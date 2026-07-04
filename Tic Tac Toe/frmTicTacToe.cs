using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class frmTicTacToe : Form
    {
        public frmTicTacToe()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1, Player2
        }

        enum enWinner
        {
            Player1, Player2, Draw, InProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public byte PlayCount;
        }

        private void frmOpening_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen WhitePen = new Pen(White);
            WhitePen.Width = 8;

            WhitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            WhitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(WhitePen, 475, 100, 475, 425);
            e.Graphics.DrawLine(WhitePen, 600, 100, 600, 425);
            e.Graphics.DrawLine(WhitePen, 350, 200, 725, 200);
            e.Graphics.DrawLine(WhitePen, 350, 325, 725, 325);
        }

        void EndGame()
        {
            GameStatus.GameOver = true;
            lblTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:

                        lblWinner.Text = "Player1";
                        break;

                case enWinner.Player2:

                        lblWinner.Text = "Player2";
                        break;

                default:

                        lblWinner.Text = "Draw";
                        break;
            }


            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString()
                && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    lblWinner.Text = "Player1";
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    lblWinner.Text = "Player2";
                }

                EndGame();
                return true;
            }

            GameStatus.GameOver = false;
            return false;

        }

        void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;
        }

        void ResetButton(Button button)
        {
            button.Tag = "?";
            button.Image = Resources.Question_Mark;
            button.BackColor = Color.Transparent;
        }

        void Restart()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player1";
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.InProgress;
            GameStatus.GameOver = false;
            lblWinner.Text = "In progress";
        }

        void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?" && GameStatus.GameOver == false)
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Tag = "X";
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Tag = "O";
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    

            if(GameStatus.PlayCount == 9)
            {
                EndGame();
                GameStatus.Winner = enWinner.Draw;

            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
