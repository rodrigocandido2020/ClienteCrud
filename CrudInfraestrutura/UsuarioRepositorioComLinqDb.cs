using Crud.Dominio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB;

namespace Crud.Infra
{
    public class UsuarioRepositorioComLinqDb : IUsuarioRepositorio
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
            try
            {
                using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                {
                    return db.GetTable<Usuario>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar lista de usuários", ex);
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                var usuarioRetorno = db.GetTable<Usuario>()
                        .FirstOrDefault(u => u.Id == id);

                return usuarioRetorno ?? throw new Exception ("Id não pode ser Nulo");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi encontrado usuario ID" , ex);
            }

        }

        public bool emailExisteNoBanco(string email)
        {
            using var db = SqlServerTools.CreateDataConnection(BancoConexao());
            {
                var emailExistente = db.GetTable<Usuario>()
                    .Any(u => u.Email == email);
                return emailExistente;
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            
            {   
                try
                {
                    usuario.Senha = CriptografarSenha.Criptografar(usuario.Senha);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criptografar senha " , ex);
                }
                try
                {
                    using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                    db.Insert(usuario);
                }
                catch (Exception ex)
                {
                    throw new Exception ("Erro ao adicionar usuario " , ex);
                }
                
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(BancoConexao());
                usuario.Senha = CriptografarSenha.Criptografar(usuario.Senha);
                db.Update(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Usuário" , ex);
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
                throw new Exception("Não foi encontrado Usuario para Remover " , ex);
            }

        }
    }
}
