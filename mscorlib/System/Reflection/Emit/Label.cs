using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Represents a label in the instruction stream. <see langword="Label" /> is used in conjunction with the <see cref="T:System.Reflection.Emit.ILGenerator" /> class.</summary>
	// Token: 0x02000617 RID: 1559
	[ComVisible(true)]
	[Serializable]
	public struct Label
	{
		// Token: 0x060049E6 RID: 18918 RVA: 0x0010B3E4 File Offset: 0x001095E4
		internal Label(int label)
		{
			this.m_label = label;
		}

		// Token: 0x060049E7 RID: 18919 RVA: 0x0010B3ED File Offset: 0x001095ED
		internal int GetLabelValue()
		{
			return this.m_label;
		}

		/// <summary>Generates a hash code for this instance.</summary>
		/// <returns>A hash code for this instance.</returns>
		// Token: 0x060049E8 RID: 18920 RVA: 0x0010B3F5 File Offset: 0x001095F5
		public override int GetHashCode()
		{
			return this.m_label;
		}

		/// <summary>Checks if the given object is an instance of <see langword="Label" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to compare with this <see langword="Label" /> instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="Label" /> and is equal to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060049E9 RID: 18921 RVA: 0x0010B3FD File Offset: 0x001095FD
		public override bool Equals(object obj)
		{
			return obj is Label && this.Equals((Label)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.Label" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.Label" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060049EA RID: 18922 RVA: 0x0010B415 File Offset: 0x00109615
		public bool Equals(Label obj)
		{
			return obj.m_label == this.m_label;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.Label" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.Label" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.Label" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060049EB RID: 18923 RVA: 0x0010B425 File Offset: 0x00109625
		public static bool operator ==(Label a, Label b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.Label" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.Label" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.Label" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060049EC RID: 18924 RVA: 0x0010B42F File Offset: 0x0010962F
		public static bool operator !=(Label a, Label b)
		{
			return !(a == b);
		}

		// Token: 0x04001E4A RID: 7754
		internal int m_label;
	}
}
