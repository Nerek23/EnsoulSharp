using System;

namespace System.Collections
{
	/// <summary>Provides objects for performing a structural comparison of two collection objects.</summary>
	// Token: 0x0200047A RID: 1146
	[__DynamicallyInvokable]
	public static class StructuralComparisons
	{
		/// <summary>Gets a predefined object that performs a structural comparison of two objects.</summary>
		/// <returns>A predefined object that is used to perform a structural comparison of two collection objects.</returns>
		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x060037DD RID: 14301 RVA: 0x000D5A9C File Offset: 0x000D3C9C
		[__DynamicallyInvokable]
		public static IComparer StructuralComparer
		{
			[__DynamicallyInvokable]
			get
			{
				IComparer comparer = StructuralComparisons.s_StructuralComparer;
				if (comparer == null)
				{
					comparer = new StructuralComparer();
					StructuralComparisons.s_StructuralComparer = comparer;
				}
				return comparer;
			}
		}

		/// <summary>Gets a predefined object that compares two objects for structural equality.</summary>
		/// <returns>A predefined object that is used to compare two collection objects for structural equality.</returns>
		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x060037DE RID: 14302 RVA: 0x000D5AC4 File Offset: 0x000D3CC4
		[__DynamicallyInvokable]
		public static IEqualityComparer StructuralEqualityComparer
		{
			[__DynamicallyInvokable]
			get
			{
				IEqualityComparer equalityComparer = StructuralComparisons.s_StructuralEqualityComparer;
				if (equalityComparer == null)
				{
					equalityComparer = new StructuralEqualityComparer();
					StructuralComparisons.s_StructuralEqualityComparer = equalityComparer;
				}
				return equalityComparer;
			}
		}

		// Token: 0x04001853 RID: 6227
		private static volatile IComparer s_StructuralComparer;

		// Token: 0x04001854 RID: 6228
		private static volatile IEqualityComparer s_StructuralEqualityComparer;
	}
}
