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
    public partial class FrmQuadratic : Form
    {
        public string rootsForQua;
        public FrmQuadratic()
        {
            InitializeComponent();
        }

        public void sendData(string thisFormData)
        {
            rootsForQua = thisFormData;
            Close();
        }

        public double changeToDouble(string str)
        {
            if (str.Length == 0) return 0;
            else return double.Parse(str);
        }

        private void btncalc_Click(object sender, EventArgs e)
        {
            double a, b, c, ans;
            if (txtA.TextLength == 0 || txtB.TextLength == 0 || txtC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ giá trị", "Vui lòng nhập đủ giá trị", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            a = changeToDouble(txtA.Text);
            b = changeToDouble(txtB.Text);
            c = changeToDouble(txtC.Text);
            double root1 = 0, root2 = 0;
            if (a == 0 && b != 0)
            {
                ans = -c / b;
            }
            else if (a == 0 && b == 0)
            {
                if (c == 0) sendData("Phương trình có vô số nghiệm");
                else sendData("Phương trình vô nghiệm");
                return;
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta < 0)
                {
                    sendData("Phương trình vô nghiệm");
                    return;
                
                }
                else
                {
                    root1 = Math.Round((-b + Math.Sqrt(delta)) / (2 * a),10);
                    root2 = Math.Round((-b - Math.Sqrt(delta)) / (2 * a), 10);
                }
            }
            Math.Round(root1, 4); Math.Round(root2, 4);
            sendData("X1 = " + root1 + "\nX2 = " + root2);
            txtA.Text = txtB.Text = txtC.Text = "";
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
