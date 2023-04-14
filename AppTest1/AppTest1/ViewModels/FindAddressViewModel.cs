using Acr.UserDialogs;
using AppTest1.APIModel.Request;
using AppTest1.Models;
using AppTest1.WebServiceHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    public class FindAddressViewModel :BaseViewModel
    {
        private readonly IUserDialogs _userDialogs;
        private ObservableRangeCollection<PostOffice> _postOffice = new ObservableRangeCollection<PostOffice>();

        public ICommand GetDataCommand { get; }

        private string _address;
        private string _ZipNumber;
        private string _Doro;
        private string _JiBuen;

        public string Address { get { return _address; } set => SetProperty(ref this._address, value); }
        public string ZipNumber { get { return _ZipNumber; } set => SetProperty(ref this._ZipNumber, value); }
        public string DoRo { get { return _Doro; } set => SetProperty(ref this._Doro, value); }
        public string JiBuen { get { return _JiBuen; } set => SetProperty(ref this._JiBuen, value); }

        public ObservableRangeCollection<PostOffice> PostOffice { get => _postOffice; set => SetProperty(ref this._postOffice, value); }
        
        public FindAddressViewModel()
        {
            GetDataCommand = new Command(() => GetData(), () => IsControlEnable);

            this._userDialogs = UserDialogs.Instance;
        }

        public void GetData()
        {
            IsControlEnable = false;
            IsBusy = true;
            (GetDataCommand as Command).ChangeCanExecute();
            
            var req = new ReqPostOffice
            {
                address = this.Address
            };

            try
            {
                var result = APIServiceHandler.Instance.FindPostAddress(APIServiceConfig.API_POSTOFFICE, req);

                if (result.ResultCode != "00")
                {
                    _userDialogs.Toast(new ToastConfig(string.Format("{0}: {1}", result.ResultCode, result.ResultMessage)) { BackgroundColor = Color.Red, Duration = TimeSpan.FromSeconds(3) });

                    IsControlEnable = true;
                    IsBusy = false;
                    (GetDataCommand as Command).ChangeCanExecute();
                    return;
                }

                StringReader sr = new StringReader(result.message);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);

                if (ds.Tables[2].Rows.Count > 0)
                {
                    this.PostOffice.Clear();
                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        PostOffice postOffice = new PostOffice
                        {
                            ZipNumber = row["postcd"].ToString(),
                            DoRo = row["address"].ToString(),
                            JiBuen = row["addrjibun"].ToString()
                        };

                        this.PostOffice.Add(postOffice);
                    }                    
                }
            }
            catch (Exception ex)
            {
                _userDialogs.Toast(new ToastConfig(string.Format("{0}: {1}", "조회중 예외 발생", ex.Message)) { BackgroundColor = Color.Red, Duration = TimeSpan.FromSeconds(3) });
            }
            
            //var data = new PostOffice
            //{ 
            //    ZipNumber = result.
            //};

            IsControlEnable = true;
            IsBusy = false;
            (GetDataCommand as Command).ChangeCanExecute();
        }
    }
}