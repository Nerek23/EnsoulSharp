using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides a base implementation of a channel object that exposes a dictionary interface to its properties.</summary>
	// Token: 0x02000824 RID: 2084
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public abstract class BaseChannelObjectWithProperties : IDictionary, ICollection, IEnumerable
	{
		/// <summary>Gets a <see cref="T:System.Collections.IDictionary" /> of the channel properties associated with the channel object.</summary>
		/// <returns>A <see cref="T:System.Collections.IDictionary" /> of the channel properties associated with the channel object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x0600591F RID: 22815 RVA: 0x00138D51 File Offset: 0x00136F51
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				return this;
			}
		}

		/// <summary>When overridden in a derived class, gets or sets the property that is associated with the specified key.</summary>
		/// <param name="key">The key of the property to get or set.</param>
		/// <returns>The property that is associated with the specified key.</returns>
		/// <exception cref="T:System.NotImplementedException">The property is accessed.</exception>
		// Token: 0x17000EEF RID: 3823
		public virtual object this[object key]
		{
			[SecuritySafeCritical]
			get
			{
				return null;
			}
			[SecuritySafeCritical]
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>When overridden in a derived class, gets a <see cref="T:System.Collections.ICollection" /> of keys that the channel object properties are associated with.</summary>
		/// <returns>A <see cref="T:System.Collections.ICollection" /> of keys that the channel object properties are associated with.</returns>
		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x06005922 RID: 22818 RVA: 0x00138D5E File Offset: 0x00136F5E
		public virtual ICollection Keys
		{
			[SecuritySafeCritical]
			get
			{
				return null;
			}
		}

		/// <summary>Gets a <see cref="T:System.Collections.ICollection" /> of the values of the properties associated with the channel object.</summary>
		/// <returns>A <see cref="T:System.Collections.ICollection" /> of the values of the properties associated with the channel object.</returns>
		// Token: 0x17000EF1 RID: 3825
		// (get) Token: 0x06005923 RID: 22819 RVA: 0x00138D64 File Offset: 0x00136F64
		public virtual ICollection Values
		{
			[SecuritySafeCritical]
			get
			{
				ICollection keys = this.Keys;
				if (keys == null)
				{
					return null;
				}
				ArrayList arrayList = new ArrayList();
				foreach (object key in keys)
				{
					arrayList.Add(this[key]);
				}
				return arrayList;
			}
		}

		/// <summary>Returns a value that indicates whether the channel object contains a property that is associated with the specified key.</summary>
		/// <param name="key">The key of the property to look for.</param>
		/// <returns>
		///   <see langword="true" /> if the channel object contains a property associated with the specified key; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005924 RID: 22820 RVA: 0x00138DD0 File Offset: 0x00136FD0
		[SecuritySafeCritical]
		public virtual bool Contains(object key)
		{
			if (key == null)
			{
				return false;
			}
			ICollection keys = this.Keys;
			if (keys == null)
			{
				return false;
			}
			string text = key as string;
			foreach (object obj in keys)
			{
				if (text != null)
				{
					string text2 = obj as string;
					if (text2 != null)
					{
						if (string.Compare(text, text2, StringComparison.OrdinalIgnoreCase) == 0)
						{
							return true;
						}
						continue;
					}
				}
				if (key.Equals(obj))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets a value that indicates whether the collection of properties in the channel object is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the collection of properties in the channel object is read-only; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000EF2 RID: 3826
		// (get) Token: 0x06005925 RID: 22821 RVA: 0x00138E64 File Offset: 0x00137064
		public virtual bool IsReadOnly
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value that indicates whether the number of properties that can be entered into the channel object is fixed.</summary>
		/// <returns>
		///   <see langword="true" /> if the number of properties that can be entered into the channel object is fixed; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000EF3 RID: 3827
		// (get) Token: 0x06005926 RID: 22822 RVA: 0x00138E67 File Offset: 0x00137067
		public virtual bool IsFixedSize
		{
			[SecuritySafeCritical]
			get
			{
				return true;
			}
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="key">The key that is associated with the object in the <paramref name="value" /> parameter.</param>
		/// <param name="value">The value to add.</param>
		/// <exception cref="T:System.NotSupportedException">The method is called.</exception>
		// Token: 0x06005927 RID: 22823 RVA: 0x00138E6A File Offset: 0x0013706A
		[SecuritySafeCritical]
		public virtual void Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" />.</summary>
		/// <exception cref="T:System.NotSupportedException">The method is called.</exception>
		// Token: 0x06005928 RID: 22824 RVA: 0x00138E71 File Offset: 0x00137071
		[SecuritySafeCritical]
		public virtual void Clear()
		{
			throw new NotSupportedException();
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="key">The key of the object to be removed.</param>
		/// <exception cref="T:System.NotSupportedException">The method is called.</exception>
		// Token: 0x06005929 RID: 22825 RVA: 0x00138E78 File Offset: 0x00137078
		[SecuritySafeCritical]
		public virtual void Remove(object key)
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns a <see cref="T:System.Collections.IDictionaryEnumerator" /> that enumerates over all the properties associated with the channel object.</summary>
		/// <returns>A <see cref="T:System.Collections.IDictionaryEnumerator" /> that enumerates over all the properties associated with the channel object.</returns>
		// Token: 0x0600592A RID: 22826 RVA: 0x00138E7F File Offset: 0x0013707F
		[SecuritySafeCritical]
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="array">The array to copy the properties to.</param>
		/// <param name="index">The index at which to begin copying.</param>
		/// <exception cref="T:System.NotSupportedException">The method is called.</exception>
		// Token: 0x0600592B RID: 22827 RVA: 0x00138E87 File Offset: 0x00137087
		[SecuritySafeCritical]
		public virtual void CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		/// <summary>Gets the number of properties associated with the channel object.</summary>
		/// <returns>The number of properties associated with the channel object.</returns>
		// Token: 0x17000EF4 RID: 3828
		// (get) Token: 0x0600592C RID: 22828 RVA: 0x00138E90 File Offset: 0x00137090
		public virtual int Count
		{
			[SecuritySafeCritical]
			get
			{
				ICollection keys = this.Keys;
				if (keys == null)
				{
					return 0;
				}
				return keys.Count;
			}
		}

		/// <summary>Gets an object that is used to synchronize access to the <see cref="T:System.Runtime.Remoting.Channels.BaseChannelObjectWithProperties" />.</summary>
		/// <returns>An object that is used to synchronize access to the <see cref="T:System.Runtime.Remoting.Channels.BaseChannelObjectWithProperties" />.</returns>
		// Token: 0x17000EF5 RID: 3829
		// (get) Token: 0x0600592D RID: 22829 RVA: 0x00138EAF File Offset: 0x001370AF
		public virtual object SyncRoot
		{
			[SecuritySafeCritical]
			get
			{
				return this;
			}
		}

		/// <summary>Gets a value that indicates whether the dictionary of channel object properties is synchronized.</summary>
		/// <returns>
		///   <see langword="true" /> if the dictionary of channel object properties is synchronized; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000EF6 RID: 3830
		// (get) Token: 0x0600592E RID: 22830 RVA: 0x00138EB2 File Offset: 0x001370B2
		public virtual bool IsSynchronized
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		/// <summary>Returns a <see cref="T:System.Collections.IEnumerator" /> that enumerates over all the properties that are associated with the channel object.</summary>
		/// <returns>A <see cref="T:System.Collections.IEnumerator" /> that enumerates over all the properties that are associated with the channel object.</returns>
		// Token: 0x0600592F RID: 22831 RVA: 0x00138EB5 File Offset: 0x001370B5
		[SecuritySafeCritical]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}
	}
}
