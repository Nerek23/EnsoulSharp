using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000054 RID: 84
	internal static class DXGI
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00005A24 File Offset: 0x00003C24
		public unsafe static void CreateDXGIFactory1(Guid riid, out IntPtr factoryOut)
		{
			Result result;
			fixed (IntPtr* ptr = &factoryOut)
			{
				void* param = (void*)ptr;
				result = DXGI.CreateDXGIFactory1_((void*)(&riid), param);
			}
			result.CheckError();
		}

		// Token: 0x0600014C RID: 332
		[DllImport("dxgi.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CreateDXGIFactory1")]
		private unsafe static extern int CreateDXGIFactory1_(void* param0, void* param1);

		// Token: 0x0600014D RID: 333 RVA: 0x00005A50 File Offset: 0x00003C50
		public unsafe static void CreateDXGIFactory2(int flags, Guid riid, out IntPtr factoryOut)
		{
			Result result;
			fixed (IntPtr* ptr = &factoryOut)
			{
				void* param = (void*)ptr;
				result = DXGI.CreateDXGIFactory2_(flags, (void*)(&riid), param);
			}
			result.CheckError();
		}

		// Token: 0x0600014E RID: 334
		[DllImport("dxgi.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CreateDXGIFactory2")]
		private unsafe static extern int CreateDXGIFactory2_(int param0, void* param1, void* param2);

		// Token: 0x0400018D RID: 397
		public const int CreateFactoryDebug = 1;
	}
}
