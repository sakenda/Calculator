using Calculator.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculator.ViewModel
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        private delegate double Calc(double a, double b);
        private Mathematics mathematics = new Mathematics();
        private string _Operand = "";
        private string _FullCalc = "";

        private ObservableCollection<string> calcHistory = new ObservableCollection<string>();

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
            get => _FullCalc;
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
            if (value == ',' && Operand.Contains(","))
            {
                return;
            }

            if (string.IsNullOrEmpty(Operand) && value == ',')
            {
                Operand += "0" + value;
                FullCalc += "0" + value;
                return;
            }

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
            FullCalc += op;
        }

        public void GetResult()
        {
            Calc del = null;
            double result = 0.0;
            bool nextToOperate = false;
            char[] opChars = new char[] { '+', '-', '*', '/' };

            if (!string.IsNullOrEmpty(Operand))
            {
                calcHistory.Add(Operand);
                Operand = "";
            }
            else; // ¯\_(ツ)_/¯

            foreach (var item in calcHistory)
            {
                //if (item == "+" || item == "-" || item == "*" || item == "/")
                if (item.IndexOfAny(opChars) >= 0)
                {
                    if (nextToOperate)
                    {
                        continue;
                    }

                    nextToOperate = true;

                    if (item == "+") del = mathematics.Add;
                    else if (item == "-") del = mathematics.Subtract;
                    else if (item == "*") del = mathematics.Multiply;
                    else if (item == "/") del = mathematics.Divide;

                    continue;
                }

                if (nextToOperate)
                {
                    if (del != null)
                    {
                        result = del(result, double.Parse(item));
                    }
                    nextToOperate = false;
                    Operand = result.ToString();
                    continue;
                }

                //result = double.Parse(item);
                double.TryParse(item, out result);
            }

            if (calcHistory.Count > 0)
            {
                calcHistory.Clear();
                FullCalc = result.ToString();
            }

        }
    }
}
