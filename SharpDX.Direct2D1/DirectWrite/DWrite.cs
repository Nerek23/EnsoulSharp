using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000121 RID: 289
	internal static class DWrite
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x00010074 File Offset: 0x0000E274
		public unsafe static void CreateFactory(FactoryType factoryType, Guid iid, ComObject factory)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = DWrite.DWriteCreateFactory_((int)factoryType, (void*)(&iid), (void*)(&zero));
			factory.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060004F0 RID: 1264
		[DllImport("dwrite.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "DWriteCreateFactory")]
		private unsafe static extern int DWriteCreateFactory_(int param0, void* param1, void* param2);
	}
}
