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
    public partial class SearchPage : ContentPage
    {
        string query;
        ObservableCollection<MountClass> mounts;
        ObservableCollection<MountClass> favList;
        NetworkingManager manager = new NetworkingManager();
        DatabaseManager dbManager = new DatabaseManager();
        public SearchPage(ObservableCollection<MountClass> mountsList)
        {
            InitializeComponent();
            favList = mountsList;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //await manager.getMounts("ant");
        //}
        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var mountListAPI = await manager.getMounts(query);
            mounts = new ObservableCollection<MountClass>();
            foreach (MountClass i in mountListAPI)
            {
                mounts.Add(new MountClass(i.id, i.name, i.description, i.enhanced_description, i.tooltip, i.movement, i.seats, i.order, i.order_group, i.patch, i.item_id, i.owned, i.image, i.icon, i.sources));
            }
            mountList.ItemsSource = mounts;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            query = e.NewTextValue;
        }

        private void favourite_Clicked(object sender, EventArgs e)
        {
            MountClass newMount = (sender as MenuItem).CommandParameter as MountClass;
            try
            {
                dbManager.AddNewMount(newMount);
                favList.Add(newMount);
            }
            catch (Exception ex)
            {
                DisplayAlert("Already Favourited", "This mount has already been favourited", "Ok");
            }
            
        }

        private void mountList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            int m_id = (e.SelectedItem as MountClass).id;
            Navigation.PushAsync(new DetailsPage(m_id));
        }
    }
}