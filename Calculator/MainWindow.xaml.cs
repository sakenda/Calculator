using Calculator.ViewModel;
using System.Windows;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        CalcViewModel cvm = new CalcViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = cvm;
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
    }
}
