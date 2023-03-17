using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Allows access to field names and field types of objects that support the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface.</summary>
	// Token: 0x02000734 RID: 1844
	[ComVisible(true)]
	public interface IFieldInfo
	{
		/// <summary>Gets or sets the field names of serialized objects.</summary>
		/// <returns>The field names of serialized objects.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x060051E5 RID: 20965
		// (set) Token: 0x060051E6 RID: 20966
		string[] FieldNames { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Gets or sets the field types of the serialized objects.</summary>
		/// <returns>The field types of the serialized objects.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x060051E7 RID: 20967
		// (set) Token: 0x060051E8 RID: 20968
		Type[] FieldTypes { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
