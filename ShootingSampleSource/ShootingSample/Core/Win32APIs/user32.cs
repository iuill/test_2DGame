using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// user32 ‚ÌŠT—v‚Ìà–¾‚Å‚·B
	/// </summary>
	public class user32
	{
		[DllImport("user32.dll")]
		extern public static bool GetKeyboardState(byte[] KeyState);
	}
}
