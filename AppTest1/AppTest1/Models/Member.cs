using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AppTest1.Models
{
    public class Member : ObservableObject
    {
        private string _userID;
        private string _userName;
        private string _email;
        private string _telephone;
        private string _registDate;

        public string UserID { get => this._userID; set => SetProperty(ref this._userID, value); }
        public string UserName { get => this._userName; set => SetProperty(ref this._userName, value); }
        public string Email { get => this._email; set => SetProperty(ref this._email, value); }
        public string Telephone { get => this._telephone; set => SetProperty(ref this._telephone, value); }
        public string RegistDate { get => this._registDate; set => SetProperty(ref this._registDate, value); }

    }
}
