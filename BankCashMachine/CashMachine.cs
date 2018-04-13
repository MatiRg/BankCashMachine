using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCashMachine
{
    public sealed class CashMachine
    {
        private static CashMachine Instance = null;

        public static Action<IState> StateChanged
        {
            private get;
            set;
        } = null;

        private int Pin;

        public int Cash
        {
            get;
            private set;
        }

        private IState StateIn;

        public IState State
        {
            get => StateIn;
            set
            {
                StateIn = value;
                if( StateChanged != null ) StateChanged.Invoke(StateIn);
            }
        }

        private Dictionary<int, int> Banknotes = new Dictionary<int, int>();
        private readonly int[] BanknotesRef = { 200, 100, 50, 20, 10 };

        private CashMachine()
        {
            State = new NullState(this);
        }

        public static CashMachine Get() => Instance ?? (Instance = new CashMachine());

        public void Setup(int P, int C)
        {
            Pin = P;
            Cash = C;
            foreach (int i in BanknotesRef) Banknotes[i] = 10;
        }

        public bool CheckPIN(int P)
        {
            if (Pin == P)
            {
                return true;
            }
            return false;
        }

        public bool WithdrawMoney(int V)
        {
            if (Cash >= V && V % 10 == 0)
            {
                Dictionary<int, int> Tmp = new Dictionary<int, int>(Banknotes);
                int Value = V;
                int k = 0;
                while (Value != 0 && k != BanknotesRef.Length)
                {
                    int l = Value / BanknotesRef[k];
                    if (l > Tmp[BanknotesRef[k]]) l = Tmp[BanknotesRef[k]];
                    Value -= l * BanknotesRef[k];
                    Tmp[BanknotesRef[k]] -= l;
                    ++k;
                }
                if (Value != 0) return false;
                Cash -= V;
                Banknotes = Tmp;
                return true;
            }
            return false;
        }

        public bool InsertMoney(int V)
        {
            if (V % 10 != 0) return false;
            Dictionary<int, int> Tmp = new Dictionary<int, int>(Banknotes);
            int Value = V;
            int k = 0;
            while (Value != 0 && k != BanknotesRef.Length)
            {
                int l = Value / BanknotesRef[k];
                Value %= BanknotesRef[k];
                Tmp[BanknotesRef[k]] += l;
                ++k;
            }
            if (Value != 0) return false;
            Cash += V;
            Banknotes = Tmp;
            return true;
        }
    }
}
