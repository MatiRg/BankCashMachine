using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public class WithdrawState : IState
    {
        private CashMachine Machine;

        public WithdrawState(CashMachine machine)
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
            if( Machine.WithdrawMoney(Op) )
                Machine.State = new StatusState(Machine, "Wybrano: "+Op);
            else
                Machine.State = new StatusState(Machine, "Nie udało się wybrać pieniędzy");
        }

        public List<string> Text()
        {
            List<string> Text = new List<string>();
            Text.Add("Ile chcesz wybrać(Podzielne przez 10): ");
            return Text;
        }
    }
}
