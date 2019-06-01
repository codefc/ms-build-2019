using Fumec.Mobile.Model;
using Fumec.Mobile.Service;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Fumec.Mobile.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IFumecAPIService _service;
        private bool _isBusy;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Repository> Repositories { get; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetValue(value, ref _isBusy);
            }

        }

        public MainPageViewModel()
        {
            Repositories = new ObservableCollection<Repository>();
            _service = RestService.For<IFumecAPIService>("http://"); // Criando uma instância a partir do REFIT para a interface IFumecAPIService
        }

        public async Task LoadAsync()
        {
            if (IsBusy) return;

            try
            {
                var repos = await _service.GetRepositories();

                foreach (var r in repos)
                    Repositories.Add(r);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }

        }

        protected void SetValue<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            field = value;
        }

    }
}
