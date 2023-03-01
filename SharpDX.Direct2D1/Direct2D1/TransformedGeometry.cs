using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023B RID: 571
	[Guid("2cd906bb-12e2-11dc-9fed-001143a055f9")]
	public class TransformedGeometry : Geometry
	{
		// Token: 0x06000D30 RID: 3376 RVA: 0x000247B8 File Offset: 0x000229B8
		public TransformedGeometry(Factory factory, Geometry geometrySource, RawMatrix3x2 matrix3X2) : base(IntPtr.Zero)
		{
			factory.CreateTransformedGeometry(geometrySource, ref matrix3X2, this);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0001C75D File Offset: 0x0001A95D
		public TransformedGeometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x000247CF File Offset: 0x000229CF
		public new static explicit operator TransformedGeometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TransformedGeometry(nativePtr);
			}
			return null;
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x000247E8 File Offset: 0x000229E8
		public Geometry SourceGeometry
		{
			get
			{
				Geometry result;
				this.GetSourceGeometry(out result);
				return result;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x00024800 File Offset: 0x00022A00
		public RawMatrix3x2 Transform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetTransform(out result);
				return result;
			}
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00024818 File Offset: 0x00022A18
		internal unsafe void GetSourceGeometry(out Geometry sourceGeometry)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				sourceGeometry = new Geometry(zero);
				return;
			}
			sourceGeometry = null;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00024868 File Offset: 0x00022A68
		internal unsafe void GetTransform(out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
