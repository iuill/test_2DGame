using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// EnemyPu ‚ÌŠT—v‚Ìà–¾‚Å‚·B
	/// </summary>
	public class EnemyPu : BaseEnemy
	{
		public EnemyPu(Point position, Bitmap bitmap) : base(position, bitmap)
		{
		}

		public override Point GetNextPosition()
		{
			return this.Position;
		}
	}
}
