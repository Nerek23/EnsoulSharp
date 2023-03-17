using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.INVOKEKIND" /> instead.</summary>
	// Token: 0x02000973 RID: 2419
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.INVOKEKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum INVOKEKIND
	{
		/// <summary>The member is called using a normal function invocation syntax.</summary>
		// Token: 0x04002BB0 RID: 11184
		INVOKE_FUNC = 1,
		/// <summary>The function is invoked using a normal property-access syntax.</summary>
		// Token: 0x04002BB1 RID: 11185
		INVOKE_PROPERTYGET,
		/// <summary>The function is invoked using a property value assignment syntax.</summary>
		// Token: 0x04002BB2 RID: 11186
		INVOKE_PROPERTYPUT = 4,
		/// <summary>The function is invoked using a property reference assignment syntax.</summary>
		// Token: 0x04002BB3 RID: 11187
		INVOKE_PROPERTYPUTREF = 8
	}
}
