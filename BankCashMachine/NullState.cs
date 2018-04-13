using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public class NullState : IState
    {
        private CashMachine Machine;

        public NullState(CashMachine machine)
        {
            Machine = machine;
        }

        public List<string> Text()
        {
            List<string> Text = new List<string>();
            Text.Add("Podaj PIN: ");
            return Text;
        }

        public void Operate(int Op)
        {
            if (Machine.CheckPIN(Op))
            {
                Machine.State = new MenuState(Machine);
            }
            else
            {
                Machine.State = new StatusState(Machine, "Zły PIN", true);
            }
        }

        public bool OnCancelButton()
        {
            return false;
        }

        public bool OnAcceptButton()
        {
            return false;
        }
    }
}
