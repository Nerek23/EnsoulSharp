using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Contains the <see cref="T:System.Runtime.InteropServices.VARFLAGS" /> that were originally imported for this field from the COM type library.</summary>
	// Token: 0x020008FB RID: 2299
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibVarAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.TypeLibVarAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value.</summary>
		/// <param name="flags">The <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value for the attributed field as found in the type library it was imported from.</param>
		// Token: 0x06005EFE RID: 24318 RVA: 0x00146DA1 File Offset: 0x00144FA1
		public TypeLibVarAttribute(TypeLibVarFlags flags)
		{
			this._val = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.TypeLibVarAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value.</summary>
		/// <param name="flags">The <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value for the attributed field as found in the type library it was imported from.</param>
		// Token: 0x06005EFF RID: 24319 RVA: 0x00146DB0 File Offset: 0x00144FB0
		public TypeLibVarAttribute(short flags)
		{
			this._val = (TypeLibVarFlags)flags;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value for this field.</summary>
		/// <returns>The <see cref="T:System.Runtime.InteropServices.TypeLibVarFlags" /> value for this field.</returns>
		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06005F00 RID: 24320 RVA: 0x00146DBF File Offset: 0x00144FBF
		public TypeLibVarFlags Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029EE RID: 10734
		internal TypeLibVarFlags _val;
	}
}
