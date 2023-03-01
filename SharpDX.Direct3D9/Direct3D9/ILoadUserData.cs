using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B1 RID: 177
	public class ILoadUserData : CppObject
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x00010519 File Offset: 0x0000E719
		public ILoadUserData(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00011DB6 File Offset: 0x0000FFB6
		public static explicit operator ILoadUserData(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new ILoadUserData(nativePointer);
			}
			return null;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00011DD0 File Offset: 0x0000FFD0
		public unsafe void LoadTopLevelData(XFileData xofChildDataRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((xofChildDataRef == null) ? IntPtr.Zero : xofChildDataRef.NativePointer), *(*(IntPtr*)this._nativePointer)).CheckError();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00011E14 File Offset: 0x00010014
		public unsafe void LoadFrameChildData(ref Frame frameRef, XFileData xofChildDataRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)((xofChildDataRef == null) ? IntPtr.Zero : xofChildDataRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)sizeof(void*)));
			frameRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00011E78 File Offset: 0x00010078
		public unsafe void LoadMeshChildData(MeshContainer meshContainerRef, XFileData xofChildDataRef)
		{
			MeshContainer.__Native _Native = default(MeshContainer.__Native);
			meshContainerRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)((xofChildDataRef == null) ? IntPtr.Zero : xofChildDataRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)2 * (IntPtr)sizeof(void*)));
			meshContainerRef.__MarshalFree(ref _Native);
			result.CheckError();
		}
	}
}
