// Ejercicio 3: Principios SOLID (basado en el ejemplo D/048, pág. 116 del libro)
namespace Ejercicio3_SOLID;

// S: Single Responsibility Principle (Responsabilidad Única)
// Pedido SOLO se encarga de los datos del pedido.
public class Pedido {
	public int Codigo { get; set; }
	public decimal TotalCosto { get; set; }

	public Pedido(int Codigo, decimal TotalCosto) {
		this.Codigo = Codigo;
		this.TotalCosto = TotalCosto;
	}
}

// Esta clase SOLO se encarga de guardar (persistir) los pedidos
public class PersistePedidos {
	public void Guardar(Pedido objPedido) {
		Console.WriteLine("Pedido: " + objPedido.Codigo + " guardado con un total de: " + objPedido.TotalCosto);
	}
}

// O: Open/Closed Principle (Abierto/Cerrado)
// Se pueden agregar nuevos descuentos creando clases nuevas,
// sin modificar las que ya existen.
public interface IDescuento {
	decimal AplicaDescuento(decimal TotalCosto);
}

public class SinDescuento : IDescuento {
	public decimal AplicaDescuento(decimal TotalCosto) {
		return TotalCosto;
	}
}

public class DescuentoTemporada : IDescuento {
	public decimal AplicaDescuento(decimal TotalCosto) {
		return TotalCosto * 0.9m; // 10% de descuento
	}
}

// L: Liskov Substitution Principle (Sustitución de Liskov)
// Cualquier hija de Notificacion puede usarse en su lugar sin romper el programa.
public abstract class Notificacion {
	public abstract void Notificar(string Mensaje);
}

public class EmailNotificacion : Notificacion {
	public override void Notificar(string Mensaje) {
		Console.WriteLine("Correo enviado: " + Mensaje);
	}
}

public class SmsNotificacion : Notificacion {
	public override void Notificar(string Mensaje) {
		Console.WriteLine("SMS enviado: " + Mensaje);
	}
}

// I: Interface Segregation Principle (Segregación de Interfaces)
// Interface pequeña: las clases solo implementan lo que necesitan.
public interface IProcesoPago {
	void Pago(decimal Precio);
}

public class TarjetaCredito : IProcesoPago {
	public void Pago(decimal Precio) {
		Console.WriteLine("Pago con tarjeta crédito de: " + Precio + " fue procesado.");
	}
}

public class PorPayPal : IProcesoPago {
	public void Pago(decimal Precio) {
		Console.WriteLine("Pago con PayPal de: " + Precio + " fue procesado.");
	}
}

// D: Dependency Inversion Principle (Inversión de Dependencias)
// ServicioPedido depende de abstracciones (IDescuento, Notificacion, IProcesoPago),
// no de clases concretas. Las recibe por el constructor ("inyección de dependencias").
public class ServicioPedido {
	private readonly IDescuento _descuento;
	private readonly Notificacion _notificacion;
	private readonly PersistePedidos _repositorio;
	private readonly IProcesoPago _formadePago;

	public ServicioPedido(IDescuento descuento, Notificacion notificacion, PersistePedidos repositorio, IProcesoPago formadePago) {
		_descuento = descuento;
		_notificacion = notificacion;
		_repositorio = repositorio;
		_formadePago = formadePago;
	}

	public void ProcesarPedido(Pedido objPedido) {
		// Aplicar descuento
		objPedido.TotalCosto = _descuento.AplicaDescuento(objPedido.TotalCosto);

		// Procesar pago
		_formadePago.Pago(objPedido.TotalCosto);

		// Guardar pedido
		_repositorio.Guardar(objPedido);

		// Enviar notificación
		_notificacion.Notificar("Pedido " + objPedido.Codigo + " procesado exitosamente con un total de: " + objPedido.TotalCosto);
	}
}

// Uso
class Program {
	static void Main() {
		Console.OutputEncoding = System.Text.Encoding.UTF8; // para ver tildes en consola

		Console.WriteLine("=== Pedido 1: descuento de temporada, tarjeta y correo ===");
		var objPedido = new Pedido(1, 100m);

		// Inyectar dependencias
		var Descuento = new DescuentoTemporada();
		var Notificacion = new EmailNotificacion();
		var Persistencia = new PersistePedidos();
		var MododePago = new TarjetaCredito();

		var objServicioPedido = new ServicioPedido(Descuento, Notificacion, Persistencia, MododePago);

		// Procesar pedido
		objServicioPedido.ProcesarPedido(objPedido);

		// Extra: SIN tocar ServicioPedido, cambiamos el comportamiento
		// pasándole otras implementaciones (esto demuestra O, L y D).
		Console.WriteLine("\n=== Pedido 2: sin descuento, PayPal y SMS ===");
		var otroServicio = new ServicioPedido(new SinDescuento(), new SmsNotificacion(), new PersistePedidos(), new PorPayPal());
		otroServicio.ProcesarPedido(new Pedido(2, 250m));
	}
}
