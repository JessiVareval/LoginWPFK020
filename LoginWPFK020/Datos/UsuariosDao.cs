using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWPFK020.Datos
{
    class UsuariosDao
    {
        private const string connString = "server=(localdb)\\MSSQLLocalDB;database=ProyectoK020;Trusted_Connection=True";
        private const string sqlLogin = "select * from usuarios where username = @nombreUsuario;";
        
        public Usuario buscarUsuarioPorUsername(string username, string password)
        {
            Usuario user = null;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sqlLogin;
                SqlParameter usernameParameter = new SqlParameter("@nombreUsuario", username);
                command.Parameters.Add(usernameParameter);
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("Se encontraron registros" + dr.HasRows);
                
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        if(password == dr.GetString("password"))
                        {
                            user = new Usuario();
                            user.Id = dr.GetInt32("id");
                            user.Username = username;
                            user.Password = dr.GetString("password");
                            user.Nombre_Completo = dr.GetString("Nombre_Completo");
                            break;
                        }
                        
                    }
                }          
            
            }
            return user;
            
        }

    }
}
