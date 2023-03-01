using System;
using System.IO;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000EC RID: 236
	public class TextWriterAppender : AppenderSkeleton
	{
		// Token: 0x06000791 RID: 1937 RVA: 0x000182DA File Offset: 0x000172DA
		public TextWriterAppender()
		{
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x000182E9 File Offset: 0x000172E9
		[Obsolete("Instead use the default constructor and set the Layout & Writer properties")]
		public TextWriterAppender(ILayout layout, Stream os) : this(layout, new StreamWriter(os))
		{
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x000182F8 File Offset: 0x000172F8
		[Obsolete("Instead use the default constructor and set the Layout & Writer properties")]
		public TextWriterAppender(ILayout layout, TextWriter writer)
		{
			this.Layout = layout;
			this.Writer = writer;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x00018315 File Offset: 0x00017315
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x0001831D File Offset: 0x0001731D
		public bool ImmediateFlush
		{
			get
			{
				return this.m_immediateFlush;
			}
			set
			{
				this.m_immediateFlush = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x00018326 File Offset: 0x00017326
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x00018330 File Offset: 0x00017330
		public virtual TextWriter Writer
		{
			get
			{
				return this.m_qtw;
			}
			set
			{
				lock (this)
				{
					this.Reset();
					if (value != null)
					{
						this.m_qtw = new QuietTextWriter(value, this.ErrorHandler);
						this.WriteHeader();
					}
				}
			}
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00018388 File Offset: 0x00017388
		protected override bool PreAppendCheck()
		{
			if (!base.PreAppendCheck())
			{
				return false;
			}
			if (this.m_qtw == null)
			{
				this.PrepareWriter();
				if (this.m_qtw == null)
				{
					this.ErrorHandler.Error("No output stream or file set for the appender named [" + base.Name + "].");
					return false;
				}
			}
			if (this.m_qtw.Closed)
			{
				this.ErrorHandler.Error("Output stream for appender named [" + base.Name + "] has been closed.");
				return false;
			}
			return true;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00018407 File Offset: 0x00017407
		protected override void Append(LoggingEvent loggingEvent)
		{
			base.RenderLoggingEvent(this.m_qtw, loggingEvent);
			if (this.m_immediateFlush)
			{
				this.m_qtw.Flush();
			}
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001842C File Offset: 0x0001742C
		protected override void Append(LoggingEvent[] loggingEvents)
		{
			foreach (LoggingEvent loggingEvent in loggingEvents)
			{
				base.RenderLoggingEvent(this.m_qtw, loggingEvent);
			}
			if (this.m_immediateFlush)
			{
				this.m_qtw.Flush();
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00018470 File Offset: 0x00017470
		protected override void OnClose()
		{
			lock (this)
			{
				this.Reset();
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x000184AC File Offset: 0x000174AC
		// (set) Token: 0x0600079D RID: 1949 RVA: 0x000184B4 File Offset: 0x000174B4
		public override IErrorHandler ErrorHandler
		{
			get
			{
				return base.ErrorHandler;
			}
			set
			{
				lock (this)
				{
					if (value == null)
					{
						LogLog.Warn(TextWriterAppender.declaringType, "TextWriterAppender: You have tried to set a null error-handler.");
					}
					else
					{
						base.ErrorHandler = value;
						if (this.m_qtw != null)
						{
							this.m_qtw.ErrorHandler = value;
						}
					}
				}
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00018518 File Offset: 0x00017518
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001851B File Offset: 0x0001751B
		protected virtual void WriteFooterAndCloseWriter()
		{
			this.WriteFooter();
			this.CloseWriter();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001852C File Offset: 0x0001752C
		protected virtual void CloseWriter()
		{
			if (this.m_qtw != null)
			{
				try
				{
					this.m_qtw.Close();
				}
				catch (Exception e)
				{
					IErrorHandler errorHandler = this.ErrorHandler;
					string str = "Could not close writer [";
					QuietTextWriter qtw = this.m_qtw;
					errorHandler.Error(str + ((qtw != null) ? qtw.ToString() : null) + "]", e);
				}
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00018590 File Offset: 0x00017590
		protected virtual void Reset()
		{
			this.WriteFooterAndCloseWriter();
			this.m_qtw = null;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000185A0 File Offset: 0x000175A0
		protected virtual void WriteFooter()
		{
			if (this.Layout != null && this.m_qtw != null && !this.m_qtw.Closed)
			{
				string footer = this.Layout.Footer;
				if (footer != null)
				{
					this.m_qtw.Write(footer);
				}
			}
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x000185E8 File Offset: 0x000175E8
		protected virtual void WriteHeader()
		{
			if (this.Layout != null && this.m_qtw != null && !this.m_qtw.Closed)
			{
				string header = this.Layout.Header;
				if (header != null)
				{
					this.m_qtw.Write(header);
				}
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001862D File Offset: 0x0001762D
		protected virtual void PrepareWriter()
		{
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x0001862F File Offset: 0x0001762F
		// (set) Token: 0x060007A6 RID: 1958 RVA: 0x00018637 File Offset: 0x00017637
		protected QuietTextWriter QuietWriter
		{
			get
			{
				return this.m_qtw;
			}
			set
			{
				this.m_qtw = value;
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00018640 File Offset: 0x00017640
		public override bool Flush(int millisecondsTimeout)
		{
			if (this.m_immediateFlush)
			{
				return true;
			}
			lock (this)
			{
				this.m_qtw.Flush();
			}
			return true;
		}

		// Token: 0x04000245 RID: 581
		private QuietTextWriter m_qtw;

		// Token: 0x04000246 RID: 582
		private bool m_immediateFlush = true;

		// Token: 0x04000247 RID: 583
		private static readonly Type declaringType = typeof(TextWriterAppender);
	}
}
