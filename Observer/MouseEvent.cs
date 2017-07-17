using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard
{
    public class MouseEvent : Event
    {
        public const string CLICK = "MouseEvent.click";
        public const string LEFT_DOWN = "MouseEvent.leftDown";
        public const string MOVE = "MouseEvent.leftUp";

        public static int HASH;

        public MouseEvent(String name) : base(name)
        {

        }
    }
}
