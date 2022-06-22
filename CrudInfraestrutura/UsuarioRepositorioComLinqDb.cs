using Crud.Dominio;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB;

namespace Crud.Infra
{
    public class UsuarioRepositorioComLinqDb : IUsuarioRepositorio
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar lista de usuários" + ex);
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                var usuarioRetorno = db.GetTable<Usuario>()
                        .FirstOrDefault(u => u.Id == id);
                return usuarioRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi encontrado usuario ID" + ex);
            }
            
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using var db = SqlServerTools.CreateDataConnection(BancoConexao());
            {
                try
                {
                    usuario.Senha = CriptografarSenha.Criptografar(usuario.Senha);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criptografar senha" + ex);
                }
                db.Insert(usuario);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            using var db = SqlServerTools.CreateDataConnection(BancoConexao());
            try
            {
                db.Update(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Usuário" + ex);
            }
        }

        public void RemoverUsuario(int id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                {
                    db.GetTable<Usuario>()
                        .Where(u => u.Id == id)
                        .Delete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Não foi encontrado Usuario para Remover " + ex);
            }
          
        }
    }
}
