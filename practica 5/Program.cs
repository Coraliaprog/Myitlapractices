using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

Console.Title = "Agenda Personal - Contactes";

Console.WriteLine("=======================================");
Console.WriteLine("   Agenda Personal - Contactes (POO)");
Console.WriteLine("   Autor: Coralia Cruceta");
Console.WriteLine("=======================================");
Console.WriteLine("Bienvenido a mi lista de Contactes");

List<Contact> contacts = new List<Contact>();

bool runing = true;

while (runing)
{
    Console.WriteLine(@"
1. Agregar Contacto
2. Ver Contactos
3. Buscar Contactos
4. Modificar Contacto
5. Eliminar Contacto
6. Salir");

    Console.WriteLine("Digite el número de la opción deseada");

    if (!int.TryParse(Console.ReadLine(), out int typeOption))
    {
        Console.WriteLine("Opción inválida.");
        continue;
    }

    switch (typeOption)
    {
        case 1:
            ContactHelper.AddContact(contacts);
            break;

        case 2:
            ContactHelper.ViewContacts(contacts);
            break;

        case 3:
            ContactHelper.SearchContact(contacts);
            break;

        case 4:
            ContactHelper.ModifyContact(contacts);
            break;

        case 5:
            ContactHelper.DeleteContact(contacts);
            break;

        case 6:
            runing = false;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }

    Console.WriteLine();
}
