using DevExpress.Mvvm.CodeGenerators;

namespace ViewModelGeneratorSample {
    [GenerateViewModel]
    public partial class PropertiesViewModel {
        [GenerateProperty]
        string _UserName;
        void OnUserNameChanged(string oldValue) => ChangedStatus = string.Format("Old value: '{0}' New value: '{1}'", oldValue, UserName);

        [GenerateProperty(SetterAccessModifier = AccessModifier.Private)]
        string _ChangedStatus;
    }
}
