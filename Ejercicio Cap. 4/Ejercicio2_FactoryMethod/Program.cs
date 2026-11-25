// Ejercicio 2: Patrón de diseño Factory Method (basado en el ejemplo D/040, pág. 93 del libro)
// Permite crear objetos sin especificar su clase exacta: un método "fábrica"
// decide qué objeto crear según el parámetro que recibe.
namespace Ejercicio2_FactoryMethod;

// Interface que obliga a definir el método Dibujar
interface IFigura {
	void Dibujar();
}

class Circulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Se hace el dibujo de un círculo");
	}
}

class Rectangulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Estoy dibujando un rectángulo");
	}
}

class Triangulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Ahora se dibuja un triángulo");
	}
}

// La fábrica: dependiendo del parámetro retorna uno u otro objeto
class FabricaFiguras {
	public IFigura? GetFigura(string TipoFigura) {
		if (TipoFigura.Equals("CIRCULO"))
			return new Circulo();

		if (TipoFigura.Equals("RECTANGULO"))
			return new Rectangulo();

		if (TipoFigura.Equals("TRIANGULO"))
			return new Triangulo();

		return null; // tipo desconocido
	}
}

class Program {
	static void Main() {
		Console.OutputEncoding = System.Text.Encoding.UTF8; // para ver tildes en consola

		FabricaFiguras objeto = new();

		// Obtiene un objeto círculo y lo dibuja
		IFigura? Figura1 = objeto.GetFigura("CIRCULO");
		Figura1?.Dibujar();

		// Obtiene un objeto rectángulo y lo dibuja
		IFigura? Figura2 = objeto.GetFigura("RECTANGULO");
		Figura2?.Dibujar();

		// Obtiene un objeto triángulo y lo dibuja
		IFigura? Figura3 = objeto.GetFigura("TRIANGULO");
		Figura3?.Dibujar();

		// Extra: el usuario elige la figura en tiempo de ejecución.
		// Main nunca hace "new Circulo()": eso lo decide la fábrica.
		Console.Write("\nEscriba una figura (CIRCULO, RECTANGULO, TRIANGULO): ");
		string tipo = (Console.ReadLine() ?? "").Trim().ToUpper();

		IFigura? elegida = objeto.GetFigura(tipo);
		if (elegida != null)
			elegida.Dibujar();
		else
			Console.WriteLine("La fábrica no sabe crear: " + tipo);
	}
}
