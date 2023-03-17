using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies the name of a key container within the CSP containing the key pair used to generate a strong name.</summary>
	// Token: 0x02000599 RID: 1433
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyKeyNameAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyKeyNameAttribute" /> class with the name of the container holding the key pair used to generate a strong name for the assembly being attributed.</summary>
		/// <param name="keyName">The name of the container containing the key pair.</param>
		// Token: 0x0600435C RID: 17244 RVA: 0x000F7B68 File Offset: 0x000F5D68
		[__DynamicallyInvokable]
		public AssemblyKeyNameAttribute(string keyName)
		{
			this.m_keyName = keyName;
		}

		/// <summary>Gets the name of the container having the key pair that is used to generate a strong name for the attributed assembly.</summary>
		/// <returns>A string containing the name of the container that has the relevant key pair.</returns>
		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x0600435D RID: 17245 RVA: 0x000F7B77 File Offset: 0x000F5D77
		[__DynamicallyInvokable]
		public string KeyName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_keyName;
			}
		}

		// Token: 0x04001B56 RID: 6998
		private string m_keyName;
	}
}
