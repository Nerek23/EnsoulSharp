using System;
using System.Runtime.InteropServices;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000180 RID: 384
	[Guid("1c4820bb-5771-4518-a581-2fe4dd0ec657")]
	public class ColorContext : Resource
	{
		// Token: 0x0600071D RID: 1821 RVA: 0x000161EE File Offset: 0x000143EE
		public ColorContext(EffectContext context, ColorSpace space, byte[] profileRef) : base(IntPtr.Zero)
		{
			context.CreateColorContext(space, profileRef, profileRef.Length, this);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00016207 File Offset: 0x00014407
		public ColorContext(EffectContext context, string filename) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromFilename(filename, this);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001621C File Offset: 0x0001441C
		public ColorContext(EffectContext context, ColorContext wicColorContext) : base(IntPtr.Zero)
		{
			context.CreateColorContextFromWicColorContext(wicColorContext, this);
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00016234 File Offset: 0x00014434
		public byte[] ProfileData
		{
			get
			{
				byte[] array = new byte[this.ProfileSize];
				this.GetProfile(array, array.Length);
				return array;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00016258 File Offset: 0x00014458
		public ColorContext(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00016261 File Offset: 0x00014461
		public new static explicit operator ColorContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorContext(nativePtr);
			}
			return null;
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00016278 File Offset: 0x00014478
		public ColorSpace ColorSpace
		{
			get
			{
				return this.GetColorSpace();
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00016280 File Offset: 0x00014480
		internal int ProfileSize
		{
			get
			{
				return this.GetProfileSize();
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00016288 File Offset: 0x00014488
		internal unsafe ColorSpace GetColorSpace()
		{
			return calli(SharpDX.Direct2D1.ColorSpace(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0000B67C File Offset: 0x0000987C
		internal unsafe int GetProfileSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x000162A8 File Offset: 0x000144A8
		internal unsafe void GetProfile(byte[] rofileRef, int profileSize)
		{
			Result result;
			fixed (byte[] array = rofileRef)
			{
				void* ptr;
				if (rofileRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, profileSize, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
