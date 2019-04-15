## О проекте
Ошибка располагается в файле MainVindow.xaml
```python
<DataGrid x:Name="PhonesGrid"
                  Grid.Row="0"
                  Grid.Column="1"
                  Grid.RowSpan="2">
        </DataGrid>
```
и в файле MainWindow.xaml.cs
```python
private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    { 
	List<Phone> phonesList = new List<Phone>
      {
        new Phone { Title="iPhone 6S", Company="Apple", Price=0 },
        new Phone {Title="Lumia 950", Company="Microsoft", Price=1 },
        new Phone {Title="Nexus 5X", Company="Google", Price=2 }
      };
      PhonesGrid.ItemsSource = phonesList;
    }
```
----
```python
public class Phone
  {
    public string Title { get; set; }
    public string Company { get; set; }
    public int Price { get; set; }
  }
```
##Вот что получается
![alt text](https://github.com/Limfips/WPF_SevenLab/blob/master/resImg/error_v1.2.1.png)
как убрать лишние строки???