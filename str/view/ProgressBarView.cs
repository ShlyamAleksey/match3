using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Lizzard.str;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Lizzard.ComponentPattern;

namespace Lizzard.str.view
{
    public class ProgressBarView : Sprite
    {
        private Sprite upperBar;
        private Sprite progress;
        
        public ProgressBarView(String progressTexture)
        {
            progress = new Sprite("monsters", progressTexture);
            addChild(progress);

            upperBar = new Sprite("monsters", "upperBar");
            addChild(upperBar);

            progress.x = (upperBar.width - progress.width) / 2;
            progress.y = (upperBar.height - progress.height) / 2;

            progress.scaleX = 1f;

            width = upperBar.width;
            height = upperBar.height;
        }

        public void updateProgress(float value)
        {
            Tween tween = new Tween();
            tween.add("scaleX", value);
            tween.start(progress, 35);
            //progress.scaleX = value;
        }
    }
}
