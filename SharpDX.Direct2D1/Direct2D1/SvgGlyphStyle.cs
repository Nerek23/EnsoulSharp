using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000310 RID: 784
	[Guid("af671749-d241-4db8-8e41-dcc2e5c1a438")]
	public class SvgGlyphStyle : Resource
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00016258 File Offset: 0x00014458
		public SvgGlyphStyle(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x000260B4 File Offset: 0x000242B4
		public new static explicit operator SvgGlyphStyle(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgGlyphStyle(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x000260CC File Offset: 0x000242CC
		// (set) Token: 0x06000DCA RID: 3530 RVA: 0x000260E2 File Offset: 0x000242E2
		public Brush Fill
		{
			get
			{
				Brush result;
				this.GetFill(out result);
				return result;
			}
			set
			{
				this.SetFill(value);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x000260EB File Offset: 0x000242EB
		public int StrokeDashesCount
		{
			get
			{
				return this.GetStrokeDashesCount();
			}
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x000260F4 File Offset: 0x000242F4
		internal unsafe void SetFill(Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00026140 File Offset: 0x00024340
		internal unsafe void GetFill(out Brush brush)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				brush = new Brush(zero);
				return;
			}
			brush = null;
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x0002618C File Offset: 0x0002438C
		public unsafe void SetStroke(Brush brush, float strokeWidth, float[] dashes, int dashesCount, float dashOffset)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			Result result;
			fixed (float[] array = dashes)
			{
				void* ptr;
				if (dashes == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*,System.Int32,System.Single), this._nativePointer, (void*)value, strokeWidth, ptr, dashesCount, dashOffset, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0002310E File Offset: 0x0002130E
		internal unsafe int GetStrokeDashesCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x000261F8 File Offset: 0x000243F8
		public unsafe void GetStroke(out Brush brush, out float strokeWidth, float[] dashes, int dashesCount, out float dashOffset)
		{
			IntPtr zero = IntPtr.Zero;
			fixed (float* ptr = &dashOffset)
			{
				void* ptr2 = (void*)ptr;
				fixed (float[] array = dashes)
				{
					void* ptr3;
					if (dashes == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					fixed (float* ptr4 = &strokeWidth)
					{
						void* ptr5 = (void*)ptr4;
						calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &zero, ptr5, ptr3, dashesCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				brush = new Brush(zero);
				return;
			}
			brush = null;
		}
	}
}
