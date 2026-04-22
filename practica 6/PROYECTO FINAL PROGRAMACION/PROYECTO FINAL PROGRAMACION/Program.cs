using PROYECTO_FINAL_PROGRAMACION;

Console.Title = "Control de Inventario de Utiles Escolares";

Console.WriteLine("==============================================");
Console.WriteLine("   Control de Inventario de Utiles Escolares");
Console.WriteLine("   Autor: Coralia Cruceta");
Console.WriteLine("==============================================");
Console.WriteLine("Bienvenido al sistema de inventario");

ProductoRepository productoRepository = new ProductoRepository();

bool runing = true;

while (runing)
{
    Console.WriteLine(@"
1. Agregar Producto
2. Ver Productos
3. Buscar Producto
4. Modificar Producto
5. Eliminar Producto
6. Registrar Entrada
7. Registrar Salida
8. Salir");

    Console.WriteLine("Digite el número de la opción deseada");

    if (!int.TryParse(Console.ReadLine(), out int typeOption))
    {
        Console.WriteLine("Opción inválida.");
        continue;
    }

    switch (typeOption)
    {
        case 1:
            AddProduct(productoRepository);
            break;

        case 2:
            ViewProducts(productoRepository);
            break;

        case 3:
            SearchProduct(productoRepository);
            break;

        case 4:
            ModifyProduct(productoRepository);
            break;

        case 5:
            DeleteProduct(productoRepository);
            break;

        case 6:
            RegisterEntry(productoRepository);
            break;

        case 7:
            RegisterExit(productoRepository);
            break;

        case 8:
            runing = false;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }

    Console.WriteLine();
}

static void AddProduct(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Agregar Producto ===");

    Console.Write("Digite el nombre del producto: ");
    string? nombre = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nombre))
    {
        Console.WriteLine("El nombre es obligatorio.");
        return;
    }

    Console.Write("Digite la descripción: ");
    string? descripcion = Console.ReadLine();

    Console.Write("Digite la cantidad: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    Console.Write("Digite el precio: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio < 0)
    {
        Console.WriteLine("Precio inválido.");
        return;
    }

    Producto producto = new Producto(nombre, cantidad, descripcion, precio);

    productoRepository.AgregarProducto(producto);
    Console.WriteLine("Producto agregado correctamente.");
}

static void ViewProducts(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Ver Productos ===");

    List<Producto> productos = productoRepository.VerProductos();

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    Console.WriteLine("ID\tNombre\t\tCantidad\tPrecio");
    Console.WriteLine("------------------------------------------------------");

    foreach (Producto producto in productos)
    {
        Console.WriteLine($"{producto.ProductoId}\t{producto.Nombre}\t\t{producto.Cantidad}\t\t{producto.Precio}");
    }
}

static void SearchProduct(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Buscar Producto ===");

    Console.Write("Digite el ID del producto: ");
    if (!int.TryParse(Console.ReadLine(), out int productoId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Producto? producto = productoRepository.BuscarProductoPorId(productoId);

    if (producto == null)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    Console.WriteLine($"ID: {producto.ProductoId}");
    Console.WriteLine($"Nombre: {producto.Nombre}");
    Console.WriteLine($"Descripción: {producto.Descripcion}");
    Console.WriteLine($"Cantidad: {producto.Cantidad}");
    Console.WriteLine($"Precio: {producto.Precio}");
    Console.WriteLine($"Fecha de Registro: {producto.FechaRegistro}");
}

static void ModifyProduct(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Modificar Producto ===");

    Console.Write("Digite el ID del producto a modificar: ");
    if (!int.TryParse(Console.ReadLine(), out int productoId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Producto? producto = productoRepository.BuscarProductoPorId(productoId);

    if (producto == null)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    Console.Write($"El nombre es: {producto.Nombre}, Digite el nuevo nombre: ");
    string? nuevoNombre = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nuevoNombre))
    {
        Console.WriteLine("El nombre es obligatorio.");
        return;
    }

    Console.Write($"La descripción es: {producto.Descripcion}, Digite la nueva descripción: ");
    string? nuevaDescripcion = Console.ReadLine();

    Console.Write($"La cantidad es: {producto.Cantidad}, Digite la nueva cantidad: ");
    if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad) || nuevaCantidad < 0)
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    Console.Write($"El precio es: {producto.Precio}, Digite el nuevo precio: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) || nuevoPrecio < 0)
    {
        Console.WriteLine("Precio inválido.");
        return;
    }

    producto.Nombre = nuevoNombre;
    producto.Descripcion = nuevaDescripcion;
    producto.Cantidad = nuevaCantidad;
    producto.Precio = nuevoPrecio;

    bool modified = productoRepository.ModificarProducto(producto);

    if (modified)
    {
        Console.WriteLine("Producto modificado correctamente.");
    }
    else
    {
        Console.WriteLine("No se pudo modificar el producto.");
    }
}

static void DeleteProduct(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Eliminar Producto ===");

    Console.Write("Digite el ID del producto a eliminar: ");
    if (!int.TryParse(Console.ReadLine(), out int productoId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Opción inválida.");
        return;
    }

    if (option == 1)
    {
        bool deleted = productoRepository.EliminarProducto(productoId);

        if (deleted)
        {
            Console.WriteLine("Producto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo eliminar el producto.");
        }
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}

static void RegisterEntry(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Registrar Entrada ===");

    Console.Write("Digite el ID del producto: ");
    if (!int.TryParse(Console.ReadLine(), out int productoId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Console.Write("Digite la cantidad a agregar: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    bool registered = productoRepository.RegistrarEntrada(productoId, cantidad);

    if (registered)
    {
        Console.WriteLine("Entrada registrada correctamente.");
    }
    else
    {
        Console.WriteLine("No se pudo registrar la entrada.");
    }
}

static void RegisterExit(ProductoRepository productoRepository)
{
    Console.WriteLine("=== Registrar Salida ===");

    Console.Write("Digite el ID del producto: ");
    if (!int.TryParse(Console.ReadLine(), out int productoId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Console.Write("Digite la cantidad a retirar: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    bool registered = productoRepository.RegistrarSalida(productoId, cantidad);

    if (registered)
    {
        Console.WriteLine("Salida registrada correctamente.");
    }
    else
    {
        Console.WriteLine("No se pudo registrar la salida. Verifique el stock disponible.");
    }
}