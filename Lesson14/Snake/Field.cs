using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake;

internal class Field
{
    public (int,int) Size { get; set; }
    int [,] Map;// ObjType
    public void AddObj(int objType) { }
    public string this[int index]
    {
        get
        {
            return index switch
            {
                0 => ">>",
                1 => "<<",
                2 => ":)",
                3 => ":(",
                4 => "::",
                5 => "()",
                _ => "  "

            };
        }
    }
    public void Show() 
    {
        StringBuilder map = new StringBuilder();
        for(int i = 0;i <= Size.Item1;i++) map.Append("--");
        map.Append("\n");
        for (int y = 0; y < Size.Item2; y++)
        {
            map.Append("|");
            for (int x = 0; x < Size.Item1; x++)
            {
                map.Append(this[Map[x, y]]); 
            }
            map.Append("|\n");
        }
        for (int i = 0; i <= Size.Item1; i++) map.Append("--");
        Console.Clear();
        Console.WriteLine(map.ToString());
    }
    public void GenerateField()
    {
        //TheSnake MySnake = new TheSnake(5);
        Map = new int[Size.Item1, Size.Item2]; 
        for(int x = 0;x<Size.Item1;x++)
        {
            for(int y = 0; y < Size.Item2; y++)
            {
                if (Map[x,y] == 0) { var rnd = new Random(); Map[x, y] = rnd.Next((Size.Item1 * Size.Item1) /2); }
            }
        }
    }
    public void InterAct(TheSnake snake)
    {
        for(int i = 0;i< snake.Body.Count;i++)
        {
            if (Map[snake.Body[0].Item1, snake.Body[0].Item1] != 0)
            {
                //Check type and impact the snake
                //If not GameOver add snake body to map
            }
        }
    }
}
