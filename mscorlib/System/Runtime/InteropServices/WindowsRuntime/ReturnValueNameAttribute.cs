using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>Specifies the name of the return value of a method in a Windows Runtime component.</summary>
	// Token: 0x0200099E RID: 2462
	[AttributeUsage(AttributeTargets.Delegate | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class ReturnValueNameAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.ReturnValueNameAttribute" /> class, and specifies the name of the return value.</summary>
		/// <param name="name">The name of the return value.</param>
		// Token: 0x060062AE RID: 25262 RVA: 0x0014FE0F File Offset: 0x0014E00F
		[__DynamicallyInvokable]
		public ReturnValueNameAttribute(string name)
		{
			this.m_Name = name;
		}

		/// <summary>Gets the name that was specified for the return value of a method in a Windows Runtime component.</summary>
		/// <returns>The name of the method's return value.</returns>
		// Token: 0x17001128 RID: 4392
		// (get) Token: 0x060062AF RID: 25263 RVA: 0x0014FE1E File Offset: 0x0014E01E
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x04002C25 RID: 11301
		private string m_Name;
	}
}
