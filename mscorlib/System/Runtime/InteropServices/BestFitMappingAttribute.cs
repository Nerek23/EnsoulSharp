using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Controls whether Unicode characters are converted to the closest matching ANSI characters.</summary>
	// Token: 0x02000911 RID: 2321
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class BestFitMappingAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.BestFitMappingAttribute" /> class set to the value of the <see cref="P:System.Runtime.InteropServices.BestFitMappingAttribute.BestFitMapping" /> property.</summary>
		/// <param name="BestFitMapping">
		///   <see langword="true" /> to indicate that best-fit mapping is enabled; otherwise, <see langword="false" />. The default is <see langword="true" />.</param>
		// Token: 0x06005F40 RID: 24384 RVA: 0x00147469 File Offset: 0x00145669
		[__DynamicallyInvokable]
		public BestFitMappingAttribute(bool BestFitMapping)
		{
			this._bestFitMapping = BestFitMapping;
		}

		/// <summary>Gets the best-fit mapping behavior when converting Unicode characters to ANSI characters.</summary>
		/// <returns>
		///   <see langword="true" /> if best-fit mapping is enabled; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x170010DB RID: 4315
		// (get) Token: 0x06005F41 RID: 24385 RVA: 0x00147478 File Offset: 0x00145678
		[__DynamicallyInvokable]
		public bool BestFitMapping
		{
			[__DynamicallyInvokable]
			get
			{
				return this._bestFitMapping;
			}
		}

		// Token: 0x04002A73 RID: 10867
		internal bool _bestFitMapping;

		/// <summary>Enables or disables the throwing of an exception on an unmappable Unicode character that is converted to an ANSI '?' character.</summary>
		// Token: 0x04002A74 RID: 10868
		[__DynamicallyInvokable]
		public bool ThrowOnUnmappableChar;
	}
}
