using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataset
{
    public partial class btnDelete : Form
    {
        public btnDelete()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.InformationTableAdapter person = new DataSet1TableAdapters.InformationTableAdapter();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = person.List2();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
           
            person.insert(textNumber.Text, textName.Text, textTelephone.Text, textAddress.Text, textEmail.Text);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            dataGridView1.DataSource = person.List2();
        }

        private void btndetetebtn_Click(object sender, EventArgs e)
        {
            person.Delete1(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            dataGridView1.DataSource = person.List2();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            person.Update1(textName.Text, textTelephone.Text, textAddress.Text, textEmail.Text, textNumber.Text);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            dataGridView1.DataSource = person.List2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = person.Search2('%'+textBox1.Text+'%');
        }
    }
}
