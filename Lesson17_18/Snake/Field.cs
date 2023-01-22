using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake;

internal class Field
{
    public (int,int) Size { get; set; }
    public int [,] Map;// ObjType
    public void AddObj(int objType) { }
    public string this[int index]
    {
        get
        {
            return index switch
            {
                -4 => "()",
                -3 => "`.",
                -2 => "@@",
                -1 => "::",
                0 => "  ",
                1 => "<<",
                2 => ":)",
                3 => ":(",
                4 => "--",
                5 => "()",
                6 => ">>",
                _ => "  "

            };
        }
    }

    public void GenerateField()
    {
        //TheSnake MySnake = new TheSnake(5);
        Map = new int[Size.Item1, Size.Item2]; 
        for(int x = 0;x<Size.Item1-1;x++)
        {
            for(int y = 0; y < Size.Item2-1; y++)
            {
                if (Map[x,y] == 0) { var rnd = new Random(); Map[x, y] = rnd.Next((Size.Item1 * Size.Item2) /5); }
                if (Map[x, y] > 6) Map[x, y] = 0;
            }
        }
    }
    
}
