using System.IO;
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

namespace fsd13_project4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> selectedOnes = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            //load data here
            LoadData();
        }

        private void LoadData()
        {
            const string dataFile = @"..\..\..\available.txt";
            if (File.Exists(dataFile))
            {
                List<string> flavorList = new List<string>();
                foreach (string line in File.ReadAllLines(dataFile))
                {
                    flavorList.Add(line);
                }
                //put the data into my listview
                lvIceCreamFlavors.ItemsSource = flavorList;
            }
        }

        private void BtnDeleteScoop_Click(object sender, RoutedEventArgs e)
        {
            if(lvSelectedFlavors.Items.Count == 0)
            {
                return;
            }
            if(lvSelectedFlavors.SelectedIndex == -1)
            {
                MessageBox.Show("please choose a scoop");
                return;
            }
            var selectedForDelete = lvSelectedFlavors.SelectedItems;

            foreach (string item in selectedForDelete)
            {
                selectedOnes.Remove(item);
            }
            lvSelectedFlavors.ItemsSource = null;
            lvSelectedFlavors.ItemsSource = selectedOnes;
        }

        private void BtnClearFlavors_Click(object sender, RoutedEventArgs e)
        {
            //nothing to remove
            if(lvSelectedFlavors.Items.Count == 0)
            {
                return;
            }
            //confirmation message
            MessageBoxResult result = MessageBox.Show("Are you sure to delete", "Clear All", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                lvSelectedFlavors.ItemsSource = null;
            }
            selectedOnes.Clear();
        }

        private void AddFlavor_Click(object sender, RoutedEventArgs e)
        {
            if(lvIceCreamFlavors.SelectedIndex == -1)
            {
                MessageBox.Show("you need to choose a falvour");
                return;
            }
            var selectedIndex = lvIceCreamFlavors.SelectedIndex; //the index of selected 
            var selectedList = lvIceCreamFlavors.SelectedItems; // the values of selected

            foreach (string item in selectedList)
            {
                selectedOnes.Add(item);
            }

            lvSelectedFlavors.ItemsSource = null;
            lvSelectedFlavors.ItemsSource = selectedOnes;

            lvIceCreamFlavors.SelectedIndex = -1; // choose nothing after adding to the list
        }
    }
}