using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budilnik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            realTime.Interval = 1000;
            realTime.Tick += new EventHandler(realTime_Tick);
            realTime.Start();
        }

        private void realTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("ddd, dd MMMM yyyy HH:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form3 addForm = new Form3(ref dataGridView1);
            addForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                Form3 addForm = new Form3(ref dataGridView1, ref dataGridRow);
                addForm.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            }
        }
    }
}
