using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class TheSnake
    {
        //public delegate void GameOverHandler();
        //public event GameOverHandler GameOver;

        int _skin = -1;
        int Lifes = 3;
        public int speedDelay = 150;
        public (int, int) LastBody { get; set; }
        public (int,int) Direction { get; set; }
        public int ScorePoints { get; set; }
        public int Skin{ get { return _skin; } set {_skin = value; } }
        public enum Ability { speed, destroy, cuttail, raundcollect, leavestones, stone }
        public List<(int, int)> Body;
        public TheSnake(int initialSize, Field field)
        {
            int startX, startY;
            startX = ((int)field.Size.Item1 / 2);
            startY = ((int)field.Size.Item2 / 2);
            Body = new List<(int, int)>() { (startX, startY), (startX+1, startY), (startX+2, startY), (startX+3, startY), (startX+4, startY) };
        }
        public (int, int)  Go((int,int) direction)
        {
            return (this.Body[0].Item1 + direction.Item1, this.Body[0].Item2 + direction.Item2);
        }

        public void MoveBody()
        {
            Program.MainField.Map[Body[Body.Count - 1].Item1, Body[Body.Count - 1].Item2] = 0;
            (int, int) temp1 = Body[0];
            for (int i = 1; i < Body.Count; i++) 
            {
                LastBody = Body[i];
                Body[i] = temp1;
                temp1 = LastBody;
            }
            Body[0] = Go(this.Direction);
        }

        public void InterAct()
        {
            var snake = this;

            var newHeadPosition = Go(this.Direction);
            for(int i = 1; i<Body.Count;i++)
            {
                if (newHeadPosition == Body[i]) 
                {
                    Program.OnGameOver();
                }
            }
            try
            {
                if (Program.MainField.Map[newHeadPosition.Item1, newHeadPosition.Item2] != 0)
                {
                    Program.OnEatingObjects(this, Program.MainField.Map[newHeadPosition.Item1, newHeadPosition.Item2]);
                }
                else PutSnakeOnField(snake);
            }
            catch(Exception Ex)
            {
                Program.OnGameOver();
            }
            DrawToConsole.ShowField(Program.MainField);
            DrawToConsole.ShowScoreEtc(snake, 0);
            //Console.WriteLine("Drawed");
        }

        public void PutSnakeOnField(TheSnake snake)
        {
            Program.MainField.Map[snake.Body[0].Item1, snake.Body[0].Item2] = -2;
            for (int i = 1; i < snake.Body.Count; i++)
            {
                Program.MainField.Map[snake.Body[i].Item1, snake.Body[i].Item2] = Skin;
            }
        }
        public void SnakeControl()
        {
            var k = Console.ReadKey();
            var currentDirection = Direction;
            if (k.Key == ConsoleKey.W) Direction = (0, -1);
            if (k.Key == ConsoleKey.D) Direction = (1, 0);
            if (k.Key == ConsoleKey.X) Direction = (0, 1);
            if (k.Key == ConsoleKey.A) Direction = (-1, 0);

            if (k.Key == ConsoleKey.Q) Direction = (-1, -1);
            if (k.Key == ConsoleKey.E) Direction = (1, -1);
            if (k.Key == ConsoleKey.C) Direction = (1, 1);
            if (k.Key == ConsoleKey.Z) Direction = (-1, 1);
            if (Direction.Item1*-1 == currentDirection.Item1 && Direction.Item2*-1 == currentDirection.Item2) Direction = currentDirection;

        }


    }
}
