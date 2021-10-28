using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FFXIVMountTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        NetworkingManager manager = new NetworkingManager();
        DatabaseManager dbManager = new DatabaseManager();
        int mountID;
        MountClass currMount;
        public DetailsPage(int id)
        {
            InitializeComponent();
            mountID = id;
        }

        protected async override void OnAppearing()
        {
            var mountAPI = await manager.getMount(mountID);
            currMount = mountAPI;
            //mountList.ItemsSource = mounts;
            mountName.Text = mountAPI.name;
            mountImage.Source = mountAPI.image;
            mountMovement.Text = mountAPI.movement;
            mountOwned.Text = "Owned by: " + mountAPI.owned + " of players";
            mountSeats.Text = "Number of Seats: " + mountAPI.seats;
            mountDesc.Text = mountAPI.description;
            mountEnchDesc.Text = mountAPI.enhanced_description;

            mountSourceList.ItemsSource = mountAPI.sources;

            base.OnAppearing();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //MountClass newMount = (sender as MenuItem).CommandParameter as MountClass;
            try
            {
                dbManager.AddNewMount(currMount);
                DisplayAlert("Favourited", currMount.name + " is favourited.", "Ok");
                //favList.Add(newMount);
            }
            catch (Exception ex)
            {
                DisplayAlert("Already Favourited", "This mount has already been favourited", "Ok");
            }
        }
    }
}