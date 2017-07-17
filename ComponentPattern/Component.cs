using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.ComponentPattern
{
	public abstract class Component : EventDispatcher
    {
        abstract public void addChild(Component child);
        abstract public void removeChild(Component child);
    }
}
