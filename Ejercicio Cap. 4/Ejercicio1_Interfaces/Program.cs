// Ejercicio 1: Interface múltiple (basado en el ejemplo D/029, pág. 70 del libro)
// Una clase puede implementar dos o más interfaces.
namespace Ejercicio1_Interfaces;

// Interface que obliga a hacer los cálculos
// (el estándar dice que el nombre empieza con "I")
interface ICalculos {
	double Area();
	double Perimetro();
}

// Otra interface que obliga a mostrar los resultados
interface IMuestra {
	void VerArea();
	void VerPerimetro();
}

// Circulo implementa las DOS interfaces
class Circulo : ICalculos, IMuestra {
	public double Radio { get; set; }

	public Circulo(double Radio) {
		this.Radio = Radio;
	}

	// Métodos exigidos por ICalculos
	public double Area() {
		return Math.PI * Radio * Radio;
	}

	public double Perimetro() {
		return 2 * Math.PI * Radio;
	}

	// Métodos exigidos por IMuestra
	public void VerArea() {
		Console.WriteLine("Área círculo: " + Area());
	}

	public void VerPerimetro() {
		Console.WriteLine("Perímetro círculo: " + Perimetro());
	}
}

// Cuadrado también implementa las DOS interfaces
class Cuadrado : ICalculos, IMuestra {
	public double Lado { get; set; }

	public Cuadrado(double Lado) {
		this.Lado = Lado;
	}

	public double Area() {
		return Lado * Lado;
	}

	public double Perimetro() {
		return 4 * Lado;
	}

	public void VerArea() {
		Console.WriteLine("Área cuadrado: " + Area());
	}

	public void VerPerimetro() {
		Console.WriteLine("Perímetro cuadrado: " + Perimetro());
	}
}

// Inicia la aplicación aquí
class Program {
	static void Main() {
		Console.OutputEncoding = System.Text.Encoding.UTF8; // para ver tildes en consola

		// Instancia las clases
		Cuadrado objCuadrado = new(5);
		Circulo objCirculo = new(5);

		// Imprime los valores
		objCuadrado.VerArea();
		objCuadrado.VerPerimetro();

		objCirculo.VerArea();
		objCirculo.VerPerimetro();

		// Extra: como ambas clases cumplen el contrato IMuestra,
		// se pueden guardar en un mismo arreglo y tratarlas igual (polimorfismo)
		Console.WriteLine("\nRecorriendo las figuras como IMuestra:");
		IMuestra[] figuras = { new Cuadrado(3), new Circulo(2) };
		foreach (IMuestra figura in figuras) {
			figura.VerArea();
		}
	}
}
