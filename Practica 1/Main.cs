using System;

class Program {
    static void Main(string[] args) {
        ListaEnlazada lista = new ListaEnlazada();
        int opcion, valor;

        do {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Agregar al inicio");
            Console.WriteLine("2. Agregar al final");
            Console.WriteLine("3. Eliminar un valor");
            Console.WriteLine("4. Buscar un valor");
            Console.WriteLine("5. Mostrar la lista");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1:
                    Console.Write("Ingrese el valor a agregar al inicio: ");
                    valor = int.Parse(Console.ReadLine());
                    lista.AgregarInicio(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a agregar al final: ");
                    valor = int.Parse(Console.ReadLine());
                    lista.AgregarFinal(valor);
                    break;
                case 3:
                    Console.Write("Ingrese el valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    lista.EliminarNodo(valor);
                    break;
                case 4:
                    Console.Write("Ingrese el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    if (lista.Buscar(valor)) {
                        Console.WriteLine("Valor encontrado!");
                    } else {
                        Console.WriteLine("Valor no encontrado!");
                    }
                    break;
                case 5:
                    Console.WriteLine("Lista actual:");
                    lista.Mostrar();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida!");
                    break;
            }
        } while (opcion != 6);
    }
}