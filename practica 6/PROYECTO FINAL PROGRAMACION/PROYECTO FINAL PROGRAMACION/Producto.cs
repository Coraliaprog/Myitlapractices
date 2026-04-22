namespace PROYECTO_FINAL_PROGRAMACION;

public class Producto
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }

    public Producto()
    {
    }

    public Producto(string nombre, int cantidad, string? descripcion, decimal precio)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        FechaRegistro = DateTime.Now;
        Descripcion = descripcion;
        Precio = precio;
    }
}