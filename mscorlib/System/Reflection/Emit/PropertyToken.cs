using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>The <see langword="PropertyToken" /> struct is an opaque representation of the <see langword="Token" /> returned by the metadata to represent a property.</summary>
	// Token: 0x02000631 RID: 1585
	[ComVisible(true)]
	[Serializable]
	public struct PropertyToken
	{
		// Token: 0x06004BD3 RID: 19411 RVA: 0x001128EC File Offset: 0x00110AEC
		internal PropertyToken(int str)
		{
			this.m_property = str;
		}

		/// <summary>Retrieves the metadata token for this property.</summary>
		/// <returns>Read-only. Retrieves the metadata token for this instance.</returns>
		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x06004BD4 RID: 19412 RVA: 0x001128F5 File Offset: 0x00110AF5
		public int Token
		{
			get
			{
				return this.m_property;
			}
		}

		/// <summary>Generates the hash code for this property.</summary>
		/// <returns>The hash code for this property.</returns>
		// Token: 0x06004BD5 RID: 19413 RVA: 0x001128FD File Offset: 0x00110AFD
		public override int GetHashCode()
		{
			return this.m_property;
		}

		/// <summary>Checks if the given object is an instance of <see langword="PropertyToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to this object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="PropertyToken" /> and equals the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BD6 RID: 19414 RVA: 0x00112905 File Offset: 0x00110B05
		public override bool Equals(object obj)
		{
			return obj is PropertyToken && this.Equals((PropertyToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.PropertyToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.PropertyToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BD7 RID: 19415 RVA: 0x0011291D File Offset: 0x00110B1D
		public bool Equals(PropertyToken obj)
		{
			return obj.m_property == this.m_property;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.PropertyToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.PropertyToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.PropertyToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BD8 RID: 19416 RVA: 0x0011292D File Offset: 0x00110B2D
		public static bool operator ==(PropertyToken a, PropertyToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.PropertyToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.PropertyToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.PropertyToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BD9 RID: 19417 RVA: 0x00112937 File Offset: 0x00110B37
		public static bool operator !=(PropertyToken a, PropertyToken b)
		{
			return !(a == b);
		}

		/// <summary>The default <see langword="PropertyToken" /> with <see cref="P:System.Reflection.Emit.PropertyToken.Token" /> value 0.</summary>
		// Token: 0x040020E0 RID: 8416
		public static readonly PropertyToken Empty;

		// Token: 0x040020E1 RID: 8417
		internal int m_property;
	}
}
