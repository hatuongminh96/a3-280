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
    public partial class addO : Form
    {
        string fn, sn, id, lv, am, box1, box2;
        public addO()
        {
            InitializeComponent();
        }
        
        private void addO_Load(object sender, EventArgs e)
        {
            using (StaffMemberContext db = new StaffMemberContext())
            {
                var b = from of in db.StaffMember
                        select of.LEVEL;
                foreach (object level in b)
                {
                    if (!comboBox1.Items.Contains(level.ToString())&& level.ToString()!="") comboBox1.Items.Add(level.ToString());
                }
            }
            comboBox2.Items.Add("None");
            using (AmbulanceContext db = new AmbulanceContext())
            {
                var a = from am in db.Ambulance
                        select am.a_id;
                foreach (object car in a) comboBox2.Items.Add(car.ToString());
                //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            //foreach (object tmp in comboBox1.Items)
            //{
            //    comboBox1.Items.Add(tmp.ToString());
            //    comboBox1.Items.Remove(tmp);
            //    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //}
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = box1;
            comboBox2.Text = box2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validate(string input)
        {
            return (String.IsNullOrEmpty(input)||String.IsNullOrWhiteSpace(input));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool validated = true;
            int temp;
            fn = textBox1.Text;
            sn = textBox2.Text;
            id = textBox3.Text;
            lv = comboBox1.Text;
            am = comboBox2.Text;
            if (validate(fn))
            {
                MessageBox.Show("An ambulance officer needs at least one first name.");
                validated = false;
            }
            else if (validate(sn))
            {
                MessageBox.Show("An ambulance officer needs a last name.");
                validated = false;
            }
            else if (validate(id))
            {
                MessageBox.Show("An ambulance officer needs an ID.");
                validated = false;
            }
            else if (!Int32.TryParse(id,out temp) || id.Length != 6)
            {
                MessageBox.Show("An ambulance officer needs a 6 digits ID.");
                validated = false;
            }
            else if (validate(lv))
            {
                MessageBox.Show("An ambulance officer needs a skill level.");
                validated = false;
            }
            else if (validate(am))
            {
                MessageBox.Show("Please choose None to assign to no ambulance.");
                validated = false;
            }
            if (validated)
            {
                using (StaffMemberContext db = new StaffMemberContext())
                {
                    var o = from emp in db.StaffMember
                            where String.Equals(emp.ID, id)
                            select emp;
                    if (o.FirstOrDefault() != null)
                    {
                        o.First().FIRST_NAME = fn;
                        o.First().SURNAME = sn;
                        o.First().LEVEL = lv;
                        if (am != "None") o.First().AMBULANCE_ID = am;
                        else o.First().AMBULANCE_ID = null;
                        db.SaveChanges();
                    }
                    else
                    {
                        var new_o = new Officer { SURNAME = sn, FIRST_NAME = fn, ID = id, LEVEL = lv, AMBULANCE_ID = am };
                        db.StaffMember.Add(new_o);
                        db.SaveChanges();
                    }
                }
            this.Close();
            }
        }
        public void setText1(string text)
        {
            textBox1.Text = text;
        }
        public void setText2(string text)
        {
            textBox2.Text = text;
        }
        public void setText3(string text)
        {
            textBox3.Text = text;
        }
        public void setBox1(string text)
        {
            box1 = text;
        }
        public void setBox2(string text)
        {
            box2 = text;
        }
    }
}