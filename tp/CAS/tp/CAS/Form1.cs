using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Expression.Exp A = (Expression.Exp)5 / (Expression.Exp)20;
            A = A.Diff("x");
            A = A.Simplify();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Expression.Exp E = Expression.RPNEval.RPN_To_Exp(Expression.InfixEval.Infix_To_RPN(textBox1.Text));
            label2.Text = E.Diff("x").Simplify().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Expression.Exp E =  Expression.RPNEval.RPN_To_Exp(Expression.InfixEval.Infix_To_RPN( textBox1.Text));
            label2.Text = E.Simplify().ToString();
        }
    }
}
