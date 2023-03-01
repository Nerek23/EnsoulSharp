using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000122 RID: 290
	internal class ModuleInit
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x0001AA90 File Offset: 0x00018C90
		[Tag("SharpDX.ModuleInit")]
		internal static void Setup()
		{
			ResultDescriptor.RegisterProvider(typeof(ResultCode));
		}
	}
}
