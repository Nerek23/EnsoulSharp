using System;

namespace log4net.Core
{
	// Token: 0x020000A5 RID: 165
	public class ExceptionEvaluator : ITriggeringEventEvaluator
	{
		// Token: 0x0600046E RID: 1134 RVA: 0x0000ECC6 File Offset: 0x0000DCC6
		public ExceptionEvaluator()
		{
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000ECCE File Offset: 0x0000DCCE
		public ExceptionEvaluator(Type exType, bool triggerOnSubClass)
		{
			if (exType == null)
			{
				throw new ArgumentNullException("exType");
			}
			this.m_type = exType;
			this.m_triggerOnSubclass = triggerOnSubClass;
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000ECF8 File Offset: 0x0000DCF8
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x0000ED00 File Offset: 0x0000DD00
		public Type ExceptionType
		{
			get
			{
				return this.m_type;
			}
			set
			{
				this.m_type = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x0000ED09 File Offset: 0x0000DD09
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x0000ED11 File Offset: 0x0000DD11
		public bool TriggerOnSubclass
		{
			get
			{
				return this.m_triggerOnSubclass;
			}
			set
			{
				this.m_triggerOnSubclass = value;
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000ED1C File Offset: 0x0000DD1C
		public bool IsTriggeringEvent(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_triggerOnSubclass && loggingEvent.ExceptionObject != null)
			{
				Type type = loggingEvent.ExceptionObject.GetType();
				return type == this.m_type || this.m_type.IsAssignableFrom(type);
			}
			return !this.m_triggerOnSubclass && loggingEvent.ExceptionObject != null && loggingEvent.ExceptionObject.GetType() == this.m_type;
		}

		// Token: 0x04000137 RID: 311
		private Type m_type;

		// Token: 0x04000138 RID: 312
		private bool m_triggerOnSubclass;
	}
}
