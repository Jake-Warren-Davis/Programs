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
//This adds regex functions. 
using System.Text.RegularExpressions;

namespace PurchasingApp
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            for (int i = 0; i < PurchaseWindow.orderList.Count; i++)
            {
                lstBasket.Items.Add(PurchaseWindow.orderedItems[i].ToString());
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //Remove selected items.
            foreach (string s in lstBasket.SelectedItems.OfType<string>().ToList())
            {
                lstBasket.Items.Remove(s);
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            //Checkout.
            float finalstring = 0;
            foreach (string item in lstBasket.Items)
            {
            //Use regex to get all the maths functions.
            Regex reg = new Regex(@"[0-9]+\.[0-9]+");
            //Store the stuff from the string that matches the regex values and then parse it.
            Match mat = reg.Match(item);
            float temp = float.Parse(mat.Value);
            finalstring += temp;
            }
            lblPrice.Content = "Total Price: £" + finalstring.ToString();
        }
    }
}
