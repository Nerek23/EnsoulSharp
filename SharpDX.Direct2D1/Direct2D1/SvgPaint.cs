using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000311 RID: 785
	[Guid("d59bab0a-68a2-455b-a5dc-9eb2854e2490")]
	public class SvgPaint : SvgAttribute
	{
		// Token: 0x06000DD1 RID: 3537 RVA: 0x0002627D File Offset: 0x0002447D
		public SvgPaint(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00026286 File Offset: 0x00024486
		public new static explicit operator SvgPaint(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgPaint(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x0002629D File Offset: 0x0002449D
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x000262A5 File Offset: 0x000244A5
		public SvgPaintType PaintType
		{
			get
			{
				return this.GetPaintType();
			}
			set
			{
				this.SetPaintType(value);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x000262B0 File Offset: 0x000244B0
		// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x000262C6 File Offset: 0x000244C6
		public RawColor4 Color
		{
			get
			{
				RawColor4 result;
				this.GetColor(out result);
				return result;
			}
			set
			{
				this.SetColor(value);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x000262CF File Offset: 0x000244CF
		public int IdLength
		{
			get
			{
				return this.GetIdLength();
			}
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x000262D8 File Offset: 0x000244D8
		internal unsafe void SetPaintType(SvgPaintType paintType)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, paintType, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00026310 File Offset: 0x00024510
		internal unsafe SvgPaintType GetPaintType()
		{
			return calli(SharpDX.Direct2D1.SvgPaintType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00026330 File Offset: 0x00024530
		internal unsafe void SetColor(RawColor4 color)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &color, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x0002636C File Offset: 0x0002456C
		internal unsafe void GetColor(out RawColor4 color)
		{
			color = default(RawColor4);
			fixed (RawColor4* ptr = &color)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x000263A8 File Offset: 0x000245A8
		public unsafe void SetId(string id)
		{
			Result result;
			fixed (string text = id)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x000263F4 File Offset: 0x000245F4
		public unsafe void GetId(IntPtr id, int idCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)id, idCount, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00026433 File Offset: 0x00024633
		internal unsafe int GetIdLength()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}
	}
}
