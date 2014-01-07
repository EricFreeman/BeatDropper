using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using BeatDropper.Helpers;
using System.ComponentModel;

namespace BeatDropper
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Analytics _analytics { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            CompositionTarget.Rendering += new EventHandler(GameLoop);

            _analytics = new Analytics();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Beat_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.BeatsDropped++;
            App.ViewModel.Money += App.ViewModel.DollarsPerClick;
            App.ViewModel.AllTimeMoney += App.ViewModel.DollarsPerClick;
        }

        private void PurchaseStoreItem(object sender, RoutedEventArgs e)
        {
            int storeItemId = int.Parse(((Button)sender).Tag.ToString());

            var item = App.ViewModel.StoreItems.
                Where(x => x.Id == storeItemId).FirstOrDefault();

            App.ViewModel.Money -= item.Price;
            item.Count++;
        }

        public void GameLoop(object sender, EventArgs e)
        {
            double dps = App.ViewModel.StoreItems.Sum(x => x.Count * x.Dps);
            double moneyPerFrame = _analytics.frameRate > 0 ?
                dps / _analytics.frameRate :
                0;

            App.ViewModel.Money += moneyPerFrame;
        }
    }
}