using System;
using System.Runtime.InteropServices;
using SharpDX.IO;
using SharpDX.Mathematics.Interop;
using SharpDX.Win32;

namespace SharpDX
{
	// Token: 0x02000002 RID: 2
	internal class Win32Native
	{
		// Token: 0x06000002 RID: 2
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile", SetLastError = true)]
		internal static extern IntPtr Create(string fileName, NativeFileAccess desiredAccess, NativeFileShare shareMode, IntPtr securityAttributes, NativeFileMode mode, NativeFileOptions flagsAndOptions, IntPtr templateFile);

		// Token: 0x06000003 RID: 3
		[DllImport("user32.dll")]
		public static extern int PeekMessage(out NativeMessage lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax, int wRemoveMsg);

		// Token: 0x06000004 RID: 4
		[DllImport("user32.dll")]
		public static extern int GetMessage(out NativeMessage lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);

		// Token: 0x06000005 RID: 5
		[DllImport("user32.dll")]
		public static extern int TranslateMessage(ref NativeMessage lpMsg);

		// Token: 0x06000006 RID: 6
		[DllImport("user32.dll")]
		public static extern int DispatchMessage(ref NativeMessage lpMsg);

		// Token: 0x06000007 RID: 7 RVA: 0x00002057 File Offset: 0x00000257
		public static IntPtr GetWindowLong(IntPtr hWnd, Win32Native.WindowLongType index)
		{
			if (IntPtr.Size == 4)
			{
				return Win32Native.GetWindowLong32(hWnd, index);
			}
			return Win32Native.GetWindowLong64(hWnd, index);
		}

		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr GetFocus();

		// Token: 0x06000009 RID: 9
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
		private static extern IntPtr GetWindowLong32(IntPtr hwnd, Win32Native.WindowLongType index);

		// Token: 0x0600000A RID: 10
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
		private static extern IntPtr GetWindowLong64(IntPtr hwnd, Win32Native.WindowLongType index);

		// Token: 0x0600000B RID: 11 RVA: 0x00002070 File Offset: 0x00000270
		public static IntPtr SetWindowLong(IntPtr hwnd, Win32Native.WindowLongType index, IntPtr wndProcPtr)
		{
			if (IntPtr.Size == 4)
			{
				return Win32Native.SetWindowLong32(hwnd, index, wndProcPtr);
			}
			return Win32Native.SetWindowLongPtr64(hwnd, index, wndProcPtr);
		}

		// Token: 0x0600000C RID: 12
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

		// Token: 0x0600000D RID: 13
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
		private static extern IntPtr SetWindowLong32(IntPtr hwnd, Win32Native.WindowLongType index, IntPtr wndProc);

		// Token: 0x0600000E RID: 14 RVA: 0x0000208B File Offset: 0x0000028B
		public static bool ShowWindow(IntPtr hWnd, bool windowVisible)
		{
			return Win32Native.ShowWindow(hWnd, windowVisible ? 1 : 0);
		}

		// Token: 0x0600000F RID: 15
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern bool ShowWindow(IntPtr hWnd, int mCmdShow);

		// Token: 0x06000010 RID: 16
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
		private static extern IntPtr SetWindowLongPtr64(IntPtr hwnd, Win32Native.WindowLongType index, IntPtr wndProc);

		// Token: 0x06000011 RID: 17
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000012 RID: 18
		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out RawRectangle lpRect);

		// Token: 0x06000013 RID: 19
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x02000003 RID: 3
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TextMetric
		{
			// Token: 0x04000001 RID: 1
			public int tmHeight;

			// Token: 0x04000002 RID: 2
			public int tmAscent;

			// Token: 0x04000003 RID: 3
			public int tmDescent;

			// Token: 0x04000004 RID: 4
			public int tmInternalLeading;

			// Token: 0x04000005 RID: 5
			public int tmExternalLeading;

			// Token: 0x04000006 RID: 6
			public int tmAveCharWidth;

			// Token: 0x04000007 RID: 7
			public int tmMaxCharWidth;

			// Token: 0x04000008 RID: 8
			public int tmWeight;

			// Token: 0x04000009 RID: 9
			public int tmOverhang;

			// Token: 0x0400000A RID: 10
			public int tmDigitizedAspectX;

			// Token: 0x0400000B RID: 11
			public int tmDigitizedAspectY;

			// Token: 0x0400000C RID: 12
			public char tmFirstChar;

			// Token: 0x0400000D RID: 13
			public char tmLastChar;

			// Token: 0x0400000E RID: 14
			public char tmDefaultChar;

			// Token: 0x0400000F RID: 15
			public char tmBreakChar;

			// Token: 0x04000010 RID: 16
			public byte tmItalic;

			// Token: 0x04000011 RID: 17
			public byte tmUnderlined;

			// Token: 0x04000012 RID: 18
			public byte tmStruckOut;

			// Token: 0x04000013 RID: 19
			public byte tmPitchAndFamily;

			// Token: 0x04000014 RID: 20
			public byte tmCharSet;
		}

		// Token: 0x02000004 RID: 4
		public enum WindowLongType
		{
			// Token: 0x04000016 RID: 22
			WndProc = -4,
			// Token: 0x04000017 RID: 23
			HInstance = -6,
			// Token: 0x04000018 RID: 24
			HwndParent = -8,
			// Token: 0x04000019 RID: 25
			Style = -16,
			// Token: 0x0400001A RID: 26
			ExtendedStyle = -20,
			// Token: 0x0400001B RID: 27
			UserData = -21,
			// Token: 0x0400001C RID: 28
			Id = -12
		}

		// Token: 0x02000005 RID: 5
		// (Invoke) Token: 0x06000016 RID: 22
		public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
	}
}
