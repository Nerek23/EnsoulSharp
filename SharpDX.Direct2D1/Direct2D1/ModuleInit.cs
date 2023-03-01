using System;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000204 RID: 516
	internal class ModuleInit
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x0001F8C6 File Offset: 0x0001DAC6
		[Tag("SharpDX.ModuleInit")]
		internal static void Setup()
		{
			ResultDescriptor.RegisterProvider(typeof(ResultCode));
			ResultDescriptor.RegisterProvider(typeof(ResultCode));
		}
	}
}
