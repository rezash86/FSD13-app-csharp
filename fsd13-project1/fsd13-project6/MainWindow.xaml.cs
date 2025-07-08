using CsvHelper;
using Microsoft.Win32;
using System.Data;
using System.Globalization;
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


namespace fsd13_project6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileName = @"..\..\..\cars.txt";
        List<Car> cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
        }

        private void LoadFile()
        {
            if (!File.Exists(fileName))
            {
                return;
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] myData = line.Split(';');
                    double engineSize;
                    if (!double.TryParse(myData[1], out engineSize))
                    {
                        MessageBox.Show("Input string error");
                        continue;
                    }
                    Car.FuelTypeEnum fuelType;
                    if (!Enum.TryParse(myData[2], out fuelType))
                    {
                        MessageBox.Show("there is an error to parse data");
                        continue;
                    }
                    Car car = new Car(myData[0], engineSize, fuelType);
                    cars.Add(car);
                    line = sr.ReadLine();
                }
                lvCars.ItemsSource = cars;
                UpdateStatusBar();
            }
        }

        private void UpdateStatusBar()
        {
            int carsNo = lvCars.Items.Count;
            tbStatus.Text = string.Format("You Currently have {0} cars", carsNo);
        }


        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvCars.SelectedIndex == -1)
            {
                return;
            }
            Car carToEdit = (Car)lvCars.SelectedItem;
            CarWindow carWindow = new CarWindow(carToEdit);
            carWindow.Owner = this;
            bool? result = carWindow.ShowDialog();

            if (result == true)
            {
                lvCars.Items.Refresh();
                UpdateStatusBar();
            }



        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvCars.SelectedIndex == -1)
            {
                MessageBox.Show("You need to choose a car to be deleted");
                return;
            }
            Car carToBeDeleted = (Car)lvCars.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes) {
                cars.Remove(carToBeDeleted);
                lvCars.Items.Refresh();
                UpdateStatusBar();
            }
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
            UpdateStatusBar();
        }

        private void AddItem()
        {
            //we need to open a new window to add the new car
            CarWindow carWindow = new CarWindow(null);
            carWindow.Owner = this;

            //Subscribe to the event 
            //carWindow.AddedNewCar += (car) => cars.Add(car);
            carWindow.AddedNewCar += AddCarsToList;

            bool? result = carWindow.ShowDialog();
            lvCars.Items.Refresh(); //it refreshes the value inside the listview
            UpdateStatusBar();
        }

        void AddCarsToList(Car car)
        {
            cars.Add(car);
        }

        private void MenuItemExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file(*.csv)|*.csv";
            saveFileDialog.Title = "Export to file";

            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ","
                    }))
                    {
                        csv.WriteRecords(cars); // 'cars' should be a list or IEnumerable of objects
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in writing to file");
            }

        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var car in cars)
                {
                    writer.WriteLine(car.ToDataString());
                }
            }
        }
    

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveToFile();
        }
    }

}