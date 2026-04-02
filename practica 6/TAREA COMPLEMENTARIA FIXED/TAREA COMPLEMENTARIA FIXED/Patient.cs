namespace RegistroPacientes
{
    internal class Patient
    {
        internal int Id { get; set; }
        internal string Name { get; set; } = "";
        internal string LastName { get; set; } = "";
        internal int Age { get; set; }
        internal string Phone { get; set; } = "";
        internal string Address { get; set; } = "";
        internal string Diagnosis { get; set; } = "";

        internal Patient()
        {
        }
    }
}