namespace DFSDK_Launcher
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.MainGameRadioButton = new System.Windows.Forms.RadioButton();
            this.DLC1RadioButton = new System.Windows.Forms.RadioButton();
            this.DLC2RadioButton = new System.Windows.Forms.RadioButton();
            this.DLC3RadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save To";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainGameRadioButton
            // 
            this.MainGameRadioButton.AutoSize = true;
            this.MainGameRadioButton.Location = new System.Drawing.Point(15, 25);
            this.MainGameRadioButton.Name = "MainGameRadioButton";
            this.MainGameRadioButton.Size = new System.Drawing.Size(79, 17);
            this.MainGameRadioButton.TabIndex = 1;
            this.MainGameRadioButton.TabStop = true;
            this.MainGameRadioButton.Text = "Main Game";
            this.MainGameRadioButton.UseVisualStyleBackColor = true;
            this.MainGameRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // DLC1RadioButton
            // 
            this.DLC1RadioButton.AutoSize = true;
            this.DLC1RadioButton.Location = new System.Drawing.Point(268, 25);
            this.DLC1RadioButton.Name = "DLC1RadioButton";
            this.DLC1RadioButton.Size = new System.Drawing.Size(52, 17);
            this.DLC1RadioButton.TabIndex = 2;
            this.DLC1RadioButton.TabStop = true;
            this.DLC1RadioButton.Text = "DLC1";
            this.DLC1RadioButton.UseVisualStyleBackColor = true;
            this.DLC1RadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // DLC2RadioButton
            // 
            this.DLC2RadioButton.AutoSize = true;
            this.DLC2RadioButton.Location = new System.Drawing.Point(380, 25);
            this.DLC2RadioButton.Name = "DLC2RadioButton";
            this.DLC2RadioButton.Size = new System.Drawing.Size(52, 17);
            this.DLC2RadioButton.TabIndex = 3;
            this.DLC2RadioButton.TabStop = true;
            this.DLC2RadioButton.Text = "DLC2";
            this.DLC2RadioButton.UseVisualStyleBackColor = true;
            this.DLC2RadioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // DLC3RadioButton
            // 
            this.DLC3RadioButton.AutoSize = true;
            this.DLC3RadioButton.Location = new System.Drawing.Point(489, 25);
            this.DLC3RadioButton.Name = "DLC3RadioButton";
            this.DLC3RadioButton.Size = new System.Drawing.Size(52, 17);
            this.DLC3RadioButton.TabIndex = 4;
            this.DLC3RadioButton.TabStop = true;
            this.DLC3RadioButton.Text = "DLC3";
            this.DLC3RadioButton.UseVisualStyleBackColor = true;
            this.DLC3RadioButton.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cook Maps!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 82);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DLC3RadioButton);
            this.Controls.Add(this.DLC2RadioButton);
            this.Controls.Add(this.DLC1RadioButton);
            this.Controls.Add(this.MainGameRadioButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Cooker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton MainGameRadioButton;
        private System.Windows.Forms.RadioButton DLC1RadioButton;
        private System.Windows.Forms.RadioButton DLC2RadioButton;
        private System.Windows.Forms.RadioButton DLC3RadioButton;
        private System.Windows.Forms.Button button1;
    }
}