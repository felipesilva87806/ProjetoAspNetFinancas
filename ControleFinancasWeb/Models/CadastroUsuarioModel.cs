using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ControleFinancasWeb.Models
{
    public class CadastroUsuarioModel
    {
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public static int InserirNewUsuario(string login,string senha, string nome)
        {
            using (var conexao = new MySqlConnection())
            {
                int ret = 0;
                //string de conexao que está dentro do arquivo Web.config
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                using (var comando = new MySqlCommand())
                {
                    try
                    {

                        comando.Connection = conexao;
                        //comando executado no banco
                        comando.CommandText = "INSERT INTO usuario VALUES (null,@login,md5(@senha),@nome)";
                        comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                        comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = senha;
                        comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                        comando.ExecuteScalar();
                        comando.CommandText = "SELECT LAST_INSERT_ID();";
                        ret = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (conexao.State == System.Data.ConnectionState.Open)
                        {
                            conexao.Close();
                        }
                    }

                }
                return ret;
            }
        }

    }
}