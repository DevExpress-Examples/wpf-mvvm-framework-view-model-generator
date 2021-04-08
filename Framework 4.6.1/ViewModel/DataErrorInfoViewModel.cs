using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace ViewModelGeneratorSample {
    [GenerateViewModel(ImplementIDataErrorInfo = true)]
    public partial class DataErrorInfoViewModel {
        [GenerateProperty]
        [Required(ErrorMessage = "Please enter the user name."), StringLength(100, MinimumLength = 5)]
        string _UserName;

        [GenerateCommand]
        void Register() => MessageBox.Show("Registered");
        bool CanRegister() => !IDataErrorInfoHelper.HasErrors(this);
    }
}
