using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies that the assembly is not fully signed when created.</summary>
	// Token: 0x02000594 RID: 1428
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyDelaySignAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyDelaySignAttribute" /> class.</summary>
		/// <param name="delaySign">
		///   <see langword="true" /> if the feature this attribute represents is activated; otherwise, <see langword="false" />.</param>
		// Token: 0x0600434C RID: 17228 RVA: 0x000F7AA2 File Offset: 0x000F5CA2
		[__DynamicallyInvokable]
		public AssemblyDelaySignAttribute(bool delaySign)
		{
			this.m_delaySign = delaySign;
		}

		/// <summary>Gets a value indicating the state of the attribute.</summary>
		/// <returns>
		///   <see langword="true" /> if this assembly has been built as delay-signed; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x0600434D RID: 17229 RVA: 0x000F7AB1 File Offset: 0x000F5CB1
		[__DynamicallyInvokable]
		public bool DelaySign
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_delaySign;
			}
		}

		// Token: 0x04001B4F RID: 6991
		private bool m_delaySign;
	}
}
