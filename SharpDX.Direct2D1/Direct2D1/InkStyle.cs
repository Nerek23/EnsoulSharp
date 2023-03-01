using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F8 RID: 504
	[Guid("bae8b344-23fc-4071-8cb5-d05d6f073848")]
	public class InkStyle : Resource
	{
		// Token: 0x06000ACB RID: 2763 RVA: 0x0001F010 File Offset: 0x0001D210
		public InkStyle(DeviceContext2 context2) : this(IntPtr.Zero)
		{
			context2.CreateInkStyle(null, this);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0001F038 File Offset: 0x0001D238
		public InkStyle(DeviceContext2 context2, InkStyleProperties inkStyleProperties) : this(IntPtr.Zero)
		{
			context2.CreateInkStyle(new InkStyleProperties?(inkStyleProperties), this);
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00016258 File Offset: 0x00014458
		public InkStyle(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0001F052 File Offset: 0x0001D252
		public new static explicit operator InkStyle(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InkStyle(nativePtr);
			}
			return null;
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x0001F06C File Offset: 0x0001D26C
		// (set) Token: 0x06000AD0 RID: 2768 RVA: 0x0001F082 File Offset: 0x0001D282
		public RawMatrix3x2 NibTransform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetNibTransform(out result);
				return result;
			}
			set
			{
				this.SetNibTransform(ref value);
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x0001F08C File Offset: 0x0001D28C
		// (set) Token: 0x06000AD2 RID: 2770 RVA: 0x0001F094 File Offset: 0x0001D294
		public InkNibShape NibShape
		{
			get
			{
				return this.GetNibShape();
			}
			set
			{
				this.SetNibShape(value);
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0001F0A0 File Offset: 0x0001D2A0
		internal unsafe void SetNibTransform(ref RawMatrix3x2 transform)
		{
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0001F0D4 File Offset: 0x0001D2D4
		internal unsafe void GetNibTransform(out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x000160B9 File Offset: 0x000142B9
		internal unsafe void SetNibShape(InkNibShape nibShape)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, nibShape, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0001F10E File Offset: 0x0001D30E
		internal unsafe InkNibShape GetNibShape()
		{
			return calli(SharpDX.Direct2D1.InkNibShape(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}
	}
}
