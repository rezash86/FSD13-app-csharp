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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSandwichSelector_Click(object sender, RoutedEventArgs e)
        {
            SanwichMakerWindow sanwichMakerWindow = new SanwichMakerWindow();
            sanwichMakerWindow.Owner = this;

            //It will take some values and bring them here
            //Subscribe to the event in the sandwich maker
            //when the sandwichmaker window calls .Invoke(..) this annynomus function runs

            sanwichMakerWindow.AssignResult += (br, veg, meat) => {
                lblBread.Content = br;
                lblVeggies.Content = veg;
                lblMeat.Content = meat;
            }; ;


            bool? result = sanwichMakerWindow.ShowDialog();
        }

        //private void getInfo(string br, string veggies, string meat)
        //{
        //    lblBread.Content = br.ToString();
        //    lblVeggies.Content = veggies.ToString();
        //    lblMeat.Content = meat.ToString();
        //}
    }
}
