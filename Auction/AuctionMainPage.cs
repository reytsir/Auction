using Auction.AuctionDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
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
                            
                        }
                        else if (roleId == 2)
                        {
                            Form UserPage = new UserPage();
                            UserPage.Show();
                            
                            
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                        
                    }
                    maskedTextBoxLogin.Text = "";
                    maskedTextBoxPassword.Text = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Iterate through all open forms
            foreach (Form form in Application.OpenForms)
            {
                // Check if the form contains a UserPage form
                if (form.Controls.ContainsKey("UserPage"))
                {
                    // Access the UserPage form and perform actions
                    UserPage userPage = (UserPage)form.Controls["UserPage"];
                    userPage.Validate();
                    userPage.Refresh();
                    foreach(BindingSource bindingSource in userPage.Controls.OfType<BindingSource>())
                    {
                        bindingSource.CancelEdit();
                    }
                    foreach(TableAdapterManager tableAdapterManager in userPage.Controls.OfType<TableAdapterManager>())
                    {
                        //foreach(DataSet dataSet in userPage.Controls.OfType<DataSet>())
                        //tableAdapterManager.UpdateAll(userPage.dataSet);
                    }
                }
            }
        }
    }
}
