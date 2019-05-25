using System;
using System.Diagnostics;
using System.Windows;

namespace TaylorSeriesFormm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            decimal x = -1;
            XtoTextBox.Text = x.ToString();
            XfromTextBox.Text = (-x).ToString();
            x = (decimal) 0.1;
            StepTextBox.Text = x.ToString();
            EpsTextBox.Text = x.ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = new MyMathLib.Math(decimal.Parse(XtoTextBox.Text),
                    decimal.Parse(XfromTextBox.Text),
                    decimal.Parse(StepTextBox.Text),
                    decimal.Parse(EpsTextBox.Text));
                ValueTable.ItemsSource = values.GenerateValues();
                ValueTable.CanUserAddRows = false;
                TimeProg.Text = "Время работы программы: " + values.GetTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите корректные данные!");
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}