using System.Windows.Forms;
using System.Drawing;

namespace Client.Forms
{
    internal static class FormValidator
    {
        private static readonly Color DefaultColor = Color.White;
        private static readonly Color ErrorColor = Color.FromArgb(255, 220, 220);

        internal static bool ValidateTextFields(params TextBox[] fields)
        {
            bool isValid = true;

            foreach (var field in fields)
            {
                field.BackColor = DefaultColor;

                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    field.BackColor = ErrorColor;
                    isValid = false;
                }
            }

            return isValid;
        }

        internal static bool ValidateComboBoxes(params ComboBox[] boxes)
        {
            bool isValid = true;

            foreach (var box in boxes)
            {
                box.BackColor = DefaultColor;

                if (box.SelectedIndex <= 0)
                {
                    box.BackColor = ErrorColor;
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
