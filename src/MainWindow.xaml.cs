using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchAThing.Sci.GUI.Examples
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            physicalQuantityCbox.ItemsSource = PQCollection.PhysicalQuantities;

            sciTextBox.Value = new Measure(123.4, MUCollection.Length.mm);
            sciTextBox.LostFocus += SciTextBox_LostFocus;
            sciTextBox.ValueChanged += SciTextBox_ValueChanged;
        }

        private void SciTextBox_ValueChanged(SciTextBox sender, Measure measure)
        {
            logTbox.Text = measure.ToString();
        }

        private void SciTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"measure = [{sciTextBox.Value}]");
        }
    }

}
