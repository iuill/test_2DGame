using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// kernel32 の概要の説明です。
	/// </summary>
	public class kernel32
	{
		[DllImport("kernel32.dll")]
		extern static uint GetTickCount();
	}
}
