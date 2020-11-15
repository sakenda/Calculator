using Calculator.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculator.ViewModel
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> calcHistory { get; set; } = new ObservableCollection<string>();

        private string _Operand = "";
        public string Operand
        {
            get => _Operand;
            set
            {
                _Operand = value;
                OnPropertyChanged(nameof(Operand));
            }
        }

        Mathematics mathematics = new Mathematics();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ClearAll()
        {
            calcHistory.Clear();
            Operand = "";
        }

        public void RemoveOperandChar()
        {
            Operand = Operand.Remove(Operand.Length - 1);
        }

        public void AddOperandChar(char value)
        {
            Operand += value;
        }

        public void AddOperator(char op)
        {
            calcHistory.Add(Operand);
            Operand = "";
            calcHistory.Add(op.ToString());
        }

        delegate double Calc(double a, double b);

        public void GetResult()
        {
            if (!string.IsNullOrEmpty(Operand))
            {
                calcHistory.Add(Operand);
                Operand = "";
            }

            double result = 0.0;
            bool nextToOperate = false;

            Calc del = null;

            foreach (var item in calcHistory)
            {
                if (item == "+" || item == "-" || item == "*" || item == "/")
                {
                    CheckOperator(item);
                    continue;
                }
                if (nextToOperate)
                {
                    if (del != null) result = del(result, double.Parse(item));
                    nextToOperate = false;
                    Operand = result.ToString();
                    continue;
                }

                result = double.Parse(item);

            }

            void CheckOperator(string op)
            {
                nextToOperate = true;
                if (op == "+") del = mathematics.Add;
                if (op == "-") del = mathematics.Subtract;
                if (op == "*") del = mathematics.Multiply;
                if (op == "/") del = mathematics.Divide;
            }
        }
    }
}
