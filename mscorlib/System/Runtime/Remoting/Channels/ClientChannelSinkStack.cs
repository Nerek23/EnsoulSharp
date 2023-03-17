using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Holds the stack of client channel sinks that must be invoked during an asynchronous message response decoding.</summary>
	// Token: 0x02000802 RID: 2050
	[SecurityCritical]
	[ComVisible(true)]
	public class ClientChannelSinkStack : IClientChannelSinkStack, IClientResponseChannelSinkStack
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Channels.ClientChannelSinkStack" /> class with default values.</summary>
		// Token: 0x06005887 RID: 22663 RVA: 0x00137585 File Offset: 0x00135785
		public ClientChannelSinkStack()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Channels.ClientChannelSinkStack" /> class with the specified reply sink.</summary>
		/// <param name="replySink">The <see cref="T:System.Runtime.Remoting.Messaging.IMessageSink" /> that the current stack can use to reply to messages.</param>
		// Token: 0x06005888 RID: 22664 RVA: 0x0013758D File Offset: 0x0013578D
		public ClientChannelSinkStack(IMessageSink replySink)
		{
			this._replySink = replySink;
		}

		/// <summary>Pushes the specified sink and information that is associated with it onto the sink stack.</summary>
		/// <param name="sink">The sink to push onto the sink stack.</param>
		/// <param name="state">Information generated on the request side that is needed on the response side.</param>
		// Token: 0x06005889 RID: 22665 RVA: 0x0013759C File Offset: 0x0013579C
		[SecurityCritical]
		public void Push(IClientChannelSink sink, object state)
		{
			this._stack = new ClientChannelSinkStack.SinkStack
			{
				PrevStack = this._stack,
				Sink = sink,
				State = state
			};
		}

		/// <summary>Pops the information that is associated with all the sinks from the sink stack up to and including the specified sink.</summary>
		/// <param name="sink">The sink to remove and return from the sink stack.</param>
		/// <returns>Information generated on the request side and associated with the specified sink.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty, or the specified sink was never pushed onto the current stack.</exception>
		// Token: 0x0600588A RID: 22666 RVA: 0x001375D0 File Offset: 0x001357D0
		[SecurityCritical]
		public object Pop(IClientChannelSink sink)
		{
			if (this._stack == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_PopOnEmptySinkStack"));
			}
			while (this._stack.Sink != sink)
			{
				this._stack = this._stack.PrevStack;
				if (this._stack == null)
				{
					break;
				}
			}
			if (this._stack.Sink == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_PopFromSinkStackWithoutPush"));
			}
			object state = this._stack.State;
			this._stack = this._stack.PrevStack;
			return state;
		}

		/// <summary>Requests asynchronous processing of a method call on the sinks that are in the current sink stack.</summary>
		/// <param name="headers">The headers that are retrieved from the server response stream.</param>
		/// <param name="stream">The stream that is returning from the transport sink.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty.</exception>
		// Token: 0x0600588B RID: 22667 RVA: 0x00137658 File Offset: 0x00135858
		[SecurityCritical]
		public void AsyncProcessResponse(ITransportHeaders headers, Stream stream)
		{
			if (this._replySink != null)
			{
				if (this._stack == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CantCallAPRWhenStackEmpty"));
				}
				IClientChannelSink sink = this._stack.Sink;
				object state = this._stack.State;
				this._stack = this._stack.PrevStack;
				sink.AsyncProcessResponse(this, state, headers, stream);
			}
		}

		/// <summary>Dispatches the specified reply message on the reply sink.</summary>
		/// <param name="msg">The <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> to dispatch.</param>
		// Token: 0x0600588C RID: 22668 RVA: 0x001376B8 File Offset: 0x001358B8
		[SecurityCritical]
		public void DispatchReplyMessage(IMessage msg)
		{
			if (this._replySink != null)
			{
				this._replySink.SyncProcessMessage(msg);
			}
		}

		/// <summary>Dispatches the specified exception on the reply sink.</summary>
		/// <param name="e">The exception to dispatch to the server.</param>
		// Token: 0x0600588D RID: 22669 RVA: 0x001376CF File Offset: 0x001358CF
		[SecurityCritical]
		public void DispatchException(Exception e)
		{
			this.DispatchReplyMessage(new ReturnMessage(e, null));
		}

		// Token: 0x04002818 RID: 10264
		private ClientChannelSinkStack.SinkStack _stack;

		// Token: 0x04002819 RID: 10265
		private IMessageSink _replySink;

		// Token: 0x02000C42 RID: 3138
		private class SinkStack
		{
			// Token: 0x0400371C RID: 14108
			public ClientChannelSinkStack.SinkStack PrevStack;

			// Token: 0x0400371D RID: 14109
			public IClientChannelSink Sink;

			// Token: 0x0400371E RID: 14110
			public object State;
		}
	}
}
