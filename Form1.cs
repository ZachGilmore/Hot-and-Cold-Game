using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hot_and_Cold_Game
{
    public partial class Form1 : Form
    {
        int rng = new Random().Next(1000);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rngDisplay.Text = Convert.ToString(rng);    //For debugging; displays random number
     
        }
        private void guess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int condition = Convert.ToInt32(guess.Text);     //Convert textbox into int for if/else statements
                string randNum = Convert.ToString(rng);         //Convert random number to string

                //Math vars
                int lowChilly = rng - 100, highChilly = rng + 100;
                int lowWarm = rng - 50, highWarm = rng + 50;
                int lowWarmer = rng - 25, highWarmer = rng + 25;
                int lowHot = rng - 10, highHot = rng + 10;


                //Error handling conditionals
                if (condition < 1 || condition > 1000) //Checks if data is out of range
                {
                    BackColor = Color.MediumPurple;
                    ForeColor = Color.White;
                    prompt.Text = "You are out of range.";
                }
                //Correct conditional
                else if (guess.Text == randNum)  //Change to green if guess is correct
                {
                    prompt.Text = "Congratulations! You win!!";
                    BackColor = Color.Green;
                    ForeColor = Color.White;
                    guess.Enabled = false;
                }
                //Cold Conditionals
                else if (condition > highChilly)    //If guess is over 100
                {
                    prompt.Text = "Way too high! You're freezing cold!!";
                    BackColor = Color.Blue;
                    ForeColor = Color.White;

                }
                else if (condition < lowChilly) //If guess is under 100
                {
                    prompt.Text = "Way too low! You're freezing cold!!";
                    BackColor = Color.Blue;
                    ForeColor = Color.White;
                }
                else if (condition >= lowChilly && condition <= lowWarm) //if guess is within 100 on the low end
                {
                    prompt.Text = "Too low. You're chilly.";
                    BackColor = Color.LightBlue;
                    ForeColor = Color.Black;
                }
                else if (condition <= highChilly && condition >= highWarm)   //if guess is within 100 on the high end
                {
                    prompt.Text = "Too high. You're chilly.";
                    BackColor = Color.LightBlue;
                    ForeColor = Color.Black;
                }
                //Hot Conditionals
                else if (condition >= lowWarm && condition <= lowWarmer)    //If guess is within 50 on the low end
                {
                    prompt.Text = "A little low. You're getting warmer...";
                    BackColor = Color.LightPink;
                    ForeColor = Color.Black;
                }
                else if (condition >= lowWarmer && condition <= lowHot) //within 25 on the low end
                {
                    prompt.Text = "Still low, but its getting pretty toasty in here...";
                    BackColor = Color.IndianRed;
                    ForeColor = Color.White;
                }
                else if (condition >= lowHot && condition <= rng)   //within 10 on the low end
                {
                    prompt.Text = "You're so close! Go up a few!!";
                    BackColor = Color.Red;
                    ForeColor = Color.White;
                }
                else if (condition <= highWarm && condition >= highWarmer)  //Within 50 on the high end
                {
                    prompt.Text = "A little high. You're getting warmer...";
                    BackColor = Color.LightPink;
                    ForeColor = Color.Black;
                }
                else if (condition <= highWarmer && condition >= highHot) //within 25 on the high end
                {
                    prompt.Text = "Still high, but its getting pretty toasty in here...";
                    BackColor = Color.IndianRed;
                    ForeColor = Color.White;
                }
                else if (condition <= highHot && condition >= rng)   //within 10 on the low end
                {
                    prompt.Text = "You're close! Go down a few!!";
                    BackColor = Color.Red;
                    ForeColor = Color.White;
                }
                //else if (condition == empty)  //Another attempt at data validation
                //{
                //    prompt.Text = "Make a guess!";
                //    BackColor = Color.Bisque;
                //}
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                prompt.Text = "Make a guess!";
                BackColor = Color.MediumPurple;
                ForeColor = Color.White;
            }


        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
