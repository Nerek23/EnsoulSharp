using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the value of the <see cref="T:System.Runtime.InteropServices.CharSet" /> enumeration. This class cannot be inherited.</summary>
	// Token: 0x02000912 RID: 2322
	[AttributeUsage(AttributeTargets.Module, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DefaultCharSetAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.DefaultCharSetAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.CharSet" /> value.</summary>
		/// <param name="charSet">One of the <see cref="T:System.Runtime.InteropServices.CharSet" /> values.</param>
		// Token: 0x06005F42 RID: 24386 RVA: 0x00147480 File Offset: 0x00145680
		[__DynamicallyInvokable]
		public DefaultCharSetAttribute(CharSet charSet)
		{
			this._CharSet = charSet;
		}

		/// <summary>Gets the default value of <see cref="T:System.Runtime.InteropServices.CharSet" /> for any call to <see cref="T:System.Runtime.InteropServices.DllImportAttribute" />.</summary>
		/// <returns>The default value of <see cref="T:System.Runtime.InteropServices.CharSet" /> for any call to <see cref="T:System.Runtime.InteropServices.DllImportAttribute" />.</returns>
		// Token: 0x170010DC RID: 4316
		// (get) Token: 0x06005F43 RID: 24387 RVA: 0x0014748F File Offset: 0x0014568F
		[__DynamicallyInvokable]
		public CharSet CharSet
		{
			[__DynamicallyInvokable]
			get
			{
				return this._CharSet;
			}
		}

		// Token: 0x04002A75 RID: 10869
		internal CharSet _CharSet;
	}
}
