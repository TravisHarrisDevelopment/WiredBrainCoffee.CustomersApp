using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public CustomersViewModel CustomersViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }

        public DelegateCommand  SelectViewModelCommand { get; }

        public ViewModelBase? SelectedViewModel 
        { 
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }    
        }

        public MainViewModel(CustomersViewModel customersViewModel,
            ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        private async void SelectViewModel(object? param)
        {
            SelectedViewModel = param as ViewModelBase;
            await LoadAsync();
        }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }
}
