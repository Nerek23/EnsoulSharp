using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000177 RID: 375
	[Guid("2cd906aa-12e2-11dc-9fed-001143a055f9")]
	public class BitmapBrush : Brush
	{
		// Token: 0x060006D1 RID: 1745 RVA: 0x000159C4 File Offset: 0x00013BC4
		public BitmapBrush(RenderTarget renderTarget, Bitmap bitmap) : this(renderTarget, bitmap, null, null)
		{
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000159EC File Offset: 0x00013BEC
		public BitmapBrush(RenderTarget renderTarget, Bitmap bitmap, BitmapBrushProperties bitmapBrushProperties) : this(renderTarget, bitmap, new BitmapBrushProperties?(bitmapBrushProperties), null)
		{
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00015A10 File Offset: 0x00013C10
		public BitmapBrush(RenderTarget renderTarget, Bitmap bitmap, BrushProperties brushProperties) : this(renderTarget, bitmap, null, new BrushProperties?(brushProperties))
		{
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00015A34 File Offset: 0x00013C34
		public BitmapBrush(RenderTarget renderTarget, Bitmap bitmap, BitmapBrushProperties? bitmapBrushProperties, BrushProperties? brushProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateBitmapBrush(bitmap, bitmapBrushProperties, brushProperties, this);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00015A4C File Offset: 0x00013C4C
		public BitmapBrush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00015A55 File Offset: 0x00013C55
		public new static explicit operator BitmapBrush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapBrush(nativePtr);
			}
			return null;
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00015A6C File Offset: 0x00013C6C
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x00015A74 File Offset: 0x00013C74
		public ExtendMode ExtendModeX
		{
			get
			{
				return this.GetExtendModeX();
			}
			set
			{
				this.SetExtendModeX(value);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00015A7D File Offset: 0x00013C7D
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x00015A85 File Offset: 0x00013C85
		public ExtendMode ExtendModeY
		{
			get
			{
				return this.GetExtendModeY();
			}
			set
			{
				this.SetExtendModeY(value);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00015A8E File Offset: 0x00013C8E
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x00015A96 File Offset: 0x00013C96
		public BitmapInterpolationMode InterpolationMode
		{
			get
			{
				return this.GetInterpolationMode();
			}
			set
			{
				this.SetInterpolationMode(value);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00015AA0 File Offset: 0x00013CA0
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00015AB6 File Offset: 0x00013CB6
		public Bitmap Bitmap
		{
			get
			{
				Bitmap result;
				this.GetBitmap(out result);
				return result;
			}
			set
			{
				this.SetBitmap(value);
			}
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00015ABF File Offset: 0x00013CBF
		internal unsafe void SetExtendModeX(ExtendMode extendModeX)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendModeX, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00015ADF File Offset: 0x00013CDF
		internal unsafe void SetExtendModeY(ExtendMode extendModeY)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendModeY, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00015B00 File Offset: 0x00013D00
		internal unsafe void SetInterpolationMode(BitmapInterpolationMode interpolationMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, interpolationMode, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00015B24 File Offset: 0x00013D24
		internal unsafe void SetBitmap(Bitmap bitmap)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00015B62 File Offset: 0x00013D62
		internal unsafe ExtendMode GetExtendModeX()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00015B82 File Offset: 0x00013D82
		internal unsafe ExtendMode GetExtendModeY()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00015BA2 File Offset: 0x00013DA2
		internal unsafe BitmapInterpolationMode GetInterpolationMode()
		{
			return calli(SharpDX.Direct2D1.BitmapInterpolationMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00015BC4 File Offset: 0x00013DC4
		internal unsafe void GetBitmap(out Bitmap bitmap)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmap = new Bitmap(zero);
				return;
			}
			bitmap = null;
		}
	}
}
