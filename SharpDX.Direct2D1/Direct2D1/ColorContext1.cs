using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000181 RID: 385
	[Guid("1ab42875-c57f-4be9-bd85-9cd78d6f55ee")]
	public class ColorContext1 : ColorContext
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x000162FB File Offset: 0x000144FB
		public ColorContext1(DeviceContext5 context, ColorSpaceType colorSpace) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromDxgiColorSpace(colorSpace, this);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00016310 File Offset: 0x00014510
		public ColorContext1(DeviceContext5 context, ref SimpleColorProfile simpleProfile) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromSimpleColorProfile(ref simpleProfile, this);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00016325 File Offset: 0x00014525
		public ColorContext1(EffectContext2 context, ColorSpaceType colorSpace) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromDxgiColorSpace(colorSpace, this);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001633A File Offset: 0x0001453A
		public ColorContext1(EffectContext2 context, ref SimpleColorProfile simpleProfile) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromSimpleColorProfile(ref simpleProfile, this);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001634F File Offset: 0x0001454F
		public ColorContext1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00016358 File Offset: 0x00014558
		public new static explicit operator ColorContext1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorContext1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001636F File Offset: 0x0001456F
		public ColorContextType ColorContextType
		{
			get
			{
				return this.GetColorContextType();
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00016377 File Offset: 0x00014577
		public ColorSpaceType DXGIColorSpace
		{
			get
			{
				return this.GetDXGIColorSpace();
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00016380 File Offset: 0x00014580
		public SimpleColorProfile SimpleColorProfile
		{
			get
			{
				SimpleColorProfile result;
				this.GetSimpleColorProfile(out result);
				return result;
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00016396 File Offset: 0x00014596
		internal unsafe ColorContextType GetColorContextType()
		{
			return calli(SharpDX.Direct2D1.ColorContextType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000163B5 File Offset: 0x000145B5
		internal unsafe ColorSpaceType GetDXGIColorSpace()
		{
			return calli(SharpDX.DXGI.ColorSpaceType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000163D4 File Offset: 0x000145D4
		internal unsafe void GetSimpleColorProfile(out SimpleColorProfile simpleProfile)
		{
			simpleProfile = default(SimpleColorProfile);
			Result result;
			fixed (SimpleColorProfile* ptr = &simpleProfile)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
