using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Homework13;
//buyers(personal information)
internal class Buyers: IShowable
{
    int _id;
    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get; set; }
    public int Discount { get; set; }
    public List<Receipts> BuyerRecipts = new List<Receipts>();

    public void Show(Homework13.MainWindow win, Session session)
    {
        win.BuyerName.Content = this.Name;
        win.Discount.Content = this.Discount.ToString() + "%";
    }
}
