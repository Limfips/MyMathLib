using System;
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
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      try
      {
        var x = new MyMathLib.Math(Convert.ToDouble(XtoTextBox.Text),
          Convert.ToDouble(XfromTextBox.Text),
          Convert.ToDouble(StepTextBox.Text),
          Convert.ToDouble(EpsTextBox.Text));
        PhonesGrid.ItemsSource = x.GenerateValues();
        PhonesGrid.CanUserAddRows = false;
        TimeProg.Text = "Время работы программы: "+x.GetTime();
      }
      catch (Exception)
      {
        MessageBox.Show("Введите корректные данные!");
      }

    }
  }
}
