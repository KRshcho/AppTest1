using AppTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    public class FindAddressViewModel :BaseViewModel
    {
        private ObservableRangeCollection<Address> _address = new ObservableRangeCollection<Address>();

        public ObservableRangeCollection<Address> Address { get => _address; set => SetProperty(ref this._address, value); }
        public FindAddressViewModel()
        {
            
        }
    }
}