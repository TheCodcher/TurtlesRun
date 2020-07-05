using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TartlesRun
{
    public class Bot
    {
        public int BotColor = 0;
        public int LastPlayedCard = 0;
        Desk Desk = new Desk();
        private int[] Hand = new int[5];

        public void SetBotColor(List<Bot> Bots)
        {
            int[] BookedColor = new int[5];
            BookedColor[0] = Desk.PlayerColor;
            int i = 0;
            foreach (Bot Bot in Bots)
            {
                i++;
                int x = new Random((int)Math.Pow((int)DateTime.Now.Ticks, i)).Next(1, 5);
                bool b = true;
                while (b)
                {
                    for (int j = 0; BookedColor[j] != 0; j++)
                        if (BookedColor[j] == x)
                        {
                            if (x == 5) { x = 1; } else x++;
                            break;
                        }
                        else b = false;
                }
                Bot.BotColor = x;
                BookedColor[i] = x;
            }
        }

        public void AddCard(int TabCardIndx)
        {
            Hand[TabCardIndx] = Desk.UpperCard();
        }

        public void Turn()
        {
            int k = -51; int indx = 0; int tabx = 0; //indx - индекс самой выгодной карты. tabx - порядковый номер карты в руке
            for (int i = 0; i<5; i++)
            {
                int _k = -51;
                int _indx = Hand[i];
                switch (Hand[i])
                {
                    case 0: _k = ValidTurn(1, 1); break;
                    case 1: _k = ValidTurn(1, 2); break;
                    case 2: _k = ValidTurn(1, 3); break;
                    case 3: _k = ValidTurn(1, 4); break;
                    case 4: _k = ValidTurn(1, 5); break;
                    case 5:
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                int __k = ValidTurn(1, j);
                                if (__k > _k) { _k = __k; _indx = j - 1; };
                            }
                        }; break;
                    case 6: _k = ValidTurn(2, 1); break;
                    case 7: _k = ValidTurn(2, 2); break;
                    case 8: _k = ValidTurn(2, 3); break;
                    case 9: _k = ValidTurn(2, 4); break;
                    case 10: _k = ValidTurn(2, 5); break;
                    case 11: _k = ValidTurn(-1, 1); break;
                    case 12: _k = ValidTurn(-1, 2); break;
                    case 13: _k = ValidTurn(-1, 3); break;
                    case 14: _k = ValidTurn(-1, 4); break;
                    case 15: _k = ValidTurn(-1, 5); break;
                    case 16:
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                int __k = ValidTurn(1, j);
                                if (__k > _k) { _k = __k; _indx = j + 10; }; 
                            }
                        }; break;
                    case 17:
                        {
                            int l = Desk.LastTurtlePos();
                            for (int j = 0; j < 5; j++)
                            {
                                int __k = -51;
                                if (Desk.Progress[l, j] != 0)
                                    __k = ValidTurn(1,Desk.Progress[l, j]);
                                if (__k > _k) { _k = __k; _indx = j; };
                            }
                        }; break;
                    case 18:
                        {
                            int l = Desk.LastTurtlePos();
                            for (int j = 0; j < 5; j++)
                            {
                                int __k = -51;
                                if (Desk.Progress[l, j] != 0)
                                    __k = ValidTurn(2, Desk.Progress[l, j]);
                                if (__k > _k) { _k = __k; _indx = j + 6; }; 
                            }
                        }; break;
                }
                if (_k > k) { k = _k; tabx = i; indx = _indx; };
            }
            Animate Am = new Animate();
            Am.YourTurn(indx);
            LastPlayedCard = Hand[tabx];
            AddCard(tabx);
        }

        private int ValidTurn(int Power,int TurtleIndx)
        {
            int[,] P = (int[,])Desk.Progress.Clone();
            NTPos(Power,TurtleIndx,P);
            int ps = FTPos(BotColor, P); //позиция бота
            if (ps < 5) ps = 0; else ps = ps + 5 - 2 * (ps % 5);
            int pp = FTPos(Desk.PlayerColor, P); //позиция игрока
            if (pp < 5) pp = 0;
            int k = ps - pp;
            return k;
        }

        private void NTPos(int Power, int TurtleIndx, int[,] Progress) //выполняет ход черепахи на поле
        {
            int i = 0;
            int ftp = FTPos(TurtleIndx, Progress);
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

        private int FTPos(int TurtleIndx, int[,] Progress) //возвращает индекс позиции
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
    }
}
