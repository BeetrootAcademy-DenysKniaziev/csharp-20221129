using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Obj
    {
        public int ObjType;
        public Obj(int objType) { ObjType = objType; }
        public static void TypeClarifing(TheSnake snake, int objType)
        {
            switch (objType)
            {
                case 6: snake.speedDelay = (snake.speedDelay / 3) * 2; break;
                case 1: snake.speedDelay = (int)(snake.speedDelay * 1.33); break;
                case 2: snake.Skin = -4; break;
                case 3: snake.Skin = -3; break;
                case 4: if (snake.Body.Count > 5) snake.Body.RemoveRange(snake.Body.Count - 2, 1); break;
                case 5: snake.Body.Add(snake.LastBody); break;
            }
        }
        public static void NewItemAdding(TheSnake snake, int objType)
        {
            while (true)
            {
                var rnd = new Random();
                var obj = rnd.Next(7);
                var x = rnd.Next(Program.MainField.Size.Item1);
                var y = rnd.Next(Program.MainField.Size.Item2);
                if (Program.MainField.Map[x, y] == 0)
                {
                    Program.MainField.Map[x, y] = obj;
                    break;
                }
            }
        }
        public static void ScoreCounting(TheSnake snake, int objType)
        {
            decimal multiplaier = 1;
            if (snake.Skin == -3) multiplaier = 0.5M;
            if (snake.Skin == -4) multiplaier = 2M;
            if (objType == 5 ) snake.ScorePoints += (int)(100 * multiplaier);
            if (objType == 4) snake.ScorePoints += (int)(-50 * multiplaier);
            if (objType == 6) snake.ScorePoints += (int)(200 * multiplaier);
            if (objType == 1) snake.ScorePoints += (int)(50 * multiplaier);
            if (objType == 2) snake.ScorePoints += (int)(10 * multiplaier);
            if (objType == 3) snake.ScorePoints += (int)(30 * multiplaier);
        }

    }
}
