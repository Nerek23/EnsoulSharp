using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000207 RID: 519
	[Guid("2cd906a5-12e2-11dc-9fed-001143a055f9")]
	public class PathGeometry : Geometry
	{
		// Token: 0x06000B11 RID: 2833 RVA: 0x0001F973 File Offset: 0x0001DB73
		public PathGeometry(Factory factory) : base(IntPtr.Zero)
		{
			factory.CreatePathGeometry(this);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0001C75D File Offset: 0x0001A95D
		public PathGeometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0001F987 File Offset: 0x0001DB87
		public new static explicit operator PathGeometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PathGeometry(nativePtr);
			}
			return null;
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0001F9A0 File Offset: 0x0001DBA0
		public int SegmentCount
		{
			get
			{
				int result;
				this.GetSegmentCount(out result);
				return result;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0001F9B8 File Offset: 0x0001DBB8
		public int FigureCount
		{
			get
			{
				int result;
				this.GetFigureCount(out result);
				return result;
			}
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0001F9D0 File Offset: 0x0001DBD0
		public unsafe GeometrySink Open()
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			GeometrySink result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new GeometrySinkNative(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0001FA2C File Offset: 0x0001DC2C
		public unsafe void Stream(GeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0001FA78 File Offset: 0x0001DC78
		internal unsafe void GetSegmentCount(out int count)
		{
			Result result;
			fixed (int* ptr = &count)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0001FABC File Offset: 0x0001DCBC
		internal unsafe void GetFigureCount(out int count)
		{
			Result result;
			fixed (int* ptr = &count)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
