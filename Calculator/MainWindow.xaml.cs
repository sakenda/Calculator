using Calculator.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        CalcViewModel cvm = new CalcViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = cvm;

            _Window.MouseDown += _Window_MouseDown;
            _Window.KeyDown += _Window_KeyDown;

        }

        private void _Window_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void _Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Back:
                    cvm.RemoveOperandChar();
                    break;
                case Key.Enter:
                    cvm.GetResult();
                    break;
                case Key.NumPad0:
                case Key.D0:
                    cvm.AddOperandChar('0');
                    break;
                case Key.NumPad1:
                case Key.D1:
                    cvm.AddOperandChar('1');
                    break;
                case Key.NumPad2:
                case Key.D2:
                    cvm.AddOperandChar('2');
                    break;
                case Key.NumPad3:
                case Key.D3:
                    cvm.AddOperandChar('3');
                    break;
                case Key.NumPad4:
                case Key.D4:
                    cvm.AddOperandChar('4');
                    break;
                case Key.NumPad5:
                case Key.D5:
                    cvm.AddOperandChar('5');
                    break;
                case Key.NumPad6:
                case Key.D6:
                    cvm.AddOperandChar('6');
                    break;
                case Key.NumPad7:
                case Key.D7:
                    cvm.AddOperandChar('7');
                    break;
                case Key.NumPad8:
                case Key.D8:
                    cvm.AddOperandChar('8');
                    break;
                case Key.NumPad9:
                case Key.D9:
                    cvm.AddOperandChar('9');
                    break;
                case Key.Decimal:
                     cvm.AddOperandChar(',');
                     break;
                case Key.Multiply:
                     cvm.AddOperator('*');
                     break;
                case Key.Add:
                     cvm.AddOperator('+');
                     break;
                case Key.Subtract:
                     cvm.AddOperator('-');
                     break;
                case Key.Divide:
                     cvm.AddOperator('/');
                     break;

                default:
                    break;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('1');
        private void btn2_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('2');
        private void btn3_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('3');
        private void btn4_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('4');
        private void btn5_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('5');
        private void btn6_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('6');
        private void btn7_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('7');
        private void btn8_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('8');
        private void btn9_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('9');
        private void btn0_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar('0');
        private void btnComma_Click(object sender, RoutedEventArgs e) => cvm.AddOperandChar(',');

        private void btnMultiply_Click(object sender, RoutedEventArgs e) => cvm.AddOperator('*');
        private void btnDivide_Click(object sender, RoutedEventArgs e) => cvm.AddOperator('/');
        private void btnAdd_Click(object sender, RoutedEventArgs e) => cvm.AddOperator('+');
        private void btnSubtract_Click(object sender, RoutedEventArgs e) => cvm.AddOperator('-');

        private void btnBack_Click(object sender, RoutedEventArgs e) => cvm.RemoveOperandChar();
        private void btnEquals_Click(object sender, RoutedEventArgs e) => cvm.GetResult();
        private void btnClear_Click(object sender, RoutedEventArgs e) => cvm.ClearAll();

        private void btnExit_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);
    }
}
