using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000E2 RID: 226
	public class ManagedColoredConsoleAppender : AppenderSkeleton
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00015CDA File Offset: 0x00014CDA
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x00015CF0 File Offset: 0x00014CF0
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
				string b = value.Trim();
				if (SystemInfo.EqualsIgnoringCase("Console.Error", b))
				{
					this.m_writeToErrorStream = true;
					return;
				}
				this.m_writeToErrorStream = false;
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00015D20 File Offset: 0x00014D20
		public void AddMapping(ManagedColoredConsoleAppender.LevelColors mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00015D30 File Offset: 0x00014D30
		protected override void Append(LoggingEvent loggingEvent)
		{
			TextWriter textWriter;
			if (this.m_writeToErrorStream)
			{
				textWriter = Console.Error;
			}
			else
			{
				textWriter = Console.Out;
			}
			Console.ResetColor();
			ManagedColoredConsoleAppender.LevelColors levelColors = this.m_levelMapping.Lookup(loggingEvent.Level) as ManagedColoredConsoleAppender.LevelColors;
			if (levelColors != null)
			{
				if (levelColors.HasBackColor)
				{
					Console.BackgroundColor = levelColors.BackColor;
				}
				if (levelColors.HasForeColor)
				{
					Console.ForegroundColor = levelColors.ForeColor;
				}
			}
			string value = base.RenderLoggingEvent(loggingEvent);
			textWriter.Write(value);
			Console.ResetColor();
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00015DAC File Offset: 0x00014DAC
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00015DAF File Offset: 0x00014DAF
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			this.m_levelMapping.ActivateOptions();
		}

		// Token: 0x04000205 RID: 517
		public const string ConsoleOut = "Console.Out";

		// Token: 0x04000206 RID: 518
		public const string ConsoleError = "Console.Error";

		// Token: 0x04000207 RID: 519
		private bool m_writeToErrorStream;

		// Token: 0x04000208 RID: 520
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x0200011A RID: 282
		public class LevelColors : LevelMappingEntry
		{
			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x06000894 RID: 2196 RVA: 0x00019E1C File Offset: 0x00018E1C
			// (set) Token: 0x06000895 RID: 2197 RVA: 0x00019E24 File Offset: 0x00018E24
			public ConsoleColor ForeColor
			{
				get
				{
					return this.foreColor;
				}
				set
				{
					this.foreColor = value;
					this.hasForeColor = true;
				}
			}

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x06000896 RID: 2198 RVA: 0x00019E34 File Offset: 0x00018E34
			internal bool HasForeColor
			{
				get
				{
					return this.hasForeColor;
				}
			}

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x06000897 RID: 2199 RVA: 0x00019E3C File Offset: 0x00018E3C
			// (set) Token: 0x06000898 RID: 2200 RVA: 0x00019E44 File Offset: 0x00018E44
			public ConsoleColor BackColor
			{
				get
				{
					return this.backColor;
				}
				set
				{
					this.backColor = value;
					this.hasBackColor = true;
				}
			}

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x06000899 RID: 2201 RVA: 0x00019E54 File Offset: 0x00018E54
			internal bool HasBackColor
			{
				get
				{
					return this.hasBackColor;
				}
			}

			// Token: 0x040002DD RID: 733
			private ConsoleColor foreColor;

			// Token: 0x040002DE RID: 734
			private bool hasForeColor;

			// Token: 0x040002DF RID: 735
			private ConsoleColor backColor;

			// Token: 0x040002E0 RID: 736
			private bool hasBackColor;
		}
	}
}
