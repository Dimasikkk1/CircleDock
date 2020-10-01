using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace CircleDock.Models
{
    static class Config
    {
        public const string ConfigPath = "Resources/Config.xml";
        public const string RootElement = "Config";

        public static ObservableDictionary<Type, ObservableDictionary<string, object>> Properties = new ObservableDictionary<Type, ObservableDictionary<string, object>>()
        {
            { typeof(WindowProperties), new ObservableDictionary<string, object>() 
            {
                { "Visibility", true },
                { "Width", SystemParameters.PrimaryScreenWidth }, // Надо будет что-то придумать для нескольких дисплеев
                { "Height", SystemParameters.PrimaryScreenHeight },
                { "Left", 0d },
                { "Top", 0d },
                { "Topmost", true },
                { "HideAfterOpen", false },
                { "Language", CultureInfo.CurrentCulture.Name } } },
            { typeof(DockProperties), new ObservableDictionary<string, object>() 
            {
                { "EnableRotation", true },
                { "MinimumRadius", 130d },
                { "IconsPerCircle", 13d },
                { "CircleInterval", 50d },
                { "RotationStep", 30d },
                { "Rotation", 0d } } },
            { typeof(RingProperties), new ObservableDictionary<string, object>() 
            {
                { "Color", Colors.LightGray },
                { "Diameter", 200d },
                { "Thickness", 50d } } },
            { typeof(ButtonProperties), new ObservableDictionary<string, object>() 
            {
                { "Image", "Resources/Icons/Button.png" },
                { "Diameter", 100d },
                { "Background", Colors.Azure } } },
            { typeof(ShortcutProperties), new ObservableDictionary<string, object>()
            {
                { "FolderImage", "Resources/Icons/Folder.png" },
                { "ShowWindowsContextMenu", true },
                { "Width", 74d },
                { "Height", 70d },
                { "Opacity", 1d }
            } }
        };

        //public static void Initialize()
        //{
        //    try
        //    {
        //        XmlReader.LoadConfig();
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        XmlReader.SaveConfig();
        //    }
        //}
    }
}
