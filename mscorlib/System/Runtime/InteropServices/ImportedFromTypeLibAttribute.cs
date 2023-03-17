using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates that the types defined within an assembly were originally defined in a type library.</summary>
	// Token: 0x020008F1 RID: 2289
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class ImportedFromTypeLibAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ImportedFromTypeLibAttribute" /> class with the name of the original type library file.</summary>
		/// <param name="tlbFile">The location of the original type library file.</param>
		// Token: 0x06005EEC RID: 24300 RVA: 0x00146C0E File Offset: 0x00144E0E
		public ImportedFromTypeLibAttribute(string tlbFile)
		{
			this._val = tlbFile;
		}

		/// <summary>Gets the name of the original type library file.</summary>
		/// <returns>The name of the original type library file.</returns>
		// Token: 0x170010C2 RID: 4290
		// (get) Token: 0x06005EED RID: 24301 RVA: 0x00146C1D File Offset: 0x00144E1D
		public string Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x040029BA RID: 10682
		internal string _val;
	}
}
