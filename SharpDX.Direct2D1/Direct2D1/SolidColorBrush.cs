using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000227 RID: 551
	[Guid("2cd906a9-12e2-11dc-9fed-001143a055f9")]
	public class SolidColorBrush : Brush
	{
		// Token: 0x06000C75 RID: 3189 RVA: 0x00022C1C File Offset: 0x00020E1C
		public SolidColorBrush(RenderTarget renderTarget, RawColor4 color) : this(renderTarget, color, null)
		{
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00022C3A File Offset: 0x00020E3A
		public SolidColorBrush(RenderTarget renderTarget, RawColor4 color, BrushProperties? brushProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateSolidColorBrush(color, brushProperties, this);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00015A4C File Offset: 0x00013C4C
		public SolidColorBrush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x00022C50 File Offset: 0x00020E50
		public new static explicit operator SolidColorBrush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SolidColorBrush(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00022C67 File Offset: 0x00020E67
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x00022C6F File Offset: 0x00020E6F
		public RawColor4 Color
		{
			get
			{
				return this.GetColor();
			}
			set
			{
				this.SetColor(value);
			}
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x00022C78 File Offset: 0x00020E78
		internal unsafe void SetColor(RawColor4 color)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &color, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00022C9C File Offset: 0x00020E9C
		internal unsafe RawColor4 GetColor()
		{
			RawColor4 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			return result;
		}
	}
}
