
namespace WindowsFormsApp1.WinForms
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.BloodDonatorsGridView = new System.Windows.Forms.DataGridView();
            this.BloodGroupCombobox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonatorsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetData);
            // 
            // BloodDonatorsGridView
            // 
            this.BloodDonatorsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BloodDonatorsGridView.Location = new System.Drawing.Point(21, 58);
            this.BloodDonatorsGridView.Name = "BloodDonatorsGridView";
            this.BloodDonatorsGridView.Size = new System.Drawing.Size(869, 522);
            this.BloodDonatorsGridView.TabIndex = 1;
            // 
            // BloodGroupCombobox
            // 
            this.BloodGroupCombobox.BackColor = System.Drawing.Color.White;
            this.BloodGroupCombobox.DropDownHeight = 150;
            this.BloodGroupCombobox.DropDownWidth = 150;
            this.BloodGroupCombobox.FormattingEnabled = true;
            this.BloodGroupCombobox.IntegralHeight = false;
            this.BloodGroupCombobox.ItemHeight = 13;
            this.BloodGroupCombobox.Location = new System.Drawing.Point(380, 13);
            this.BloodGroupCombobox.Name = "BloodGroupCombobox";
            this.BloodGroupCombobox.Size = new System.Drawing.Size(212, 21);
            this.BloodGroupCombobox.TabIndex = 2;
            this.BloodGroupCombobox.SelectedIndexChanged += new System.EventHandler(this.BloodGroupChange);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(669, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnBloodDonationKeyUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Search";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnSearchButton);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(920, 592);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BloodGroupCombobox);
            this.Controls.Add(this.BloodDonatorsGridView);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonatorsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView BloodDonatorsGridView;
        private System.Windows.Forms.ComboBox BloodGroupCombobox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}