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
    public partial class userEdit : Form
    {
        public userEdit()
        {
            InitializeComponent();
        }

        private void userEdit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.auctionDBDataSet.Users);
            
        }

        

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.auctionDBDataSet);
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBoxBid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
