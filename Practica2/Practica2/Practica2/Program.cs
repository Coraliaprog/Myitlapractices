using System;
bool continuar = true;
while (continuar)
{
    Console.WriteLine("Ingrese un número entero:");
    int numero = Convert.ToInt32(Console.ReadLine());

    if (numero % 2 == 0)
    {
        Console.WriteLine("El número es par.");
    }
    else
    {
        Console.WriteLine("El número es impar.");
    }

    Console.WriteLine("¿Desea ingresar otro número? (s/n)");
    string respuesta = Console.ReadLine().ToLower();

    if (respuesta != "s")
    {
        continuar = false;
    }
}