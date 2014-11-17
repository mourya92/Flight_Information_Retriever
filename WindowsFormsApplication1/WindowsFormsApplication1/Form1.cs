using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class GUI : Form
    {
        Airport_controller ac = new Airport_controller();
        string output = null;

        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int num1;
            try
            {
                num1 = Int32.Parse(text);
                if (num1 < 1 || num1 > 18)
                {
                    label2.Text = "Enter numbers from 1 to 18 only !";
                    label2.ForeColor = Color.Red;
                }
                else
                {
                    label2.Text = "Entered correct number";
                    label2.ForeColor = Color.Green;

                    output = ac.printData(num1 - 1);
                    System.Windows.Forms.MessageBox.Show(output);

                }

              
                


            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not an integer");
                // Return? Loop round? Whatever.
            } 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
