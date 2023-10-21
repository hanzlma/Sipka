using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekt___Sipka;
namespace Ukazka___Sipka
{
    public partial class Form1 : Form
    {
        Random rand;
        Sipka[] sipky = new Sipka[10];
        public Form1()
        {
            VytvorSipky();
            InitializeComponent();
            timer1.Start();
        }
        void VytvorSipky()
        {
            rand = new Random();
            for(int i = 0; i < sipky.Length; i++)
            {
                int x = rand.Next(40, 150);
                sipky[i] = new Sipka
                {
                    Parent = this,
                    Size = new Size(x,x),
                    Location = new Point(rand.Next(0, this.Width - Width), rand.Next(0, this.Height - Height)),
                    
                };
                sipky[i].Naraz += Sipky_Naraz;
                System.Threading.Thread.Sleep(1);
            }
        }

        private void Sipky_Naraz(object sender, EventArgs e)
        {
            Sipka sipka = sender as Sipka;
            rand = new Random();
            int puvodniSmer = (int)sipka.Smer;
            int novySmer;
            do
            {
                novySmer = rand.Next(1, 5);
            } while (novySmer == puvodniSmer);
            sipka.Smer = (Smer)novySmer;
            sipka.Location = new Point(rand.Next(0, this.Width - sipka.Width), rand.Next(0, this.Height - sipka.Height));
            sipka.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Sipka sipka in sipky)
            {
                sipka.Pohyb();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Spustit";
            }
            else
            {
                timer1.Start();
                button1.Text = "Zastavit";
            }
        }
    }
}
