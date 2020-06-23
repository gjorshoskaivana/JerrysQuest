namespace JerrysQuest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.Jerry = new System.Windows.Forms.PictureBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOverTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Jerry)).BeginInit();
            this.SuspendLayout();
            // 
            // Jerry
            // 
            this.Jerry.Image = global::JerrysQuest.Properties.Resources.jerry_running_right;
            this.Jerry.Location = new System.Drawing.Point(8, 31);
            this.Jerry.Name = "Jerry";
            this.Jerry.Size = new System.Drawing.Size(52, 53);
            this.Jerry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Jerry.TabIndex = 30;
            this.Jerry.TabStop = false;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ScoreLabel.Location = new System.Drawing.Point(3, 3);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(94, 25);
            this.ScoreLabel.TabIndex = 31;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 531);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.Jerry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "Jerry\'s Quest";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Jerry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Jerry;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer GameOverTimer;
    }
}