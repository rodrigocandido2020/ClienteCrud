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
            using(var conexao = BancoConexao())
            {
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM USUARIO";
                    comandoBancoDeDados = new SqlDataAdapter(cmd.CommandText, conexao);
                    comandoBancoDeDados.Fill(BancoDeDados);
                    return BancoDeDados;
                }

            }
        }
        public List<Usuario> ConverterDataTableParaUsuario()
        {
            var repositorioComBanco = new UsuarioRepositorioComBanco();
            var conventerDataTableParaUsuario = new ConversorDataTableParaUsuario(); 
            return conventerDataTableParaUsuario.ConverterParaLista<Usuario>(repositorioComBanco.ObterTodos()); 
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var cmd = BancoConexao().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO USUARIO (NOME, SENHA, EMAIL, DATACRIACAO, DATANASCIMENTO) VALUES (@NOME, @SENHA, @EMAIL, @DATACRIACAO, @DATANASCIMENTO)";
                cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                cmd.Parameters.AddWithValue("@DATACRIACAO", usuario.DataCriacao);
                if (usuario.DataNascimento == null)
                {
                    cmd.Parameters.AddWithValue("@DATANASCIMENTO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DATANASCIMENTO", usuario.DataNascimento);

                }
                cmd.ExecuteNonQuery();  
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            using (var cmd = BancoConexao().CreateCommand())
            {
                if(usuario != null)
                {
                    cmd.CommandText = "UPDATE USUARIO SET NOME=@NOME, SENHA=@SENHA, EMAIL=@EMAIL, DATACRIACAO=@DATACRIACAO, DATANASCIMENTO=@DATANASCIMENTO WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("ID", usuario.Id);
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@DATACRIACAO", usuario.DataCriacao);
                    if(usuario.DataNascimento == null)
                    {
                        cmd.Parameters.AddWithValue("@DATANASCIMENTO", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DATANASCIMENTO", usuario.DataNascimento);

                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoverUsuario(int id)
        {
            var usuario = new Usuario();
            using (var cmd = BancoConexao().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM USUARIO WHERE ID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
