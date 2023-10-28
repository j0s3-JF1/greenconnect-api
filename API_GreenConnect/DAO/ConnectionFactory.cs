using MySql.Data.MySqlClient;

namespace API_GreenConnect.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            string conn = @"Server=localhost;Database=GREENCONNECT_DB;Uid=root;Pwd=#Canario83.";
            return new MySqlConnection(conn);
        }
    }
}
