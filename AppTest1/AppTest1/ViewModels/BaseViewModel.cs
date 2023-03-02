using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    /// <summary>
    /// ObservableObject를 상속받아서 사용한다.(INotifyPropertyChanged 포함되어 있음) application에서 ViewModel의 변화 등을 감지하여 View와 함께 사용할 수 있도록 한다.
    /// </summary>
    public class BaseViewModel : ObservableObject
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public BaseViewModel() { }

        // 모든 뷰모델에서 공통적으로 사용하는 컨트롤
        bool isBusy = false;
        bool isEnabled = true;
        bool _isControlEnable = true;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        public bool IsControlEnable
        {
            get => _isControlEnable;
            set => SetProperty(ref this._isControlEnable, value);
        }

        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
