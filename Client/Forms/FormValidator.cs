using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Client.Forms
{
    internal class FormValidator
    {
        private static FormValidator instance;
        internal static FormValidator Instance => instance ??= new FormValidator();

        private FormValidator() { }

        private readonly Color DefaultColor = Color.White;
        private readonly Color ErrorColor = Color.FromArgb(255, 220, 220);

        internal bool ValidateTextFields(params TextBox[] fields)
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

        internal bool ValidateComboBoxes(params ComboBox[] boxes)
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

        internal void ValidateWithRulesOrThrow(params (TextBox textBox, Func<string, bool> rule, string errorMessage)[] validations)
        {
            foreach (var (textBox, rule, errorMessage) in validations)
            {
                textBox.BackColor = DefaultColor;

                if (!rule(textBox.Text))
                {
                    textBox.BackColor = ErrorColor;
                    throw new ArgumentException(errorMessage);
                }
            }
        }

        internal bool IsValidEmail(string input) =>
            Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        internal bool HasMinLength(string input, int minLength) =>
            !string.IsNullOrWhiteSpace(input) && input.Length >= minLength;

        internal bool IsExactLength(string input, int length) =>
            input?.Length == length;

        internal bool IsValidDoubleGreaterThanZero(string input) =>
            double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double value) && value > 0;
    }
}
