using System;
using System.Collections;
using System.Globalization;
using System.IO;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D4 RID: 212
	public abstract class AppenderSkeleton : IAppender, IBulkAppender, IOptionHandler, IFlushable
	{
		// Token: 0x06000640 RID: 1600 RVA: 0x00013E0C File Offset: 0x00012E0C
		protected AppenderSkeleton()
		{
			this.m_errorHandler = new OnlyOnceErrorHandler(base.GetType().Name);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00013E2C File Offset: 0x00012E2C
		~AppenderSkeleton()
		{
			if (!this.m_closed)
			{
				LogLog.Debug(AppenderSkeleton.declaringType, "Finalizing appender named [" + this.m_name + "].");
				this.Close();
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x00013E80 File Offset: 0x00012E80
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x00013E88 File Offset: 0x00012E88
		public Level Threshold
		{
			get
			{
				return this.m_threshold;
			}
			set
			{
				this.m_threshold = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x00013E91 File Offset: 0x00012E91
		// (set) Token: 0x06000645 RID: 1605 RVA: 0x00013E9C File Offset: 0x00012E9C
		public virtual IErrorHandler ErrorHandler
		{
			get
			{
				return this.m_errorHandler;
			}
			set
			{
				lock (this)
				{
					if (value == null)
					{
						LogLog.Warn(AppenderSkeleton.declaringType, "You have tried to set a null error-handler.");
					}
					else
					{
						this.m_errorHandler = value;
					}
				}
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x00013EEC File Offset: 0x00012EEC
		public virtual IFilter FilterHead
		{
			get
			{
				return this.m_headFilter;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00013EF4 File Offset: 0x00012EF4
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00013EFC File Offset: 0x00012EFC
		public virtual ILayout Layout
		{
			get
			{
				return this.m_layout;
			}
			set
			{
				this.m_layout = value;
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00013F05 File Offset: 0x00012F05
		public virtual void ActivateOptions()
		{
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x00013F07 File Offset: 0x00012F07
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x00013F0F File Offset: 0x00012F0F
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00013F18 File Offset: 0x00012F18
		public void Close()
		{
			lock (this)
			{
				if (!this.m_closed)
				{
					this.OnClose();
					this.m_closed = true;
				}
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00013F64 File Offset: 0x00012F64
		public void DoAppend(LoggingEvent loggingEvent)
		{
			lock (this)
			{
				if (this.m_closed)
				{
					this.ErrorHandler.Error("Attempted to append to closed appender named [" + this.m_name + "].");
				}
				else if (!this.m_recursiveGuard)
				{
					try
					{
						this.m_recursiveGuard = true;
						if (this.FilterEvent(loggingEvent) && this.PreAppendCheck())
						{
							this.Append(loggingEvent);
						}
					}
					catch (Exception e)
					{
						this.ErrorHandler.Error("Failed in DoAppend", e);
					}
					finally
					{
						this.m_recursiveGuard = false;
					}
				}
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00014024 File Offset: 0x00013024
		public void DoAppend(LoggingEvent[] loggingEvents)
		{
			lock (this)
			{
				if (this.m_closed)
				{
					this.ErrorHandler.Error("Attempted to append to closed appender named [" + this.m_name + "].");
				}
				else if (!this.m_recursiveGuard)
				{
					try
					{
						this.m_recursiveGuard = true;
						ArrayList arrayList = new ArrayList(loggingEvents.Length);
						foreach (LoggingEvent loggingEvent in loggingEvents)
						{
							if (this.FilterEvent(loggingEvent))
							{
								arrayList.Add(loggingEvent);
							}
						}
						if (arrayList.Count > 0 && this.PreAppendCheck())
						{
							this.Append((LoggingEvent[])arrayList.ToArray(typeof(LoggingEvent)));
						}
					}
					catch (Exception e)
					{
						this.ErrorHandler.Error("Failed in Bulk DoAppend", e);
					}
					finally
					{
						this.m_recursiveGuard = false;
					}
				}
			}
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x00014134 File Offset: 0x00013134
		protected virtual bool FilterEvent(LoggingEvent loggingEvent)
		{
			if (!this.IsAsSevereAsThreshold(loggingEvent.Level))
			{
				return false;
			}
			IFilter filter = this.FilterHead;
			while (filter != null)
			{
				switch (filter.Decide(loggingEvent))
				{
				case FilterDecision.Deny:
					return false;
				case FilterDecision.Neutral:
					filter = filter.Next;
					break;
				case FilterDecision.Accept:
					filter = null;
					break;
				}
			}
			return true;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001418C File Offset: 0x0001318C
		public virtual void AddFilter(IFilter filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException("filter param must not be null");
			}
			if (this.m_headFilter == null)
			{
				this.m_tailFilter = filter;
				this.m_headFilter = filter;
				return;
			}
			this.m_tailFilter.Next = filter;
			this.m_tailFilter = filter;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000141D4 File Offset: 0x000131D4
		public virtual void ClearFilters()
		{
			this.m_headFilter = (this.m_tailFilter = null);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x000141F1 File Offset: 0x000131F1
		protected virtual bool IsAsSevereAsThreshold(Level level)
		{
			return this.m_threshold == null || level >= this.m_threshold;
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001420F File Offset: 0x0001320F
		protected virtual void OnClose()
		{
		}

		// Token: 0x06000654 RID: 1620
		protected abstract void Append(LoggingEvent loggingEvent);

		// Token: 0x06000655 RID: 1621 RVA: 0x00014214 File Offset: 0x00013214
		protected virtual void Append(LoggingEvent[] loggingEvents)
		{
			foreach (LoggingEvent loggingEvent in loggingEvents)
			{
				this.Append(loggingEvent);
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001423C File Offset: 0x0001323C
		protected virtual bool PreAppendCheck()
		{
			if (this.m_layout == null && this.RequiresLayout)
			{
				this.ErrorHandler.Error("AppenderSkeleton: No layout set for the appender named [" + this.m_name + "].");
				return false;
			}
			return true;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00014274 File Offset: 0x00013274
		protected string RenderLoggingEvent(LoggingEvent loggingEvent)
		{
			if (this.m_renderWriter == null)
			{
				this.m_renderWriter = new ReusableStringWriter(CultureInfo.InvariantCulture);
			}
			ReusableStringWriter renderWriter = this.m_renderWriter;
			string result;
			lock (renderWriter)
			{
				this.m_renderWriter.Reset(1024, 256);
				this.RenderLoggingEvent(this.m_renderWriter, loggingEvent);
				result = this.m_renderWriter.ToString();
			}
			return result;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x000142F8 File Offset: 0x000132F8
		protected void RenderLoggingEvent(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (this.m_layout == null)
			{
				throw new InvalidOperationException("A layout must be set");
			}
			if (!this.m_layout.IgnoresException)
			{
				this.m_layout.Format(writer, loggingEvent);
				return;
			}
			string exceptionString = loggingEvent.GetExceptionString();
			if (exceptionString != null && exceptionString.Length > 0)
			{
				this.m_layout.Format(writer, loggingEvent);
				writer.WriteLine(exceptionString);
				return;
			}
			this.m_layout.Format(writer, loggingEvent);
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x00014368 File Offset: 0x00013368
		protected virtual bool RequiresLayout
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001436B File Offset: 0x0001336B
		public virtual bool Flush(int millisecondsTimeout)
		{
			return true;
		}

		// Token: 0x040001CB RID: 459
		private ILayout m_layout;

		// Token: 0x040001CC RID: 460
		private string m_name;

		// Token: 0x040001CD RID: 461
		private Level m_threshold;

		// Token: 0x040001CE RID: 462
		private IErrorHandler m_errorHandler;

		// Token: 0x040001CF RID: 463
		private IFilter m_headFilter;

		// Token: 0x040001D0 RID: 464
		private IFilter m_tailFilter;

		// Token: 0x040001D1 RID: 465
		private bool m_closed;

		// Token: 0x040001D2 RID: 466
		private bool m_recursiveGuard;

		// Token: 0x040001D3 RID: 467
		private ReusableStringWriter m_renderWriter;

		// Token: 0x040001D4 RID: 468
		private const int c_renderBufferSize = 256;

		// Token: 0x040001D5 RID: 469
		private const int c_renderBufferMaxCapacity = 1024;

		// Token: 0x040001D6 RID: 470
		private static readonly Type declaringType = typeof(AppenderSkeleton);
	}
}
