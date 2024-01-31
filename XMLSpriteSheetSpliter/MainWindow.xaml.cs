using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMLSpriteSheetSpliter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false;
        openFileDialog.DefaultExt = ".xml";
        openFileDialog.Filter = "XML documents (.xml)|*.xml";
        bool? result = openFileDialog.ShowDialog();
        if (result == true)
        {
            path.Text = openFileDialog.FileName;
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFolderDialog openFolderDialog = new OpenFolderDialog();
        openFolderDialog.Multiselect = false;
        bool? result = openFolderDialog.ShowDialog();
        if (true)
        {
            Spliter.SplitAndSave(path.Text,openFolderDialog.FolderName);
            MessageBox.Show("Success!");
        }

    }
}