using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        float result;
        bool isOperationPerformed; //Then we can clear text take in next input
        string operationPerformed; // operation preferformed in string format

        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed == true|| textBox_Result.Text == "0")
            {
                //clearing text. when button click funcion is clicked
                textBox_Result.Clear();
            }
            isOperationPerformed = false; // is we didnt set this. it would clear everytime button is entered
            Button button = (Button)sender; // converting the object sender class, to a button

            if (button.Text == "." && textBox_Result.Text.Contains(".") == false)
            {
                textBox_Result.Text += button.Text;
            }
            else if (button.Text != ".")
            {
                textBox_Result.Text += button.Text;
            }
     
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //ce function - clear calculator inputs
            textBox_Result.Text = "0";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            // c function - clear our workings and inputs
            textBox_Result.Text = "0";
            labelCurrentResult.Text = "";
            result = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //function auto generated from equal click event
            switch (operationPerformed)
            {
                case "+":
                    {
                        //number input + result 
                        //float.parse convert string to a number. Then back to string
                        textBox_Result.Text = (result + float.Parse(textBox_Result.Text)).ToString();
                          
                        break;
                    }
                case "-":
                    {

                        textBox_Result.Text = (result - float.Parse(textBox_Result.Text)).ToString();
                        break;
                    }
                case "*":
                    {
                        textBox_Result.Text = (result * float.Parse(textBox_Result.Text)).ToString();
                        break;
                    }
                case "/":
                    {
                        textBox_Result.Text = (result / float.Parse(textBox_Result.Text)).ToString();
                        break;
                    }
            }

            result = float.Parse(textBox_Result.Text);
            labelCurrentResult.Text = "";
        }
        private void operator_Click(object sender, EventArgs e)
        {
            //I assigned function to operator buttons
            //casting sender object to button. Since its a button 
            Button button = (Button)sender;
            //if we pressed button first time (operator) we simply store number in input box
            if (result == 0)
            {
                operationPerformed = button.Text; //storing the operator, -,+ /, *
                result = float.Parse(textBox_Result.Text);
                labelCurrentResult.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                button18.PerformClick();
                operationPerformed = button.Text;
                labelCurrentResult.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }
    }
}
