using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bingo
{
    public partial class Bingo_Card_Generator : Form
    {
        public Bingo_Card_Generator()
        {
            InitializeComponent();
        }
        private string outputFileString = "";
        private void selectOutputFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            outputFileString = openFileDialog1.FileName;
            if(Path.GetExtension(outputFileString) != ".csv")
            {
                MessageBox.Show("Incorrect file type selected. Program only supports writing to .csv files");
                outputFileString = "";
            }
            
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(outputFileString);
            }
            catch
            {
                MessageBox.Show("Something went wrong. I don't know what you did but....  don't", "Huh?");
            }

            if(lines.Length != 0)
            {
                DialogResult result = MessageBox.Show("File does not appear to be empty. If this file is used all data will be removed from file. \n\nAre you sure you want to use this file?", "File Not Empty", MessageBoxButtons.YesNo);
                if(result == DialogResult.No)
                {
                    outputFileString = "";
                }
            }

            if(outputFileString == "")
            {
                outputFileNameLabel.Text = "No File Selected";
                return;
            }
            outputFileNameLabel.Text = outputFileString;
        }

        private void generateCardsButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(outputFileString))
            {
                MessageBox.Show("Please select an empty .csv file before attepting to generate bingo cards","Error");
                return;
            }
            generateNumbersFor75Bingo();

        }
        List<int> possibleIntegers = new List<int>() 
        { 
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
        };
        private Dictionary<int, BingoCard> bingoCards;
        private int matchCountMax;
        private void generateNumbersFor75Bingo()
        {
            bingoCards = new Dictionary<int, BingoCard>();
            int numberOfBingoCardsDesired = (int)numberOfCardsToMakeNumericUpDown.Value;
            string bingoCardTitle = cardTitleTextBox.Text;
            maxPossibleLabel.Text = numberOfBingoCardsDesired.ToString();
            Random rand = new Random();

            if(numberOfBingoCardsDesired < 16)
            {
                matchCountMax = 0;
            }
            else if(numberOfBingoCardsDesired < 100)
            {
                matchCountMax = 1;
            }
            else
            {
                matchCountMax = 2;
            }

            // one loop for every bingo card being generated
            for (int cardNumber = 1; cardNumber < numberOfBingoCardsDesired+1; cardNumber++)
            {
                currentlyAtLabel.Text = cardNumber.ToString();
                BingoCard bingoCard = new BingoCard();
                bingoCard.cardName = bingoCardTitle + " " + cardNumber.ToString();
                bingoCard.cardNumber = cardNumber;
                // one loop for each bingo card column
                for (int columnNumber = 0; columnNumber < 5; columnNumber++)
                {
                    List<int> workingPossibleIntegers = new List<int>(possibleIntegers);
                    // one loop for ever column's row
                    for (int rowNumber = 0; rowNumber < 5; rowNumber++)
                    {
                        Application.DoEvents();
                        if (rowNumber == 2 && columnNumber == 2)
                        {
                            bingoCard.bingoCardNumbers[rowNumber, columnNumber] = 0;
                            continue;
                        }
                        int randomIndex = rand.Next(0, workingPossibleIntegers.Count());
                        int randomNumber = workingPossibleIntegers[randomIndex];
                        randomNumber += columnNumber * 15;
                        workingPossibleIntegers.RemoveAt(randomIndex);
                        bingoCard.bingoCardNumbers[rowNumber, columnNumber] = randomNumber;
                    }
                    if (checkForIfIsNovel(bingoCard, columnNumber) == false)
                    {
                        columnNumber--;
                        continue;
                    }
                }
                bingoCards.Add(cardNumber, bingoCard);
            }

            printBingoCardsToCSV();
        }

        private bool checkForIfIsNovel(BingoCard bingoCard, int columnNumber)
        {
            for(int cardNumber = 1; cardNumber < bingoCard.cardNumber; cardNumber++)
            {
                int matchCount = 0;
                BingoCard cardBeingChecked = bingoCards[cardNumber];
                for (int rowCount = 0; rowCount < 5; rowCount++)
                {
                    if (cardBeingChecked.bingoCardNumbers[rowCount,columnNumber] == bingoCard.bingoCardNumbers[rowCount, columnNumber])
                    {
                        matchCount++;
                    }
                }
                if(matchCount > matchCountMax)
                {
                    return false;
                }
            }

            return true;
        }
        private void printBingoCardsToCSV()
        {
            string stringToPrintToCSV = "";
            for (int cardNumber = 1; cardNumber < bingoCards.Count() + 1; cardNumber++)
            {
                BingoCard bingoCard = bingoCards[cardNumber];
                char[] trimChars = { '\n', ',' , '\0','\r'};
                bingoCard.cardName = bingoCard.cardName.Trim(trimChars);
                stringToPrintToCSV += bingoCard.cardName + "\n";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        stringToPrintToCSV += bingoCard.bingoCardNumbers[i, j].ToString() + ",";
                    }
                    stringToPrintToCSV.TrimEnd(stringToPrintToCSV[stringToPrintToCSV.Length - 1]);
                    stringToPrintToCSV += "\n";
                }
                stringToPrintToCSV += "\n";
            }
            string tempString = outputFileNameLabel.Text;
            outputFileNameLabel.Text = "Printing to File";
            Application.DoEvents();
            Thread.Sleep(10);
            Application.DoEvents();
            File.WriteAllText(outputFileString, stringToPrintToCSV);
            outputFileNameLabel.Text = tempString;

        }

    }
}
