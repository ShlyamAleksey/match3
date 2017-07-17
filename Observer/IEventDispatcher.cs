using System;
namespace Lizzard
{
	public delegate void EventListener(Event e);

	public interface IEventDispatcher
	{

		void addEventListener(String eventName, EventListener callBack);
		void removeEventListener(String eventName, EventListener callBack);
		void dispatchEvent(Event e);
	}
}
