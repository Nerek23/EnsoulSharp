using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023F RID: 575
	[Guid("b2efe1e7-729f-4102-949f-505fa21bf666")]
	public class TransformNodeNative : ComObject, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00024AED File Offset: 0x00022CED
		public int InputCount
		{
			get
			{
				return this.GetInputCount_();
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00002A7F File Offset: 0x00000C7F
		public TransformNodeNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x00024AF5 File Offset: 0x00022CF5
		public new static explicit operator TransformNodeNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TransformNodeNative(nativePtr);
			}
			return null;
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x00024AED File Offset: 0x00022CED
		public int InputCount_
		{
			get
			{
				return this.GetInputCount_();
			}
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetInputCount_()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}
	}
}
