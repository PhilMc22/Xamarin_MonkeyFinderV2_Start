using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

using System.Linq;
using MonkeyFinder.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace MonkeyFinder.ViewModel
{
    public class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; }
        public Command GetMonkeysCommand { get; }
        public MonkeysViewModel()
        {
            Title = "Monkey Finder";
            Monkeys = new ObservableCollection<Monkey>();
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        }
        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var monkeys = await DataService.GetMonkeysASync();
                Monkeys.Clear();
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
