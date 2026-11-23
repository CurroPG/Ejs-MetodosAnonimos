using System;
using System.Collections.Generic;

namespace MetodosAnonimos
{
    internal class Program
    {
        public delegate int Multiplicar(int a, int b);
        public delegate bool VerificarPalindromo(string palabra);
        public delegate double ConvertirTemperatura(double celsius);
        public delegate bool EsMayorQueDiez(int numero);
        public delegate bool CompararLongitud(string palabra1, string palabra2);
        public delegate int CalcularFactorial(int numero);
        public delegate int ContarCaracteres(string palabra);
        public delegate void Operacion(int numero);
        public delegate bool Filtro(Producto producto);
        public delegate bool FiltroEmpleado(Empleado empleado);
        public delegate bool FiltroLibros(Libro libro);
        public delegate bool FiltroVehiculo(Vehiculo vehiculo);

        static void Main(string[] args)
        {
            Ejercicio1();
            Ejercicio2();
            Ejercicio3();
            Ejercicio4();
            Ejercicio5();
            Ejercicio6();
            Ejercicio7();
            Ejercicio8();
            Ejercicio9();
            Ejercicio10();
            Ejercicio11();
            Ejercicio12();

            Console.ReadKey();
        }

        static void Ejercicio1()
        {
            Console.WriteLine("\n--- Ejercicio 1 ---");
            Multiplicar multiplicar = delegate (int a, int b)
            {
                return a * b;
            };

            Console.WriteLine($"4 * 3 = {multiplicar(4, 3)}");
            Console.WriteLine($"7 * 5 = {multiplicar(7, 5)}");
        }

        static void Ejercicio2()
        {
            Console.WriteLine("\n--- Ejercicio 2 ---");
            VerificarPalindromo verificar = delegate (string palabra)
            {
                char[] letras = palabra.ToCharArray();
                Array.Reverse(letras);
                string alReves = new string(letras);
                return palabra == alReves;
            };

            Console.WriteLine($"'radar' es un palíndromo: {verificar("radar")}");
            Console.WriteLine($"'puerta' es un palíndromo: {verificar("puerta")}");
        }

        static void Ejercicio3()
        {
            Console.WriteLine("\n--- Ejercicio 3 ---");
            ConvertirTemperatura convertir = delegate (double celsius)
            {
                return celsius * 9 / 5 + 32;
            };

            Console.WriteLine($"0°C -> {convertir(0)}°F");
            Console.WriteLine($"30°C -> {convertir(30)}°F");
        }

        static void Ejercicio4()
        {
            Console.WriteLine("\n--- Ejercicio 4 ---");
            EsMayorQueDiez esMayor = delegate (int numero)
            {
                return numero > 10;
            };

            Console.WriteLine($"8 es mayor que 10: {esMayor(8)}");
            Console.WriteLine($"15 es mayor que 10: {esMayor(15)}");
        }

        static void Ejercicio5()
        {
            Console.WriteLine("\n--- Ejercicio 5 ---");
            CompararLongitud comparar = delegate (string palabra1, string palabra2)
            {
                return palabra1.Length == palabra2.Length;
            };

            Console.WriteLine($"Las palabras 'gato' y 'perro' tienen la misma longitud: {comparar("gato", "perro")}");
        }

        static void Ejercicio6()
        {
            Console.WriteLine("\n--- Ejercicio 6 ---");
            CalcularFactorial factorial = delegate (int numero)
            {
                int resultado = 1;
                for (int i = 2; i <= numero; i++)
                {
                    resultado *= i;
                }
                return resultado;
            };

            Console.WriteLine($"Factorial de 4 es {factorial(4)}");
            Console.WriteLine($"Factorial de 6 es {factorial(6)}");
        }

        static void Ejercicio7()
        {
            Console.WriteLine("\n--- Ejercicio 7 ---");
            ContarCaracteres contar = delegate (string palabra)
            {
                return palabra.Length;
            };

            Console.WriteLine($"La palabra 'mundo' tiene {contar("mundo")} caracteres");
            Console.WriteLine($"La palabra 'programa' tiene {contar("programa")} caracteres");
        }

        static void Ejercicio8()
        {
            Console.WriteLine("\n--- Ejercicio 8 ---");
            Operacion esPar = delegate (int numero)
            {
                Console.WriteLine($"El número {numero} es par: {numero % 2 == 0}");
            };

            ProcesarNumero(4, esPar);
            ProcesarNumero(7, esPar);
        }

        static void ProcesarNumero(int numero, Operacion operacion)
        {
            operacion(numero);
        }

        static void Ejercicio9()
        {
            Console.WriteLine("\n--- Ejercicio 9 ---");
            List<Producto> productos = new List<Producto>
            {
                new Producto { Nombre = "Televisor", Cantidad = 10 },
                new Producto { Nombre = "Microondas", Cantidad = 3 },
                new Producto { Nombre = "Refrigerador", Cantidad = 7 },
                new Producto { Nombre = "Lavadora", Cantidad = 2 }
            };

            int cantidadMinima = 5;
            Filtro filtro = delegate (Producto producto)
            {
                return producto.Cantidad > cantidadMinima;
            };

            Console.WriteLine($"Productos con cantidad mayor a {cantidadMinima}:");
            MostrarProductosFiltrados(productos, filtro);
        }

        static void MostrarProductosFiltrados(List<Producto> productos, Filtro filtro)
        {
            foreach (Producto producto in productos)
            {
                if (filtro(producto))
                {
                    Console.WriteLine($"- {producto.Nombre} (Cantidad: {producto.Cantidad})");
                }
            }
        }

        static void Ejercicio10()
        {
            Console.WriteLine("\n--- Ejercicio 10 ---");
            List<Empleado> empleados = new List<Empleado>
            {
                new Empleado { Nombre = "Ana", Edad = 35 },
                new Empleado { Nombre = "Pedro", Edad = 28 },
                new Empleado { Nombre = "Luis", Edad = 42 },
                new Empleado { Nombre = "Lucía", Edad = 24 }
            };

            FiltroEmpleado filtro = delegate (Empleado empleado)
            {
                return empleado.Edad > 30;
            };

            Console.WriteLine("Empleados mayores de 30 años:");
            FiltrarEmpleados(empleados, filtro);
        }

        static void FiltrarEmpleados(List<Empleado> empleados, FiltroEmpleado filtro)
        {
            foreach (Empleado empleado in empleados)
            {
                if (filtro(empleado))
                {
                    Console.WriteLine($"- {empleado.Nombre} (Edad: {empleado.Edad})");
                }
            }
        }

        static void Ejercicio11()
        {
            Console.WriteLine("\n--- Ejercicio 11 ---");
            List<Libro> libros = new List<Libro>
            {
                new Libro { Titulo = "El Hobbit", Categoria = "Ficción" },
                new Libro { Titulo = "Breve historia del tiempo", Categoria = "Ciencia" },
                new Libro { Titulo = "Harry Potter", Categoria = "Ficción" },
                new Libro { Titulo = "Atlas del mundo", Categoria = "Geografía" }
            };

            FiltroLibros filtro = delegate (Libro libro)
            {
                return libro.Categoria == "Ficción";
            };

            Console.WriteLine("Libros de la categoría Ficción:");
            MostrarLibrosPorCategoria(libros, filtro);
        }

        static void MostrarLibrosPorCategoria(List<Libro> libros, FiltroLibros filtro)
        {
            foreach (Libro libro in libros)
            {
                if (filtro(libro))
                {
                    Console.WriteLine($"- {libro.Titulo}");
                }
            }
        }

        static void Ejercicio12()
        {
            Console.WriteLine("\n--- Ejercicio 12 ---");
            List<Vehiculo> vehiculos = new List<Vehiculo>
            {
                new Vehiculo { Marca = "Toyota", Modelo = "Corolla", AnioFabricacion = 2005 },
                new Vehiculo { Marca = "Seat", Modelo = "León", AnioFabricacion = 2015 },
                new Vehiculo { Marca = "Honda", Modelo = "Civic", AnioFabricacion = 2008 },
                new Vehiculo { Marca = "Ford", Modelo = "Focus", AnioFabricacion = 2019 }
            };

            FiltroVehiculo filtro = delegate (Vehiculo vehiculo)
            {
                return vehiculo.AnioFabricacion < 2010;
            };

            Console.WriteLine("Vehículos fabricados antes de 2010:");
            MostrarVehiculosAntiguos(vehiculos, filtro);
        }

        static void MostrarVehiculosAntiguos(List<Vehiculo> vehiculos, FiltroVehiculo filtro)
        {
            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (filtro(vehiculo))
                {
                    Console.WriteLine($"- {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.AnioFabricacion})");
                }
            }
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    public class Libro
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
    }

    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
    }
}