using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Encapsulates an array and an offset within the specified array.</summary>
	// Token: 0x020008E1 RID: 2273
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct ArrayWithOffset
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> structure.</summary>
		/// <param name="array">A managed array.</param>
		/// <param name="offset">The offset in bytes, of the element to be passed through platform invoke.</param>
		/// <exception cref="T:System.ArgumentException">The array is larger than 2 gigabytes (GB).</exception>
		// Token: 0x06005EC8 RID: 24264 RVA: 0x00146A38 File Offset: 0x00144C38
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public ArrayWithOffset(object array, int offset)
		{
			this.m_array = array;
			this.m_offset = offset;
			this.m_count = 0;
			this.m_count = this.CalculateCount();
		}

		/// <summary>Returns the managed array referenced by this <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" />.</summary>
		/// <returns>The managed array this instance references.</returns>
		// Token: 0x06005EC9 RID: 24265 RVA: 0x00146A5B File Offset: 0x00144C5B
		[__DynamicallyInvokable]
		public object GetArray()
		{
			return this.m_array;
		}

		/// <summary>Returns the offset provided when this <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> was constructed.</summary>
		/// <returns>The offset for this instance.</returns>
		// Token: 0x06005ECA RID: 24266 RVA: 0x00146A63 File Offset: 0x00144C63
		[__DynamicallyInvokable]
		public int GetOffset()
		{
			return this.m_offset;
		}

		/// <summary>Returns a hash code for this value type.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x06005ECB RID: 24267 RVA: 0x00146A6B File Offset: 0x00144C6B
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_count + this.m_offset;
		}

		/// <summary>Indicates whether the specified object matches the current <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object.</summary>
		/// <param name="obj">Object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the object matches this <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005ECC RID: 24268 RVA: 0x00146A7A File Offset: 0x00144C7A
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is ArrayWithOffset && this.Equals((ArrayWithOffset)obj);
		}

		/// <summary>Indicates whether the specified <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object matches the current instance.</summary>
		/// <param name="obj">An <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object matches the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005ECD RID: 24269 RVA: 0x00146A92 File Offset: 0x00144C92
		[__DynamicallyInvokable]
		public bool Equals(ArrayWithOffset obj)
		{
			return obj.m_array == this.m_array && obj.m_offset == this.m_offset && obj.m_count == this.m_count;
		}

		/// <summary>Determines whether two specified <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> objects have the same value.</summary>
		/// <param name="a">An <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object to compare with the <paramref name="b" /> parameter.</param>
		/// <param name="b">An <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object to compare with the <paramref name="a" /> parameter.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005ECE RID: 24270 RVA: 0x00146AC0 File Offset: 0x00144CC0
		[__DynamicallyInvokable]
		public static bool operator ==(ArrayWithOffset a, ArrayWithOffset b)
		{
			return a.Equals(b);
		}

		/// <summary>Determines whether two specified <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> objects no not have the same value.</summary>
		/// <param name="a">An <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object to compare with the <paramref name="b" /> parameter.</param>
		/// <param name="b">An <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object to compare with the <paramref name="a" /> parameter.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="a" /> is not the same as the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005ECF RID: 24271 RVA: 0x00146ACA File Offset: 0x00144CCA
		[__DynamicallyInvokable]
		public static bool operator !=(ArrayWithOffset a, ArrayWithOffset b)
		{
			return !(a == b);
		}

		// Token: 0x06005ED0 RID: 24272
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int CalculateCount();

		// Token: 0x0400299F RID: 10655
		private object m_array;

		// Token: 0x040029A0 RID: 10656
		private int m_offset;

		// Token: 0x040029A1 RID: 10657
		private int m_count;
	}
}
