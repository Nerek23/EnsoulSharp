using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F1 RID: 497
	[Guid("f292e401-c050-4cde-83d7-04962d3b23c2")]
	public class GradientMesh : Resource
	{
		// Token: 0x06000A77 RID: 2679 RVA: 0x0001E622 File Offset: 0x0001C822
		public GradientMesh(DeviceContext2 context2, GradientMeshPatch[] atchesRef, int patchesCount) : this(IntPtr.Zero)
		{
			context2.CreateGradientMesh(atchesRef, patchesCount, this);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00016258 File Offset: 0x00014458
		public GradientMesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0001E638 File Offset: 0x0001C838
		public new static explicit operator GradientMesh(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GradientMesh(nativePtr);
			}
			return null;
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0001E64F File Offset: 0x0001C84F
		public int PatchCount
		{
			get
			{
				return this.GetPatchCount();
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00010018 File Offset: 0x0000E218
		internal unsafe int GetPatchCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0001E658 File Offset: 0x0001C858
		public unsafe void GetPatches(int startIndex, GradientMeshPatch[] atchesRef, int patchesCount)
		{
			Result result;
			fixed (GradientMeshPatch[] array = atchesRef)
			{
				void* ptr;
				if (atchesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startIndex, ptr, patchesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
