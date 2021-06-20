using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.Model
{
    class MudaParaMaiuscula
    {
        static string texto_global = "";
        public static void RegisterKeyUpEvents(Control.ControlCollection controls, string texto)
        {
            texto_global = texto;
            foreach (Control control in controls)
            {
                if ((control is TextBox))
                {
                    control.KeyUp += new KeyEventHandler(controlKeyUp);
                }

                RegisterKeyUpEvents(control.Controls, texto_global);
            }
        }

        static void controlKeyUp(object sender, EventArgs e)
        {
            (sender as Control).Text = texto_global.ToUpper();
        }
    }
}
