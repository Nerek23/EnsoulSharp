using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D8 RID: 216
	public class ColoredConsoleAppender : AppenderSkeleton
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x00014A38 File Offset: 0x00013A38
		public ColoredConsoleAppender()
		{
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00014A4B File Offset: 0x00013A4B
		[Obsolete("Instead use the default constructor and set the Layout property")]
		public ColoredConsoleAppender(ILayout layout) : this(layout, false)
		{
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00014A55 File Offset: 0x00013A55
		[Obsolete("Instead use the default constructor and set the Layout & Target properties")]
		public ColoredConsoleAppender(ILayout layout, bool writeToErrorStream)
		{
			this.Layout = layout;
			this.m_writeToErrorStream = writeToErrorStream;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00014A76 File Offset: 0x00013A76
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x00014A8C File Offset: 0x00013A8C
		public virtual string Target
		{
			get
			{
				if (!this.m_writeToErrorStream)
				{
					return "Console.Out";
				}
				return "Console.Error";
			}
			set
			{
				string strB = value.Trim();
				if (string.Compare("Console.Error", strB, true, CultureInfo.InvariantCulture) == 0)
				{
					this.m_writeToErrorStream = true;
					return;
				}
				this.m_writeToErrorStream = false;
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00014AC2 File Offset: 0x00013AC2
		public void AddMapping(ColoredConsoleAppender.LevelColors mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00014AD0 File Offset: 0x00013AD0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_consoleOutputWriter != null)
			{
				IntPtr consoleHandle = IntPtr.Zero;
				if (this.m_writeToErrorStream)
				{
					consoleHandle = ColoredConsoleAppender.GetStdHandle(4294967284U);
				}
				else
				{
					consoleHandle = ColoredConsoleAppender.GetStdHandle(4294967285U);
				}
				ushort attributes = 7;
				ColoredConsoleAppender.LevelColors levelColors = this.m_levelMapping.Lookup(loggingEvent.Level) as ColoredConsoleAppender.LevelColors;
				if (levelColors != null)
				{
					attributes = levelColors.CombinedColor;
				}
				string text = base.RenderLoggingEvent(loggingEvent);
				ColoredConsoleAppender.CONSOLE_SCREEN_BUFFER_INFO console_SCREEN_BUFFER_INFO;
				ColoredConsoleAppender.GetConsoleScreenBufferInfo(consoleHandle, out console_SCREEN_BUFFER_INFO);
				ColoredConsoleAppender.SetConsoleTextAttribute(consoleHandle, attributes);
				char[] array = text.ToCharArray();
				int num = array.Length;
				bool flag = false;
				if (num > 1 && array[num - 2] == '\r' && array[num - 1] == '\n')
				{
					num -= 2;
					flag = true;
				}
				this.m_consoleOutputWriter.Write(array, 0, num);
				ColoredConsoleAppender.SetConsoleTextAttribute(consoleHandle, console_SCREEN_BUFFER_INFO.wAttributes);
				if (flag)
				{
					this.m_consoleOutputWriter.Write(ColoredConsoleAppender.s_windowsNewline, 0, 2);
				}
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x00014BAA File Offset: 0x00013BAA
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00014BB0 File Offset: 0x00013BB0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			this.m_levelMapping.ActivateOptions();
			Stream stream;
			if (this.m_writeToErrorStream)
			{
				stream = Console.OpenStandardError();
			}
			else
			{
				stream = Console.OpenStandardOutput();
			}
			Encoding encoding = Encoding.GetEncoding(ColoredConsoleAppender.GetConsoleOutputCP());
			this.m_consoleOutputWriter = new StreamWriter(stream, encoding, 256);
			this.m_consoleOutputWriter.AutoFlush = true;
			GC.SuppressFinalize(this.m_consoleOutputWriter);
		}

		// Token: 0x06000689 RID: 1673
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetConsoleOutputCP();

		// Token: 0x0600068A RID: 1674
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool SetConsoleTextAttribute(IntPtr consoleHandle, ushort attributes);

		// Token: 0x0600068B RID: 1675
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool GetConsoleScreenBufferInfo(IntPtr consoleHandle, out ColoredConsoleAppender.CONSOLE_SCREEN_BUFFER_INFO bufferInfo);

		// Token: 0x0600068C RID: 1676
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetStdHandle(uint type);

		// Token: 0x040001E1 RID: 481
		private static readonly char[] s_windowsNewline = new char[]
		{
			'\r',
			'\n'
		};

		// Token: 0x040001E2 RID: 482
		public const string ConsoleOut = "Console.Out";

		// Token: 0x040001E3 RID: 483
		public const string ConsoleError = "Console.Error";

		// Token: 0x040001E4 RID: 484
		private bool m_writeToErrorStream;

		// Token: 0x040001E5 RID: 485
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x040001E6 RID: 486
		private StreamWriter m_consoleOutputWriter;

		// Token: 0x040001E7 RID: 487
		private const uint STD_OUTPUT_HANDLE = 4294967285U;

		// Token: 0x040001E8 RID: 488
		private const uint STD_ERROR_HANDLE = 4294967284U;

		// Token: 0x0200010C RID: 268
		[Flags]
		public enum Colors
		{
			// Token: 0x04000297 RID: 663
			Blue = 1,
			// Token: 0x04000298 RID: 664
			Green = 2,
			// Token: 0x04000299 RID: 665
			Red = 4,
			// Token: 0x0400029A RID: 666
			White = 7,
			// Token: 0x0400029B RID: 667
			Yellow = 6,
			// Token: 0x0400029C RID: 668
			Purple = 5,
			// Token: 0x0400029D RID: 669
			Cyan = 3,
			// Token: 0x0400029E RID: 670
			HighIntensity = 8
		}

		// Token: 0x0200010D RID: 269
		private struct COORD
		{
			// Token: 0x0400029F RID: 671
			public ushort x;

			// Token: 0x040002A0 RID: 672
			public ushort y;
		}

		// Token: 0x0200010E RID: 270
		private struct SMALL_RECT
		{
			// Token: 0x040002A1 RID: 673
			public ushort Left;

			// Token: 0x040002A2 RID: 674
			public ushort Top;

			// Token: 0x040002A3 RID: 675
			public ushort Right;

			// Token: 0x040002A4 RID: 676
			public ushort Bottom;
		}

		// Token: 0x0200010F RID: 271
		private struct CONSOLE_SCREEN_BUFFER_INFO
		{
			// Token: 0x040002A5 RID: 677
			public ColoredConsoleAppender.COORD dwSize;

			// Token: 0x040002A6 RID: 678
			public ColoredConsoleAppender.COORD dwCursorPosition;

			// Token: 0x040002A7 RID: 679
			public ushort wAttributes;

			// Token: 0x040002A8 RID: 680
			public ColoredConsoleAppender.SMALL_RECT srWindow;

			// Token: 0x040002A9 RID: 681
			public ColoredConsoleAppender.COORD dwMaximumWindowSize;
		}

		// Token: 0x02000110 RID: 272
		public class LevelColors : LevelMappingEntry
		{
			// Token: 0x170001BE RID: 446
			// (get) Token: 0x0600084E RID: 2126 RVA: 0x000196F7 File Offset: 0x000186F7
			// (set) Token: 0x0600084F RID: 2127 RVA: 0x000196FF File Offset: 0x000186FF
			public ColoredConsoleAppender.Colors ForeColor
			{
				get
				{
					return this.m_foreColor;
				}
				set
				{
					this.m_foreColor = value;
				}
			}

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x06000850 RID: 2128 RVA: 0x00019708 File Offset: 0x00018708
			// (set) Token: 0x06000851 RID: 2129 RVA: 0x00019710 File Offset: 0x00018710
			public ColoredConsoleAppender.Colors BackColor
			{
				get
				{
					return this.m_backColor;
				}
				set
				{
					this.m_backColor = value;
				}
			}

			// Token: 0x06000852 RID: 2130 RVA: 0x00019719 File Offset: 0x00018719
			public override void ActivateOptions()
			{
				base.ActivateOptions();
				this.m_combinedColor = (ushort)(this.m_foreColor + (int)((int)this.m_backColor << 4));
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x06000853 RID: 2131 RVA: 0x00019737 File Offset: 0x00018737
			internal ushort CombinedColor
			{
				get
				{
					return this.m_combinedColor;
				}
			}

			// Token: 0x040002AA RID: 682
			private ColoredConsoleAppender.Colors m_foreColor;

			// Token: 0x040002AB RID: 683
			private ColoredConsoleAppender.Colors m_backColor;

			// Token: 0x040002AC RID: 684
			private ushort m_combinedColor;
		}
	}
}
