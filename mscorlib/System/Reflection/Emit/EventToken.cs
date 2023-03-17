using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Represents the <see langword="Token" /> returned by the metadata to represent an event.</summary>
	// Token: 0x0200060D RID: 1549
	[ComVisible(true)]
	[Serializable]
	public struct EventToken
	{
		// Token: 0x06004951 RID: 18769 RVA: 0x00108AF1 File Offset: 0x00106CF1
		internal EventToken(int str)
		{
			this.m_event = str;
		}

		/// <summary>Retrieves the metadata token for this event.</summary>
		/// <returns>Read-only. Retrieves the metadata token for this event.</returns>
		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x06004952 RID: 18770 RVA: 0x00108AFA File Offset: 0x00106CFA
		public int Token
		{
			get
			{
				return this.m_event;
			}
		}

		/// <summary>Generates the hash code for this event.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x06004953 RID: 18771 RVA: 0x00108B02 File Offset: 0x00106D02
		public override int GetHashCode()
		{
			return this.m_event;
		}

		/// <summary>Checks if the given object is an instance of <see langword="EventToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to be compared with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="EventToken" /> and equals the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004954 RID: 18772 RVA: 0x00108B0A File Offset: 0x00106D0A
		public override bool Equals(object obj)
		{
			return obj is EventToken && this.Equals((EventToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.EventToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.EventToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004955 RID: 18773 RVA: 0x00108B22 File Offset: 0x00106D22
		public bool Equals(EventToken obj)
		{
			return obj.m_event == this.m_event;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.EventToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.EventToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.EventToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004956 RID: 18774 RVA: 0x00108B32 File Offset: 0x00106D32
		public static bool operator ==(EventToken a, EventToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.EventToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.EventToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.EventToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004957 RID: 18775 RVA: 0x00108B3C File Offset: 0x00106D3C
		public static bool operator !=(EventToken a, EventToken b)
		{
			return !(a == b);
		}

		/// <summary>The default <see langword="EventToken" /> with <see cref="P:System.Reflection.Emit.EventToken.Token" /> value 0.</summary>
		// Token: 0x04001DF8 RID: 7672
		public static readonly EventToken Empty;

		// Token: 0x04001DF9 RID: 7673
		internal int m_event;
	}
}
