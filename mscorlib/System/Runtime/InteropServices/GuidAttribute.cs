using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Supplies an explicit <see cref="T:System.Guid" /> when an automatic GUID is undesirable.</summary>
	// Token: 0x02000900 RID: 2304
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class GuidAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.GuidAttribute" /> class with the specified GUID.</summary>
		/// <param name="guid">The <see cref="T:System.Guid" /> to be assigned.</param>
		// Token: 0x06005F0D RID: 24333 RVA: 0x00146F6E File Offset: 0x0014516E
		[__DynamicallyInvokable]
		public GuidAttribute(string guid)
		{
			this._val = guid;
		}

		/// <summary>Gets the <see cref="T:System.Guid" /> of the class.</summary>
		/// <returns>The <see cref="T:System.Guid" /> of the class.</returns>
		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x06005F0E RID: 24334 RVA: 0x00146F7D File Offset: 0x0014517D
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A4D RID: 10829
		internal string _val;
	}
}
