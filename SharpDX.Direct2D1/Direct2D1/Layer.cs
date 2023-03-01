using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001FC RID: 508
	[Guid("2cd9069b-12e2-11dc-9fed-001143a055f9")]
	public class Layer : Resource
	{
		// Token: 0x06000AE3 RID: 2787 RVA: 0x0001F358 File Offset: 0x0001D558
		public Layer(RenderTarget renderTarget) : this(renderTarget, null)
		{
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0001F375 File Offset: 0x0001D575
		public Layer(RenderTarget renderTarget, Size2F? size) : base(IntPtr.Zero)
		{
			renderTarget.CreateLayer(size, this);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00016258 File Offset: 0x00014458
		public Layer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0001F38A File Offset: 0x0001D58A
		public new static explicit operator Layer(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Layer(nativePtr);
			}
			return null;
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0001F3A1 File Offset: 0x0001D5A1
		public Size2F Size
		{
			get
			{
				return this.GetSize();
			}
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0001F3AC File Offset: 0x0001D5AC
		internal unsafe Size2F GetSize()
		{
			Size2F result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			return result;
		}
	}
}
