using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RockPaperScissorsGame
{
    public partial class Form1 : Form
    {
        // define possible turns
        private enum PlayerTurn {Player1, Player2 };
        // assign game start state
        private PlayerTurn playerTurn = PlayerTurn.Player1;
        
        // define winning states
        private const string TIE = "Tie";
        private const string PLAYER1_WIN = "Player 1 wins";
        private const string PLAYER2_WIN = "Player 2 wins";
        // define picks
        private Image player1Pick;
        private Image player2Pick;
        
        private List<Image> images = new List<Image>();

        public Form1()
        {
            InitializeComponent();
            LoadImages();
        }

        private void LoadImages ()
        {
            images.Add((Image)Resources.paper); //0
            images.Add((Image)Resources.rock);  //1
            images.Add((Image)Resources.scissors); //2
        }

        private void OnClick(object sender, EventArgs e)
        {
            PictureBox picClicked = sender as PictureBox;
            Random randam = new Random();
            int index = randam.Next(0, 200) % 3;

            picClicked.Image = images[index];

            Debug.WriteLine(picClicked.Name);
            if(playerTurn== PlayerTurn.Player1)
            {
                player1Pick = images[index];
            }
            else
            {
                player2Pick = images[index];
                showinner();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newGame();
        }
        private void showinner()
        {
            int rock = 0;
            int paper = 1;
            int scissor = 2;

            if(player1Pick==images[rock])
            {
                if(player2Pick==images[rock])
                {
                    groupBox1.Text = "Draw";
                }
               else if (player2Pick == images[paper])
                {
                    groupBox1.Text = "Player 2 Win";
                }
               else if (player2Pick == images[scissor])
                {
                    groupBox1.Text = "Player 1 Win";
                }
            }
          else  if (player1Pick == images[paper])
            {
                if (player2Pick == images[rock])
                {
                    groupBox1.Text = "Player 1 win";
                }
                else if (player2Pick == images[paper])
                {
                    groupBox1.Text = "Draw";
                }
                else if (player2Pick == images[scissor])
                {
                    groupBox1.Text = "Player 2 win";
                }
            }
           else if (player1Pick == images[scissor])
            {
                if (player2Pick == images[rock])
                {
                    groupBox1.Text = "Player 2 Win";
                }
                else if (player2Pick == images[paper])
                {
                    groupBox1.Text = "Player 1 Win";
                }
                else if (player2Pick == images[scissor])
                {
                    groupBox1.Text = "Draw";
                }
            }
        }

        private void newGame()
        {

        }
    }
}
