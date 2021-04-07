using DevExpress.Mvvm;
using System;
using System.Windows;

namespace ViewModelGeneratorSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var source = new[] {
                new SampleInfo(typeof(LoginView), "Overview"),
                new SampleInfo(typeof(PropertiesView), "Bindable Properties"),
                new SampleInfo(typeof(CommandsView), "Commands"),
                new SampleInfo(typeof(AsyncCommandsView), "Async Commands"),
                new SampleInfo(typeof(DataErrorInfoView), "IDataErrorInfo"),
                new SampleInfo(typeof(ServicesView), "ISupportServices"),
            };
            Samples.ItemsSource = source;
            Samples.SelectedItem = source[0];
        }
        void Samples_SelectedItemChanged(object sender, DevExpress.Xpf.Accordion.AccordionSelectedItemChangedEventArgs e) {
            content.Content = Activator.CreateInstance(((SampleInfo)Samples.SelectedItem).ViewType);
        }
    }

    public class SampleInfo : BindableBase {
        public SampleInfo(Type viewType, string description) {
            ViewType = viewType;
            Description = description;
        }
        public Type ViewType { get; }
        public string Description { get; }
    }
}
