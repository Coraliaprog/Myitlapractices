using Microsoft.Data.SqlClient;

namespace PROYECTO_FINAL_PROGRAMACION;

public abstract class DatabaseBase
{
    protected readonly string connectionString;

    protected DatabaseBase()
    {
        connectionString = DatabaseConfig.ConnectionString;
    }

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}