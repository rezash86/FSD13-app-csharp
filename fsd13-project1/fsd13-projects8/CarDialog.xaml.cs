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

namespace fsd13_projects8
{
    /// <summary>
    /// Interaction logic for CarDialog.xaml
    /// </summary>
    public partial class CarDialog : Window
    {
        Owner currOwner;
        public CarDialog(Owner owner)
        {
            InitializeComponent();
            currOwner = owner;
            lblDialogName.Content = currOwner.Name;
            FetchRecords();
        }

        private void FetchRecords()
        {
            lvDialogCars.ItemsSource = currOwner.CarsInGarage.ToList();
        }

        private void lvDialogCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDialogCars.SelectedIndex == -1)
            {
                ClearDialogInputs();
                return;
            }
            Car c = (Car)lvDialogCars.SelectedItem;
            lblDialogId.Content = c.Id;
            tbDialogMakeModel.Text = c.MakeModel;
            btnDialogDelete.IsEnabled = true;
            btnDialogUpdate.IsEnabled = true;
        }

        private void btnDialogDone_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnDialogAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDialogFieldsValid()) { return; }
            try
            {
                Car car = new Car
                {
                    MakeModel = tbDialogMakeModel.Text,
                    //we need to know the current owner
                    OwnerId = currOwner.Id
                };
                Global.ctx.Cars.Add(car);
                Global.ctx.SaveChanges();
                //clear the input
                ClearDialogInputs();
                FetchRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsDialogFieldsValid()
        {
            if (tbDialogMakeModel.Text.Length < 1)
            {
                MessageBox.Show("Please fill the field", "validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void ClearDialogInputs()
        {
            tbDialogMakeModel.Text = "";
            lblDialogId.Content = "";
            btnDialogDelete.IsEnabled = false;
            btnDialogUpdate.IsEnabled = false;
        }

        private void btnDialogDelete_Click(object sender, RoutedEventArgs e)
        {
            Car carCurr = (Car)lvDialogCars.SelectedItem;
            if (carCurr == null) return;
            if (MessageBoxResult.No == MessageBox.Show("Do you want to delete the record?\n" + carCurr, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            { return; }
            try
            {
                Global.ctx.Cars.Remove(carCurr);
                Global.ctx.SaveChanges();
                ClearDialogInputs();
                FetchRecords();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void btnDialogUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDialogFieldsValid()) { return; }
            Car carCurr = (Car)lvDialogCars.SelectedItem;
            if (carCurr == null) { return; }

            try
            {
                carCurr.MakeModel = tbDialogMakeModel.Text;
                Global.ctx.SaveChanges();
                ClearDialogInputs();
                FetchRecords();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // FetchRecords();
        }
    }
}
