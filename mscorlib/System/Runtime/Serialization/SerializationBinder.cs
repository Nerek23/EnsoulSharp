using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Allows users to control class loading and mandate what class to load.</summary>
	// Token: 0x02000711 RID: 1809
	[ComVisible(true)]
	[Serializable]
	public abstract class SerializationBinder
	{
		/// <summary>When overridden in a derived class, controls the binding of a serialized object to a type.</summary>
		/// <param name="serializedType">The type of the object the formatter creates a new instance of.</param>
		/// <param name="assemblyName">Specifies the <see cref="T:System.Reflection.Assembly" /> name of the serialized object.</param>
		/// <param name="typeName">Specifies the <see cref="T:System.Type" /> name of the serialized object.</param>
		// Token: 0x060050B1 RID: 20657 RVA: 0x0011B39F File Offset: 0x0011959F
		public virtual void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			assemblyName = null;
			typeName = null;
		}

		/// <summary>When overridden in a derived class, controls the binding of a serialized object to a type.</summary>
		/// <param name="assemblyName">Specifies the <see cref="T:System.Reflection.Assembly" /> name of the serialized object.</param>
		/// <param name="typeName">Specifies the <see cref="T:System.Type" /> name of the serialized object.</param>
		/// <returns>The type of the object the formatter creates a new instance of.</returns>
		// Token: 0x060050B2 RID: 20658
		public abstract Type BindToType(string assemblyName, string typeName);
	}
}
