using System;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x0200000E RID: 14
	public class CyclicBuffer
	{
		// Token: 0x0600008A RID: 138 RVA: 0x00002AA4 File Offset: 0x00001AA4
		public CyclicBuffer(int maxSize)
		{
			if (maxSize < 1)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("maxSize", maxSize, "Parameter: maxSize, Value: [" + maxSize.ToString() + "] out of range. Non zero positive integer required");
			}
			this.m_maxSize = maxSize;
			this.m_events = new LoggingEvent[maxSize];
			this.m_first = 0;
			this.m_last = 0;
			this.m_numElems = 0;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002B0C File Offset: 0x00001B0C
		public LoggingEvent Append(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			LoggingEvent result;
			lock (this)
			{
				LoggingEvent loggingEvent2 = this.m_events[this.m_last];
				this.m_events[this.m_last] = loggingEvent;
				int num = this.m_last + 1;
				this.m_last = num;
				if (num == this.m_maxSize)
				{
					this.m_last = 0;
				}
				if (this.m_numElems < this.m_maxSize)
				{
					this.m_numElems++;
				}
				else
				{
					num = this.m_first + 1;
					this.m_first = num;
					if (num == this.m_maxSize)
					{
						this.m_first = 0;
					}
				}
				if (this.m_numElems < this.m_maxSize)
				{
					result = null;
				}
				else
				{
					result = loggingEvent2;
				}
			}
			return result;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002BE4 File Offset: 0x00001BE4
		public LoggingEvent PopOldest()
		{
			LoggingEvent result;
			lock (this)
			{
				LoggingEvent loggingEvent = null;
				if (this.m_numElems > 0)
				{
					this.m_numElems--;
					loggingEvent = this.m_events[this.m_first];
					this.m_events[this.m_first] = null;
					int num = this.m_first + 1;
					this.m_first = num;
					if (num == this.m_maxSize)
					{
						this.m_first = 0;
					}
				}
				result = loggingEvent;
			}
			return result;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002C74 File Offset: 0x00001C74
		public LoggingEvent[] PopAll()
		{
			LoggingEvent[] result;
			lock (this)
			{
				LoggingEvent[] array = new LoggingEvent[this.m_numElems];
				if (this.m_numElems > 0)
				{
					if (this.m_first < this.m_last)
					{
						Array.Copy(this.m_events, this.m_first, array, 0, this.m_numElems);
					}
					else
					{
						Array.Copy(this.m_events, this.m_first, array, 0, this.m_maxSize - this.m_first);
						Array.Copy(this.m_events, 0, array, this.m_maxSize - this.m_first, this.m_last);
					}
				}
				this.Clear();
				result = array;
			}
			return result;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002D30 File Offset: 0x00001D30
		public void Clear()
		{
			lock (this)
			{
				Array.Clear(this.m_events, 0, this.m_events.Length);
				this.m_first = 0;
				this.m_last = 0;
				this.m_numElems = 0;
			}
		}

		// Token: 0x17000013 RID: 19
		public LoggingEvent this[int i]
		{
			get
			{
				LoggingEvent result;
				lock (this)
				{
					if (i < 0 || i >= this.m_numElems)
					{
						result = null;
					}
					else
					{
						result = this.m_events[(this.m_first + i) % this.m_maxSize];
					}
				}
				return result;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00002DF0 File Offset: 0x00001DF0
		public int MaxSize
		{
			get
			{
				int maxSize;
				lock (this)
				{
					maxSize = this.m_maxSize;
				}
				return maxSize;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002E30 File Offset: 0x00001E30
		public int Length
		{
			get
			{
				int numElems;
				lock (this)
				{
					numElems = this.m_numElems;
				}
				return numElems;
			}
		}

		// Token: 0x04000010 RID: 16
		private LoggingEvent[] m_events;

		// Token: 0x04000011 RID: 17
		private int m_first;

		// Token: 0x04000012 RID: 18
		private int m_last;

		// Token: 0x04000013 RID: 19
		private int m_numElems;

		// Token: 0x04000014 RID: 20
		private int m_maxSize;
	}
}
