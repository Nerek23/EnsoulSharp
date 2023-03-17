using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies which <see cref="T:System.Type" /> exclusively uses an interface. This class cannot be inherited.</summary>
	// Token: 0x020008EC RID: 2284
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibImportClassAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.TypeLibImportClassAttribute" /> class specifying the <see cref="T:System.Type" /> that exclusively uses an interface.</summary>
		/// <param name="importClass">The <see cref="T:System.Type" /> object that exclusively uses an interface.</param>
		// Token: 0x06005EE4 RID: 24292 RVA: 0x00146BB4 File Offset: 0x00144DB4
		public TypeLibImportClassAttribute(Type importClass)
		{
			this._importClassName = importClass.ToString();
		}

		/// <summary>Gets the name of a <see cref="T:System.Type" /> object that exclusively uses an interface.</summary>
		/// <returns>The name of a <see cref="T:System.Type" /> object that exclusively uses an interface.</returns>
		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06005EE5 RID: 24293 RVA: 0x00146BC8 File Offset: 0x00144DC8
		public string Value
		{
			get
			{
				return this._importClassName;
			}
		}

		// Token: 0x040029B7 RID: 10679
		internal string _importClassName;
	}
}
