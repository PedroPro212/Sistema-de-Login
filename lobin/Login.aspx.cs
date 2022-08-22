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
    public partial class About : Page
    {
        private MySqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
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

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string gecd = GerarHashMd5(txtSenha.Text);

            connection.Open();
            var comando = new MySqlCommand($"SELECT * FROM login WHERE email = @email AND senha = @senha", connection);

            MySqlParameter email = new MySqlParameter("@email", txtEmail.Text);
            comando.Parameters.Add(email);
            MySqlParameter senha = new MySqlParameter("@senha", gecd);
            comando.Parameters.Add(senha);

            var reader = comando.ExecuteReader(); 

            if (reader.Read())
                SiteMaster.ExibirAlert(this, "Acorda Marmelopi");
            else
                SiteMaster.ExibirAlert(this, "deu pau");

            connection.Close();
        }
    }
}