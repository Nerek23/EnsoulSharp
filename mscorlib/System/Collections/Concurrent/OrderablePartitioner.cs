using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Collections.Concurrent
{
	/// <summary>Represents a particular manner of splitting an orderable data source into multiple partitions.</summary>
	/// <typeparam name="TSource">Type of the elements in the collection.</typeparam>
	// Token: 0x02000485 RID: 1157
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public abstract class OrderablePartitioner<TSource> : Partitioner<TSource>
	{
		/// <summary>Called from constructors in derived classes to initialize the <see cref="T:System.Collections.Concurrent.OrderablePartitioner`1" /> class with the specified constraints on the index keys.</summary>
		/// <param name="keysOrderedInEachPartition">Indicates whether the elements in each partition are yielded in the order of increasing keys.</param>
		/// <param name="keysOrderedAcrossPartitions">Indicates whether elements in an earlier partition always come before elements in a later partition. If true, each element in partition 0 has a smaller order key than any element in partition 1, each element in partition 1 has a smaller order key than any element in partition 2, and so on.</param>
		/// <param name="keysNormalized">Indicates whether keys are normalized. If true, all order keys are distinct integers in the range [0 .. numberOfElements-1]. If false, order keys must still be distinct, but only their relative order is considered, not their absolute values.</param>
		// Token: 0x06003873 RID: 14451 RVA: 0x000D7E06 File Offset: 0x000D6006
		[__DynamicallyInvokable]
		protected OrderablePartitioner(bool keysOrderedInEachPartition, bool keysOrderedAcrossPartitions, bool keysNormalized)
		{
			this.KeysOrderedInEachPartition = keysOrderedInEachPartition;
			this.KeysOrderedAcrossPartitions = keysOrderedAcrossPartitions;
			this.KeysNormalized = keysNormalized;
		}

		/// <summary>Partitions the underlying collection into the specified number of orderable partitions.</summary>
		/// <param name="partitionCount">The number of partitions to create.</param>
		/// <returns>A list containing <paramref name="partitionCount" /> enumerators.</returns>
		// Token: 0x06003874 RID: 14452
		[__DynamicallyInvokable]
		public abstract IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount);

		/// <summary>Creates an object that can partition the underlying collection into a variable number of partitions.</summary>
		/// <returns>An object that can create partitions over the underlying data source.</returns>
		/// <exception cref="T:System.NotSupportedException">Dynamic partitioning is not supported by this partitioner.</exception>
		// Token: 0x06003875 RID: 14453 RVA: 0x000D7E23 File Offset: 0x000D6023
		[__DynamicallyInvokable]
		public virtual IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions()
		{
			throw new NotSupportedException(Environment.GetResourceString("Partitioner_DynamicPartitionsNotSupported"));
		}

		/// <summary>Gets whether elements in each partition are yielded in the order of increasing keys.</summary>
		/// <returns>
		///   <see langword="true" /> if the elements in each partition are yielded in the order of increasing keys; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06003876 RID: 14454 RVA: 0x000D7E34 File Offset: 0x000D6034
		// (set) Token: 0x06003877 RID: 14455 RVA: 0x000D7E3C File Offset: 0x000D603C
		[__DynamicallyInvokable]
		public bool KeysOrderedInEachPartition { [__DynamicallyInvokable] get; private set; }

		/// <summary>Gets whether elements in an earlier partition always come before elements in a later partition.</summary>
		/// <returns>
		///   <see langword="true" /> if the elements in an earlier partition always come before elements in a later partition; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06003878 RID: 14456 RVA: 0x000D7E45 File Offset: 0x000D6045
		// (set) Token: 0x06003879 RID: 14457 RVA: 0x000D7E4D File Offset: 0x000D604D
		[__DynamicallyInvokable]
		public bool KeysOrderedAcrossPartitions { [__DynamicallyInvokable] get; private set; }

		/// <summary>Gets whether order keys are normalized.</summary>
		/// <returns>
		///   <see langword="true" /> if the keys are normalized; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x0600387A RID: 14458 RVA: 0x000D7E56 File Offset: 0x000D6056
		// (set) Token: 0x0600387B RID: 14459 RVA: 0x000D7E5E File Offset: 0x000D605E
		[__DynamicallyInvokable]
		public bool KeysNormalized { [__DynamicallyInvokable] get; private set; }

		/// <summary>Partitions the underlying collection into the given number of ordered partitions.</summary>
		/// <param name="partitionCount">The number of partitions to create.</param>
		/// <returns>A list containing <paramref name="partitionCount" /> enumerators.</returns>
		// Token: 0x0600387C RID: 14460 RVA: 0x000D7E68 File Offset: 0x000D6068
		[__DynamicallyInvokable]
		public override IList<IEnumerator<TSource>> GetPartitions(int partitionCount)
		{
			IList<IEnumerator<KeyValuePair<long, TSource>>> orderablePartitions = this.GetOrderablePartitions(partitionCount);
			if (orderablePartitions.Count != partitionCount)
			{
				throw new InvalidOperationException("OrderablePartitioner_GetPartitions_WrongNumberOfPartitions");
			}
			IEnumerator<TSource>[] array = new IEnumerator<!0>[partitionCount];
			for (int i = 0; i < partitionCount; i++)
			{
				array[i] = new OrderablePartitioner<TSource>.EnumeratorDropIndices(orderablePartitions[i]);
			}
			return array;
		}

		/// <summary>Creates an object that can partition the underlying collection into a variable number of partitions.</summary>
		/// <returns>An object that can create partitions over the underlying data source.</returns>
		/// <exception cref="T:System.NotSupportedException">Dynamic partitioning is not supported by the base class. It must be implemented in derived classes.</exception>
		// Token: 0x0600387D RID: 14461 RVA: 0x000D7EB4 File Offset: 0x000D60B4
		[__DynamicallyInvokable]
		public override IEnumerable<TSource> GetDynamicPartitions()
		{
			IEnumerable<KeyValuePair<long, TSource>> orderableDynamicPartitions = this.GetOrderableDynamicPartitions();
			return new OrderablePartitioner<TSource>.EnumerableDropIndices(orderableDynamicPartitions);
		}

		// Token: 0x02000B93 RID: 2963
		private class EnumerableDropIndices : IEnumerable<!0>, IEnumerable, IDisposable
		{
			// Token: 0x06006D66 RID: 28006 RVA: 0x00178DD7 File Offset: 0x00176FD7
			public EnumerableDropIndices(IEnumerable<KeyValuePair<long, TSource>> source)
			{
				this.m_source = source;
			}

			// Token: 0x06006D67 RID: 28007 RVA: 0x00178DE6 File Offset: 0x00176FE6
			public IEnumerator<TSource> GetEnumerator()
			{
				return new OrderablePartitioner<TSource>.EnumeratorDropIndices(this.m_source.GetEnumerator());
			}

			// Token: 0x06006D68 RID: 28008 RVA: 0x00178DF8 File Offset: 0x00176FF8
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06006D69 RID: 28009 RVA: 0x00178E00 File Offset: 0x00177000
			public void Dispose()
			{
				IDisposable disposable = this.m_source as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			// Token: 0x040034CE RID: 13518
			private readonly IEnumerable<KeyValuePair<long, TSource>> m_source;
		}

		// Token: 0x02000B94 RID: 2964
		private class EnumeratorDropIndices : IEnumerator<!0>, IDisposable, IEnumerator
		{
			// Token: 0x06006D6A RID: 28010 RVA: 0x00178E22 File Offset: 0x00177022
			public EnumeratorDropIndices(IEnumerator<KeyValuePair<long, TSource>> source)
			{
				this.m_source = source;
			}

			// Token: 0x06006D6B RID: 28011 RVA: 0x00178E31 File Offset: 0x00177031
			public bool MoveNext()
			{
				return this.m_source.MoveNext();
			}

			// Token: 0x170012CE RID: 4814
			// (get) Token: 0x06006D6C RID: 28012 RVA: 0x00178E40 File Offset: 0x00177040
			public TSource Current
			{
				get
				{
					KeyValuePair<long, TSource> keyValuePair = this.m_source.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x170012CF RID: 4815
			// (get) Token: 0x06006D6D RID: 28013 RVA: 0x00178E60 File Offset: 0x00177060
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06006D6E RID: 28014 RVA: 0x00178E6D File Offset: 0x0017706D
			public void Dispose()
			{
				this.m_source.Dispose();
			}

			// Token: 0x06006D6F RID: 28015 RVA: 0x00178E7A File Offset: 0x0017707A
			public void Reset()
			{
				this.m_source.Reset();
			}

			// Token: 0x040034CF RID: 13519
			private readonly IEnumerator<KeyValuePair<long, TSource>> m_source;
		}
	}
}
