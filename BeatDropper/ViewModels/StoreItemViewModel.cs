using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using BeatDropper.Helpers;

namespace BeatDropper.ViewModels
{
    public class StoreItemViewModel : NotifyPropertyChangedBase
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

        private double _price;
        public double Price
        {
            get
            {
                return _price * (Count + 1);
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

        private double _dps;
        public double Dps
        {
            get
            {
                return _dps;
            }
            set
            {
                if (value != _dps)
                {
                    _dps = value;
                    NotifyOfPropertyChange(() => Dps);
                }
            }
        }

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != _count)
                {
                    _count = value;
                    NotifyOfPropertyChange(() => Count);
                    NotifyOfPropertyChange(() => Price);
                }
            }
        }

        #endregion

        #region Constructor

        public StoreItemViewModel(int id, string name, string description, double price, double dps)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Dps = dps;
        }

        #endregion
    }
}