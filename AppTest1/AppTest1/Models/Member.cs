using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AppTest1.Models
{
    /// <summary>
    /// 모델 구성은 아래와 같은 형식으로 한다. ObservableObject를 상속받고, SetProperty 사용한다. 공식처럼 외우자!
    /// </summary>
    public class Member : ObservableObject
    {
        // 내부적으로만 사용되는 변수
        private string _userID;
        private string _userName;
        private string _email;
        private string _telephone;
        private string _registDate;

        // 실제 모델뷰에 전달되는 변수, 값이 바뀔때 SetProperty에서 모델뷰로 노티를 준다
        public string UserID { get { return _userID; } set => SetProperty(ref this._userID, value); }
        public string UserName { get { return _userName; } set => SetProperty(ref this._userName, value); }
        public string Email { get { return _email;} set => SetProperty(ref this._email, value); }
        public string Telephone { get { return _telephone;} set => SetProperty(ref this._telephone, value); }
        public string RegistDate { get { return _registDate;} set => SetProperty(ref this._registDate, value); }
    }
}
