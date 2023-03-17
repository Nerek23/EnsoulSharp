using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that a class should be treated as if it has global scope.</summary>
	// Token: 0x02000888 RID: 2184
	[AttributeUsage(AttributeTargets.Class)]
	[ComVisible(true)]
	[Serializable]
	public class CompilerGlobalScopeAttribute : Attribute
	{
	}
}
