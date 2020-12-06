using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// 自機クラス。
	/// </summary>
	public class OwnBody : BaseEntity
	{
		public OwnBody(Point position, Bitmap bitmap) : base(position, bitmap)
		{
		}

		public void MoveToRight()
		{
			this.Position = new Point(this.Position.X + Core.Constants.DifferenceOfOwnBodyMove, this.Position.Y);
		}

		public void MoveToLeft()
		{
			this.Position = new Point(this.Position.X - Core.Constants.DifferenceOfOwnBodyMove, this.Position.Y);
		}
	}
}
