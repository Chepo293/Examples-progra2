using System;

class Program {
    static void Main(string[] args) {
        GrafoMetro metro = new GrafoMetro();
        string dotFilePath = "metro.dot";
        string imagePath = "metro.png";
        int opcion;

        do {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Agregar estación");
            Console.WriteLine("2. Conectar estaciones");
            Console.WriteLine("3. Mostrar grafo");
            Console.WriteLine("4. Exportar a DOT");
            Console.WriteLine("5. Generar imagen con Graphviz");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1:
                    Console.Write("Ingrese el ID de la estación: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre de la estación: ");
                    string nombre = Console.ReadLine();
                    metro.AgregarEstacion(id, nombre);
                    break;
                case 2:
                    Console.Write("Ingrese el ID de la estación de origen: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el ID de la estación de destino: ");
                    int id2 = int.Parse(Console.ReadLine());
                    metro.ConectarEstaciones(id1, id2);
                    break;
                case 3:
                    metro.MostrarGrafo();
                    break;
                case 4:
                    metro.ExportarDOT(dotFilePath);
                    break;
                case 5:
                    metro.GenerarImagen(dotFilePath, imagePath);
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}