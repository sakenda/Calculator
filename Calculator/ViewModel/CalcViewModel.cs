using Calculator.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculator.ViewModel
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        private delegate double Calc(double a, double b);
        private string _Operand = "";
        private string _FullCalc = "";

        public ObservableCollection<string> calcHistory { get; set; } = new ObservableCollection<string>();

        public string Operand
        {
            get => _Operand;
            set
            {
                _Operand = value;
                OnPropertyChanged(nameof(Operand));
            }
        }

        public string FullCalc
        {
            get { return _FullCalc; }
            set 
            { 
                _FullCalc = value;
                OnPropertyChanged(nameof(FullCalc));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ClearAll()
        {
            calcHistory.Clear();
            Operand = "";
            FullCalc = "";
        }

        public void RemoveOperandChar()
        {
            if (Operand.Length > 0)
            {
                Operand = Operand.Remove(Operand.Length - 1);
            }

            FullCalc = FullCalc.Remove(FullCalc.Length - 1);
        }

        public void AddOperandChar(char value)
        {
            Operand += value;
            FullCalc += value;
        }

        public void AddOperator(char op)
        {
            if (!string.IsNullOrEmpty(Operand))
            {
                calcHistory.Add(Operand);
                Operand = "";
            }

            calcHistory.Add(op.ToString());
            FullCalc += $" {op} ";
        }

        public void GetResult()
        {
            Mathematics mathematics = new Mathematics();
            Calc del = null;
            double result = 0.0;
            bool nextToOperate = false;

            if (!string.IsNullOrEmpty(Operand))
            {
                calcHistory.Add(Operand);
                Operand = "";
            }

            foreach (var item in calcHistory)
            {
                if (item == "+" || item == "-" || item == "*" || item == "/")
                {
                    nextToOperate = true;
                    if (item == "+") del = mathematics.Add;
                    else if (item == "-") del = mathematics.Subtract;
                    else if (item == "*") del = mathematics.Multiply;
                    else if (item == "/") del = mathematics.Divide;
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

            if (calcHistory.Count > 1)
            {
                calcHistory.Clear();
                FullCalc = result.ToString();
            }

        }
    }
}
