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
    public class UsuarioRepositorioComBanco
    {
        //string de conexão: @"Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=cadastro;Data Source=INVENT79";
        public static SqlConnection sqlConnection;
        public static string sqlConnectionString;
        public static string ConexaoBanco()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings
                [@"Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=cadastro;Data Source=INVENT79"].ConnectionString;
            return sqlConnectionString;
        }
        public static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }


        public static DataTable ObterTodos()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try 
            { 
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM USUARIO";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }








        public void adicionarUsuario(Usuario usuario)
        {
            var conexaoBancoDeDados = new SqlConnection
                ("Data Source=INVENT79;Initial Catalog=cadastro;User ID=sa;Password=sap@123;");
            SqlCommand cmd;
            cmd = new SqlCommand
                ("INSERT INTO USUARIO(ID,NOME,SENHA,EMAIL,DATACRIACAO,DATANASCIMENTO)VALUES(@ID.@NOME,@SENHA,@EMAIL,@DATACRIACAO,@DATANASCIMENTO)");
            conexaoBancoDeDados.Open();
            cmd.Parameters.Add("NOME" , SqlDbType.VarChar).Value = usuario.Nome.ToString();
            cmd.ExecuteNonQuery();
            conexaoBancoDeDados.Close();
        }

    }
}
