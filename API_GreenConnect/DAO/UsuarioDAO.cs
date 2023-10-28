using API_GreenConnect.DTO;
using MySql.Data.MySqlClient;

namespace API_GreenConnect.DAO
{
    public class UsuarioDAO
    {
        public List<UsuarioDTO> Lista()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM USUARIO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<UsuarioDTO>();

            while (reader.Read())
            {
                var usuario = new UsuarioDTO();
                usuario.ID = int.Parse(reader["ID"].ToString());
                usuario.Nome = reader["NOME"].ToString();
                usuario.Imagem = reader["IMAGEM"].ToString();
                usuario.Email = reader["EMAIL"].ToString();
                usuario.Senha = reader["SENHA"].ToString();
                usuario.Nivel = reader["nivel"].ToString();

                lista.Add(usuario);
            }

            Conexao.Close();
            return lista;
        }

        public UsuarioDTO Login(UsuarioDTO usuario)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM USUARIO WHERE EMAIL = @email AND SENHA = @senha";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);

            var reader = comando.ExecuteReader();
            var login = new UsuarioDTO();


            while (reader.Read())
            {
                login.ID = int.Parse(reader["ID"].ToString());
                login.Nome = reader["NOME"].ToString();
                login.Imagem = reader["IMAGEM"].ToString();
                login.Email = reader["EMAIL"].ToString();
                login.Senha = reader["SENHA"].ToString();
                login.Nivel = reader["nivel"].ToString();
            }
            Conexao.Close();

            return login;
        }
    }
}
