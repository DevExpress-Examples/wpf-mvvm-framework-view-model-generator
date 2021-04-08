using DevExpress.Mvvm.ModuleInjection;
using System.Windows;

namespace ViewModelGeneratorSample {
    public partial class App : Application {
        Bootstrapper Bootstrapper { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Bootstrapper = new Bootstrapper();
            Bootstrapper.Run();
        }
    }

    public class Bootstrapper {
        IModuleManager Manager { get { return ModuleManager.DefaultManager; } }
        void RegisterModules() {
            Manager.Register(Regions.ViewContent, new Module(AppModules.Login,         () => new LoginViewModel(),         typeof(LoginView)));
            Manager.Register(Regions.ViewContent, new Module(AppModules.Property,      () => new PropertiesViewModel(),    typeof(PropertiesView)));
            Manager.Register(Regions.ViewContent, new Module(AppModules.Command,       () => new CommandsViewModel(),      typeof(CommandsView)));
            Manager.Register(Regions.ViewContent, new Module(AppModules.AsyncCommand,  () => new AsyncCommandsViewModel(), typeof(AsyncCommandsView)));
            Manager.Register(Regions.ViewContent, new Module(AppModules.DataErrorInfo, () => new DataErrorInfoViewModel(), typeof(DataErrorInfoView)));
            Manager.Register(Regions.ViewContent, new Module(AppModules.Services,      () => new ServicesViewModel(),      typeof(ServicesView)));

            Manager.Register(Regions.Navigation, new Module(AppModules.Login,         () => new NavigationItem(AppModules.Login),         typeof(NavigationView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.Property,      () => new NavigationItem(AppModules.Property),      typeof(NavigationView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.Command,       () => new NavigationItem(AppModules.Command),       typeof(NavigationView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.AsyncCommand,  () => new NavigationItem(AppModules.AsyncCommand),  typeof(NavigationView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.DataErrorInfo, () => new NavigationItem(AppModules.DataErrorInfo), typeof(NavigationView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.Services,      () => new NavigationItem(AppModules.Services),      typeof(NavigationView)));
        }
        void InjectModules() {
            Manager.Inject(Regions.Navigation, AppModules.Login);
            Manager.Inject(Regions.Navigation, AppModules.Property);
            Manager.Inject(Regions.Navigation, AppModules.Command);
            Manager.Inject(Regions.Navigation, AppModules.AsyncCommand);
            Manager.Inject(Regions.Navigation, AppModules.DataErrorInfo);
            Manager.Inject(Regions.Navigation, AppModules.Services);
        }
        void ConfigureNavigation() => Manager.GetEvents(Regions.Navigation).Navigation += OnNavigation;
        void ShowMainWindow() {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
        }
        void ShowOverview() => Manager.InjectOrNavigate(Regions.ViewContent, AppModules.Login);
        void OnNavigation(object sender, NavigationEventArgs e) {
            if(e.NewViewModelKey != null)
                Manager.InjectOrNavigate(Regions.ViewContent, e.NewViewModelKey);
        }

        public void Run() {
            RegisterModules();
            InjectModules();
            ConfigureNavigation();
            ShowMainWindow();
            ShowOverview();
        }
    }
}
