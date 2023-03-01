using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace EnsoulSharp.SDK.Utility.MouseActivity.WinApi
{
	// Token: 0x0200008E RID: 142
	internal class Hooker
	{
		// Token: 0x06000526 RID: 1318 RVA: 0x000254E3 File Offset: 0x000236E3
		internal int Subscribe(int hookId, HookCallback hookCallback)
		{
			int num = Hooker.SetWindowsHookEx(hookId, hookCallback, IntPtr.Zero, Hooker.GetCurrentThreadId());
			if (num == 0)
			{
				Hooker.ThrowLastUnmanagedErrorAsException();
			}
			return num;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000254FE File Offset: 0x000236FE
		internal void Unsubscribe(int handle)
		{
			if (Hooker.UnhookWindowsHookEx(handle) == 0)
			{
				Hooker.ThrowLastUnmanagedErrorAsException();
			}
		}

		// Token: 0x06000528 RID: 1320
		[DllImport("kernel32")]
		private static extern int GetCurrentThreadId();

		// Token: 0x06000529 RID: 1321
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		internal static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

		// Token: 0x0600052A RID: 1322
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int SetWindowsHookEx(int idHook, HookCallback lpfn, IntPtr hMod, int dwThreadId);

		// Token: 0x0600052B RID: 1323
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int UnhookWindowsHookEx(int idHook);

		// Token: 0x0600052C RID: 1324 RVA: 0x0002550D File Offset: 0x0002370D
		internal static void ThrowLastUnmanagedErrorAsException()
		{
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
	}
}
