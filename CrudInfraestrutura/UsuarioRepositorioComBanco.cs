using Crud.Dominio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Crud.Infra
{
    public class UsuarioRepositorioComBanco : IUsuarioRepositorio
    {

        private static SqlConnection? sqlConexao;
        private static SqlConnection BancoConexao()
        {
            sqlConexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["conexaoSql"].ConnectionString);
            sqlConexao.Open();
            return sqlConexao;
        }

        public List<Usuario> ObterTodos()
        {
            DataTable BancoDeDados = new DataTable();
            try
            {
                using (var conexao = BancoConexao())
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM teste";
                        var comandoBancoDeDados = new SqlDataAdapter(cmd.CommandText, conexao);
                        comandoBancoDeDados.Fill(BancoDeDados);
                    }
                }
                return ConversorDataTableParaUsuario.ConverterParaLista<Usuario>(BancoDeDados);
            }
            catch (Exception ex)
            {
                throw new Exception ("não existe usuario "  , ex);
            }
        }


        public Usuario ObterPorId(int id)
        {
            DataTable BancoDeDados = new DataTable();
            try
            {
                using (var conexao = BancoConexao())
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM USUARIO";
                        var comandoBancoDeDados = new SqlDataAdapter(cmd.CommandText, conexao);
                        comandoBancoDeDados.Fill(BancoDeDados);
                    }
                }
                return ConversorDataTableParaUsuario.ConverterParaLista<Usuario>(BancoDeDados).Find(u => u.Id == id) ??
                    throw new Exception("Id não pode ser nulo");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Usuário por id" + id , ex);
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                using (var conexao = BancoConexao())
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO USUARIO (NOME, SENHA, EMAIL, DATACRIACAO, DATANASCIMENTO) VALUES (@NOME, @SENHA, @EMAIL, @DATACRIACAO, @DATANASCIMENTO)";
                        cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                        cmd.Parameters.AddWithValue("@SENHA", CriptografarSenha.Criptografar(usuario.Senha));
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
            }
            catch (Exception ex)
            {
                throw new Exception ("Não a usuario para ser adicionado " , ex);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new ArgumentNullException("Usuario não pode ser nulo");
                }
                using (var conexao = BancoConexao())
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE USUARIO SET NOME=@NOME, SENHA=@SENHA, EMAIL=@EMAIL, DATACRIACAO=@DATACRIACAO, DATANASCIMENTO=@DATANASCIMENTO WHERE ID=@ID";
                        cmd.Parameters.AddWithValue("ID", usuario.Id);
                        cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                        cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                        cmd.Parameters.AddWithValue("EMAIL", usuario.Email);
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
            }
            catch (Exception ex)
            {
                throw new Exception ("Usuario não pode ser Nulo " , ex);
            }
            
        }

        public void RemoverUsuario(int id)
        {
            try
            {
                if (id == decimal.Zero)
                {
                    throw new ArgumentNullException("Id não pode ser zero");
                }
                using (var conexao = BancoConexao())
                {
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM USUARIO WHERE ID=@ID";
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Não a usario para remover " , ex);
            }
        }
    }
}
