public class Estacion {
    public int Id { get; set; }         
    public string Nombre { get; set; } 
    public List<Estacion> Conexiones { get; set; }

    public Estacion(int id, string nombre) {
        Id = id;
        Nombre = nombre;
        Conexiones = new List<Estacion>();
    }
}