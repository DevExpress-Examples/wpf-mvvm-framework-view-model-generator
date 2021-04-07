using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;

namespace ViewModelGeneratorSample {
    [GenerateViewModel]
    public partial class AsyncCommandsViewModel {
        [GenerateProperty]
        int _Progress;

        [GenerateCommand]
        async Task CalculateAsync() {
            for(int i = 0; i <= 100; i++) {
                if(CalculateAsyncCommand.IsCancellationRequested) {
                    Progress = 0;
                    return;
                }
                Progress = i;
                await Task.Delay(20);
            }
        }
    }
}
