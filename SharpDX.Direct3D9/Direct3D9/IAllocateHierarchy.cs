using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B0 RID: 176
	public class IAllocateHierarchy : CppObject
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x00010519 File Offset: 0x0000E719
		public IAllocateHierarchy(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00011BE1 File Offset: 0x0000FDE1
		public static explicit operator IAllocateHierarchy(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new IAllocateHierarchy(nativePointer);
			}
			return null;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00011BF8 File Offset: 0x0000FDF8
		public unsafe void CreateFrame(string name, ref Frame newFrameOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(name);
			Frame.__Native _Native = default(Frame.__Native);
			newFrameOut.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &_Native, *(*(IntPtr*)this._nativePointer));
			Marshal.FreeHGlobal(intPtr);
			newFrameOut.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00011C54 File Offset: 0x0000FE54
		public unsafe void CreateMeshContainer(string name, MeshData meshDataRef, ref ExtendedMaterial materialsRef, EffectInstance effectInstancesRef, int numMaterials, int adjacencyRef, SkinInfo skinInfoRef, MeshContainer newMeshContainerOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(name);
			ExtendedMaterial.__Native _Native = default(ExtendedMaterial.__Native);
			materialsRef.__MarshalTo(ref _Native);
			EffectInstance.__Native _Native2 = default(EffectInstance.__Native);
			effectInstancesRef.__MarshalTo(ref _Native2);
			MeshContainer.__Native _Native3 = default(MeshContainer.__Native);
			newMeshContainerOut.__MarshalTo(ref _Native3);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &meshDataRef, &_Native, &_Native2, numMaterials, &adjacencyRef, (void*)((skinInfoRef == null) ? IntPtr.Zero : skinInfoRef.NativePointer), &_Native3, *(*(IntPtr*)this._nativePointer + (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			materialsRef.__MarshalFree(ref _Native);
			effectInstancesRef.__MarshalFree(ref _Native2);
			newMeshContainerOut.__MarshalFree(ref _Native3);
			result.CheckError();
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00011D10 File Offset: 0x0000FF10
		public unsafe void DestroyFrame(ref Frame frameToFreeRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameToFreeRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)2 * (IntPtr)sizeof(void*)));
			frameToFreeRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00011D64 File Offset: 0x0000FF64
		public unsafe void DestroyMeshContainer(MeshContainer meshContainerToFreeRef)
		{
			MeshContainer.__Native _Native = default(MeshContainer.__Native);
			meshContainerToFreeRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			meshContainerToFreeRef.__MarshalFree(ref _Native);
			result.CheckError();
		}
	}
}
