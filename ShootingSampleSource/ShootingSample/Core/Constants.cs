using System;

namespace ShootingSample.Core
{
	/// <summary>
	/// Constant ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public class Constants
	{
		public const string BackgroundImageFileName = @"./img/BackgroundImage.bmp";
		public const string OwnBodyImageFileName = @"./img/OwnBodyImage.bmp";
		public const string EnemyBodyImageFileName = @"./img/EnemyBodyImage.bmp";
		public const string MissileImageFileName = @"./img/MissileImage.bmp";

		public const int KeyInterval_MissileLaunch = 100;
		public const int KeyInterval_MoveToRight = 40;
		public const int KeyInterval_MoveToLeft = 40;

		public const int DifferenceOfOwnBodyMove = 5;
		public const int DifferenceOfMissileBodyMove = 10;
	}
}
