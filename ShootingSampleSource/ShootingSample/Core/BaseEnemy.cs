using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// BaseEnemy の概要の説明です。
	/// </summary>
	public abstract class BaseEnemy : BaseEntity
	{
		public BaseEnemy(Point position, Bitmap bitmap) : base(position, bitmap)
		{
		}

		/// <summary>
		/// 次の位置を取得。
		/// 独自のアルゴリズムを実装する場合はここで実装。
		/// </summary>
		/// <returns></returns>
		public abstract Point GetNextPosition();
	}
}
