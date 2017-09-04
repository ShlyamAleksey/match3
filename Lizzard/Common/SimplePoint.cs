using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.Common
{
    public class SimplePoint
    {
        public float X = 0;
        public float Y = 0;

        public SimplePoint(float x = 0, float y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public SimplePoint clone()
        {
            SimplePoint pt = new SimplePoint(this.X, this.Y);
            return pt;
        }

        public SimplePoint revert()
        {
            SimplePoint pt = new SimplePoint(this.Y, this.X);
            return pt;
        }
    }
}
