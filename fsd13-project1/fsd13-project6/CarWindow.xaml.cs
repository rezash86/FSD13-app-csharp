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

namespace fsd13_project6
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public event Action<Car> AddedNewCar;

        public Car currntCar;
        public CarWindow(Car car)
        {
            InitializeComponent();

            //add dynamic load
            comboFuelType.ItemsSource = Enum.GetValues(typeof(Car.FuelTypeEnum));
            comboFuelType.SelectedIndex = 0;

            if (car != null) // I want to edit the car
            { 
                currntCar = car;
                tbMakeModel.Text = car.MakeModel;
                sliderEngineSize.Value = car.EngineSize;
                comboFuelType.SelectedItem = car.FuelType;

                btnSaveUpdate.Content = "Update";
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            string makeModel = tbMakeModel.Text;
            double engineSize = sliderEngineSize.Value;
            Car.FuelTypeEnum fuelType = (Car.FuelTypeEnum)comboFuelType.SelectedItem;

            // if it is update or save
            if (currntCar != null)
            {
                currntCar.MakeModel = makeModel;
                currntCar.EngineSize = engineSize;
                currntCar.FuelType = fuelType;
            }
            else
            {
                AddedNewCar?.Invoke(new Car(makeModel, engineSize, fuelType));
            }
            DialogResult = true;
        }
    }
}
