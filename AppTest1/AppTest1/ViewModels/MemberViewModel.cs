using AppTest1.Models;
using AppTest1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    /// <summary>
    /// BaseViewModel을 상속 받는다
    /// </summary>
    public class MemberViewModel : BaseViewModel
    {
        /// <summary>
        /// 해당 앱에서 관찰 대상 모델
        /// </summary>
        private ObservableRangeCollection<Member> _members = new ObservableRangeCollection<Member>();

        public ICommand RegistCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CleareCommand { get; }        
        public ICommand OpenModifyCommand { get; }

        //local 변수
        private string _userID;
        private string _userName;
        private string _email;
        private string _telephone;
        private string _registDate;
        private Member _selectedMember;

        //Property
        public string UserID { get => this._userID; set => SetProperty(ref this._userID, value); }
        public string UserName { get => this._userName; set => SetProperty(ref this._userName, value); }
        public string Email { get => this._email; set => SetProperty(ref this._email, value); }
        public string Telephone { get => this._telephone; set => SetProperty(ref this._telephone, value); }
        public string RegistDate { get => this._registDate; set => SetProperty(ref this._registDate, value); }
        public ObservableRangeCollection<Member> Members { get => _members; set => SetProperty(ref this._members, value); }

        public Member SelectedMember
        {
            get => _selectedMember;
            set
            {
                SetProperty(ref this._selectedMember, value);

                this.UserID = value.UserID;
                this.UserName = value.UserName;
                this.Email = value.Email;
                this.Telephone = value.Telephone;
                this.RegistDate = value.RegistDate;
            }
        }

        

        /// <summary>
        /// 생성자에서 버튼 이벤트 초기화
        /// </summary>
        public MemberViewModel()
        {
            CleareCommand = new Command(() => Clear(), () => IsControlEnable);
            RegistCommand = new Command(() => Regist(), () => IsControlEnable);
            OpenModifyCommand = new Command(() => OpenEditMemeberView(), () => IsControlEnable);
        }

        private void Clear()
        {
            // 버튼 이벤트 시에 항상 시작
            IsControlEnable = false;
            IsBusy = true;
            (CleareCommand as Command).ChangeCanExecute();

            // 실제 동작 구현
            this.UserID = string.Empty; 
            this.UserName = string.Empty;
            this.Email = string.Empty;
            this.Telephone = string.Empty;
            this.RegistDate = string.Empty;

            // 버튼 이벤트 시에 항상 끝
            IsControlEnable= true;
            IsBusy= false;
            (CleareCommand as Command).ChangeCanExecute();
        }

        private void Regist()
        {
            IsControlEnable = false;
            IsBusy = true;
            (RegistCommand as Command).ChangeCanExecute();

            Member member = new Member()
            {
                UserID = this.UserID,
                UserName = this.UserName,
                Email = this.Email,
                Telephone = this.Telephone,
                RegistDate = this.RegistDate
            };

            Members.Add(member);

            IsControlEnable= true;
            IsBusy= false;
            (RegistCommand as Command).ChangeCanExecute();
        }

        public void OpenEditMemeberView()
        {
            ModifyMemberViewModel vm = new ModifyMemberViewModel();
            ModifyMemberView page = new ModifyMemberView();
            page.BindingContext = vm;
            this.Navigation.ShowPopupAsync(page);
        }
    }
}
