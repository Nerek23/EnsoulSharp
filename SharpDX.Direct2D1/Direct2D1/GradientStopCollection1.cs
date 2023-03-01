using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F3 RID: 499
	[Guid("ae1572f4-5dd0-4777-998b-9279472ae63b")]
	public class GradientStopCollection1 : GradientStopCollection
	{
		// Token: 0x06000A8A RID: 2698 RVA: 0x0001E7A0 File Offset: 0x0001C9A0
		public GradientStopCollection1(DeviceContext context, GradientStop[] straightAlphaGradientStops, ColorSpace preInterpolationSpace, ColorSpace postInterpolationSpace, BufferPrecision bufferPrecision, ExtendMode extendMode, ColorInterpolationMode colorInterpolationMode) : base(IntPtr.Zero)
		{
			context.CreateGradientStopCollection(straightAlphaGradientStops, straightAlphaGradientStops.Length, preInterpolationSpace, postInterpolationSpace, bufferPrecision, extendMode, colorInterpolationMode, this);
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0001E7CC File Offset: 0x0001C9CC
		public GradientStopCollection1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0001E7D5 File Offset: 0x0001C9D5
		public new static explicit operator GradientStopCollection1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GradientStopCollection1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0001E7EC File Offset: 0x0001C9EC
		public ColorSpace PreInterpolationSpace
		{
			get
			{
				return this.GetPreInterpolationSpace();
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000A8E RID: 2702 RVA: 0x0001E7F4 File Offset: 0x0001C9F4
		public ColorSpace PostInterpolationSpace
		{
			get
			{
				return this.GetPostInterpolationSpace();
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0001E7FC File Offset: 0x0001C9FC
		public BufferPrecision BufferPrecision
		{
			get
			{
				return this.GetBufferPrecision();
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0001E804 File Offset: 0x0001CA04
		public ColorInterpolationMode ColorInterpolationMode
		{
			get
			{
				return this.GetColorInterpolationMode();
			}
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0001E80C File Offset: 0x0001CA0C
		public unsafe void GetGradientStops1(GradientStop[] gradientStops, int gradientStopsCount)
		{
			fixed (GradientStop[] array = gradientStops)
			{
				void* ptr;
				if (gradientStops == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, gradientStopsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0001E852 File Offset: 0x0001CA52
		internal unsafe ColorSpace GetPreInterpolationSpace()
		{
			return calli(SharpDX.Direct2D1.ColorSpace(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0001E872 File Offset: 0x0001CA72
		internal unsafe ColorSpace GetPostInterpolationSpace()
		{
			return calli(SharpDX.Direct2D1.ColorSpace(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0001E892 File Offset: 0x0001CA92
		internal unsafe BufferPrecision GetBufferPrecision()
		{
			return calli(SharpDX.Direct2D1.BufferPrecision(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0001E8B2 File Offset: 0x0001CAB2
		internal unsafe ColorInterpolationMode GetColorInterpolationMode()
		{
			return calli(SharpDX.Direct2D1.ColorInterpolationMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}
	}
}
