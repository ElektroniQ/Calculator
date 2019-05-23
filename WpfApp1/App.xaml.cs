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
    public enum Skin { Dark, Light, Blue }

    public partial class App : Application
    {
        public static Skin Skin { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ChangeSkin(Skin.Dark);
        }

        public void ChangeSkin(Skin newSkin)
        {
            Skin = newSkin;
            Resources.Clear();
            Resources.MergedDictionaries.Clear();
            if (Skin == Skin.Dark)
                ApplyResources("\\Resources\\Style\\DarkTheme.xaml");
            else if (Skin == Skin.Light)
                ApplyResources("\\Resources\\Style\\LightTheme.xaml");
            else if (Skin == Skin.Blue)
                ApplyResources("\\Resources\\Style\\BlueTheme.xaml");

            ApplyResources("\\Resources\\Style\\MetroStyle.xaml");
        }

        private void ApplyResources(string src)
        {
            var dict = new ResourceDictionary() { Source = new Uri(src, UriKind.Relative) };
            foreach (var mergeDict in dict.MergedDictionaries)
            {
                Resources.MergedDictionaries.Add(mergeDict);
            }

            foreach (var key in dict.Keys)
            {
                Resources[key] = dict[key];
            }
        }
    }


}
