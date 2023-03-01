using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F4 RID: 500
	[Guid("fe9e984d-3f95-407c-b5db-cb94d4e8f87c")]
	public class ImageBrush : Brush
	{
		// Token: 0x06000A96 RID: 2710 RVA: 0x0001E8D4 File Offset: 0x0001CAD4
		public ImageBrush(DeviceContext context, Image image, ImageBrushProperties imageBrushProperties) : base(IntPtr.Zero)
		{
			context.CreateImageBrush(image, ref imageBrushProperties, null, this);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0001E8FF File Offset: 0x0001CAFF
		public ImageBrush(DeviceContext context, Image image, ImageBrushProperties imageBrushProperties, BrushProperties brushProperties) : base(IntPtr.Zero)
		{
			context.CreateImageBrush(image, ref imageBrushProperties, new BrushProperties?(brushProperties), this);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00015A4C File Offset: 0x00013C4C
		public ImageBrush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0001E91D File Offset: 0x0001CB1D
		public new static explicit operator ImageBrush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImageBrush(nativePtr);
			}
			return null;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0001E934 File Offset: 0x0001CB34
		// (set) Token: 0x06000A9B RID: 2715 RVA: 0x0001E94A File Offset: 0x0001CB4A
		public Image Image
		{
			get
			{
				Image result;
				this.GetImage(out result);
				return result;
			}
			set
			{
				this.SetImage(value);
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0001E953 File Offset: 0x0001CB53
		// (set) Token: 0x06000A9D RID: 2717 RVA: 0x0001E95B File Offset: 0x0001CB5B
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

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0001E964 File Offset: 0x0001CB64
		// (set) Token: 0x06000A9F RID: 2719 RVA: 0x0001E96C File Offset: 0x0001CB6C
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

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x0001E975 File Offset: 0x0001CB75
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x0001E97D File Offset: 0x0001CB7D
		public InterpolationMode InterpolationMode
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

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x0001E988 File Offset: 0x0001CB88
		// (set) Token: 0x06000AA3 RID: 2723 RVA: 0x0001E99E File Offset: 0x0001CB9E
		public RawRectangleF SourceRectangle
		{
			get
			{
				RawRectangleF result;
				this.GetSourceRectangle(out result);
				return result;
			}
			set
			{
				this.SetSourceRectangle(value);
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0001E9A8 File Offset: 0x0001CBA8
		internal unsafe void SetImage(Image image)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00015ADF File Offset: 0x00013CDF
		internal unsafe void SetExtendModeX(ExtendMode extendModeX)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendModeX, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00015B00 File Offset: 0x00013D00
		internal unsafe void SetExtendModeY(ExtendMode extendModeY)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendModeY, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0001E9E5 File Offset: 0x0001CBE5
		internal unsafe void SetInterpolationMode(InterpolationMode interpolationMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, interpolationMode, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0001E43C File Offset: 0x0001C63C
		internal unsafe void SetSourceRectangle(RawRectangleF sourceRectangle)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &sourceRectangle, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0001EA08 File Offset: 0x0001CC08
		internal unsafe void GetImage(out Image image)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				image = new Image(zero);
				return;
			}
			image = null;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0001EA55 File Offset: 0x0001CC55
		internal unsafe ExtendMode GetExtendModeX()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0001EA75 File Offset: 0x0001CC75
		internal unsafe ExtendMode GetExtendModeY()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0001EA95 File Offset: 0x0001CC95
		internal unsafe InterpolationMode GetInterpolationMode()
		{
			return calli(SharpDX.Direct2D1.InterpolationMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0001EAB8 File Offset: 0x0001CCB8
		internal unsafe void GetSourceRectangle(out RawRectangleF sourceRectangle)
		{
			sourceRectangle = default(RawRectangleF);
			fixed (RawRectangleF* ptr = &sourceRectangle)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
