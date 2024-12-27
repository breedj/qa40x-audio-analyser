using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class ComboBoxHelper
{
    public static void SelectNearestValue(ComboBox comboBox, double targetValue)
    {
        if (comboBox.Items.Count == 0) return;

        // Find the nearest value
        var nearestItem = comboBox.Items.Cast<KeyValuePair<double, string>>()
            .OrderBy(item => Math.Abs(item.Key - targetValue))
            .FirstOrDefault();

        // Select the nearest value in the ComboBox
        comboBox.SelectedItem = nearestItem;
    }

   

    public static void PopulateComboBox(ComboBox comboBox, List<KeyValuePair<double, string>> items)
    {
        comboBox.Items.Clear();

        foreach (var item in items)
        {
            comboBox.Items.Add(item);
        }

        // Set DisplayMember and ValueMember
        comboBox.DisplayMember = "Value"; // Display the string
        comboBox.ValueMember = "Key";    // Use the integer as the value
    }
}