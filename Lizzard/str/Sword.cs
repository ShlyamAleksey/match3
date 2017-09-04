using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lizzard.str
{
    public class Sword
    {
        [XmlIgnore]
        public Type Type;

        public Sword()
        {
            Type = this.GetType();
        }
       
    }
}
