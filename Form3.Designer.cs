namespace TartlesRun
{
    partial class Form3
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 228);
            this.button1.TabIndex = 0;
            this.button1.Tag = "1";
            this.button1.Text = "Chose Turtle";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(138, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 228);
            this.button2.TabIndex = 1;
            this.button2.Tag = "2";
            this.button2.Text = "Chose Turtle";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(264, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 228);
            this.button3.TabIndex = 2;
            this.button3.Tag = "3";
            this.button3.Text = "Chose Turtle";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(390, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 228);
            this.button4.TabIndex = 3;
            this.button4.Tag = "4";
            this.button4.Text = "Chose Turtle";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.MediumOrchid;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(516, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 228);
            this.button5.TabIndex = 4;
            this.button5.Tag = "5";
            this.button5.Text = "Chose Turtle";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 251);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Chose Your Turtle";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
    }
}