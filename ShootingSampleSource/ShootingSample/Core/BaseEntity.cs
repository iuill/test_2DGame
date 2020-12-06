using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// BaseEntity �̊T�v�̐����ł��B
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
		/// ���݂̈ʒu�B
		/// </summary>
		/// <remarks>
		/// ���̈ʒu�����_�Ƃ��āA�摜���E���ɓW�J�B
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
