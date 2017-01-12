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
    public partial class oForm : Form
    {
        public oForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addO frm = new addO();
            frm.ShowDialog();
        }

        private void oForm_Load(object sender, EventArgs e)
        {
            using (StaffMemberContext db = new StaffMemberContext())
            {
                dataGridView1.DataSource = db.StaffMember.ToArray();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["FIRST_NAME"].Value += " "+row.Cells["SURNAME"].Value.ToString();
                }
                dataGridView1.Columns["SURNAME"].Visible = false;
                dataGridView1.Columns[0].HeaderText = "FULL NAME";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string s_ln = row.Cells[1].Value.ToString();
            string s_fn = row.Cells[0].Value.ToString().Replace(" "+s_ln,"");
            string s_id = row.Cells[2].Value.ToString();
            //int s_lv = -1;
            //if (row.Cells[3].Value.ToString() == "Basic") s_lv = 0;
            //else if (row.Cells[3].Value.ToString() == "Intermediate") s_lv = 1;
            //else if (row.Cells[3].Value.ToString() == "Advance") s_lv = 2;
            string s_lv = row.Cells[3].Value.ToString();
            string s_am;
            if (row.Cells[4].Value == null) s_am = "None";
            else s_am = row.Cells[4].Value.ToString();
            addO frm = new addO();
            frm.setText1(s_fn);
            frm.setText2(s_ln);
            frm.setText3(s_id);
            frm.setBox1(s_lv);
            frm.setBox2(s_am);
            frm.ShowDialog();
        }
    }
}
