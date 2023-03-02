using AppTest1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    public class ModifyMemberViewModel : BaseViewModel
    {
        public delegate void RetunEventHandler(Member member);
        public event RetunEventHandler RetunEvent;

        private ObservableRangeCollection<Member> _members = new ObservableRangeCollection<Member>();

        public ICommand CancelCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand DeleteCommand { get; }

        //local 변수
        private string _userID;
        private string _userName;
        private string _email;
        private string _telephone;
        private string _registDate;
        //private Member _selectedMember;

        //Property
        public string UserID { get => this._userID; set => SetProperty(ref this._userID, value); }
        public string UserName { get => this._userName; set => SetProperty(ref this._userName, value); }
        public string Email { get => this._email; set => SetProperty(ref this._email, value); }
        public string Telephone { get => this._telephone; set => SetProperty(ref this._telephone, value); }
        public string RegistDate { get => this._registDate; set => SetProperty(ref this._registDate, value); }
        public ObservableRangeCollection<Member> Members { get => _members; set => SetProperty(ref this._members, value); }
        //public Member SelectedMember
        //{
        //    get => _selectedMember;
        //    set
        //    {
        //        SetProperty(ref this._selectedMember, value);

        //        this.UserID = value.UserID;
        //        this.UserName = value.UserName;
        //        this.Email = value.Email;
        //        this.Telephone = value.Telephone;
        //        this.RegistDate = value.RegistDate;
        //    }
        //}

        //MemberViewModel memberViewModel = new MemberViewModel();

        public ModifyMemberViewModel(Member member) 
        {
            //this.SelectedMember = SelectedMember;
            this.UserID = member.UserID;
            this.UserName = member.UserName;
            this.Email = member.Email;
            this.Telephone = member.Telephone;
            this.RegistDate = member.RegistDate;

            ModifyCommand = new Command<object>((obj) => Modify(obj), (obj) => IsControlEnable);
            //DeleteCommand = new Command(() => memberViewModel.Delete(DeleteCommand), () => IsControlEnable);
            CancelCommand = new Command<object>((obj) => Cancel(obj), (obj) => IsControlEnable);
        }

        private void Modify(object obj)
        {
            IsControlEnable = false;
            IsBusy = true;
            (ModifyCommand as Command).ChangeCanExecute();

            Member member = new Member()
            {
                UserID = this.UserID,
                UserName = this.UserName,
                Email = this.Email,
                Telephone = this.Telephone,
                RegistDate = this.RegistDate
            };

            RetunEvent?.Invoke(member); //콜했던 화면으로 데이터 전달

            //팝업창 닫기
            ((Xamarin.CommunityToolkit.UI.Views.Popup)obj).Dismiss(true);

            IsControlEnable = true;
            IsBusy = false;
            (ModifyCommand as Command).ChangeCanExecute();
        }

        private void Cancel(object obj)
        {
            IsControlEnable = false;
            IsBusy = true;
            (CancelCommand as Command).ChangeCanExecute();

            ((Xamarin.CommunityToolkit.UI.Views.Popup)obj).Dismiss(false);


            IsControlEnable = true;
            IsBusy = false;
            (CancelCommand as Command).ChangeCanExecute();
        }
        
    }
}
