using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FFXIVMountTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        ObservableCollection<MountClass> favMounts = new ObservableCollection<MountClass>();
        DatabaseManager dbManager = new DatabaseManager();
        public FavouritesPage(/*ObservableCollection<MountClass> list*/)
        {
            InitializeComponent();
            //favMounts = list;
        }

        protected async override void OnAppearing()
        {
            favMounts = await dbManager.CreateTable();
            mountFavList.ItemsSource = favMounts;
            base.OnAppearing();
        }

        private async void deleteFromFav(object sender, EventArgs e)
        {
            MountClass mount = (sender as MenuItem).CommandParameter as MountClass;
            dbManager.DeleteMount(mount);
            
            favMounts = await dbManager.CreateTable();
            mountFavList.ItemsSource = null;
            mountFavList.ItemsSource = favMounts;
        }

        private void mountFavList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            int m_id = (e.SelectedItem as MountClass).id;
            Navigation.PushAsync(new DetailsPage(m_id));
        }
    }
}