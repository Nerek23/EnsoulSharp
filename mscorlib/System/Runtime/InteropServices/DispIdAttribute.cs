using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the COM dispatch identifier (DISPID) of a method, field, or property.</summary>
	// Token: 0x020008E5 RID: 2277
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DispIdAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see langword="DispIdAttribute" /> class with the specified DISPID.</summary>
		/// <param name="dispId">The DISPID for the member.</param>
		// Token: 0x06005ED8 RID: 24280 RVA: 0x00146B23 File Offset: 0x00144D23
		[__DynamicallyInvokable]
		public DispIdAttribute(int dispId)
		{
			this._val = dispId;
		}

		/// <summary>Gets the DISPID for the member.</summary>
		/// <returns>The DISPID for the member.</returns>
		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x06005ED9 RID: 24281 RVA: 0x00146B32 File Offset: 0x00144D32
		[__DynamicallyInvokable]
		public int Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029A9 RID: 10665
		internal int _val;
	}
}
