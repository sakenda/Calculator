using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator.ViewModel
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        private double _Output;
        public double Output
        {
            get => _Output;
            set
            {
                _Output = value;
                OnPropertyChanged(nameof(Output));
            }
        }

        Mathematics mathematics = new Mathematics();
        string operand = "";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));

        public void AddOperandChar(string value)
        {
            operand += value;
            Output = double.Parse(operand);
        }

        public void Operate(char op)
        {
            if (op == '+')
            {
                Output = mathematics.Add(Output, double.Parse(operand));
            }
            else if (op == '-')
            {
                Output = mathematics.Subtract(Output, double.Parse(operand));
            }
            else if (op == '*')
            {
                Output = mathematics.Multiply(Output, double.Parse(operand));
            }
            else if (op == '/')
            {
                Output = mathematics.Divide(Output, double.Parse(operand));
            }
        }
    }
}
