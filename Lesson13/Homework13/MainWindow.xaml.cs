using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Describe with UML ‘internet shop’ domain. It should include products (with price, quantity, etc.), buyers(personal information), receipts(what was sold and to whom), etc.
//Provide console interface to register new product, add quantity to existent, sell product, register buyer.

namespace Homework13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Session CurrentSession = new Session();

        public MainWindow()
        {
            InitializeComponent();
            this.AddProduct.Visibility = Visibility.Collapsed;
            this.AddBuyer.Visibility = Visibility.Collapsed;
            this.ProductNameTxt.Visibility = Visibility.Collapsed;
            this.PriceTxt.Visibility = Visibility.Collapsed;
            this.DescriptionTxt.Visibility = Visibility.Collapsed;
            this.QttyTxt.Visibility = Visibility.Collapsed;
            this.LoadProductIMG.Visibility = Visibility.Collapsed;  
            this.UserNameTxt.Visibility = Visibility.Collapsed;
            this.DiscountTxt.Visibility = Visibility.Collapsed;
            this.SwichMode.Content = "Swich to Admin mode:)";


            Shops.sessions.Add(CurrentSession);

            Shops.LoadBayers("Buyers.txt");
            if (Shops.buyers != null && Shops.buyers.Count != 0)  {
                CurrentSession.Buyer = Shops.buyers[0];//Without login function let it be first from list
            }
            else   {
                Buyers buyer = new Buyers();
                buyer.Name = "Dmytro Bonislavskyi";
                buyer.Discount = 20;
                CurrentSession.Buyer = buyer;
            }
            CurrentSession.Buyer.Show(this, CurrentSession);

            Shops.LoadProducts("Products.txt");
            int currentProduct = 0;
            if (Shops.products != null && Shops.products.Count != 0) Shops.products[currentProduct].Show(this, CurrentSession);
            else MessageBox.Show("There are no products in your shop yet.\nGo to Admin mode and add some.");
        }



        private void SwitchToAdmin(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Admin mode");
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("AdminPage.xaml", UriKind.Relative);
            //window.Show();
            //this.Visibility = Visibility.Hidden;
            if (this.SwichMode.Content == "Swich to Admin mode:)")
            {
                this.AddProduct.Visibility = Visibility.Visible;
                this.AddBuyer.Visibility = Visibility.Visible;
                this.ProductNameTxt.Visibility = Visibility.Visible;
                this.PriceTxt.Visibility = Visibility.Visible;
                this.DescriptionTxt.Visibility = Visibility.Visible;
                this.QttyTxt.Visibility = Visibility.Visible;
                this.LoadProductIMG.Visibility = Visibility.Visible;
                this.UserNameTxt.Visibility = Visibility.Visible;
                this.DiscountTxt.Visibility = Visibility.Visible;

                this.SwichMode.Content = "Exit from Admin Mode";

            }
            else 
            {
                this.AddProduct.Visibility = Visibility.Collapsed;
                this.AddBuyer.Visibility = Visibility.Collapsed;
                this.ProductNameTxt.Visibility = Visibility.Collapsed;
                this.PriceTxt.Visibility = Visibility.Collapsed;
                this.DescriptionTxt.Visibility = Visibility.Collapsed;
                this.QttyTxt.Visibility = Visibility.Collapsed;
                this.LoadProductIMG.Visibility = Visibility.Collapsed;
                this.UserNameTxt.Visibility = Visibility.Collapsed;
                this.DiscountTxt.Visibility = Visibility.Collapsed;
                this.SwichMode.Content = "Swich to Admin mode:)";
            }

        }
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            if (Shops.products.Count > 0)
            {
                if (Shops.products[this.CurrentSession.CurrentProduct].Quantity > 0)
                {
                    this.CurrentSession.cart.AddToCart(Shops.products[this.CurrentSession.CurrentProduct], 1);
                    //this.CurrentSession.cart.ProductsInCart.Add(Shops.products[this.CurrentSession.CurrentProduct]);
                    Shops.products[this.CurrentSession.CurrentProduct].Show(this, this.CurrentSession);
                }
                else MessageBox.Show($"No more {Shops.products[this.CurrentSession.CurrentProduct].ProductName}'s on stock.");
            }
        }

        private void RemoveFromCart(object sender, RoutedEventArgs e)
        {
            if (Shops.products.Count > 0)
            {
                this.CurrentSession.cart.ReturnFromCart(Shops.products[this.CurrentSession.CurrentProduct]);
                //this.CurrentSession.cart.ProductsInCart.Add(Shops.products[this.CurrentSession.CurrentProduct]);
                Shops.products[this.CurrentSession.CurrentProduct].Show(this, this.CurrentSession);
            }
        }

        private void NextProduct(object sender, RoutedEventArgs e)
        {
            if (Shops.products.Count > 0)
            {
                if (this.CurrentSession.CurrentProduct == Shops.products.Count - 1) this.CurrentSession.CurrentProduct = 0;
                else this.CurrentSession.CurrentProduct++;
                Shops.products[this.CurrentSession.CurrentProduct].Show(this, CurrentSession);
            }
        }
        private void PreviousProduct(object sender, RoutedEventArgs e)
        {
            if (Shops.products.Count > 0)
            {
                if (this.CurrentSession.CurrentProduct == 0) this.CurrentSession.CurrentProduct = Shops.products.Count - 1;
                else this.CurrentSession.CurrentProduct--;
                Shops.products[this.CurrentSession.CurrentProduct].Show(this, CurrentSession);
            }
        }
        private void GoToCart(object sender, RoutedEventArgs e)
        {
            if (this.CurrentSession.cart.ProductsInCart.Count > 0)            {
                Shops.Sale(this.CurrentSession);
                Shops.products[this.CurrentSession.CurrentProduct].Show(this, this.CurrentSession);
            }
            else MessageBox.Show("Cart is Empty, add something into!");
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("ToCart.xaml", UriKind.Relative);
            //window.Show();
            //this.Visibility = Visibility.Hidden;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Products tempProd = new Products("Noname",0,0,"NoDescription");
            Shops.AddProduct(tempProd);
            this.CurrentSession.CurrentProduct =  Shops.products.Count-1;
            Shops.products.Last().Show(this, this.CurrentSession);
            //Shops.products[this.CurrentSession.CurrentProduct].Show(this, this.CurrentSession);
        }

        private void LoadProductIMG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string prefix = "";
                //Uri fileUri = new Uri(openFileDialog.SafeFileName);
                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + openFileDialog.SafeFileName)) prefix = new Random().Next(999).ToString(); ;
                File.Copy(openFileDialog.FileName, AppDomain.CurrentDomain.BaseDirectory + prefix + openFileDialog.SafeFileName);
                PImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + prefix + openFileDialog.SafeFileName, UriKind.Absolute));
                Shops.products[this.CurrentSession.CurrentProduct].ProdImg = prefix + openFileDialog.SafeFileName ;
            }

        }

        private void ProductNameTxt_TextChanged(object sender, KeyboardFocusChangedEventArgs e)
        {
            string text = this.ProductNameTxt.Text;
            if (!string.IsNullOrEmpty(text))            {
                if (text.Length > 16) text = text.Substring(0, 16);
                Shops.products[this.CurrentSession.CurrentProduct].ProductName = text;//.Substring(0, 16);
                // Regex.Replace(this.ProductNameTxt.Text, "[^A-Za-z]+", string.Empty); ;
                this.ProductNameTxt.Text = text;
            }
        }

        private void DescriptionTxt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string text = this.DescriptionTxt.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length > 25) text = text.Substring(0, 25);
                Shops.products[this.CurrentSession.CurrentProduct].Description = text;
                this.DescriptionTxt.Text = text;
            }
        }

        private void QttyTxt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string text = this.QttyTxt.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (UInt32.TryParse(text, out uint quentity)) Shops.products[this.CurrentSession.CurrentProduct].Quantity = (int)quentity;
                else this.QttyTxt.Text = Shops.products[this.CurrentSession.CurrentProduct].Quantity.ToString();
            }

        }

        private void PriceTxt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string text = this.PriceTxt.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (Decimal.TryParse(text, out decimal price)) Shops.products[this.CurrentSession.CurrentProduct].Price = Math.Abs(price);
                else this.PriceTxt.Text = Shops.products[this.CurrentSession.CurrentProduct].Price.ToString();
            }
        }

        private void UserNameTxt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {


        }

        private void DiscountTxt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void AddBuyer_Click(object sender, RoutedEventArgs e)
        {
            string name = this.UserNameTxt.Text;
            string discont = this.DiscountTxt.Text;
            Shops.AddBuyer(name, discont);
        }
    }
}
