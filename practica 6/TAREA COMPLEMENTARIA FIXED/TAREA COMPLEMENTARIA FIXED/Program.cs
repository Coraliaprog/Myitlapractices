using System;
using System.Collections.Generic;
using RegistroPacientes;

Console.WriteLine("Sistema de Registro de Pacientes");
Console.WriteLine("Bienvenido al sistema");

List<Patient> patients = new List<Patient>();
PatientHelper helper = new PatientHelper();

bool running = true;
while (running)
{
    Console.Write("1. Agregar Paciente      ");
    Console.Write("2. Ver Pacientes      ");
    Console.Write("3. Buscar Paciente      ");
    Console.Write("4. Modificar Paciente      ");
    Console.WriteLine("5. Eliminar Paciente      ");
    Console.Write("6. Salir");
    Console.WriteLine();
    Console.Write("Elige una opción: ");

    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.Write("Opción inválida. Elige una opción válida: ");
    }

    switch (choice)
    {
        case 1:
            helper.AddPatient(patients);
            break;
        case 2:
            helper.ViewPatients(patients);
            break;
        case 3:
            helper.SearchPatient(patients);
            break;
        case 4:
            helper.EditPatient(patients);
            break;
        case 5:
            helper.DeletePatient(patients);
            break;
        case 6:
            running = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    Console.WriteLine();
}