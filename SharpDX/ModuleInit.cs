using System;

namespace SharpDX
{
	// Token: 0x02000027 RID: 39
	internal class ModuleInit
	{
		// Token: 0x0600010F RID: 271 RVA: 0x000040A3 File Offset: 0x000022A3
		[Tag("SharpDX.ModuleInit")]
		internal static void Setup()
		{
			ResultDescriptor.RegisterProvider(typeof(Result));
		}
	}
}
