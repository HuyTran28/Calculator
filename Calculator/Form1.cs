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
        public Form1()
        {
            InitializeComponent();
        }
        double a = 0, b = 0, res = 0;
        string sign = "@";
        int oldselection = 0;
        private void eval()
        {
            if (sign != "@") txtDisplay.Text = a.ToString(); 
            if (sign == "sqrt")
            {
                if (txt.TextLength != 0)
                {
                    b = double.Parse(txt.Text);
                    a = b;
                }
                res = Math.Sqrt(a);
                a = res;
                txtDisplay.Text = a.ToString();
                txt.Text = "";
                sign = "@";
                return;
            }
            else if (sign == "!")
            {
                if (txt.TextLength != 0)
                {
                    b = double.Parse(txt.Text);
                    a = b;
                }
                if (a != Math.Floor(a))
                {
                    txtDisplay.Text = "INVALID INPUT";
                    txt.Text = "";
                    return;
                }
                res = 1;
                for (long i = 1; i <= a; i++)
                    res *= i;
                a = res;
                txtDisplay.Text = a.ToString();
                txt.Text = "";
                sign = "@";
                return;
            }
            else if(sign == "%")
            {
                if (txt.TextLength != 0)
                {
                    b = double.Parse(txt.Text);
                    b /= 100;
                }
                if (a != 0) res = a * b;
                else res = b;
                a = res;
                txtDisplay.Text = a.ToString();
                txt.Text = "";
                return;
            }
            if (txt.TextLength!=0)
            {
                if (sign == "@") res = double.Parse(txt.Text);
                else
                {

                    b = double.Parse(txt.Text);
                    if (sign == "+")
                    {
                        res = a + b;
                    } 
                    else if(sign== "-")
                    {
                        res = a - b;
                    }    
                    else if(sign=="*")
                    {
                        res = a * b;
                    }    
                    else if(sign == "/")
                    {
                        res = a / b;
                    }
                    else if (sign == "mod")
                    {
                        res = a % b;
                    }    
                    else
                    {
                        res = Math.Pow(a, b);
                    }    
                        
                }
                a = res;
                if(a<0)
                {
                    double c = a * (-1);
                    txtDisplay.Text = c.ToString();
                    txtDisplay.Text += "-";
                }
                txtDisplay.Text = a.ToString();
                txt.Text = "";
            }   
        }
        
        private void btndel_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            sign = "@";
            a = 0;
            b = 0;
            res = 0;
            txtDisplay.Text = "";
        }


        public int getCurrentCursor()
        {
            if (txt.SelectionStart == 0) return txt.TextLength;
            else
            {
                oldselection = txt.SelectionStart+1;
                return txt.SelectionStart;
            }
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            if(txt.TextLength != 0 && cursorPosition != 0) txt.Text = txt.Text.Insert(cursorPosition,"0");
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "1");
            txt.SelectionStart = oldselection; 
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "2");
            txt.SelectionStart = oldselection;
    
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "3");
            txt.SelectionStart = oldselection;
           
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "4");
            txt.SelectionStart = oldselection;
           
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "5");
            txt.SelectionStart = oldselection;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "6");
            txt.SelectionStart = oldselection;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "7");
            txt.SelectionStart = oldselection;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "8");
            txt.SelectionStart = oldselection;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            txt.Text = txt.Text.Insert(cursorPosition, "9");
            txt.SelectionStart = oldselection;
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            if (txt.TextLength != 0 && !txt.Text.Contains(".")) txt.Text = txt.Text.Insert(cursorPosition, ".");
            else if (txt.TextLength == 0) txt.Text += "0.";
            txt.SelectionStart = oldselection;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            int cursorPosition = getCurrentCursor();
            if (cursorPosition == 0) return;
            txt.Text = txt.Text.Remove(cursorPosition - 1, 1);
            if(oldselection >= 2) txt.SelectionStart = oldselection - 2;
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0 || (txtDisplay.TextLength != 0))
            {
                eval();
                sign = "-";
                txtDisplay.Text = txtDisplay.Text + " " + sign;

            }
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0 || (txtDisplay.TextLength != 0))
            {
                eval();
                sign = "*";
                txtDisplay.Text =  txtDisplay.Text + " " + sign;

            }
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0 || (txtDisplay.TextLength != 0))
            {
                eval();
                sign = "/";
                txtDisplay.Text = txtDisplay.Text + " " + sign;
            }
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0)
            {
                eval();
                sign = "@"; 
                txtDisplay.Text = txtDisplay.Text;
            }
        }

        private void btnpow_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0 || txtDisplay.TextLength != 0)
            {
                eval();
                sign = "^";
                txtDisplay.Text = txtDisplay.Text + " " + sign;
            }
        }

        private void btnsqrt_Click(object sender, EventArgs e)
        {
            sign = "sqrt";
            eval();
            txtDisplay.Text =  txtDisplay.Text;
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (txt.TextLength != 0 || txtDisplay.TextLength != 0)
            {
                eval();
                sign = "mod";
                txtDisplay.Text = txtDisplay.Text + " " + sign;
            }
        }

        private void btnfact_Click(object sender, EventArgs e)
        {
            sign = "!";
            eval();
        }

        private void btnQuadratic_Click(object sender, EventArgs e)
        {
            FrmQuadratic frmQ = new FrmQuadratic();
            frmQ.ShowDialog();
            txt.Text = frmQ.rootsForQua;
        }

        private void btnSysEqua3_Click(object sender, EventArgs e)
        {
            FrmSysEqua3 frmQ = new FrmSysEqua3();
            frmQ.ShowDialog();
            txt.Text = frmQ.rootsForSysEqua3;
        }

        private void btnSysEqua2_Click(object sender, EventArgs e)
        {
            FrmSysEqua2 frmQ = new FrmSysEqua2();
            frmQ.ShowDialog();
            txt.Text = frmQ.rootsforSysEqua2;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnperc_Click(object sender, EventArgs e)
        {

            if (sign == "*" || sign == "/")
            {
                sign = "%";
                eval();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(txt.TextLength!=0 || txtDisplay.TextLength!=0)
            {  
                eval();
                sign = "+";
                txtDisplay.Text = txtDisplay.Text + " " + sign;
            }
        }
    }
}
