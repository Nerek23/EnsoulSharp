﻿using System;

namespace System.Threading
{
	/// <summary>Specifies how a <see cref="T:System.Lazy`1" /> instance synchronizes access among multiple threads.</summary>
	// Token: 0x02000510 RID: 1296
	[__DynamicallyInvokable]
	public enum LazyThreadSafetyMode
	{
		/// <summary>The <see cref="T:System.Lazy`1" /> instance is not thread safe; if the instance is accessed from multiple threads, its behavior is undefined. Use this mode only when high performance is crucial and the <see cref="T:System.Lazy`1" /> instance is guaranteed never to be initialized from more than one thread. If you use a <see cref="T:System.Lazy`1" /> constructor that specifies an initialization method (<paramref name="valueFactory" /> parameter), and if that initialization method throws an exception (or fails to handle an exception) the first time you call the <see cref="P:System.Lazy`1.Value" /> property, then the exception is cached and thrown again on subsequent calls to the <see cref="P:System.Lazy`1.Value" /> property. If you use a <see cref="T:System.Lazy`1" /> constructor that does not specify an initialization method, exceptions that are thrown by the default constructor for <paramref name="T" /> are not cached. In that case, a subsequent call to the <see cref="P:System.Lazy`1.Value" /> property might successfully initialize the <see cref="T:System.Lazy`1" /> instance. If the initialization method recursively accesses the <see cref="P:System.Lazy`1.Value" /> property of the <see cref="T:System.Lazy`1" /> instance, an <see cref="T:System.InvalidOperationException" /> is thrown.</summary>
		// Token: 0x040019B8 RID: 6584
		[__DynamicallyInvokable]
		None,
		/// <summary>When multiple threads try to initialize a <see cref="T:System.Lazy`1" /> instance simultaneously, all threads are allowed to run the initialization method (or the default constructor, if there is no initialization method). The first thread to complete initialization sets the value of the <see cref="T:System.Lazy`1" /> instance. That value is returned to any other threads that were simultaneously running the initialization method, unless the initialization method throws exceptions on those threads. Any instances of <paramref name="T" /> that were created by the competing threads are discarded. If the initialization method throws an exception on any thread, the exception is propagated out of the <see cref="P:System.Lazy`1.Value" /> property on that thread. The exception is not cached. The value of the <see cref="P:System.Lazy`1.IsValueCreated" /> property remains <see langword="false" />, and subsequent calls to the <see cref="P:System.Lazy`1.Value" /> property, either by the thread where the exception was thrown or by other threads, cause the initialization method to run again. If the initialization method recursively accesses the <see cref="P:System.Lazy`1.Value" /> property of the <see cref="T:System.Lazy`1" /> instance, no exception is thrown.</summary>
		// Token: 0x040019B9 RID: 6585
		[__DynamicallyInvokable]
		PublicationOnly,
		/// <summary>Locks are used to ensure that only a single thread can initialize a <see cref="T:System.Lazy`1" /> instance in a thread-safe manner. If the initialization method (or the default constructor, if there is no initialization method) uses locks internally, deadlocks can occur. If you use a <see cref="T:System.Lazy`1" /> constructor that specifies an initialization method (<paramref name="valueFactory" /> parameter), and if that initialization method throws an exception (or fails to handle an exception) the first time you call the <see cref="P:System.Lazy`1.Value" /> property, then the exception is cached and thrown again on subsequent calls to the <see cref="P:System.Lazy`1.Value" /> property. If you use a <see cref="T:System.Lazy`1" /> constructor that does not specify an initialization method, exceptions that are thrown by the default constructor for <paramref name="T" /> are not cached. In that case, a subsequent call to the <see cref="P:System.Lazy`1.Value" /> property might successfully initialize the <see cref="T:System.Lazy`1" /> instance. If the initialization method recursively accesses the <see cref="P:System.Lazy`1.Value" /> property of the <see cref="T:System.Lazy`1" /> instance, an <see cref="T:System.InvalidOperationException" /> is thrown.</summary>
		// Token: 0x040019BA RID: 6586
		[__DynamicallyInvokable]
		ExecutionAndPublication
	}
}
