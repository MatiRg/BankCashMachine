using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public class InputState : IState
    {
        private CashMachine Machine;

        public InputState(CashMachine machine)
        {
            Machine = machine;
        }

        public bool OnAcceptButton()
        {
            return false;
        }

        public bool OnCancelButton()
        {
            Machine.State = new MenuState(Machine); 
            return true;
        }

        public void Operate(int Op)
        { 
            if( Machine.InsertMoney(Op) )
                Machine.State = new StatusState(Machine, "Wpłacono: " + Op);
            else
                Machine.State = new StatusState(Machine, "Nie udało się wpłacić pieniędzy");
        }

        public List<string> Text()
        {
            List<string> Text = new List<string>();
            Text.Add("Ile chcesz wpłacić(Podzielne przez 10): ");
            return Text;
        }
    }
}
