using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000A7 RID: 167
	internal sealed class AllowAllAssemblyVersionsDeserializationBinder : SerializationBinder
	{
		// Token: 0x060005B7 RID: 1463 RVA: 0x00027A02 File Offset: 0x00025C02
		public override Type BindToType(string assemblyName, string typeName)
		{
			assemblyName = Assembly.GetExecutingAssembly().FullName;
			return Type.GetType(typeName + ", " + assemblyName);
		}
	}
}
