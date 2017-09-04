using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str
{
    public class GameActiveStatus
    {
        static public void active()
        {
            GameScreen.instance.mouseEnable = true;
        }
        static public void deactive()
        {
            GameScreen.instance.mouseEnable = false;
        }
    }
}
