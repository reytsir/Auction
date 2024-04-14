using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction
{
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet1.Lots". При необходимости она может быть перемещена или удалена.
            this.lotsTableAdapter.Fill(this.auctionDBDataSet.Lots);

            lotsBindingSource.Filter = "[Available] = true";
            
        }

        private void lotsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBoxBid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Подавляем ввод неправильных символов
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lotsBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.auctionDBDataSet);
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tableAdapterManager1.UpdateAll(this.auctionDBDataSet);
            this.Refresh();
        }
    }
}
