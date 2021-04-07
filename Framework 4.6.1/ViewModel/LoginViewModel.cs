using DevExpress.Mvvm.CodeGenerators;

namespace ViewModelGeneratorSample {
    [GenerateViewModel]
    public partial class LoginViewModel {
        [GenerateProperty]
        string _UserName;
        [GenerateProperty]
        string _Status;

        [GenerateCommand]
        void Login() => Status = "User: " + UserName;
        bool CanLogin() => !string.IsNullOrEmpty(UserName);
    }
}
