﻿using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TorneoPredicciones.Services;

namespace TorneoPredicciones.ViewModels
{
    public class MenuItemViewModel
    {
        #region Atributos

        private NavigationService navigationService;
        private DataService dataService;

        #endregion

        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private async void Navigate()
        {var mainViewModel = MainViewModel.GetInstance();
            if (PageName == "LoginPage")
            {
                
                mainViewModel.CurrentUser.IsRemembered = false;
                dataService.Update(mainViewModel.CurrentUser);
                navigationService.SetMainPage("LoginPage");
            }
            else
            {
                switch (PageName)
                {
                    case "SelectTournamentPage":
                        mainViewModel.SelectTournament=new SelectTournamentViewModel();
                        await navigationService.Navigate(PageName);
                        break;
                    default:
                      
                        break;
                        
                }
                //var parameter = dataService.First<Parameter>(false);
                //parameter.Option = Title;
                //dataService.Update(parameter);
               
            }
        }

        #endregion

        #region Cosntructores

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
            dataService= new DataService();
        }

        #endregion

    }
}
