using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// winmm ‚ÌŠT—v‚Ìà–¾‚Å‚·B
	/// </summary>
	public class winmm
	{
		[DllImport("winmm.dll", EntryPoint="timeGetTime")]
		extern static uint TimeGetTime();
	}
}
