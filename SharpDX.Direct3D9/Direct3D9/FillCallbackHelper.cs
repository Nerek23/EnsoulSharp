using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200002D RID: 45
	internal static class FillCallbackHelper
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0000A9E4 File Offset: 0x00008BE4
		private unsafe static Result Fill2DCallbackImpl(RawColor4* outVector, RawVector2* textCoord, RawVector2* textelSize, IntPtr data)
		{
			try
			{
				*outVector = ((Fill2DCallback)GCHandle.FromIntPtr(data).Target)(*textCoord, *textelSize);
			}
			catch (SharpDXException ex)
			{
				return ex.ResultCode.Code;
			}
			catch (Exception)
			{
				return Result.Fail.Code;
			}
			return Result.Ok.Code;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000AA78 File Offset: 0x00008C78
		private unsafe static Result Fill3DCallbackImpl(RawColor4* outVector, RawVector3* textCoord, RawVector3* textelSize, IntPtr data)
		{
			try
			{
				*outVector = ((Fill3DCallback)GCHandle.FromIntPtr(data).Target)(*textCoord, *textelSize);
			}
			catch (SharpDXException ex)
			{
				return ex.ResultCode.Code;
			}
			catch (Exception)
			{
				return Result.Fail.Code;
			}
			return Result.Ok.Code;
		}

		// Token: 0x040004DF RID: 1247
		private static FillCallbackHelper.Fill2DCallbackDelegate native2DCallback = new FillCallbackHelper.Fill2DCallbackDelegate(FillCallbackHelper.Fill2DCallbackImpl);

		// Token: 0x040004E0 RID: 1248
		private static FillCallbackHelper.Fill3DCallbackDelegate native3DCallback = new FillCallbackHelper.Fill3DCallbackDelegate(FillCallbackHelper.Fill3DCallbackImpl);

		// Token: 0x040004E1 RID: 1249
		public static IntPtr Native2DCallbackPtr = Marshal.GetFunctionPointerForDelegate(FillCallbackHelper.native2DCallback);

		// Token: 0x040004E2 RID: 1250
		public static IntPtr Native3DCallbackPtr = Marshal.GetFunctionPointerForDelegate(FillCallbackHelper.native3DCallback);

		// Token: 0x0200002E RID: 46
		// (Invoke) Token: 0x060002B5 RID: 693
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private unsafe delegate Result Fill2DCallbackDelegate(RawColor4* outVector, RawVector2* textCoord, RawVector2* textelSize, IntPtr data);

		// Token: 0x0200002F RID: 47
		// (Invoke) Token: 0x060002B9 RID: 697
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private unsafe delegate Result Fill3DCallbackDelegate(RawColor4* outVector, RawVector3* textCoord, RawVector3* textelSize, IntPtr data);
	}
}
