namespace PROYECTO_FINAL_PROGRAMACION;

public static class DatabaseConfig
{
    public static string ConnectionString { get; } =
        @"Server=DESKTOP-QHR16HM;
          Database=InventarioDB;
          Trusted_Connection=true;
          MultipleActiveResultSets=true;
          TrustServerCertificate=true";
}