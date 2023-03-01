using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace log4net.Util
{
	// Token: 0x0200001D RID: 29
	public sealed class NativeError
	{
		// Token: 0x0600012F RID: 303 RVA: 0x000045E7 File Offset: 0x000035E7
		private NativeError(int number, string message)
		{
			this.m_number = number;
			this.m_message = message;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000130 RID: 304 RVA: 0x000045FD File Offset: 0x000035FD
		public int Number
		{
			get
			{
				return this.m_number;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00004605 File Offset: 0x00003605
		public string Message
		{
			get
			{
				return this.m_message;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000460D File Offset: 0x0000360D
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public static NativeError GetLastError()
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			return new NativeError(lastWin32Error, NativeError.GetErrorMessage(lastWin32Error));
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000461F File Offset: 0x0000361F
		public static NativeError GetError(int number)
		{
			return new NativeError(number, NativeError.GetErrorMessage(number));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004630 File Offset: 0x00003630
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public static string GetErrorMessage(int messageId)
		{
			int num = 256;
			int num2 = 512;
			int num3 = 4096;
			string text = "";
			IntPtr intPtr = 0;
			IntPtr arguments = 0;
			if (messageId != 0)
			{
				if (NativeError.FormatMessage(num | num3 | num2, ref intPtr, messageId, 0, ref text, 255, arguments) > 0)
				{
					text = text.TrimEnd(new char[]
					{
						'\r',
						'\n'
					});
				}
				else
				{
					text = null;
				}
			}
			else
			{
				text = null;
			}
			return text;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000046A4 File Offset: 0x000036A4
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "0x{0:x8}", new object[]
			{
				this.Number
			}) + ((this.Message != null) ? (": " + this.Message) : "");
		}

		// Token: 0x06000136 RID: 310
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref string lpBuffer, int nSize, IntPtr Arguments);

		// Token: 0x04000035 RID: 53
		private int m_number;

		// Token: 0x04000036 RID: 54
		private string m_message;
	}
}
