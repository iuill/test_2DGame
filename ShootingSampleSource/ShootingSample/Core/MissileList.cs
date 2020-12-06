using System;
using System.Collections;

namespace ShootingSample.Core
{
	/// <summary>
	/// MissileList �̊T�v�̐����ł��B
	/// </summary>
	public class MissileList
	{
		private ArrayList missiles = new ArrayList();

		public void Add(MissileBody missile)
		{
			this.missiles.Add(missile);
		}

		public int Count
		{
			get
			{
				return this.missiles.Count;
			}
		}

		public MissileBody this [int index]
		{
			get
			{
				return (MissileBody)this.missiles[index];
			}
		}

		public void RemoveAt(int index)
		{
			this.missiles.RemoveAt(index);
		}
	}
}
