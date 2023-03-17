using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Wraps objects the marshaler should marshal as a <see langword="VT_UNKNOWN" />.</summary>
	// Token: 0x02000933 RID: 2355
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class UnknownWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.UnknownWrapper" /> class with the object to be wrapped.</summary>
		/// <param name="obj">The object being wrapped.</param>
		// Token: 0x06006103 RID: 24835 RVA: 0x0014AC1F File Offset: 0x00148E1F
		[__DynamicallyInvokable]
		public UnknownWrapper(object obj)
		{
			this.m_WrappedObject = obj;
		}

		/// <summary>Gets the object contained by this wrapper.</summary>
		/// <returns>The wrapped object.</returns>
		// Token: 0x170010FD RID: 4349
		// (get) Token: 0x06006104 RID: 24836 RVA: 0x0014AC2E File Offset: 0x00148E2E
		[__DynamicallyInvokable]
		public object WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002AD4 RID: 10964
		private object m_WrappedObject;
	}
}
