using System.Windows;

namespace ErrorListTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddSampleData_OnClick(object sender, RoutedEventArgs e)
        {
            errorList.AddError("Error unable to do something \"Name: Write PHP\"");
            errorList.AddError("Error unable to do something \"Name: Write Flash\"");
            errorList.AddWarning("Error unable to do something \"Name: Program in F#, yet\"");
            errorList.AddInformation("Note: I need a better hobby than wasting my lunch coding..");
        }

        private void BtnRemoveSampleData_OnClick(object sender, RoutedEventArgs e)
        {
            errorList.ClearAll();
        }
    }
}
