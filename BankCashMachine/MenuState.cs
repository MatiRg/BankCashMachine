using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public class MenuState : IState
    {
        private CashMachine Machine;

        public MenuState(CashMachine machine)
        {
            Machine = machine;
        }

        public List<string> Text()
        {
            List<string> Text = new List<string>();
            Text.Add("1.Stan Konta");
            Text.Add("2.Wypłata");
            Text.Add("3.Wpłata");
            Text.Add("4.Wyjmij Karte");
            return Text;
        }

        public void Operate(int Op)
        {
            switch (Op)
            {
                case 1:
                    Machine.State = new StatusState(Machine, "Stan Konta: "+Machine.Cash);
                    break;
                case 2:
                    Machine.State = new WithdrawState(Machine);
                    break;
                case 3:
                    Machine.State = new InputState(Machine);
                    break;
                case 4:
                    Machine.State = new NullState(Machine);
                    break;
                default:
                    break;
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
