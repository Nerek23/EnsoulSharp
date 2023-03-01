using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000229 RID: 553
	[Guid("db1800dd-0c34-4cf9-be90-31cc0a5653e1")]
	public class SourceTransformNative : TransformNative, SourceTransform, Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000C7F RID: 3199 RVA: 0x00022CCC File Offset: 0x00020ECC
		public void SetRenderInformation(RenderInformation renderInfo)
		{
			this.SetRenderInfo_(renderInfo);
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00022CD5 File Offset: 0x00020ED5
		public void Draw(Bitmap1 target, RawRectangle drawRect, RawPoint targetOrigin)
		{
			this.Draw_(target, drawRect, targetOrigin);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0001805E File Offset: 0x0001625E
		public SourceTransformNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00022CE0 File Offset: 0x00020EE0
		public new static explicit operator SourceTransformNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SourceTransformNative(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A6 RID: 422
		// (set) Token: 0x06000C83 RID: 3203 RVA: 0x00022CCC File Offset: 0x00020ECC
		public RenderInformation RenderInfo_
		{
			set
			{
				this.SetRenderInfo_(value);
			}
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00022CF8 File Offset: 0x00020EF8
		internal unsafe void SetRenderInfo_(RenderInformation renderInfo)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderInformation>(renderInfo);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00022D44 File Offset: 0x00020F44
		internal unsafe void Draw_(Bitmap1 target, RawRectangle drawRect, RawPoint targetOrigin)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap1>(target);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawPoint), this._nativePointer, (void*)value, &drawRect, targetOrigin, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
