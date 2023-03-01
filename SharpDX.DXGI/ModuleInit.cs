using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000019 RID: 25
	internal class ModuleInit
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00004040 File Offset: 0x00002240
		[Tag("SharpDX.ModuleInit")]
		internal static void Setup()
		{
			ResultDescriptor.RegisterProvider(typeof(ResultCode));
		}
	}
}
