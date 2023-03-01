using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200017F RID: 383
	[Guid("90f732e2-5092-4606-a819-8651970baccd")]
	public class BoundsAdjustmentTransform : TransformNodeNative
	{
		// Token: 0x06000716 RID: 1814 RVA: 0x00016138 File Offset: 0x00014338
		public BoundsAdjustmentTransform(EffectContext context, RawRectangle outputRectangle) : base(IntPtr.Zero)
		{
			context.CreateBoundsAdjustmentTransform(outputRectangle, this);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001614D File Offset: 0x0001434D
		public BoundsAdjustmentTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00016156 File Offset: 0x00014356
		public new static explicit operator BoundsAdjustmentTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BoundsAdjustmentTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00016170 File Offset: 0x00014370
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00016186 File Offset: 0x00014386
		public RawRectangle OutputBounds
		{
			get
			{
				RawRectangle result;
				this.GetOutputBounds(out result);
				return result;
			}
			set
			{
				this.SetOutputBounds(value);
			}
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001618F File Offset: 0x0001438F
		internal unsafe void SetOutputBounds(RawRectangle outputBounds)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &outputBounds, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x000161B4 File Offset: 0x000143B4
		internal unsafe void GetOutputBounds(out RawRectangle outputBounds)
		{
			outputBounds = default(RawRectangle);
			fixed (RawRectangle* ptr = &outputBounds)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
