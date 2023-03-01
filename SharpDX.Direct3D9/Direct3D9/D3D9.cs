using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000A7 RID: 167
	internal static class D3D9
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x0000AFBC File Offset: 0x000091BC
		public unsafe static void Create9Ex(int sDKVersion, Direct3DEx arg1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3D9.Direct3DCreate9Ex_(sDKVersion, (void*)(&zero));
			arg1.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002D5 RID: 725
		[DllImport("d3d9.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "Direct3DCreate9Ex")]
		private unsafe static extern int Direct3DCreate9Ex_(int arg0, void* arg1);

		// Token: 0x060002D6 RID: 726 RVA: 0x0000AFEC File Offset: 0x000091EC
		public static Direct3D Create9(int sDKVersion)
		{
			return new Direct3D(D3D9.Direct3DCreate9_(sDKVersion));
		}

		// Token: 0x060002D7 RID: 727
		[DllImport("d3d9.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "Direct3DCreate9")]
		private static extern IntPtr Direct3DCreate9_(int arg0);

		// Token: 0x040009A9 RID: 2473
		public const int SdkVersion = 32;
	}
}
