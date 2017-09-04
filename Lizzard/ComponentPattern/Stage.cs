using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lizzard.ComponentPattern
{
    public class Stage : Sprite
    {
        static public Stage instance;
        static public string UPDATE = "onStageUpdated";
        static public double currentTimeMS;

        public Stage() 
		{
			name = "stage";
            instance = this;
        }

        override public void draw()
        {
            if (_visible)
            {
                if (texture != null) MainApp.spriteBatch.Draw(this.texture, new Vector2(0, 0), null, Color.White, _rotation, new Vector2(0, 0), _scaleX, SpriteEffects.None, 0.0f);
                foreach (Sprite child in this.children)
                {
                    child.draw();
                }
            }
        }

        override protected void onMouseClick(MouseState state)
        {           
            if (state.LeftButton.ToString() == "Released")
            {
                if (_clickStatus)
                {
                    setMouseBubbling(true);
                    Random rnd = new Random();
                    MouseEvent.HASH = rnd.Next(int.MaxValue);
                    _clickStatus = false;
                }
            }
        }

        override protected void onMouseDown(MouseState state)
        {
            if (state.LeftButton.ToString() == "Pressed")
            {
                _clickStatus = true;
            }
        }

        public void update(GameTime gameTime)
        {
            base.update();
            currentTimeMS = gameTime.TotalGameTime.TotalMilliseconds;
            dispatchEvent(new Event(Stage.UPDATE));
        }
    }
}
