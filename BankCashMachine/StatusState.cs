using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public class StatusState : IState
    {
        private CashMachine Machine;
        private string Status;
        private bool InMode = false;

        public StatusState(CashMachine machine, string text, bool In = false)
        {
            Machine = machine;
            Status = text;
            InMode = In;
        }

        public bool OnAcceptButton()
        {
            Machine.State = !InMode ? new MenuState(Machine) : (IState)new NullState(Machine);
            return true;
        }

        public bool OnCancelButton()
        {
            Machine.State = !InMode ? new MenuState(Machine) : (IState)new NullState(Machine);
            return true;
        }

        public void Operate(int Op)
        {
        }

        public List<string> Text()
        {
            List<string> Text = new List<string>();
            Text.Add(Status);
            return Text;
        }
    }
}
