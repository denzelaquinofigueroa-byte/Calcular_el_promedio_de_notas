using System;

class Program
{
    static void Main(string[] args)
    {
        string nombre;
        double nota;

        try
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            nombre = Console.ReadLine();

            Console.Write("Ingrese la nota del estudiante (0-100): ");

            nota = double.Parse(Console.ReadLine());

            if (nota < 0 || nota > 100)
            {
                Console.WriteLine("Error: La nota debe estar entre 0 y 100.");
            }
            else
            {
                Console.WriteLine("\n===== RESULTADO =====");
                Console.WriteLine("Estudiante: " + nombre);
                Console.WriteLine("Nota: " + nota);

                if (nota >= 70)
                {
                    Console.WriteLine("Estado: APROBADO");
                }
                else
                {
                    Console.WriteLine("Estado: REPROBADO");
                }
            }
        }

        catch (FormatException)
        {
            Console.WriteLine("Error: Debe ingresar un valor numérico válido.");
        }

        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }

        finally
        {
            Console.WriteLine("\nProceso finalizado.");
        }

        Console.ReadKey();
    }
}