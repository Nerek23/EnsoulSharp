using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Provides the basic functionality for propagating a synchronization context in various synchronization models.</summary>
	// Token: 0x020004C1 RID: 1217
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = (SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy))]
	public class SynchronizationContext
	{
		/// <summary>Creates a new instance of the <see cref="T:System.Threading.SynchronizationContext" /> class.</summary>
		// Token: 0x06003A72 RID: 14962 RVA: 0x000DDB4B File Offset: 0x000DBD4B
		[__DynamicallyInvokable]
		public SynchronizationContext()
		{
		}

		/// <summary>Sets notification that wait notification is required and prepares the callback method so it can be called more reliably when a wait occurs.</summary>
		// Token: 0x06003A73 RID: 14963 RVA: 0x000DDB54 File Offset: 0x000DBD54
		[SecuritySafeCritical]
		protected void SetWaitNotificationRequired()
		{
			Type type = base.GetType();
			if (SynchronizationContext.s_cachedPreparedType1 != type && SynchronizationContext.s_cachedPreparedType2 != type && SynchronizationContext.s_cachedPreparedType3 != type && SynchronizationContext.s_cachedPreparedType4 != type && SynchronizationContext.s_cachedPreparedType5 != type)
			{
				RuntimeHelpers.PrepareDelegate(new SynchronizationContext.WaitDelegate(this.Wait));
				if (SynchronizationContext.s_cachedPreparedType1 == null)
				{
					SynchronizationContext.s_cachedPreparedType1 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType2 == null)
				{
					SynchronizationContext.s_cachedPreparedType2 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType3 == null)
				{
					SynchronizationContext.s_cachedPreparedType3 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType4 == null)
				{
					SynchronizationContext.s_cachedPreparedType4 = type;
				}
				else if (SynchronizationContext.s_cachedPreparedType5 == null)
				{
					SynchronizationContext.s_cachedPreparedType5 = type;
				}
			}
			this._props |= SynchronizationContextProperties.RequireWaitNotification;
		}

		/// <summary>Determines if wait notification is required.</summary>
		/// <returns>
		///   <see langword="true" /> if wait notification is required; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003A74 RID: 14964 RVA: 0x000DDC3C File Offset: 0x000DBE3C
		public bool IsWaitNotificationRequired()
		{
			return (this._props & SynchronizationContextProperties.RequireWaitNotification) > SynchronizationContextProperties.None;
		}

		/// <summary>When overridden in a derived class, dispatches a synchronous message to a synchronization context.</summary>
		/// <param name="d">The <see cref="T:System.Threading.SendOrPostCallback" /> delegate to call.</param>
		/// <param name="state">The object passed to the delegate.</param>
		/// <exception cref="T:System.NotSupportedException">The method was called in a Windows Store app. The implementation of <see cref="T:System.Threading.SynchronizationContext" /> for Windows Store apps does not support the <see cref="M:System.Threading.SynchronizationContext.Send(System.Threading.SendOrPostCallback,System.Object)" /> method.</exception>
		// Token: 0x06003A75 RID: 14965 RVA: 0x000DDC49 File Offset: 0x000DBE49
		[__DynamicallyInvokable]
		public virtual void Send(SendOrPostCallback d, object state)
		{
			d(state);
		}

		/// <summary>When overridden in a derived class, dispatches an asynchronous message to a synchronization context.</summary>
		/// <param name="d">The <see cref="T:System.Threading.SendOrPostCallback" /> delegate to call.</param>
		/// <param name="state">The object passed to the delegate.</param>
		// Token: 0x06003A76 RID: 14966 RVA: 0x000DDC52 File Offset: 0x000DBE52
		[__DynamicallyInvokable]
		public virtual void Post(SendOrPostCallback d, object state)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(d.Invoke), state);
		}

		/// <summary>When overridden in a derived class, responds to the notification that an operation has started.</summary>
		// Token: 0x06003A77 RID: 14967 RVA: 0x000DDC67 File Offset: 0x000DBE67
		[__DynamicallyInvokable]
		public virtual void OperationStarted()
		{
		}

		/// <summary>When overridden in a derived class, responds to the notification that an operation has completed.</summary>
		// Token: 0x06003A78 RID: 14968 RVA: 0x000DDC69 File Offset: 0x000DBE69
		[__DynamicallyInvokable]
		public virtual void OperationCompleted()
		{
		}

		/// <summary>Waits for any or all the elements in the specified array to receive a signal.</summary>
		/// <param name="waitHandles">An array of type <see cref="T:System.IntPtr" /> that contains the native operating system handles.</param>
		/// <param name="waitAll">
		///   <see langword="true" /> to wait for all handles; <see langword="false" /> to wait for any handle.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <returns>The array index of the object that satisfied the wait.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="waitHandles" /> is null.</exception>
		// Token: 0x06003A79 RID: 14969 RVA: 0x000DDC6B File Offset: 0x000DBE6B
		[SecurityCritical]
		[CLSCompliant(false)]
		[PrePrepareMethod]
		public virtual int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
		{
			if (waitHandles == null)
			{
				throw new ArgumentNullException("waitHandles");
			}
			return SynchronizationContext.WaitHelper(waitHandles, waitAll, millisecondsTimeout);
		}

		/// <summary>Helper function that waits for any or all the elements in the specified array to receive a signal.</summary>
		/// <param name="waitHandles">An array of type <see cref="T:System.IntPtr" /> that contains the native operating system handles.</param>
		/// <param name="waitAll">
		///   <see langword="true" /> to wait for all handles;  <see langword="false" /> to wait for any handle.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <returns>The array index of the object that satisfied the wait.</returns>
		// Token: 0x06003A7A RID: 14970
		[SecurityCritical]
		[CLSCompliant(false)]
		[PrePrepareMethod]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		protected static extern int WaitHelper(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);

		/// <summary>Sets the current synchronization context.</summary>
		/// <param name="syncContext">The <see cref="T:System.Threading.SynchronizationContext" /> object to be set.</param>
		// Token: 0x06003A7B RID: 14971 RVA: 0x000DDC84 File Offset: 0x000DBE84
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void SetSynchronizationContext(SynchronizationContext syncContext)
		{
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			mutableExecutionContext.SynchronizationContext = syncContext;
			mutableExecutionContext.SynchronizationContextNoFlow = syncContext;
		}

		/// <summary>Gets the synchronization context for the current thread.</summary>
		/// <returns>A <see cref="T:System.Threading.SynchronizationContext" /> object representing the current synchronization context.</returns>
		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x06003A7C RID: 14972 RVA: 0x000DDCAC File Offset: 0x000DBEAC
		[__DynamicallyInvokable]
		public static SynchronizationContext Current
		{
			[__DynamicallyInvokable]
			get
			{
				return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContext ?? SynchronizationContext.GetThreadLocalContext();
			}
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06003A7D RID: 14973 RVA: 0x000DDCD4 File Offset: 0x000DBED4
		internal static SynchronizationContext CurrentNoFlow
		{
			[FriendAccessAllowed]
			get
			{
				return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContextNoFlow ?? SynchronizationContext.GetThreadLocalContext();
			}
		}

		// Token: 0x06003A7E RID: 14974 RVA: 0x000DDCFC File Offset: 0x000DBEFC
		private static SynchronizationContext GetThreadLocalContext()
		{
			SynchronizationContext synchronizationContext = null;
			if (synchronizationContext == null && Environment.IsWinRTSupported)
			{
				synchronizationContext = SynchronizationContext.GetWinRTContext();
			}
			return synchronizationContext;
		}

		// Token: 0x06003A7F RID: 14975 RVA: 0x000DDD1C File Offset: 0x000DBF1C
		[SecuritySafeCritical]
		private static SynchronizationContext GetWinRTContext()
		{
			if (!AppDomain.IsAppXModel())
			{
				return null;
			}
			object winRTDispatcherForCurrentThread = SynchronizationContext.GetWinRTDispatcherForCurrentThread();
			if (winRTDispatcherForCurrentThread != null)
			{
				return SynchronizationContext.GetWinRTSynchronizationContextFactory().Create(winRTDispatcherForCurrentThread);
			}
			return null;
		}

		// Token: 0x06003A80 RID: 14976 RVA: 0x000DDD48 File Offset: 0x000DBF48
		[SecurityCritical]
		private static WinRTSynchronizationContextFactoryBase GetWinRTSynchronizationContextFactory()
		{
			WinRTSynchronizationContextFactoryBase winRTSynchronizationContextFactoryBase = SynchronizationContext.s_winRTContextFactory;
			if (winRTSynchronizationContextFactoryBase == null)
			{
				Type type = Type.GetType("System.Threading.WinRTSynchronizationContextFactory, System.Runtime.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true);
				winRTSynchronizationContextFactoryBase = (SynchronizationContext.s_winRTContextFactory = (WinRTSynchronizationContextFactoryBase)Activator.CreateInstance(type, true));
			}
			return winRTSynchronizationContextFactoryBase;
		}

		// Token: 0x06003A81 RID: 14977
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Interface)]
		private static extern object GetWinRTDispatcherForCurrentThread();

		/// <summary>When overridden in a derived class, creates a copy of the synchronization context.</summary>
		/// <returns>A new <see cref="T:System.Threading.SynchronizationContext" /> object.</returns>
		// Token: 0x06003A82 RID: 14978 RVA: 0x000DDD7E File Offset: 0x000DBF7E
		[__DynamicallyInvokable]
		public virtual SynchronizationContext CreateCopy()
		{
			return new SynchronizationContext();
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x000DDD85 File Offset: 0x000DBF85
		[SecurityCritical]
		private static int InvokeWaitMethodHelper(SynchronizationContext syncContext, IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
		{
			return syncContext.Wait(waitHandles, waitAll, millisecondsTimeout);
		}

		// Token: 0x040018B3 RID: 6323
		private SynchronizationContextProperties _props;

		// Token: 0x040018B4 RID: 6324
		private static Type s_cachedPreparedType1;

		// Token: 0x040018B5 RID: 6325
		private static Type s_cachedPreparedType2;

		// Token: 0x040018B6 RID: 6326
		private static Type s_cachedPreparedType3;

		// Token: 0x040018B7 RID: 6327
		private static Type s_cachedPreparedType4;

		// Token: 0x040018B8 RID: 6328
		private static Type s_cachedPreparedType5;

		// Token: 0x040018B9 RID: 6329
		[SecurityCritical]
		private static WinRTSynchronizationContextFactoryBase s_winRTContextFactory;

		// Token: 0x02000BB5 RID: 2997
		// (Invoke) Token: 0x06006E24 RID: 28196
		private delegate int WaitDelegate(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);
	}
}
