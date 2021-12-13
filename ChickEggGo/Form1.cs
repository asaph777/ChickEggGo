using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickEggGo
{
    public partial class Form1 : Form
    {
        Object menuItem = new Object();
        Employee emp = new Employee();
        int quantity = 0;
        string resultOrdered = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No Quantity");
                return;
            }
            quantity = int.Parse(textBox1.Text);
            if (radioButton1.Checked)
            {
                menuItem = new ChickenOrder(quantity);
            }
            if (radioButton2.Checked)
            {
                menuItem = new EggOrder(quantity);
            }
            Object returnedCase = emp.NewRequest(quantity, menuItem);
            menuItem = returnedCase;
            string resultInspection = emp.Inspect(returnedCase);
            label3.Text = resultInspection;

            if (menuItem is ChickenOrder)
            {
                resultOrdered = " Chicken(s)";
            }
            if (menuItem is EggOrder)
            {
                resultOrdered = " Egg(s)";
            }
            listBox1.Items.Add("Ordered " + quantity.ToString() + " " + resultOrdered);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Object returnedCase = emp.CopyRequest();
                menuItem = returnedCase;
                string resultInspection = emp.Inspect(returnedCase);
                label3.Text = resultInspection;
                if (menuItem is ChickenOrder)
                {
                    resultOrdered = " Chicken(s)";
                }
                if (menuItem is EggOrder)
                {
                    resultOrdered = " Egg(s)";
                }
                listBox1.Items.Add("Ordered " + quantity.ToString() + " " + resultOrdered);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add(emp.PrepareFood(menuItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Text = "";
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
