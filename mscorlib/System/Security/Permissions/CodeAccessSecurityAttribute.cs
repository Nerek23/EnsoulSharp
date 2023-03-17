using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the base attribute class for code access security.</summary>
	// Token: 0x020002C3 RID: 707
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class CodeAccessSecurityAttribute : SecurityAttribute
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Permissions.CodeAccessSecurityAttribute" /> with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x0600253C RID: 9532 RVA: 0x00087933 File Offset: 0x00085B33
		protected CodeAccessSecurityAttribute(SecurityAction action) : base(action)
		{
		}
	}
}
