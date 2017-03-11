using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceNavigator
{
    public partial class SpaceNavigatorForm : Form
    {
        Spaceship ship;
        HashSet<UFO> UFOs = new HashSet<UFO>();

        public SpaceNavigatorForm()
        {
            InitializeComponent();
        }

        private void SpaceNavigatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ship = new Spaceship(this.DisplayRectangle);
            //UFOs.Add(new UFO(this.DisplayRectangle));

            AnimationTimer.Start();
            UFOTimer.Start();
        }

        private void SpaceNavigatorForm_Paint(object sender, PaintEventArgs e)
        {
            ship.Draw(e.Graphics);

            foreach(UFO ufo in UFOs)
            {
                ufo.Draw(e.Graphics);
            }
        }

        private void SpaceNavigatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        ship.Move(Spaceship.Direction.Left);
                        break;
                    }
                case Keys.Right:
                    {
                        ship.Move(Spaceship.Direction.Right);
                        break;
                    }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            foreach(UFO ufo in UFOs)
            {
                ufo.Move();
            }

            Invalidate();
        }

        private void UFOTimer_Tick(object sender, EventArgs e)
        {
            UFOs.Add(new UFO(this.DisplayRectangle));
        }
    }
}
