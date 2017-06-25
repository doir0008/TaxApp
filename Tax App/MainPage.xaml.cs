using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Tax_App
{
    /*
     * An app that calculates sales tax
    */
    public sealed partial class MainPage : Page
    {
        Tax tax;

        public MainPage()
        {
            this.InitializeComponent();
            // Create new obj ref
            tax = new Tax();
        }

        private void purchaseAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            // set text to empty when got focus
            purchaseAmount.Text = string.Empty;
        }

        private void purchaseAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            // set text to calculated amount when lost focus
            purchaseAmount.Text = tax.purchasePrice;
        }

        private void purchaseAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            doCalculation();
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            doCalculation();
        }

        private void doCalculation()
        {
            // determine which radio button is selected
            RadioButton selectedTax = mainStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            // grab the tag value and store it
            string selectedTaxAmount = selectedTax.Tag.ToString();
            // calculate the taxes
            tax.Calculate(purchaseAmount.Text, selectedTaxAmount);
            // set the text labels to new values
            taxAmount.Text = tax.taxAmount;
            totalAmount.Text = tax.totalAmount;
        }
    }
}
