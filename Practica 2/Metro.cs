using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Metro {
    private List<Estacion> estaciones; // Lista dinámica de estaciones

    public Metro() {
        estaciones = new List<Estacion>();
    }

    // Agregar una estación al grafo
    public void AgregarEstacion(int id, string nombre) {
        if (estaciones.Exists(e => e.Id == id)) {
            Console.WriteLine($"La estación con ID {id} ya existe.");
            return;
        }
        estaciones.Add(new Estacion(id, nombre));
        Console.WriteLine($"Estación {nombre} agregada.");
    }

    // Conectar dos estaciones
    public void ConectarEstaciones(int id1, int id2) {
        Estacion estacion1 = BuscarEstacion(id1);
        Estacion estacion2 = BuscarEstacion(id2);

        if (estacion1 == null || estacion2 == null) {
            Console.WriteLine("Una o ambas estaciones no existen.");
            return;
        }

        estacion1.Conexiones.Add(estacion2);
        Console.WriteLine($"Conexión agregada: {estacion1.Nombre} -> {estacion2.Nombre}");
    }

    // Buscar una estación por ID
    public Estacion BuscarEstacion(int id) {
        return estaciones.Find(e => e.Id == id);
    }

    // Mostrar las conexiones del grafo
    public void MostrarGrafo() {
        foreach (var estacion in estaciones) {
            Console.Write($"Estación {estacion.Nombre} ({estacion.Id}): ");
            foreach (var conexion in estacion.Conexiones) {
                Console.Write($"{conexion.Nombre} -> ");
            }
            Console.WriteLine("NULL");
        }
    }

    // Exportar el grafo a formato DOT
    public void ExportarDOT(string filePath) {
        using (StreamWriter writer = new StreamWriter(filePath)) {
            writer.WriteLine("digraph Metro {");
            foreach (var estacion in estaciones) {
                foreach (var conexion in estacion.Conexiones) {
                    writer.WriteLine($"    \"{estacion.Nombre}\" -> \"{conexion.Nombre}\";");
                }
            }
            writer.WriteLine("}");
        }
        Console.WriteLine($"Archivo DOT exportado a: {filePath}");
    }

    // Generar imagen del grafo con Graphviz
    public void GenerarImagen(string dotFilePath, string outputImagePath) {
        ProcessStartInfo processInfo = new ProcessStartInfo("dot");
        processInfo.Arguments = $"-Tpng {dotFilePath} -o {outputImagePath}";
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;

        try {
            Process process = Process.Start(processInfo);
            process.WaitForExit();
            Console.WriteLine($"Imagen generada en: {outputImagePath}");
        } catch (Exception e) {
            Console.WriteLine($"Error al generar la imagen: {e.Message}");
        }
    }
}