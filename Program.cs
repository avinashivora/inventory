using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static void Redirect(string formName, Form currForm, bool toOpenCurrForm)
        {
            Type formType = Type.GetType("inventory." + formName);
            if (formType != null && formType.IsSubclassOf(typeof(Form)))
            {
                Form next = (Form)Activator.CreateInstance(formType);
                next.StartPosition = FormStartPosition.Manual;
                next.Location = currForm.Location;
                if (toOpenCurrForm)
                {
                    next.FormClosed += (sender, e) =>
                    {
                        currForm.Show();
                    };
                }
                next.Show();
                currForm.Hide();
            }
            else
            {
                MessageBox.Show("Invalid form name or form type.");
            }
        }
    }
}
