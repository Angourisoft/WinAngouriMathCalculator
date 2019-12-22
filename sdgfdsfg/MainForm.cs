using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngouriMath;

namespace sdgfdsfg
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {

        }

        private void InputTextboxChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Simplify().ToString();
            }
            catch (Exception ex) {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InputTextbox.Text += (sender as Button).Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Derive(MathS.Var("x")).Simplify().ToString();
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Expand().ToString();
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Collapse().ToString();
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Latexise();
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var roots = MathS.FromString(InputTextbox.Text).SolveNt(MathS.Var("x"));
                OutputTextbox.Text = "";
                foreach (var root in roots)
                    OutputTextbox.Text += root.ToString() + "  ";
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OutputTextbox.Text = MathS.FromString(InputTextbox.Text).Simplify(4).ToString();
            }
            catch (Exception ex)
            {
                OutputTextbox.Text = ex.Message;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (InputTextbox.Text != "")
                InputTextbox.Text = InputTextbox.Text.Substring(0, InputTextbox.Text.Length - 1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/Angourisoft/MathS");
        }

        private void InputTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
