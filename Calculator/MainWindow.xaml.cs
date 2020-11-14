using Calculator.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mathematics mathematics = new Mathematics();
            mathematics.Input = 100.25;

            Binding bind = new Binding(nameof(mathematics))
            {
                Source = mathematics.Input,
                Mode = BindingMode.TwoWay,
                //UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            TextBox_Result.SetBinding(TextBox.TextProperty, bind);
        }
    }
}
