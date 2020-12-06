using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// winmm の概要の説明です。
	/// </summary>
	public class winmm
	{
		[DllImport("winmm.dll", EntryPoint="timeGetTime")]
		extern static uint TimeGetTime();
	}
}
