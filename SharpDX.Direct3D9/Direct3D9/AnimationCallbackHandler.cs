using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AA RID: 170
	public class AnimationCallbackHandler : CppObject
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x00010519 File Offset: 0x0000E719
		public AnimationCallbackHandler(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00010522 File Offset: 0x0000E722
		public static explicit operator AnimationCallbackHandler(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new AnimationCallbackHandler(nativePointer);
			}
			return null;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0001053C File Offset: 0x0000E73C
		public unsafe void HandleCallback(int track, IntPtr callbackDataRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, track, (void*)callbackDataRef, *(*(IntPtr*)this._nativePointer)).CheckError();
		}
	}
}
