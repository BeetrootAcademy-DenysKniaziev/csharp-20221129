using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Homework13;
//receipts(what was sold and to whom)
interface ICreatable{
    Receipts Create(TheCart cart);
}
//interface ICancelable{
//    void Cancel(Buyers buyer, List<Products> products);
//}
internal class Receipts : ICreatable//, ICancelable 
{
    int _receiptN;
    public int ReceiptN { get { return _receiptN; } set { _receiptN = value; } }
    public List<Products> Prod = new();
    public Buyers Buyer { get; set; }
    public Receipts Create(TheCart cart)
    {
        this.Buyer = cart.Buyer;
        foreach(var cpr in cart.ProductsInCart)  {
            Products tempProd = cpr;
            tempProd.Quantity = cpr.Quantity;
            //tempProd.Sale(cpr.Quantity);
            Prod.Add(tempProd);
            //Shops.products[Shops.products.IndexOf(cpr)].Quantity -=

        }

        var data = new string[cart.ProductsInCart.Count];
        for (int i = 0; i < cart.ProductsInCart.Count; i++)
        {
            var record = cart.ProductsInCart[i];
            data[i] = $"{record.Id}|" +
            $"{record.ProductName}|" +
            $"{cart.Qtty[i]}|" +
            $"{record.Price / 100 * (100 - this.Buyer.Discount) * cart.Qtty[i]}|" +
            $"{this.Buyer.Name}|" +
            $"{this.Buyer.Discount}";
        }

        string s = this.Buyer.Name;
        var output = Regex.Replace(s, "[^A-Za-z]+", string.Empty);
        string FileName = output.Substring(0,16) + "_" + DateTime.Now.Ticks.ToString()+".txt";
        MessageBox.Show("New reciept was saved to file: " + FileName);
        File.WriteAllLines(FileName, data);

        //this.Prod.Add(product.Sale(product.Quantity));
        return this;
    }

}
