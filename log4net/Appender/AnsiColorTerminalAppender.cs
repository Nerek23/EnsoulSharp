using System;
using System.Text;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D2 RID: 210
	public class AnsiColorTerminalAppender : AppenderSkeleton
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x000135B2 File Offset: 0x000125B2
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x000135C8 File Offset: 0x000125C8
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

		// Token: 0x0600060E RID: 1550 RVA: 0x000135F8 File Offset: 0x000125F8
		public void AddMapping(AnsiColorTerminalAppender.LevelColors mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00013608 File Offset: 0x00012608
		protected override void Append(LoggingEvent loggingEvent)
		{
			string text = base.RenderLoggingEvent(loggingEvent);
			AnsiColorTerminalAppender.LevelColors levelColors = this.m_levelMapping.Lookup(loggingEvent.Level) as AnsiColorTerminalAppender.LevelColors;
			if (levelColors != null)
			{
				text = levelColors.CombinedColor + text;
			}
			if (text.Length > 1)
			{
				if (text.EndsWith("\r\n") || text.EndsWith("\n\r"))
				{
					text = text.Insert(text.Length - 2, "\u001b[0m");
				}
				else if (text.EndsWith("\n") || text.EndsWith("\r"))
				{
					text = text.Insert(text.Length - 1, "\u001b[0m");
				}
				else
				{
					text += "\u001b[0m";
				}
			}
			else if (text[0] == '\n' || text[0] == '\r')
			{
				text = "\u001b[0m" + text;
			}
			else
			{
				text += "\u001b[0m";
			}
			if (this.m_writeToErrorStream)
			{
				Console.Error.Write(text);
				return;
			}
			Console.Write(text);
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x00013705 File Offset: 0x00012705
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00013708 File Offset: 0x00012708
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			this.m_levelMapping.ActivateOptions();
		}

		// Token: 0x040001C1 RID: 449
		public const string ConsoleOut = "Console.Out";

		// Token: 0x040001C2 RID: 450
		public const string ConsoleError = "Console.Error";

		// Token: 0x040001C3 RID: 451
		private bool m_writeToErrorStream;

		// Token: 0x040001C4 RID: 452
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x040001C5 RID: 453
		private const string PostEventCodes = "\u001b[0m";

		// Token: 0x02000105 RID: 261
		[Flags]
		public enum AnsiAttributes
		{
			// Token: 0x0400027B RID: 635
			Bright = 1,
			// Token: 0x0400027C RID: 636
			Dim = 2,
			// Token: 0x0400027D RID: 637
			Underscore = 4,
			// Token: 0x0400027E RID: 638
			Blink = 8,
			// Token: 0x0400027F RID: 639
			Reverse = 16,
			// Token: 0x04000280 RID: 640
			Hidden = 32,
			// Token: 0x04000281 RID: 641
			Strikethrough = 64,
			// Token: 0x04000282 RID: 642
			Light = 128
		}

		// Token: 0x02000106 RID: 262
		public enum AnsiColor
		{
			// Token: 0x04000284 RID: 644
			Black,
			// Token: 0x04000285 RID: 645
			Red,
			// Token: 0x04000286 RID: 646
			Green,
			// Token: 0x04000287 RID: 647
			Yellow,
			// Token: 0x04000288 RID: 648
			Blue,
			// Token: 0x04000289 RID: 649
			Magenta,
			// Token: 0x0400028A RID: 650
			Cyan,
			// Token: 0x0400028B RID: 651
			White
		}

		// Token: 0x02000107 RID: 263
		public class LevelColors : LevelMappingEntry
		{
			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x06000824 RID: 2084 RVA: 0x000193C4 File Offset: 0x000183C4
			// (set) Token: 0x06000825 RID: 2085 RVA: 0x000193CC File Offset: 0x000183CC
			public AnsiColorTerminalAppender.AnsiColor ForeColor
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

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x06000826 RID: 2086 RVA: 0x000193D5 File Offset: 0x000183D5
			// (set) Token: 0x06000827 RID: 2087 RVA: 0x000193DD File Offset: 0x000183DD
			public AnsiColorTerminalAppender.AnsiColor BackColor
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

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x06000828 RID: 2088 RVA: 0x000193E6 File Offset: 0x000183E6
			// (set) Token: 0x06000829 RID: 2089 RVA: 0x000193EE File Offset: 0x000183EE
			public AnsiColorTerminalAppender.AnsiAttributes Attributes
			{
				get
				{
					return this.m_attributes;
				}
				set
				{
					this.m_attributes = value;
				}
			}

			// Token: 0x0600082A RID: 2090 RVA: 0x000193F8 File Offset: 0x000183F8
			public override void ActivateOptions()
			{
				base.ActivateOptions();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("\u001b[0;");
				int num = ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Light) > (AnsiColorTerminalAppender.AnsiAttributes)0) ? 60 : 0;
				stringBuilder.Append((int)(30 + num + this.m_foreColor));
				stringBuilder.Append(';');
				stringBuilder.Append((int)(40 + num + this.m_backColor));
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Bright) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";1");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Dim) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";2");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Underscore) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";4");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Blink) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";5");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Reverse) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";7");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Hidden) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";8");
				}
				if ((this.m_attributes & AnsiColorTerminalAppender.AnsiAttributes.Strikethrough) > (AnsiColorTerminalAppender.AnsiAttributes)0)
				{
					stringBuilder.Append(";9");
				}
				stringBuilder.Append('m');
				this.m_combinedColor = stringBuilder.ToString();
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x0600082B RID: 2091 RVA: 0x00019518 File Offset: 0x00018518
			internal string CombinedColor
			{
				get
				{
					return this.m_combinedColor;
				}
			}

			// Token: 0x0400028C RID: 652
			private AnsiColorTerminalAppender.AnsiColor m_foreColor;

			// Token: 0x0400028D RID: 653
			private AnsiColorTerminalAppender.AnsiColor m_backColor;

			// Token: 0x0400028E RID: 654
			private AnsiColorTerminalAppender.AnsiAttributes m_attributes;

			// Token: 0x0400028F RID: 655
			private string m_combinedColor = "";
		}
	}
}
