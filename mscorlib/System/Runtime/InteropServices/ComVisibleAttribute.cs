using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Controls accessibility of an individual managed type or member, or of all types within an assembly, to COM.</summary>
	// Token: 0x020008EB RID: 2283
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComVisibleAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see langword="ComVisibleAttribute" /> class.</summary>
		/// <param name="visibility">
		///   <see langword="true" /> to indicate that the type is visible to COM; otherwise, <see langword="false" />. The default is <see langword="true" />.</param>
		// Token: 0x06005EE2 RID: 24290 RVA: 0x00146B9D File Offset: 0x00144D9D
		[__DynamicallyInvokable]
		public ComVisibleAttribute(bool visibility)
		{
			this._val = visibility;
		}

		/// <summary>Gets a value that indicates whether the COM type is visible.</summary>
		/// <returns>
		///   <see langword="true" /> if the type is visible; otherwise, <see langword="false" />. The default value is <see langword="true" />.</returns>
		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x06005EE3 RID: 24291 RVA: 0x00146BAC File Offset: 0x00144DAC
		[__DynamicallyInvokable]
		public bool Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029B6 RID: 10678
		internal bool _val;
	}
}
