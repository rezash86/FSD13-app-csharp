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
using System.IO;

namespace fsd13_project3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * https://wpf-tutorial.com/misc-controls/the-slider-control/
         */
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The form is loaded", "this is my caption", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save the information from the form into a file
            bool valid = true;
            string fileName = "info.txt";

            File.AppendAllText(fileName, "Name;Age;Pets;" + "\n"); 
            string name = txtBoxName.Text;
            // we can validate the name

            if (name.Length == 0)
            {
                MessageBox.Show("Please enter a name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
            string age = "";
            if (rbtnBelow18.IsChecked == true)
            {
                age = rbtnBelow18.Content.ToString();
            }
            else if (rbtnOver18.IsChecked == true)
            {
                age = rbtnOver18.Content.ToString();
            }
            else if(rbtnOver20.IsChecked == true)
            {
                age = rbtnOver20.Content.ToString();
            }
            else
            {
                MessageBox.Show("Please enter one of the options");
                valid = false;
            }

            List<string> petList = new List<string>();
            if (chboxCat.IsChecked == true)
            {
                petList.Add(chboxCat.Content.ToString());
            }
            if (chboxDog.IsChecked == true)
            {
                petList.Add(chboxDog.Content.ToString());
            }
            if (chboxOther.IsChecked == true)
            {
                petList.Add(chboxOther.Content.ToString());
            }

            //I want to save them to gether in string with , seperated
            string pets = string.Join(",", petList);

            string continent = cmbContinents.Text;
            string prefferedTemp = lblTemp.Content.ToString();

            if(valid == true)
            {
                File.AppendAllText(fileName, $"{name};{age};{pets};{continent};{prefferedTemp}");
                MessageBox.Show("saved successfully !");
            }
        }
    }
}