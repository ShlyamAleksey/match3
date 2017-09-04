using System;
namespace Lizzard
{
	
	public class Event
	{
        public const string ENTER_FRAME = "ENTER_FRAME";

        public String name;
		public Object data;
        public Object currentTarget;

		public Event(String name, Object data = null)
		{
			this.name = name;
			this.data = data;
		}
	}
}
