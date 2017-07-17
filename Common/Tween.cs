using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;
using System.Dynamic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Lizzard.str
{
    public delegate void TweenCallback();
    public class Tween
    {
        private Sprite _target;
        private int _duration;
        private TweenCallback callback;

        private float x;
		private float _x;
		private float offsetX;

		private float y;
		private float _y;
		private float offsetY;

        private float alpha;
        private float _alpha;
        private float offsetAlpha;

        private float scaleX;
        private float _scaleX;
        private float offsetScaleX;

        private float tintR;
        private float _tintR;
        private float offsetTintR;

        private float tintG;
        private float _tintG;
        private float offsetTintG;

        private float tintB;
        private float _tintB;
        private float offsetTintB;

        private uint mask = 0;
        private uint maskX = 1 << 0;
        private uint maskY = 1 << 1;
        private uint maskAlpha = 1 << 2;
        private uint maskScaleX = 1 << 3;

        private uint maskTintR = 1 << 4;
        private uint maskTintG = 1 << 5;
        private uint maskTintB = 1 << 6;

        public void add( string property, float value)
        {
			switch (property)
			{
				case "x":
					this.x = value;
                    mask = mask | maskX;
                    break;
				case "y":
					this.y = value;
                    mask = mask | maskY;
                    break;
			    case "alpha":
			        this.alpha = value;
			        mask = mask | maskAlpha;
			        break;
                case "scaleX":
                    this.scaleX = value;
                    mask = mask | maskScaleX;
                    break;
                case "tintR":
                    this.tintR = value;
                    mask = mask | maskTintR;
                    break;
                case "tintG":
                    this.tintG = value;
                    mask = mask | maskTintG;
                    break;
                case "tintB":
                    this.tintB = value;
                    mask = mask | maskTintB;
                    break;
            }
		}

		public void start(Sprite sprite, int duration, TweenCallback callback = null)
		{
			this._duration = duration;
			this._target = sprite;
            this.callback = callback;

            offsetX = this.x - _target.x;
			_x = offsetX / duration;

			offsetY = this.y - _target.y;
			_y = offsetY / duration;

		    offsetAlpha = this.alpha - _target.alpha;
		    _alpha = offsetAlpha / duration;

            offsetScaleX = this.scaleX - _target.scaleX;
            _scaleX = offsetScaleX / duration;

            offsetTintR = this.tintR - _target.tint.ToVector3().X;
            _tintR = offsetTintR / duration;

            offsetTintG = this.tintG - _target.tint.ToVector3().Y;
            _tintG = offsetTintG / duration;

            offsetTintB = this.tintB - _target.tint.ToVector3().Z;
            _tintB = offsetTintB / duration;

            _target.addEventListener(Event.ENTER_FRAME, update);
		}

        public void update(Event e)
        {
            float r = _target.tint.ToVector3().X;
            float g = _target.tint.ToVector3().Y;
            float b = _target.tint.ToVector3().Z;

            if (_duration > 0)
            {
                if ((mask & maskX) == maskX)  _target.x += _x;
                if((mask & maskY) == maskY) _target.y += _y;
                if ((mask & maskAlpha) == maskAlpha) _target.alpha += _alpha;
                if ((mask & maskScaleX) == maskScaleX) _target.scaleX += _scaleX;

                if ((mask & maskTintR) == maskTintR) r += _tintR;
                if ((mask & maskTintG) == maskTintG) g += _tintG;
                if ((mask & maskTintB) == maskTintB) b += _tintB;

                if ((mask & maskTintR) == maskTintR || (mask & maskTintG) == maskTintG || (mask & maskTintB) == maskTintB) _target.tint = new Color(r, g, b);
            }
            else
            {
                if ((mask & maskX) == maskX) _target.x = this.x;
                if ((mask & maskY) == maskY) _target.y = this.y;
                if ((mask & maskAlpha) == maskAlpha) _target.alpha = this.alpha;
                if ((mask & maskScaleX) == maskScaleX) _target.scaleX = this.scaleX;
                if ((mask & maskTintR) == maskTintR) _target.tint = new Color(this.tintR, g, b);
                if ((mask & maskTintG) == maskTintG) _target.tint = new Color(r, this.tintG, b);
                if ((mask & maskTintB) == maskTintB) _target.tint = new Color(r, g, this.tintB);

                _target.removeEventListener(Event.ENTER_FRAME, update);
                if(this.callback != null) this.callback.Invoke();
            }
            _duration--;
        }
    }
}
