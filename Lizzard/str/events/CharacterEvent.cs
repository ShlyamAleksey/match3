using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str.events
{
    public class CharacterEvent
    {
        static public string UPDATE_HEALTH = "Lizzard.str.events.CharacterEvent.UPDATE_HEALTH";
        static public string UPDATE_POWER = "Lizzard.str.events.CharacterEvent.UPDATE_POWER";

        public string status;
        public float value;

        public CharacterEvent(string status, float value)
        {
            this.status = status;
            this.value = value;
        }
    }
}
