using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;

namespace Lizzard.str.view
{
    public class CharacterView : Sprite
    {
        private ProgressBarView healthBar;

        private Sprite characterFrame;
        private Sprite characterIcon;

        public CharacterView(int monsterID)
        {
            characterFrame = new Sprite("monsters", "characterBG");
            addChild(characterFrame);
            characterFrame.x = 10;
            characterFrame.y = 10;

            characterIcon = new Sprite("monsters", "monster" + monsterID.ToString());
            addChild(characterIcon);

            characterIcon.x = characterFrame.x + (characterFrame.width - characterIcon.width) / 2;
            characterIcon.y = characterFrame.y + (characterFrame.height - characterIcon.height) / 2;

            healthBar = new ProgressBarView("red");
            addChild(healthBar);
            healthBar.x = 2;
            healthBar.y = characterFrame.y + characterFrame.height;
        }

        public void showVanishAnimation(TweenCallback callback)
        {
            Tween tween;
            tween = new Tween();
            tween.add("alpha", 0);
            tween.start(this.characterIcon, 40, callback);
        }

        public void updateHealth(float value)
        {
            Tween   tween = new Tween();
                    tween.add("tintG", 0);
                    tween.add("tintB", 0);
            tween.start(characterIcon, 15, onComplete);

            
            healthBar.updateProgress(value);
        }

        public void onComplete()
        {
            Tween tween = new Tween();
            tween.add("tintG", 255);
            tween.add("tintB", 255);
            tween.start(characterIcon, 15);
        }
    }
}
