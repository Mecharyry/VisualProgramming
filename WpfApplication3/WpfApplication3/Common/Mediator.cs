/// The structure for this class was derived using the tutorial 
/// available at the code project website and the code therein
/// is available under the code project open licence.
/// Source: http://www.codeproject.com/Articles/35277/MVVM-Mediator-Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Common
{
    public sealed class Mediator : Singleton<Mediator>
    {
        public enum ViewModelMessages
        {
            ControlsChanged = 1, PropertiesSelection = 2, ControlSelected = 3,
            StartDraw = 4, AddTab = 5, RemoveControl = 6, CanvasSizeChanged = 7,
            ControlListLoaded = 8, ContextChanged = 9
        };

        Dictionary<ViewModelMessages, List<Action<Object>>> _messageCallbackList = new Dictionary<ViewModelMessages, List<Action<Object>>>();

        public CustomDictionary<ViewModelMessages, List<Action<Object>>> MessageCallbackList 
        {
            get 
            {
                return new CustomDictionary<ViewModelMessages,List<Action<object>>>(_messageCallbackList, true);
            }
        }

        public void Register(Action<Object> callback,
            ViewModelMessages message)
        {
            if (!_messageCallbackList.ContainsKey(message))
            {   // Create a new list of message type.
                _messageCallbackList.Add(message, new List<Action<object>>() { callback });
            }
            else
            {   // Retrieve current list and add callback to it.
                _messageCallbackList[message].Add(callback);
            }
        }

        public void Notify(ViewModelMessages message,
            object args)
        {
            if (_messageCallbackList.ContainsKey(message))
            {
                foreach (Action<object> callback in
                    _messageCallbackList[message])
                {
                    callback(args);
                }
            }
        }
    }
}
