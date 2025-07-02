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

namespace Assignment3
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

        private void TxtBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Some action 
            TempConvert();
        }

        private void Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            TempConvert();
        }

        private void TempConvert()
        {
            string inputValue = txtBoxInput.Text;
            double temp;
            if (!double.TryParse(inputValue, out temp)) {
                return;
            }

            if (rbtnInputCelc.IsChecked == true)
            {
                if (rbtnOutputCelc.IsChecked == true) {
                    lblResult.Content = string.Format("{0:0.0}° C", temp);
                } 
                if(rbtnOutputFaren.IsChecked == true)
                {
                    lblResult.Content = string.Format("{0:0.0}° F", ((temp* 9 / 5) + 32));
                }

                if (rbtnOutputKelvin.IsChecked == true)
                {
                    lblResult.Content = string.Format("{0:0.0}° K", (temp + 273.15));
                }

            }
            if (rbtnInputFaren.IsChecked == true)
            {
                if (rbtnOutputCelc.IsChecked == true)
                {
                    //(1°F − 32) × 5 / 9
                    lblResult.Content = string.Format("{0:0.0}° C", ((temp - 32) * 5) / 9);
                }

                if (rbtnOutputFaren.IsChecked == true)
                {
                    lblResult.Content = string.Format("{0:0.0}° F", temp);
                }

                //(1°F − 32) × 5 / 9 + 273.15 


                if (rbtnOutputKelvin.IsChecked == true)
                {
                    lblResult.Content = string.Format("{0:0.0}° K", (((temp -32) * 5)/9 + 273.15));
                }
            }

            //TODO: do it for kelvin and convert to F and C
        }
    }
}