using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines the member of a type that is the default member used by <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])" />.</summary>
	// Token: 0x020005B3 RID: 1459
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DefaultMemberAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.DefaultMemberAttribute" /> class.</summary>
		/// <param name="memberName">A <see langword="String" /> containing the name of the member to invoke. This may be a constructor, method, property, or field. A suitable invocation attribute must be specified when the member is invoked. The default member of a class can be specified by passing an empty <see langword="String" /> as the name of the member.  
		///  The default member of a type is marked with the <see langword="DefaultMemberAttribute" /> custom attribute or marked in COM in the usual way.</param>
		// Token: 0x06004493 RID: 17555 RVA: 0x000FC7FA File Offset: 0x000FA9FA
		[__DynamicallyInvokable]
		public DefaultMemberAttribute(string memberName)
		{
			this.m_memberName = memberName;
		}

		/// <summary>Gets the name from the attribute.</summary>
		/// <returns>A string representing the member name.</returns>
		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06004494 RID: 17556 RVA: 0x000FC809 File Offset: 0x000FAA09
		[__DynamicallyInvokable]
		public string MemberName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_memberName;
			}
		}

		// Token: 0x04001BD8 RID: 7128
		private string m_memberName;
	}
}
