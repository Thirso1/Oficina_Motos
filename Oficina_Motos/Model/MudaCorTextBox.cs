using System;
using System.Drawing;
using System.Windows.Forms;

namespace Oficina_Motos.Model
{
    public static class MudaCorTextBox
    {
        public static void RegisterFocusEvents(Control.ControlCollection controls)
        {

            foreach (Control control in controls)
            {
                if ((control is TextBox) ||
                  (control is RichTextBox) ||
                  (control is ComboBox) ||
                  (control is MaskedTextBox))
                {
                    control.Enter += new EventHandler(controlFocus_Enter);
                    control.Leave += new EventHandler(controlFocus_Leave);
                }

                RegisterFocusEvents(control.Controls);
            }
        }

        static void controlFocus_Leave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        static void controlFocus_Enter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.Yellow;
        }
    }
}
