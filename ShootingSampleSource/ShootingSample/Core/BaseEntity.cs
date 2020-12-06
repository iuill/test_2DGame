using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// BaseEntity の概要の説明です。
	/// </summary>
	public abstract class BaseEntity
	{
		private Point position;
		private Bitmap bitmap;

		public BaseEntity(Point position, Bitmap bitmap)
		{
			this.position = position;
			this.bitmap = bitmap;
		}

		/// <summary>
		/// 現在の位置。
		/// </summary>
		/// <remarks>
		/// この位置を原点として、画像が右下に展開。
		/// </remarks>
		public Point Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		public Bitmap EntityImage
		{
			get
			{
				return this.bitmap;
			}
		}
	}
}
