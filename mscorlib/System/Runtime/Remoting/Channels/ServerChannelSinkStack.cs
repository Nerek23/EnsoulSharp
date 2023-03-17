using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Holds the stack of server channel sinks.</summary>
	// Token: 0x02000805 RID: 2053
	[SecurityCritical]
	[ComVisible(true)]
	public class ServerChannelSinkStack : IServerChannelSinkStack, IServerResponseChannelSinkStack
	{
		/// <summary>Pushes the specified sink and information associated with it onto the sink stack.</summary>
		/// <param name="sink">The sink to push onto the sink stack.</param>
		/// <param name="state">Information generated on the request side that is needed on the response side.</param>
		// Token: 0x06005895 RID: 22677 RVA: 0x001376E0 File Offset: 0x001358E0
		[SecurityCritical]
		public void Push(IServerChannelSink sink, object state)
		{
			this._stack = new ServerChannelSinkStack.SinkStack
			{
				PrevStack = this._stack,
				Sink = sink,
				State = state
			};
		}

		/// <summary>Pops the information associated with all the sinks from the sink stack up to and including the specified sink.</summary>
		/// <param name="sink">The sink to remove and return from the sink stack.</param>
		/// <returns>Information generated on the request side and associated with the specified sink.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty, or the specified sink was never pushed onto the current stack.</exception>
		// Token: 0x06005896 RID: 22678 RVA: 0x00137714 File Offset: 0x00135914
		[SecurityCritical]
		public object Pop(IServerChannelSink sink)
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

		/// <summary>Stores a message sink and its associated state for later asynchronous processing.</summary>
		/// <param name="sink">A server channel sink.</param>
		/// <param name="state">The state associated with <paramref name="sink" />.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty.  
		///  -or-  
		///  The specified sink was never pushed onto the current stack.</exception>
		// Token: 0x06005897 RID: 22679 RVA: 0x0013779C File Offset: 0x0013599C
		[SecurityCritical]
		public void Store(IServerChannelSink sink, object state)
		{
			if (this._stack == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_StoreOnEmptySinkStack"));
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
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_StoreOnSinkStackWithoutPush"));
			}
			this._rememberedStack = new ServerChannelSinkStack.SinkStack
			{
				PrevStack = this._rememberedStack,
				Sink = sink,
				State = state
			};
			this.Pop(sink);
		}

		/// <summary>Stores a message sink and its associated state, and then dispatches a message asynchronously, using the sink just stored and any other stored sinks.</summary>
		/// <param name="sink">A server channel sink.</param>
		/// <param name="state">The state associated with <paramref name="sink" />.</param>
		// Token: 0x06005898 RID: 22680 RVA: 0x00137834 File Offset: 0x00135A34
		[SecurityCritical]
		public void StoreAndDispatch(IServerChannelSink sink, object state)
		{
			this.Store(sink, state);
			this.FlipRememberedStack();
			CrossContextChannel.DoAsyncDispatch(this._asyncMsg, null);
		}

		// Token: 0x06005899 RID: 22681 RVA: 0x00137854 File Offset: 0x00135A54
		private void FlipRememberedStack()
		{
			if (this._stack != null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CantCallFRSWhenStackEmtpy"));
			}
			while (this._rememberedStack != null)
			{
				this._stack = new ServerChannelSinkStack.SinkStack
				{
					PrevStack = this._stack,
					Sink = this._rememberedStack.Sink,
					State = this._rememberedStack.State
				};
				this._rememberedStack = this._rememberedStack.PrevStack;
			}
		}

		/// <summary>Requests asynchronous processing of a method call on the sinks in the current sink stack.</summary>
		/// <param name="msg">The message to be serialized onto the requested stream.</param>
		/// <param name="headers">The headers retrieved from the server response stream.</param>
		/// <param name="stream">The stream coming back from the transport sink.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty.</exception>
		// Token: 0x0600589A RID: 22682 RVA: 0x001378D0 File Offset: 0x00135AD0
		[SecurityCritical]
		public void AsyncProcessResponse(IMessage msg, ITransportHeaders headers, Stream stream)
		{
			if (this._stack == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CantCallAPRWhenStackEmpty"));
			}
			IServerChannelSink sink = this._stack.Sink;
			object state = this._stack.State;
			this._stack = this._stack.PrevStack;
			sink.AsyncProcessResponse(this, state, msg, headers, stream);
		}

		/// <summary>Returns the <see cref="T:System.IO.Stream" /> onto which the specified message is to be serialized.</summary>
		/// <param name="msg">The message to be serialized onto the requested stream.</param>
		/// <param name="headers">The headers retrieved from the server response stream.</param>
		/// <returns>The <see cref="T:System.IO.Stream" /> onto which the specified message is to be serialized.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The sink stack is empty.</exception>
		// Token: 0x0600589B RID: 22683 RVA: 0x0013792C File Offset: 0x00135B2C
		[SecurityCritical]
		public Stream GetResponseStream(IMessage msg, ITransportHeaders headers)
		{
			if (this._stack == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CantCallGetResponseStreamWhenStackEmpty"));
			}
			IServerChannelSink sink = this._stack.Sink;
			object state = this._stack.State;
			this._stack = this._stack.PrevStack;
			Stream responseStream = sink.GetResponseStream(this, state, msg, headers);
			this.Push(sink, state);
			return responseStream;
		}

		// Token: 0x17000EC7 RID: 3783
		// (set) Token: 0x0600589C RID: 22684 RVA: 0x0013798E File Offset: 0x00135B8E
		internal object ServerObject
		{
			set
			{
				this._serverObject = value;
			}
		}

		/// <summary>Provides a <see cref="T:System.AsyncCallback" /> delegate to handle a callback after a message has been dispatched asynchronously.</summary>
		/// <param name="ar">The status and state of an asynchronous operation on a remote object.</param>
		// Token: 0x0600589D RID: 22685 RVA: 0x00137998 File Offset: 0x00135B98
		[SecurityCritical]
		public void ServerCallback(IAsyncResult ar)
		{
			if (this._asyncEnd != null)
			{
				RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(this._asyncEnd);
				MethodInfo mi = (MethodInfo)this._msg.MethodBase;
				RemotingMethodCachedData reflectionCachedData2 = InternalRemotingServices.GetReflectionCachedData(mi);
				ParameterInfo[] parameters = reflectionCachedData.Parameters;
				object[] array = new object[parameters.Length];
				array[parameters.Length - 1] = ar;
				object[] args = this._msg.Args;
				AsyncMessageHelper.GetOutArgs(reflectionCachedData2.Parameters, args, array);
				StackBuilderSink stackBuilderSink = new StackBuilderSink(this._serverObject);
				object[] array2;
				object ret = stackBuilderSink.PrivateProcessMessage(this._asyncEnd.MethodHandle, Message.CoerceArgs(this._asyncEnd, array, parameters), this._serverObject, out array2);
				if (array2 != null)
				{
					array2 = ArgMapper.ExpandAsyncEndArgsToSyncArgs(reflectionCachedData2, array2);
				}
				stackBuilderSink.CopyNonByrefOutArgsFromOriginalArgs(reflectionCachedData2, args, ref array2);
				IMessage msg = new ReturnMessage(ret, array2, this._msg.ArgCount, Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext, this._msg);
				this.AsyncProcessResponse(msg, null, null);
			}
		}

		// Token: 0x0400281A RID: 10266
		private ServerChannelSinkStack.SinkStack _stack;

		// Token: 0x0400281B RID: 10267
		private ServerChannelSinkStack.SinkStack _rememberedStack;

		// Token: 0x0400281C RID: 10268
		private IMessage _asyncMsg;

		// Token: 0x0400281D RID: 10269
		private MethodInfo _asyncEnd;

		// Token: 0x0400281E RID: 10270
		private object _serverObject;

		// Token: 0x0400281F RID: 10271
		private IMethodCallMessage _msg;

		// Token: 0x02000C43 RID: 3139
		private class SinkStack
		{
			// Token: 0x0400371F RID: 14111
			public ServerChannelSinkStack.SinkStack PrevStack;

			// Token: 0x04003720 RID: 14112
			public IServerChannelSink Sink;

			// Token: 0x04003721 RID: 14113
			public object State;
		}
	}
}
