using System.Security.Cryptography.X509Certificates;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor= Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTImer.Stop();
;
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            CheckGame();
            CPUTImer.Start();

        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
            {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
              || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
              || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
              || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
              || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
              || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
              || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
              || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTImer.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWinCount++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWinCount; // update player label
                RestartGame(); // run the reset game function
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
           || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
           || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
           || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
           || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
           || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
           || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
           || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTImer.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                CPUWinCount++; // increase the computer wins score number
                label2.Text = "AI Wins- " + CPUWinCount; // update the label 2 for computer wins
                RestartGame(); // run the reset game
            }
            }
        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons) 
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
        }
    }
