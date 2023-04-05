using AppTest1.Models;
using AppTest1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool _isCallBack = false;

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

                //this.UserID = value.UserID;
                //this.UserName = value.UserName;
                //this.Email = value.Email;
                //this.Telephone = value.Telephone;
                //this.RegistDate = value.RegistDate;
            }
        }



        /// <summary>
        /// 생성자에서 버튼 이벤트 초기화
        /// </summary>
        public MemberViewModel()
        {
            CleareCommand = new Command(() => Clear(), () => IsControlEnable);
            RegistCommand = new Command(() => Regist(), () => IsControlEnable);
            //ModifyCommand = new Command(() => Modify(), () => IsControlEnable);
            //DeleteCommand = new Command(() => Delete(), () => IsControlEnable);
            OpenModifyCommand = new Command(() => OpenEditMemeberView(), () => IsControlEnable);
        }

        public void Clear()
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
            IsControlEnable = true;
            IsBusy = false;
            (CleareCommand as Command).ChangeCanExecute();
        }

        public void Regist()
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

            IsControlEnable = true;
            IsBusy = false;
            (RegistCommand as Command).ChangeCanExecute();
        }

        public void Modify(Member editMember)
        {
            IsControlEnable = false;
            IsBusy = true;
            (ModifyCommand as Command).ChangeCanExecute();

            //ToDo
            var member = Members.FirstOrDefault(i => i.UserID == this.UserID);
            if (member != null)
            {
                member.UserName = this.UserName;
                member.Email = this.Email;
                member.Telephone = this.Telephone;
                member.RegistDate = this.RegistDate;
            }

            IsControlEnable = true;
            IsBusy = false;
            (ModifyCommand as Command).ChangeCanExecute();
        }

        //public void Delete(ICommand deleteCommand)
        //{
        //    IsControlEnable = false;
        //    IsBusy = true;
        //    (deleteCommand as Command).ChangeCanExecute();

        //    //ToDo
        //    if (SelectedMember != null)
        //    {
        //        Members.Remove(SelectedMember);
        //    }

        //    IsControlEnable = true;
        //    IsBusy = false;
        //    (deleteCommand as Command).ChangeCanExecute();
        //}

        public void OpenEditMemeberView()
        {
            if (_isCallBack) return;

            IsControlEnable = false;
            IsBusy = true;
            (OpenModifyCommand as Command).ChangeCanExecute();

            // 호출하는 viewModel에 returnEvent를 할당 할 수 있음
            ModifyMemberViewModel vm = new ModifyMemberViewModel(SelectedMember);
            vm.RetunEvent += Vm_RetunEvent;            

            ModifyMemberView page = new ModifyMemberView();
            page.BindingContext = vm;
            this.Navigation.ShowPopupAsync(page);

            IsControlEnable = true;
            IsBusy = false;
            (OpenModifyCommand as Command).ChangeCanExecute();
        }

        

        private void Vm_RetunEvent(Member member, string feature)
        {
            _isCallBack = true;
            //this.SelectedMember = member; //SelectionChangedCommand를 사용하기 대문에 무한 루프 발생

            this.UserID = member.UserID;
            this.UserName = member.UserName;
            this.Email = member.Email;
            this.Telephone = member.Telephone;
            this.RegistDate = member.RegistDate;

            var mem = Members.FirstOrDefault(i => i.UserID == member.UserID);
            if (feature == "modi")
            {
                if (mem != null)
                {
                    mem.UserName = member.UserName;
                    mem.Email = member.Email;
                    mem.Telephone = member.Telephone;
                    mem.RegistDate = member.RegistDate;
                }
            }
            else if (feature == "del")
            {
                if (mem != null)
                {
                    mem.UserName = member.UserName;
                    mem.Email = member.Email;
                    mem.Telephone = member.Telephone;
                    mem.RegistDate = member.RegistDate;
                }

                Members.Remove(mem);
            }
            else { }

            _isCallBack = false;
        }
    }
}
