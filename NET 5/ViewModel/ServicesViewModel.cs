using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;

namespace ViewModelGeneratorSample {
    [GenerateViewModel(ImplementISupportServices = true)]
    public partial class ServicesViewModel {
        IMessageBoxService MessageBoxService { get => ServiceContainer.GetService<IMessageBoxService>(); }
        
        [GenerateProperty]
        string _Message;

        [GenerateCommand]
        void ShowMessage() => MessageBoxService.ShowMessage("Your message: " + Message, "Login", MessageButton.OK, MessageIcon.Information);
        bool CanShowMessage() => !string.IsNullOrEmpty(Message);
    }
}
