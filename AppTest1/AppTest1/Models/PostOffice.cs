using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AppTest1.Models
{
    public class PostOffice : ObservableObject
    {
        private string _ZipNumber;
        private string _Doro;
        private string _JiBuen;

        public string ZipNumber { get { return _ZipNumber; } set => SetProperty(ref this._ZipNumber, value); }
        public string DoRo { get { return _Doro; } set => SetProperty(ref this._Doro, value); }
        public string JiBuen { get { return _JiBuen; } set => SetProperty(ref this._JiBuen, value); }
    }
}
