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
        public ICommand StartUserCommand { get; }
        public ICommand FindAddressCommand { get; }

        public MainViewModel() 
        {
            StartUserCommand = new Command(() => StartUser(), () => IsControlEnable);
            FindAddressCommand = new Command(() => FindAddress(), () => IsControlEnable);
        }

        private async void StartUser()
        {
            IsControlEnable = false;
            IsBusy= true;
            (StartUserCommand as Command).ChangeCanExecute();

            // 현재커맨드를 마지막 페이지로 만들고 해당 페이지를 열고 back key를 눌렀을때 앱이 종료 된다.
            //this.Navigation.InsertPageBefore(new MemberView(), Application.Current.MainPage.Navigation.NavigationStack.Last());
            //this.Navigation.PopAsync();

            var page = new MemberView();
            await this.Navigation.PushAsync(page);

            IsControlEnable = true;
            IsBusy= false;
            (StartUserCommand as Command).ChangeCanExecute();
        }

        private async void FindAddress()
        {
            IsControlEnable = false;
            IsBusy = true;
            (FindAddressCommand as Command).ChangeCanExecute();            

            var page = new FindAddressView();
            await this.Navigation.PushAsync(page);

            IsControlEnable = true;
            IsBusy = false;
            (FindAddressCommand as Command).ChangeCanExecute();
        }
    }
}
