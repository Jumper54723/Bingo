namespace Bingo
{
    partial class Printable_Bingo_Card_Maker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentlyAtLabel = new System.Windows.Forms.Label();
            this.maxPossibleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generatePrintableBingoCardsButton = new System.Windows.Forms.Button();
            this.selectInputCSVButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputFileNameLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectOutputDocxButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.outputFileNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentlyAtLabel
            // 
            this.currentlyAtLabel.AutoSize = true;
            this.currentlyAtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentlyAtLabel.Location = new System.Drawing.Point(12, 234);
            this.currentlyAtLabel.Name = "currentlyAtLabel";
            this.currentlyAtLabel.Size = new System.Drawing.Size(36, 20);
            this.currentlyAtLabel.TabIndex = 17;
            this.currentlyAtLabel.Text = "000";
            // 
            // maxPossibleLabel
            // 
            this.maxPossibleLabel.AutoSize = true;
            this.maxPossibleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPossibleLabel.Location = new System.Drawing.Point(70, 234);
            this.maxPossibleLabel.Name = "maxPossibleLabel";
            this.maxPossibleLabel.Size = new System.Drawing.Size(36, 20);
            this.maxPossibleLabel.TabIndex = 16;
            this.maxPossibleLabel.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "/";
            // 
            // generatePrintableBingoCardsButton
            // 
            this.generatePrintableBingoCardsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generatePrintableBingoCardsButton.Location = new System.Drawing.Point(12, 187);
            this.generatePrintableBingoCardsButton.Name = "generatePrintableBingoCardsButton";
            this.generatePrintableBingoCardsButton.Size = new System.Drawing.Size(257, 35);
            this.generatePrintableBingoCardsButton.TabIndex = 12;
            this.generatePrintableBingoCardsButton.Text = "Generate Printable Bingo Cards";
            this.generatePrintableBingoCardsButton.UseVisualStyleBackColor = true;
            this.generatePrintableBingoCardsButton.Click += new System.EventHandler(this.generatePrintableBingoCardsButton_Click);
            // 
            // selectInputCSVButton
            // 
            this.selectInputCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectInputCSVButton.Location = new System.Drawing.Point(12, 140);
            this.selectInputCSVButton.Name = "selectInputCSVButton";
            this.selectInputCSVButton.Size = new System.Drawing.Size(204, 35);
            this.selectInputCSVButton.TabIndex = 11;
            this.selectInputCSVButton.Text = "Select Input CSV File";
            this.selectInputCSVButton.UseVisualStyleBackColor = true;
            this.selectInputCSVButton.Click += new System.EventHandler(this.selectInputCSVFileButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.inputFileNameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 120);
            this.panel1.TabIndex = 10;
            // 
            // inputFileNameLabel
            // 
            this.inputFileNameLabel.AutoSize = true;
            this.inputFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFileNameLabel.Location = new System.Drawing.Point(10, 10);
            this.inputFileNameLabel.MaximumSize = new System.Drawing.Size(300, 100);
            this.inputFileNameLabel.Name = "inputFileNameLabel";
            this.inputFileNameLabel.Size = new System.Drawing.Size(107, 16);
            this.inputFileNameLabel.TabIndex = 0;
            this.inputFileNameLabel.Text = "No File Selected";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectOutputDocxButton
            // 
            this.selectOutputDocxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectOutputDocxButton.Location = new System.Drawing.Point(373, 140);
            this.selectOutputDocxButton.Name = "selectOutputDocxButton";
            this.selectOutputDocxButton.Size = new System.Drawing.Size(210, 35);
            this.selectOutputDocxButton.TabIndex = 21;
            this.selectOutputDocxButton.Text = "Select Output Docx File";
            this.selectOutputDocxButton.UseVisualStyleBackColor = true;
            this.selectOutputDocxButton.Click += new System.EventHandler(this.selectOutputFileButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.outputFileNameLabel);
            this.panel2.Location = new System.Drawing.Point(373, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 120);
            this.panel2.TabIndex = 20;
            // 
            // outputFileNameLabel
            // 
            this.outputFileNameLabel.AutoSize = true;
            this.outputFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputFileNameLabel.Location = new System.Drawing.Point(10, 10);
            this.outputFileNameLabel.MaximumSize = new System.Drawing.Size(300, 100);
            this.outputFileNameLabel.Name = "outputFileNameLabel";
            this.outputFileNameLabel.Size = new System.Drawing.Size(107, 16);
            this.outputFileNameLabel.TabIndex = 0;
            this.outputFileNameLabel.Text = "No File Selected";
            // 
            // Printable_Bingo_Card_Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectOutputDocxButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.currentlyAtLabel);
            this.Controls.Add(this.maxPossibleLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generatePrintableBingoCardsButton);
            this.Controls.Add(this.selectInputCSVButton);
            this.Controls.Add(this.panel1);
            this.Name = "Printable_Bingo_Card_Maker";
            this.Text = "Printable_Bingo_Card_Maker";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentlyAtLabel;
        private System.Windows.Forms.Label maxPossibleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generatePrintableBingoCardsButton;
        private System.Windows.Forms.Button selectInputCSVButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label inputFileNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectOutputDocxButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label outputFileNameLabel;
    }
}