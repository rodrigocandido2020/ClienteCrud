using Crud.Dominio;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB;

namespace Crud.Infra
{
    public class UsuarioRepositorioComBanco : IUsuarioRepositorio
    {

        private static SqlConnection sqlConexao;
        private static SqlConnection BancoConexao()
        {
            sqlConexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["conexaoSql"].ConnectionString);
            sqlConexao.Open();
            return sqlConexao;
        }

        public List<Usuario> ObterTodos()
        {
            using var db = SqlServerTools.CreateDataConnection(BancoConexao());
            {
                var resultado =
                    from usuarios 
                    in db.GetTable<Usuario>()
                    select usuarios;
                    return resultado
                    .ToList();
            }
        }


        public Usuario ObterPorId(int id)
        {
           var lista = ObterTodos();
           var usuario =  lista.Find(u => u.Id == id);
           return usuario;  
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            //using (var conexao = BancoConexao())
            //{
            //    using (var cmd = conexao.CreateCommand())
            //    {
            //        cmd.CommandText = "INSERT INTO USUARIO (NOME, SENHA, EMAIL, DATACRIACAO, DATANASCIMENTO) VALUES (@NOME, @SENHA, @EMAIL, @DATACRIACAO, @DATANASCIMENTO)";
            //        cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
            //        cmd.Parameters.AddWithValue("@SENHA", CriptografarSenha.Criptografar(usuario.Senha));
            //        cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            //        cmd.Parameters.AddWithValue("@DATACRIACAO", usuario.DataCriacao);
            //        if (usuario.DataNascimento == null)
            //        {
            //            cmd.Parameters.AddWithValue("@DATANASCIMENTO", DBNull.Value);
            //        }
            //        else
            //        {
            //            cmd.Parameters.AddWithValue("@DATANASCIMENTO", usuario.DataNascimento);

            //        }
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            using var db = SqlServerTools.CreateDataConnection(BancoConexao());
            {
                db.Insert(usuario);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("Usuario não pode ser nulo");
            }

            using (var conexao = BancoConexao())
            {
                using(var cmd = conexao.CreateCommand())
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
            if (id == decimal.Zero)
            {
                throw new ArgumentNullException("Id não pode ser zero");
            }

            using (var conexao = BancoConexao())
            {

                using(var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM USUARIO WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
