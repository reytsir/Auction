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
    public partial class lotsEdit : Form
    {
        public lotsEdit()
        {
            InitializeComponent();
        }

        private void lotsEdit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.Lots". При необходимости она может быть перемещена или удалена.
            this.lotsTableAdapter.Fill(this.auctionDBDataSet.Lots);

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lotsBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.auctionDBDataSet);
            this.Refresh();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Изображения BMP|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
