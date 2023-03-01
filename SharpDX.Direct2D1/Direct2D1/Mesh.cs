using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000203 RID: 515
	[Guid("2cd906c2-12e2-11dc-9fed-001143a055f9")]
	public class Mesh : Resource
	{
		// Token: 0x06000B01 RID: 2817 RVA: 0x0001F7E4 File Offset: 0x0001D9E4
		public Mesh(RenderTarget renderTarget) : base(IntPtr.Zero)
		{
			renderTarget.CreateMesh(this);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0001F7F8 File Offset: 0x0001D9F8
		public Mesh(RenderTarget renderTarget, Triangle[] triangles) : this(renderTarget)
		{
			using (TessellationSink tessellationSink = this.Open())
			{
				tessellationSink.AddTriangles(triangles);
				tessellationSink.Close();
			}
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public TessellationSink Open()
		{
			TessellationSink result;
			this.Open_(out result);
			return result;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00016258 File Offset: 0x00014458
		public Mesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0001F852 File Offset: 0x0001DA52
		public new static explicit operator Mesh(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Mesh(nativePtr);
			}
			return null;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0001F86C File Offset: 0x0001DA6C
		internal unsafe void Open_(out TessellationSink tessellationSink)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				tessellationSink = new TessellationSinkNative(zero);
			}
			else
			{
				tessellationSink = null;
			}
			result.CheckError();
		}
	}
}
