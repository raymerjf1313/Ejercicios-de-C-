using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaProductos
{
    public static class MetodosFacturas
    {
        // Productos que todavía tienen stock, para el ComboBox de la factura.
        public static DataTable ObtenerProductosConStock()
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    "SELECT CODIGO, NOMBRE, PRECIO, STOCK FROM Productos WHERE STOCK > 0 ORDER BY NOMBRE", conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        // Guarda cabecera + detalle, descuenta stock y, si es a crédito, registra la cuenta por cobrar.
        // Todo en una sola transacción: si algo falla, no queda nada a medias.
        public static void Guardar(Factura factura)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        factura.Fecha = DateTime.Now;
                        factura.Calcular();

                        SqlCommand cabecera = new SqlCommand(
                            @"INSERT INTO Facturas (fecha, cliente, usuario, total, tipo, turno, id_cliente,
                                                    total_bruto, total_itbis, monto_pagado, devuelta)
                              OUTPUT INSERTED.id_factura
                              VALUES (@fecha, @cliente, @usuario, @total, @tipo, @turno, @idCliente,
                                      @bruto, @itbis, @pagado, @devuelta)", conexion, transaccion);
                        cabecera.Parameters.AddWithValue("@fecha", factura.Fecha);
                        cabecera.Parameters.AddWithValue("@cliente", factura.NombreCliente);
                        cabecera.Parameters.AddWithValue("@usuario", factura.UsuarioCajero);
                        cabecera.Parameters.AddWithValue("@total", factura.Total);
                        cabecera.Parameters.AddWithValue("@tipo", factura.Tipo);
                        cabecera.Parameters.AddWithValue("@turno", (object)factura.Turno ?? DBNull.Value);
                        cabecera.Parameters.AddWithValue("@idCliente", factura.IdCliente.HasValue ? (object)factura.IdCliente.Value : DBNull.Value);
                        cabecera.Parameters.AddWithValue("@bruto", factura.TotalBruto);
                        cabecera.Parameters.AddWithValue("@itbis", factura.TotalItbis);
                        cabecera.Parameters.AddWithValue("@pagado", factura.MontoPagado);
                        cabecera.Parameters.AddWithValue("@devuelta", factura.Devuelta);
                        factura.Id = (int)cabecera.ExecuteScalar();

                        foreach (DetalleFactura d in factura.Detalles)
                        {
                            SqlCommand stock = new SqlCommand(
                                @"UPDATE Productos SET STOCK = STOCK - @cantidad
                                  WHERE CODIGO = @codigo AND STOCK >= @cantidad", conexion, transaccion);
                            stock.Parameters.AddWithValue("@cantidad", d.Cantidad);
                            stock.Parameters.AddWithValue("@codigo", d.Codigo);
                            if (stock.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException("Stock insuficiente para: " + d.Nombre);

                            SqlCommand detalle = new SqlCommand(
                                @"INSERT INTO DetalleFactura (id_factura, codigo, nombre, precio, cantidad, subtotal, itbis)
                                  VALUES (@factura, @codigo, @nombre, @precio, @cantidad, @subtotal, @itbis)", conexion, transaccion);
                            detalle.Parameters.AddWithValue("@factura", factura.Id);
                            detalle.Parameters.AddWithValue("@codigo", d.Codigo);
                            detalle.Parameters.AddWithValue("@nombre", d.Nombre);
                            detalle.Parameters.AddWithValue("@precio", d.Precio);
                            detalle.Parameters.AddWithValue("@cantidad", d.Cantidad);
                            detalle.Parameters.AddWithValue("@subtotal", d.Valor);
                            detalle.Parameters.AddWithValue("@itbis", d.Itbis);
                            detalle.ExecuteNonQuery();
                        }

                        if (factura.EsCredito)
                        {
                            SqlCommand cxc = new SqlCommand(
                                @"INSERT INTO CuentasPorCobrar (id_factura, id_cliente, fecha, monto, saldo, estado)
                                  VALUES (@factura, @cliente, @fecha, @monto, @monto, 'Pendiente')", conexion, transaccion);
                            cxc.Parameters.AddWithValue("@factura", factura.Id);
                            cxc.Parameters.AddWithValue("@cliente", factura.IdCliente.Value);
                            cxc.Parameters.AddWithValue("@fecha", factura.Fecha);
                            cxc.Parameters.AddWithValue("@monto", factura.Total);
                            cxc.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
