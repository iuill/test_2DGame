using System;
using System.Runtime.InteropServices;

namespace ShootingSample.Core.Win32APIs
{
	/// <summary>
	/// kernel32 �̊T�v�̐����ł��B
	/// </summary>
	public class kernel32
	{
		[DllImport("kernel32.dll")]
		extern static uint GetTickCount();
	}
}
