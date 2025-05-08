namespace Bingo
{
    partial class Bingo_Card_Generator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.outputFileNameLabel = new System.Windows.Forms.Label();
            this.selectOutputFileButton = new System.Windows.Forms.Button();
            this.generateCardsButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numberOfCardsToMakeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxPossibleLabel = new System.Windows.Forms.Label();
            this.currentlyAtLabel = new System.Windows.Forms.Label();
            this.cardTitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCardsToMakeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.outputFileNameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 120);
            this.panel1.TabIndex = 0;
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
            // selectOutputFileButton
            // 
            this.selectOutputFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectOutputFileButton.Location = new System.Drawing.Point(12, 140);
            this.selectOutputFileButton.Name = "selectOutputFileButton";
            this.selectOutputFileButton.Size = new System.Drawing.Size(150, 35);
            this.selectOutputFileButton.TabIndex = 1;
            this.selectOutputFileButton.Text = "Select Output File";
            this.selectOutputFileButton.UseVisualStyleBackColor = true;
            this.selectOutputFileButton.Click += new System.EventHandler(this.selectOutputFileButton_Click);
            // 
            // generateCardsButton
            // 
            this.generateCardsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateCardsButton.Location = new System.Drawing.Point(12, 312);
            this.generateCardsButton.Name = "generateCardsButton";
            this.generateCardsButton.Size = new System.Drawing.Size(150, 35);
            this.generateCardsButton.TabIndex = 2;
            this.generateCardsButton.Text = "Generate Cards";
            this.generateCardsButton.UseVisualStyleBackColor = true;
            this.generateCardsButton.Click += new System.EventHandler(this.generateCardsButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // numberOfCardsToMakeNumericUpDown
            // 
            this.numberOfCardsToMakeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfCardsToMakeNumericUpDown.Location = new System.Drawing.Point(12, 209);
            this.numberOfCardsToMakeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberOfCardsToMakeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCardsToMakeNumericUpDown.Name = "numberOfCardsToMakeNumericUpDown";
            this.numberOfCardsToMakeNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.numberOfCardsToMakeNumericUpDown.TabIndex = 3;
            this.numberOfCardsToMakeNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Cards to Make:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "/";
            // 
            // maxPossibleLabel
            // 
            this.maxPossibleLabel.AutoSize = true;
            this.maxPossibleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPossibleLabel.Location = new System.Drawing.Point(70, 359);
            this.maxPossibleLabel.Name = "maxPossibleLabel";
            this.maxPossibleLabel.Size = new System.Drawing.Size(36, 20);
            this.maxPossibleLabel.TabIndex = 6;
            this.maxPossibleLabel.Text = "000";
            // 
            // currentlyAtLabel
            // 
            this.currentlyAtLabel.AutoSize = true;
            this.currentlyAtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentlyAtLabel.Location = new System.Drawing.Point(12, 359);
            this.currentlyAtLabel.Name = "currentlyAtLabel";
            this.currentlyAtLabel.Size = new System.Drawing.Size(36, 20);
            this.currentlyAtLabel.TabIndex = 7;
            this.currentlyAtLabel.Text = "000";
            // 
            // cardTitleTextBox
            // 
            this.cardTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardTitleTextBox.Location = new System.Drawing.Point(12, 266);
            this.cardTitleTextBox.Name = "cardTitleTextBox";
            this.cardTitleTextBox.Size = new System.Drawing.Size(177, 26);
            this.cardTitleTextBox.TabIndex = 8;
            this.cardTitleTextBox.Text = "Bingo Card";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Card Title:";
            // 
            // Bingo_Card_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cardTitleTextBox);
            this.Controls.Add(this.currentlyAtLabel);
            this.Controls.Add(this.maxPossibleLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfCardsToMakeNumericUpDown);
            this.Controls.Add(this.generateCardsButton);
            this.Controls.Add(this.selectOutputFileButton);
            this.Controls.Add(this.panel1);
            this.Name = "Bingo_Card_Generator";
            this.Text = "Bingo_Card_Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCardsToMakeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label outputFileNameLabel;
        private System.Windows.Forms.Button selectOutputFileButton;
        private System.Windows.Forms.Button generateCardsButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numberOfCardsToMakeNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label maxPossibleLabel;
        private System.Windows.Forms.Label currentlyAtLabel;
        private System.Windows.Forms.TextBox cardTitleTextBox;
        private System.Windows.Forms.Label label3;
    }
}