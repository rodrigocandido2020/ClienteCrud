using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class UsuarioRepositorioComBanco : IDisposable
    {
        private static SqlConnection sqlConexao;
        private static string sqlConexaoString;

        public UsuarioRepositorioComBanco()
        { }
        private static string bancoConexaoString()
        {
            sqlConexaoString = ConfigurationManager.ConnectionStrings
                ["conexaoSql"].ConnectionString;
            return sqlConexaoString;
        }
        private static SqlConnection BancoConexao()
        {
            sqlConexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["conexaoSql"].ConnectionString);
            sqlConexao.Open();
            return sqlConexao;
        }


        public DataTable ObterTodos()
        {
            SqlDataAdapter comandoBancoDeDados = null;
            DataTable BancoDeDados = new DataTable();
            using(var conn = BancoConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM USUARIO";
                    comandoBancoDeDados = new SqlDataAdapter(cmd.CommandText, conn);
                    comandoBancoDeDados.Fill(BancoDeDados);

                    for (int i = 0; i < BancoDeDados.Rows.Count; i++)
                    {
                        var row = BancoDeDados.Rows[i];
                        var usuario = new Usuario
                        {
                            Nome = row.Field<string>("NOME"),
                            DataCriacao = row.Field<DateTime>("DATACRIACAO")
                        };
                    }
                    
                    return BancoDeDados;
                }

            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var cmd = BancoConexao().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO USUARIO (NOME, SENHA, EMAIL, DATACRIACAO, DATANASCIMENTO) VALUES (@NOME, @SENHA, @EMAIL, @DATACRIACAO, @DATANASCIMENTO)";
                cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                cmd.Parameters.AddWithValue("@DATACRIACAO", usuario.DataCriacao.ToString());
                cmd.Parameters.AddWithValue("@DATANASCIMENTO", usuario.DataNascimento.ToString());
                cmd.ExecuteNonQuery();  
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
