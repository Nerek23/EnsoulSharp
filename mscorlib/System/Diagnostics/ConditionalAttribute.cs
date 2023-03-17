using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Indicates to compilers that a method call or attribute should be ignored unless a specified conditional compilation symbol is defined.</summary>
	// Token: 0x020003B8 RID: 952
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ConditionalAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.ConditionalAttribute" /> class.</summary>
		/// <param name="conditionString">A string that specifies the case-sensitive conditional compilation symbol that is associated with the attribute.</param>
		// Token: 0x060031D7 RID: 12759 RVA: 0x000C002E File Offset: 0x000BE22E
		[__DynamicallyInvokable]
		public ConditionalAttribute(string conditionString)
		{
			this.m_conditionString = conditionString;
		}

		/// <summary>Gets the conditional compilation symbol that is associated with the <see cref="T:System.Diagnostics.ConditionalAttribute" /> attribute.</summary>
		/// <returns>A string that specifies the case-sensitive conditional compilation symbol that is associated with the <see cref="T:System.Diagnostics.ConditionalAttribute" /> attribute.</returns>
		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x060031D8 RID: 12760 RVA: 0x000C003D File Offset: 0x000BE23D
		[__DynamicallyInvokable]
		public string ConditionString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_conditionString;
			}
		}

		// Token: 0x040015E4 RID: 5604
		private string m_conditionString;
	}
}
