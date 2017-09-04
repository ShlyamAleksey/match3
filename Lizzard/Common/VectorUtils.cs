using System;
using Microsoft.Xna.Framework;
using Lizzard.Common;
namespace Lizzard
{
	public class VectorUtils
	{
		static public SimplePoint cloneVector(SimplePoint v)
		{
			return new SimplePoint(v.X, v.Y);
		}
	}
}
