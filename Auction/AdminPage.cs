using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.auctionDBDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.Lots". При необходимости она может быть перемещена или удалена.
            this.lotsTableAdapter.Fill(this.auctionDBDataSet.Lots);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lotsEditButton_Click(object sender, EventArgs e)
        {
            Form lotsEdit = new lotsEdit();
            lotsEdit.Show();
        }
    }
}
