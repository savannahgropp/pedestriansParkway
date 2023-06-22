namespace pedestriansParkway
{
    partial class pedestriansParkway
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pedestriansParkway));
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.timedButton = new System.Windows.Forms.Button();
            this.endlessButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(1, 100);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(963, 165);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Pedestrian\'s Parkway";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Gill Sans MT", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.White;
            this.subtitleLabel.Location = new System.Drawing.Point(1, 254);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(963, 62);
            this.subtitleLabel.TabIndex = 2;
            this.subtitleLabel.Text = "SELECT GAME MODE";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timedButton
            // 
            this.timedButton.BackColor = System.Drawing.Color.Yellow;
            this.timedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timedButton.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timedButton.ForeColor = System.Drawing.Color.Black;
            this.timedButton.Location = new System.Drawing.Point(307, 369);
            this.timedButton.Name = "timedButton";
            this.timedButton.Size = new System.Drawing.Size(160, 68);
            this.timedButton.TabIndex = 3;
            this.timedButton.Text = "Timed";
            this.timedButton.UseVisualStyleBackColor = false;
            this.timedButton.Click += new System.EventHandler(this.timedButton_Click);
            // 
            // endlessButton
            // 
            this.endlessButton.BackColor = System.Drawing.Color.Yellow;
            this.endlessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endlessButton.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endlessButton.ForeColor = System.Drawing.Color.Black;
            this.endlessButton.Location = new System.Drawing.Point(487, 369);
            this.endlessButton.Name = "endlessButton";
            this.endlessButton.Size = new System.Drawing.Size(160, 68);
            this.endlessButton.TabIndex = 4;
            this.endlessButton.Text = "Endless";
            this.endlessButton.UseVisualStyleBackColor = false;
            this.endlessButton.Click += new System.EventHandler(this.endlessButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Yellow;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(863, 553);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(90, 42);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Gill Sans MT", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(812, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(136, 41);
            this.scoreLabel.TabIndex = 7;
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerLabel
            // 
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("Gill Sans MT", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Black;
            this.timerLabel.Location = new System.Drawing.Point(12, 9);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(136, 41);
            this.timerLabel.TabIndex = 6;
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pedestriansParkway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.endlessButton);
            this.Controls.Add(this.timedButton);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pedestriansParkway";
            this.Text = "Pedestrian\'s Parkway";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pedestriansParkway_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pedestriansParkway_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pedestriansParkway_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button timedButton;
        private System.Windows.Forms.Button endlessButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label timerLabel;
    }
}

