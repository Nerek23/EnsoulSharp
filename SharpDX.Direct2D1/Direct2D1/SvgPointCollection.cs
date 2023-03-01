using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000313 RID: 787
	[Guid("9dbe4c0d-3572-4dd9-9825-5530813bb712")]
	public class SvgPointCollection : SvgAttribute
	{
		// Token: 0x06000DEC RID: 3564 RVA: 0x0002627D File Offset: 0x0002447D
		public SvgPointCollection(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x000266E4 File Offset: 0x000248E4
		public new static explicit operator SvgPointCollection(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgPointCollection(nativePtr);
			}
			return null;
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x000266FB File Offset: 0x000248FB
		public int PointsCount
		{
			get
			{
				return this.GetPointsCount();
			}
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00026704 File Offset: 0x00024904
		public unsafe void RemovePointsAtEnd(int pointsCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, pointsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0002673C File Offset: 0x0002493C
		public unsafe void UpdatePoints(RawVector2[] ointsRef, int pointsCount, int startIndex)
		{
			Result result;
			fixed (RawVector2[] array = ointsRef)
			{
				void* ptr;
				if (ointsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, pointsCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00026790 File Offset: 0x00024990
		public unsafe void GetPoints(RawVector2[] ointsRef, int pointsCount, int startIndex)
		{
			Result result;
			fixed (RawVector2[] array = ointsRef)
			{
				void* ptr;
				if (ointsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, pointsCount, startIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0002655C File Offset: 0x0002475C
		internal unsafe int GetPointsCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}
	}
}
