using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// EnemyPu �̊T�v�̐����ł��B
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
