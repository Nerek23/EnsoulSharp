using System;
using System.Configuration.Assemblies;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies an algorithm to hash all files in an assembly. This class cannot be inherited.</summary>
	// Token: 0x02000595 RID: 1429
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class AssemblyAlgorithmIdAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyAlgorithmIdAttribute" /> class with the specified hash algorithm, using one of the members of <see cref="T:System.Configuration.Assemblies.AssemblyHashAlgorithm" /> to represent the hash algorithm.</summary>
		/// <param name="algorithmId">A member of <see langword="AssemblyHashAlgorithm" /> that represents the hash algorithm.</param>
		// Token: 0x0600434E RID: 17230 RVA: 0x000F7AB9 File Offset: 0x000F5CB9
		public AssemblyAlgorithmIdAttribute(AssemblyHashAlgorithm algorithmId)
		{
			this.m_algId = (uint)algorithmId;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyAlgorithmIdAttribute" /> class with the specified hash algorithm, using an unsigned integer to represent the hash algorithm.</summary>
		/// <param name="algorithmId">An unsigned integer representing the hash algorithm.</param>
		// Token: 0x0600434F RID: 17231 RVA: 0x000F7AC8 File Offset: 0x000F5CC8
		[CLSCompliant(false)]
		public AssemblyAlgorithmIdAttribute(uint algorithmId)
		{
			this.m_algId = algorithmId;
		}

		/// <summary>Gets the hash algorithm of an assembly manifest's contents.</summary>
		/// <returns>An unsigned integer representing the assembly hash algorithm.</returns>
		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06004350 RID: 17232 RVA: 0x000F7AD7 File Offset: 0x000F5CD7
		[CLSCompliant(false)]
		public uint AlgorithmId
		{
			get
			{
				return this.m_algId;
			}
		}

		// Token: 0x04001B50 RID: 6992
		private uint m_algId;
	}
}
