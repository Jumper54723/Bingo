namespace Bingo
{
    partial class Setup_Automatic_Winner_Checking
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
            this.selectInputCSVButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputFileNameLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectInputCSVButton
            // 
            this.selectInputCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectInputCSVButton.ForeColor = System.Drawing.Color.Black;
            this.selectInputCSVButton.Location = new System.Drawing.Point(12, 140);
            this.selectInputCSVButton.Name = "selectInputCSVButton";
            this.selectInputCSVButton.Size = new System.Drawing.Size(204, 35);
            this.selectInputCSVButton.TabIndex = 13;
            this.selectInputCSVButton.Text = "Select Input CSV File";
            this.selectInputCSVButton.UseVisualStyleBackColor = true;
            this.selectInputCSVButton.Click += new System.EventHandler(this.selectInputCSVButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.inputFileNameLabel);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 120);
            this.panel1.TabIndex = 12;
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
            // Setup_Automatic_Winner_Checking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectInputCSVButton);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Indigo;
            this.Name = "Setup_Automatic_Winner_Checking";
            this.Text = "Setup_Automatic_Winner_Checking";
            this.Load += new System.EventHandler(this.Setup_Automatic_Winner_Checking_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectInputCSVButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label inputFileNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}