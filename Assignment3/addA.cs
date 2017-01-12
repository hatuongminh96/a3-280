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
    public partial class addA : Form
    {
        string a_id, station;
        bool validated = true;
        private bool validate(string input)
        {
            return (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input));
        }
        public addA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setText1(string text)
        {
            textBox1.Text = text;
        }
        public void setText2(string text)
        {
            comboBox1.Text = text;
        }
        

        private void addA_Load(object sender, EventArgs e)
        {
            using (AmbulanceContext db = new AmbulanceContext())
            {
                var t = from amb in db.Ambulance
                        select amb.station;
                foreach (object sta in t)
                {
                    comboBox1.Items.Add(sta.ToString());
                }
            }
            using (StaffMemberContext db = new StaffMemberContext())
            {
                var o = from ofc in db.StaffMember
                        where String.Equals(ofc.AMBULANCE_ID, textBox1.Text)
                        select ofc;
                dataGridView1.DataSource = o.ToArray();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["FIRST_NAME"].Value += " " + row.Cells["SURNAME"].Value.ToString();
                }
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.ColumnHeadersVisible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int temp;
            a_id = textBox1.Text;
            station = comboBox1.Text;
            if (validate(a_id))
            {
                MessageBox.Show("Need Ambulance ID.");
                validated = false;
            }
            else if (validate(station))
            {
                MessageBox.Show("Need station for ambulance.");
                validated = false;
            }
            else if (!a_id.StartsWith("A") || a_id.Length >=5|| !Int32.TryParse(a_id.Substring(1), out temp))
            {
                MessageBox.Show("Ambulance ID must start with an A and follow by up to three digits");
                validated = false;
            }
            if (validated)
            {
                using (AmbulanceContext db = new AmbulanceContext())
                {
                    var a = new Ambulance { a_id = a_id, station = station };
                    db.Ambulance.Add(a);
                    db.SaveChanges();
                }
                this.Close();
            }
        }
    }
}
