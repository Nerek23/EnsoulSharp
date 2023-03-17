using System;

namespace System.Threading.Tasks
{
	/// <summary>Provides completion status on the execution of a <see cref="T:System.Threading.Tasks.Parallel" /> loop.</summary>
	// Token: 0x0200052E RID: 1326
	[__DynamicallyInvokable]
	public struct ParallelLoopResult
	{
		/// <summary>Gets whether the loop ran to completion, such that all iterations of the loop were executed and the loop didn't receive a request to end prematurely.</summary>
		/// <returns>true if the loop ran to completion; otherwise false;</returns>
		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06003F4F RID: 16207 RVA: 0x000EBBDD File Offset: 0x000E9DDD
		[__DynamicallyInvokable]
		public bool IsCompleted
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_completed;
			}
		}

		/// <summary>Gets the index of the lowest iteration from which <see cref="M:System.Threading.Tasks.ParallelLoopState.Break" /> was called.</summary>
		/// <returns>Returns an integer that represents the lowest iteration from which the Break statement was called.</returns>
		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06003F50 RID: 16208 RVA: 0x000EBBE5 File Offset: 0x000E9DE5
		[__DynamicallyInvokable]
		public long? LowestBreakIteration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_lowestBreakIteration;
			}
		}

		// Token: 0x04001A30 RID: 6704
		internal bool m_completed;

		// Token: 0x04001A31 RID: 6705
		internal long? m_lowestBreakIteration;
	}
}
