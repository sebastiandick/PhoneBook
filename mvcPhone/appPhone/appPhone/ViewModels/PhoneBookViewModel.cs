namespace appPhone.ViewModels
{
    using appPhone.Models;
    using appPhone.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class PhoneBookViewModel:BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Phone> phones;
        #endregion

        #region Properties
        public ObservableCollection<Phone> Phones
        {
            get { return this.phones; }
            set { SetValue(ref this.phones, value); }
        }
        #endregion

        #region Constructor
        public PhoneBookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPhones();
        }
        #endregion

        #region Methods
        private async void LoadPhones()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet Error Connection",
                    connection.Message,
                    "Accept"
                    );
                return;
            }

            var responce = await apiService.GetList<Phone>(
                "http://localhost:51897/", //base
                "api/",                    //prefijo
                "Phones"                   //controlador
                );

            if(!responce.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Phone Service Error",
                    responce.Message,
                    "Accept"
                    );
                return;
            }

            MainViewModel main = MainViewModel.GetInstance();
            main.ListPhone = (List<Phone>)responce.Result;

            this.Phones = new ObservableCollection<Phone>(ToPhoneCollect());
        }

        private IEnumerable<Phone> ToPhoneCollect()
        {
            ObservableCollection<Phone> collection = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListPhone)
            {
                Phone phone = new Phone();
                phone.PhoneID = lista.PhoneID;
                phone.Name = lista.Name;
                phone.Type = lista.Type;
                phone.Contact = lista.Contact;
                collection.Add(phone);
            }

            return (collection);
        }
        #endregion
    }
}