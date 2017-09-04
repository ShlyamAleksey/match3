using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;

namespace Lizzard.str
{
    public class ItemView : MovieClip
    {
        private int _state = 0;
        public Sprite selected;

        public ItemView() : base("lizzard", "item")
        {
            selected = new Sprite("lizzard", "frame");
            selected.name = "FRAME";
            addChild(selected);
            selected.visible = false;
            gotoAndStop(_state);
        }

        public int state
        {
            set { _state = value; gotoAndStop(_state); }
            get { return _state; }
        }
    }
}
