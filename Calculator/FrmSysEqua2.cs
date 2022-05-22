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
    public partial class FrmSysEqua2 : Form
    {
        public string rootsforSysEqua2;
        public FrmSysEqua2()
        {
            InitializeComponent();
        }

        public void sendData(string thisFormData)
        {
            rootsforSysEqua2 = thisFormData;
            Close();
        }
        public double changeToDouble(string str)
        {
            if (str.Length == 0) return 0;
            else return double.Parse(str);
        }


        private void btncalc_Click(object sender, EventArgs e)
        {
            double a1, b1, c1, a2, b2, c2, x, y;
            a1 = changeToDouble(txtA1.Text);
            b1 = changeToDouble(txtB1.Text);
            c1 = changeToDouble(txtC1.Text);
            a2 = changeToDouble(txtA2.Text);
            b2 = changeToDouble(txtB2.Text);
            c2 = changeToDouble(txtC2.Text);
            if (Math.Abs(a1) <= Math.Abs(a2))
            {
                (a1, a2) = (a2, a1);
                (b1, b2) = (b2, b1);
                (c1, c2) = (c2, c1);
            }

            double now1 = c1 * a2 / a1;
            double now2 = b1 * a2 / a1;
            y = (c2 - now1) / (b2 - now2);
            if (a2 != 0) x = (now1 - now2 * y) / a2;
            else x = (c1 - b1 * y) / a1;
            Math.Round(x, 4); Math.Round(y, 4);
            sendData("X = " + x + "\nY = " + y);
            txtA1.Text = txtA2.Text = txtB1.Text = txtB2.Text = txtC1.Text = txtC2.Text = "";
        }
        public void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

            string typePlace = (sender as RichTextBox).Text;
            if (e.KeyChar == '.')
            {
                if (typePlace.Contains('.') == true || typePlace.Length == 0) e.Handled = true;
                else return;
            }
            else if (e.KeyChar == '0')
            {
                if (typePlace.Length == 0) e.Handled = true;
                else return;
            }
            else if (e.KeyChar == '-')
            {
                if (typePlace.Length != 0) e.Handled = true;
                else return;
            }
            else if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)) e.Handled = true;
        }

       
    }
}
