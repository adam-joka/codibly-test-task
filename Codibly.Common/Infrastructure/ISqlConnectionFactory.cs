using System.Data.SqlClient;

namespace Polysystem.Standard.Infrastructure
{    
    public interface ISqlConnectionFactory
    {
        SqlConnection GetConnection();
    }
}
