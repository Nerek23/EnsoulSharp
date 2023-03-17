using System;

namespace System.Runtime.Versioning
{
	/// <summary>Defines the compatibility guarantee of a component, type, or type member that may span multiple versions.</summary>
	// Token: 0x020006F1 RID: 1777
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	public sealed class ComponentGuaranteesAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Versioning.ComponentGuaranteesAttribute" /> class with a value that indicates a library, type, or member's guaranteed level of compatibility across multiple versions.</summary>
		/// <param name="guarantees">One of the enumeration values that specifies the level of compatibility that is guaranteed across multiple versions.</param>
		// Token: 0x06005035 RID: 20533 RVA: 0x0011A2A0 File Offset: 0x001184A0
		public ComponentGuaranteesAttribute(ComponentGuaranteesOptions guarantees)
		{
			this._guarantees = guarantees;
		}

		/// <summary>Gets a value that indicates the guaranteed level of compatibility of a library, type, or type member that spans multiple versions.</summary>
		/// <returns>One of the enumeration values that specifies the level of compatibility that is guaranteed across multiple versions.</returns>
		// Token: 0x17000D52 RID: 3410
		// (get) Token: 0x06005036 RID: 20534 RVA: 0x0011A2AF File Offset: 0x001184AF
		public ComponentGuaranteesOptions Guarantees
		{
			get
			{
				return this._guarantees;
			}
		}

		// Token: 0x04002353 RID: 9043
		private ComponentGuaranteesOptions _guarantees;
	}
}
