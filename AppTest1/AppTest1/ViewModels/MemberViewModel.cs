using AppTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppTest1.ViewModels
{
    public class MemberViewModel : BaseViewModel
    {
        INavigation Navigation => Application.Current.MainPage.Navigation;

        private ObservableRangeCollection<Member> _members = new ObservableRangeCollection<Member>();
        private ObservableRangeCollection<object> _selectedMembers = new ObservableRangeCollection<object>();

        //Command
        public ICommand RegistCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand SelectionChangedCommand { get; }
        public ICommand RowTappedCommand { get; }

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
        public ObservableRangeCollection<object> SelectedMembers
        {
            get => _selectedMembers;
            set
            {
                SetProperty(ref this._selectedMembers, value);

                //Clear();

                //this.UserID = (value. as Member).UserID;
                //this.UserName = value.UserName;
                //this.Email = value.Email;
                //this.Telephone = value.Telephone;
                //this.RegistDate = value.RegistDate;
            }
        }

        //SelectionMode="Multiple"에서 작동안함
        public Member SelectedMember
        {
            get => _selectedMember;
            set
            {
                SetProperty(ref this._selectedMember, value);

                Clear();

                this.UserID = value.UserID;
                this.UserName = value.UserName;
                this.Email = value.Email;
                this.Telephone = value.Telephone;
                this.RegistDate = value.RegistDate;
            }
        }

        public MemberViewModel()
        {
            RegistCommand = new Command(() => Regist(), () => IsControlEnable);
            ModifyCommand = new Command(() => Modify(), () => IsControlEnable);
            DeleteCommand = new Command(() => Delete(), () => IsControlEnable);
            ClearCommand = new Command(() => Clear(), () => IsControlEnable);
            SelectionChangedCommand = new Command<Member>((obj) => SelectionChanged(obj), (obj) => IsControlEnable);
            RowTappedCommand = new Command<Member>((obj) => RowTapped(obj), (obj) => IsControlEnable);
        }

        private void RowTapped(Member obj)
        {
            IsControlEnable = false;
            IsBusy = true;
            (RowTappedCommand as Command).ChangeCanExecute();


            Console.WriteLine(obj.UserID);


            IsControlEnable = true;
            IsBusy = false;
            (RowTappedCommand as Command).ChangeCanExecute();
        }

        //SelectionMode="Multiple" 에서 작동 안함.
        private void SelectionChanged(Member obj)
        {
            if (obj != null)
            {
                Console.WriteLine(obj.UserID);
            }            
        }

        private void Clear()
        {
            IsControlEnable = false;
            IsBusy = true;
            (ClearCommand as Command).ChangeCanExecute();

            this.UserID = string.Empty;
            this.UserName = string.Empty;
            this.Telephone = string.Empty;
            this.RegistDate = string.Empty;
            this.Email = string.Empty;

            IsControlEnable = true;
            IsBusy = false;
            (ClearCommand as Command).ChangeCanExecute();
        }

        private void Regist()
        {
            IsControlEnable = false;
            IsBusy = true;
            (RegistCommand as Command).ChangeCanExecute();

            //ToDo
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

        private void Modify()
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

        private void Delete()
        {
            IsControlEnable = false;
            IsBusy = true;
            (DeleteCommand as Command).ChangeCanExecute();

            //ToDo
            if (SelectedMembers != null)
            {
                foreach (Member member in SelectedMembers)
                {
                    Members.Remove(member);
                }
            }

            IsControlEnable = true;
            IsBusy = false;
            (DeleteCommand as Command).ChangeCanExecute();
        }
    }
}
