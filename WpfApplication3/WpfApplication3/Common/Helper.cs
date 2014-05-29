using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WpfApplication3.Common
{
    public static class Helper
    {
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            return member.Member.Name;
        }

        public static string GetMethod<T>(Expression<Action<T>> expression)
        {
            MethodCallExpression member = expression.Body as MethodCallExpression;
            return member.Method.Name;
        }

        // Helper to search up the VisualTree
        public static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return current as T;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        public static T FindChild<T>(DependencyObject current, String elementName)
            where T : DependencyObject
        {
            for (int childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(current); childIndex++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(current, childIndex);
                T result = FindChild<T>(child, elementName);

                FrameworkElement element = child as FrameworkElement;
                if (element != null && element.Name == elementName)
                {
                    return element as T;
                }

                if (result != null)
                {
                    return result as T;
                }
            }
            return null;
        }

        public static T ConvertToType<T>(T n1)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)Convert.ChangeType(n1, n1.GetType());
        }

        public static bool ObjectToXml(object toCopy, string path)
        {
            XmlSerializer xml = new XmlSerializer(toCopy.GetType());

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    xml.Serialize(sw, toCopy);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
                return false;
            }
        }

        public static object XmlToObject(Type toType, string path)
        {
            XmlSerializer xml = new XmlSerializer(toType);

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    object obj = xml.Deserialize(reader);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
                return null;
            }
        }
    }


    public class CustomDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _dictionary;
        private Boolean _isReadOnly;

        public CustomDictionary(IDictionary<TKey, TValue> source, Boolean isReadOnly)
        {
            _dictionary = source;
            _isReadOnly = isReadOnly;
        }

        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return _dictionary.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                if (IsReadOnly == false)
                {
                    _dictionary[key] = value;
                }
                else
                {
                    throw new NotImplementedException();
                }

            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (IsReadOnly == false)
            {
                _dictionary.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            if (IsReadOnly == false)
            {
                _dictionary.Clear();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsReadOnly == false)
            {
                return _dictionary.Remove(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public void Add(TKey key, TValue value)
        {
            if (IsReadOnly == false)
            {
                _dictionary.Add(key, value);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Remove(TKey key)
        {
            if (IsReadOnly == false)
            {
                return _dictionary.Remove(key);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
