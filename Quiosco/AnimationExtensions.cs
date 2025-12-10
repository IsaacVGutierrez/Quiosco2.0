using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiosco
{
    public static class AnimationExtensions
    {
        // Fade background desde un color con alpha 0 hasta el color full
        public static async Task FadeBackgroundAsync(this Control ctrl, Color targetColor, int durationMs)
        {
            if (ctrl == null) return;

            // empezamos con alpha 0
            int steps = Math.Max(1, durationMs / 10);
            for (int s = 0; s <= steps; s++)
            {
                double t = (double)s / steps; // 0..1
                int a = (int)(t * targetColor.A);
                int r = targetColor.R;
                int g = targetColor.G;
                int b = targetColor.B;

                // asignar color interpolado
                ctrl.BackColor = Color.FromArgb(a, r, g, b);

                // si el control estaba invisible, hacerlo visible (para ver el fade)
                if (!ctrl.Visible) ctrl.Visible = true;

                await Task.Delay(10);
            }

            // asegurar color final
            ctrl.BackColor = targetColor;
        }

        public static async Task FadeOutBackgroundAsync(this Control ctrl, int durationMs)
        {
            if (ctrl == null) return;

            Color start = ctrl.BackColor;
            int steps = Math.Max(1, durationMs / 10);
            for (int s = 0; s <= steps; s++)
            {
                double t = 1.0 - (double)s / steps; // 1..0
                int a = (int)(t * start.A);
                ctrl.BackColor = Color.FromArgb(a, start.R, start.G, start.B);
                await Task.Delay(10);
            }

            ctrl.Visible = false;

        }

        public static async void OpacityAnimation(this Control ctrl, double from, double to, int duration)
        {
            double step = (to - from) / (duration / 10.0);

            for (double i = from; (step > 0 ? i <= to : i >= to); i += step)
            {
                ctrl.BackColor = Color.FromArgb((int)(255 * i), ctrl.BackColor);
                await Task.Delay(10);
            }
        }



    }
}
