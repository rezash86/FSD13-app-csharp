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

namespace fsd13_project4
{
    /// <summary>
    /// Interaction logic for GridViewExample.xaml
    /// </summary>
    public partial class GridViewExample : Window
    {
        
        public List<Person> People { get; set; }
        public GridViewExample()
        {
            InitializeComponent();
            People = new List<Person>
            {
                new Person {Name = "Alex", Age= 20},
                new Person{ Name= "Rose", Age = 18}
            };

            //lvPoepleData.ItemsSource = People;
            DataContext = this;
        }
    }
}
