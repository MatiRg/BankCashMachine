using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankCashMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            CashMachine.StateChanged = OnStateChanged;
            CashMachine.Instance.Setup( 1234, 4500 );
        }

        private void OnStateChanged(IState s)
        {
            if (s is NullState)
                InputBox.PasswordChar = '*';
            else
                InputBox.PasswordChar = '\0';

            DisplayText(s);
            InputBox.Clear();
        }

        private void DisplayText(IState St)
        {
            DisplayEdit.Clear();
            foreach (string s in St.Text())
            {
                DisplayEdit.AppendText(s+"\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CashMachine.Instance.State.OnAcceptButton())
            {
                DisplayText(CashMachine.Instance.State);
                int i = 0;
                string s = InputBox.Text;
                if (int.TryParse(s, out i)) CashMachine.Instance.State.Operate(i);
            }
            InputBox.Clear();
        }

        private void OnKeyPadCLick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button bt = sender as Button;
                InputBox.AppendText(bt.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputBox.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CashMachine.Instance.State.OnCancelButton();
        }

        private void TextBoxFocus(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox ed = sender as TextBox;
                ed.Enabled = false;
                ed.Enabled = true;
            }
        }
    }
}
