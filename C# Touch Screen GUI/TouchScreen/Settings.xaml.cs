using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TouchScreen
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Room1Name.Text = (Application.Current.MainWindow as MainWindow).Room1Label.Content.ToString();
            Room2Name.Text = (Application.Current.MainWindow as MainWindow).Room2Label.Content.ToString();
            Room3Name.Text = (Application.Current.MainWindow as MainWindow).Room3Label.Content.ToString();
            //Room4Name.Text = (Application.Current.MainWindow as MainWindow).Room1Label.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Room1Label.Content = Room1Name.Text;
            (Application.Current.MainWindow as MainWindow).Room2Label.Content = Room2Name.Text;
            (Application.Current.MainWindow as MainWindow).Room3Label.Content = Room3Name.Text;
            this.Close();
        }
    }
   
}
