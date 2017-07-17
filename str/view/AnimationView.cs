using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.str.model;

namespace Lizzard.str
{
    public class AnimationView
    {
        private BoardModel _model;

        public AnimationView(BoardModel model)
        {
            _model = model;
        }

        public void completeMovingPiece()
		{
            _model.lookForMatches();
		}

    public void completeDestroyPiece()
		{
            _model.destroy();
            _model.fall();
		}
    }
}
