using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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

namespace fsd13_projects8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[] currOwnerImage;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Global.ctx = new CarsOwnerDbContext();
                FetchRecord();
            }
            catch(Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }

        private void FetchRecord()
        {
            //Include means force Eager Loading in one to many relationship
            lvOwners.ItemsSource = Global.ctx.Owners.Include("CarsInGarage").ToList();
        }

        private void lvOwners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOwners.SelectedIndex == -1) {
                ClearInput();
                return;
            }
            Owner o = (Owner)lvOwners.SelectedItem as Owner;
            lblOwnerId.Content = o.Id;
            tbName.Text = o.Name;
            currOwnerImage = o.Photo;
            //we have byte[] => bitmap
            imageViewer.Source = Utils.ByteArrayToBitmap(o.Photo);
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnManageCars.IsEnabled = true;
        }

        private void ClearInput()
        {
            tbName.Text = "";
            imageViewer.Source = null;
            btnDelete.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnManageCars.IsEnabled = false;
            tbImage.Visibility = Visibility.Visible;
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    currOwnerImage = File.ReadAllBytes(dlg.FileName);
                    tbImage.Visibility = Visibility.Hidden;
                    BitmapImage bitmap = Utils.ByteArrayToBitmap(currOwnerImage);
                    imageViewer.Source = bitmap;
                }
                catch(Exception exc) when (exc is SystemException || exc is IOException)
                {
                    MessageBox.Show(exc.Message, "file reading failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsValid()) { return; }
            try
            {
                Owner o = new Owner
                {
                    Name = tbName.Text,
                    Photo = currOwnerImage
                };
                Global.ctx.Owners.Add(o);
                Global.ctx.SaveChanges();

                ClearInput();
                FetchRecord();
            }
            catch (SystemException exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private bool IsFieldsValid()
        {
            if (tbName.Text.Length < 2)
            {
                MessageBox.Show("Name must be between 2 and 100 characters", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (currOwnerImage == null)
            {
                MessageBox.Show("Choose a picture", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsValid()) { return; }
            Owner ownerCurr = (Owner) lvOwners.SelectedItem;
            if(ownerCurr == null) { return; }
            try
            {
                ownerCurr.Name = tbName.Text;
                ownerCurr.Photo = currOwnerImage;
                Global.ctx.SaveChanges();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Owner ownerCurr = (Owner) lvOwners.SelectedItem;
            if (ownerCurr == null) { return; };
            if(MessageBoxResult.Yes != MessageBox.Show("Do you want to delete ? "
                + ownerCurr, "warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                return;
            }
            try
            {
                Global.ctx.Owners.Remove(ownerCurr);
                Global.ctx.SaveChanges();
                ClearInput();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnManageCars_Click(object sender, RoutedEventArgs e)
        {
            Owner owner = (Owner) lvOwners.SelectedItem;
            CarDialog dialog = new CarDialog(owner);
            dialog.ShowDialog();
        }
    }
}