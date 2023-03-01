using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000031 RID: 49
	internal class ModuleInit
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000AC84 File Offset: 0x00008E84
		[Tag("SharpDX.ModuleInit")]
		internal static void Setup()
		{
			ResultDescriptor.RegisterProvider(typeof(ResultCode));
		}
	}
}
