using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E6 RID: 486
	[Guid("2cd906a6-12e2-11dc-9fed-001143a055f9")]
	public class GeometryGroup : Geometry
	{
		// Token: 0x06000A3A RID: 2618 RVA: 0x0001E223 File Offset: 0x0001C423
		public GeometryGroup(Factory factory, FillMode fillMode, Geometry[] geometries) : base(IntPtr.Zero)
		{
			factory.CreateGeometryGroup(fillMode, geometries, geometries.Length, this);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0001E23C File Offset: 0x0001C43C
		public Geometry[] GetSourceGeometry()
		{
			return this.GetSourceGeometry(this.SourceGeometryCount);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0001E24C File Offset: 0x0001C44C
		public Geometry[] GetSourceGeometry(int geometriesCount)
		{
			Geometry[] array = new Geometry[geometriesCount];
			this.GetSourceGeometries(array, geometriesCount);
			return array;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0001C75D File Offset: 0x0001A95D
		public GeometryGroup(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0001E269 File Offset: 0x0001C469
		public new static explicit operator GeometryGroup(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GeometryGroup(nativePtr);
			}
			return null;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x0001E280 File Offset: 0x0001C480
		public FillMode FillMode
		{
			get
			{
				return this.GetFillMode();
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x0001E288 File Offset: 0x0001C488
		public int SourceGeometryCount
		{
			get
			{
				return this.GetSourceGeometryCount();
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0001E290 File Offset: 0x0001C490
		internal unsafe FillMode GetFillMode()
		{
			return calli(SharpDX.Direct2D1.FillMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
		internal unsafe int GetSourceGeometryCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0001E2D0 File Offset: 0x0001C4D0
		internal unsafe void GetSourceGeometries(Geometry[] geometries, int geometriesCount)
		{
			IntPtr* ptr = null;
			ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)geometries.Length) * (UIntPtr)sizeof(IntPtr))];
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, geometriesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			for (int i = 0; i < geometries.Length; i++)
			{
				if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
				{
					geometries[i] = new Geometry(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				}
				else
				{
					geometries[i] = null;
				}
			}
		}
	}
}
