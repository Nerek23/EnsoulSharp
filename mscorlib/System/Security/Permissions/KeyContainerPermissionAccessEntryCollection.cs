using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Represents a collection of <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects. This class cannot be inherited.</summary>
	// Token: 0x020002E9 RID: 745
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAccessEntryCollection : ICollection, IEnumerable
	{
		// Token: 0x060026AA RID: 9898 RVA: 0x0008C179 File Offset: 0x0008A379
		private KeyContainerPermissionAccessEntryCollection()
		{
		}

		// Token: 0x060026AB RID: 9899 RVA: 0x0008C181 File Offset: 0x0008A381
		internal KeyContainerPermissionAccessEntryCollection(KeyContainerPermissionFlags globalFlags)
		{
			this.m_list = new ArrayList();
			this.m_globalFlags = globalFlags;
		}

		/// <summary>Gets the item at the specified index in the collection.</summary>
		/// <param name="index">The zero-based index of the element to access.</param>
		/// <returns>The <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object at the specified index in the collection.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is greater than or equal to the collection count.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="index" /> is negative.</exception>
		// Token: 0x170004FF RID: 1279
		public KeyContainerPermissionAccessEntry this[int index]
		{
			get
			{
				if (index < 0)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
				}
				if (index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				return (KeyContainerPermissionAccessEntry)this.m_list[index];
			}
		}

		/// <summary>Gets the number of items in the collection.</summary>
		/// <returns>The number of <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects in the collection.</returns>
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060026AD RID: 9901 RVA: 0x0008C1EC File Offset: 0x0008A3EC
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		/// <summary>Adds a <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object to the collection.</summary>
		/// <param name="accessEntry">The <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="accessEntry" /> is <see langword="null" />.</exception>
		// Token: 0x060026AE RID: 9902 RVA: 0x0008C1FC File Offset: 0x0008A3FC
		public int Add(KeyContainerPermissionAccessEntry accessEntry)
		{
			if (accessEntry == null)
			{
				throw new ArgumentNullException("accessEntry");
			}
			int num = this.m_list.IndexOf(accessEntry);
			if (num != -1)
			{
				((KeyContainerPermissionAccessEntry)this.m_list[num]).Flags &= accessEntry.Flags;
				return num;
			}
			if (accessEntry.Flags != this.m_globalFlags)
			{
				return this.m_list.Add(accessEntry);
			}
			return -1;
		}

		/// <summary>Removes all the <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects from the collection.</summary>
		// Token: 0x060026AF RID: 9903 RVA: 0x0008C269 File Offset: 0x0008A469
		public void Clear()
		{
			this.m_list.Clear();
		}

		/// <summary>Gets the index in the collection of the specified <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object, if it exists in the collection.</summary>
		/// <param name="accessEntry">The <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object to locate.</param>
		/// <returns>The index of the specified <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object in the collection, or -1 if no match is found.</returns>
		// Token: 0x060026B0 RID: 9904 RVA: 0x0008C276 File Offset: 0x0008A476
		public int IndexOf(KeyContainerPermissionAccessEntry accessEntry)
		{
			return this.m_list.IndexOf(accessEntry);
		}

		/// <summary>Removes the specified <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object from thecollection.</summary>
		/// <param name="accessEntry">The <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> object to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="accessEntry" /> is <see langword="null" />.</exception>
		// Token: 0x060026B1 RID: 9905 RVA: 0x0008C284 File Offset: 0x0008A484
		public void Remove(KeyContainerPermissionAccessEntry accessEntry)
		{
			if (accessEntry == null)
			{
				throw new ArgumentNullException("accessEntry");
			}
			this.m_list.Remove(accessEntry);
		}

		/// <summary>Returns a <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator" /> object that can be used to iterate through the objects in the collection.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator" /> object that can be used to iterate through the collection.</returns>
		// Token: 0x060026B2 RID: 9906 RVA: 0x0008C2A0 File Offset: 0x0008A4A0
		public KeyContainerPermissionAccessEntryEnumerator GetEnumerator()
		{
			return new KeyContainerPermissionAccessEntryEnumerator(this);
		}

		/// <summary>Returns a <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator" /> object that can be used to iterate through the objects in the collection.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator" /> object that can be used to iterate through the collection.</returns>
		// Token: 0x060026B3 RID: 9907 RVA: 0x0008C2A8 File Offset: 0x0008A4A8
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new KeyContainerPermissionAccessEntryEnumerator(this);
		}

		/// <summary>Copies the elements of the collection to a compatible one-dimensional array, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional array that is the destination of the elements copied from the current collection.</param>
		/// <param name="index">The index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the collection is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x060026B4 RID: 9908 RVA: 0x0008C2B0 File Offset: 0x0008A4B0
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (index < 0 || index >= array.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (index + this.Count > array.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			for (int i = 0; i < this.Count; i++)
			{
				array.SetValue(this[i], index);
				index++;
			}
		}

		/// <summary>Copies the elements of the collection to a compatible one-dimensional array, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> array that is the destination of the elements copied from the current collection.</param>
		/// <param name="index">The index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the collection is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x060026B5 RID: 9909 RVA: 0x0008C34A File Offset: 0x0008A54A
		public void CopyTo(KeyContainerPermissionAccessEntry[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}

		/// <summary>Gets a value indicating whether the collection is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="false" /> in all cases.</returns>
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060026B6 RID: 9910 RVA: 0x0008C354 File Offset: 0x0008A554
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the collection.</summary>
		/// <returns>An object that can be used to synchronize access to the collection.</returns>
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060026B7 RID: 9911 RVA: 0x0008C357 File Offset: 0x0008A557
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x04000EB4 RID: 3764
		private ArrayList m_list;

		// Token: 0x04000EB5 RID: 3765
		private KeyContainerPermissionFlags m_globalFlags;
	}
}
