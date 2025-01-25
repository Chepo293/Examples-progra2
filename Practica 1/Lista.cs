public class Lista {
    private Nodo cabeza;

    public Lista() {
        cabeza = null;
    }

    public void AgregarInicio(int valor) {
        Nodo nuevo = new Nodo(valor);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
    }

    public void AgregarFinal(int valor) {
        Nodo nuevo = new Nodo(valor);
        if (cabeza == null) {
            cabeza = nuevo;
        } else {
            Nodo temp = cabeza;
            while (temp.Siguiente != null) {
                temp = temp.Siguiente;
            }
            temp.Siguiente = nuevo;
        }
    }

    public void EliminarNodo(int valor) {
        if (cabeza == null) return;

        if (cabeza.Valor == valor) {
            cabeza = cabeza.Siguiente;
            return;
        }

        Nodo temp = cabeza;
        while (temp.Siguiente != null && temp.Siguiente.Valor != valor) {
            temp = temp.Siguiente;
        }

        if (temp.Siguiente != null) {
            temp.Siguiente = temp.Siguiente.Siguiente;
        }
    }

    public bool Buscar(int valor) {
        Nodo temp = cabeza;
        while (temp != null) {
            if (temp.Valor == valor) return true;
            temp = temp.Siguiente;
        }
        return false;
    }

    public void Mostrar() {
        Nodo temp = cabeza;
        while (temp != null) {
            Console.Write(temp.Valor + " -> ");
            temp = temp.Siguiente;
        }
        Console.WriteLine("NULL");
    }
}