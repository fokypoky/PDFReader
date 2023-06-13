using System.Windows.Input;
using Microsoft.Win32;
using PDFReader.Infrastructure.Commands;
using PDFReader.ViewModels.Base;

namespace PDFReader.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private string _filepath;

    public string FilePath
    {
        get => _filepath;
        set => SetField(ref _filepath, value);
    }
    public ICommand OpenFileCommand
    {
        get => new RelayCommand((object parameter) =>
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF (*.pdf)|*.pdf";
            if (fileDialog.ShowDialog() == true)
            {
                FilePath = fileDialog.FileName;
            }
            
        });
    }
}