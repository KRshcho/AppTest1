# AppTest1
자마린 스터디 프로젝트

NuGet에서 아래 패키지를 설치해야 MVVM 형식에서 ObservableRangeCollection, SetProperty 등 사용 가능
Xamarin.CommunityToolkit

<MVVM>
Models
View
ViewModels

Models
 - 말그대로 모델(변수, 리스트 등)
Views
 - 앱에서 보여지는 UI
 - Views.xaml.cs에서는 특별한 경우 아닌 이상 코딩 안함
 - ViewModels와 바인딩
ViewModels
 - View와 연결(바인딩)되어 해당 뷰에서 동작하도록 코딩
 
<*.xaml>
 xaml 파일은 앱 구동 시켜놓은 상태에서 수정하면 바로 적용되어 수정한 것을 바로 확인 가능
 
AppTest1.Android
 - AndroidManifest.xml
 - htts가 기본연결이고 http 연결하려면 <application></application>에 아래 항목 추가
 - android:usesCleartextTraffic="true"
