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
            pictureBox1.DataBindings.Add("Image", lotsBindingSource, "Image", true);
        }

        private void lotsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
