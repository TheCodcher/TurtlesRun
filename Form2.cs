using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TartlesRun
{
    public partial class Form2 : Form
    {
        Animate Animate = new Animate();
        List<Button> GameField = new List<Button>();
        List<Bot> Bots = new List<Bot>();
        List<Button> PlayerButtons;

        public Form2()
        {
            InitializeComponent();
            PlayerButtons = new List<Button> { button1, button2, button3, button4, button5 };
            Animate.StartGame(PlayerButtons);
            Animate.SetPlayerColor(label1);
            for (int i = 6; i < 56; i++)
            {
                GameField.Add(Controls.Find("button" + i.ToString(),true).FirstOrDefault() as Button);
            }
            Form4 f = new Form4();
            string k = f.ShowDialog().ToString();
            int n = 0;
            switch (k)
            {
                case "OK": n = 1; break;
                case "Cancel": n = 0; break;
                case "Abort": n = 2; break;
                case "Retry": n = 3; break;
            };
            for (int i = 0; i < n + 1; i++) Bots.Add(new Bot());
            foreach (Bot Bot in Bots)
            {
                Bot.SetBotColor(Bots);
                for (int i = 0; i < 5; i++) Bot.AddCard(i);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            foreach (Button b in PlayerButtons)
            {
                b.Enabled = false;
            }
            Animate.YourTurn((int)((Button)sender).Tag);
            graveyard.Image = Animate.CardSkin((int)((Button)sender).Tag);
            Animate.AddCard((Button)sender);
            Animate.Reload(GameField);
            if (Animate.WinDetect(Bots)) Close();
            foreach (Bot Bot in Bots)
            {
                Update();
                System.Threading.Thread.Sleep(600);
                Bot.Turn();
                graveyard.Image = Animate.CardSkin(Bot.LastPlayedCard);
                Animate.Reload(GameField);
                if (Animate.WinDetect(Bots)) { Close(); return; };
            }
            foreach (Button b in PlayerButtons)
            {
                b.Enabled = true;
            }
        }

        private void turtles_Click(object sender, EventArgs e)
        {

        }
    }
}
