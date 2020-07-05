using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TartlesRun
{
    public class Animate
    {
        private Image[] texture = { Resource1.red_forward,
                            Resource1.blue_forward,
                            Resource1.yellow_forward,
                            Resource1.green_forward,
                            Resource1.purple_forward,
                            Resource1.rainbow_forward,
                            Resource1.red_dobleforward,
                            Resource1.blue_dobleforward,
                            Resource1.yellow_dobleforward,
                            Resource1.green_dobleforward,
                            Resource1.purple_dobleforward,
                            Resource1.red_back,
                            Resource1.blue_back,
                            Resource1.yellow_back,
                            Resource1.green_back,
                            Resource1.purple_back,
                            Resource1.rainbow_back,
                            Resource1.last_forward,
                            Resource1.last_doubleforward
        };

        Desk Desk = new Desk();

        public Image CardSkin(int Indx)
        {
            return texture[Indx];
        }

        public void SetPlayerColor(Label Label)
        {
            switch (Desk.PlayerColor)
            {
                case 1: Label.BackColor = Color.Red; break;
                case 2: Label.BackColor = Color.Blue; break;
                case 3: Label.BackColor = Color.Yellow; break;
                case 4: Label.BackColor = Color.Green; break;
                case 5: Label.BackColor = Color.Purple; break;
            }
        }

        public bool WinDetect(List<Bot> Bots)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Bot Bot in Bots)
                    if (Desk.Progress[10, i] == Bot.BotColor)
                    {
                        string s = "";
                        switch (Bot.BotColor)
                        {
                            case 1: s = "Red"; break;
                            case 2: s = "Blue"; break;
                            case 3: s = "Yellow"; break;
                            case 4: s = "Green"; break;
                            case 5: s = "Purple"; break;
                        }
                        MessageBox.Show(s + " Turtle WIN");
                        return true;
                    }
                if (Desk.Progress[10, i] == Desk.PlayerColor)
                {
                    MessageBox.Show("YOU WIN");
                    return true;
                }
            }
            return false;
        }

        public void StartGame(List<Button> CardButtons)
        {
            Desk.Refresh();
            Desk.SetPlayerColor();
            foreach (Button button in CardButtons)
            {
                AddCard(button);
            }
            Desk.Progress = new int[11, 5];
            for (int i = 1; i < 6; i++)
                Desk.Progress[0, i - 1] = i;
        }

        public void AddCard(Button button)
        {
            int k = Desk.UpperCard();
            button.Image = texture[k];
            button.Tag = k;
        }

        public void YourTurn(int CardIndx)
        {
            switch (CardIndx)
            {
                case 0: Desk.NextTurtlePos(1, 1); break;
                case 1: Desk.NextTurtlePos(1, 2); break;
                case 2: Desk.NextTurtlePos(1, 3); break;
                case 3: Desk.NextTurtlePos(1, 4); break;
                case 4: Desk.NextTurtlePos(1, 5); break;
                case 5: Desk.NextTurtlePos(1, VoteTurtle(CardIndx)); break;
                case 6: Desk.NextTurtlePos(2, 1); break;
                case 7: Desk.NextTurtlePos(2, 2); break;
                case 8: Desk.NextTurtlePos(2, 3); break;
                case 9: Desk.NextTurtlePos(2, 4); break;
                case 10: Desk.NextTurtlePos(2, 5); break;
                case 11: Desk.NextTurtlePos(-1, 1); break; //-1,n
                case 12: Desk.NextTurtlePos(-1, 2); break;
                case 13: Desk.NextTurtlePos(-1, 3); break;
                case 14: Desk.NextTurtlePos(-1, 4); break;
                case 15: Desk.NextTurtlePos(-1, 5); break;
                case 16: Desk.NextTurtlePos(-1, VoteTurtle(CardIndx)); break;
                case 17: Desk.NextTurtlePos(1, VoteTurtle(CardIndx)); break;
                case 18: Desk.NextTurtlePos(2, VoteTurtle(CardIndx)); break;
            }
        }

        private int VoteTurtle(int CardIndx)
        {
            while (true)
            {
                Form3 ChoseTurtleForm = new Form3();
                if ((CardIndx == 17) || (CardIndx == 18))
                    for (int i = 10; i > Desk.LastTurtlePos(); i--)
                    {
                        int j = 0;
                        while ((j != 5) && (Desk.Progress[i, j] != 0))
                        {
                            ChoseCardOff(ChoseTurtleForm.Controls.Find("button" + Desk.Progress[i, j].ToString(), true).FirstOrDefault() as Button);
                            j++;
                        }
                    }
                if (CardIndx == 16)
                    for (int i = 0; i < 5; i++)
                        if (Desk.Progress[0, i] != 0)
                            ChoseCardOff(ChoseTurtleForm.Controls.Find("button" + Desk.Progress[0, i].ToString(), true).FirstOrDefault() as Button);
                if ((CardIndx == 5) || (CardIndx == 16))
                    for (int i = 0; i < 5 && Desk.Progress[10, i] != 0; i++)
                        ChoseCardOff(ChoseTurtleForm.Controls.Find("button" + Desk.Progress[10, i].ToString(), true).FirstOrDefault() as Button);
                string k = ChoseTurtleForm.ShowDialog().ToString();
                switch (k)
                {
                    case "OK": return 1;
                    case "Yes": return 2;
                    case "Abort": return 3;
                    case "Retry": return 4;
                    case "Ignore": return 5;
                }
                MessageBox.Show("You must chose Turtle's color");
            }
            return 0;
        }

        private void ChoseCardOff(Button btn)
        {
            btn.BackColor = Color.FromArgb(64, 64, 64);
            btn.Cursor = Cursors.Default;
            btn.DialogResult = DialogResult.None;
        }

        public void Reload(List<Button> buttons) //обновляет тексуры поля
        {
            foreach (Button b in buttons)
            {
                int k = Desk.Progress[(Convert.ToInt32(b.Tag) + 5) / 5, Convert.ToInt32(b.Tag) % 5];
                if (k == 0) { b.Visible = false; }
                else
                {
                    b.Visible = true;
                    switch (k)
                    {
                        case 1: b.BackColor = Color.Red; break;
                        case 2: b.BackColor = Color.Blue; break;
                        case 3: b.BackColor = Color.Yellow; break;
                        case 4: b.BackColor = Color.Green; break;
                        case 5: b.BackColor = Color.Purple; break;
                    }
                }
            }
        }
    }
}
