using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20261006
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void feladat_1(object sender, RoutedEventArgs e)
        {
            Window ablak = new feladat_1();
            ablak.Show();
        }

        void feladat_2(object sender, RoutedEventArgs e)
        {
            Window ablak = new feladat_2();
            ablak.Show();
        }

        void feladat_3(object sender, RoutedEventArgs e)
        {
            Window ablak = new feladat_3();
            ablak.Show();
        }

        void feladat_4(object sender, RoutedEventArgs e)
        {
            Window ablak = new feladat_4();
            ablak.Show();
        }
    }
}