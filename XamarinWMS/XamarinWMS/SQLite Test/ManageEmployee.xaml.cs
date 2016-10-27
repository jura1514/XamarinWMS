using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinWMS.SQLite_Test
{
    public partial class ManageEmployee : ContentPage
    {
        public ManageEmployee()
        {
            InitializeComponent();
            var vList = App.DAUtil.GetAllDeliveries();
            lstData.ItemsSource = vList;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
            }
            var vSelUser = (Employee)e.SelectedItem;
            Navigation.PushAsync(new ShowEmplyee(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddEmployee());
        }
    }
}
