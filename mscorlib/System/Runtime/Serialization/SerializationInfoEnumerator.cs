using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Provides a formatter-friendly mechanism for parsing the data in <see cref="T:System.Runtime.Serialization.SerializationInfo" />. This class cannot be inherited.</summary>
	// Token: 0x02000716 RID: 1814
	[ComVisible(true)]
	public sealed class SerializationInfoEnumerator : IEnumerator
	{
		// Token: 0x06005107 RID: 20743 RVA: 0x0011C039 File Offset: 0x0011A239
		internal SerializationInfoEnumerator(string[] members, object[] info, Type[] types, int numItems)
		{
			this.m_members = members;
			this.m_data = info;
			this.m_types = types;
			this.m_numItems = numItems - 1;
			this.m_currItem = -1;
			this.m_current = false;
		}

		/// <summary>Updates the enumerator to the next item.</summary>
		/// <returns>
		///   <see langword="true" /> if a new element is found; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005108 RID: 20744 RVA: 0x0011C06E File Offset: 0x0011A26E
		public bool MoveNext()
		{
			if (this.m_currItem < this.m_numItems)
			{
				this.m_currItem++;
				this.m_current = true;
			}
			else
			{
				this.m_current = false;
			}
			return this.m_current;
		}

		/// <summary>Gets the current item in the collection.</summary>
		/// <returns>A <see cref="T:System.Runtime.Serialization.SerializationEntry" /> that contains the current serialization data.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enumeration has not started or has already ended.</exception>
		// Token: 0x17000D73 RID: 3443
		// (get) Token: 0x06005109 RID: 20745 RVA: 0x0011C0A4 File Offset: 0x0011A2A4
		object IEnumerator.Current
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return new SerializationEntry(this.m_members[this.m_currItem], this.m_data[this.m_currItem], this.m_types[this.m_currItem]);
			}
		}

		/// <summary>Gets the item currently being examined.</summary>
		/// <returns>The item currently being examined.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enumerator has not started enumerating items or has reached the end of the enumeration.</exception>
		// Token: 0x17000D74 RID: 3444
		// (get) Token: 0x0600510A RID: 20746 RVA: 0x0011C0FC File Offset: 0x0011A2FC
		public SerializationEntry Current
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return new SerializationEntry(this.m_members[this.m_currItem], this.m_data[this.m_currItem], this.m_types[this.m_currItem]);
			}
		}

		/// <summary>Resets the enumerator to the first item.</summary>
		// Token: 0x0600510B RID: 20747 RVA: 0x0011C14D File Offset: 0x0011A34D
		public void Reset()
		{
			this.m_currItem = -1;
			this.m_current = false;
		}

		/// <summary>Gets the name for the item currently being examined.</summary>
		/// <returns>The item name.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enumerator has not started enumerating items or has reached the end of the enumeration.</exception>
		// Token: 0x17000D75 RID: 3445
		// (get) Token: 0x0600510C RID: 20748 RVA: 0x0011C15D File Offset: 0x0011A35D
		public string Name
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_members[this.m_currItem];
			}
		}

		/// <summary>Gets the value of the item currently being examined.</summary>
		/// <returns>The value of the item currently being examined.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enumerator has not started enumerating items or has reached the end of the enumeration.</exception>
		// Token: 0x17000D76 RID: 3446
		// (get) Token: 0x0600510D RID: 20749 RVA: 0x0011C184 File Offset: 0x0011A384
		public object Value
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_data[this.m_currItem];
			}
		}

		/// <summary>Gets the type of the item currently being examined.</summary>
		/// <returns>The type of the item currently being examined.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enumerator has not started enumerating items or has reached the end of the enumeration.</exception>
		// Token: 0x17000D77 RID: 3447
		// (get) Token: 0x0600510E RID: 20750 RVA: 0x0011C1AB File Offset: 0x0011A3AB
		public Type ObjectType
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_types[this.m_currItem];
			}
		}

		// Token: 0x040023A0 RID: 9120
		private string[] m_members;

		// Token: 0x040023A1 RID: 9121
		private object[] m_data;

		// Token: 0x040023A2 RID: 9122
		private Type[] m_types;

		// Token: 0x040023A3 RID: 9123
		private int m_numItems;

		// Token: 0x040023A4 RID: 9124
		private int m_currItem;

		// Token: 0x040023A5 RID: 9125
		private bool m_current;
	}
}
