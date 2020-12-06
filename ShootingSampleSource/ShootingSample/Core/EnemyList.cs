using System;
using System.Collections;
using System.Drawing;

namespace ShootingSample.Core
{
	/// <summary>
	/// EnemyList ‚ÌŠT—v‚Ìà–¾‚Å‚·B
	/// </summary>
	public class EnemyList
	{
		private ArrayList array = new ArrayList();

		public void Add(BaseEnemy enemy)
		{
			this.array.Add(enemy);
		}

		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		public BaseEnemy this [int index]
		{
			get
			{
				return (BaseEnemy)this.array[index];
			}
		}
	}
}
