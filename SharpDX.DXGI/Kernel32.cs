using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000016 RID: 22
	internal static class Kernel32
	{
		// Token: 0x060000AB RID: 171
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, Kernel32.LoadLibraryFlags dwFlags);

		// Token: 0x060000AC RID: 172
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x060000AD RID: 173
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x02000017 RID: 23
		[Flags]
		public enum LoadLibraryFlags : uint
		{
			// Token: 0x0400000E RID: 14
			DontResolveDllReferences = 1U,
			// Token: 0x0400000F RID: 15
			LoadIgnoreCodeAuthzLevel = 16U,
			// Token: 0x04000010 RID: 16
			LoadLibraryAsDatafile = 2U,
			// Token: 0x04000011 RID: 17
			LoadLibraryAsDatafileExclusive = 64U,
			// Token: 0x04000012 RID: 18
			LoadLibraryAsImageResource = 32U,
			// Token: 0x04000013 RID: 19
			LoadLibrarySearchApplicationDir = 512U,
			// Token: 0x04000014 RID: 20
			LoadLibrarySearchDefaultDirs = 4096U,
			// Token: 0x04000015 RID: 21
			LoadLibrarySearchDllLoadDir = 256U,
			// Token: 0x04000016 RID: 22
			LoadLibrarySearchSystem32 = 2048U,
			// Token: 0x04000017 RID: 23
			LoadLibrarySearchUserDirs = 1024U,
			// Token: 0x04000018 RID: 24
			LoadWithAlteredSearchPath = 8U
		}
	}
}
