using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.str.events;

namespace Lizzard.str.model
{
    public class CharacterModel : EventDispatcher
    {
        public StatusBarModel energy { get; }
        private StatusBarModel health;

        public CharacterModel()
        {
            this.energy = new StatusBarModel();
            this.health = new StatusBarModel();

            //this.power.addEventListener(StatusEvent.UPDATE, updateHealth);
            this.health.addEventListener(StatusEvent.UPDATE, update);
        }

        public void init(float power, float health)
        {
            this.energy.init(0);
            this.health.init(health);
        }

        public void hit(int value)
        {
            this.health.statusValue = this.health.statusValue - value;
        }

        public void addEnergy(float value)
        {
            this.energy.statusValue = this.energy.statusValue + value;
        }

        private void update(Event e)
        {
            dispatchEvent(new Event(CharacterEvent.UPDATE_HEALTH, new CharacterEvent("health", (float)e.data)));
        }
    }
}
