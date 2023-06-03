using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ref link:https://www.youtube.com/watch?v=Lu2Wq0UJrn8&list=PLAIBPfq19p2EJ6JY0f5DyQfybwBGVglcR&index=65
// Creating a 16x16 icon for your form

namespace Programmatically_create_a_form_icon
{
    public partial class Form1 : Form
    {
        private bool _showInner;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetIcon()
        {
            // Icon displays at 16x16
            Bitmap canvas = new Bitmap(16, 16);

            using(Graphics GFX = Graphics.FromImage(canvas))
            {
                // Increase quality
                //GFX.SmoothingMode = SmoothingMode.AntiAlias;
                GFX.CompositingQuality = CompositingQuality.HighQuality;

                GFX.FillEllipse(Brushes.YellowGreen, 0, 0, canvas.Width, canvas.Height);

                if((_showInner = !_showInner))
                {
                    GFX.FillEllipse(Brushes.Gray, 5, 5, canvas.Width - 5, canvas.Height - 5);
                }

                this.Icon = Icon.FromHandle(canvas.GetHicon());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetIcon();
        }
    }
}
