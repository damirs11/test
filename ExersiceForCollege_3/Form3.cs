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
    public partial class Form3 : Form
    {
        public DataGridView dataGrid;

        private string Time;
        private string Date;
        private string Message;
        private string Path;

        bool editing = false;
        DataGridViewRow selectedRow;

        public Form3(ref DataGridView dataGrid)
        {
            InitializeComponent();
            this.dataGrid = dataGrid;  
        }

        public Form3(ref DataGridView dataGrid, ref DataGridViewRow dataGridRow)
        {
            InitializeComponent();
            this.dataGrid = dataGrid;

            maskedTextBox1.Text = dataGridRow.Cells[0].Value.ToString();

            string iDate = dataGridRow.Cells[1].Value.ToString();
            DateTime oDate = Convert.ToDateTime(iDate);
            dateTimePicker1.Value = oDate;

            textBox2.Text = dataGridRow.Cells[2].Value.ToString();
            label4.Text = dataGridRow.Cells[3].Value.ToString();

            editing = true;
            selectedRow = dataGridRow;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Time =  maskedTextBox1.MaskCompleted ? Time = maskedTextBox1.Text : DateTime.Now.ToString("HH:mm:ss");
            Date = dateTimePicker1.Value.ToString("dd MMMM yyyy");
            this.Message = textBox2.Text;
            Path = openFileDialog1.FileName == "openFileDialog1" ? "" : openFileDialog1.FileName;



            if (!editing)
                dataGrid.Rows.Add(Time, Date, this.Message, Path);
            else
                selectedRow.SetValues(Time, Date, this.Message, Path);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                label4.Text = openFileDialog1.FileName;
            else
                label4.Text = "";
        }
    }
}
