using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Provides a hint to the common language runtime (CLR) indicating how likely a dependency is to be loaded. This class is used in a dependent assembly to indicate what hint should be used when the parent does not specify the <see cref="T:System.Runtime.CompilerServices.DependencyAttribute" /> attribute.  This class cannot be inherited.</summary>
	// Token: 0x02000897 RID: 2199
	[AttributeUsage(AttributeTargets.Assembly)]
	[Serializable]
	public sealed class DefaultDependencyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.DefaultDependencyAttribute" /> class with the specified <see cref="T:System.Runtime.CompilerServices.LoadHint" /> binding.</summary>
		/// <param name="loadHintArgument">One of the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> values that indicates the default binding preference.</param>
		// Token: 0x06005CA0 RID: 23712 RVA: 0x00144D6F File Offset: 0x00142F6F
		public DefaultDependencyAttribute(LoadHint loadHintArgument)
		{
			this.loadHint = loadHintArgument;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> value that indicates when an assembly loads a dependency.</summary>
		/// <returns>One of the <see cref="T:System.Runtime.CompilerServices.LoadHint" /> values.</returns>
		// Token: 0x17001003 RID: 4099
		// (get) Token: 0x06005CA1 RID: 23713 RVA: 0x00144D7E File Offset: 0x00142F7E
		public LoadHint LoadHint
		{
			get
			{
				return this.loadHint;
			}
		}

		// Token: 0x04002975 RID: 10613
		private LoadHint loadHint;
	}
}
