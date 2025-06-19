using System.Collections.Generic;

namespace Client.Forms
{
    internal class ControlInitialisator
    {
        private static ControlInitialisator instance;
        internal static ControlInitialisator Instance => instance ??= new ControlInitialisator();

        private ControlInitialisator() { }

        internal void InitComboBox<T>(
            ComboBox comboBox,
            IEnumerable<T> items,
            string valueMember,
            string displayMember,
            T defaultItem)
        {
            var itemList = items.ToList();
            itemList.Insert(0, defaultItem);

            comboBox.DataSource = itemList;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.SelectedIndex = 0;
        }
    }
}