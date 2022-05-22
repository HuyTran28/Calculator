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
    public partial class FrmSysEqua3 : Form
    {
        public string rootsForSysEqua3;
        public FrmSysEqua3()
        {
            InitializeComponent();
        }


        public void sendData(string thisFormData)
        {
            rootsForSysEqua3 = thisFormData;
            Close();
        }

        public void checkEnough()
        {
            if (txtA1.TextLength * txtB1.TextLength * txtC1.TextLength * txtD1.TextLength 
                * txtA2.TextLength*txtB2.TextLength*txtC2.TextLength * txtD2.TextLength 
                * txtA3.TextLength * txtB3.TextLength * txtC3.TextLength * txtD3.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ giá trị", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public double changeToDouble(string str)
        {
            if (str.Length == 0) return 0;
            else return double.Parse(str);
        }

        private void btncalc_Click(object sender, EventArgs e)
        {
            checkEnough();
            double a,b,c,d,p,q,r,s,g,h,k,l;
            a = changeToDouble(txtA1.Text); b = changeToDouble(txtB1.Text); c = changeToDouble(txtC1.Text); d = changeToDouble(txtD1.Text);
            p = changeToDouble(txtA2.Text); q = changeToDouble(txtB2.Text); r = changeToDouble(txtC2.Text); s = changeToDouble(txtD2.Text);
            g = changeToDouble(txtA3.Text); h = changeToDouble(txtB3.Text); k = changeToDouble(txtC3.Text); l = changeToDouble(txtD3.Text);

            double U,V;
            
            U = a * (q * k - r * h) - b * (p * k - r * g) + c * (p * h - q * g);
            V = b * (-r * l + s * k) + c * (q * l - s * h) + d * (-q * k + r * h);
            double X,Y,Z;
           
            X = V / U;
            V = a * (r * l - s * k) - c * (p * l - s * g) + d * (p * k - r * g);
            Y = V / U;
            V = -a * (q * l - s * h) + b * (p * l - s * g) - d * (p * h - q * g);
            Z = V / U;
            Math.Round(X, 4); Math.Round(Y, 4);  Math.Round(Z, 4);
            sendData("X = " + X + "  Y = " + Y + "\nZ = " + Z);
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
