
namespace PotatoShooter
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.targetTimer = new System.Windows.Forms.Timer(this.components);
            this.platno1 = new PotatoShooter.Platno();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 17;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // targetTimer
            // 
            this.targetTimer.Interval = 2000;
            this.targetTimer.Tick += new System.EventHandler(this.targetTimer_Tick);
            // 
            // platno1
            // 
            this.platno1.BackColor = System.Drawing.Color.SkyBlue;
            this.platno1.Location = new System.Drawing.Point(12, 12);
            this.platno1.Name = "platno1";
            this.platno1.Size = new System.Drawing.Size(974, 496);
            this.platno1.TabIndex = 0;
            this.platno1.Paint += new System.Windows.Forms.PaintEventHandler(this.platno1_Paint);
            this.platno1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.platno1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zbývá střel: 3";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(571, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Počet bodů:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 770);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.platno1);
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer targetTimer;
        private Platno platno1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}