namespace SpaceNavigator
{
    partial class SpaceNavigatorForm
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
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.AsteroidTimer = new System.Windows.Forms.Timer(this.components);
            this.HealthTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 16;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // AsteroidTimer
            // 
            this.AsteroidTimer.Interval = 2000;
            this.AsteroidTimer.Tick += new System.EventHandler(this.AsteroidTimer_Tick);
            // 
            // HealthTimer
            // 
            this.HealthTimer.Interval = 20000;
            this.HealthTimer.Tick += new System.EventHandler(this.HealthTimer_Tick);
            // 
            // SpaceNavigatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SpaceNavigator.Properties.Resources.Stars;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.DoubleBuffered = true;
            this.Name = "SpaceNavigatorForm";
            this.Text = "Space Navigator";
            this.Load += new System.EventHandler(this.SpaceNavigatorForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceNavigatorForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceNavigatorForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Timer AsteroidTimer;
        private System.Windows.Forms.Timer HealthTimer;
    }
}

