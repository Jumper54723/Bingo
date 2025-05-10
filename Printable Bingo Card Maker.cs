using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class Printable_Bingo_Card_Maker : Form
    {
        public Printable_Bingo_Card_Maker()
        {
            InitializeComponent();
        }
        private string inputFileString;
        private string outputFileString;
        private void selectInputCSVFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            inputFileString = openFileDialog1.FileName;
            if (Path.GetExtension(inputFileString) != ".csv")
            {
                MessageBox.Show("Incorrect file type selected. Program only supports writing to .csv files");
                inputFileString = "";
            }

            if(checkCSVFileIsValid() == false)
            {
                MessageBox.Show("File does not contain valid values, is not in correct format, or another error with input file has occured.\n\n " +
                    "Please correct error in file or select a differnt file and try again", "File Error");
                inputFileString = "";
                inputFileNameLabel.Text = "No File Selected";
                return;
            }
            inputFileNameLabel.Text = inputFileString;
        }
        private void selectOutputFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "docx files (*.docx)|*.docx";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            outputFileString = openFileDialog1.FileName;
            if (Path.GetExtension(outputFileString) != ".docx")
            {
                MessageBox.Show("Incorrect file type selected. Program can only create printable bingo cards in .docx format");
                outputFileString = "";
            }


            try
            {
                // Open a WordprocessingDocument for editing using the filepath.
                using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(outputFileString, true))
                {
                }
            }
            catch
            {
                MessageBox.Show("Error with selected file. May be open already elsewhere", "Error");
                outputFileString = "";
                outputFileNameLabel.Text = "No File Selected";
                return;
            }


            if (outputFileString != "")
            {
                DialogResult result = MessageBox.Show("If this file is used all data will be removed from file. \n\nAre you sure you want to use this file?", "Will Erase Check", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    outputFileString = "";
                }
            }

            if (outputFileString == "")
            {
                outputFileNameLabel.Text = "No File Selected";
                return;
            }
            outputFileNameLabel.Text = outputFileString;
        }

        private bool checkCSVFileIsValid()
        {
            try
            {
                string[] allLines = File.ReadAllLines(inputFileString);

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
                if (numberOfRowsPerBingoCard >= 10 || numberOfColumnsInFile >= 10)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void generatePrintableBingoCardsButton_Click(object sender, EventArgs e)
        {
            getBingoCardsFromFile();
            createPrintableBingoCardsDocument(outputFileString);
        }
        private Dictionary<int, BingoCard> bingoCards;
        private void getBingoCardsFromFile()
        {
            bingoCards = new Dictionary<int, BingoCard>();
            string[] allLines = File.ReadAllLines(inputFileString);

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
                MessageBox.Show("Error with data in .csv file. Too many rows detected");
            }
            numberOfRowsPerBingoCard--;



            // go through .csv file and pull out all bingo cards
            for (int rowNumber = 0; rowNumber < allLines.Length; rowNumber++)
            {
                BingoCard currentBingoCard = new BingoCard();
                currentBingoCard.cardName = allLines[rowNumber];
                currentBingoCard.cardNumber = int.Parse(Regex.Match(currentBingoCard.cardName, @"\d+$", RegexOptions.RightToLeft).Value);
                currentBingoCard.bingoNumberRows = numberOfRowsPerBingoCard; 
                currentBingoCard.bingoNumberColumns = numberOfColumnsInFile; 
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
                        " found.\n\n First card found will be kept; all duplicates skipped";
                    MessageBox.Show(messageString, "Warning, Duplicate Entries");
                    continue;
                }
                bingoCards.Add(currentBingoCard.cardNumber, currentBingoCard);
            }
            maxPossibleLabel.Text = bingoCards.Keys.Count.ToString();
            Application.DoEvents();
        }
        private void createPrintableBingoCardsDocument(string filepath)
        {
            // Open a WordprocessingDocument for editing using the filepath.
            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filepath, true))
            {

                if (wordprocessingDocument is null)
                {
                    throw new ArgumentNullException(nameof(wordprocessingDocument));
                }

                // Assign a reference to the existing document body.
                MainDocumentPart mainDocumentPart = wordprocessingDocument.MainDocumentPart ?? wordprocessingDocument.AddMainDocumentPart();
                //mainDocumentPart.Document = new Document();
                mainDocumentPart.Document.Body = mainDocumentPart.Document.AppendChild(new Body());
                Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                // Append Bingo Tables to body
                for (int bingoCardNumber = 1; bingoCardNumber <= bingoCards.Count; bingoCardNumber++)
                {
                    currentlyAtLabel.Text = bingoCardNumber.ToString();
                    Application.DoEvents();
                    List<Paragraph> blankParagraphs = forDocGetBlankParagraphs(4);      // Adds blank lines before table
                    foreach(Paragraph blankParagraph in blankParagraphs)
                    {
                        body.AppendChild(blankParagraph);
                    }
                    body.AppendChild(forDocCreateNewBingoCard(bingoCardNumber));        // Adds bingo tables to Doc
                    blankParagraphs = forDocGetBlankParagraphs(6);                      // Adds blank lines after table
                    foreach (Paragraph blankParagraph in blankParagraphs)
                    {
                        body.AppendChild(blankParagraph);
                    }
                    body.AppendChild(forDocCreateCardNameParagraph(bingoCardNumber));   // Adds card title to bottom right of card
                    if (bingoCardNumber != bingoCards.Count)
                    {
                        body.AppendChild(forDocCreatePageBreak());                      // Adds page break after table, if not the last card
                    }
                }
                wordprocessingDocument.MainDocumentPart.Document.Save();
            }

        }
        List<Paragraph> forDocGetBlankParagraphs(int numberOfBlankParagraphs)
        {
            List<Paragraph> blankParagraphs = new List<Paragraph>();
            for(int i = 0; i < numberOfBlankParagraphs; i++)
            {
                blankParagraphs.Add(new Paragraph(new Run(new Text(""))));
            }

            return blankParagraphs;
        }
        public string bingoCardFontSize = "56"; // half points, font is half this in points
        public string bingoCardColumnWidth = "400"; 
        Table forDocCreateNewBingoCard(int bingoCardNumber)
        {
            // Create the table
            Table table = new Table();
            BingoCard currentBingoCard = bingoCards[bingoCardNumber];
            // Optional: define table borders
            TableProperties tblProps = new TableProperties(
                new TableJustification { Val = TableRowAlignmentValues.Center },
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Pct },
                new TableLayout() { Type = TableLayoutValues.Fixed }, // 🔧 Important for column widths
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6 },
                    new BottomBorder { Val = BorderValues.Single, Size = 6 },
                    new LeftBorder { Val = BorderValues.Single, Size = 6 },
                    new RightBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
                )
            );
            table.AppendChild(tblProps);


            // add BINGO header row for standard 75-bingo
            string[] bingoLetters = { "B","I","N","G","O" };
            TableRow headerRow = new TableRow();
            for (int i = 0; i < 5; i++)
            {
                TableCell cell = new TableCell(
                    new Paragraph(
                        new ParagraphProperties(
                            new Justification() { Val = JustificationValues.Center }  // Center text horizontally
                        ),
                        new Run(
                            new RunProperties(
                                new Bold(),
                                new FontSize() { Val = bingoCardFontSize } // half points, font is half this in points
                                ),
                            new Text(bingoLetters[i])))
                );

                // Optional: define cell properties (like cell width)
                cell.Append(new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = bingoCardColumnWidth },  // 2000 = 20%,
                    new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center}
                ));

                headerRow.Append(cell);
            }
            table.Append(headerRow);

            // Add all other Rows and Columns to Table
            int centerRow = (int)Math.Floor((double)currentBingoCard.bingoNumberRows / 2);
            int centerColumn = (int)Math.Floor((double)currentBingoCard.bingoNumberRows / 2);
            for (int rowNumber = 0; rowNumber < currentBingoCard.bingoNumberRows; rowNumber++)
            {
                TableRow row = new TableRow();

                for (int columnNumber = 0; columnNumber < currentBingoCard.bingoNumberColumns; columnNumber++)
                {
                    string cellString = currentBingoCard.bingoCardNumbers[rowNumber, columnNumber].ToString();
                    if(rowNumber == centerRow && columnNumber == centerColumn)
                    {
                        cellString = "Free";
                    }
                    TableCell cell = new TableCell(
                        new Paragraph(
                            new ParagraphProperties(
                                new Justification() { Val = JustificationValues.Center }  // Center text horizontally
                                ),
                            new Run(
                                new RunProperties(
                                    new FontSize() { Val = bingoCardFontSize } // half points, font is half this in points
                                    ),
                                new Text(cellString)
                                )
                            )
                    );
                    // Optional: define cell properties (like cell width)
                    cell.Append(new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = bingoCardColumnWidth },
                        new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center }
                    ));

                    row.Append(cell);
                }

                table.Append(row);
            }

            return table;
        }
        Paragraph forDocCreateCardNameParagraph(int bingoCardNumber)
        {
            BingoCard currentBingoCard = bingoCards[bingoCardNumber];
            Paragraph titleParagraph = 
                new Paragraph(
                    new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Right}  // Center text horizontally
                        ),                    
                    new Run(
                        new RunProperties(
                            new FontSize() { Val = bingoCardFontSize } // half points, font is half this in points
                            ),
                        new Text(currentBingoCard.cardName)   
                    )
                );
            return titleParagraph;
        }
        Paragraph forDocCreatePageBreak()
        {
            return new Paragraph(
                new Run(
                    new Break() { Type = BreakValues.Page }
                )
            );
        }


    }
}
