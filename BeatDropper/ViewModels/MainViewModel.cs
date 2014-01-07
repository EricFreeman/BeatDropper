using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BeatDropper.Helpers;

namespace BeatDropper.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        #region Lists

        public ObservableCollection<UpgradesViewModel> Upgrades { get; private set; }

        public ObservableCollection<StoreItemViewModel> StoreItems { get; private set; }

        #endregion

        #region Properties

        private int _beatsDropped = 0;
        public int BeatsDropped
        {
            get
            {
                return _beatsDropped;
            }
            set
            {
                if (value != _beatsDropped)
                {
                    _beatsDropped = value;
                    NotifyPropertyChanged("BeatsDropped");
                }
            }
        }

        private double _dollarsPerClick = 1.234f;
        public double DollarsPerClick
        {
            get
            {
                return _dollarsPerClick;
            }
            set
            {
                if (value != _dollarsPerClick)
                {
                    _dollarsPerClick = value;
                    NotifyPropertyChanged("DollarsPerClick");
                }
            }
        }

        private double _money = 0;
        public double Money
        {
            get
            {
                return _money;
            }
            set
            {
                if (value != _money)
                {
                    _money = value;
                    NotifyPropertyChanged("Money");

                    // This is really stupid, but until Sliverlight has multibindings
                    // or I figure out a way to add them myself, this is how it has
                    // to happen :(
                    foreach (var item in App.ViewModel.StoreItems)
                    {
                        item.NotifyOfPropertyChange(() => item.Price);
                    }

                    foreach (var up in App.ViewModel.Upgrades)
                    {
                        up.NotifyOfPropertyChange(() => up.Price);
                    }
                }
            }
        }

        private double _allTimeMoney = 0;
        public double AllTimeMoney
        {
            get
            {
                return _allTimeMoney;
            }
            set
            {
                if (value != _allTimeMoney)
                {
                    _allTimeMoney = value;
                    NotifyPropertyChanged("AllTimeMoney");
                }
            }
        }

        public bool IsDataLoaded { get; private set; }

        #endregion

        #region Constructor

        public GameViewModel()
        {
            this.Upgrades = new ObservableCollection<UpgradesViewModel>();
            this.StoreItems = new ObservableCollection<StoreItemViewModel>();
        }

        #endregion

        #region Loading

        public void LoadData()
        {
            // Sample data; replace with real data
            this.Upgrades.Add(new UpgradesViewModel(1, "Test Upgrade 1", "This is a test description", 12000));

            this.StoreItems.Add(new StoreItemViewModel(1, "Test Item 1", "This is a test description", 15, .03));
            this.StoreItems.Add(new StoreItemViewModel(2, "Test Item 2", "This is a test description", 100, 1));

            this.IsDataLoaded = true;
        }

        #endregion

        #region INotify Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}