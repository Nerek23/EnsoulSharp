using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D6 RID: 470
	[Guid("36bfdcb6-9739-435d-a30d-a653beff6a6f")]
	public class DrawTransformNative : TransformNative, DrawTransform, Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000988 RID: 2440 RVA: 0x0001B84C File Offset: 0x00019A4C
		public void SetDrawInformation(DrawInformation drawInfo)
		{
			this.SetDrawInfo_(drawInfo);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0001805E File Offset: 0x0001625E
		public DrawTransformNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0001B855 File Offset: 0x00019A55
		public new static explicit operator DrawTransformNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DrawTransformNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700015B RID: 347
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x0001B84C File Offset: 0x00019A4C
		public DrawInformation DrawInfo_
		{
			set
			{
				this.SetDrawInfo_(value);
			}
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0001B86C File Offset: 0x00019A6C
		internal unsafe void SetDrawInfo_(DrawInformation drawInfo)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DrawInformation>(drawInfo);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
