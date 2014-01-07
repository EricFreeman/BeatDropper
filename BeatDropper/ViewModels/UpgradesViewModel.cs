using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BeatDropper.Helpers;

namespace BeatDropper.ViewModels
{
    public class UpgradesViewModel : NotifyPropertyChangedBase
    {
        #region Properties

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyOfPropertyChange(() => Id);
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        private bool _isPurchased;
        public bool IsPurchased
        {
            get
            {
                return _isPurchased;
            }
            set
            {
                if (value != _isPurchased)
                {
                    _isPurchased = value;
                    NotifyOfPropertyChange(() => IsPurchased);
                }
            }
        }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    NotifyOfPropertyChange(() => Price);
                }
            }
        }

        #endregion

        #region Constructor

        public UpgradesViewModel(int id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        #endregion
    }
}