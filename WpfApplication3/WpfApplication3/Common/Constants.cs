using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication3.Common
{
    public static class Constants
    {
        #region Image Locations
        private static string ImageSourceLocation
        {
            get { return Environment.CurrentDirectory; }
        }
        
        private static string ControlsSourceLocation
        {
            get { return @"\Resources\Images\Controls\"; }
        }

        private static string ApplicationsSourceLocation
        {
            get { return @"\Resources\Images\Applications\"; }
        }

        public static string ExcelConnectionImage
        {
            get { return ImageSourceLocation + ControlsSourceLocation + "Plug.png"; }
        }

        public static string WordApplicationImage
        {
            get { return ImageSourceLocation + ApplicationsSourceLocation + "Word.jpg"; }
        }

        public static string ExcelApplicationImage
        {
            get { return ImageSourceLocation + ApplicationsSourceLocation + "Excel.png"; }
        }

        public static string AccessApplicationImage
        {
            get { return ImageSourceLocation + ApplicationsSourceLocation + "Access.png"; }
        }

        public static string StartControlImage
        {
            get { return ImageSourceLocation + ControlsSourceLocation + "checkeredFlag.png"; }
        }
        #endregion

        #region Screen Details
        public static double ScreenWidth
        {
            get { return SystemParameters.PrimaryScreenWidth; }
        }

        public static double ScreenHeight
        {
            get { return SystemParameters.PrimaryScreenHeight; }
        }

        private static double _designAreaHeight;
        public static double DesignAreaHeight
        {
            get { return _designAreaHeight; }
            set { _designAreaHeight = value; }
        }

        private static double _designAreaWidth;
        public static double DesignAreaWidth
        {
            get { return _designAreaWidth; }
            set { _designAreaWidth = value; }
        }
        #endregion

        #region Other
        public enum ApplicationSet
        {
            Excel = 1, Word = 2, Access = 3,
            System = 4
        };

        public enum VariableType
        {
            Global = 1, Connection = 2, Iterator = 3
        };

        private static Boolean _controlsLoaded = false;
        public static Boolean ControlsLoaded
        {
            get
            {
                return _controlsLoaded;
            }
            set
            {
                _controlsLoaded = value;
            }
        }

        public static string OutputDirectory
        {
            get { return Environment.CurrentDirectory; }
        }
        #endregion
    }
}
