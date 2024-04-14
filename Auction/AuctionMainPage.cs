using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction
{
    public partial class AuctionMainPage : Form
    {
        public AuctionMainPage()
        {
            InitializeComponent();
        }
        private void AuctionMainPage_Load(object sender, EventArgs e)
        {
                        
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = maskedTextBoxLogin.Text.Trim();
            string password = maskedTextBoxPassword.Text.Trim();

            using (var connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|AuctionDB.mdb"))
            {
                connection.Open();

                string query = "SELECT Role_id FROM Users WHERE Login = ? AND Password = ?";
                using (var UserCommand = new OleDbCommand(query, connection))
                {
                    UserCommand.Parameters.AddWithValue("@Login", login);
                    UserCommand.Parameters.AddWithValue("@Password", password);

                    int roleId = Convert.ToInt32(UserCommand.ExecuteScalar());

                    if (roleId > 0)
                    {
                        MessageBox.Show("Вход выполнен!");

                        if (roleId == 1)
                        {
                            Form AdminPage = new AdminPage();
                            AdminPage.Show();
                            // Perform any additional actions for users with Role_id 1
                        }
                        else if (roleId == 2)
                        {
                            Form UserPage = new UserPage();
                            UserPage.Show();
                            // Perform any additional actions for users with Role_id 2
                            
                        }

                        // Perform any additional actions after successful login
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                        // Clear the MaskedTextBox controls or any other action after failed login
                    }
                    maskedTextBoxLogin.Text = "";
                    maskedTextBoxPassword.Text = "";
                }
            }
        }
    }
}
