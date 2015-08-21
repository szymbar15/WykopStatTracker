namespace WykopStatTracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.debugBoxasdf = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.atencjaDzis = new System.Windows.Forms.Label();
            this.atencjaDzisTextBox = new System.Windows.Forms.TextBox();
            this.atencja7dni = new System.Windows.Forms.Label();
            this.atencja7dniTextBox = new System.Windows.Forms.TextBox();
            this.nickBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inWpisyToday = new System.Windows.Forms.TextBox();
            this.inWpisy7Days = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // debugBoxasdf
            // 
            this.debugBoxasdf.BackColor = System.Drawing.Color.White;
            this.debugBoxasdf.Location = new System.Drawing.Point(13, 74);
            this.debugBoxasdf.Name = "debugBoxasdf";
            this.debugBoxasdf.ReadOnly = true;
            this.debugBoxasdf.Size = new System.Drawing.Size(522, 256);
            this.debugBoxasdf.TabIndex = 0;
            this.debugBoxasdf.Text = "";
            this.debugBoxasdf.TextChanged += new System.EventHandler(this.debugBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sprawdź atencję";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // atencjaDzis
            // 
            this.atencjaDzis.AutoSize = true;
            this.atencjaDzis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atencjaDzis.Location = new System.Drawing.Point(9, 333);
            this.atencjaDzis.Name = "atencjaDzis";
            this.atencjaDzis.Size = new System.Drawing.Size(110, 20);
            this.atencjaDzis.TabIndex = 2;
            this.atencjaDzis.Text = "Atencja dzisiaj";
            this.atencjaDzis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.atencjaDzis.Click += new System.EventHandler(this.atencjaDzis_Click);
            // 
            // atencjaDzisTextBox
            // 
            this.atencjaDzisTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.atencjaDzisTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.atencjaDzisTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atencjaDzisTextBox.Location = new System.Drawing.Point(12, 356);
            this.atencjaDzisTextBox.Name = "atencjaDzisTextBox";
            this.atencjaDzisTextBox.ReadOnly = true;
            this.atencjaDzisTextBox.Size = new System.Drawing.Size(106, 55);
            this.atencjaDzisTextBox.TabIndex = 3;
            this.atencjaDzisTextBox.TextChanged += new System.EventHandler(this.atencjaDzisTextBox_TextChanged);
            // 
            // atencja7dni
            // 
            this.atencja7dni.AutoSize = true;
            this.atencja7dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atencja7dni.Location = new System.Drawing.Point(330, 333);
            this.atencja7dni.Name = "atencja7dni";
            this.atencja7dni.Size = new System.Drawing.Size(205, 20);
            this.atencja7dni.TabIndex = 4;
            this.atencja7dni.Text = "Atencja przez ostatnie 7 dni";
            this.atencja7dni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // atencja7dniTextBox
            // 
            this.atencja7dniTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.atencja7dniTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.atencja7dniTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atencja7dniTextBox.Location = new System.Drawing.Point(429, 356);
            this.atencja7dniTextBox.Name = "atencja7dniTextBox";
            this.atencja7dniTextBox.ReadOnly = true;
            this.atencja7dniTextBox.Size = new System.Drawing.Size(106, 55);
            this.atencja7dniTextBox.TabIndex = 5;
            this.atencja7dniTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nickBox
            // 
            this.nickBox.Location = new System.Drawing.Point(293, 28);
            this.nickBox.Name = "nickBox";
            this.nickBox.Size = new System.Drawing.Size(242, 20);
            this.nickBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(374, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Twój nick";
            // 
            // inWpisyToday
            // 
            this.inWpisyToday.BackColor = System.Drawing.SystemColors.Control;
            this.inWpisyToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inWpisyToday.Location = new System.Drawing.Point(13, 415);
            this.inWpisyToday.Name = "inWpisyToday";
            this.inWpisyToday.ReadOnly = true;
            this.inWpisyToday.Size = new System.Drawing.Size(100, 13);
            this.inWpisyToday.TabIndex = 8;
            // 
            // inWpisy7Days
            // 
            this.inWpisy7Days.BackColor = System.Drawing.SystemColors.Control;
            this.inWpisy7Days.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inWpisy7Days.Location = new System.Drawing.Point(435, 415);
            this.inWpisy7Days.Name = "inWpisy7Days";
            this.inWpisy7Days.ReadOnly = true;
            this.inWpisy7Days.Size = new System.Drawing.Size(100, 13);
            this.inWpisy7Days.TabIndex = 9;
            this.inWpisy7Days.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 440);
            this.Controls.Add(this.inWpisy7Days);
            this.Controls.Add(this.inWpisyToday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nickBox);
            this.Controls.Add(this.atencja7dniTextBox);
            this.Controls.Add(this.atencja7dni);
            this.Controls.Add(this.atencjaDzisTextBox);
            this.Controls.Add(this.atencjaDzis);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.debugBoxasdf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Atencjosprawdzacz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox debugBoxasdf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label atencjaDzis;
        private System.Windows.Forms.TextBox atencjaDzisTextBox;
        private System.Windows.Forms.Label atencja7dni;
        private System.Windows.Forms.TextBox atencja7dniTextBox;
        private System.Windows.Forms.TextBox nickBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inWpisyToday;
        private System.Windows.Forms.TextBox inWpisy7Days;

    }
}

