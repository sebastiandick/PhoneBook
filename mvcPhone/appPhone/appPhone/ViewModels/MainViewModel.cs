

namespace appPhone.ViewModels
{
    using appPhone.Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public  List <Phone> ListPhone { get; set; }
        #endregion

        #region ViewModels
        public PhoneBookViewModel phoneBookViewModel { get; set; }
        #endregion

        #region Construtor
        public MainViewModel()
        {
            instance = this;
            phoneBookViewModel = new PhoneBookViewModel();
        } 
        #endregion

        #region Singleton 
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion 
    }
}
