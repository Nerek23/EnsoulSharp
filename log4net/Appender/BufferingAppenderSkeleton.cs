using System;
using System.Collections;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D6 RID: 214
	public abstract class BufferingAppenderSkeleton : AppenderSkeleton
	{
		// Token: 0x06000661 RID: 1633 RVA: 0x00014428 File Offset: 0x00013428
		protected BufferingAppenderSkeleton() : this(true)
		{
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00014431 File Offset: 0x00013431
		protected BufferingAppenderSkeleton(bool eventMustBeFixed)
		{
			this.m_eventMustBeFixed = eventMustBeFixed;
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x00014456 File Offset: 0x00013456
		// (set) Token: 0x06000664 RID: 1636 RVA: 0x0001445E File Offset: 0x0001345E
		public bool Lossy
		{
			get
			{
				return this.m_lossy;
			}
			set
			{
				this.m_lossy = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x00014467 File Offset: 0x00013467
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x0001446F File Offset: 0x0001346F
		public int BufferSize
		{
			get
			{
				return this.m_bufferSize;
			}
			set
			{
				this.m_bufferSize = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x00014478 File Offset: 0x00013478
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x00014480 File Offset: 0x00013480
		public ITriggeringEventEvaluator Evaluator
		{
			get
			{
				return this.m_evaluator;
			}
			set
			{
				this.m_evaluator = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00014489 File Offset: 0x00013489
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x00014491 File Offset: 0x00013491
		public ITriggeringEventEvaluator LossyEvaluator
		{
			get
			{
				return this.m_lossyEvaluator;
			}
			set
			{
				this.m_lossyEvaluator = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x0001449A File Offset: 0x0001349A
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x000144A9 File Offset: 0x000134A9
		[Obsolete("Use Fix property")]
		public virtual bool OnlyFixPartialEventData
		{
			get
			{
				return this.Fix == FixFlags.Partial;
			}
			set
			{
				if (value)
				{
					this.Fix = FixFlags.Partial;
					return;
				}
				this.Fix = FixFlags.All;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x000144C5 File Offset: 0x000134C5
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x000144CD File Offset: 0x000134CD
		public virtual FixFlags Fix
		{
			get
			{
				return this.m_fixFlags;
			}
			set
			{
				this.m_fixFlags = value;
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x000144D6 File Offset: 0x000134D6
		public override bool Flush(int millisecondsTimeout)
		{
			this.Flush();
			return true;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x000144DF File Offset: 0x000134DF
		public virtual void Flush()
		{
			this.Flush(false);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x000144E8 File Offset: 0x000134E8
		public virtual void Flush(bool flushLossyBuffer)
		{
			lock (this)
			{
				if (this.m_cb != null && this.m_cb.Length > 0)
				{
					if (this.m_lossy)
					{
						if (flushLossyBuffer)
						{
							if (this.m_lossyEvaluator != null)
							{
								LoggingEvent[] array = this.m_cb.PopAll();
								ArrayList arrayList = new ArrayList(array.Length);
								foreach (LoggingEvent loggingEvent in array)
								{
									if (this.m_lossyEvaluator.IsTriggeringEvent(loggingEvent))
									{
										arrayList.Add(loggingEvent);
									}
								}
								if (arrayList.Count > 0)
								{
									this.SendBuffer((LoggingEvent[])arrayList.ToArray(typeof(LoggingEvent)));
								}
							}
							else
							{
								this.m_cb.Clear();
							}
						}
					}
					else
					{
						this.SendFromBuffer(null, this.m_cb);
					}
				}
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x000145D8 File Offset: 0x000135D8
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.m_lossy && this.m_evaluator == null)
			{
				this.ErrorHandler.Error("Appender [" + base.Name + "] is Lossy but has no Evaluator. The buffer will never be sent!");
			}
			if (this.m_bufferSize > 1)
			{
				this.m_cb = new CyclicBuffer(this.m_bufferSize);
				return;
			}
			this.m_cb = null;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001463D File Offset: 0x0001363D
		protected override void OnClose()
		{
			this.Flush(true);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00014648 File Offset: 0x00013648
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_cb == null || this.m_bufferSize <= 1)
			{
				if (!this.m_lossy || (this.m_evaluator != null && this.m_evaluator.IsTriggeringEvent(loggingEvent)) || (this.m_lossyEvaluator != null && this.m_lossyEvaluator.IsTriggeringEvent(loggingEvent)))
				{
					if (this.m_eventMustBeFixed)
					{
						loggingEvent.Fix = this.Fix;
					}
					this.SendBuffer(new LoggingEvent[]
					{
						loggingEvent
					});
					return;
				}
			}
			else
			{
				loggingEvent.Fix = this.Fix;
				LoggingEvent loggingEvent2 = this.m_cb.Append(loggingEvent);
				if (loggingEvent2 != null)
				{
					if (!this.m_lossy)
					{
						this.SendFromBuffer(loggingEvent2, this.m_cb);
						return;
					}
					if (this.m_lossyEvaluator == null || !this.m_lossyEvaluator.IsTriggeringEvent(loggingEvent2))
					{
						loggingEvent2 = null;
					}
					if (this.m_evaluator != null && this.m_evaluator.IsTriggeringEvent(loggingEvent))
					{
						this.SendFromBuffer(loggingEvent2, this.m_cb);
						return;
					}
					if (loggingEvent2 != null)
					{
						this.SendBuffer(new LoggingEvent[]
						{
							loggingEvent2
						});
						return;
					}
				}
				else if (this.m_evaluator != null && this.m_evaluator.IsTriggeringEvent(loggingEvent))
				{
					this.SendFromBuffer(null, this.m_cb);
				}
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001476C File Offset: 0x0001376C
		protected virtual void SendFromBuffer(LoggingEvent firstLoggingEvent, CyclicBuffer buffer)
		{
			LoggingEvent[] array = buffer.PopAll();
			if (firstLoggingEvent == null)
			{
				this.SendBuffer(array);
				return;
			}
			if (array.Length == 0)
			{
				this.SendBuffer(new LoggingEvent[]
				{
					firstLoggingEvent
				});
				return;
			}
			LoggingEvent[] array2 = new LoggingEvent[array.Length + 1];
			Array.Copy(array, 0, array2, 1, array.Length);
			array2[0] = firstLoggingEvent;
			this.SendBuffer(array2);
		}

		// Token: 0x06000676 RID: 1654
		protected abstract void SendBuffer(LoggingEvent[] events);

		// Token: 0x040001D8 RID: 472
		private const int DEFAULT_BUFFER_SIZE = 512;

		// Token: 0x040001D9 RID: 473
		private int m_bufferSize = 512;

		// Token: 0x040001DA RID: 474
		private CyclicBuffer m_cb;

		// Token: 0x040001DB RID: 475
		private ITriggeringEventEvaluator m_evaluator;

		// Token: 0x040001DC RID: 476
		private bool m_lossy;

		// Token: 0x040001DD RID: 477
		private ITriggeringEventEvaluator m_lossyEvaluator;

		// Token: 0x040001DE RID: 478
		private FixFlags m_fixFlags = FixFlags.All;

		// Token: 0x040001DF RID: 479
		private readonly bool m_eventMustBeFixed;
	}
}
