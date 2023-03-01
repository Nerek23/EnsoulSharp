using System;
using System.Collections;
using System.Security;
using System.Threading;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000E7 RID: 231
	public class RemotingAppender : BufferingAppenderSkeleton
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00016400 File Offset: 0x00015400
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x00016408 File Offset: 0x00015408
		public string Sink
		{
			get
			{
				return this.m_sinkUrl;
			}
			set
			{
				this.m_sinkUrl = value;
			}
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00016414 File Offset: 0x00015414
		[SecuritySafeCritical]
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			IDictionary dictionary = new Hashtable();
			dictionary["typeFilterLevel"] = "Full";
			this.m_sinkObj = (RemotingAppender.IRemoteLoggingSink)Activator.GetObject(typeof(RemotingAppender.IRemoteLoggingSink), this.m_sinkUrl, dictionary);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00016460 File Offset: 0x00015460
		protected override void SendBuffer(LoggingEvent[] events)
		{
			this.BeginAsyncSend();
			if (!ThreadPool.QueueUserWorkItem(new WaitCallback(this.SendBufferCallback), events))
			{
				this.EndAsyncSend();
				this.ErrorHandler.Error("RemotingAppender [" + base.Name + "] failed to ThreadPool.QueueUserWorkItem logging events in SendBuffer.");
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000164AD File Offset: 0x000154AD
		protected override void OnClose()
		{
			base.OnClose();
			if (!this.m_workQueueEmptyEvent.WaitOne(30000, false))
			{
				this.ErrorHandler.Error("RemotingAppender [" + base.Name + "] failed to send all queued events before close, in OnClose.");
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000164E8 File Offset: 0x000154E8
		public override bool Flush(int millisecondsTimeout)
		{
			base.Flush();
			return this.m_workQueueEmptyEvent.WaitOne(millisecondsTimeout, false);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000164FD File Offset: 0x000154FD
		private void BeginAsyncSend()
		{
			this.m_workQueueEmptyEvent.Reset();
			Interlocked.Increment(ref this.m_queuedCallbackCount);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00016517 File Offset: 0x00015517
		private void EndAsyncSend()
		{
			if (Interlocked.Decrement(ref this.m_queuedCallbackCount) <= 0)
			{
				this.m_workQueueEmptyEvent.Set();
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00016534 File Offset: 0x00015534
		private void SendBufferCallback(object state)
		{
			try
			{
				LoggingEvent[] events = (LoggingEvent[])state;
				this.m_sinkObj.LogEvents(events);
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error("Failed in SendBufferCallback", e);
			}
			finally
			{
				this.EndAsyncSend();
			}
		}

		// Token: 0x04000215 RID: 533
		private string m_sinkUrl;

		// Token: 0x04000216 RID: 534
		private RemotingAppender.IRemoteLoggingSink m_sinkObj;

		// Token: 0x04000217 RID: 535
		private int m_queuedCallbackCount;

		// Token: 0x04000218 RID: 536
		private ManualResetEvent m_workQueueEmptyEvent = new ManualResetEvent(true);

		// Token: 0x0200011E RID: 286
		public interface IRemoteLoggingSink
		{
			// Token: 0x0600089E RID: 2206
			void LogEvents(LoggingEvent[] events);
		}
	}
}
