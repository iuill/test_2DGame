using System;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// BaseEnemy �̊T�v�̐����ł��B
	/// </summary>
	public abstract class BaseEnemy : BaseEntity
	{
		public BaseEnemy(Point position, Bitmap bitmap) : base(position, bitmap)
		{
		}

		/// <summary>
		/// ���̈ʒu���擾�B
		/// �Ǝ��̃A���S���Y������������ꍇ�͂����Ŏ����B
		/// </summary>
		/// <returns></returns>
		public abstract Point GetNextPosition();
	}
}
