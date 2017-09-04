using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;
using Lizzard.ComponentPattern;
using System.Collections.Generic;
using Lizzard.str;


namespace Lizzard
{
	public class MovieClips : Sprite
	{
		public int currentFrame = 0;
		public int slowdown = 4;

		protected string _sourceName;

		private int _totalFrames = 0;
		private int _tick = 0;
		private bool _stop = false;

		public int totalFrames { get { return _totalFrames; } }

		public MovieClips(string atlasName, string sourceRec) : base("instance")
		{
			_sourceName = sourceRec;
			this.texture = TextureManager.textureByName(atlasName);
			_sourceRect = XmlAssetsParser.rectangle(sourceRec + currentFrame.ToString());
			getTotalFrames();
            updateBounce();

        }

		private void getTotalFrames() 
		{
			while (XmlAssetsParser.hasRectangle(_sourceName + _totalFrames.ToString()))
			{
				_totalFrames++;
			}
			_totalFrames--;
		}

		public override void update()
		{
			base.update();
			if (_stop) return;

			_tick++;
			if(_tick == slowdown)
			{
				_tick = 0;
				currentFrame++;
				if (currentFrame > totalFrames) currentFrame = 0;
			}
			_sourceRect = XmlAssetsParser.rectangle(_sourceName + currentFrame.ToString());
		}

		public void gotoAndPlay(int frame)
		{
			setFrame(frame, false);
		}

		public void gotoAndStop(int frame)
		{
			setFrame(frame, true);
		}

		public void stop()
		{
			setFrame(currentFrame, true);
		}

		public void play()
		{
			setFrame(currentFrame, false);
		}

		private void setFrame(int frame, bool isStop) 
		{
			currentFrame = frame;
			_tick = 0;
			_stop = isStop;
			_sourceRect = XmlAssetsParser.rectangle(_sourceName + currentFrame.ToString());
		}
	}
}
