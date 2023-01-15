using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class TheSnake
    {
        public int CurrentDirection { get; set; }
        public int ScorePoints { get; set; }
        public enum Ability { speed, destroy, cuttail, raundcollect, leavestones, stone }
        public List<(int, int)> Body;
        public TheSnake(int initialSize)
        {
            Body = new List<(int, int)>();
        }

    }
}
