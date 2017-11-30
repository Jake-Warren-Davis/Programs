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
//Add this for later jsut in case.
using System.Xaml.Permissions;
using System.Data;
using System.Windows.Markup;
//This adds regex functions. 
using System.Text.RegularExpressions;

namespace PurchasingApp
{
    /// <summary>
    /// Interaction logic for PurchaseWindow.xaml
    /// </summary>
    public partial class PurchaseWindow : Window
    {
        ListBox tmpList = new ListBox();
        public static string[] orderedItems;
        public static string orderString;
        
        public static List<string> orderList = new List<string>();
        



        public PurchaseWindow()
        {
            InitializeComponent();

            //Stop this window resizing and display the username.
            this.ResizeMode = ResizeMode.NoResize;
            lblUsername.Content = "User: " + MainWindow.Username;
            
            //Add all the items.
            
            //Comics
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Comic £2.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Comic £2.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Comic £2.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Comic £2.99" });

            
            //Collectables
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Collectable £6.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Collectable £6.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Collectable £6.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Collectable £6.99" });
            
            //Food and Drink
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Crisps £0.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Chocolate bar £0.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Water £1.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Fruit juice £1.99" });
            
            //Mugs
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Mug £9.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Mug £9.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Mug £9.99" });
            LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Mug £9.99" });

            //Now time to add all the items from the orders list to the tempory list.

            //Add all the items to temp list.

            //Comics
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Comic £2.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Comic £2.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Comic £2.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Comic £2.99" });

            //Collectables
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Collectable £6.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Collectable £6.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Collectable £6.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Collectable £6.99" });

            //Food and Drink
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Crisps £0.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Chocolate bar £0.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Water £1.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Fruit juice £1.99" });

            //Mugs
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Superman Mug £9.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Spiderman Mug £9.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Batman Mug £9.99" });
            tmpList.Items.Add(new BoolStringClass { IsSelected = false, TheText = "Flash Mug £9.99" });

            
            
        }

        


        //Setting the text and select variables as public.
        //Jsut realised that I could get the item.IsChecked through a foreach loop which would have saved so much time. I hate microsoft's c# documentation.
        public class BoolStringClass
        {
            public string TheText { get; set; }
            public bool IsSelected { get; set; }
        }


       




        //tmpList.Items.Add(LstOrders.Items);
        private void imgBasket_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        
        {
            //Open up a new basket window.
            Basket bk = new Basket();
            bk.Show();
            orderList.Clear();
        }
        
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Most of this could have been avoided too.
            //Items are cleared every search and added later.
            LstOrders.Items.Clear();
            

            if (txtSearch.Text == "")
            {
                foreach (BoolStringClass item in tmpList.Items)
                {

                    LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = item.TheText.ToString() });
                }
            }
            else
            {
                foreach (BoolStringClass item in tmpList.Items)
                {
                    if (item.TheText.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        LstOrders.Items.Add(new BoolStringClass { IsSelected = false, TheText = item.TheText.ToString() });
                    }
                }
            }
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Thsi makes sure the user cant enter in any characters.
            char[] input;
            input = txtQuantity.Text.ToCharArray();
            string output = "";
            

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    output += input[i];
                }
            }

            

            txtQuantity.Text = output;

            if (txtQuantity.Text == "" || txtQuantity.Text == "0")
            {
                txtQuantity.Text = "1";
            }


            int num = int.Parse(txtQuantity.Text);
            if (num > 999)
            {
                num = 999;
                txtQuantity.Text = num.ToString();
            }

        }

        private void btnNmbUp_Click(object sender, RoutedEventArgs e)
        {
            //Handles increasing the number.
            int num = int.Parse(txtQuantity.Text);
            if (num < 999)
            {
                num += 1;
                txtQuantity.Text=num.ToString();
            }
        }

        private void btnNmbDown_Click(object sender, RoutedEventArgs e)
        {
            //Handles decreasing the number.
            int num = int.Parse(txtQuantity.Text);
            if (num > 1)
            {
                num -= 1;
                txtQuantity.Text = num.ToString();
            }
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {


            
            foreach (BoolStringClass item in LstOrders.Items)
            {
                if (item.IsSelected == true)
                {
                    for(int i =0; i<int.Parse(txtQuantity.Text); i++)
                    {
                    orderList.Add(item.TheText.ToString());
                    
                    orderedItems = orderList.ToArray();

                    orderString += item.TheText;
                    }

                }
            }
        }


        //This handles all the selecting stuff. All of this could have been avoided.

        private void lblSelectedItems_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Content = LstOrders.SelectedItems.Count.ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox ckitem = (CheckBox)sender;
            
            ckitem.IsChecked = true;

            foreach (BoolStringClass item in LstOrders.Items)
            {

                if (item.TheText == ckitem.Content.ToString())
                {
                    item.IsSelected = true;
                }
            }
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            CheckBox ckitem = (CheckBox)sender;
            ckitem.IsChecked = false;

            foreach (BoolStringClass item in LstOrders.Items)
            {

                if (item.TheText == ckitem.Content.ToString())
                {
                    item.IsSelected = false;
                }
            }

           string temp = ckitem.Content.ToString();
           string[] tt = temp.Split();
           string output = "";
           for (int i = 0; i < tt.Length; i++)
           {
                output += temp[i];
           }
        }

        private void btnClearCart_Click(object sender, RoutedEventArgs e)
        {
            orderList.Clear();
        } 

    }
}
