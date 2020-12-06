using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// MissileBody �̊T�v�̐����ł��B
	/// </summary>
	public class MissileBody : BaseEnemy
	{
		public MissileBody(Point position, Bitmap bitmap) : base(position, bitmap)
		{
		}

		public override Point GetNextPosition()
		{
			return new Point(this.Position.X, this.Position.Y - Core.Constants.DifferenceOfMissileBodyMove);
		}

	}
}
