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
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace Bingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeOldNumberTextBoxesToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkThatCSVInSettingsHoldingBingoCardDataIsValid() == false)
            {
                automaticallyCheckForWinningCardsCheckBox.Checked = false;
            }
            updateVisibilityOfAutomaticWinnerFormItems(false);
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
            if (automaticGameInProgressFlag)
            {
                return;
            }
            if (calledValues.Count > MaxRandomNumber - 1)
            {
                MessageBox.Show("You've called all the numbers already! \n\nReset Before Continuing!", "Error");
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
        private void automaticallyCheckForWinningCardsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkThatCSVInSettingsHoldingBingoCardDataIsValid() == false)
            {
                automaticallyCheckForWinningCardsCheckBox.Checked = false;
            }
            bool itemsAreVisible = false;
            if (automaticallyCheckForWinningCardsCheckBox.Checked)
            {
                itemsAreVisible = true;
            }
            updateVisibilityOfAutomaticWinnerFormItems(itemsAreVisible);
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
        private void bingoCardGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bingo_Card_Generator newform = new Bingo_Card_Generator();
            newform.Show();
        }
        private void printableBingoCardMakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printable_Bingo_Card_Maker newform = new Printable_Bingo_Card_Maker();
            newform.Show();
        }

        private void setupAutomaticWinnerCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setup_Automatic_Winner_Checking newform = new Setup_Automatic_Winner_Checking();
            newform.Show();
        }
        private void getNewNumber()
        {
            if (calledValues.Count == 0 && automaticallyCheckForWinningCardsCheckBox.Checked)
            {
                pullDataFromCSVForWinnerChecking();
            }
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
            if (automaticallyCheckForWinningCardsCheckBox.Checked)
            {
                winningCardsComboBox.Items.Clear();
                winningCardsComboBox.Items.AddRange(checkForWinners());
                numberOfWinnersLabel.Text = "Number of Winning Cards: " + winningCardsComboBox.Items.Count.ToString();
            }
        }
        private char getBingoLetter(int number)
        {
            char[] bingoLetters = { 'B', 'I', 'N', 'G', 'O' };
            int stepSize = 15;
            for (int i = 0; i < 5; i++)
            {
                if (number < (stepSize * (i + 1)) + 1)
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
            allNumbersComboBox.Text = "";
            automaticGameInProgressFlag = false;
            automaticModeProgressBar.Visible = false;
            winningCardsComboBox.Items.Clear();
            winningCardsComboBox.Text = "";
            numberOfWinnersLabel.Text = "Number of Winning Cards:";
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
            while (automaticGameInProgressFlag)
            {
                if (stopwatch.ElapsedMilliseconds > timeBetweenCallsNumericUpDownCounter.Value * 1000 && automaticGameInProgressFlag)
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
        private bool checkThatCSVInSettingsHoldingBingoCardDataIsValid()
        {
            if (Path.GetExtension(Properties.Settings.Default.automaticWinnerCheckCSVFilePath) != ".csv")
            {
                MessageBox.Show("Incorrect file type selected. Program only supports writing to .csv files");
                Properties.Settings.Default.automaticWinnerCheckCSVFilePath = "";
                return false;
            }

            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(Properties.Settings.Default.automaticWinnerCheckCSVFilePath);
            }
            catch
            {
                Properties.Settings.Default.automaticWinnerCheckCSVFilePath = "";
                MessageBox.Show("Something went wrong with selected csv file in settings for automatic game checking. A new or different file will need to be selected for automatic winner checikng.", "Error?");
                return false;
            }

            return true;
        }
        private void updateVisibilityOfAutomaticWinnerFormItems(bool itemsAreVisible)
        {
            winningCardsComboBox.Visible = itemsAreVisible;
            numberOfWinnersLabel.Visible = itemsAreVisible;
        }
        private Dictionary<int, BingoCard> bingoCards;
        private void pullDataFromCSVForWinnerChecking()
        {
            bingoCards = new Dictionary<int, BingoCard>();
            string[] allLines = File.ReadAllLines(Properties.Settings.Default.automaticWinnerCheckCSVFilePath);
            // determine characteristics of .csv files contents
            int numberOfRowsInFile = allLines.Count();
            int numberOfColumnsInFile = allLines[1].Split(',').Count() - 1;
            int numberOfRowsPerBingoCard = 0;
            string tempString = "asdf";
            while (tempString != "" && numberOfRowsPerBingoCard < 10)
            {
                numberOfRowsPerBingoCard++;
                tempString = allLines[numberOfRowsPerBingoCard];
            }
            if (numberOfRowsPerBingoCard >= 10)
            {
                MessageBox.Show("Error with data in .csv file for automatic winner checking. Too many rows detected. Automatic Winner Checking Disabled");
            }
            numberOfRowsPerBingoCard--;


            // go through .csv file and pull out all bingo cards
            for (int rowNumber = 0; rowNumber < allLines.Length; rowNumber++)
            {
                BingoCard currentBingoCard = new BingoCard();
                currentBingoCard.cardName = allLines[rowNumber];
                currentBingoCard.cardNumber = int.Parse(Regex.Match(currentBingoCard.cardName, @"\d+$", RegexOptions.RightToLeft).Value);
                currentBingoCard.bingoNumberOfRows = numberOfRowsPerBingoCard;
                currentBingoCard.bingoNumberOfColumns = numberOfColumnsInFile;
                rowNumber++;
                currentBingoCard.bingoCardNumbers = new int[numberOfRowsPerBingoCard, numberOfColumnsInFile];
                for (int bingoCardRowNumber = 0; bingoCardRowNumber < numberOfRowsPerBingoCard; bingoCardRowNumber++)
                {
                    string[] columnNumbers = allLines[rowNumber].Split(',');
                    for (int columnNumber = 0; columnNumber < numberOfColumnsInFile; columnNumber++)
                    {
                        currentBingoCard.bingoCardNumbers[bingoCardRowNumber, columnNumber] = int.Parse(columnNumbers[columnNumber]);
                    }
                    rowNumber++;
                }
                if (bingoCards.ContainsKey(currentBingoCard.cardNumber))
                {
                    string messageString = "Warning, multiple instances of bingo card number " + currentBingoCard.cardNumber.ToString() +
                        " found in automatic winner checking csv.\n\n First card found will be kept; all duplicates skipped";
                    MessageBox.Show(messageString, "Warning, Duplicate Entries");
                    continue;
                }
                bingoCards.Add(currentBingoCard.cardNumber, currentBingoCard);
            }
            Application.DoEvents();
        }
        private string[] checkForWinners()
        {
            List<string> listOfWinners = new List<string>();

            for (int cardNumber = 1; cardNumber <= bingoCards.Count; cardNumber++)
            {
                if (checkCardForWinner(cardNumber))
                {
                    listOfWinners.Add(bingoCards[cardNumber].cardName);
                }
            }

            string[] arrayOfWinners = new string[listOfWinners.Count];
            for (int i = 0; i < listOfWinners.Count; i++)
            {
                arrayOfWinners[i] = listOfWinners[i];
            }
            return arrayOfWinners;
        }
        enum PossibleDirections
        {
            upLeft,
            up,
            upRight,
            right,
            downRight,
            down,
            downLeft,
            left
        }
        List<PossibleDirections> possibleDirections = new List<PossibleDirections>() {
            PossibleDirections.upLeft,
            PossibleDirections.up,
            PossibleDirections.upRight,
            PossibleDirections.right,
            PossibleDirections.downRight,
            PossibleDirections.down,
            PossibleDirections.downLeft,
            PossibleDirections.left,
        };
        // returns true if card is winner, returns false if card is not winner
        private bool checkCardForWinner(int cardNumber)
        {
            BingoCard cardBeingChecked = bingoCards[cardNumber];
            for(int rowNumber = 0; rowNumber < cardBeingChecked.bingoNumberOfRows; rowNumber++)
            {
                for(int coloumnNumber = 0; coloumnNumber < cardBeingChecked.bingoNumberOfColumns; coloumnNumber++)
                {
                    // check if number in question has been called, move on to next number if not
                    if (calledValues.Contains(cardBeingChecked.bingoCardNumbers[rowNumber, coloumnNumber]) == false)
                    {
                        continue;
                    }
                    // check each direction for number of continuous hits
                    Dictionary<PossibleDirections, int> numberOfHits = new Dictionary<PossibleDirections, int>();
                    foreach (PossibleDirections direction in possibleDirections)
                    {
                        int hits = checkForNumberOfHitsInGivenDirection(cardBeingChecked, direction, rowNumber, coloumnNumber);
                        numberOfHits.Add(direction, hits);
                    }
                    if (numberOfHits[PossibleDirections.upLeft] + numberOfHits[PossibleDirections.downRight] >= 4)
                    {
                        return true;
                    }
                    if (numberOfHits[PossibleDirections.up] + numberOfHits[PossibleDirections.down] >= 4)
                    {
                        return true;
                    }
                    if (numberOfHits[PossibleDirections.upRight] + numberOfHits[PossibleDirections.downLeft] >= 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private int checkForNumberOfHitsInGivenDirection(BingoCard cardBeingChecked, PossibleDirections direction, int startingRowNumber, int startingColumnNumber)
        {
            int numberOfHits = 0;
            int rowShift = 0, columnShift = 0;
            int rowNumber = startingRowNumber, columnNumber = startingColumnNumber;
            switch (direction)
            {
                case PossibleDirections.upLeft:
                    {
                        rowShift = -1;
                        columnShift = -1;
                        break;
                    }
                case PossibleDirections.up:
                    {
                        rowShift = -1;
                        columnShift = 0;
                        break;
                    }
                case PossibleDirections.upRight:
                    {
                        rowShift = -1;
                        columnShift = 1;
                        break;
                    }
                case PossibleDirections.right:
                    {
                        rowShift = 0;
                        columnShift = 1;
                        break;
                    }
                case PossibleDirections.downRight:
                    {
                        rowShift = 1;
                        columnShift = 1;
                        break;
                    }
                case PossibleDirections.down:
                    {
                        rowShift = 1;
                        columnShift = 0;
                        break;
                    }
                case PossibleDirections.downLeft:
                    {
                        rowShift = 1;
                        columnShift = -1;
                        break;
                    }
                case PossibleDirections.left:
                    {
                        rowShift = 0;
                        columnShift = -1;
                        break;
                    }
            }

            bool hit = true;
            while(hit)
            {
                rowNumber += rowShift;
                columnNumber += columnShift;
                if(rowNumber < 0 || rowNumber >= cardBeingChecked.bingoNumberOfRows)
                {
                    return numberOfHits;
                }
                if (columnNumber < 0 || columnNumber >= cardBeingChecked.bingoNumberOfColumns)
                {
                    return numberOfHits;
                }
                int numberToCheckFor = cardBeingChecked.bingoCardNumbers[rowNumber,columnNumber];
                if(calledValues.Contains(numberToCheckFor) == false)
                {
                    return numberOfHits;
                }
                numberOfHits++;
            }
            return numberOfHits;
        }








    }
}
