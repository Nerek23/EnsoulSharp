using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates that data should be marshaled from the caller to the callee, but not back to the caller.</summary>
	// Token: 0x02000902 RID: 2306
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class InAttribute : Attribute
	{
		// Token: 0x06005F12 RID: 24338 RVA: 0x00146FB5 File Offset: 0x001451B5
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			if (!parameter.IsIn)
			{
				return null;
			}
			return new InAttribute();
		}

		// Token: 0x06005F13 RID: 24339 RVA: 0x00146FC6 File Offset: 0x001451C6
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return parameter.IsIn;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.InAttribute" /> class.</summary>
		// Token: 0x06005F14 RID: 24340 RVA: 0x00146FCE File Offset: 0x001451CE
		[__DynamicallyInvokable]
		public InAttribute()
		{
		}
	}
}
