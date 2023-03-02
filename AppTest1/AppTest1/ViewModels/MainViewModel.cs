using AppTest1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        public ICommand StartCommand { get; }

        public MainViewModel() 
        {
            StartCommand = new Command(() => Start(), () => IsControlEnable);
        }

        private async void Start()
        {
            IsControlEnable = false;
            IsBusy= true;
            (StartCommand as Command).ChangeCanExecute();

            //this.Navigation.InsertPageBefore(new MemberView(), Application.Current.MainPage.Navigation.NavigationStack.Last());
            //this.Navigation.PopAsync();

            var page = new MemberView();
            await this.Navigation.PushAsync(page);

            IsControlEnable = true;
            IsBusy= false;
            (StartCommand as Command).ChangeCanExecute();
        }
    }
}
