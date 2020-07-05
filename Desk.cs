using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TartlesRun
{
    public class Desk
    {
        public static int PlayerColor; //выбирает цвет черепахи игрока
        private static int ValueCard = -1; //нынешняя верхняя карта
        private static int[] Deck = new int[52]; //колода
        public static int[,] Progress = new int[11, 5]; //10 - кол-во полей. 5 - высота черепахи. индекс - цвет черепахи

        public void Refresh() //задает новую колоду
        {
            int[] ClassCard = new int[] { 5, 5, 5, 5, 5, 5, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 2 };
            int psx = (int)DateTime.Now.Ticks;
            int f = 1;
            for (int i = 0; i < 52; i++)
            {
                Deck[i] = new Random(psx).Next(0, 18);
                if (Deck[i] > 5)
                {
                    if (f == 1)
                    {
                        Deck[i] = new Random(psx).Next(6, 18);
                    }
                    else
                    {
                        Deck[i] = new Random(psx).Next(0, 6);
                    }
                    f *= -1;
                }
                while (ClassCard[Deck[i]] == 0)
                {
                    if (Deck[i] == 18) { Deck[i] = 0; } else Deck[i]++;
                }
                psx = (int)DateTime.Now.Ticks + psx - Deck[i] * 123;
                ClassCard[Deck[i]]--;
            }
            ValueCard = -1;
        }

        public void SetPlayerColor()
        {
            PlayerColor = new Random((int)DateTime.Now.Ticks * (int)DateTime.Now.Ticks).Next(1, 5);
        }

        public int UpperCard() //возвращает индекс верхней карты колоды
        {
            ValueCard++;
            if (ValueCard == 52) { Refresh(); ValueCard = 0; };
            return Deck[ValueCard];
        }

        public void NextTurtlePos(int Power, int TurtleIndx) //выполняет ход черепахи на поле
        {
            int i = 0;
            int ftp = FoundTurtlePos(TurtleIndx);
            if ((ftp > 44) && (Power == 2)) Power = 1;
            int x = ftp / 5 + Power;
            int y = ftp % 5;
            if (((Power < 0) && (ftp < 5)) || (ftp > 49)) return;
            if (x == 0)
            {
                int j = y;
                while ((j != 5) && (Progress[ftp / 5, j] != 0))
                {
                    Progress[0, Progress[ftp / 5, j] - 1] = Progress[ftp / 5, j];
                    Progress[ftp / 5, j] = 0;
                    j++;
                }
                return;
            }
            while (Progress[x, i] != 0) i++;
            if (ftp < 5)
            {
                Progress[x, i] = Progress[ftp / 5, y];
                Progress[ftp / 5, y] = 0;
            }
            else
            {
                int j = y;
                while ((j != 5) && (Progress[ftp / 5, j] != 0))
                {
                    Progress[x, i] = Progress[ftp / 5, j];
                    Progress[ftp / 5, j] = 0;
                    i++; j++;
                }
            }
        }

        public int FoundTurtlePos(int TurtleIndx) //возвращает индекс позиции
        {
            int Pos = 0;
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (Progress[i, j] == TurtleIndx)
                    {
                        Pos = i * 5 + j; return Pos;
                    }
                }
            return Pos;
        }

        public int LastTurtlePos() //возвращает индекс столбца с последними черепахами(черепахой)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Progress[0, i] != 0) return 0;
            }
            int x = 1;
            while (Progress[x, 0] == 0) x++;
            return x;
        }
    }
}
