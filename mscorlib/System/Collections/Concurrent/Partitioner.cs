using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Collections.Concurrent
{
	/// <summary>Represents a particular manner of splitting a data source into multiple partitions.</summary>
	/// <typeparam name="TSource">Type of the elements in the collection.</typeparam>
	// Token: 0x02000484 RID: 1156
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public abstract class Partitioner<TSource>
	{
		/// <summary>Partitions the underlying collection into the given number of partitions.</summary>
		/// <param name="partitionCount">The number of partitions to create.</param>
		/// <returns>A list containing <paramref name="partitionCount" /> enumerators.</returns>
		// Token: 0x0600386F RID: 14447
		[__DynamicallyInvokable]
		public abstract IList<IEnumerator<TSource>> GetPartitions(int partitionCount);

		/// <summary>Gets whether additional partitions can be created dynamically.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.Concurrent.Partitioner`1" /> can create partitions dynamically as they are requested; <see langword="false" /> if the <see cref="T:System.Collections.Concurrent.Partitioner`1" /> can only allocate partitions statically.</returns>
		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06003870 RID: 14448 RVA: 0x000D7DEA File Offset: 0x000D5FEA
		[__DynamicallyInvokable]
		public virtual bool SupportsDynamicPartitions
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Creates an object that can partition the underlying collection into a variable number of partitions.</summary>
		/// <returns>An object that can create partitions over the underlying data source.</returns>
		/// <exception cref="T:System.NotSupportedException">Dynamic partitioning is not supported by the base class. You must implement it in a derived class.</exception>
		// Token: 0x06003871 RID: 14449 RVA: 0x000D7DED File Offset: 0x000D5FED
		[__DynamicallyInvokable]
		public virtual IEnumerable<TSource> GetDynamicPartitions()
		{
			throw new NotSupportedException(Environment.GetResourceString("Partitioner_DynamicPartitionsNotSupported"));
		}

		/// <summary>Creates a new partitioner instance.</summary>
		// Token: 0x06003872 RID: 14450 RVA: 0x000D7DFE File Offset: 0x000D5FFE
		[__DynamicallyInvokable]
		protected Partitioner()
		{
		}
	}
}
