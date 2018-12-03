using AssemblyBrowser.Model;
using AssemblyBrowser.Command;
using Microsoft.Win32;
using System.ComponentModel;

namespace AssemblyBrowser.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private AssemblyBrowserModel _model;
        public event PropertyChangedEventHandler PropertyChanged;

        public AssemblyVM AssemblyVM
        {
            get => _model.AssemblyVM;
            private set { }
        }
        public Commands OpenAssemblyCommand { get; set; }

        public MainVM()
        {
            _model = new AssemblyBrowserModel();
            OpenAssemblyCommand = new Commands(OpenAssembly);
            _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
        }

        public void OpenAssembly(object param)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog().Value)
                _model.Open(open.FileName);
        }

        public void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, 
            new PropertyChangedEventArgs(property));
    }
}
