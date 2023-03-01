using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001BC RID: 444
	[Guid("a248fd3f-3e6c-4e63-9f03-7f68ecc91db9")]
	internal class CustomEffectNative : ComObject, CustomEffect, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000888 RID: 2184 RVA: 0x0001899A File Offset: 0x00016B9A
		public void Initialize(EffectContext effectContext, TransformGraph transformGraph)
		{
			this.Initialize_(effectContext, transformGraph);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x000189A4 File Offset: 0x00016BA4
		public void PrepareForRender(ChangeType changeType)
		{
			this.PrepareForRender_(changeType);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x000189AD File Offset: 0x00016BAD
		public void SetGraph(TransformGraph transformGraph)
		{
			this.SetGraph_(transformGraph);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00002A7F File Offset: 0x00000C7F
		public CustomEffectNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000189B6 File Offset: 0x00016BB6
		public new static explicit operator CustomEffectNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CustomEffectNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700014B RID: 331
		// (set) Token: 0x0600088D RID: 2189 RVA: 0x000189AD File Offset: 0x00016BAD
		public TransformGraph Graph_
		{
			set
			{
				this.SetGraph_(value);
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x000189D0 File Offset: 0x00016BD0
		internal unsafe void Initialize_(EffectContext effectContext, TransformGraph transformGraph)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<EffectContext>(effectContext);
			value2 = CppObject.ToCallbackPtr<TransformGraph>(transformGraph);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00018A30 File Offset: 0x00016C30
		internal unsafe void PrepareForRender_(ChangeType changeType)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, changeType, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00018A68 File Offset: 0x00016C68
		internal unsafe void SetGraph_(TransformGraph transformGraph)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformGraph>(transformGraph);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
