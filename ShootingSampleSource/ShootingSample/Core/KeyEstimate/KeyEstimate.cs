using System;

namespace ShootingSample.Core.KeyEstimate
{
	/// <summary>
	/// �L�[�̏�Ԃ����ɁA�O�񉟉�������̌o�R���ԂŃL�[�����Ƃ��邩�Ȃǂ̔���B
	/// </summary>
	public class KeyEstimate
	{
		/// <summary>
		/// �Œ�o�ߎ��ԁB���̒l�ȏ�̎��Ԃ��o�߂��Ă���΁A�V���ɃL�[�����������̂Ƃ݂Ȃ��B
		/// </summary>
		private int interval;
		/// <summary>
		/// �O��L�[���������ꂽ���̂Ƃ݂Ȃ��ꂽ���̃V�X�e���N������̌o�ߎ��ԁB
		/// </summary>
		private int lastTime = 0;

		private int key;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="interval">�Œ�o�ߎ��ԁB</param>
		/// <param name="key">��������L�[�B</param>
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
