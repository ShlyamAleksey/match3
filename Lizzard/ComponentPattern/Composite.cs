using System;
using System.Collections.Generic;

namespace Lizzard.ComponentPattern
{
    public class Composite : Component
    {
        public String name;
        protected List<Component> children;

        public Composite(String nodeName)
        {
            this.name = nodeName;
            this.children = new List<Component>();
        }

        override public void addChild(Component child)
        {
            children.Add(child);
        }

        override public void removeChild(Component child)
        {
            children.Remove(child);
        }
    }
}
