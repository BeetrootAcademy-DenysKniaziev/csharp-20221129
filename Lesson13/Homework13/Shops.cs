using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Homework13;

static internal class Shops
{
    public static int _lastProdID;
    public static int _lastBuyerID;
    public static List<Products> products = new();
    public static List<Buyers> buyers = new();
    public static List<Receipts> receipts = new();
    public static List<Session> sessions = new();

    public static void Sale(Session session)
    {
        //TheCart cart = session.cart;
        session.cart.Buyer = session.Buyer;
        //decimal totalSum = 0;
        //int i = 0;
        //foreach (var item in cart.ProductsInCart)
        //{
        //    var idx = products.IndexOf(item);
        //    if (products[idx].Quantity - session.cart.Qtty[i] >= 0)            {
        //        products[idx].Quantity -= session.cart.Qtty[i];
        //    }
        //    else { 
        //        cart.ProductsInCart.Remove(item); 
        //        cart.Qtty.RemoveAt(cart.ProductsInCart.IndexOf(item)); 
        //        MessageBox.Show($"Not enough {item.ProductName} in stock! This product removed from your cart"); 
        //    }
        //}
        Receipts rec = new Receipts();
        rec.Create(session.cart);
        session.cart.Qtty.Clear();
        session.cart.ProductsInCart.Clear();
    }

    public static void LoadProducts(string FileName)    {
        if (!File.Exists(FileName))        {
            try     {
                throw new System.IO.FileNotFoundException("Products: Wrong pass or file name exception");
            }
            catch (Exception Ex){ MessageBox.Show(Ex.ToString()); }
        }
        else        {
            try            {
                var data = File.ReadAllLines(FileName);
                int maxId = 0;
                for (int i = 0; i < data.Length; i++)                {
                    var splited = data[i].Split('|');
                    Products tempProd = new Products(splited[1]);
                    bool success = Int32.TryParse(splited[0], out int id);//0-id,1-prodname,2-Description,3-quantity,4-price,5-Img
                    if (success) { //if ID number excepteble int                   
                        if (maxId < id) maxId = id; 
                        tempProd.Id = id;
                        tempProd.Description = splited[2];
                        if(Int32.TryParse(splited[3], out int quentity)) tempProd.Quantity = quentity;
                        else tempProd.Quantity = 0;

                        if (Int32.TryParse(splited[4], out int price)) tempProd.Price = price;
                        else tempProd.Price = 0;
                        if (File.Exists(splited[5])) {
                            try      {
                                tempProd.ProdImg = splited[5];
                            }
                            catch (Exception ex) {
                                tempProd.ProdImg = "defoult.png";
                            }
                        }
                        else tempProd.ProdImg = "defoult.png";
                        products.Add(tempProd);
                    }
                }
                _lastProdID = maxId;
            }
            catch (Exception ex)            {
                MessageBox.Show(ex.Message);
            }

        }
    }
    
    public static void AddProduct(Products newProduct) {
        products.Add(newProduct);

        //var data = new string[products.Count];
        //for (int i = 0; i < products.Count; i++)
        //{
        //    var record = products[i];
        //    data[i] = $"{record.Id}|" +
        //    $"{record.ProductName}|" +
        //    $"{record.Description}|" +
        //    $"{record.Quantity}|" +
        //    $"{record.Price}|" +
        //    $"{record.ProdImg}";
        //}
        //File.WriteAllLines("Products.txt", data);
    }
    public static void RemoveProduct() { }


    public static void LoadBayers(string FileName) {
        if (!File.Exists(FileName))        {
            try            {
                throw new System.IO.FileNotFoundException("Buyers: Wrong pass or file name exception");
            }
            catch (Exception Ex) { MessageBox.Show(Ex.ToString()); }
        }
        else        {
            try            {
                var data = File.ReadAllLines(FileName);
                int maxId = 0;
                for (int i = 0; i < data.Length; i++)                {
                    var splited = data[i].Split('|');
                    Buyers tempBuyer = new Buyers();
                    bool success = Int32.TryParse(splited[0], out int id);//0-id,1-name,2-discount
                    if (success)                    { //if ID number excepteble int                   
                        if (maxId < id) maxId = id;
                        tempBuyer.Id = id;
                        tempBuyer.Name = splited[1];
                        if (Int32.TryParse(splited[2], out int discount)) tempBuyer.Discount = discount;
                        else tempBuyer.Discount = 0;
                        buyers.Add(tempBuyer);
                    }
                }
                _lastBuyerID = maxId;
            }
            catch (Exception ex)            {
                MessageBox.Show(ex.Message);
            }

        }
    }
    public static void AddBuyer(string name, string discont) {

        int d = 0;
        if (!string.IsNullOrEmpty(name))   {
            if (name.Length > 16) name = name.Substring(0, 16);
        }
        else name = "New User";
        if (!string.IsNullOrEmpty(discont))        {
            if (UInt32.TryParse(discont, out uint disc))            {
                if (disc > 100) disc = 100;
                else d = (int)disc;
            }
        }
        Buyers tempBuyer = new Buyers();
        _lastBuyerID++;
        tempBuyer.Id = _lastBuyerID;
        tempBuyer.Name = name;
        tempBuyer.Discount = d;
        buyers.Add(tempBuyer);

        var data = new string[buyers.Count];
        for (int i = 0; i < buyers.Count; i++)  {
            var record = buyers[i];
            data[i] = $"{record.Id}|" +
            $"{record.Name}|" +
            $"{record.Discount}|";
        }
        File.WriteAllLines("Buyers.txt", data);
        MessageBox.Show($"User {name} was add to Buyers.txt");
    }
    public static void RemoveBuyer() { }
}
