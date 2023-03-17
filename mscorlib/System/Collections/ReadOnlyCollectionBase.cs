using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Provides the <see langword="abstract" /> base class for a strongly typed non-generic read-only collection.</summary>
	// Token: 0x02000461 RID: 1121
	[ComVisible(true)]
	[Serializable]
	public abstract class ReadOnlyCollectionBase : ICollection, IEnumerable
	{
		/// <summary>Gets the list of elements contained in the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.ArrayList" /> representing the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance itself.</returns>
		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06003694 RID: 13972 RVA: 0x000D1263 File Offset: 0x000CF463
		protected ArrayList InnerList
		{
			get
			{
				if (this.list == null)
				{
					this.list = new ArrayList();
				}
				return this.list;
			}
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance.  
		///  Retrieving the value of this property is an O(1) operation.</returns>
		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06003695 RID: 13973 RVA: 0x000D127E File Offset: 0x000CF47E
		public virtual int Count
		{
			get
			{
				return this.InnerList.Count;
			}
		}

		/// <summary>Gets a value indicating whether access to a <see cref="T:System.Collections.ReadOnlyCollectionBase" /> object is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> object is synchronized (thread safe); otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06003696 RID: 13974 RVA: 0x000D128B File Offset: 0x000CF48B
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerList.IsSynchronized;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to a <see cref="T:System.Collections.ReadOnlyCollectionBase" /> object.</summary>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> object.</returns>
		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06003697 RID: 13975 RVA: 0x000D1298 File Offset: 0x000CF498
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerList.SyncRoot;
			}
		}

		/// <summary>Copies the entire <see cref="T:System.Collections.ReadOnlyCollectionBase" /> to a compatible one-dimensional <see cref="T:System.Array" />, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ReadOnlyCollectionBase" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the source <see cref="T:System.Collections.ReadOnlyCollectionBase" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		/// <exception cref="T:System.InvalidCastException">The type of the source <see cref="T:System.Collections.ReadOnlyCollectionBase" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x06003698 RID: 13976 RVA: 0x000D12A5 File Offset: 0x000CF4A5
		void ICollection.CopyTo(Array array, int index)
		{
			this.InnerList.CopyTo(array, index);
		}

		/// <summary>Returns an enumerator that iterates through the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Collections.ReadOnlyCollectionBase" /> instance.</returns>
		// Token: 0x06003699 RID: 13977 RVA: 0x000D12B4 File Offset: 0x000CF4B4
		public virtual IEnumerator GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		// Token: 0x040017FF RID: 6143
		private ArrayList list;
	}
}
