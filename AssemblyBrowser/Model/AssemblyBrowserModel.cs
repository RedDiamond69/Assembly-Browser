using AssemblyAnalyzer.Info;
using AssemblyBrowser.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.Model
{
    public class AssemblyBrowserModel : INotifyPropertyChanged
    {
        private readonly AssemblyAnalyzer.AssemblyAnalyzer _assemblyAnalyzer;
        private AssemblyVM _assemblyVM;
        public event PropertyChangedEventHandler PropertyChanged;

        public AssemblyBrowserModel() => _assemblyAnalyzer = AssemblyAnalyzer.AssemblyAnalyzer.GetInstance();

        public AssemblyVM AssemblyVM
        {
            get => _assemblyVM;
            private set
            {
                if (_assemblyVM != value)
                {
                    _assemblyVM = value;
                    RaisePropertyChanged("AssemblyVM");
                }
            }
        }

        public void Open(string asmPath)
        {
            AssemblyInfo assemblyInfo = _assemblyAnalyzer.GetInfo(asmPath);
            AssemblyVM = new AssemblyVM(assemblyInfo);
        }

        public void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, 
            new PropertyChangedEventArgs(property));
    }
}
