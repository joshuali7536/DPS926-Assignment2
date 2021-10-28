using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FFXIVMountTracker
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<MountClass> favList = new ObservableCollection<MountClass>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage(favList));
        }

        private void FavButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouritesPage(/*favList*/));
        }
    }
}
