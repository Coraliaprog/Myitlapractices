using Microsoft.Data.SqlClient;


namespace PROYECTO_FINAL_PROGRAMACION;

public class ProductoRepository : DatabaseBase
{
    public void AgregarProducto(Producto producto)
    {
        const string sql = @"
            INSERT INTO Productos (Nombre, Cantidad, FechaRegistro, Descripcion, Precio)
            VALUES (@Nombre, @Cantidad, GETDATE(), @Descripcion, @Precio);";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
        command.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
        command.Parameters.AddWithValue("@Descripcion", (object?)producto.Descripcion ?? DBNull.Value);
        command.Parameters.AddWithValue("@Precio", producto.Precio);

        command.ExecuteNonQuery();
    }

    public List<Producto> VerProductos()
    {
        List<Producto> productos = new List<Producto>();

        const string sql = @"
            SELECT ProductoId, Nombre, Cantidad, FechaRegistro, Descripcion, Precio
            FROM Productos
            ORDER BY ProductoId;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Producto producto = new Producto
            {
                ProductoId = Convert.ToInt32(reader["ProductoId"]),
                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                Descripcion = reader["Descripcion"] == DBNull.Value ? null : reader["Descripcion"].ToString(),
                Precio = Convert.ToDecimal(reader["Precio"])
            };

            productos.Add(producto);
        }

        return productos;
    }

    public Producto? BuscarProductoPorId(int productoId)
    {
        const string sql = @"
            SELECT ProductoId, Nombre, Cantidad, FechaRegistro, Descripcion, Precio
            FROM Productos
            WHERE ProductoId = @ProductoId;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ProductoId", productoId);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            Producto producto = new Producto
            {
                ProductoId = Convert.ToInt32(reader["ProductoId"]),
                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                Descripcion = reader["Descripcion"] == DBNull.Value ? null : reader["Descripcion"].ToString(),
                Precio = Convert.ToDecimal(reader["Precio"])
            };

            return producto;
        }

        return null;
    }

    public bool ModificarProducto(Producto producto)
    {
        const string sql = @"
            UPDATE Productos
            SET Nombre = @Nombre,
                Cantidad = @Cantidad,
                Descripcion = @Descripcion,
                Precio = @Precio
            WHERE ProductoId = @ProductoId;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ProductoId", producto.ProductoId);
        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
        command.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
        command.Parameters.AddWithValue("@Descripcion", (object?)producto.Descripcion ?? DBNull.Value);
        command.Parameters.AddWithValue("@Precio", producto.Precio);

        return command.ExecuteNonQuery() > 0;
    }

    public bool EliminarProducto(int productoId)
    {
        const string sql = "DELETE FROM Productos WHERE ProductoId = @ProductoId;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ProductoId", productoId);

        return command.ExecuteNonQuery() > 0;
    }

    public bool RegistrarEntrada(int productoId, int cantidad)
    {
        const string sql = @"
            UPDATE Productos
            SET Cantidad = Cantidad + @Cantidad
            WHERE ProductoId = @ProductoId;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ProductoId", productoId);
        command.Parameters.AddWithValue("@Cantidad", cantidad);

        return command.ExecuteNonQuery() > 0;
    }

    public bool RegistrarSalida(int productoId, int cantidad)
    {
        const string sql = @"
            UPDATE Productos
            SET Cantidad = Cantidad - @Cantidad
            WHERE ProductoId = @ProductoId
              AND Cantidad >= @Cantidad;";

        using var connection = GetConnection();
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ProductoId", productoId);
        command.Parameters.AddWithValue("@Cantidad", cantidad);

        return command.ExecuteNonQuery() > 0;
    }
}