using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Homework13;

interface IShowable {
    void Show(Homework13.MainWindow win, Session session);

}
internal class Products: IShowable //, ICreatable, ISalable
{
    int _id;
    decimal _price;
    int _quantity;
    public decimal Price { get { return _price; } set { _price = value; } }
    public int Id { get { return _id; } set { _id = value; } }
    public int Quantity { get { return _quantity; } set { _quantity = value; } }
    public string ProductName { get; set; }   
    public string Description { get; set; }
    //public Bitmap ProdImg;
    public string ProdImg;

    public Products(string productName)  {
        this.Id = ++Shops._lastProdID;
        this.ProductName = productName;
        this.ProdImg = "defoult.png";
    }

    public Products(string productName, decimal price)    {
        this.Id = ++Shops._lastProdID;
        this.ProductName = productName;
        this.Price = price;
        this.ProdImg = "defoult.png";
    }

    public Products(string productName, decimal price, int qty)    {
        this.Id = ++Shops._lastProdID;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity= qty;
        this.ProdImg = "defoult.png";
    }

    public Products(string productName, decimal price, int qty, string description)    {
        this.Id = ++Shops._lastProdID;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = qty;
        this.Description = description;
        this.ProdImg = "defoult.png";
    }

    public void Show(Homework13.MainWindow win, Session session)    {

        win.PImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + this.ProdImg, UriKind.Absolute));
        win.Price.Content = this.Price.ToString();
        win.ProductName.Content = this.ProductName;
        win.Qtty.Content = this.Quantity.ToString();
        win.Description.Content = this.Description;
        //win.Description.Visibility = Visibility.Collapsed;
        win.PriceWDisc.Content = this.Price /100 * (100- session.Buyer.Discount);
        if (session.cart.ProductsInCart.Count > 0)        {
            if (session.cart.ProductsInCart.Contains(this))
                win.TotalPrice.Content = this.Price / 100 * (100 - session.Buyer.Discount) * session.cart.Qtty[session.cart.ProductsInCart.IndexOf(this)];
            else win.TotalPrice.Content = 0;
            
            decimal totalPriceAll = 0;
            int totalAmountAll = 0;
            string inCart = "";
            int i = 0;
            foreach (var prod in session.cart.ProductsInCart)            {
                totalPriceAll += prod.Price / 100 * (100 - session.Buyer.Discount) * session.cart.Qtty[i];
                totalAmountAll += session.cart.Qtty[i];
                inCart += $"{session.cart.Qtty[i]} * item(s) {prod.Price / 100 * (100 - session.Buyer.Discount) * session.cart.Qtty[i]}UAH     {prod.ProductName}\n";
                i++;
            }
            win.TotalPriceAllProd.Content = totalPriceAll;
            win.ProductsInCart.Content = totalAmountAll;
            win.InCart.Content = inCart;
        }
        else        {
            win.TotalPriceAllProd.Content = 0;
            win.ProductsInCart.Content = 0;
            win.InCart.Content = "Empty";
        }
        win.ProductNameTxt.Text = this.ProductName;
        win.DescriptionTxt.Text = this.Description;
        win.PriceTxt.Text = this.Price.ToString();
        win.QttyTxt.Text = this.Quantity.ToString();
    }
}
