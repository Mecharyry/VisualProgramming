/// This class was built using the tutorial available by code project.
/// All code is available under "The Code Project Open Licence".
/// Link: http://www.codeproject.com/Articles/572263/A-Reusable-Base-Class-for-the-Singleton-Pattern-in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Common
{
    public abstract class Singleton<T> where T : class
    {
        #region Members
        private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstanceOfT());
        #endregion

        #region Properties
        public static T Instance { get { return _instance.Value; } }
        #endregion

        #region Methods
        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }
        #endregion
    }
}