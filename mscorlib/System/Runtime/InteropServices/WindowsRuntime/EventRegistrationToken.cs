using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>A token that is returned when an event handler is added to a Windows Runtime event. The token is used to remove the event handler from the event at a later time.</summary>
	// Token: 0x020009B3 RID: 2483
	[__DynamicallyInvokable]
	public struct EventRegistrationToken
	{
		// Token: 0x06006354 RID: 25428 RVA: 0x00151B33 File Offset: 0x0014FD33
		internal EventRegistrationToken(ulong value)
		{
			this.m_value = value;
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x06006355 RID: 25429 RVA: 0x00151B3C File Offset: 0x0014FD3C
		internal ulong Value
		{
			get
			{
				return this.m_value;
			}
		}

		/// <summary>Indicates whether two <see cref="T:System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken" /> instances are equal.</summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns>
		///   <see langword="true" /> if the two objects are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006356 RID: 25430 RVA: 0x00151B44 File Offset: 0x0014FD44
		[__DynamicallyInvokable]
		public static bool operator ==(EventRegistrationToken left, EventRegistrationToken right)
		{
			return left.Equals(right);
		}

		/// <summary>Indicates whether two <see cref="T:System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken" /> instances are not equal.</summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns>
		///   <see langword="true" /> if the two instances are not equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006357 RID: 25431 RVA: 0x00151B59 File Offset: 0x0014FD59
		[__DynamicallyInvokable]
		public static bool operator !=(EventRegistrationToken left, EventRegistrationToken right)
		{
			return !left.Equals(right);
		}

		/// <summary>Returns a value that indicates whether the current object is equal to the specified object.</summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to <paramref name="obj" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006358 RID: 25432 RVA: 0x00151B74 File Offset: 0x0014FD74
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is EventRegistrationToken && ((EventRegistrationToken)obj).Value == this.Value;
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x06006359 RID: 25433 RVA: 0x00151BA1 File Offset: 0x0014FDA1
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_value.GetHashCode();
		}

		// Token: 0x04002C34 RID: 11316
		internal ulong m_value;
	}
}
