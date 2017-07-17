using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.str.events;

namespace Lizzard.str.model
{
    public class StatusBarModel : EventDispatcher
    {
        private float _statusValue;
        public float statusValue {
            get { return _statusValue; }
            set
            {
                _statusValue = value;
                dispatchEvent(new Event(StatusEvent.UPDATE, _statusValue));
            }
        }

        public StatusBarModel()
        { 
        }

        public void init(float startValue)
        {
            this.statusValue = startValue;
        }
    }
}
