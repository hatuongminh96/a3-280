using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class aForm : Form
    {
        public aForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addA frm = new addA();
            frm.ShowDialog();
        }

        private void aForm_Load(object sender, EventArgs e)
        {
            using (AmbulanceContext db = new AmbulanceContext())
            {
                dataGridView1.DataSource = db.Ambulance.ToArray();
            }
            
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                string str = dataGridView1.Columns[i].HeaderText;
                if (str == "a_id") dataGridView1.Columns[i].HeaderText = "ID";
                else dataGridView1.Columns[i].HeaderText = "Station";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string s_id = row.Cells[0].Value.ToString();
            string s_s = row.Cells[1].Value.ToString();
            addA frm = new addA();
            frm.setText1(s_id);
            frm.setText2(s_s);
            frm.ShowDialog();
        }
    }
}
