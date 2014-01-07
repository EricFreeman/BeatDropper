using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BeatDropper.Helpers
{
    public class Analytics
    {
        private DispatcherTimer fpsTimer = new DispatcherTimer();
        private DateTime lastFpsUpdate;
        private int frameCount;

        public double frameRate;

        public Analytics()
        {
            fpsTimer.Interval = TimeSpan.FromSeconds(1);
            fpsTimer.Tick += new EventHandler(fpsTimer_Tick);
            fpsTimer.Start();
            lastFpsUpdate = DateTime.Now;
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
        }

        // Called every second
        void fpsTimer_Tick(object sender, EventArgs e)
        {
            frameRate = frameCount / (DateTime.Now - lastFpsUpdate).TotalSeconds;
            lastFpsUpdate = DateTime.Now;
            frameCount = 0;
        }

        // Called by the framework on every frame
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            frameCount++;
        }
    }
}
