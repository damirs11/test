using System;
using System.IO;
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

            

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                bool alarmStatus = Convert.ToBoolean(chk.Value);
                string time = row.Cells[1].Value.ToString();
                string date = row.Cells[2].Value.ToString();

                
                

                if (alarmStatus &&
                    time == DateTime.Now.ToString("HH:mm:ss") &&
                    date == DateTime.Now.ToString("dd MMMM yyyy"))
                {
                    row.Cells[0].Value = false;

                    if (File.Exists(row.Cells["soundPath"].ToString()))
                    {
                        try
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(row.Cells[4].Value.ToString());
                            player.Load();
                            player.Play();
                            DialogResult result = MessageBox.Show(this, row.Cells[3].Value.ToString(), "Будильник прокнул", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                player.Stop();
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            DialogResult result = MessageBox.Show(this, row.Cells[3].Value.ToString(), "Будильник прокнул", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    
                }
                
            }
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
