using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies that an importing compiler must fully understand the semantics of a type definition, or refuse to use it.  This class cannot be inherited.</summary>
	// Token: 0x02000895 RID: 2197
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class RequiredAttributeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.RequiredAttributeAttribute" /> class.</summary>
		/// <param name="requiredContract">A type that an importing compiler must fully understand.  
		///  This parameter is not supported in the .NET Framework version 2.0 and later.</param>
		// Token: 0x06005C9E RID: 23710 RVA: 0x00144D58 File Offset: 0x00142F58
		public RequiredAttributeAttribute(Type requiredContract)
		{
			this.requiredContract = requiredContract;
		}

		/// <summary>Gets a type that an importing compiler must fully understand.</summary>
		/// <returns>A type that an importing compiler must fully understand.</returns>
		// Token: 0x17001002 RID: 4098
		// (get) Token: 0x06005C9F RID: 23711 RVA: 0x00144D67 File Offset: 0x00142F67
		public Type RequiredContract
		{
			get
			{
				return this.requiredContract;
			}
		}

		// Token: 0x04002970 RID: 10608
		private Type requiredContract;
	}
}
