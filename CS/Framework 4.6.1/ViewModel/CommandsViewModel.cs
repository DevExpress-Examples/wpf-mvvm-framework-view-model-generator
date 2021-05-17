using DevExpress.Mvvm.CodeGenerators;
using System.Windows;

namespace ViewModelGeneratorSample {
    [GenerateViewModel]
    public partial class CommandsViewModel {
        [GenerateProperty]
        bool _CanExecuteSaveCommand;
        [GenerateProperty]
        string _FileName;

        [GenerateCommand]
        void Save() => MessageBox.Show("Action: Save");
        bool CanSave() => CanExecuteSaveCommand;

        [GenerateCommand]
        void Open(string fileName) => MessageBox.Show(string.Format("Action: Open {0}", fileName));
        bool CanOpen(string fileName) => !string.IsNullOrEmpty(fileName);

        public CommandsViewModel() => CanExecuteSaveCommand = true;
    }
}
