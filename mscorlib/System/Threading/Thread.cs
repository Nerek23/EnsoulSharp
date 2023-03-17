using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;

namespace System.Threading
{
	/// <summary>Creates and controls a thread, sets its priority, and gets its status.</summary>
	// Token: 0x020004E9 RID: 1257
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Thread))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class Thread : CriticalFinalizerObject, _Thread
	{
		// Token: 0x06003C03 RID: 15363 RVA: 0x000E1819 File Offset: 0x000DFA19
		private static void AsyncLocalSetCurrentCulture(AsyncLocalValueChangedArgs<CultureInfo> args)
		{
			Thread.CurrentThread.m_CurrentCulture = args.CurrentValue;
		}

		// Token: 0x06003C04 RID: 15364 RVA: 0x000E182C File Offset: 0x000DFA2C
		private static void AsyncLocalSetCurrentUICulture(AsyncLocalValueChangedArgs<CultureInfo> args)
		{
			Thread.CurrentThread.m_CurrentUICulture = args.CurrentValue;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Thread" /> class.</summary>
		/// <param name="start">A <see cref="T:System.Threading.ThreadStart" /> delegate that represents the methods to be invoked when this thread begins executing.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="start" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003C05 RID: 15365 RVA: 0x000E183F File Offset: 0x000DFA3F
		[SecuritySafeCritical]
		public Thread(ThreadStart start)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			this.SetStartHelper(start, 0);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Thread" /> class, specifying the maximum stack size for the thread.</summary>
		/// <param name="start">A <see cref="T:System.Threading.ThreadStart" /> delegate that represents the methods to be invoked when this thread begins executing.</param>
		/// <param name="maxStackSize">The maximum stack size, in bytes, to be used by the thread, or 0 to use the default maximum stack size specified in the header for the executable.  
		///  Important   For partially trusted code, <paramref name="maxStackSize" /> is ignored if it is greater than the default stack size. No exception is thrown.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="start" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="maxStackSize" /> is less than zero.</exception>
		// Token: 0x06003C06 RID: 15366 RVA: 0x000E185D File Offset: 0x000DFA5D
		[SecuritySafeCritical]
		public Thread(ThreadStart start, int maxStackSize)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			if (0 > maxStackSize)
			{
				throw new ArgumentOutOfRangeException("maxStackSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.SetStartHelper(start, maxStackSize);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Thread" /> class, specifying a delegate that allows an object to be passed to the thread when the thread is started.</summary>
		/// <param name="start">A delegate that represents the methods to be invoked when this thread begins executing.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="start" /> is <see langword="null" />.</exception>
		// Token: 0x06003C07 RID: 15367 RVA: 0x000E1894 File Offset: 0x000DFA94
		[SecuritySafeCritical]
		public Thread(ParameterizedThreadStart start)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			this.SetStartHelper(start, 0);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Thread" /> class, specifying a delegate that allows an object to be passed to the thread when the thread is started and specifying the maximum stack size for the thread.</summary>
		/// <param name="start">A <see cref="T:System.Threading.ParameterizedThreadStart" /> delegate that represents the methods to be invoked when this thread begins executing.</param>
		/// <param name="maxStackSize">The maximum stack size, in bytes, to be used by the thread, or 0 to use the default maximum stack size specified in the header for the executable.  
		///  Important   For partially trusted code, <paramref name="maxStackSize" /> is ignored if it is greater than the default stack size. No exception is thrown.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="start" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="maxStackSize" /> is less than zero.</exception>
		// Token: 0x06003C08 RID: 15368 RVA: 0x000E18B2 File Offset: 0x000DFAB2
		[SecuritySafeCritical]
		public Thread(ParameterizedThreadStart start, int maxStackSize)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			if (0 > maxStackSize)
			{
				throw new ArgumentOutOfRangeException("maxStackSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.SetStartHelper(start, maxStackSize);
		}

		/// <summary>Returns a hash code for the current thread.</summary>
		/// <returns>An integer hash code value.</returns>
		// Token: 0x06003C09 RID: 15369 RVA: 0x000E18E9 File Offset: 0x000DFAE9
		[ComVisible(false)]
		public override int GetHashCode()
		{
			return this.m_ManagedThreadId;
		}

		/// <summary>Gets a unique identifier for the current managed thread.</summary>
		/// <returns>An integer that represents a unique identifier for this managed thread.</returns>
		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x06003C0A RID: 15370
		[__DynamicallyInvokable]
		public extern int ManagedThreadId { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [SecuritySafeCritical] [__DynamicallyInvokable] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06003C0B RID: 15371 RVA: 0x000E18F4 File Offset: 0x000DFAF4
		internal ThreadHandle GetNativeHandle()
		{
			IntPtr dont_USE_InternalThread = this.DONT_USE_InternalThread;
			if (dont_USE_InternalThread.IsNull())
			{
				throw new ArgumentException(null, Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return new ThreadHandle(dont_USE_InternalThread);
		}

		/// <summary>Causes the operating system to change the state of the current instance to <see cref="F:System.Threading.ThreadState.Running" />.</summary>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has already been started.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is not enough memory available to start this thread.</exception>
		// Token: 0x06003C0C RID: 15372 RVA: 0x000E1928 File Offset: 0x000DFB28
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Start()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Start(ref stackCrawlMark);
		}

		/// <summary>Causes the operating system to change the state of the current instance to <see cref="F:System.Threading.ThreadState.Running" />, and optionally supplies an object containing data to be used by the method the thread executes.</summary>
		/// <param name="parameter">An object that contains data to be used by the method the thread executes.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has already been started.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is not enough memory available to start this thread.</exception>
		/// <exception cref="T:System.InvalidOperationException">This thread was created using a <see cref="T:System.Threading.ThreadStart" /> delegate instead of a <see cref="T:System.Threading.ParameterizedThreadStart" /> delegate.</exception>
		// Token: 0x06003C0D RID: 15373 RVA: 0x000E1940 File Offset: 0x000DFB40
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Start(object parameter)
		{
			if (this.m_Delegate is ThreadStart)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadWrongThreadStart"));
			}
			this.m_ThreadStartArg = parameter;
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Start(ref stackCrawlMark);
		}

		// Token: 0x06003C0E RID: 15374 RVA: 0x000E197C File Offset: 0x000DFB7C
		[SecuritySafeCritical]
		private void Start(ref StackCrawlMark stackMark)
		{
			this.StartupSetApartmentStateInternal();
			if (this.m_Delegate != null)
			{
				ThreadHelper threadHelper = (ThreadHelper)this.m_Delegate.Target;
				ExecutionContext executionContextHelper = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx);
				threadHelper.SetExecutionContextHelper(executionContextHelper);
			}
			IPrincipal principal = CallContext.Principal;
			this.StartInternal(principal, ref stackMark);
		}

		// Token: 0x06003C0F RID: 15375 RVA: 0x000E19C5 File Offset: 0x000DFBC5
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal ExecutionContext.Reader GetExecutionContextReader()
		{
			return new ExecutionContext.Reader(this.m_ExecutionContext);
		}

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x06003C10 RID: 15376 RVA: 0x000E19D2 File Offset: 0x000DFBD2
		// (set) Token: 0x06003C11 RID: 15377 RVA: 0x000E19DD File Offset: 0x000DFBDD
		internal bool ExecutionContextBelongsToCurrentScope
		{
			get
			{
				return !this.m_ExecutionContextBelongsToOuterScope;
			}
			set
			{
				this.m_ExecutionContextBelongsToOuterScope = !value;
			}
		}

		/// <summary>Gets an <see cref="T:System.Threading.ExecutionContext" /> object that contains information about the various contexts of the current thread.</summary>
		/// <returns>An <see cref="T:System.Threading.ExecutionContext" /> object that consolidates context information for the current thread.</returns>
		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x06003C12 RID: 15378 RVA: 0x000E19EC File Offset: 0x000DFBEC
		public ExecutionContext ExecutionContext
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			get
			{
				ExecutionContext result;
				if (this == Thread.CurrentThread)
				{
					result = this.GetMutableExecutionContext();
				}
				else
				{
					result = this.m_ExecutionContext;
				}
				return result;
			}
		}

		// Token: 0x06003C13 RID: 15379 RVA: 0x000E1A14 File Offset: 0x000DFC14
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal ExecutionContext GetMutableExecutionContext()
		{
			if (this.m_ExecutionContext == null)
			{
				this.m_ExecutionContext = new ExecutionContext();
			}
			else if (!this.ExecutionContextBelongsToCurrentScope)
			{
				ExecutionContext executionContext = this.m_ExecutionContext.CreateMutableCopy();
				this.m_ExecutionContext = executionContext;
			}
			this.ExecutionContextBelongsToCurrentScope = true;
			return this.m_ExecutionContext;
		}

		// Token: 0x06003C14 RID: 15380 RVA: 0x000E1A5E File Offset: 0x000DFC5E
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext value, bool belongsToCurrentScope)
		{
			this.m_ExecutionContext = value;
			this.ExecutionContextBelongsToCurrentScope = belongsToCurrentScope;
		}

		// Token: 0x06003C15 RID: 15381 RVA: 0x000E1A6E File Offset: 0x000DFC6E
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext.Reader value, bool belongsToCurrentScope)
		{
			this.m_ExecutionContext = value.DangerousGetRawExecutionContext();
			this.ExecutionContextBelongsToCurrentScope = belongsToCurrentScope;
		}

		// Token: 0x06003C16 RID: 15382
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartInternal(IPrincipal principal, ref StackCrawlMark stackMark);

		/// <summary>Applies a captured <see cref="T:System.Threading.CompressedStack" /> to the current thread.</summary>
		/// <param name="stack">The <see cref="T:System.Threading.CompressedStack" /> object to be applied to the current thread.</param>
		/// <exception cref="T:System.InvalidOperationException">In all cases.</exception>
		// Token: 0x06003C17 RID: 15383 RVA: 0x000E1A84 File Offset: 0x000DFC84
		[SecurityCritical]
		[Obsolete("Thread.SetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
		public void SetCompressedStack(CompressedStack stack)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadAPIsNotSupported"));
		}

		// Token: 0x06003C18 RID: 15384
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr SetAppDomainStack(SafeCompressedStackHandle csHandle);

		// Token: 0x06003C19 RID: 15385
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void RestoreAppDomainStack(IntPtr appDomainStack);

		/// <summary>Returns a <see cref="T:System.Threading.CompressedStack" /> object that can be used to capture the stack for the current thread.</summary>
		/// <returns>None.</returns>
		/// <exception cref="T:System.InvalidOperationException">In all cases.</exception>
		// Token: 0x06003C1A RID: 15386 RVA: 0x000E1A95 File Offset: 0x000DFC95
		[SecurityCritical]
		[Obsolete("Thread.GetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
		public CompressedStack GetCompressedStack()
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ThreadAPIsNotSupported"));
		}

		// Token: 0x06003C1B RID: 15387
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr InternalGetCurrentThread();

		/// <summary>Raises a <see cref="T:System.Threading.ThreadAbortException" /> in the thread on which it is invoked, to begin the process of terminating the thread while also providing exception information about the thread termination. Calling this method usually terminates the thread.</summary>
		/// <param name="stateInfo">An object that contains application-specific information, such as state, which can be used by the thread being aborted.</param>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread that is being aborted is currently suspended.</exception>
		// Token: 0x06003C1C RID: 15388 RVA: 0x000E1AA6 File Offset: 0x000DFCA6
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Abort(object stateInfo)
		{
			this.AbortReason = stateInfo;
			this.AbortInternal();
		}

		/// <summary>Raises a <see cref="T:System.Threading.ThreadAbortException" /> in the thread on which it is invoked, to begin the process of terminating the thread. Calling this method usually terminates the thread.</summary>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread that is being aborted is currently suspended.</exception>
		// Token: 0x06003C1D RID: 15389 RVA: 0x000E1AB5 File Offset: 0x000DFCB5
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Abort()
		{
			this.AbortInternal();
		}

		// Token: 0x06003C1E RID: 15390
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AbortInternal();

		/// <summary>Cancels an <see cref="M:System.Threading.Thread.Abort(System.Object)" /> requested for the current thread.</summary>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">
		///   <see langword="Abort" /> was not invoked on the current thread.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required security permission for the current thread.</exception>
		// Token: 0x06003C1F RID: 15391 RVA: 0x000E1AC0 File Offset: 0x000DFCC0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public static void ResetAbort()
		{
			Thread currentThread = Thread.CurrentThread;
			if ((currentThread.ThreadState & ThreadState.AbortRequested) == ThreadState.Running)
			{
				throw new ThreadStateException(Environment.GetResourceString("ThreadState_NoAbortRequested"));
			}
			currentThread.ResetAbortNative();
			currentThread.ClearAbortReason();
		}

		// Token: 0x06003C20 RID: 15392
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ResetAbortNative();

		/// <summary>Either suspends the thread, or if the thread is already suspended, has no effect.</summary>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has not been started or is dead.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the appropriate <see cref="T:System.Security.Permissions.SecurityPermission" />.</exception>
		// Token: 0x06003C21 RID: 15393 RVA: 0x000E1AFD File Offset: 0x000DFCFD
		[SecuritySafeCritical]
		[Obsolete("Thread.Suspend has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Suspend()
		{
			this.SuspendInternal();
		}

		// Token: 0x06003C22 RID: 15394
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SuspendInternal();

		/// <summary>Resumes a thread that has been suspended.</summary>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has not been started, is dead, or is not in the suspended state.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the appropriate <see cref="T:System.Security.Permissions.SecurityPermission" />.</exception>
		// Token: 0x06003C23 RID: 15395 RVA: 0x000E1B05 File Offset: 0x000DFD05
		[SecuritySafeCritical]
		[Obsolete("Thread.Resume has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Resume()
		{
			this.ResumeInternal();
		}

		// Token: 0x06003C24 RID: 15396
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ResumeInternal();

		/// <summary>Interrupts a thread that is in the <see langword="WaitSleepJoin" /> thread state.</summary>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the appropriate <see cref="T:System.Security.Permissions.SecurityPermission" />.</exception>
		// Token: 0x06003C25 RID: 15397 RVA: 0x000E1B0D File Offset: 0x000DFD0D
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public void Interrupt()
		{
			this.InterruptInternal();
		}

		// Token: 0x06003C26 RID: 15398
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InterruptInternal();

		/// <summary>Gets or sets a value indicating the scheduling priority of a thread.</summary>
		/// <returns>One of the <see cref="T:System.Threading.ThreadPriority" /> values. The default value is <see cref="F:System.Threading.ThreadPriority.Normal" />.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has reached a final state, such as <see cref="F:System.Threading.ThreadState.Aborted" />.</exception>
		/// <exception cref="T:System.ArgumentException">The value specified for a set operation is not a valid <see cref="T:System.Threading.ThreadPriority" /> value.</exception>
		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x06003C27 RID: 15399 RVA: 0x000E1B15 File Offset: 0x000DFD15
		// (set) Token: 0x06003C28 RID: 15400 RVA: 0x000E1B1D File Offset: 0x000DFD1D
		public ThreadPriority Priority
		{
			[SecuritySafeCritical]
			get
			{
				return (ThreadPriority)this.GetPriorityNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading = true)]
			set
			{
				this.SetPriorityNative((int)value);
			}
		}

		// Token: 0x06003C29 RID: 15401
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetPriorityNative();

		// Token: 0x06003C2A RID: 15402
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetPriorityNative(int priority);

		/// <summary>Gets a value indicating the execution status of the current thread.</summary>
		/// <returns>
		///   <see langword="true" /> if this thread has been started and has not terminated normally or aborted; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x06003C2B RID: 15403
		public extern bool IsAlive { [SecuritySafeCritical] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		/// <summary>Gets a value indicating whether or not a thread belongs to the managed thread pool.</summary>
		/// <returns>
		///   <see langword="true" /> if this thread belongs to the managed thread pool; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x06003C2C RID: 15404
		public extern bool IsThreadPoolThread { [SecuritySafeCritical] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06003C2D RID: 15405
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool JoinInternal(int millisecondsTimeout);

		/// <summary>Blocks the calling thread until the thread represented by this instance terminates, while continuing to perform standard COM and <see langword="SendMessage" /> pumping.</summary>
		/// <exception cref="T:System.Threading.ThreadStateException">The caller attempted to join a thread that is in the <see cref="F:System.Threading.ThreadState.Unstarted" /> state.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread is interrupted while waiting.</exception>
		// Token: 0x06003C2E RID: 15406 RVA: 0x000E1B26 File Offset: 0x000DFD26
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public void Join()
		{
			this.JoinInternal(-1);
		}

		/// <summary>Blocks the calling thread until the thread represented by this instance terminates or the specified time elapses, while continuing to perform standard COM and SendMessage pumping.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait for the thread to terminate.</param>
		/// <returns>
		///   <see langword="true" /> if the thread has terminated; <see langword="false" /> if the thread has not terminated after the amount of time specified by the <paramref name="millisecondsTimeout" /> parameter has elapsed.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="millisecondsTimeout" /> is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" /> in milliseconds.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has not been started.</exception>
		// Token: 0x06003C2F RID: 15407 RVA: 0x000E1B30 File Offset: 0x000DFD30
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public bool Join(int millisecondsTimeout)
		{
			return this.JoinInternal(millisecondsTimeout);
		}

		/// <summary>Blocks the calling thread until the thread represented by this instance terminates or the specified time elapses, while continuing to perform standard COM and SendMessage pumping.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> set to the amount of time to wait for the thread to terminate.</param>
		/// <returns>
		///   <see langword="true" /> if the thread terminated; <see langword="false" /> if the thread has not terminated after the amount of time specified by the <paramref name="timeout" /> parameter has elapsed.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="timeout" /> is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" /> in milliseconds, or is greater than <see cref="F:System.Int32.MaxValue" /> milliseconds.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The caller attempted to join a thread that is in the <see cref="F:System.Threading.ThreadState.Unstarted" /> state.</exception>
		// Token: 0x06003C30 RID: 15408 RVA: 0x000E1B3C File Offset: 0x000DFD3C
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public bool Join(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.Join((int)num);
		}

		// Token: 0x06003C31 RID: 15409
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SleepInternal(int millisecondsTimeout);

		/// <summary>Suspends the current thread for the specified number of milliseconds.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds for which the thread is suspended. If the value of the <paramref name="millisecondsTimeout" /> argument is zero, the thread relinquishes the remainder of its time slice to any thread of equal priority that is ready to run. If there are no other threads of equal priority that are ready to run, execution of the current thread is not suspended.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The time-out value is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003C32 RID: 15410 RVA: 0x000E1B7D File Offset: 0x000DFD7D
		[SecuritySafeCritical]
		public static void Sleep(int millisecondsTimeout)
		{
			Thread.SleepInternal(millisecondsTimeout);
			if (AppDomainPauseManager.IsPaused)
			{
				AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
			}
		}

		/// <summary>Suspends the current thread for the specified amount of time.</summary>
		/// <param name="timeout">The amount of time for which the thread is suspended. If the value of the <paramref name="millisecondsTimeout" /> argument is <see cref="F:System.TimeSpan.Zero" />, the thread relinquishes the remainder of its time slice to any thread of equal priority that is ready to run. If there are no other threads of equal priority that are ready to run, execution of the current thread is not suspended.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="timeout" /> is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" /> in milliseconds, or is greater than <see cref="F:System.Int32.MaxValue" /> milliseconds.</exception>
		// Token: 0x06003C33 RID: 15411 RVA: 0x000E1B98 File Offset: 0x000DFD98
		public static void Sleep(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			Thread.Sleep((int)num);
		}

		// Token: 0x06003C34 RID: 15412
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCurrentProcessorNumber();

		// Token: 0x06003C35 RID: 15413 RVA: 0x000E1BD8 File Offset: 0x000DFDD8
		private static int RefreshCurrentProcessorId()
		{
			int num = Thread.GetCurrentProcessorNumber();
			if (num < 0)
			{
				num = Environment.CurrentManagedThreadId;
			}
			num += 100;
			Thread.t_currentProcessorIdCache = ((num << 16 & int.MaxValue) | 5000);
			return num;
		}

		// Token: 0x06003C36 RID: 15414 RVA: 0x000E1C10 File Offset: 0x000DFE10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int GetCurrentProcessorId()
		{
			int num = Thread.t_currentProcessorIdCache--;
			if ((num & 65535) == 0)
			{
				return Thread.RefreshCurrentProcessorId();
			}
			return num >> 16;
		}

		// Token: 0x06003C37 RID: 15415
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SpinWaitInternal(int iterations);

		/// <summary>Causes a thread to wait the number of times defined by the <paramref name="iterations" /> parameter.</summary>
		/// <param name="iterations">A 32-bit signed integer that defines how long a thread is to wait.</param>
		// Token: 0x06003C38 RID: 15416 RVA: 0x000E1C3E File Offset: 0x000DFE3E
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public static void SpinWait(int iterations)
		{
			Thread.SpinWaitInternal(iterations);
		}

		// Token: 0x06003C39 RID: 15417
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool YieldInternal();

		/// <summary>Causes the calling thread to yield execution to another thread that is ready to run on the current processor. The operating system selects the thread to yield to.</summary>
		/// <returns>
		///   <see langword="true" /> if the operating system switched execution to another thread; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003C3A RID: 15418 RVA: 0x000E1C46 File Offset: 0x000DFE46
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public static bool Yield()
		{
			return Thread.YieldInternal();
		}

		/// <summary>Gets the currently running thread.</summary>
		/// <returns>A <see cref="T:System.Threading.Thread" /> that is the representation of the currently running thread.</returns>
		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x06003C3B RID: 15419 RVA: 0x000E1C4D File Offset: 0x000DFE4D
		[__DynamicallyInvokable]
		public static Thread CurrentThread
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			[__DynamicallyInvokable]
			get
			{
				return Thread.GetCurrentThreadNative();
			}
		}

		// Token: 0x06003C3C RID: 15420
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Thread GetCurrentThreadNative();

		// Token: 0x06003C3D RID: 15421 RVA: 0x000E1C54 File Offset: 0x000DFE54
		[SecurityCritical]
		private void SetStartHelper(Delegate start, int maxStackSize)
		{
			ulong processDefaultStackSize = Thread.GetProcessDefaultStackSize();
			if ((ulong)maxStackSize > processDefaultStackSize)
			{
				try
				{
					CodeAccessPermission.Demand(PermissionType.FullTrust);
				}
				catch (SecurityException)
				{
					maxStackSize = (int)Math.Min(processDefaultStackSize, 2147483647UL);
				}
			}
			ThreadHelper @object = new ThreadHelper(start);
			if (start is ThreadStart)
			{
				this.SetStart(new ThreadStart(@object.ThreadStart), maxStackSize);
				return;
			}
			this.SetStart(new ParameterizedThreadStart(@object.ThreadStart), maxStackSize);
		}

		// Token: 0x06003C3E RID: 15422
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern ulong GetProcessDefaultStackSize();

		// Token: 0x06003C3F RID: 15423
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetStart(Delegate start, int maxStackSize);

		/// <summary>Ensures that resources are freed and other cleanup operations are performed when the garbage collector reclaims the <see cref="T:System.Threading.Thread" /> object.</summary>
		// Token: 0x06003C40 RID: 15424 RVA: 0x000E1CCC File Offset: 0x000DFECC
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~Thread()
		{
			this.InternalFinalize();
		}

		// Token: 0x06003C41 RID: 15425
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalFinalize();

		/// <summary>Turns off automatic cleanup of runtime callable wrappers (RCW) for the current thread.</summary>
		// Token: 0x06003C42 RID: 15426
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DisableComObjectEagerCleanup();

		/// <summary>Gets or sets a value indicating whether or not a thread is a background thread.</summary>
		/// <returns>
		///   <see langword="true" /> if this thread is or is to become a background thread; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread is dead.</exception>
		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x06003C43 RID: 15427 RVA: 0x000E1CF8 File Offset: 0x000DFEF8
		// (set) Token: 0x06003C44 RID: 15428 RVA: 0x000E1D00 File Offset: 0x000DFF00
		public bool IsBackground
		{
			[SecuritySafeCritical]
			get
			{
				return this.IsBackgroundNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading = true)]
			set
			{
				this.SetBackgroundNative(value);
			}
		}

		// Token: 0x06003C45 RID: 15429
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool IsBackgroundNative();

		// Token: 0x06003C46 RID: 15430
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetBackgroundNative(bool isBackground);

		/// <summary>Gets a value containing the states of the current thread.</summary>
		/// <returns>One of the <see cref="T:System.Threading.ThreadState" /> values indicating the state of the current thread. The initial value is <see langword="Unstarted" />.</returns>
		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x06003C47 RID: 15431 RVA: 0x000E1D09 File Offset: 0x000DFF09
		public ThreadState ThreadState
		{
			[SecuritySafeCritical]
			get
			{
				return (ThreadState)this.GetThreadStateNative();
			}
		}

		// Token: 0x06003C48 RID: 15432
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetThreadStateNative();

		/// <summary>Gets or sets the apartment state of this thread.</summary>
		/// <returns>One of the <see cref="T:System.Threading.ApartmentState" /> values. The initial value is <see langword="Unknown" />.</returns>
		/// <exception cref="T:System.ArgumentException">An attempt is made to set this property to a state that is not a valid apartment state (a state other than single-threaded apartment (<see langword="STA" />) or multithreaded apartment (<see langword="MTA" />)).</exception>
		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06003C49 RID: 15433 RVA: 0x000E1D11 File Offset: 0x000DFF11
		// (set) Token: 0x06003C4A RID: 15434 RVA: 0x000E1D19 File Offset: 0x000DFF19
		[Obsolete("The ApartmentState property has been deprecated.  Use GetApartmentState, SetApartmentState or TrySetApartmentState instead.", false)]
		public ApartmentState ApartmentState
		{
			[SecuritySafeCritical]
			get
			{
				return (ApartmentState)this.GetApartmentStateNative();
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
			set
			{
				this.SetApartmentStateNative((int)value, true);
			}
		}

		/// <summary>Returns an <see cref="T:System.Threading.ApartmentState" /> value indicating the apartment state.</summary>
		/// <returns>One of the <see cref="T:System.Threading.ApartmentState" /> values indicating the apartment state of the managed thread. The default is <see cref="F:System.Threading.ApartmentState.Unknown" />.</returns>
		// Token: 0x06003C4B RID: 15435 RVA: 0x000E1D24 File Offset: 0x000DFF24
		[SecuritySafeCritical]
		public ApartmentState GetApartmentState()
		{
			return (ApartmentState)this.GetApartmentStateNative();
		}

		/// <summary>Sets the apartment state of a thread before it is started.</summary>
		/// <param name="state">The new apartment state.</param>
		/// <returns>
		///   <see langword="true" /> if the apartment state is set; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="state" /> is not a valid apartment state.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has already been started.</exception>
		// Token: 0x06003C4C RID: 15436 RVA: 0x000E1D2C File Offset: 0x000DFF2C
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
		public bool TrySetApartmentState(ApartmentState state)
		{
			return this.SetApartmentStateHelper(state, false);
		}

		/// <summary>Sets the apartment state of a thread before it is started.</summary>
		/// <param name="state">The new apartment state.</param>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported on the macOS and Linux platforms.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="state" /> is not a valid apartment state.</exception>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread has already been started.</exception>
		/// <exception cref="T:System.InvalidOperationException">The apartment state has already been initialized.</exception>
		// Token: 0x06003C4D RID: 15437 RVA: 0x000E1D38 File Offset: 0x000DFF38
		[SecuritySafeCritical]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, SelfAffectingThreading = true)]
		public void SetApartmentState(ApartmentState state)
		{
			if (!this.SetApartmentStateHelper(state, true))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ApartmentStateSwitchFailed"));
			}
		}

		// Token: 0x06003C4E RID: 15438 RVA: 0x000E1D64 File Offset: 0x000DFF64
		[SecurityCritical]
		private bool SetApartmentStateHelper(ApartmentState state, bool fireMDAOnMismatch)
		{
			ApartmentState apartmentState = (ApartmentState)this.SetApartmentStateNative((int)state, fireMDAOnMismatch);
			return (state == ApartmentState.Unknown && apartmentState == ApartmentState.MTA) || apartmentState == state;
		}

		// Token: 0x06003C4F RID: 15439
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetApartmentStateNative();

		// Token: 0x06003C50 RID: 15440
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int SetApartmentStateNative(int state, bool fireMDAOnMismatch);

		// Token: 0x06003C51 RID: 15441
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartupSetApartmentStateInternal();

		/// <summary>Allocates an unnamed data slot on all the threads. For better performance, use fields that are marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <returns>The allocated named data slot on all threads.</returns>
		// Token: 0x06003C52 RID: 15442 RVA: 0x000E1D8B File Offset: 0x000DFF8B
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot AllocateDataSlot()
		{
			return Thread.LocalDataStoreManager.AllocateDataSlot();
		}

		/// <summary>Allocates a named data slot on all threads. For better performance, use fields that are marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <param name="name">The name of the data slot to be allocated.</param>
		/// <returns>The allocated named data slot on all threads.</returns>
		/// <exception cref="T:System.ArgumentException">A named data slot with the specified name already exists.</exception>
		// Token: 0x06003C53 RID: 15443 RVA: 0x000E1D97 File Offset: 0x000DFF97
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot AllocateNamedDataSlot(string name)
		{
			return Thread.LocalDataStoreManager.AllocateNamedDataSlot(name);
		}

		/// <summary>Looks up a named data slot. For better performance, use fields that are marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <param name="name">The name of the local data slot.</param>
		/// <returns>A <see cref="T:System.LocalDataStoreSlot" /> allocated for this thread.</returns>
		// Token: 0x06003C54 RID: 15444 RVA: 0x000E1DA4 File Offset: 0x000DFFA4
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static LocalDataStoreSlot GetNamedDataSlot(string name)
		{
			return Thread.LocalDataStoreManager.GetNamedDataSlot(name);
		}

		/// <summary>Eliminates the association between a name and a slot, for all threads in the process. For better performance, use fields that are marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <param name="name">The name of the data slot to be freed.</param>
		// Token: 0x06003C55 RID: 15445 RVA: 0x000E1DB1 File Offset: 0x000DFFB1
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static void FreeNamedDataSlot(string name)
		{
			Thread.LocalDataStoreManager.FreeNamedDataSlot(name);
		}

		/// <summary>Retrieves the value from the specified slot on the current thread, within the current thread's current domain. For better performance, use fields that are marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <param name="slot">The <see cref="T:System.LocalDataStoreSlot" /> from which to get the value.</param>
		/// <returns>The retrieved value.</returns>
		// Token: 0x06003C56 RID: 15446 RVA: 0x000E1DC0 File Offset: 0x000DFFC0
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static object GetData(LocalDataStoreSlot slot)
		{
			LocalDataStoreHolder localDataStoreHolder = Thread.s_LocalDataStore;
			if (localDataStoreHolder == null)
			{
				Thread.LocalDataStoreManager.ValidateSlot(slot);
				return null;
			}
			return localDataStoreHolder.Store.GetData(slot);
		}

		/// <summary>Sets the data in the specified slot on the currently running thread, for that thread's current domain. For better performance, use fields marked with the <see cref="T:System.ThreadStaticAttribute" /> attribute instead.</summary>
		/// <param name="slot">The <see cref="T:System.LocalDataStoreSlot" /> in which to set the value.</param>
		/// <param name="data">The value to be set.</param>
		// Token: 0x06003C57 RID: 15447 RVA: 0x000E1DF0 File Offset: 0x000DFFF0
		[HostProtection(SecurityAction.LinkDemand, SharedState = true, ExternalThreading = true)]
		public static void SetData(LocalDataStoreSlot slot, object data)
		{
			LocalDataStoreHolder localDataStoreHolder = Thread.s_LocalDataStore;
			if (localDataStoreHolder == null)
			{
				localDataStoreHolder = Thread.LocalDataStoreManager.CreateLocalDataStore();
				Thread.s_LocalDataStore = localDataStoreHolder;
			}
			localDataStoreHolder.Store.SetData(slot, data);
		}

		// Token: 0x06003C58 RID: 15448
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool nativeGetSafeCulture(Thread t, int appDomainId, bool isUI, ref CultureInfo safeCulture);

		/// <summary>Gets or sets the current culture used by the Resource Manager to look up culture-specific resources at run time.</summary>
		/// <returns>An object that represents the current culture.</returns>
		/// <exception cref="T:System.ArgumentNullException">The property is set to <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The property is set to a culture name that cannot be used to locate a resource file. Resource filenames must include only letters, numbers, hyphens or underscores.</exception>
		/// <exception cref="T:System.InvalidOperationException">.NET Core only: Reading or writing the culture of a thread from another thread is not supported.</exception>
		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06003C59 RID: 15449 RVA: 0x000E1E24 File Offset: 0x000E0024
		// (set) Token: 0x06003C5A RID: 15450 RVA: 0x000E1E44 File Offset: 0x000E0044
		[__DynamicallyInvokable]
		public CultureInfo CurrentUICulture
		{
			[__DynamicallyInvokable]
			get
			{
				if (AppDomain.IsAppXModel())
				{
					return CultureInfo.GetCultureInfoForUserPreferredLanguageInAppX() ?? this.GetCurrentUICultureNoAppX();
				}
				return this.GetCurrentUICultureNoAppX();
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CultureInfo.VerifyCultureName(value, true);
				if (!Thread.nativeSetThreadUILocale(value.SortName))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidResourceCultureName", new object[]
					{
						value.Name
					}));
				}
				value.StartCrossDomainTracking();
				if (!AppContextSwitches.NoAsyncCurrentCulture)
				{
					if (Thread.s_asyncLocalCurrentUICulture == null)
					{
						Interlocked.CompareExchange<AsyncLocal<CultureInfo>>(ref Thread.s_asyncLocalCurrentUICulture, new AsyncLocal<CultureInfo>(new Action<AsyncLocalValueChangedArgs<CultureInfo>>(Thread.AsyncLocalSetCurrentUICulture)), null);
					}
					Thread.s_asyncLocalCurrentUICulture.Value = value;
					return;
				}
				this.m_CurrentUICulture = value;
			}
		}

		// Token: 0x06003C5B RID: 15451 RVA: 0x000E1ED8 File Offset: 0x000E00D8
		[SecuritySafeCritical]
		internal CultureInfo GetCurrentUICultureNoAppX()
		{
			if (this.m_CurrentUICulture == null)
			{
				CultureInfo defaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentUICulture;
				if (defaultThreadCurrentUICulture == null)
				{
					return CultureInfo.UserDefaultUICulture;
				}
				return defaultThreadCurrentUICulture;
			}
			else
			{
				CultureInfo cultureInfo = null;
				if (!Thread.nativeGetSafeCulture(this, Thread.GetDomainID(), true, ref cultureInfo) || cultureInfo == null)
				{
					return CultureInfo.UserDefaultUICulture;
				}
				return cultureInfo;
			}
		}

		// Token: 0x06003C5C RID: 15452
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool nativeSetThreadUILocale(string locale);

		/// <summary>Gets or sets the culture for the current thread.</summary>
		/// <returns>An object that represents the culture for the current thread.</returns>
		/// <exception cref="T:System.ArgumentNullException">The property is set to <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">.NET Core only: Reading or writing the culture of a thread from another thread is not supported.</exception>
		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06003C5D RID: 15453 RVA: 0x000E1F1A File Offset: 0x000E011A
		// (set) Token: 0x06003C5E RID: 15454 RVA: 0x000E1F3C File Offset: 0x000E013C
		[__DynamicallyInvokable]
		public CultureInfo CurrentCulture
		{
			[__DynamicallyInvokable]
			get
			{
				if (AppDomain.IsAppXModel())
				{
					return CultureInfo.GetCultureInfoForUserPreferredLanguageInAppX() ?? this.GetCurrentCultureNoAppX();
				}
				return this.GetCurrentCultureNoAppX();
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CultureInfo.nativeSetThreadLocale(value.SortName);
				value.StartCrossDomainTracking();
				if (!AppContextSwitches.NoAsyncCurrentCulture)
				{
					if (Thread.s_asyncLocalCurrentCulture == null)
					{
						Interlocked.CompareExchange<AsyncLocal<CultureInfo>>(ref Thread.s_asyncLocalCurrentCulture, new AsyncLocal<CultureInfo>(new Action<AsyncLocalValueChangedArgs<CultureInfo>>(Thread.AsyncLocalSetCurrentCulture)), null);
					}
					Thread.s_asyncLocalCurrentCulture.Value = value;
					return;
				}
				this.m_CurrentCulture = value;
			}
		}

		// Token: 0x06003C5F RID: 15455 RVA: 0x000E1FA8 File Offset: 0x000E01A8
		[SecuritySafeCritical]
		private CultureInfo GetCurrentCultureNoAppX()
		{
			if (this.m_CurrentCulture == null)
			{
				CultureInfo defaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentCulture;
				if (defaultThreadCurrentCulture == null)
				{
					return CultureInfo.UserDefaultCulture;
				}
				return defaultThreadCurrentCulture;
			}
			else
			{
				CultureInfo cultureInfo = null;
				if (!Thread.nativeGetSafeCulture(this, Thread.GetDomainID(), false, ref cultureInfo) || cultureInfo == null)
				{
					return CultureInfo.UserDefaultCulture;
				}
				return cultureInfo;
			}
		}

		/// <summary>Gets the current context in which the thread is executing.</summary>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Contexts.Context" /> representing the current thread context.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06003C60 RID: 15456 RVA: 0x000E1FEA File Offset: 0x000E01EA
		public static Context CurrentContext
		{
			[SecurityCritical]
			get
			{
				return Thread.CurrentThread.GetCurrentContextInternal();
			}
		}

		// Token: 0x06003C61 RID: 15457 RVA: 0x000E1FF6 File Offset: 0x000E01F6
		[SecurityCritical]
		internal Context GetCurrentContextInternal()
		{
			if (this.m_Context == null)
			{
				this.m_Context = Context.DefaultContext;
			}
			return this.m_Context;
		}

		/// <summary>Gets or sets the thread's current principal (for role-based security).</summary>
		/// <returns>An <see cref="T:System.Security.Principal.IPrincipal" /> value representing the security context.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the permission required to set the principal.</exception>
		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x06003C62 RID: 15458 RVA: 0x000E2014 File Offset: 0x000E0214
		// (set) Token: 0x06003C63 RID: 15459 RVA: 0x000E206C File Offset: 0x000E026C
		public static IPrincipal CurrentPrincipal
		{
			[SecuritySafeCritical]
			get
			{
				Thread currentThread = Thread.CurrentThread;
				IPrincipal result;
				lock (currentThread)
				{
					IPrincipal principal = CallContext.Principal;
					if (principal == null)
					{
						principal = Thread.GetDomain().GetThreadPrincipal();
						CallContext.Principal = principal;
					}
					result = principal;
				}
				return result;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlPrincipal)]
			set
			{
				CallContext.Principal = value;
			}
		}

		// Token: 0x06003C64 RID: 15460 RVA: 0x000E2074 File Offset: 0x000E0274
		[SecurityCritical]
		private void SetPrincipalInternal(IPrincipal principal)
		{
			this.GetMutableExecutionContext().LogicalCallContext.SecurityData.Principal = principal;
		}

		// Token: 0x06003C65 RID: 15461
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Context GetContextInternal(IntPtr id);

		// Token: 0x06003C66 RID: 15462
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object InternalCrossContextCallback(Context ctx, IntPtr ctxID, int appDomainID, InternalCrossContextDelegate ftnToCall, object[] args);

		// Token: 0x06003C67 RID: 15463 RVA: 0x000E208C File Offset: 0x000E028C
		[SecurityCritical]
		internal object InternalCrossContextCallback(Context ctx, InternalCrossContextDelegate ftnToCall, object[] args)
		{
			return this.InternalCrossContextCallback(ctx, ctx.InternalContextID, 0, ftnToCall, args);
		}

		// Token: 0x06003C68 RID: 15464 RVA: 0x000E209E File Offset: 0x000E029E
		private static object CompleteCrossContextCallback(InternalCrossContextDelegate ftnToCall, object[] args)
		{
			return ftnToCall(args);
		}

		// Token: 0x06003C69 RID: 15465
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain GetDomainInternal();

		// Token: 0x06003C6A RID: 15466
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain GetFastDomainInternal();

		/// <summary>Returns the current domain in which the current thread is running.</summary>
		/// <returns>An <see cref="T:System.AppDomain" /> representing the current application domain of the running thread.</returns>
		// Token: 0x06003C6B RID: 15467 RVA: 0x000E20A8 File Offset: 0x000E02A8
		[SecuritySafeCritical]
		public static AppDomain GetDomain()
		{
			AppDomain appDomain = Thread.GetFastDomainInternal();
			if (appDomain == null)
			{
				appDomain = Thread.GetDomainInternal();
			}
			return appDomain;
		}

		/// <summary>Returns a unique application domain identifier.</summary>
		/// <returns>A 32-bit signed integer uniquely identifying the application domain.</returns>
		// Token: 0x06003C6C RID: 15468 RVA: 0x000E20C5 File Offset: 0x000E02C5
		public static int GetDomainID()
		{
			return Thread.GetDomain().GetId();
		}

		/// <summary>Gets or sets the name of the thread.</summary>
		/// <returns>A string containing the name of the thread, or <see langword="null" /> if no name was set.</returns>
		/// <exception cref="T:System.InvalidOperationException">A set operation was requested, but the <see langword="Name" /> property has already been set.</exception>
		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06003C6D RID: 15469 RVA: 0x000E20D1 File Offset: 0x000E02D1
		// (set) Token: 0x06003C6E RID: 15470 RVA: 0x000E20DC File Offset: 0x000E02DC
		public string Name
		{
			get
			{
				return this.m_Name;
			}
			[SecuritySafeCritical]
			[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
			set
			{
				lock (this)
				{
					if (this.m_Name != null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_WriteOnce"));
					}
					this.m_Name = value;
					Thread.InformThreadNameChange(this.GetNativeHandle(), value, (value != null) ? value.Length : 0);
				}
			}
		}

		// Token: 0x06003C6F RID: 15471
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void InformThreadNameChange(ThreadHandle t, string name, int len);

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x06003C70 RID: 15472 RVA: 0x000E2148 File Offset: 0x000E0348
		// (set) Token: 0x06003C71 RID: 15473 RVA: 0x000E2184 File Offset: 0x000E0384
		internal object AbortReason
		{
			[SecurityCritical]
			get
			{
				object result = null;
				try
				{
					result = this.GetAbortReason();
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ExceptionStateCrossAppDomain"), innerException);
				}
				return result;
			}
			[SecurityCritical]
			set
			{
				this.SetAbortReason(value);
			}
		}

		/// <summary>Notifies a host that execution is about to enter a region of code in which the effects of a thread abort or unhandled exception might jeopardize other tasks in the application domain.</summary>
		// Token: 0x06003C72 RID: 15474
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginCriticalRegion();

		/// <summary>Notifies a host that execution is about to enter a region of code in which the effects of a thread abort or unhandled exception are limited to the current task.</summary>
		// Token: 0x06003C73 RID: 15475
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndCriticalRegion();

		/// <summary>Notifies a host that managed code is about to execute instructions that depend on the identity of the current physical operating system thread.</summary>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003C74 RID: 15476
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginThreadAffinity();

		/// <summary>Notifies a host that managed code has finished executing instructions that depend on the identity of the current physical operating system thread.</summary>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003C75 RID: 15477
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndThreadAffinity();

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C76 RID: 15478 RVA: 0x000E2190 File Offset: 0x000E0390
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte VolatileRead(ref byte address)
		{
			byte result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C77 RID: 15479 RVA: 0x000E21A8 File Offset: 0x000E03A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static short VolatileRead(ref short address)
		{
			short result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C78 RID: 15480 RVA: 0x000E21C0 File Offset: 0x000E03C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static int VolatileRead(ref int address)
		{
			int result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C79 RID: 15481 RVA: 0x000E21D8 File Offset: 0x000E03D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static long VolatileRead(ref long address)
		{
			long result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7A RID: 15482 RVA: 0x000E21F0 File Offset: 0x000E03F0
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static sbyte VolatileRead(ref sbyte address)
		{
			sbyte result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7B RID: 15483 RVA: 0x000E2208 File Offset: 0x000E0408
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ushort VolatileRead(ref ushort address)
		{
			ushort result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7C RID: 15484 RVA: 0x000E2220 File Offset: 0x000E0420
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static uint VolatileRead(ref uint address)
		{
			uint result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7D RID: 15485 RVA: 0x000E2238 File Offset: 0x000E0438
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IntPtr VolatileRead(ref IntPtr address)
		{
			IntPtr result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7E RID: 15486 RVA: 0x000E2250 File Offset: 0x000E0450
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static UIntPtr VolatileRead(ref UIntPtr address)
		{
			UIntPtr result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C7F RID: 15487 RVA: 0x000E2268 File Offset: 0x000E0468
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ulong VolatileRead(ref ulong address)
		{
			ulong result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C80 RID: 15488 RVA: 0x000E2280 File Offset: 0x000E0480
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static float VolatileRead(ref float address)
		{
			float result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C81 RID: 15489 RVA: 0x000E2298 File Offset: 0x000E0498
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double VolatileRead(ref double address)
		{
			double result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache.</summary>
		/// <param name="address">The field to be read.</param>
		/// <returns>The latest value written to the field by any processor.</returns>
		// Token: 0x06003C82 RID: 15490 RVA: 0x000E22B0 File Offset: 0x000E04B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object VolatileRead(ref object address)
		{
			object result = address;
			Thread.MemoryBarrier();
			return result;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C83 RID: 15491 RVA: 0x000E22C6 File Offset: 0x000E04C6
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref byte address, byte value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C84 RID: 15492 RVA: 0x000E22D0 File Offset: 0x000E04D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref short address, short value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C85 RID: 15493 RVA: 0x000E22DA File Offset: 0x000E04DA
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref int address, int value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C86 RID: 15494 RVA: 0x000E22E4 File Offset: 0x000E04E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref long address, long value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C87 RID: 15495 RVA: 0x000E22EE File Offset: 0x000E04EE
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref sbyte address, sbyte value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C88 RID: 15496 RVA: 0x000E22F8 File Offset: 0x000E04F8
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref ushort address, ushort value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C89 RID: 15497 RVA: 0x000E2302 File Offset: 0x000E0502
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref uint address, uint value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8A RID: 15498 RVA: 0x000E230C File Offset: 0x000E050C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref IntPtr address, IntPtr value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8B RID: 15499 RVA: 0x000E2316 File Offset: 0x000E0516
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref UIntPtr address, UIntPtr value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8C RID: 15500 RVA: 0x000E2320 File Offset: 0x000E0520
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref ulong address, ulong value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8D RID: 15501 RVA: 0x000E232A File Offset: 0x000E052A
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref float address, float value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8E RID: 15502 RVA: 0x000E2334 File Offset: 0x000E0534
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref double address, double value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Writes a value to a field immediately, so that the value is visible to all processors in the computer.</summary>
		/// <param name="address">The field to which the value is to be written.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06003C8F RID: 15503 RVA: 0x000E233E File Offset: 0x000E053E
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VolatileWrite(ref object address, object value)
		{
			Thread.MemoryBarrier();
			address = value;
		}

		/// <summary>Synchronizes memory access as follows: The processor executing the current thread cannot reorder instructions in such a way that memory accesses prior to the call to <see cref="M:System.Threading.Thread.MemoryBarrier" /> execute after memory accesses that follow the call to <see cref="M:System.Threading.Thread.MemoryBarrier" />.</summary>
		// Token: 0x06003C90 RID: 15504
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void MemoryBarrier();

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x06003C91 RID: 15505 RVA: 0x000E2348 File Offset: 0x000E0548
		private static LocalDataStoreMgr LocalDataStoreManager
		{
			get
			{
				if (Thread.s_LocalDataStoreMgr == null)
				{
					Interlocked.CompareExchange<LocalDataStoreMgr>(ref Thread.s_LocalDataStoreMgr, new LocalDataStoreMgr(), null);
				}
				return Thread.s_LocalDataStoreMgr;
			}
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06003C92 RID: 15506 RVA: 0x000E2367 File Offset: 0x000E0567
		void _Thread.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06003C93 RID: 15507 RVA: 0x000E236E File Offset: 0x000E056E
		void _Thread.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06003C94 RID: 15508 RVA: 0x000E2375 File Offset: 0x000E0575
		void _Thread.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06003C95 RID: 15509 RVA: 0x000E237C File Offset: 0x000E057C
		void _Thread.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003C96 RID: 15510
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetAbortReason(object o);

		// Token: 0x06003C97 RID: 15511
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object GetAbortReason();

		// Token: 0x06003C98 RID: 15512
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void ClearAbortReason();

		// Token: 0x0400192D RID: 6445
		private Context m_Context;

		// Token: 0x0400192E RID: 6446
		private ExecutionContext m_ExecutionContext;

		// Token: 0x0400192F RID: 6447
		private string m_Name;

		// Token: 0x04001930 RID: 6448
		private Delegate m_Delegate;

		// Token: 0x04001931 RID: 6449
		private CultureInfo m_CurrentCulture;

		// Token: 0x04001932 RID: 6450
		private CultureInfo m_CurrentUICulture;

		// Token: 0x04001933 RID: 6451
		private object m_ThreadStartArg;

		// Token: 0x04001934 RID: 6452
		private IntPtr DONT_USE_InternalThread;

		// Token: 0x04001935 RID: 6453
		private int m_Priority;

		// Token: 0x04001936 RID: 6454
		private int m_ManagedThreadId;

		// Token: 0x04001937 RID: 6455
		private bool m_ExecutionContextBelongsToOuterScope;

		// Token: 0x04001938 RID: 6456
		private static LocalDataStoreMgr s_LocalDataStoreMgr;

		// Token: 0x04001939 RID: 6457
		[ThreadStatic]
		private static LocalDataStoreHolder s_LocalDataStore;

		// Token: 0x0400193A RID: 6458
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentCulture;

		// Token: 0x0400193B RID: 6459
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentUICulture;

		// Token: 0x0400193C RID: 6460
		[ThreadStatic]
		private static int t_currentProcessorIdCache;

		// Token: 0x0400193D RID: 6461
		private const int ProcessorIdCacheShift = 16;

		// Token: 0x0400193E RID: 6462
		private const int ProcessorIdCacheCountDownMask = 65535;

		// Token: 0x0400193F RID: 6463
		private const int ProcessorIdRefreshRate = 5000;
	}
}
