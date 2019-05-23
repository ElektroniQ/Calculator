using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;


namespace WpfApp1
{
    public class SkinResourceDictionary : ResourceDictionary
    {
        private Uri _lightSource;
        private Uri _darkSource;

        public Uri LightSource
        {
            get { return _lightSource; }
            set
            {
                _lightSource = value;
                UpdateSource();
            }
        }
        public Uri DarkSource
        {
            get { return _darkSource; }
            set
            {
                _darkSource = value;
                UpdateSource();
            }
        }

        public void UpdateSource()
        {
            var val = App.Skin == Skin.Light ? LightSource : DarkSource;
            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
