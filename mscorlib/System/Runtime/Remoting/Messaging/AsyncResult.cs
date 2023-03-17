using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Encapsulates the results of an asynchronous operation on a delegate.</summary>
	// Token: 0x02000828 RID: 2088
	[ComVisible(true)]
	public class AsyncResult : IAsyncResult, IMessageSink
	{
		// Token: 0x0600594A RID: 22858 RVA: 0x00139272 File Offset: 0x00137472
		[SecurityCritical]
		internal AsyncResult(Message m)
		{
			m.GetAsyncBeginInfo(out this._acbd, out this._asyncState);
			this._asyncDelegate = (Delegate)m.GetThisPtr();
		}

		/// <summary>Gets a value indicating whether the server has completed the call.</summary>
		/// <returns>
		///   <see langword="true" /> after the server has completed the call; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000F04 RID: 3844
		// (get) Token: 0x0600594B RID: 22859 RVA: 0x0013929D File Offset: 0x0013749D
		public virtual bool IsCompleted
		{
			get
			{
				return this._isCompleted;
			}
		}

		/// <summary>Gets the delegate object on which the asynchronous call was invoked.</summary>
		/// <returns>The delegate object on which the asynchronous call was invoked.</returns>
		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x0600594C RID: 22860 RVA: 0x001392A5 File Offset: 0x001374A5
		public virtual object AsyncDelegate
		{
			get
			{
				return this._asyncDelegate;
			}
		}

		/// <summary>Gets the object provided as the last parameter of a <see langword="BeginInvoke" /> method call.</summary>
		/// <returns>The object provided as the last parameter of a <see langword="BeginInvoke" /> method call.</returns>
		// Token: 0x17000F06 RID: 3846
		// (get) Token: 0x0600594D RID: 22861 RVA: 0x001392AD File Offset: 0x001374AD
		public virtual object AsyncState
		{
			get
			{
				return this._asyncState;
			}
		}

		/// <summary>Gets a value indicating whether the <see langword="BeginInvoke" /> call completed synchronously.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see langword="BeginInvoke" /> call completed synchronously; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x0600594E RID: 22862 RVA: 0x001392B5 File Offset: 0x001374B5
		public virtual bool CompletedSynchronously
		{
			get
			{
				return false;
			}
		}

		/// <summary>Gets or sets a value indicating whether <see langword="EndInvoke" /> has been called on the current <see cref="T:System.Runtime.Remoting.Messaging.AsyncResult" />.</summary>
		/// <returns>
		///   <see langword="true" /> if <see langword="EndInvoke" /> has been called on the current <see cref="T:System.Runtime.Remoting.Messaging.AsyncResult" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x0600594F RID: 22863 RVA: 0x001392B8 File Offset: 0x001374B8
		// (set) Token: 0x06005950 RID: 22864 RVA: 0x001392C0 File Offset: 0x001374C0
		public bool EndInvokeCalled
		{
			get
			{
				return this._endInvokeCalled;
			}
			set
			{
				this._endInvokeCalled = value;
			}
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x001392CC File Offset: 0x001374CC
		private void FaultInWaitHandle()
		{
			lock (this)
			{
				if (this._AsyncWaitHandle == null)
				{
					this._AsyncWaitHandle = new ManualResetEvent(false);
				}
			}
		}

		/// <summary>Gets a <see cref="T:System.Threading.WaitHandle" /> that encapsulates Win32 synchronization handles, and allows the implementation of various synchronization schemes.</summary>
		/// <returns>A <see cref="T:System.Threading.WaitHandle" /> that encapsulates Win32 synchronization handles, and allows the implementation of various synchronization schemes.</returns>
		// Token: 0x17000F09 RID: 3849
		// (get) Token: 0x06005952 RID: 22866 RVA: 0x00139318 File Offset: 0x00137518
		public virtual WaitHandle AsyncWaitHandle
		{
			get
			{
				this.FaultInWaitHandle();
				return this._AsyncWaitHandle;
			}
		}

		/// <summary>Sets an <see cref="T:System.Runtime.Remoting.Messaging.IMessageCtrl" /> for the current remote method call, which provides a way to control asynchronous messages after they have been dispatched.</summary>
		/// <param name="mc">The <see cref="T:System.Runtime.Remoting.Messaging.IMessageCtrl" /> for the current remote method call.</param>
		// Token: 0x06005953 RID: 22867 RVA: 0x00139326 File Offset: 0x00137526
		public virtual void SetMessageCtrl(IMessageCtrl mc)
		{
			this._mc = mc;
		}

		/// <summary>Synchronously processes a response message returned by a method call on a remote object.</summary>
		/// <param name="msg">A response message to a method call on a remote object.</param>
		/// <returns>Returns <see langword="null" />.</returns>
		// Token: 0x06005954 RID: 22868 RVA: 0x00139330 File Offset: 0x00137530
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			if (msg == null)
			{
				this._replyMsg = new ReturnMessage(new RemotingException(Environment.GetResourceString("Remoting_NullMessage")), new ErrorMessage());
			}
			else if (!(msg is IMethodReturnMessage))
			{
				this._replyMsg = new ReturnMessage(new RemotingException(Environment.GetResourceString("Remoting_Message_BadType")), new ErrorMessage());
			}
			else
			{
				this._replyMsg = msg;
			}
			this._isCompleted = true;
			this.FaultInWaitHandle();
			this._AsyncWaitHandle.Set();
			if (this._acbd != null)
			{
				this._acbd(this);
			}
			return null;
		}

		/// <summary>Implements the <see cref="T:System.Runtime.Remoting.Messaging.IMessageSink" /> interface.</summary>
		/// <param name="msg">The request <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> interface.</param>
		/// <param name="replySink">The response <see cref="T:System.Runtime.Remoting.Messaging.IMessageSink" /> interface.</param>
		/// <returns>No value is returned.</returns>
		// Token: 0x06005955 RID: 22869 RVA: 0x001393BF File Offset: 0x001375BF
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		/// <summary>Gets the next message sink in the sink chain.</summary>
		/// <returns>An <see cref="T:System.Runtime.Remoting.Messaging.IMessageSink" /> interface that represents the next message sink in the sink chain.</returns>
		// Token: 0x17000F0A RID: 3850
		// (get) Token: 0x06005956 RID: 22870 RVA: 0x001393D0 File Offset: 0x001375D0
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		/// <summary>Gets the response message for the asynchronous call.</summary>
		/// <returns>A remoting message that should represent a response to a method call on a remote object.</returns>
		// Token: 0x06005957 RID: 22871 RVA: 0x001393D3 File Offset: 0x001375D3
		public virtual IMessage GetReplyMessage()
		{
			return this._replyMsg;
		}

		// Token: 0x0400284A RID: 10314
		private IMessageCtrl _mc;

		// Token: 0x0400284B RID: 10315
		private AsyncCallback _acbd;

		// Token: 0x0400284C RID: 10316
		private IMessage _replyMsg;

		// Token: 0x0400284D RID: 10317
		private bool _isCompleted;

		// Token: 0x0400284E RID: 10318
		private bool _endInvokeCalled;

		// Token: 0x0400284F RID: 10319
		private ManualResetEvent _AsyncWaitHandle;

		// Token: 0x04002850 RID: 10320
		private Delegate _asyncDelegate;

		// Token: 0x04002851 RID: 10321
		private object _asyncState;
	}
}
