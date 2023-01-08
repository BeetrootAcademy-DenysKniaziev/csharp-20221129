using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework13;

internal class TheCart
{
    public Buyers Buyer { get; set; }
    public List<Products> ProductsInCart = new List<Products>();
    public List<int> Qtty = new List<int>();
    public void AddToCart(Products prod, int qtty)    {

        if (prod.Quantity - qtty >= 0)//Qtty[ProductsInCart.IndexOf(prod)])
        {
            prod.Quantity -= qtty;
            if (ProductsInCart.Contains(prod)) Qtty[ProductsInCart.IndexOf(prod)] += qtty;
            else
            {
                ProductsInCart.Add(prod);
                Qtty.Add(qtty);
            }
        }
        else        {
            qtty = prod.Quantity;
            AddToCart(prod, qtty);
        }
    }
    public void ReturnFromCart(Products prod)    {

        if (ProductsInCart.Contains(prod))//Qtty[ProductsInCart.IndexOf(prod)])
        {
            //Qtty[ProductsInCart.IndexOf(prod)] -= 1;
            //prod.Quantity += 1;
            prod.Quantity += Qtty[ProductsInCart.IndexOf(prod)];
            Qtty.RemoveAt(ProductsInCart.IndexOf(prod));
            ProductsInCart.Remove(prod);
        }
    }
    public void ChangeQtty(Products prod, int qtty)  {
        Qtty[ProductsInCart.IndexOf(prod)] = qtty;
    }
}