using System;

namespace ShootingSample.Core.KeyEstimate
{
	/// <summary>
	/// キーの状態を元に、前回押下時からの経由時間でキー押下とするかなどの判定。
	/// </summary>
	public class KeyEstimate
	{
		/// <summary>
		/// 最低経過時間。この値以上の時間が経過していれば、新たにキーを押したものとみなす。
		/// </summary>
		private int interval;
		/// <summary>
		/// 前回キーが押下されたものとみなされた時のシステム起動からの経過時間。
		/// </summary>
		private int lastTime = 0;

		private int key;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="interval">最低経過時間。</param>
		/// <param name="key">押下するキー。</param>
		public KeyEstimate(int interval, int key)
		{
			this.interval = interval;
			this.key = key;
		}

		public bool isNewKeyPress(byte[] keyState)
		{
			if((keyState[key] & (byte)0x80) != 0x80)
			{
				this.lastTime = 0;
				return false;
			}

			int now = System.Environment.TickCount;

			if(now - this.lastTime < this.interval)
			{
				return false;
			}

			this.lastTime = now;
			return true;
		}
	}
}
