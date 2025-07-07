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

namespace fsd123_project5
{
    /// <summary>
    /// Interaction logic for SanwichMakerWindow.xaml
    /// </summary>
    public partial class SanwichMakerWindow : Window
    {
        //this defines an event that any other class can SUBSCRIBE to
        // "Hey. I am ready to announce a new sandwich !
        public event Action<string, string, string> AssignResult;
        
        public SanwichMakerWindow()
        {
            InitializeComponent();
        }

        private void BtnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            string breadType = comboBreads.Text;
            List<string> selectedVeggies = new List<string>();
            if (chbxLettuce.IsChecked == true)
            {
                selectedVeggies.Add("Lettuce");
            }
            if (chbxTomato.IsChecked == true)
            {
                selectedVeggies.Add("Tomato");
            }
            if (chbxCucumber.IsChecked == true)
            {
                selectedVeggies.Add("cucumber");
            }

            string meat = "";
            if (rbtnChicken.IsChecked == true)
            {
                meat = "chicken";
            }
            if (rbtnTofu.IsChecked == true)
            {
                meat = "Tofu";
            }
            if (rbtnTurkey.IsChecked == true)
            {
                meat = "Turkey";
            }

            //Raise a trigger to the event that others want to subscribe
            AssignResult?.Invoke(breadType, string.Join(",", selectedVeggies), meat);

            DialogResult = true; // closes the dialog and return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
