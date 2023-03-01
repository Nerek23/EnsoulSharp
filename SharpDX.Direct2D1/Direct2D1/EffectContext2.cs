using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000301 RID: 769
	[Guid("577ad2a0-9fc7-4dda-8b18-dab810140052")]
	public class EffectContext2 : EffectContext1
	{
		// Token: 0x06000D93 RID: 3475 RVA: 0x00025A10 File Offset: 0x00023C10
		public EffectContext2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00025A19 File Offset: 0x00023C19
		public new static explicit operator EffectContext2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new EffectContext2(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00025A30 File Offset: 0x00023C30
		public unsafe void CreateColorContextFromDxgiColorSpace(ColorSpaceType colorSpace, ColorContext1 colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, colorSpace, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00025A7C File Offset: 0x00023C7C
		public unsafe void CreateColorContextFromSimpleColorProfile(ref SimpleColorProfile simpleProfile, ColorContext1 colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (SimpleColorProfile* ptr = &simpleProfile)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}
	}
}
