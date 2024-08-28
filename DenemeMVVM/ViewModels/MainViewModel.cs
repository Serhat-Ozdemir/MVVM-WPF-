using DenemeMVVM.Stores;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace DenemeMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore  navigation) 
        {
            setLang(Properties.Settings.Default.lang);
            _navigationStore = navigation;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private ComboBoxItem _selectedLanguage;
        public ComboBoxItem SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
                setLang(Convert.ToString(SelectedLanguage.Tag));
            }
        }

        private void setLang(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            Application.Current.Resources.MergedDictionaries.Clear();
            ResourceDictionary redict = new ResourceDictionary()
            {
                Source = new Uri($"/Dictionary-{lang}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(redict);

            Properties.Settings.Default.lang = lang;
            Properties.Settings.Default.Save();
        }
    }
}
