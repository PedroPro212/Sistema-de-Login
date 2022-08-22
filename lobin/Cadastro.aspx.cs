using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lobin
{
    public partial class _Default : Page
    {

        private MySqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e) //colocar SqlParameter(@senha, tx)
        {

            string gecd = GerarHashMd5(txtSenha.Text);

            if (ValidarEmail(txtEmail.Text)==true)
            {
                if (txtSenha.Text == txtConfsenha.Text)
                {
                    connection.Open();
                    var comando = new MySqlCommand($"INSERT INTO `login` VALUES(null, @email," +
                        $" @senha)", connection);

                    MySqlParameter email = new MySqlParameter("@email", txtEmail.Text);
                    comando.Parameters.Add(email);
                    MySqlParameter senha = new MySqlParameter("@senha", gecd);
                    comando.Parameters.Add(senha);

                    comando.ExecuteNonQuery();
                    connection.Close();
                    SiteMaster.ExibirAlert(this, "Cadastro concluído.");
                }
                else
                    SiteMaster.ExibirAlert(this, "Senhas incompatíveis.");
            }
            else
                SiteMaster.ExibirAlert(this, "Email inválido.");

        }
    }
}