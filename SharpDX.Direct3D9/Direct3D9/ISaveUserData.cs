using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B4 RID: 180
	public class ISaveUserData : CppObject
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x00010519 File Offset: 0x0000E719
		public ISaveUserData(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001209D File Offset: 0x0001029D
		public static explicit operator ISaveUserData(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new ISaveUserData(nativePointer);
			}
			return null;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000120B4 File Offset: 0x000102B4
		public unsafe void AddFrameChildData(ref Frame frameRef, XFileSaveObject xofSaveRef, XFileSaveData xofFrameDataRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)((xofSaveRef == null) ? IntPtr.Zero : xofSaveRef.NativePointer), (void*)((xofFrameDataRef == null) ? IntPtr.Zero : xofFrameDataRef.NativePointer), *(*(IntPtr*)this._nativePointer));
			frameRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00012128 File Offset: 0x00010328
		public unsafe void AddMeshChildData(MeshContainer meshContainerRef, XFileSaveObject xofSaveRef, XFileSaveData xofMeshDataRef)
		{
			MeshContainer.__Native _Native = default(MeshContainer.__Native);
			meshContainerRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)((xofSaveRef == null) ? IntPtr.Zero : xofSaveRef.NativePointer), (void*)((xofMeshDataRef == null) ? IntPtr.Zero : xofMeshDataRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)sizeof(void*)));
			meshContainerRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000121A4 File Offset: 0x000103A4
		public unsafe void AddTopLevelDataObjectsPre(XFileSaveObject xofSaveRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((xofSaveRef == null) ? IntPtr.Zero : xofSaveRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)2 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000121F0 File Offset: 0x000103F0
		public unsafe void AddTopLevelDataObjectsPost(XFileSaveObject xofSaveRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((xofSaveRef == null) ? IntPtr.Zero : xofSaveRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001223C File Offset: 0x0001043C
		public unsafe void RegisterTemplates(XFile xFileApiRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((xFileApiRef == null) ? IntPtr.Zero : xFileApiRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00012288 File Offset: 0x00010488
		public unsafe void SaveTemplates(XFileSaveObject xofSaveRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((xofSaveRef == null) ? IntPtr.Zero : xofSaveRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
