using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

namespace Bingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeOldNumberTextBoxesToList();
        }
        
        public List<int> calledValues = new List<int>();
        public List<string> calledValuesWithLetter = new List<string>();
        public List<int> calledValuesSorted = new List<int>();
        public List<TextBox> oldNumberTextBoxes = new List<TextBox>();
        public const int MinRandomNumber = 1;
        public const int MaxRandomNumber = 75;
        public bool automaticGameInProgressFlag = false;
        private void getNumberButton_Click(object sender, EventArgs e)
        {
            if(automaticGameInProgressFlag)
            {
                return;
            }
            if(calledValues.Count > MaxRandomNumber - 1)
            {
                MessageBox.Show("You've called all the numbers already! \n\nReset Before Continuing!","Error");
                return;
            }

            getNewNumber();
        }
        private void resetGameButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Reset the game?", "Check", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            resetGame();
        }
        private void startAutomaticGameButton_Click(object sender, EventArgs e)
        {
            if (automaticGameInProgressFlag)
            {
                return;
            }
            automaticGameInProgressFlag = true;
            automaticModeProgressBar.Visible = true;
            getNewNumber();
            automaticGameWorker();
        }

        private void stopAutomaticGameButton_Click(object sender, EventArgs e)
        {
            automaticGameInProgressFlag = false;
            automaticModeProgressBar.Visible = false;
        }
        private void getNewNumber()
        {
            Random rand = new Random();
            int num = rand.Next(MinRandomNumber, MaxRandomNumber + 1);
            while (calledValues.Contains(num))
            {
                num = rand.Next(MinRandomNumber, MaxRandomNumber + 1);
            }
            calledValues.Add(num);


            calledValuesSorted.Add(num);
            calledValuesSorted.Sort();
            allNumbersComboBox.Items.Clear();
            for (int i = 0; i < calledValuesSorted.Count; i++)
            {
                int number = calledValuesSorted[i];
                allNumbersComboBox.Items.Add(getBingoLetter(number) + number.ToString());
            }


            string numAndLetterString = getBingoLetter(num) + num.ToString();
            calledValuesWithLetter.Add(numAndLetterString);
            newNumberTextBox.Text = numAndLetterString;        
            for (int i = 0; i < oldNumberTextBoxes.Count(); i++)
            {
                if (calledValuesWithLetter.Count() - i < 1)
                {
                    break;
                }
                oldNumberTextBoxes[i].Text = calledValuesWithLetter[calledValuesWithLetter.Count() - i - 1];
            }
            updateOldNumberTextBoxs();
        }
        private char getBingoLetter(int number)
        {
            char[] bingoLetters = { 'B', 'I' ,'N','G','O'};
            int stepSize = 15;
            for(int i = 0; i < 5; i++)
            {
                if(number < (stepSize * (i+1)) + 1)
                {
                    return (bingoLetters[i]);
                }
            }
            return ('E');
        }
        private void resetGame()
        {
            calledValues.Clear();
            calledValuesSorted.Clear();
            newNumberTextBox.Text = "";
            for (int i = 0; i < oldNumberTextBoxes.Count(); i++)
            {
                oldNumberTextBoxes[i].Text = "";
            }
            updateOldNumberTextBoxs();
            allNumbersComboBox.Items.Clear();
            automaticGameInProgressFlag = false;
            automaticModeProgressBar.Visible = false;
        }
        private void InitializeOldNumberTextBoxesToList()
        {
            oldNumberTextBoxes.Add(oldNumberTextBox1);
            oldNumberTextBoxes.Add(oldNumberTextBox2);
            oldNumberTextBoxes.Add(oldNumberTextBox3);
            oldNumberTextBoxes.Add(oldNumberTextBox4);
            oldNumberTextBoxes.Add(oldNumberTextBox5);
            oldNumberTextBoxes.Add(oldNumberTextBox6);
            oldNumberTextBoxes.Add(oldNumberTextBox7);
            oldNumberTextBoxes.Add(oldNumberTextBox8);
            oldNumberTextBoxes.Add(oldNumberTextBox9);
            oldNumberTextBoxes.Add(oldNumberTextBox10);
            oldNumberTextBoxes.Add(oldNumberTextBox11);
            oldNumberTextBoxes.Add(oldNumberTextBox12);
            oldNumberTextBoxes.Add(oldNumberTextBox13);
            oldNumberTextBoxes.Add(oldNumberTextBox14);
            oldNumberTextBoxes.Add(oldNumberTextBox15);
            oldNumberTextBoxes.Add(oldNumberTextBox16);
            oldNumberTextBoxes.Add(oldNumberTextBox17);
            oldNumberTextBoxes.Add(oldNumberTextBox18);
            oldNumberTextBoxes.Add(oldNumberTextBox19);
            oldNumberTextBoxes.Add(oldNumberTextBox20);
            oldNumberTextBoxes.Add(oldNumberTextBox21);
        }
        private void updateOldNumberTextBoxs()
        {
            oldNumberTextBox1 = oldNumberTextBoxes[0];
            oldNumberTextBox2 = oldNumberTextBoxes[1];
            oldNumberTextBox3 = oldNumberTextBoxes[2];
            oldNumberTextBox4 = oldNumberTextBoxes[3];
            oldNumberTextBox5 = oldNumberTextBoxes[4];
            oldNumberTextBox6 = oldNumberTextBoxes[5];
            oldNumberTextBox7 = oldNumberTextBoxes[6];
            oldNumberTextBox8 = oldNumberTextBoxes[7];
            oldNumberTextBox9 = oldNumberTextBoxes[8];
            oldNumberTextBox10 = oldNumberTextBoxes[9];
            oldNumberTextBox11 = oldNumberTextBoxes[10];
            oldNumberTextBox12 = oldNumberTextBoxes[11];
            oldNumberTextBox13 = oldNumberTextBoxes[12];
            oldNumberTextBox14 = oldNumberTextBoxes[13];
            oldNumberTextBox15 = oldNumberTextBoxes[14];
            oldNumberTextBox16 = oldNumberTextBoxes[15];
            oldNumberTextBox17 = oldNumberTextBoxes[16];
            oldNumberTextBox18 = oldNumberTextBoxes[17];
            oldNumberTextBox19 = oldNumberTextBoxes[18];
            oldNumberTextBox20 = oldNumberTextBoxes[19];
            oldNumberTextBox21 = oldNumberTextBoxes[20];
        }
        private void automaticGameWorker()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while(automaticGameInProgressFlag)
            {
                if(stopwatch.ElapsedMilliseconds > timeBetweenCallsNumericUpDownCounter.Value * 1000 && automaticGameInProgressFlag)
                {
                    getNewNumber();
                    stopwatch.Restart();
                }
                automaticModeProgressBar.Maximum = (int)(timeBetweenCallsNumericUpDownCounter.Value * 1000);
                if ((int)stopwatch.ElapsedMilliseconds < automaticModeProgressBar.Maximum)
                {
                    automaticModeProgressBar.Value = (int)stopwatch.ElapsedMilliseconds;
                }
                Application.DoEvents();
            }
        }

        private void bingoCardGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bingo_Card_Generator newform = new Bingo_Card_Generator();
            newform.Show();
        }
    }
}
