using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// user32 �̊T�v�̐����ł��B
	/// </summary>
	public class user32
	{
		[DllImport("user32.dll")]
		extern public static bool GetKeyboardState(byte[] KeyState);
	}
}
