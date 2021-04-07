using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;

namespace ViewModelGeneratorSample {
    [GenerateViewModel(ImplementISupportServices = true)]
    public partial class ServicesViewModel {
        [GenerateProperty]
        string _Message;

        IMessageBoxService MessageBoxService { get => ServiceContainer.GetService<IMessageBoxService>(); }

        [GenerateCommand]
        void ShowMessage() => MessageBoxService.ShowMessage("Your message: " + Message, "Login", MessageButton.OK, MessageIcon.Information);
        bool CanShowMessage() => !string.IsNullOrEmpty(Message);
    }
}
