using System.Collections.Generic;
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
      var x = new MyMathLib.Math(1,10,2,1);
      
      
      List<Phone> phonesList = new List<Phone>
      {
        new Phone { Title="iPhone 6S", Company="Apple", Price=0 },
        new Phone {Title="Lumia 950", Company="Microsoft", Price=1 },
        new Phone {Title="Nexus 5X", Company="Google", Price=2 }
      };
      PhonesGrid.ItemsSource = phonesList;
    }
  }
  public class Phone
  {
    public string Title { get; set; }
    public string Company { get; set; }
    public int Price { get; set; }
  }
}
