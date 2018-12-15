using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XFSampleApp.models
{
    public class SchoolInfo : INotifyPropertyChanged
    {
        private string _name;
        private string _logo;
        private string _address;
        private string _tel;
        private string _email;

        public string Name
        { get { return _name; }
          set
          {
            if(_name!=value)
            {
                NotifyPropertyChanged();
                _name = value;
            }
          }
        }

        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo != value)
                {
                    NotifyPropertyChanged();
                    _logo = value;
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    NotifyPropertyChanged();
                    _address = value;
                }
            }
        }
        public string Tel
        {
            get { return _tel; }
            set
            {
                if (_tel != value)
                {
                    NotifyPropertyChanged();
                    _tel = value;
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    NotifyPropertyChanged();
                    _email = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
