using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public interface IState
    {
        List<string> Text();
        void Operate(int Op);
        // true if handled
        bool OnCancelButton();
        // true if handled
        bool OnAcceptButton();
    }
}
