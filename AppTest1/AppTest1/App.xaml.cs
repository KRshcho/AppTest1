using AppTest1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest1
{
    public partial class App : Application
    {
        /// <summary>
        /// 실제로 app이 시작 되는 부분!
        /// </summary>
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            // 아래 MainPage는 프로젝트 생성시 만들어지는 MainPage.xaml이 아니라 Application 시작 페이지를 의미 (Application.Current.MainPage)
            // 시작하기 원하는 View를 지정한다.
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
