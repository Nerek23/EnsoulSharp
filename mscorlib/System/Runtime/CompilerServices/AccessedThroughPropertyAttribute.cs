using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies the name of the property that accesses the attributed field.</summary>
	// Token: 0x02000875 RID: 2165
	[AttributeUsage(AttributeTargets.Field)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AccessedThroughPropertyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see langword="AccessedThroughPropertyAttribute" /> class with the name of the property used to access the attributed field.</summary>
		/// <param name="propertyName">The name of the property used to access the attributed field.</param>
		// Token: 0x06005C5B RID: 23643 RVA: 0x001447FE File Offset: 0x001429FE
		[__DynamicallyInvokable]
		public AccessedThroughPropertyAttribute(string propertyName)
		{
			this.propertyName = propertyName;
		}

		/// <summary>Gets the name of the property used to access the attributed field.</summary>
		/// <returns>The name of the property used to access the attributed field.</returns>
		// Token: 0x17000FF7 RID: 4087
		// (get) Token: 0x06005C5C RID: 23644 RVA: 0x0014480D File Offset: 0x00142A0D
		[__DynamicallyInvokable]
		public string PropertyName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.propertyName;
			}
		}

		// Token: 0x04002954 RID: 10580
		private readonly string propertyName;
	}
}
