using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates when a dependency is to be loaded by the referring assembly. This class cannot be inherited.</summary>
	// Token: 0x02000898 RID: 2200
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Serializable]
	public sealed class DependencyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.DependencyAttribute" /> class with the specified <see cref="T:System.Runtime.CompilerServices.LoadHint" /> value.</summary>
		/// <param name="dependentAssemblyArgument">The dependent assembly to bind to.</param>
		/// <param name="loadHintArgument">One of the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> values.</param>
		// Token: 0x06005CA2 RID: 23714 RVA: 0x00144D86 File Offset: 0x00142F86
		public DependencyAttribute(string dependentAssemblyArgument, LoadHint loadHintArgument)
		{
			this.dependentAssembly = dependentAssemblyArgument;
			this.loadHint = loadHintArgument;
		}

		/// <summary>Gets the value of the dependent assembly.</summary>
		/// <returns>The name of the dependent assembly.</returns>
		// Token: 0x17001004 RID: 4100
		// (get) Token: 0x06005CA3 RID: 23715 RVA: 0x00144D9C File Offset: 0x00142F9C
		public string DependentAssembly
		{
			get
			{
				return this.dependentAssembly;
			}
		}

		/// <summary>Gets the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> value that indicates when an assembly is to load a dependency.</summary>
		/// <returns>One of the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> values.</returns>
		// Token: 0x17001005 RID: 4101
		// (get) Token: 0x06005CA4 RID: 23716 RVA: 0x00144DA4 File Offset: 0x00142FA4
		public LoadHint LoadHint
		{
			get
			{
				return this.loadHint;
			}
		}

		// Token: 0x04002976 RID: 10614
		private string dependentAssembly;

		// Token: 0x04002977 RID: 10615
		private LoadHint loadHint;
	}
}
