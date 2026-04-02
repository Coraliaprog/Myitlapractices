using System;
using System.Collections.Generic;

namespace RegistroPacientes
{
    internal class PatientHelper
    {
        internal void AddPatient(List<Patient> patients)
        {
            Patient patient = new Patient();
            int age;
            int id;

            Console.WriteLine("===== AGREGAR PACIENTE =====");
            Console.WriteLine();

            if (patients.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = patients[patients.Count - 1].Id + 1;
            }

            patient.Id = id;

            Console.Write("Digite el nombre del paciente: ");
            patient.Name = Console.ReadLine() ?? "";

            Console.Write("Digite el apellido del paciente: ");
            patient.LastName = Console.ReadLine() ?? "";

            Console.Write("Digite la edad del paciente: ");
            while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.Write("Edad inválida. Digite una edad correcta: ");
            }
            patient.Age = age;

            Console.Write("Digite el teléfono del paciente: ");
            patient.Phone = Console.ReadLine() ?? "";

            Console.Write("Digite la dirección del paciente: ");
            patient.Address = Console.ReadLine() ?? "";

            Console.Write("Digite el diagnóstico del paciente: ");
            patient.Diagnosis = Console.ReadLine() ?? "";

            patients.Add(patient);

            Console.WriteLine();
            Console.WriteLine("Paciente agregado correctamente.");
        }

        internal void ViewPatients(List<Patient> patients)
        {
            Console.WriteLine("===== LISTA DE PACIENTES =====");
            Console.WriteLine();

            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine("ID: " + patients[i].Id);
                Console.WriteLine("Nombre: " + patients[i].Name);
                Console.WriteLine("Apellido: " + patients[i].LastName);
                Console.WriteLine("Edad: " + patients[i].Age);
                Console.WriteLine("Teléfono: " + patients[i].Phone);
                Console.WriteLine("Dirección: " + patients[i].Address);
                Console.WriteLine("Diagnóstico: " + patients[i].Diagnosis);
                Console.WriteLine("--------------------------------------");
            }
        }

        internal void SearchPatient(List<Patient> patients)
        {
            string name;
            bool found = false;

            Console.WriteLine("===== BUSCAR PACIENTE =====");
            Console.WriteLine();

            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.Write("Digite el nombre del paciente a buscar: ");
            name = (Console.ReadLine() ?? "").ToLower();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Name.ToLower() == name)
                {
                    Console.WriteLine();
                    Console.WriteLine("Paciente encontrado:");
                    Console.WriteLine("ID: " + patients[i].Id);
                    Console.WriteLine("Nombre: " + patients[i].Name);
                    Console.WriteLine("Apellido: " + patients[i].LastName);
                    Console.WriteLine("Edad: " + patients[i].Age);
                    Console.WriteLine("Teléfono: " + patients[i].Phone);
                    Console.WriteLine("Dirección: " + patients[i].Address);
                    Console.WriteLine("Diagnóstico: " + patients[i].Diagnosis);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("No se encontró el paciente.");
            }
        }

        internal void EditPatient(List<Patient> patients)
        {
            int id;
            bool found = false;
            int age;

            Console.WriteLine("===== MODIFICAR PACIENTE =====");
            Console.WriteLine();

            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.Write("Digite el ID del paciente a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    Console.Write("Nuevo nombre: ");
                    patients[i].Name = Console.ReadLine() ?? "";

                    Console.Write("Nuevo apellido: ");
                    patients[i].LastName = Console.ReadLine() ?? "";

                    Console.Write("Nueva edad: ");
                    while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                    {
                        Console.Write("Edad inválida. Digite una edad correcta: ");
                    }
                    patients[i].Age = age;

                    Console.Write("Nuevo teléfono: ");
                    patients[i].Phone = Console.ReadLine() ?? "";

                    Console.Write("Nueva dirección: ");
                    patients[i].Address = Console.ReadLine() ?? "";

                    Console.Write("Nuevo diagnóstico: ");
                    patients[i].Diagnosis = Console.ReadLine() ?? "";

                    Console.WriteLine();
                    Console.WriteLine("Paciente modificado correctamente.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No se encontró un paciente con ese ID.");
            }
        }

        internal void DeletePatient(List<Patient> patients)
        {
            int id;
            bool found = false;

            Console.WriteLine("===== ELIMINAR PACIENTE =====");
            Console.WriteLine();

            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.Write("Digite el ID del paciente a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    patients.RemoveAt(i);
                    Console.WriteLine("Paciente eliminado correctamente.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No se encontró un paciente con ese ID.");
            }
        }
    }
}