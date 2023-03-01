using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000314 RID: 788
	[Guid("f1c0ca52-92a3-4f00-b4ce-f35691efd9d9")]
	public class SvgStrokeDashArray : SvgAttribute
	{
		// Token: 0x06000DF3 RID: 3571 RVA: 0x0002627D File Offset: 0x0002447D
		public SvgStrokeDashArray(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x000267E4 File Offset: 0x000249E4
		public new static explicit operator SvgStrokeDashArray(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgStrokeDashArray(nativePtr);
			}
			return null;
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x000267FB File Offset: 0x000249FB
		public int DashesCount
		{
			get
			{
				return this.GetDashesCount();
			}
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00026804 File Offset: 0x00024A04
		public unsafe void RemoveDashesAtEnd(int dashesCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, dashesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0002683C File Offset: 0x00024A3C
		public unsafe void UpdateDashes(SvgLength[] dashes, int dashesCount, int startIndex)
		{
			Result result;
			fixed (SvgLength[] array = dashes)
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dashesCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00026890 File Offset: 0x00024A90
		public unsafe void UpdateDashes(float[] dashes, int dashesCount, int startIndex)
		{
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dashesCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x000268E4 File Offset: 0x00024AE4
		public unsafe void GetDashes(SvgLength[] dashes, int dashesCount, int startIndex)
		{
			Result result;
			fixed (SvgLength[] array = dashes)
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dashesCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x0002693C File Offset: 0x00024B3C
		public unsafe void GetDashes(float[] dashes, int dashesCount, int startIndex)
		{
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, dashesCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x000232B0 File Offset: 0x000214B0
		internal unsafe int GetDashesCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}
	}
}
