using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020002FE RID: 766
	[Guid("2cd906a8-12e2-11dc-9fed-001143a055f9")]
	public class Brush : Resource
	{
		// Token: 0x06000D81 RID: 3457 RVA: 0x00016258 File Offset: 0x00014458
		public Brush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x000257BA File Offset: 0x000239BA
		public new static explicit operator Brush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Brush(nativePtr);
			}
			return null;
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000D83 RID: 3459 RVA: 0x000257D1 File Offset: 0x000239D1
		// (set) Token: 0x06000D84 RID: 3460 RVA: 0x000257D9 File Offset: 0x000239D9
		public float Opacity
		{
			get
			{
				return this.GetOpacity();
			}
			set
			{
				this.SetOpacity(value);
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x000257E4 File Offset: 0x000239E4
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x000257FA File Offset: 0x000239FA
		public RawMatrix3x2 Transform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetTransform(out result);
				return result;
			}
			set
			{
				this.SetTransform(ref value);
			}
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00025804 File Offset: 0x00023A04
		internal unsafe void SetOpacity(float opacity)
		{
			calli(System.Void(System.Void*,System.Single), this._nativePointer, opacity, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00025824 File Offset: 0x00023A24
		internal unsafe void SetTransform(ref RawMatrix3x2 transform)
		{
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00025857 File Offset: 0x00023A57
		internal unsafe float GetOpacity()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00025878 File Offset: 0x00023A78
		internal unsafe void GetTransform(out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
