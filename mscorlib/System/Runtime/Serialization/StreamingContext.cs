using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</summary>
	// Token: 0x02000717 RID: 1815
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct StreamingContext
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.StreamingContext" /> class with a given context state.</summary>
		/// <param name="state">A bitwise combination of the <see cref="T:System.Runtime.Serialization.StreamingContextStates" /> values that specify the source or destination context for this <see cref="T:System.Runtime.Serialization.StreamingContext" />.</param>
		// Token: 0x0600510F RID: 20751 RVA: 0x0011C1D2 File Offset: 0x0011A3D2
		public StreamingContext(StreamingContextStates state)
		{
			this = new StreamingContext(state, null);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.StreamingContext" /> class with a given context state, and some additional information.</summary>
		/// <param name="state">A bitwise combination of the <see cref="T:System.Runtime.Serialization.StreamingContextStates" /> values that specify the source or destination context for this <see cref="T:System.Runtime.Serialization.StreamingContext" />.</param>
		/// <param name="additional">Any additional information to be associated with the <see cref="T:System.Runtime.Serialization.StreamingContext" />. This information is available to any object that implements <see cref="T:System.Runtime.Serialization.ISerializable" /> or any serialization surrogate. Most users do not need to set this parameter.</param>
		// Token: 0x06005110 RID: 20752 RVA: 0x0011C1DC File Offset: 0x0011A3DC
		public StreamingContext(StreamingContextStates state, object additional)
		{
			this.m_state = state;
			this.m_additionalContext = additional;
		}

		/// <summary>Gets context specified as part of the additional context.</summary>
		/// <returns>The context specified as part of the additional context.</returns>
		// Token: 0x17000D78 RID: 3448
		// (get) Token: 0x06005111 RID: 20753 RVA: 0x0011C1EC File Offset: 0x0011A3EC
		public object Context
		{
			get
			{
				return this.m_additionalContext;
			}
		}

		/// <summary>Determines whether two <see cref="T:System.Runtime.Serialization.StreamingContext" /> instances contain the same values.</summary>
		/// <param name="obj">An object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the specified object is an instance of <see cref="T:System.Runtime.Serialization.StreamingContext" /> and equals the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005112 RID: 20754 RVA: 0x0011C1F4 File Offset: 0x0011A3F4
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is StreamingContext && (((StreamingContext)obj).m_additionalContext == this.m_additionalContext && ((StreamingContext)obj).m_state == this.m_state);
		}

		/// <summary>Returns a hash code of this object.</summary>
		/// <returns>The <see cref="T:System.Runtime.Serialization.StreamingContextStates" /> value that contains the source or destination of the serialization for this <see cref="T:System.Runtime.Serialization.StreamingContext" />.</returns>
		// Token: 0x06005113 RID: 20755 RVA: 0x0011C229 File Offset: 0x0011A429
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return (int)this.m_state;
		}

		/// <summary>Gets the source or destination of the transmitted data.</summary>
		/// <returns>During serialization, the destination of the transmitted data. During deserialization, the source of the data.</returns>
		// Token: 0x17000D79 RID: 3449
		// (get) Token: 0x06005114 RID: 20756 RVA: 0x0011C231 File Offset: 0x0011A431
		public StreamingContextStates State
		{
			get
			{
				return this.m_state;
			}
		}

		// Token: 0x040023A6 RID: 9126
		internal object m_additionalContext;

		// Token: 0x040023A7 RID: 9127
		internal StreamingContextStates m_state;
	}
}
