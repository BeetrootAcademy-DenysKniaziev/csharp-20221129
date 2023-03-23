using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework14;

internal class Picture
{
    const int sprite = 3;

    public Point[,] Points;
    public Bitmap Img;
    public int[,] LevelMask;
    public string ConsolPic;

    public void LoadBitmap(string fileName)
    {
        Img = new Bitmap(fileName);  //fileName);
        Points = new Point[Img.Width + 1, Img.Height + 1];
        for (int x = 1; x < Img.Width; x++)
        {
            for (int y = 1; y < Img.Height; y++)
            {
                Points[x, y].X = x;
                Points[x, y].Y = y;
                Points[x, y].PColor = Img.GetPixel(x, y);
            }
        }

        for (int x = 2; x < Img.Width-1; x++)
        {
            for (int y = 2; y < Img.Height-1; y++)
            {
                LookAround(ref Points[x, y]);
            }
        }

    }

    public void LookAround(ref Point p)
    {
        (int, int)[] neighbor = new (int, int)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
        foreach ((int, int) i in neighbor)
        {
            if (p != Points[p.X + i.Item1, p.Y + i.Item2]) p.Level++;
        }

    }

    public override string ToString()
    {
        int maxLevel = 0;
        int xMaskSize = Img.Width / sprite + 1;
        int yMaskSize = Img.Height / sprite + 1;

        LevelMask = new int[xMaskSize, yMaskSize];
        ConsolPic = "";// new string[yMaskSize];
        for (int x = 1; x < Img.Width; x++)
        {
            for (int y = 1; y < Img.Height; y++)
            {
                LevelMask[(int)x / sprite, (int)y / sprite] += Points[x, y].Level;
                if (LevelMask[(int)x / sprite, (int)y / sprite] > maxLevel) maxLevel = LevelMask[(int)x / sprite, (int)y / sprite];
            }
        }


        for (int cY = 0; cY < yMaskSize; cY++)
        {
            for (int cX = 0; cX < xMaskSize; cX++)
            {
                if (LevelMask[cX, cY] >= maxLevel / 1.33) ConsolPic += "@@";
                else if (LevelMask[cX, cY] >= maxLevel / 2) ConsolPic += "ll";
                else if (LevelMask[cX, cY] >= maxLevel / 4) ConsolPic += "::";
                else ConsolPic += " ";
            }
            ConsolPic += "\n";
        }
        return ConsolPic;

    }

}


