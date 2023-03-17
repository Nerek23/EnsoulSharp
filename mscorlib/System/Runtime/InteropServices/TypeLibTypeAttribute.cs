using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Contains the <see cref="T:System.Runtime.InteropServices.TYPEFLAGS" /> that were originally imported for this type from the COM type library.</summary>
	// Token: 0x020008F9 RID: 2297
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibTypeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see langword="TypeLibTypeAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value.</summary>
		/// <param name="flags">The <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value for the attributed type as found in the type library it was imported from.</param>
		// Token: 0x06005EF8 RID: 24312 RVA: 0x00146D55 File Offset: 0x00144F55
		public TypeLibTypeAttribute(TypeLibTypeFlags flags)
		{
			this._val = flags;
		}

		/// <summary>Initializes a new instance of the <see langword="TypeLibTypeAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value.</summary>
		/// <param name="flags">The <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value for the attributed type as found in the type library it was imported from.</param>
		// Token: 0x06005EF9 RID: 24313 RVA: 0x00146D64 File Offset: 0x00144F64
		public TypeLibTypeAttribute(short flags)
		{
			this._val = (TypeLibTypeFlags)flags;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value for this type.</summary>
		/// <returns>The <see cref="T:System.Runtime.InteropServices.TypeLibTypeFlags" /> value for this type.</returns>
		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x06005EFA RID: 24314 RVA: 0x00146D73 File Offset: 0x00144F73
		public TypeLibTypeFlags Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029EC RID: 10732
		internal TypeLibTypeFlags _val;
	}
}
