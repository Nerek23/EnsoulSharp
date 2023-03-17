using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides support for type equivalence.</summary>
	// Token: 0x020008E3 RID: 2275
	[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public sealed class TypeIdentifierAttribute : Attribute
	{
		/// <summary>Creates a new instance of the <see cref="T:System.Runtime.InteropServices.TypeIdentifierAttribute" /> class.</summary>
		// Token: 0x06005ED3 RID: 24275 RVA: 0x00146AED File Offset: 0x00144CED
		[__DynamicallyInvokable]
		public TypeIdentifierAttribute()
		{
		}

		/// <summary>Creates a new instance of the <see cref="T:System.Runtime.InteropServices.TypeIdentifierAttribute" /> class with the specified scope and identifier.</summary>
		/// <param name="scope">The first type equivalence string.</param>
		/// <param name="identifier">The second type equivalence string.</param>
		// Token: 0x06005ED4 RID: 24276 RVA: 0x00146AF5 File Offset: 0x00144CF5
		[__DynamicallyInvokable]
		public TypeIdentifierAttribute(string scope, string identifier)
		{
			this.Scope_ = scope;
			this.Identifier_ = identifier;
		}

		/// <summary>Gets the value of the <paramref name="scope" /> parameter that was passed to the <see cref="M:System.Runtime.InteropServices.TypeIdentifierAttribute.#ctor(System.String,System.String)" /> constructor.</summary>
		/// <returns>The value of the constructor's <paramref name="scope" /> parameter.</returns>
		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x06005ED5 RID: 24277 RVA: 0x00146B0B File Offset: 0x00144D0B
		[__DynamicallyInvokable]
		public string Scope
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Scope_;
			}
		}

		/// <summary>Gets the value of the <paramref name="identifier" /> parameter that was passed to the <see cref="M:System.Runtime.InteropServices.TypeIdentifierAttribute.#ctor(System.String,System.String)" /> constructor.</summary>
		/// <returns>The value of the constructor's <paramref name="identifier" /> parameter.</returns>
		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x06005ED6 RID: 24278 RVA: 0x00146B13 File Offset: 0x00144D13
		[__DynamicallyInvokable]
		public string Identifier
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Identifier_;
			}
		}

		// Token: 0x040029A7 RID: 10663
		internal string Scope_;

		// Token: 0x040029A8 RID: 10664
		internal string Identifier_;
	}
}
