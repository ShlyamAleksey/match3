using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lizzard;

namespace Lizzard
{
	public class EventDispatcher : IEventDispatcher
	{
		private List<ObserverStruct> observers = new List<ObserverStruct>();

		public EventDispatcher()
		{
		}

		public void addEventListener(string eventName, EventListener callBack)
		{
			bool hasEvents = false;
			foreach (ObserverStruct list in observers)
			{
				if (list.name == eventName) 
				{
					list.listeners.Add(callBack);
					hasEvents = true;
				}
			}

			if (!hasEvents)
			{
                ObserverStruct listener = new ObserverStruct();
				listener.name = eventName;
				listener.listeners = new List<EventListener>();
				listener.listeners.Add(callBack);
				observers.Add(listener);
			}
		}

		public void dispatchEvent(Event e)
		{
			foreach (ObserverStruct observer in observers)
			{
				if (observer.name == e.name)
				{
					List<EventListener> listeners = ListUtils.cloneList<EventListener>(observer.listeners);

					foreach (EventListener listener in listeners)
					{
						e.currentTarget = this;
						listener.Invoke(e);
					}
					break;
				}
			}
		}

		public void removeEventListener(string eventName, EventListener callBack)
		{
			foreach (ObserverStruct observer in observers)
			{
				if (observer.name == eventName)
				{
					observer.listeners.Remove(callBack);
					if (observer.listeners.Count == 0) observers.Remove(observer);
					break;
				}
			}
		}
	}

	public struct ObserverStruct 
	{
		public String name;
		public List<EventListener> listeners;
	}
}
