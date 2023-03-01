using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000A8 RID: 168
	internal static class D3DX9
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x0000AFFC File Offset: 0x000091FC
		public unsafe static void SetMarker(RawColorBGRA col, string wszName)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(wszName);
			D3DX9.D3DPERF_SetMarker_(col, (void*)intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x060002D9 RID: 729
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_SetMarker")]
		private unsafe static extern void D3DPERF_SetMarker_(RawColorBGRA arg0, void* arg1);

		// Token: 0x060002DA RID: 730 RVA: 0x0000B022 File Offset: 0x00009222
		public static void SetOptions(int dwOptions)
		{
			D3DX9.D3DPERF_SetOptions_(dwOptions);
		}

		// Token: 0x060002DB RID: 731
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_SetOptions")]
		private static extern void D3DPERF_SetOptions_(int arg0);

		// Token: 0x060002DC RID: 732 RVA: 0x0000B02A File Offset: 0x0000922A
		public static int GetStatus()
		{
			return D3DX9.D3DPERF_GetStatus_();
		}

		// Token: 0x060002DD RID: 733
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_GetStatus")]
		private static extern int D3DPERF_GetStatus_();

		// Token: 0x060002DE RID: 734 RVA: 0x0000B034 File Offset: 0x00009234
		public unsafe static void SetRegion(RawColorBGRA col, string wszName)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(wszName);
			D3DX9.D3DPERF_SetRegion_(col, (void*)intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x060002DF RID: 735
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_SetRegion")]
		private unsafe static extern void D3DPERF_SetRegion_(RawColorBGRA arg0, void* arg1);

		// Token: 0x060002E0 RID: 736 RVA: 0x0000B05A File Offset: 0x0000925A
		public static int EndEvent()
		{
			return D3DX9.D3DPERF_EndEvent_();
		}

		// Token: 0x060002E1 RID: 737
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_EndEvent")]
		private static extern int D3DPERF_EndEvent_();

		// Token: 0x060002E2 RID: 738 RVA: 0x0000B064 File Offset: 0x00009264
		public unsafe static int BeginEvent(RawColorBGRA col, string wszName)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(wszName);
			int result = D3DX9.D3DPERF_BeginEvent_(col, (void*)intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x060002E3 RID: 739
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_BeginEvent")]
		private unsafe static extern int D3DPERF_BeginEvent_(RawColorBGRA arg0, void* arg1);

		// Token: 0x060002E4 RID: 740 RVA: 0x0000B08A File Offset: 0x0000928A
		public static RawBool QueryRepeatFrame()
		{
			return D3DX9.D3DPERF_QueryRepeatFrame_();
		}

		// Token: 0x060002E5 RID: 741
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPERF_QueryRepeatFrame")]
		private static extern RawBool D3DPERF_QueryRepeatFrame_();

		// Token: 0x060002E6 RID: 742 RVA: 0x0000B094 File Offset: 0x00009294
		public unsafe static void FrameAppendChild(ref Frame frameParentRef, ref Frame frameChildRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameParentRef.__MarshalTo(ref _Native);
			Frame.__Native _Native2 = default(Frame.__Native);
			frameChildRef.__MarshalTo(ref _Native2);
			Result result = D3DX9.D3DXFrameAppendChild_((void*)(&_Native), (void*)(&_Native2));
			frameParentRef.__MarshalFree(ref _Native);
			frameChildRef.__MarshalFree(ref _Native2);
			result.CheckError();
		}

		// Token: 0x060002E7 RID: 743
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameAppendChild")]
		private unsafe static extern int D3DXFrameAppendChild_(void* arg0, void* arg1);

		// Token: 0x060002E8 RID: 744 RVA: 0x0000B0EC File Offset: 0x000092EC
		public unsafe static void LoadMeshHierarchyFromXW(string filename, int meshOptions, Device d3DDeviceRef, IAllocateHierarchy allocRef, ILoadUserData userDataLoaderRef, ref Frame frameHierarchyOut, out AnimationController animControllerOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(filename);
			Frame.__Native _Native = default(Frame.__Native);
			frameHierarchyOut.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshHierarchyFromXW_((void*)intPtr, meshOptions, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)((allocRef == null) ? IntPtr.Zero : allocRef.NativePointer), (void*)((userDataLoaderRef == null) ? IntPtr.Zero : userDataLoaderRef.NativePointer), (void*)(&_Native), (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			frameHierarchyOut.__MarshalFree(ref _Native);
			animControllerOut = ((zero == IntPtr.Zero) ? null : new AnimationController(zero));
			result.CheckError();
		}

		// Token: 0x060002E9 RID: 745
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshHierarchyFromXW")]
		private unsafe static extern int D3DXLoadMeshHierarchyFromXW_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x060002EA RID: 746 RVA: 0x0000B1A0 File Offset: 0x000093A0
		public unsafe static void FrameRegisterNamedMatrices(ref Frame frameRootRef, AnimationController animControllerRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			Result result = D3DX9.D3DXFrameRegisterNamedMatrices_((void*)(&_Native), (void*)((animControllerRef == null) ? IntPtr.Zero : animControllerRef.NativePointer));
			frameRootRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002EB RID: 747
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameRegisterNamedMatrices")]
		private unsafe static extern int D3DXFrameRegisterNamedMatrices_(void* arg0, void* arg1);

		// Token: 0x060002EC RID: 748 RVA: 0x0000B1F0 File Offset: 0x000093F0
		public unsafe static void LoadMeshHierarchyFromXInMemory(IntPtr memory, int sizeOfMemory, int meshOptions, Device d3DDeviceRef, IAllocateHierarchy allocRef, ILoadUserData userDataLoaderRef, ref Frame frameHierarchyOut, out AnimationController animControllerOut)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameHierarchyOut.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshHierarchyFromXInMemory_((void*)memory, sizeOfMemory, meshOptions, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)((allocRef == null) ? IntPtr.Zero : allocRef.NativePointer), (void*)((userDataLoaderRef == null) ? IntPtr.Zero : userDataLoaderRef.NativePointer), (void*)(&_Native), (void*)(&zero));
			frameHierarchyOut.__MarshalFree(ref _Native);
			animControllerOut = ((zero == IntPtr.Zero) ? null : new AnimationController(zero));
			result.CheckError();
		}

		// Token: 0x060002ED RID: 749
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshHierarchyFromXInMemory")]
		private unsafe static extern int D3DXLoadMeshHierarchyFromXInMemory_(void* arg0, int arg1, int arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x060002EE RID: 750 RVA: 0x0000B29C File Offset: 0x0000949C
		public unsafe static void CreateCompressedAnimationSet(string nameRef, double ticksPerSecond, PlaybackType playback, Blob compressedDataRef, int numCallbackKeys, CallbackKey callbackKeysRef, out CompressedAnimationSet animationSetOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCompressedAnimationSet_((void*)intPtr, ticksPerSecond, (int)playback, (void*)((compressedDataRef == null) ? IntPtr.Zero : compressedDataRef.NativePointer), numCallbackKeys, (void*)(&callbackKeysRef), (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			animationSetOut = ((zero == IntPtr.Zero) ? null : new CompressedAnimationSet(zero));
			result.CheckError();
		}

		// Token: 0x060002EF RID: 751
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCompressedAnimationSet")]
		private unsafe static extern int D3DXCreateCompressedAnimationSet_(void* arg0, double arg1, int arg2, void* arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x060002F0 RID: 752 RVA: 0x0000B30C File Offset: 0x0000950C
		public unsafe static void SaveMeshHierarchyToFileW(string filename, int xFormat, ref Frame frameRootRef, AnimationController animControllerRef, ISaveUserData userDataSaverRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(filename);
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			Result result = D3DX9.D3DXSaveMeshHierarchyToFileW_((void*)intPtr, xFormat, (void*)(&_Native), (void*)((animControllerRef == null) ? IntPtr.Zero : animControllerRef.NativePointer), (void*)((userDataSaverRef == null) ? IntPtr.Zero : userDataSaverRef.NativePointer));
			Marshal.FreeHGlobal(intPtr);
			frameRootRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002F1 RID: 753
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveMeshHierarchyToFileW")]
		private unsafe static extern int D3DXSaveMeshHierarchyToFileW_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x060002F2 RID: 754 RVA: 0x0000B384 File Offset: 0x00009584
		public unsafe static void FrameCalculateBoundingSphere(ref Frame frameRootRef, RawVector3 objectCenterRef, float objectRadiusRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			Result result = D3DX9.D3DXFrameCalculateBoundingSphere_((void*)(&_Native), (void*)(&objectCenterRef), (void*)(&objectRadiusRef));
			frameRootRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002F3 RID: 755
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameCalculateBoundingSphere")]
		private unsafe static extern int D3DXFrameCalculateBoundingSphere_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060002F4 RID: 756 RVA: 0x0000B3C4 File Offset: 0x000095C4
		public unsafe static void CreateAnimationController(int maxNumMatrices, int maxNumAnimationSets, int maxNumTracks, int maxNumEvents, out AnimationController animControllerOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateAnimationController_(maxNumMatrices, maxNumAnimationSets, maxNumTracks, maxNumEvents, (void*)(&zero));
			animControllerOut = ((zero == IntPtr.Zero) ? null : new AnimationController(zero));
			result.CheckError();
		}

		// Token: 0x060002F5 RID: 757
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateAnimationController")]
		private unsafe static extern int D3DXCreateAnimationController_(int arg0, int arg1, int arg2, int arg3, void* arg4);

		// Token: 0x060002F6 RID: 758 RVA: 0x0000B40C File Offset: 0x0000960C
		public unsafe static Frame FrameFind(ref Frame frameRootRef, string name)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(name);
			Frame result = D3DX9.D3DXFrameFind_((void*)(&_Native), (void*)intPtr);
			frameRootRef.__MarshalFree(ref _Native);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x060002F7 RID: 759
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameFind")]
		private unsafe static extern Frame D3DXFrameFind_(void* arg0, void* arg1);

		// Token: 0x060002F8 RID: 760 RVA: 0x0000B44C File Offset: 0x0000964C
		public unsafe static void CreateKeyframedAnimationSet(string nameRef, double ticksPerSecond, PlaybackType playback, int numAnimations, int numCallbackKeys, CallbackKey callbackKeysRef, out KeyframedAnimationSet animationSetOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateKeyframedAnimationSet_((void*)intPtr, ticksPerSecond, (int)playback, numAnimations, numCallbackKeys, (void*)(&callbackKeysRef), (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			animationSetOut = ((zero == IntPtr.Zero) ? null : new KeyframedAnimationSet(zero));
			result.CheckError();
		}

		// Token: 0x060002F9 RID: 761
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateKeyframedAnimationSet")]
		private unsafe static extern int D3DXCreateKeyframedAnimationSet_(void* arg0, double arg1, int arg2, int arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x060002FA RID: 762 RVA: 0x0000B4A8 File Offset: 0x000096A8
		public unsafe static void FrameDestroy(ref Frame frameRootRef, IAllocateHierarchy allocRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			Result result = D3DX9.D3DXFrameDestroy_((void*)(&_Native), (void*)((allocRef == null) ? IntPtr.Zero : allocRef.NativePointer));
			frameRootRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002FB RID: 763
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameDestroy")]
		private unsafe static extern int D3DXFrameDestroy_(void* arg0, void* arg1);

		// Token: 0x060002FC RID: 764 RVA: 0x0000B4F8 File Offset: 0x000096F8
		public unsafe static int FrameNumNamedMatrices(ref Frame frameRootRef)
		{
			Frame.__Native _Native = default(Frame.__Native);
			frameRootRef.__MarshalTo(ref _Native);
			int result = D3DX9.D3DXFrameNumNamedMatrices_((void*)(&_Native));
			frameRootRef.__MarshalFree(ref _Native);
			return result;
		}

		// Token: 0x060002FD RID: 765
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFrameNumNamedMatrices")]
		private unsafe static extern int D3DXFrameNumNamedMatrices_(void* arg0);

		// Token: 0x060002FE RID: 766 RVA: 0x0000B528 File Offset: 0x00009728
		public unsafe static void CreateRenderToEnvMap(Device deviceRef, int size, int mipLevels, Format format, RawBool depthStencil, Format depthStencilFormat, out RenderToEnvironmentMap renderToEnvMapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateRenderToEnvMap_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), size, mipLevels, (int)format, depthStencil, (int)depthStencilFormat, (void*)(&zero));
			renderToEnvMapOut = ((zero == IntPtr.Zero) ? null : new RenderToEnvironmentMap(zero));
			result.CheckError();
		}

		// Token: 0x060002FF RID: 767
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateRenderToEnvMap")]
		private unsafe static extern int D3DXCreateRenderToEnvMap_(void* arg0, int arg1, int arg2, int arg3, RawBool arg4, int arg5, void* arg6);

		// Token: 0x06000300 RID: 768 RVA: 0x0000B585 File Offset: 0x00009785
		public unsafe static int GetDriverLevel(Device deviceRef)
		{
			return D3DX9.D3DXGetDriverLevel_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer));
		}

		// Token: 0x06000301 RID: 769
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetDriverLevel")]
		private unsafe static extern int D3DXGetDriverLevel_(void* arg0);

		// Token: 0x06000302 RID: 770 RVA: 0x0000B5A4 File Offset: 0x000097A4
		public unsafe static void CreateFont(Device deviceRef, int height, int width, int weight, int mipLevels, RawBool italic, int charSet, int outputPrecision, int quality, int pitchAndFamily, string faceNameRef, Font fontOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(faceNameRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateFontW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), height, width, weight, mipLevels, italic, charSet, outputPrecision, quality, pitchAndFamily, (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			fontOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000303 RID: 771
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateFontW")]
		private unsafe static extern int D3DXCreateFontW_(void* arg0, int arg1, int arg2, int arg3, int arg4, RawBool arg5, int arg6, int arg7, int arg8, int arg9, void* arg10, void* arg11);

		// Token: 0x06000304 RID: 772 RVA: 0x0000B60C File Offset: 0x0000980C
		public unsafe static void CreateRenderToSurface(Device deviceRef, int width, int height, Format format, RawBool depthStencil, Format depthStencilFormat, RenderToSurface renderToSurfaceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateRenderToSurface_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), width, height, (int)format, depthStencil, (int)depthStencilFormat, (void*)(&zero));
			renderToSurfaceOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000305 RID: 773
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateRenderToSurface")]
		private unsafe static extern int D3DXCreateRenderToSurface_(void* arg0, int arg1, int arg2, int arg3, RawBool arg4, int arg5, void* arg6);

		// Token: 0x06000306 RID: 774 RVA: 0x0000B658 File Offset: 0x00009858
		public unsafe static void CreateSprite(Device deviceRef, Sprite spriteOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSprite_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)(&zero));
			spriteOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000307 RID: 775
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSprite")]
		private unsafe static extern int D3DXCreateSprite_(void* arg0, void* arg1);

		// Token: 0x06000308 RID: 776 RVA: 0x0000B69C File Offset: 0x0000989C
		public unsafe static void CreateFontIndirect(Device deviceRef, ref FontDescription descRef, Font fontOut)
		{
			FontDescription.__Native _Native = default(FontDescription.__Native);
			descRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateFontIndirectW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)(&_Native), (void*)(&zero));
			descRef.__MarshalFree(ref _Native);
			fontOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000309 RID: 777
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateFontIndirectW")]
		private unsafe static extern int D3DXCreateFontIndirectW_(void* arg0, void* arg1, void* arg2);

		// Token: 0x0600030A RID: 778 RVA: 0x0000B6FC File Offset: 0x000098FC
		public unsafe static void CreateLine(Device deviceRef, Line lineOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateLine_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)(&zero));
			lineOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600030B RID: 779
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateLine")]
		private unsafe static extern int D3DXCreateLine_(void* arg0, void* arg1);

		// Token: 0x0600030C RID: 780 RVA: 0x0000B740 File Offset: 0x00009940
		public static RawBool DebugMute(RawBool mute)
		{
			return D3DX9.D3DXDebugMute_(mute);
		}

		// Token: 0x0600030D RID: 781
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXDebugMute")]
		private static extern RawBool D3DXDebugMute_(RawBool arg0);

		// Token: 0x0600030E RID: 782 RVA: 0x0000B748 File Offset: 0x00009948
		public static RawBool CheckVersion(int d3DSdkVersion, int d3DXSdkVersion)
		{
			return D3DX9.D3DXCheckVersion_(d3DSdkVersion, d3DXSdkVersion);
		}

		// Token: 0x0600030F RID: 783
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCheckVersion")]
		private static extern RawBool D3DXCheckVersion_(int arg0, int arg1);

		// Token: 0x06000310 RID: 784 RVA: 0x0000B754 File Offset: 0x00009954
		public unsafe static void CreateEffect(Device deviceRef, IntPtr srcDataRef, int srcDataLen, Macro[] definesRef, IntPtr includeRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffect_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataLen, arg, (void*)includeRef, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000311 RID: 785
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffect")]
		private unsafe static extern int D3DXCreateEffect_(void* arg0, void* arg1, int arg2, void* arg3, void* arg4, int arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x06000312 RID: 786 RVA: 0x0000B878 File Offset: 0x00009A78
		public unsafe static void DisassembleEffect(Effect effectRef, RawBool enableColorCode, out Blob disassemblyOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXDisassembleEffect_((void*)((effectRef == null) ? IntPtr.Zero : effectRef.NativePointer), enableColorCode, (void*)(&zero));
			disassemblyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000313 RID: 787
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXDisassembleEffect")]
		private unsafe static extern int D3DXDisassembleEffect_(void* arg0, RawBool arg1, void* arg2);

		// Token: 0x06000314 RID: 788 RVA: 0x0000B8D0 File Offset: 0x00009AD0
		public unsafe static void CreateEffectFromResourceExW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, string skipConstantsRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(skipConstantsRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectFromResourceExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, (void*)intPtr2, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr2);
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000315 RID: 789
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectFromResourceExW")]
		private unsafe static extern int D3DXCreateEffectFromResourceExW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x06000316 RID: 790 RVA: 0x0000BA20 File Offset: 0x00009C20
		public unsafe static void CreateEffectFromResourceW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectFromResourceW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000317 RID: 791
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectFromResourceW")]
		private unsafe static extern int D3DXCreateEffectFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x06000318 RID: 792 RVA: 0x0000BB58 File Offset: 0x00009D58
		public unsafe static void CreateEffectCompiler(IntPtr srcDataRef, int srcDataLen, Macro[] definesRef, IntPtr includeRef, int flags, EffectCompiler compilerOut, out Blob parseErrorsOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectCompiler_((void*)srcDataRef, srcDataLen, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			compilerOut.NativePointer = zero;
			parseErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000319 RID: 793
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectCompiler")]
		private unsafe static extern int D3DXCreateEffectCompiler_(void* arg0, int arg1, void* arg2, void* arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x0600031A RID: 794 RVA: 0x0000BC40 File Offset: 0x00009E40
		public unsafe static void CreateEffectFromFileExW(Device deviceRef, string srcFileRef, Macro[] definesRef, IntPtr includeRef, string skipConstantsRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(skipConstantsRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectFromFileExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, arg, (void*)includeRef, (void*)intPtr2, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr2);
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x0600031B RID: 795
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectFromFileExW")]
		private unsafe static extern int D3DXCreateEffectFromFileExW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x0600031C RID: 796 RVA: 0x0000BD88 File Offset: 0x00009F88
		public unsafe static void CreateEffectCompilerFromFileW(string srcFileRef, Macro[] definesRef, IntPtr includeRef, int flags, out EffectCompiler compilerOut, out Blob parseErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectCompilerFromFileW_((void*)intPtr, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			compilerOut = ((zero == IntPtr.Zero) ? null : new EffectCompiler(zero));
			parseErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x0600031D RID: 797
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectCompilerFromFileW")]
		private unsafe static extern int D3DXCreateEffectCompilerFromFileW_(void* arg0, void* arg1, void* arg2, int arg3, void* arg4, void* arg5);

		// Token: 0x0600031E RID: 798 RVA: 0x0000BE8C File Offset: 0x0000A08C
		public unsafe static void CreateEffectCompilerFromResourceW(IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, int flags, out EffectCompiler compilerOut, out Blob parseErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectCompilerFromResourceW_((void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			compilerOut = ((zero == IntPtr.Zero) ? null : new EffectCompiler(zero));
			parseErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x0600031F RID: 799
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectCompilerFromResourceW")]
		private unsafe static extern int D3DXCreateEffectCompilerFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x06000320 RID: 800 RVA: 0x0000BF98 File Offset: 0x0000A198
		public unsafe static void CreateEffectFromFileW(Device deviceRef, string srcFileRef, Macro[] definesRef, IntPtr includeRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectFromFileW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, arg, (void*)includeRef, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000321 RID: 801
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectFromFileW")]
		private unsafe static extern int D3DXCreateEffectFromFileW_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000322 RID: 802 RVA: 0x0000C0C8 File Offset: 0x0000A2C8
		public unsafe static void CreateEffectPool(EffectPool poolOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateEffectPool_((void*)(&zero));
			poolOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000323 RID: 803
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectPool")]
		private unsafe static extern int D3DXCreateEffectPool_(void* arg0);

		// Token: 0x06000324 RID: 804 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
		public unsafe static void CreateEffectEx(Device deviceRef, IntPtr srcDataRef, int srcDataLen, Macro[] definesRef, IntPtr includeRef, string skipConstantsRef, int flags, EffectPool poolRef, out Effect effectOut, out Blob compilationErrorsOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(skipConstantsRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCreateEffectEx_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataLen, arg, (void*)includeRef, (void*)intPtr, flags, (void*)((poolRef == null) ? IntPtr.Zero : poolRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr);
			effectOut = ((zero == IntPtr.Zero) ? null : new Effect(zero));
			compilationErrorsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000325 RID: 805
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateEffectEx")]
		private unsafe static extern int D3DXCreateEffectEx_(void* arg0, void* arg1, int arg2, void* arg3, void* arg4, void* arg5, int arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x06000326 RID: 806 RVA: 0x0000C234 File Offset: 0x0000A434
		public unsafe static void SaveMeshToXW(string filenameRef, Mesh meshRef, int adjacencyRef, ref ExtendedMaterial materialsRef, EffectInstance effectInstancesRef, int numMaterials, int format)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(filenameRef);
			ExtendedMaterial.__Native _Native = default(ExtendedMaterial.__Native);
			materialsRef.__MarshalTo(ref _Native);
			EffectInstance.__Native _Native2 = default(EffectInstance.__Native);
			effectInstancesRef.__MarshalTo(ref _Native2);
			Result result = D3DX9.D3DXSaveMeshToXW_((void*)intPtr, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&adjacencyRef), (void*)(&_Native), (void*)(&_Native2), numMaterials, format);
			Marshal.FreeHGlobal(intPtr);
			materialsRef.__MarshalFree(ref _Native);
			effectInstancesRef.__MarshalFree(ref _Native2);
			result.CheckError();
		}

		// Token: 0x06000327 RID: 807
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveMeshToXW")]
		private unsafe static extern int D3DXSaveMeshToXW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, int arg6);

		// Token: 0x06000328 RID: 808 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
		public unsafe static void CreateNPatchMesh(Mesh meshSysMemRef, out PatchMesh patchMeshRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateNPatchMesh_((void*)((meshSysMemRef == null) ? IntPtr.Zero : meshSysMemRef.NativePointer), (void*)(&zero));
			patchMeshRef = ((zero == IntPtr.Zero) ? null : new PatchMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000329 RID: 809
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateNPatchMesh")]
		private unsafe static extern int D3DXCreateNPatchMesh_(void* arg0, void* arg1);

		// Token: 0x0600032A RID: 810 RVA: 0x0000C310 File Offset: 0x0000A510
		public unsafe static Result DeclaratorFromFVF(VertexFormat fvf, VertexElement[] declaratorRef)
		{
			Result result;
			fixed (VertexElement[] array = declaratorRef)
			{
				void* arg;
				if (declaratorRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXDeclaratorFromFVF_((int)fvf, arg);
			}
			return result;
		}

		// Token: 0x0600032B RID: 811
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXDeclaratorFromFVF")]
		private unsafe static extern int D3DXDeclaratorFromFVF_(int arg0, void* arg1);

		// Token: 0x0600032C RID: 812 RVA: 0x0000C344 File Offset: 0x0000A544
		public unsafe static void ComputeTangentFrame(Mesh meshRef, int dwOptions)
		{
			D3DX9.D3DXComputeTangentFrame_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), dwOptions).CheckError();
		}

		// Token: 0x0600032D RID: 813
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeTangentFrame")]
		private unsafe static extern int D3DXComputeTangentFrame_(void* arg0, int arg1);

		// Token: 0x0600032E RID: 814 RVA: 0x0000C37C File Offset: 0x0000A57C
		public unsafe static Result OptimizeFaces(IntPtr bIndicesRef, int cFaces, int cVertices, RawBool b32BitIndices, int[] faceRemapRef)
		{
			Result result;
			fixed (int[] array = faceRemapRef)
			{
				void* arg;
				if (faceRemapRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXOptimizeFaces_((void*)bIndicesRef, cFaces, cVertices, b32BitIndices, arg);
			}
			return result;
		}

		// Token: 0x0600032F RID: 815
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXOptimizeFaces")]
		private unsafe static extern int D3DXOptimizeFaces_(void* arg0, int arg1, int arg2, RawBool arg3, void* arg4);

		// Token: 0x06000330 RID: 816 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
		public unsafe static void WeldVertices(Mesh meshRef, int flags, ref WeldEpsilons epsilonsRef, int adjacencyInRef, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut)
		{
			WeldEpsilons.__Native _Native = default(WeldEpsilons.__Native);
			epsilonsRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXWeldVertices_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), flags, (void*)(&_Native), (void*)(&adjacencyInRef), (void*)(&adjacencyOutRef), (void*)(&faceRemapRef), (void*)(&zero));
			epsilonsRef.__MarshalFree(ref _Native);
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000331 RID: 817
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXWeldVertices")]
		private unsafe static extern int D3DXWeldVertices_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000332 RID: 818 RVA: 0x0000C434 File Offset: 0x0000A634
		public unsafe static Result GenerateOutputDecl(VertexElement[] outputRef, VertexElement[] inputRef)
		{
			Result result;
			fixed (VertexElement[] array = outputRef)
			{
				void* arg;
				if (outputRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (VertexElement[] array2 = inputRef)
				{
					void* arg2;
					if (inputRef == null || array2.Length == 0)
					{
						arg2 = null;
					}
					else
					{
						arg2 = (void*)(&array2[0]);
					}
					result = D3DX9.D3DXGenerateOutputDecl_(arg, arg2);
				}
			}
			return result;
		}

		// Token: 0x06000333 RID: 819
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGenerateOutputDecl")]
		private unsafe static extern int D3DXGenerateOutputDecl_(void* arg0, void* arg1);

		// Token: 0x06000334 RID: 820 RVA: 0x0000C484 File Offset: 0x0000A684
		public unsafe static void CreateBuffer(int numBytes, out Blob bufferOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateBuffer_(numBytes, (void*)(&zero));
			bufferOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000335 RID: 821
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateBuffer")]
		private unsafe static extern int D3DXCreateBuffer_(int arg0, void* arg1);

		// Token: 0x06000336 RID: 822 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		public unsafe static void LoadPatchMeshFromXof(XFileData xofObjMeshRef, int options, Device d3DDeviceRef, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out PatchMesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadPatchMeshFromXof_((void*)((xofObjMeshRef == null) ? IntPtr.Zero : xofObjMeshRef.NativePointer), options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&numMaterialsRef), (void*)(&zero3));
			materialsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			effectInstancesOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			meshOut = ((zero3 == IntPtr.Zero) ? null : new PatchMesh(zero3));
			result.CheckError();
		}

		// Token: 0x06000337 RID: 823
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadPatchMeshFromXof")]
		private unsafe static extern int D3DXLoadPatchMeshFromXof_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000338 RID: 824 RVA: 0x0000C57C File Offset: 0x0000A77C
		public unsafe static void TessellateNPatches(Mesh meshInRef, int adjacencyInRef, float numSegs, RawBool quadraticInterpNormals, out Mesh meshOutOut, out Blob adjacencyOutOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXTessellateNPatches_((void*)((meshInRef == null) ? IntPtr.Zero : meshInRef.NativePointer), (void*)(&adjacencyInRef), numSegs, quadraticInterpNormals, (void*)(&zero), (void*)(&zero2));
			meshOutOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOutOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000339 RID: 825
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXTessellateNPatches")]
		private unsafe static extern int D3DXTessellateNPatches_(void* arg0, void* arg1, float arg2, RawBool arg3, void* arg4, void* arg5);

		// Token: 0x0600033A RID: 826 RVA: 0x0000C5FC File Offset: 0x0000A7FC
		public unsafe static void ComputeIMTFromSignal(Mesh meshRef, int dwTextureIndex, int uSignalDimension, float fMaxUVDistance, int dwOptions, FunctionCallback signalCallbackRef, IntPtr userDataRef, FunctionCallback statusCallbackRef, IntPtr userContextRef, out Blob iMTDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXComputeIMTFromSignal_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), dwTextureIndex, uSignalDimension, fMaxUVDistance, dwOptions, signalCallbackRef, (void*)userDataRef, statusCallbackRef, (void*)userContextRef, (void*)(&zero));
			iMTDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600033B RID: 827
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeIMTFromSignal")]
		private unsafe static extern int D3DXComputeIMTFromSignal_(void* arg0, int arg1, int arg2, float arg3, int arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x0600033C RID: 828 RVA: 0x0000C674 File Offset: 0x0000A874
		public unsafe static void ValidPatchMesh(PatchMesh meshRef, int dwcDegenerateVertices, int dwcDegeneratePatches, out Blob errorsAndWarningsOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXValidPatchMesh_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&dwcDegenerateVertices), (void*)(&dwcDegeneratePatches), (void*)(&zero));
			errorsAndWarningsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600033D RID: 829
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXValidPatchMesh")]
		private unsafe static extern int D3DXValidPatchMesh_(void* arg0, void* arg1, void* arg2, void* arg3);

		// Token: 0x0600033E RID: 830 RVA: 0x0000C6D0 File Offset: 0x0000A8D0
		public unsafe static void ValidMesh(Mesh meshInRef, int adjacencyRef, out Blob errorsAndWarningsOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXValidMesh_((void*)((meshInRef == null) ? IntPtr.Zero : meshInRef.NativePointer), (void*)(&adjacencyRef), (void*)(&zero));
			errorsAndWarningsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600033F RID: 831
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXValidMesh")]
		private unsafe static extern int D3DXValidMesh_(void* arg0, void* arg1, void* arg2);

		// Token: 0x06000340 RID: 832 RVA: 0x0000C728 File Offset: 0x0000A928
		public unsafe static void SplitMesh(Mesh meshInRef, int adjacencyInRef, int maxSize, int options, int meshesOutRef, out Blob meshArrayOutOut, out Blob adjacencyArrayOutOut, out Blob faceRemapArrayOutOut, out Blob vertRemapArrayOutOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXSplitMesh_((void*)((meshInRef == null) ? IntPtr.Zero : meshInRef.NativePointer), (void*)(&adjacencyInRef), maxSize, options, (void*)(&meshesOutRef), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&zero4));
			meshArrayOutOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			adjacencyArrayOutOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			faceRemapArrayOutOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			vertRemapArrayOutOut = ((zero4 == IntPtr.Zero) ? null : new Blob(zero4));
			result.CheckError();
		}

		// Token: 0x06000341 RID: 833
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSplitMesh")]
		private unsafe static extern int D3DXSplitMesh_(void* arg0, void* arg1, int arg2, int arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x06000342 RID: 834 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		public unsafe static void ComputeTangent(Mesh mesh, int texStage, int tangentIndex, int binormIndex, int wrap, int adjacencyRef)
		{
			D3DX9.D3DXComputeTangent_((void*)((mesh == null) ? IntPtr.Zero : mesh.NativePointer), texStage, tangentIndex, binormIndex, wrap, (void*)(&adjacencyRef)).CheckError();
		}

		// Token: 0x06000343 RID: 835
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeTangent")]
		private unsafe static extern int D3DXComputeTangent_(void* arg0, int arg1, int arg2, int arg3, int arg4, void* arg5);

		// Token: 0x06000344 RID: 836 RVA: 0x0000C82C File Offset: 0x0000AA2C
		public unsafe static void Intersect(BaseMesh meshRef, RawVector3 rayPosRef, RawVector3 rayDirRef, RawBool hitRef, int faceIndexRef, float uRef, float vRef, float distRef, out Blob allHitsOut, int countOfHitsRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXIntersect_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&rayPosRef), (void*)(&rayDirRef), (void*)(&hitRef), (void*)(&faceIndexRef), (void*)(&uRef), (void*)(&vRef), (void*)(&distRef), (void*)(&zero), (void*)(&countOfHitsRef));
			allHitsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000345 RID: 837
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXIntersect")]
		private unsafe static extern int D3DXIntersect_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x06000346 RID: 838 RVA: 0x0000C89C File Offset: 0x0000AA9C
		public unsafe static void UVAtlasPack(Mesh meshRef, int uWidth, int uHeight, float fGutter, int dwTextureIndex, int dwPartitionResultAdjacencyRef, FunctionCallback statusCallbackRef, float fCallbackFrequency, IntPtr userContextRef, int dwOptions, Blob facePartitioningRef)
		{
			D3DX9.D3DXUVAtlasPack_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), uWidth, uHeight, fGutter, dwTextureIndex, (void*)(&dwPartitionResultAdjacencyRef), statusCallbackRef, fCallbackFrequency, (void*)userContextRef, dwOptions, (void*)((facePartitioningRef == null) ? IntPtr.Zero : facePartitioningRef.NativePointer)).CheckError();
		}

		// Token: 0x06000347 RID: 839
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXUVAtlasPack")]
		private unsafe static extern int D3DXUVAtlasPack_(void* arg0, int arg1, int arg2, float arg3, int arg4, void* arg5, void* arg6, float arg7, void* arg8, int arg9, void* arg10);

		// Token: 0x06000348 RID: 840 RVA: 0x0000C904 File Offset: 0x0000AB04
		public unsafe static void LoadSkinMeshFromXof(XFileData xofMeshRef, int options, Device d3DDeviceRef, out Blob adjacencyOut, out Blob materialsOut, out Blob effectInstancesOut, int matOutRef, out SkinInfo skinInfoOut, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			IntPtr zero5 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadSkinMeshFromXof_((void*)((xofMeshRef == null) ? IntPtr.Zero : xofMeshRef.NativePointer), options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&matOutRef), (void*)(&zero4), (void*)(&zero5));
			adjacencyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			materialsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			effectInstancesOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			skinInfoOut = ((zero4 == IntPtr.Zero) ? null : new SkinInfo(zero4));
			meshOut = ((zero5 == IntPtr.Zero) ? null : new Mesh(zero5));
			result.CheckError();
		}

		// Token: 0x06000349 RID: 841
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSkinMeshFromXof")]
		private unsafe static extern int D3DXLoadSkinMeshFromXof_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x0600034A RID: 842 RVA: 0x0000CA00 File Offset: 0x0000AC00
		public unsafe static void CreateMesh(int numFaces, int numVertices, int options, VertexElement declarationRef, Device d3DDeviceRef, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateMesh_(numFaces, numVertices, options, (void*)(&declarationRef), (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x0600034B RID: 843
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateMesh")]
		private unsafe static extern int D3DXCreateMesh_(int arg0, int arg1, int arg2, void* arg3, void* arg4, void* arg5);

		// Token: 0x0600034C RID: 844 RVA: 0x0000CA60 File Offset: 0x0000AC60
		public unsafe static void CreateSkinInfoFVF(int numVertices, VertexFormat fvf, int numBones, out SkinInfo skinInfoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSkinInfoFVF_(numVertices, (int)fvf, numBones, (void*)(&zero));
			skinInfoOut = ((zero == IntPtr.Zero) ? null : new SkinInfo(zero));
			result.CheckError();
		}

		// Token: 0x0600034D RID: 845
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSkinInfoFVF")]
		private unsafe static extern int D3DXCreateSkinInfoFVF_(int arg0, int arg1, int arg2, void* arg3);

		// Token: 0x0600034E RID: 846 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		public unsafe static void IntersectSubset(BaseMesh meshRef, int attribId, RawVector3 rayPosRef, RawVector3 rayDirRef, RawBool hitRef, int faceIndexRef, float uRef, float vRef, float distRef, out Blob allHitsOut, int countOfHitsRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXIntersectSubset_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), attribId, (void*)(&rayPosRef), (void*)(&rayDirRef), (void*)(&hitRef), (void*)(&faceIndexRef), (void*)(&uRef), (void*)(&vRef), (void*)(&distRef), (void*)(&zero), (void*)(&countOfHitsRef));
			allHitsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600034F RID: 847
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXIntersectSubset")]
		private unsafe static extern int D3DXIntersectSubset_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9, void* arg10);

		// Token: 0x06000350 RID: 848 RVA: 0x0000CB13 File Offset: 0x0000AD13
		public static int GetFVFVertexSize(VertexFormat fvf)
		{
			return D3DX9.D3DXGetFVFVertexSize_((int)fvf);
		}

		// Token: 0x06000351 RID: 849
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetFVFVertexSize")]
		private static extern int D3DXGetFVFVertexSize_(int arg0);

		// Token: 0x06000352 RID: 850 RVA: 0x0000CB1C File Offset: 0x0000AD1C
		public unsafe static int GetDeclLength(VertexElement[] declRef)
		{
			int result;
			fixed (VertexElement[] array = declRef)
			{
				void* arg;
				if (declRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXGetDeclLength_(arg);
			}
			return result;
		}

		// Token: 0x06000353 RID: 851
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetDeclLength")]
		private unsafe static extern int D3DXGetDeclLength_(void* arg0);

		// Token: 0x06000354 RID: 852 RVA: 0x0000CB4C File Offset: 0x0000AD4C
		public unsafe static void CleanMesh(CleanType cleanType, Mesh meshInRef, int adjacencyInRef, out Mesh meshOutOut, int adjacencyOutRef, out Blob errorsAndWarningsOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCleanMesh_((int)cleanType, (void*)((meshInRef == null) ? IntPtr.Zero : meshInRef.NativePointer), (void*)(&adjacencyInRef), (void*)(&zero), (void*)(&adjacencyOutRef), (void*)(&zero2));
			meshOutOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			errorsAndWarningsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000355 RID: 853
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCleanMesh")]
		private unsafe static extern int D3DXCleanMesh_(int arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5);

		// Token: 0x06000356 RID: 854 RVA: 0x0000CBCA File Offset: 0x0000ADCA
		public unsafe static RawBool IntersectTri(RawVector3 arg0Ref, RawVector3 arg1Ref, RawVector3 arg2Ref, RawVector3 rayPosRef, RawVector3 rayDirRef, float uRef, float vRef, float distRef)
		{
			return D3DX9.D3DXIntersectTri_((void*)(&arg0Ref), (void*)(&arg1Ref), (void*)(&arg2Ref), (void*)(&rayPosRef), (void*)(&rayDirRef), (void*)(&uRef), (void*)(&vRef), (void*)(&distRef));
		}

		// Token: 0x06000357 RID: 855
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXIntersectTri")]
		private unsafe static extern RawBool D3DXIntersectTri_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000358 RID: 856 RVA: 0x0000CBEC File Offset: 0x0000ADEC
		public unsafe static void ConvertMeshSubsetToSingleStrip(BaseMesh meshIn, int attribId, int iBOptions, out IndexBuffer indexBufferOut, int numIndicesRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXConvertMeshSubsetToSingleStrip_((void*)((meshIn == null) ? IntPtr.Zero : meshIn.NativePointer), attribId, iBOptions, (void*)(&zero), (void*)(&numIndicesRef));
			indexBufferOut = ((zero == IntPtr.Zero) ? null : new IndexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x06000359 RID: 857
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXConvertMeshSubsetToSingleStrip")]
		private unsafe static extern int D3DXConvertMeshSubsetToSingleStrip_(void* arg0, int arg1, int arg2, void* arg3, void* arg4);

		// Token: 0x0600035A RID: 858 RVA: 0x0000CC48 File Offset: 0x0000AE48
		public unsafe static void CreateSkinInfo(int numVertices, VertexElement declarationRef, int numBones, out SkinInfo skinInfoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSkinInfo_(numVertices, (void*)(&declarationRef), numBones, (void*)(&zero));
			skinInfoOut = ((zero == IntPtr.Zero) ? null : new SkinInfo(zero));
			result.CheckError();
		}

		// Token: 0x0600035B RID: 859
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSkinInfo")]
		private unsafe static extern int D3DXCreateSkinInfo_(int arg0, void* arg1, int arg2, void* arg3);

		// Token: 0x0600035C RID: 860 RVA: 0x0000CC90 File Offset: 0x0000AE90
		public unsafe static int GetDeclVertexSize(VertexElement[] declRef, int stream)
		{
			int result;
			fixed (VertexElement[] array = declRef)
			{
				void* arg;
				if (declRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXGetDeclVertexSize_(arg, stream);
			}
			return result;
		}

		// Token: 0x0600035D RID: 861
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetDeclVertexSize")]
		private unsafe static extern int D3DXGetDeclVertexSize_(void* arg0, int arg1);

		// Token: 0x0600035E RID: 862 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		public unsafe static void GeneratePMesh(Mesh meshRef, int adjacencyRef, ref AttributeWeights vertexAttributeWeightsRef, float vertexWeightsRef, int minValue, int options, out ProgressiveMesh pMeshOut)
		{
			AttributeWeights.__Native _Native = default(AttributeWeights.__Native);
			vertexAttributeWeightsRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXGeneratePMesh_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&adjacencyRef), (void*)(&_Native), (void*)(&vertexWeightsRef), minValue, options, (void*)(&zero));
			vertexAttributeWeightsRef.__MarshalFree(ref _Native);
			pMeshOut = ((zero == IntPtr.Zero) ? null : new ProgressiveMesh(zero));
			result.CheckError();
		}

		// Token: 0x0600035F RID: 863
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGeneratePMesh")]
		private unsafe static extern int D3DXGeneratePMesh_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, int arg5, void* arg6);

		// Token: 0x06000360 RID: 864 RVA: 0x0000CD3C File Offset: 0x0000AF3C
		public unsafe static void TessellateRectPatch(VertexBuffer vBRef, float numSegsRef, VertexElement dwInDeclRef, ref RectanglePatchInfo rectPatchInfoRef, Mesh meshRef)
		{
			Result result;
			fixed (RectanglePatchInfo* ptr = &rectPatchInfoRef)
			{
				void* arg = (void*)ptr;
				result = D3DX9.D3DXTessellateRectPatch_((void*)((vBRef == null) ? IntPtr.Zero : vBRef.NativePointer), (void*)(&numSegsRef), (void*)(&dwInDeclRef), arg, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer));
			}
			result.CheckError();
		}

		// Token: 0x06000361 RID: 865
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXTessellateRectPatch")]
		private unsafe static extern int D3DXTessellateRectPatch_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x06000362 RID: 866 RVA: 0x0000CD98 File Offset: 0x0000AF98
		public unsafe static VertexFormat FVFFromDeclarator(VertexElement[] declaratorRef)
		{
			VertexFormat result2;
			Result result;
			fixed (VertexElement[] array = declaratorRef)
			{
				void* arg;
				if (declaratorRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXFVFFromDeclarator_(arg, (void*)(&result2));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000363 RID: 867
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFVFFromDeclarator")]
		private unsafe static extern int D3DXFVFFromDeclarator_(void* arg0, void* arg1);

		// Token: 0x06000364 RID: 868 RVA: 0x0000CDD8 File Offset: 0x0000AFD8
		public unsafe static void ComputeBoundingBox(RawVector3 firstPositionRef, int numVertices, int dwStride, RawVector3 minRef, RawVector3 maxRef)
		{
			D3DX9.D3DXComputeBoundingBox_((void*)(&firstPositionRef), numVertices, dwStride, (void*)(&minRef), (void*)(&maxRef)).CheckError();
		}

		// Token: 0x06000365 RID: 869
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeBoundingBox")]
		private unsafe static extern int D3DXComputeBoundingBox_(void* arg0, int arg1, int arg2, void* arg3, void* arg4);

		// Token: 0x06000366 RID: 870 RVA: 0x0000CE04 File Offset: 0x0000B004
		public unsafe static void CreateSkinInfoFromBlendedMesh(BaseMesh meshRef, int numBones, BoneCombination boneCombinationTableRef, out SkinInfo skinInfoOut)
		{
			BoneCombination.__Native _Native = default(BoneCombination.__Native);
			boneCombinationTableRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSkinInfoFromBlendedMesh_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), numBones, (void*)(&_Native), (void*)(&zero));
			boneCombinationTableRef.__MarshalFree(ref _Native);
			skinInfoOut = ((zero == IntPtr.Zero) ? null : new SkinInfo(zero));
			result.CheckError();
		}

		// Token: 0x06000367 RID: 871
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSkinInfoFromBlendedMesh")]
		private unsafe static extern int D3DXCreateSkinInfoFromBlendedMesh_(void* arg0, int arg1, void* arg2, void* arg3);

		// Token: 0x06000368 RID: 872 RVA: 0x0000CE78 File Offset: 0x0000B078
		public unsafe static void ComputeTangentFrameEx(Mesh meshRef, int dwTextureInSemantic, int dwTextureInIndex, int dwUPartialOutSemantic, int dwUPartialOutIndex, int dwVPartialOutSemantic, int dwVPartialOutIndex, int dwNormalOutSemantic, int dwNormalOutIndex, int dwOptions, int dwAdjacencyRef, float fPartialEdgeThreshold, float fSingularPointThreshold, float fNormalEdgeThreshold, out Mesh meshOutOut, out Blob vertexMappingOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXComputeTangentFrameEx_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), dwTextureInSemantic, dwTextureInIndex, dwUPartialOutSemantic, dwUPartialOutIndex, dwVPartialOutSemantic, dwVPartialOutIndex, dwNormalOutSemantic, dwNormalOutIndex, dwOptions, (void*)(&dwAdjacencyRef), fPartialEdgeThreshold, fSingularPointThreshold, fNormalEdgeThreshold, (void*)(&zero), (void*)(&zero2));
			meshOutOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			vertexMappingOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000369 RID: 873
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeTangentFrameEx")]
		private unsafe static extern int D3DXComputeTangentFrameEx_(void* arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, void* arg10, float arg11, float arg12, float arg13, void* arg14, void* arg15);

		// Token: 0x0600036A RID: 874 RVA: 0x0000CF08 File Offset: 0x0000B108
		public unsafe static RawBool SphereBoundProbe(RawVector3 centerRef, float radius, RawVector3 rayPositionRef, RawVector3 rayDirectionRef)
		{
			return D3DX9.D3DXSphereBoundProbe_((void*)(&centerRef), radius, (void*)(&rayPositionRef), (void*)(&rayDirectionRef));
		}

		// Token: 0x0600036B RID: 875
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSphereBoundProbe")]
		private unsafe static extern RawBool D3DXSphereBoundProbe_(void* arg0, float arg1, void* arg2, void* arg3);

		// Token: 0x0600036C RID: 876 RVA: 0x0000CF1C File Offset: 0x0000B11C
		public unsafe static void UVAtlasCreate(Mesh meshRef, int uMaxChartNumber, float fMaxStretch, int uWidth, int uHeight, float fGutter, int dwTextureIndex, int dwAdjacencyRef, int dwFalseEdgeAdjacencyRef, float fIMTArrayRef, FunctionCallback statusCallbackRef, float fCallbackFrequency, IntPtr userContextRef, int dwOptions, out Mesh meshOutOut, out Blob facePartitioningOut, out Blob vertexRemapArrayOut, float fMaxStretchOutRef, int uNumChartsOutRef)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = D3DX9.D3DXUVAtlasCreate_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), uMaxChartNumber, fMaxStretch, uWidth, uHeight, fGutter, dwTextureIndex, (void*)(&dwAdjacencyRef), (void*)(&dwFalseEdgeAdjacencyRef), (void*)(&fIMTArrayRef), statusCallbackRef, fCallbackFrequency, (void*)userContextRef, dwOptions, (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&fMaxStretchOutRef), (void*)(&uNumChartsOutRef));
			meshOutOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			facePartitioningOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			vertexRemapArrayOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			result.CheckError();
		}

		// Token: 0x0600036D RID: 877
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXUVAtlasCreate")]
		private unsafe static extern int D3DXUVAtlasCreate_(void* arg0, int arg1, float arg2, int arg3, int arg4, float arg5, int arg6, void* arg7, void* arg8, void* arg9, void* arg10, float arg11, void* arg12, int arg13, void* arg14, void* arg15, void* arg16, void* arg17, void* arg18);

		// Token: 0x0600036E RID: 878 RVA: 0x0000CFE0 File Offset: 0x0000B1E0
		public unsafe static void UVAtlasPartition(Mesh meshRef, int uMaxChartNumber, float fMaxStretch, int dwTextureIndex, int dwAdjacencyRef, int dwFalseEdgeAdjacencyRef, float fIMTArrayRef, FunctionCallback statusCallbackRef, float fCallbackFrequency, IntPtr userContextRef, int dwOptions, out Mesh meshOutOut, out Blob facePartitioningOut, out Blob vertexRemapArrayOut, out Blob partitionResultAdjacencyOut, float fMaxStretchOutRef, int uNumChartsOutRef)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXUVAtlasPartition_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), uMaxChartNumber, fMaxStretch, dwTextureIndex, (void*)(&dwAdjacencyRef), (void*)(&dwFalseEdgeAdjacencyRef), (void*)(&fIMTArrayRef), statusCallbackRef, fCallbackFrequency, (void*)userContextRef, dwOptions, (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&zero4), (void*)(&fMaxStretchOutRef), (void*)(&uNumChartsOutRef));
			meshOutOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			facePartitioningOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			vertexRemapArrayOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			partitionResultAdjacencyOut = ((zero4 == IntPtr.Zero) ? null : new Blob(zero4));
			result.CheckError();
		}

		// Token: 0x0600036F RID: 879
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXUVAtlasPartition")]
		private unsafe static extern int D3DXUVAtlasPartition_(void* arg0, int arg1, float arg2, int arg3, void* arg4, void* arg5, void* arg6, void* arg7, float arg8, void* arg9, int arg10, void* arg11, void* arg12, void* arg13, void* arg14, void* arg15, void* arg16);

		// Token: 0x06000370 RID: 880 RVA: 0x0000D0C4 File Offset: 0x0000B2C4
		public unsafe static void CreatePMeshFromStream(IntPtr streamRef, int options, Device d3DDeviceRef, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out ProgressiveMesh pMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreatePMeshFromStream_((void*)streamRef, options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&numMaterialsRef), (void*)(&zero3));
			materialsOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			effectInstancesOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			pMeshOut = ((zero3 == IntPtr.Zero) ? null : new ProgressiveMesh(zero3));
			result.CheckError();
		}

		// Token: 0x06000371 RID: 881
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreatePMeshFromStream")]
		private unsafe static extern int D3DXCreatePMeshFromStream_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000372 RID: 882 RVA: 0x0000D168 File Offset: 0x0000B368
		public unsafe static void ComputeIMTFromTexture(Mesh meshRef, Texture textureRef, int dwTextureIndex, int dwOptions, FunctionCallback statusCallbackRef, IntPtr userContextRef, out Blob iMTDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXComputeIMTFromTexture_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), dwTextureIndex, dwOptions, statusCallbackRef, (void*)userContextRef, (void*)(&zero));
			iMTDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000373 RID: 883
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeIMTFromTexture")]
		private unsafe static extern int D3DXComputeIMTFromTexture_(void* arg0, void* arg1, int arg2, int arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000374 RID: 884 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		public unsafe static void CreateSPMesh(Mesh meshRef, int adjacencyRef, ref AttributeWeights vertexAttributeWeightsRef, float vertexWeightsRef, out SimplificationMesh sMeshOut)
		{
			AttributeWeights.__Native _Native = default(AttributeWeights.__Native);
			vertexAttributeWeightsRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSPMesh_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&adjacencyRef), (void*)(&_Native), (void*)(&vertexWeightsRef), (void*)(&zero));
			vertexAttributeWeightsRef.__MarshalFree(ref _Native);
			sMeshOut = ((zero == IntPtr.Zero) ? null : new SimplificationMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000375 RID: 885
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSPMesh")]
		private unsafe static extern int D3DXCreateSPMesh_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x06000376 RID: 886 RVA: 0x0000D25C File Offset: 0x0000B45C
		public unsafe static void ConcatenateMeshes(out Mesh meshesOut, int numMeshes, int options, ref RawMatrix geomXFormsRef, ref RawMatrix textureXFormsRef, VertexElement[] declRef, Device d3DDeviceRef, out Mesh meshOutOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result;
			fixed (RawMatrix* ptr = &geomXFormsRef)
			{
				void* arg = (void*)ptr;
				fixed (RawMatrix* ptr2 = &textureXFormsRef)
				{
					void* arg2 = (void*)ptr2;
					fixed (VertexElement[] array = declRef)
					{
						void* arg3;
						if (declRef == null || array.Length == 0)
						{
							arg3 = null;
						}
						else
						{
							arg3 = (void*)(&array[0]);
						}
						result = D3DX9.D3DXConcatenateMeshes_((void*)(&zero), numMeshes, options, arg, arg2, arg3, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero2));
					}
				}
			}
			meshesOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			meshOutOut = ((zero2 == IntPtr.Zero) ? null : new Mesh(zero2));
			result.CheckError();
		}

		// Token: 0x06000377 RID: 887
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXConcatenateMeshes")]
		private unsafe static extern int D3DXConcatenateMeshes_(void* arg0, int arg1, int arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000378 RID: 888 RVA: 0x0000D315 File Offset: 0x0000B515
		public unsafe static RawBool BoxBoundProbe(RawVector3 minRef, RawVector3 maxRef, RawVector3 rayPositionRef, RawVector3 rayDirectionRef)
		{
			return D3DX9.D3DXBoxBoundProbe_((void*)(&minRef), (void*)(&maxRef), (void*)(&rayPositionRef), (void*)(&rayDirectionRef));
		}

		// Token: 0x06000379 RID: 889
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXBoxBoundProbe")]
		private unsafe static extern RawBool D3DXBoxBoundProbe_(void* arg0, void* arg1, void* arg2, void* arg3);

		// Token: 0x0600037A RID: 890 RVA: 0x0000D328 File Offset: 0x0000B528
		public unsafe static void LoadMeshFromXResource(IntPtr module, string name, string type, int options, Device d3DDeviceRef, out Blob adjacencyOut, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out Mesh meshOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(name);
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(type);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshFromXResource_((void*)module, (void*)intPtr, (void*)intPtr2, options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&numMaterialsRef), (void*)(&zero4));
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			adjacencyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			materialsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			effectInstancesOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			meshOut = ((zero4 == IntPtr.Zero) ? null : new Mesh(zero4));
			result.CheckError();
		}

		// Token: 0x0600037B RID: 891
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshFromXResource")]
		private unsafe static extern int D3DXLoadMeshFromXResource_(void* arg0, void* arg1, void* arg2, int arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x0600037C RID: 892 RVA: 0x0000D420 File Offset: 0x0000B620
		public unsafe static void SimplifyMesh(Mesh meshRef, int adjacencyRef, ref AttributeWeights vertexAttributeWeightsRef, float vertexWeightsRef, int minValue, int options, out Mesh meshOut)
		{
			AttributeWeights.__Native _Native = default(AttributeWeights.__Native);
			vertexAttributeWeightsRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXSimplifyMesh_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&adjacencyRef), (void*)(&_Native), (void*)(&vertexWeightsRef), minValue, options, (void*)(&zero));
			vertexAttributeWeightsRef.__MarshalFree(ref _Native);
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x0600037D RID: 893
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSimplifyMesh")]
		private unsafe static extern int D3DXSimplifyMesh_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, int arg5, void* arg6);

		// Token: 0x0600037E RID: 894 RVA: 0x0000D49C File Offset: 0x0000B69C
		public unsafe static void CreateMeshFVF(int numFaces, int numVertices, int options, VertexFormat fvf, Device d3DDeviceRef, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateMeshFVF_(numFaces, numVertices, options, (int)fvf, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x0600037F RID: 895
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateMeshFVF")]
		private unsafe static extern int D3DXCreateMeshFVF_(int arg0, int arg1, int arg2, int arg3, void* arg4, void* arg5);

		// Token: 0x06000380 RID: 896 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		public unsafe static void ComputeIMTFromPerVertexSignal(Mesh meshRef, float fVertexSignalRef, int uSignalDimension, int uSignalStride, int dwOptions, FunctionCallback statusCallbackRef, IntPtr userContextRef, out Blob iMTDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXComputeIMTFromPerVertexSignal_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&fVertexSignalRef), uSignalDimension, uSignalStride, dwOptions, statusCallbackRef, (void*)userContextRef, (void*)(&zero));
			iMTDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000381 RID: 897
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeIMTFromPerVertexSignal")]
		private unsafe static extern int D3DXComputeIMTFromPerVertexSignal_(void* arg0, void* arg1, int arg2, int arg3, int arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000382 RID: 898 RVA: 0x0000D564 File Offset: 0x0000B764
		public unsafe static Result OptimizeVertices(IntPtr bIndicesRef, int cFaces, int cVertices, RawBool b32BitIndices, int[] vertexRemapRef)
		{
			Result result;
			fixed (int[] array = vertexRemapRef)
			{
				void* arg;
				if (vertexRemapRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXOptimizeVertices_((void*)bIndicesRef, cFaces, cVertices, b32BitIndices, arg);
			}
			return result;
		}

		// Token: 0x06000383 RID: 899
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXOptimizeVertices")]
		private unsafe static extern int D3DXOptimizeVertices_(void* arg0, int arg1, int arg2, RawBool arg3, void* arg4);

		// Token: 0x06000384 RID: 900 RVA: 0x0000D5A0 File Offset: 0x0000B7A0
		public unsafe static void LoadMeshFromXof(XFileData xofMeshRef, int options, Device d3DDeviceRef, out Blob adjacencyOut, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshFromXof_((void*)((xofMeshRef == null) ? IntPtr.Zero : xofMeshRef.NativePointer), options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&numMaterialsRef), (void*)(&zero4));
			adjacencyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			materialsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			effectInstancesOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			meshOut = ((zero4 == IntPtr.Zero) ? null : new Mesh(zero4));
			result.CheckError();
		}

		// Token: 0x06000385 RID: 901
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshFromXof")]
		private unsafe static extern int D3DXLoadMeshFromXof_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000386 RID: 902 RVA: 0x0000D678 File Offset: 0x0000B878
		public unsafe static void CreatePatchMesh(PatchInfo infoRef, int dwNumPatches, int dwNumVertices, int dwOptions, VertexElement[] declRef, Device d3DDeviceRef, out PatchMesh patchMeshRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (VertexElement[] array = declRef)
			{
				void* arg;
				if (declRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreatePatchMesh_((void*)(&infoRef), dwNumPatches, dwNumVertices, dwOptions, arg, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero));
			}
			patchMeshRef = ((zero == IntPtr.Zero) ? null : new PatchMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000387 RID: 903
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreatePatchMesh")]
		private unsafe static extern int D3DXCreatePatchMesh_(void* arg0, int arg1, int arg2, int arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000388 RID: 904 RVA: 0x0000D6F4 File Offset: 0x0000B8F4
		public unsafe static Result RectPatchSize(float fNumSegsRef, out int dwTrianglesRef, out int dwVerticesRef)
		{
			Result result;
			fixed (int* ptr = &dwTrianglesRef)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &dwVerticesRef)
				{
					void* arg2 = (void*)ptr2;
					result = D3DX9.D3DXRectPatchSize_((void*)(&fNumSegsRef), arg, arg2);
				}
			}
			return result;
		}

		// Token: 0x06000389 RID: 905
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXRectPatchSize")]
		private unsafe static extern int D3DXRectPatchSize_(void* arg0, void* arg1, void* arg2);

		// Token: 0x0600038A RID: 906 RVA: 0x0000D720 File Offset: 0x0000B920
		public unsafe static void TessellateTriPatch(VertexBuffer vBRef, float numSegsRef, VertexElement inDeclRef, TrianglePatchInfo triPatchInfoRef, Mesh meshRef)
		{
			D3DX9.D3DXTessellateTriPatch_((void*)((vBRef == null) ? IntPtr.Zero : vBRef.NativePointer), (void*)(&numSegsRef), (void*)(&inDeclRef), (void*)(&triPatchInfoRef), (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer)).CheckError();
		}

		// Token: 0x0600038B RID: 907
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXTessellateTriPatch")]
		private unsafe static extern int D3DXTessellateTriPatch_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x0600038C RID: 908 RVA: 0x0000D774 File Offset: 0x0000B974
		public unsafe static void ComputeBoundingSphere(RawVector3 firstPositionRef, int numVertices, int dwStride, RawVector3 centerRef, float radiusRef)
		{
			D3DX9.D3DXComputeBoundingSphere_((void*)(&firstPositionRef), numVertices, dwStride, (void*)(&centerRef), (void*)(&radiusRef)).CheckError();
		}

		// Token: 0x0600038D RID: 909
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeBoundingSphere")]
		private unsafe static extern int D3DXComputeBoundingSphere_(void* arg0, int arg1, int arg2, void* arg3, void* arg4);

		// Token: 0x0600038E RID: 910 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
		public unsafe static void LoadMeshFromXW(string filenameRef, int options, Device d3DDeviceRef, out Blob adjacencyOut, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out Mesh meshOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(filenameRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshFromXW_((void*)intPtr, options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&numMaterialsRef), (void*)(&zero4));
			Marshal.FreeHGlobal(intPtr);
			adjacencyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			materialsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			effectInstancesOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			meshOut = ((zero4 == IntPtr.Zero) ? null : new Mesh(zero4));
			result.CheckError();
		}

		// Token: 0x0600038F RID: 911
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshFromXW")]
		private unsafe static extern int D3DXLoadMeshFromXW_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x06000390 RID: 912 RVA: 0x0000D874 File Offset: 0x0000BA74
		public unsafe static void LoadMeshFromXInMemory(IntPtr memory, int sizeOfMemory, int options, Device d3DDeviceRef, out Blob adjacencyOut, out Blob materialsOut, out Blob effectInstancesOut, int numMaterialsRef, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr zero4 = IntPtr.Zero;
			Result result = D3DX9.D3DXLoadMeshFromXInMemory_((void*)memory, sizeOfMemory, options, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), (void*)(&zero), (void*)(&zero2), (void*)(&zero3), (void*)(&numMaterialsRef), (void*)(&zero4));
			adjacencyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			materialsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			effectInstancesOut = ((zero3 == IntPtr.Zero) ? null : new Blob(zero3));
			meshOut = ((zero4 == IntPtr.Zero) ? null : new Mesh(zero4));
			result.CheckError();
		}

		// Token: 0x06000391 RID: 913
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadMeshFromXInMemory")]
		private unsafe static extern int D3DXLoadMeshFromXInMemory_(void* arg0, int arg1, int arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x06000392 RID: 914 RVA: 0x0000D93C File Offset: 0x0000BB3C
		public unsafe static void ConvertMeshSubsetToStrips(BaseMesh meshIn, int attribId, int iBOptions, out IndexBuffer indexBufferOut, int numIndicesRef, out Blob stripLengthsOut, int numStripsRef)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXConvertMeshSubsetToStrips_((void*)((meshIn == null) ? IntPtr.Zero : meshIn.NativePointer), attribId, iBOptions, (void*)(&zero), (void*)(&numIndicesRef), (void*)(&zero2), (void*)(&numStripsRef));
			indexBufferOut = ((zero == IntPtr.Zero) ? null : new IndexBuffer(zero));
			stripLengthsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000393 RID: 915
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXConvertMeshSubsetToStrips")]
		private unsafe static extern int D3DXConvertMeshSubsetToStrips_(void* arg0, int arg1, int arg2, void* arg3, void* arg4, void* arg5, void* arg6);

		// Token: 0x06000394 RID: 916 RVA: 0x0000D9BC File Offset: 0x0000BBBC
		public unsafe static void ComputeIMTFromPerTexelSignal(Mesh meshRef, int dwTextureIndex, float fTexelSignalRef, int uWidth, int uHeight, int uSignalDimension, int uComponents, int dwOptions, FunctionCallback statusCallbackRef, IntPtr userContextRef, out Blob iMTDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXComputeIMTFromPerTexelSignal_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), dwTextureIndex, (void*)(&fTexelSignalRef), uWidth, uHeight, uSignalDimension, uComponents, dwOptions, statusCallbackRef, (void*)userContextRef, (void*)(&zero));
			iMTDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000395 RID: 917
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeIMTFromPerTexelSignal")]
		private unsafe static extern int D3DXComputeIMTFromPerTexelSignal_(void* arg0, int arg1, void* arg2, int arg3, int arg4, int arg5, int arg6, int arg7, void* arg8, void* arg9, void* arg10);

		// Token: 0x06000396 RID: 918 RVA: 0x0000DA30 File Offset: 0x0000BC30
		public unsafe static Result TriPatchSize(float fNumSegsRef, out int dwTrianglesRef, out int dwVerticesRef)
		{
			Result result;
			fixed (int* ptr = &dwTrianglesRef)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &dwVerticesRef)
				{
					void* arg2 = (void*)ptr2;
					result = D3DX9.D3DXTriPatchSize_((void*)(&fNumSegsRef), arg, arg2);
				}
			}
			return result;
		}

		// Token: 0x06000397 RID: 919
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXTriPatchSize")]
		private unsafe static extern int D3DXTriPatchSize_(void* arg0, void* arg1, void* arg2);

		// Token: 0x06000398 RID: 920 RVA: 0x0000DA5C File Offset: 0x0000BC5C
		public unsafe static void ComputeNormals(BaseMesh meshRef, int adjacencyRef)
		{
			D3DX9.D3DXComputeNormals_((void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), (void*)(&adjacencyRef)).CheckError();
		}

		// Token: 0x06000399 RID: 921
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeNormals")]
		private unsafe static extern int D3DXComputeNormals_(void* arg0, void* arg1);

		// Token: 0x0600039A RID: 922 RVA: 0x0000DA94 File Offset: 0x0000BC94
		public unsafe static void DisassembleShader(IntPtr shaderRef, RawBool enableColorCode, string commentsRef, out Blob disassemblyOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(commentsRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXDisassembleShader_((void*)shaderRef, enableColorCode, (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			disassemblyOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600039B RID: 923
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXDisassembleShader")]
		private unsafe static extern int D3DXDisassembleShader_(void* arg0, RawBool arg1, void* arg2, void* arg3);

		// Token: 0x0600039C RID: 924 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		public unsafe static void PreprocessShader(IntPtr srcDataRef, int srcDataSize, Macro[] definesRef, IntPtr includeRef, out Blob shaderTextOut, out Blob errorMsgsOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXPreprocessShader_((void*)srcDataRef, srcDataSize, arg, (void*)includeRef, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderTextOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x0600039D RID: 925
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXPreprocessShader")]
		private unsafe static extern int D3DXPreprocessShader_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5);

		// Token: 0x0600039E RID: 926 RVA: 0x0000DBE8 File Offset: 0x0000BDE8
		public unsafe static void CompileShaderFromFileW(string srcFileRef, Macro[] definesRef, IntPtr includeRef, string functionNameRef, string profileRef, int flags, out Blob shaderOut, out Blob errorMsgsOut, out ConstantTable constantTableOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(functionNameRef);
			IntPtr intPtr3 = Utilities.StringToHGlobalAnsi(profileRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCompileShaderFromFileW_((void*)intPtr, arg, (void*)includeRef, (void*)intPtr2, (void*)intPtr3, flags, (void*)(&zero), (void*)(&zero2), (void*)(&zero3));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			constantTableOut = ((zero3 == IntPtr.Zero) ? null : new ConstantTable(zero3));
			result.CheckError();
		}

		// Token: 0x0600039F RID: 927
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCompileShaderFromFileW")]
		private unsafe static extern int D3DXCompileShaderFromFileW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, void* arg6, void* arg7, void* arg8);

		// Token: 0x060003A0 RID: 928 RVA: 0x0000DD40 File Offset: 0x0000BF40
		public unsafe static void CreateTextureShader(int functionRef, out TextureShader textureShaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTextureShader_((void*)(&functionRef), (void*)(&zero));
			textureShaderOut = ((zero == IntPtr.Zero) ? null : new TextureShader(zero));
			result.CheckError();
		}

		// Token: 0x060003A1 RID: 929
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureShader")]
		private unsafe static extern int D3DXCreateTextureShader_(void* arg0, void* arg1);

		// Token: 0x060003A2 RID: 930 RVA: 0x0000DD84 File Offset: 0x0000BF84
		public unsafe static void GetShaderOutputSemantics(IntPtr functionRef, ShaderSemantic[] semanticsRef, ref int countRef)
		{
			Result result;
			fixed (ShaderSemantic[] array = semanticsRef)
			{
				void* arg;
				if (semanticsRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (int* ptr = &countRef)
				{
					void* arg2 = (void*)ptr;
					result = D3DX9.D3DXGetShaderOutputSemantics_((void*)functionRef, arg, arg2);
				}
			}
			result.CheckError();
		}

		// Token: 0x060003A3 RID: 931
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderOutputSemantics")]
		private unsafe static extern int D3DXGetShaderOutputSemantics_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003A4 RID: 932 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
		public unsafe static void GetShaderInputSemantics(IntPtr functionRef, ShaderSemantic[] semanticsRef, ref int countRef)
		{
			Result result;
			fixed (ShaderSemantic[] array = semanticsRef)
			{
				void* arg;
				if (semanticsRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (int* ptr = &countRef)
				{
					void* arg2 = (void*)ptr;
					result = D3DX9.D3DXGetShaderInputSemantics_((void*)functionRef, arg, arg2);
				}
			}
			result.CheckError();
		}

		// Token: 0x060003A5 RID: 933
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderInputSemantics")]
		private unsafe static extern int D3DXGetShaderInputSemantics_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003A6 RID: 934 RVA: 0x0000DE1C File Offset: 0x0000C01C
		public unsafe static string GetPixelShaderProfile(Device deviceRef)
		{
			return Marshal.PtrToStringAnsi(D3DX9.D3DXGetPixelShaderProfile_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer)));
		}

		// Token: 0x060003A7 RID: 935
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetPixelShaderProfile")]
		private unsafe static extern IntPtr D3DXGetPixelShaderProfile_(void* arg0);

		// Token: 0x060003A8 RID: 936 RVA: 0x0000DE40 File Offset: 0x0000C040
		public unsafe static void FindShaderComment(IntPtr functionRef, int fourCC, out IntPtr dataOut, out int sizeInBytesRef)
		{
			Result result;
			fixed (IntPtr* ptr = &dataOut)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &sizeInBytesRef)
				{
					void* arg2 = (void*)ptr2;
					result = D3DX9.D3DXFindShaderComment_((void*)functionRef, fourCC, arg, arg2);
				}
			}
			result.CheckError();
		}

		// Token: 0x060003A9 RID: 937
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFindShaderComment")]
		private unsafe static extern int D3DXFindShaderComment_(void* arg0, int arg1, void* arg2, void* arg3);

		// Token: 0x060003AA RID: 938 RVA: 0x0000DE7C File Offset: 0x0000C07C
		public unsafe static void AssembleShaderFromResourceW(IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, int flags, out Blob shaderOut, out Blob errorMsgsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXAssembleShaderFromResourceW_((void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003AB RID: 939
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXAssembleShaderFromResourceW")]
		private unsafe static extern int D3DXAssembleShaderFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x060003AC RID: 940 RVA: 0x0000DF88 File Offset: 0x0000C188
		public unsafe static void AssembleShader(IntPtr srcDataRef, int srcDataLen, Macro[] definesRef, IntPtr includeRef, int flags, out Blob shaderOut, out Blob errorMsgsOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXAssembleShader_((void*)srcDataRef, srcDataLen, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003AD RID: 941
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXAssembleShader")]
		private unsafe static extern int D3DXAssembleShader_(void* arg0, int arg1, void* arg2, void* arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x060003AE RID: 942 RVA: 0x0000E080 File Offset: 0x0000C280
		public unsafe static void CompileShader(IntPtr srcDataRef, int srcDataLen, Macro[] definesRef, IntPtr includeRef, string functionNameRef, string profileRef, int flags, out Blob shaderOut, out Blob errorMsgsOut, out ConstantTable constantTableOut)
		{
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(functionNameRef);
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(profileRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCompileShader_((void*)srcDataRef, srcDataLen, arg, (void*)includeRef, (void*)intPtr, (void*)intPtr2, flags, (void*)(&zero), (void*)(&zero2), (void*)(&zero3));
			array2 = null;
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			constantTableOut = ((zero3 == IntPtr.Zero) ? null : new ConstantTable(zero3));
			result.CheckError();
		}

		// Token: 0x060003AF RID: 943
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCompileShader")]
		private unsafe static extern int D3DXCompileShader_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x060003B0 RID: 944 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
		public unsafe static void GetShaderSamplers(IntPtr functionRef, IntPtr samplersRef, ref int countRef)
		{
			Result result;
			fixed (int* ptr = &countRef)
			{
				void* arg = (void*)ptr;
				result = D3DX9.D3DXGetShaderSamplers_((void*)functionRef, (void*)samplersRef, arg);
			}
			result.CheckError();
		}

		// Token: 0x060003B1 RID: 945
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderSamplers")]
		private unsafe static extern int D3DXGetShaderSamplers_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003B2 RID: 946 RVA: 0x0000E1FC File Offset: 0x0000C3FC
		public unsafe static ConstantTable GetShaderConstantTable(IntPtr functionRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXGetShaderConstantTable_((void*)functionRef, (void*)(&zero));
			ConstantTable result2 = (zero == IntPtr.Zero) ? null : new ConstantTable(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x060003B3 RID: 947
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderConstantTable")]
		private unsafe static extern int D3DXGetShaderConstantTable_(void* arg0, void* arg1);

		// Token: 0x060003B4 RID: 948 RVA: 0x0000E240 File Offset: 0x0000C440
		public unsafe static void AssembleShaderFromFileW(string srcFileRef, Macro[] definesRef, IntPtr includeRef, int flags, out Blob shaderOut, out Blob errorMsgsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXAssembleShaderFromFileW_((void*)intPtr, arg, (void*)includeRef, flags, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003B5 RID: 949
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXAssembleShaderFromFileW")]
		private unsafe static extern int D3DXAssembleShaderFromFileW_(void* arg0, void* arg1, void* arg2, int arg3, void* arg4, void* arg5);

		// Token: 0x060003B6 RID: 950 RVA: 0x0000E344 File Offset: 0x0000C544
		public unsafe static void GetShaderConstantTableEx(IntPtr functionRef, int flags, out ConstantTable constantTableOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXGetShaderConstantTableEx_((void*)functionRef, flags, (void*)(&zero));
			constantTableOut = ((zero == IntPtr.Zero) ? null : new ConstantTable(zero));
			result.CheckError();
		}

		// Token: 0x060003B7 RID: 951
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderConstantTableEx")]
		private unsafe static extern int D3DXGetShaderConstantTableEx_(void* arg0, int arg1, void* arg2);

		// Token: 0x060003B8 RID: 952 RVA: 0x0000E38B File Offset: 0x0000C58B
		public unsafe static string GetVertexShaderProfile(Device deviceRef)
		{
			return Marshal.PtrToStringAnsi(D3DX9.D3DXGetVertexShaderProfile_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer)));
		}

		// Token: 0x060003B9 RID: 953
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetVertexShaderProfile")]
		private unsafe static extern IntPtr D3DXGetVertexShaderProfile_(void* arg0);

		// Token: 0x060003BA RID: 954 RVA: 0x0000E3AC File Offset: 0x0000C5AC
		public unsafe static void PreprocessShaderFromResourceW(IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, out Blob shaderTextOut, out Blob errorMsgsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXPreprocessShaderFromResourceW_((void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderTextOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003BB RID: 955
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXPreprocessShaderFromResourceW")]
		private unsafe static extern int D3DXPreprocessShaderFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5);

		// Token: 0x060003BC RID: 956 RVA: 0x0000E4B4 File Offset: 0x0000C6B4
		public unsafe static void CompileShaderFromResourceW(IntPtr hSrcModule, string srcResourceRef, Macro[] definesRef, IntPtr includeRef, string functionNameRef, string profileRef, int flags, out Blob shaderOut, out Blob errorMsgsOut, out ConstantTable constantTableOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(functionNameRef);
			IntPtr intPtr3 = Utilities.StringToHGlobalAnsi(profileRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXCompileShaderFromResourceW_((void*)hSrcModule, (void*)intPtr, arg, (void*)includeRef, (void*)intPtr2, (void*)intPtr3, flags, (void*)(&zero), (void*)(&zero2), (void*)(&zero3));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr3);
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			constantTableOut = ((zero3 == IntPtr.Zero) ? null : new ConstantTable(zero3));
			result.CheckError();
		}

		// Token: 0x060003BD RID: 957
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCompileShaderFromResourceW")]
		private unsafe static extern int D3DXCompileShaderFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, void* arg7, void* arg8, void* arg9);

		// Token: 0x060003BE RID: 958 RVA: 0x0000E614 File Offset: 0x0000C814
		public unsafe static void PreprocessShaderFromFileW(string srcFileRef, Macro[] definesRef, IntPtr includeRef, out Blob shaderTextOut, out Blob errorMsgsOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Macro.__Native[] array = (definesRef == null) ? null : new Macro.__Native[definesRef.Length];
			if (definesRef != null)
			{
				for (int i = 0; i < definesRef.Length; i++)
				{
					definesRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Macro.__Native[] array2;
			void* arg;
			if ((array2 = array) == null || array2.Length == 0)
			{
				arg = null;
			}
			else
			{
				arg = (void*)(&array2[0]);
			}
			Result result = D3DX9.D3DXPreprocessShaderFromFileW_((void*)intPtr, arg, (void*)includeRef, (void*)(&zero), (void*)(&zero2));
			array2 = null;
			Marshal.FreeHGlobal(intPtr);
			if (definesRef != null)
			{
				for (int j = 0; j < definesRef.Length; j++)
				{
					definesRef[j].__MarshalFree(ref array[j]);
				}
			}
			shaderTextOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003BF RID: 959
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXPreprocessShaderFromFileW")]
		private unsafe static extern int D3DXPreprocessShaderFromFileW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x060003C0 RID: 960 RVA: 0x0000E715 File Offset: 0x0000C915
		public unsafe static int GetShaderSize(IntPtr functionRef)
		{
			return D3DX9.D3DXGetShaderSize_((void*)functionRef);
		}

		// Token: 0x060003C1 RID: 961
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderSize")]
		private unsafe static extern int D3DXGetShaderSize_(void* arg0);

		// Token: 0x060003C2 RID: 962 RVA: 0x0000E722 File Offset: 0x0000C922
		public unsafe static int GetShaderVersion(IntPtr functionRef)
		{
			return D3DX9.D3DXGetShaderVersion_((void*)functionRef);
		}

		// Token: 0x060003C3 RID: 963
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetShaderVersion")]
		private unsafe static extern int D3DXGetShaderVersion_(void* arg0);

		// Token: 0x060003C4 RID: 964 RVA: 0x0000E730 File Offset: 0x0000C930
		public unsafe static void CreateCylinder(Device deviceRef, float radius1, float radius2, float length, int slices, int stacks, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCylinder_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), radius1, radius2, length, slices, stacks, (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003C5 RID: 965
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCylinder")]
		private unsafe static extern int D3DXCreateCylinder_(void* arg0, float arg1, float arg2, float arg3, int arg4, int arg5, void* arg6, void* arg7);

		// Token: 0x060003C6 RID: 966 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		public unsafe static void CreateTorus(Device deviceRef, float innerRadius, float outerRadius, int sides, int rings, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTorus_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), innerRadius, outerRadius, sides, rings, (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003C7 RID: 967
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTorus")]
		private unsafe static extern int D3DXCreateTorus_(void* arg0, float arg1, float arg2, int arg3, int arg4, void* arg5, void* arg6);

		// Token: 0x060003C8 RID: 968 RVA: 0x0000E830 File Offset: 0x0000CA30
		public unsafe static void CreateSphere(Device deviceRef, float radius, int slices, int stacks, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateSphere_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), radius, slices, stacks, (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003C9 RID: 969
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateSphere")]
		private unsafe static extern int D3DXCreateSphere_(void* arg0, float arg1, int arg2, int arg3, void* arg4, void* arg5);

		// Token: 0x060003CA RID: 970 RVA: 0x0000E8AC File Offset: 0x0000CAAC
		public unsafe static void CreateTeapot(Device deviceRef, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTeapot_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003CB RID: 971
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTeapot")]
		private unsafe static extern int D3DXCreateTeapot_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003CC RID: 972 RVA: 0x0000E924 File Offset: 0x0000CB24
		public unsafe static void CreateBox(Device deviceRef, float width, float height, float depth, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateBox_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), width, height, depth, (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003CD RID: 973
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateBox")]
		private unsafe static extern int D3DXCreateBox_(void* arg0, float arg1, float arg2, float arg3, void* arg4, void* arg5);

		// Token: 0x060003CE RID: 974 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
		public unsafe static void CreatePolygon(Device deviceRef, float length, int sides, out Mesh meshOut, out Blob adjacencyOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreatePolygon_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), length, sides, (void*)(&zero), (void*)(&zero2));
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003CF RID: 975
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreatePolygon")]
		private unsafe static extern int D3DXCreatePolygon_(void* arg0, float arg1, int arg2, void* arg3, void* arg4);

		// Token: 0x060003D0 RID: 976 RVA: 0x0000EA1C File Offset: 0x0000CC1C
		public unsafe static void CreateTextW(Device deviceRef, IntPtr hDC, string textRef, float deviation, float extrusion, out Mesh meshOut, out Blob adjacencyOut, IntPtr pGlyphMetrics)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(textRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTextW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hDC, (void*)intPtr, deviation, extrusion, (void*)(&zero), (void*)(&zero2), (void*)pGlyphMetrics);
			Marshal.FreeHGlobal(intPtr);
			meshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			adjacencyOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x060003D1 RID: 977
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextW")]
		private unsafe static extern int D3DXCreateTextW_(void* arg0, void* arg1, void* arg2, float arg3, float arg4, void* arg5, void* arg6, void* arg7);

		// Token: 0x060003D2 RID: 978 RVA: 0x0000EAB8 File Offset: 0x0000CCB8
		public unsafe static ImageInformation GetImageInfoFromFileInMemory(IntPtr srcDataRef, int srcDataSize)
		{
			ImageInformation result = default(ImageInformation);
			D3DX9.D3DXGetImageInfoFromFileInMemory_((void*)srcDataRef, srcDataSize, (void*)(&result)).CheckError();
			return result;
		}

		// Token: 0x060003D3 RID: 979
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetImageInfoFromFileInMemory")]
		private unsafe static extern int D3DXGetImageInfoFromFileInMemory_(void* arg0, int arg1, void* arg2);

		// Token: 0x060003D4 RID: 980 RVA: 0x0000EAEC File Offset: 0x0000CCEC
		public unsafe static void FillVolumeTextureTX(VolumeTexture volumeTextureRef, TextureShader textureShaderRef)
		{
			D3DX9.D3DXFillVolumeTextureTX_((void*)((volumeTextureRef == null) ? IntPtr.Zero : volumeTextureRef.NativePointer), (void*)((textureShaderRef == null) ? IntPtr.Zero : textureShaderRef.NativePointer)).CheckError();
		}

		// Token: 0x060003D5 RID: 981
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillVolumeTextureTX")]
		private unsafe static extern int D3DXFillVolumeTextureTX_(void* arg0, void* arg1);

		// Token: 0x060003D6 RID: 982 RVA: 0x0000EB38 File Offset: 0x0000CD38
		public unsafe static void CreateCubeTexture(Device deviceRef, int size, int mipLevels, int usage, Format format, Pool pool, out CubeTexture cubeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCubeTexture_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), size, mipLevels, usage, (int)format, (int)pool, (void*)(&zero));
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003D7 RID: 983
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTexture")]
		private unsafe static extern int D3DXCreateCubeTexture_(void* arg0, int arg1, int arg2, int arg3, int arg4, int arg5, void* arg6);

		// Token: 0x060003D8 RID: 984 RVA: 0x0000EB98 File Offset: 0x0000CD98
		public unsafe static void CreateVolumeTextureFromFileInMemoryEx(Device deviceRef, IntPtr srcDataRef, int srcDataSize, int width, int height, int depth, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out VolumeTexture volumeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateVolumeTextureFromFileInMemoryEx_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, width, height, depth, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003D9 RID: 985
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromFileInMemoryEx")]
		private unsafe static extern int D3DXCreateVolumeTextureFromFileInMemoryEx_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, RawColorBGRA arg12, void* arg13, void* arg14, void* arg15);

		// Token: 0x060003DA RID: 986 RVA: 0x0000EC2C File Offset: 0x0000CE2C
		public unsafe static void FillTextureTX(Texture textureRef, TextureShader textureShaderRef)
		{
			D3DX9.D3DXFillTextureTX_((void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), (void*)((textureShaderRef == null) ? IntPtr.Zero : textureShaderRef.NativePointer)).CheckError();
		}

		// Token: 0x060003DB RID: 987
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillTextureTX")]
		private unsafe static extern int D3DXFillTextureTX_(void* arg0, void* arg1);

		// Token: 0x060003DC RID: 988 RVA: 0x0000EC78 File Offset: 0x0000CE78
		public unsafe static void CheckCubeTextureRequirements(Device deviceRef, ref int sizeRef, ref int numMipLevelsRef, int usage, ref Format formatRef, Pool pool)
		{
			Result result;
			fixed (int* ptr = &sizeRef)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &numMipLevelsRef)
				{
					void* arg2 = (void*)ptr2;
					fixed (Format* ptr3 = &formatRef)
					{
						void* arg3 = (void*)ptr3;
						result = D3DX9.D3DXCheckCubeTextureRequirements_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), arg, arg2, usage, arg3, (int)pool);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060003DD RID: 989
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCheckCubeTextureRequirements")]
		private unsafe static extern int D3DXCheckCubeTextureRequirements_(void* arg0, void* arg1, void* arg2, int arg3, void* arg4, int arg5);

		// Token: 0x060003DE RID: 990 RVA: 0x0000ECD4 File Offset: 0x0000CED4
		public unsafe static void CreateTextureFromFileW(Device deviceRef, string srcFileRef, out Texture textureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTextureFromFileW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x060003DF RID: 991
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromFileW")]
		private unsafe static extern int D3DXCreateTextureFromFileW_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003E0 RID: 992 RVA: 0x0000ED3C File Offset: 0x0000CF3C
		public unsafe static void LoadSurfaceFromFileW(Surface destSurfaceRef, PaletteEntry[] destPaletteRef, IntPtr destRectRef, string srcFileRef, IntPtr srcRectRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadSurfaceFromFileW_((void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), arg, (void*)destRectRef, (void*)intPtr, (void*)srcRectRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060003E1 RID: 993
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSurfaceFromFileW")]
		private unsafe static extern int D3DXLoadSurfaceFromFileW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, int arg6, void* arg7);

		// Token: 0x060003E2 RID: 994 RVA: 0x0000EDB8 File Offset: 0x0000CFB8
		public unsafe static void FillCubeTexture(CubeTexture cubeTextureRef, FunctionCallback functionRef, IntPtr dataRef)
		{
			D3DX9.D3DXFillCubeTexture_((void*)((cubeTextureRef == null) ? IntPtr.Zero : cubeTextureRef.NativePointer), functionRef, (void*)dataRef).CheckError();
		}

		// Token: 0x060003E3 RID: 995
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillCubeTexture")]
		private unsafe static extern int D3DXFillCubeTexture_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003E4 RID: 996 RVA: 0x0000EDF8 File Offset: 0x0000CFF8
		public unsafe static void CreateVolumeTexture(Device deviceRef, int width, int height, int depth, int mipLevels, int usage, Format format, Pool pool, out VolumeTexture volumeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateVolumeTexture_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), width, height, depth, mipLevels, usage, (int)format, (int)pool, (void*)(&zero));
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003E5 RID: 997
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTexture")]
		private unsafe static extern int D3DXCreateVolumeTexture_(void* arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, void* arg8);

		// Token: 0x060003E6 RID: 998 RVA: 0x0000EE5C File Offset: 0x0000D05C
		public unsafe static void LoadVolumeFromFileW(Volume destVolumeRef, PaletteEntry[] destPaletteRef, IntPtr destBoxRef, string srcFileRef, IntPtr srcBoxRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadVolumeFromFileW_((void*)((destVolumeRef == null) ? IntPtr.Zero : destVolumeRef.NativePointer), arg, (void*)destBoxRef, (void*)intPtr, (void*)srcBoxRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060003E7 RID: 999
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadVolumeFromFileW")]
		private unsafe static extern int D3DXLoadVolumeFromFileW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, int arg6, void* arg7);

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000EED8 File Offset: 0x0000D0D8
		public unsafe static void LoadSurfaceFromResourceW(Surface destSurfaceRef, PaletteEntry[] destPaletteRef, IntPtr destRectRef, IntPtr hSrcModule, string srcResourceRef, IntPtr srcRectRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadSurfaceFromResourceW_((void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), arg, (void*)destRectRef, (void*)hSrcModule, (void*)intPtr, (void*)srcRectRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060003E9 RID: 1001
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSurfaceFromResourceW")]
		private unsafe static extern int D3DXLoadSurfaceFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, int arg7, void* arg8);

		// Token: 0x060003EA RID: 1002 RVA: 0x0000EF5C File Offset: 0x0000D15C
		public unsafe static void CreateTextureFromFileExW(Device deviceRef, string srcFileRef, int width, int height, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out Texture textureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateTextureFromFileExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, width, height, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x060003EB RID: 1003
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromFileExW")]
		private unsafe static extern int D3DXCreateTextureFromFileExW_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, RawColorBGRA arg10, void* arg11, void* arg12, void* arg13);

		// Token: 0x060003EC RID: 1004 RVA: 0x0000EFFC File Offset: 0x0000D1FC
		public unsafe static void ComputeNormalMap(Texture textureRef, Texture srcTextureRef, PaletteEntry[] srcPaletteRef, int flags, int channel, float amplitude)
		{
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXComputeNormalMap_((void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), (void*)((srcTextureRef == null) ? IntPtr.Zero : srcTextureRef.NativePointer), arg, flags, channel, amplitude);
			}
			result.CheckError();
		}

		// Token: 0x060003ED RID: 1005
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXComputeNormalMap")]
		private unsafe static extern int D3DXComputeNormalMap_(void* arg0, void* arg1, void* arg2, int arg3, int arg4, float arg5);

		// Token: 0x060003EE RID: 1006 RVA: 0x0000F068 File Offset: 0x0000D268
		public unsafe static void CheckVolumeTextureRequirements(Device deviceRef, ref int widthRef, ref int heightRef, ref int depthRef, ref int numMipLevelsRef, int usage, ref Format formatRef, Pool pool)
		{
			Result result;
			fixed (int* ptr = &widthRef)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &heightRef)
				{
					void* arg2 = (void*)ptr2;
					fixed (int* ptr3 = &depthRef)
					{
						void* arg3 = (void*)ptr3;
						fixed (int* ptr4 = &numMipLevelsRef)
						{
							void* arg4 = (void*)ptr4;
							fixed (Format* ptr5 = &formatRef)
							{
								void* arg5 = (void*)ptr5;
								result = D3DX9.D3DXCheckVolumeTextureRequirements_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), arg, arg2, arg3, arg4, usage, arg5, (int)pool);
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060003EF RID: 1007
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCheckVolumeTextureRequirements")]
		private unsafe static extern int D3DXCheckVolumeTextureRequirements_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, int arg5, void* arg6, int arg7);

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000F0E4 File Offset: 0x0000D2E4
		public unsafe static void LoadSurfaceFromFileInMemory(Surface destSurfaceRef, PaletteEntry[] destPaletteRef, IntPtr destRectRef, IntPtr srcDataRef, int srcDataSize, IntPtr srcRectRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadSurfaceFromFileInMemory_((void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), arg, (void*)destRectRef, (void*)srcDataRef, srcDataSize, (void*)srcRectRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			result.CheckError();
		}

		// Token: 0x060003F1 RID: 1009
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSurfaceFromFileInMemory")]
		private unsafe static extern int D3DXLoadSurfaceFromFileInMemory_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, int arg6, int arg7, void* arg8);

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000F154 File Offset: 0x0000D354
		public unsafe static void CreateTextureFromFileInMemory(Device deviceRef, IntPtr srcDataRef, int srcDataSize, out Texture textureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTextureFromFileInMemory_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, (void*)(&zero));
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x060003F3 RID: 1011
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromFileInMemory")]
		private unsafe static extern int D3DXCreateTextureFromFileInMemory_(void* arg0, void* arg1, int arg2, void* arg3);

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
		public unsafe static void CreateCubeTextureFromResourceExW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, int size, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, ref ImageInformation srcInfoRef, PaletteEntry paletteRef, out CubeTexture cubeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (ImageInformation* ptr = &srcInfoRef)
			{
				void* arg = (void*)ptr;
				result = D3DX9.D3DXCreateCubeTextureFromResourceExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, size, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, arg, (void*)(&paletteRef), (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003F5 RID: 1013
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromResourceExW")]
		private unsafe static extern int D3DXCreateCubeTextureFromResourceExW_(void* arg0, void* arg1, void* arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, RawColorBGRA arg10, void* arg11, void* arg12, void* arg13);

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000F240 File Offset: 0x0000D440
		public unsafe static void CreateVolumeTextureFromFileInMemory(Device deviceRef, IntPtr srcDataRef, int srcDataSize, out VolumeTexture volumeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateVolumeTextureFromFileInMemory_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, (void*)(&zero));
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003F7 RID: 1015
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromFileInMemory")]
		private unsafe static extern int D3DXCreateVolumeTextureFromFileInMemory_(void* arg0, void* arg1, int arg2, void* arg3);

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000F29C File Offset: 0x0000D49C
		public unsafe static void LoadVolumeFromVolume(Volume destVolumeRef, PaletteEntry[] destPaletteRef, IntPtr destBoxRef, Volume srcVolumeRef, PaletteEntry[] srcPaletteRef, IntPtr srcBoxRef, Filter filter, int colorKey)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (PaletteEntry[] array2 = srcPaletteRef)
				{
					void* arg2;
					if (srcPaletteRef == null || array2.Length == 0)
					{
						arg2 = null;
					}
					else
					{
						arg2 = (void*)(&array2[0]);
					}
					result = D3DX9.D3DXLoadVolumeFromVolume_((void*)((destVolumeRef == null) ? IntPtr.Zero : destVolumeRef.NativePointer), arg, (void*)destBoxRef, (void*)((srcVolumeRef == null) ? IntPtr.Zero : srcVolumeRef.NativePointer), arg2, (void*)srcBoxRef, (int)filter, colorKey);
				}
			}
			result.CheckError();
		}

		// Token: 0x060003F9 RID: 1017
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadVolumeFromVolume")]
		private unsafe static extern int D3DXLoadVolumeFromVolume_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, int arg7);

		// Token: 0x060003FA RID: 1018 RVA: 0x0000F334 File Offset: 0x0000D534
		public unsafe static void SaveTextureToFileW(string destFileRef, ImageFileFormat destFormat, BaseTexture srcTextureRef, PaletteEntry[] srcPaletteRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(destFileRef);
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveTextureToFileW_((void*)intPtr, (int)destFormat, (void*)((srcTextureRef == null) ? IntPtr.Zero : srcTextureRef.NativePointer), arg);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060003FB RID: 1019
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveTextureToFileW")]
		private unsafe static extern int D3DXSaveTextureToFileW_(void* arg0, int arg1, void* arg2, void* arg3);

		// Token: 0x060003FC RID: 1020 RVA: 0x0000F398 File Offset: 0x0000D598
		public unsafe static void CreateCubeTextureFromFileW(Device deviceRef, string srcFileRef, out CubeTexture cubeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCubeTextureFromFileW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003FD RID: 1021
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromFileW")]
		private unsafe static extern int D3DXCreateCubeTextureFromFileW_(void* arg0, void* arg1, void* arg2);

		// Token: 0x060003FE RID: 1022 RVA: 0x0000F400 File Offset: 0x0000D600
		public unsafe static void CreateCubeTextureFromFileInMemoryEx(Device deviceRef, IntPtr srcDataRef, int srcDataSize, int size, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out CubeTexture cubeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateCubeTextureFromFileInMemoryEx_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, size, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x060003FF RID: 1023
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromFileInMemoryEx")]
		private unsafe static extern int D3DXCreateCubeTextureFromFileInMemoryEx_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, RawColorBGRA arg10, void* arg11, void* arg12, void* arg13);

		// Token: 0x06000400 RID: 1024 RVA: 0x0000F490 File Offset: 0x0000D690
		public unsafe static void CreateTextureFromResourceExW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, int width, int height, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, ref ImageInformation srcInfoRef, PaletteEntry paletteRef, out Texture textureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (ImageInformation* ptr = &srcInfoRef)
			{
				void* arg = (void*)ptr;
				result = D3DX9.D3DXCreateTextureFromResourceExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, width, height, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, arg, (void*)(&paletteRef), (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x06000401 RID: 1025
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromResourceExW")]
		private unsafe static extern int D3DXCreateTextureFromResourceExW_(void* arg0, void* arg1, void* arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, RawColorBGRA arg11, void* arg12, void* arg13, void* arg14);

		// Token: 0x06000402 RID: 1026 RVA: 0x0000F520 File Offset: 0x0000D720
		public unsafe static ImageInformation GetImageInfoFromFileW(string srcFileRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			ImageInformation result = default(ImageInformation);
			Result result2 = D3DX9.D3DXGetImageInfoFromFileW_((void*)intPtr, (void*)(&result));
			Marshal.FreeHGlobal(intPtr);
			result2.CheckError();
			return result;
		}

		// Token: 0x06000403 RID: 1027
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetImageInfoFromFileW")]
		private unsafe static extern int D3DXGetImageInfoFromFileW_(void* arg0, void* arg1);

		// Token: 0x06000404 RID: 1028 RVA: 0x0000F55C File Offset: 0x0000D75C
		public unsafe static void FilterTexture(BaseTexture baseTextureRef, PaletteEntry[] paletteRef, int srcLevel, Filter filter)
		{
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXFilterTexture_((void*)((baseTextureRef == null) ? IntPtr.Zero : baseTextureRef.NativePointer), arg, srcLevel, (int)filter);
			}
			result.CheckError();
		}

		// Token: 0x06000405 RID: 1029
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFilterTexture")]
		private unsafe static extern int D3DXFilterTexture_(void* arg0, void* arg1, int arg2, int arg3);

		// Token: 0x06000406 RID: 1030 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
		public unsafe static void LoadSurfaceFromMemory(Surface destSurfaceRef, PaletteEntry[] destPaletteRef, IntPtr destRectRef, IntPtr srcMemoryRef, Format srcFormat, int srcPitch, PaletteEntry[] srcPaletteRef, IntPtr srcRectRef, Filter filter, int colorKey)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (PaletteEntry[] array2 = srcPaletteRef)
				{
					void* arg2;
					if (srcPaletteRef == null || array2.Length == 0)
					{
						arg2 = null;
					}
					else
					{
						arg2 = (void*)(&array2[0]);
					}
					result = D3DX9.D3DXLoadSurfaceFromMemory_((void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), arg, (void*)destRectRef, (void*)srcMemoryRef, (int)srcFormat, srcPitch, arg2, (void*)srcRectRef, (int)filter, colorKey);
				}
			}
			result.CheckError();
		}

		// Token: 0x06000407 RID: 1031
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSurfaceFromMemory")]
		private unsafe static extern int D3DXLoadSurfaceFromMemory_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, int arg5, void* arg6, void* arg7, int arg8, int arg9);

		// Token: 0x06000408 RID: 1032 RVA: 0x0000F63C File Offset: 0x0000D83C
		public unsafe static Blob SaveTextureToFileInMemory(ImageFileFormat destFormat, BaseTexture srcTextureRef, PaletteEntry[] srcPaletteRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveTextureToFileInMemory_((void*)(&zero), (int)destFormat, (void*)((srcTextureRef == null) ? IntPtr.Zero : srcTextureRef.NativePointer), arg);
			}
			Blob result2 = (zero == IntPtr.Zero) ? null : new Blob(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000409 RID: 1033
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveTextureToFileInMemory")]
		private unsafe static extern int D3DXSaveTextureToFileInMemory_(void* arg0, int arg1, void* arg2, void* arg3);

		// Token: 0x0600040A RID: 1034 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		public unsafe static void CheckTextureRequirements(Device deviceRef, ref int widthRef, ref int heightRef, ref int numMipLevelsRef, int usage, ref Format formatRef, Pool pool)
		{
			Result result;
			fixed (int* ptr = &widthRef)
			{
				void* arg = (void*)ptr;
				fixed (int* ptr2 = &heightRef)
				{
					void* arg2 = (void*)ptr2;
					fixed (int* ptr3 = &numMipLevelsRef)
					{
						void* arg3 = (void*)ptr3;
						fixed (Format* ptr4 = &formatRef)
						{
							void* arg4 = (void*)ptr4;
							result = D3DX9.D3DXCheckTextureRequirements_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), arg, arg2, arg3, usage, arg4, (int)pool);
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600040B RID: 1035
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCheckTextureRequirements")]
		private unsafe static extern int D3DXCheckTextureRequirements_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, int arg6);

		// Token: 0x0600040C RID: 1036 RVA: 0x0000F718 File Offset: 0x0000D918
		public unsafe static void SaveVolumeToFileW(string destFileRef, ImageFileFormat destFormat, Volume srcVolumeRef, PaletteEntry[] srcPaletteRef, IntPtr srcBoxRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(destFileRef);
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveVolumeToFileW_((void*)intPtr, (int)destFormat, (void*)((srcVolumeRef == null) ? IntPtr.Zero : srcVolumeRef.NativePointer), arg, (void*)srcBoxRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600040D RID: 1037
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveVolumeToFileW")]
		private unsafe static extern int D3DXSaveVolumeToFileW_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x0600040E RID: 1038 RVA: 0x0000F780 File Offset: 0x0000D980
		public unsafe static void LoadVolumeFromResourceW(Volume destVolumeRef, PaletteEntry[] destPaletteRef, IntPtr destBoxRef, IntPtr hSrcModule, string srcResourceRef, IntPtr srcBoxRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadVolumeFromResourceW_((void*)((destVolumeRef == null) ? IntPtr.Zero : destVolumeRef.NativePointer), arg, (void*)destBoxRef, (void*)hSrcModule, (void*)intPtr, (void*)srcBoxRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600040F RID: 1039
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadVolumeFromResourceW")]
		private unsafe static extern int D3DXLoadVolumeFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, int arg7, void* arg8);

		// Token: 0x06000410 RID: 1040 RVA: 0x0000F804 File Offset: 0x0000DA04
		public unsafe static void CreateVolumeTextureFromResourceExW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, int width, int height, int depth, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, ref ImageInformation srcInfoRef, PaletteEntry paletteRef, out VolumeTexture volumeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (ImageInformation* ptr = &srcInfoRef)
			{
				void* arg = (void*)ptr;
				result = D3DX9.D3DXCreateVolumeTextureFromResourceExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, width, height, depth, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, arg, (void*)(&paletteRef), (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000411 RID: 1041
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromResourceExW")]
		private unsafe static extern int D3DXCreateVolumeTextureFromResourceExW_(void* arg0, void* arg1, void* arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, RawColorBGRA arg12, void* arg13, void* arg14, void* arg15);

		// Token: 0x06000412 RID: 1042 RVA: 0x0000F898 File Offset: 0x0000DA98
		public unsafe static void CreateCubeTextureFromResourceW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, out CubeTexture cubeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCubeTextureFromResourceW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000413 RID: 1043
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromResourceW")]
		private unsafe static extern int D3DXCreateCubeTextureFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3);

		// Token: 0x06000414 RID: 1044 RVA: 0x0000F908 File Offset: 0x0000DB08
		public unsafe static void SaveSurfaceToFileW(string destFileRef, ImageFileFormat destFormat, Surface srcSurfaceRef, PaletteEntry[] srcPaletteRef, IntPtr srcRectRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(destFileRef);
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveSurfaceToFileW_((void*)intPtr, (int)destFormat, (void*)((srcSurfaceRef == null) ? IntPtr.Zero : srcSurfaceRef.NativePointer), arg, (void*)srcRectRef);
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x06000415 RID: 1045
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveSurfaceToFileW")]
		private unsafe static extern int D3DXSaveSurfaceToFileW_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x06000416 RID: 1046 RVA: 0x0000F970 File Offset: 0x0000DB70
		public unsafe static void CreateCubeTextureFromFileInMemory(Device deviceRef, IntPtr srcDataRef, int srcDataSize, out CubeTexture cubeTextureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateCubeTextureFromFileInMemory_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, (void*)(&zero));
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000417 RID: 1047
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromFileInMemory")]
		private unsafe static extern int D3DXCreateCubeTextureFromFileInMemory_(void* arg0, void* arg1, int arg2, void* arg3);

		// Token: 0x06000418 RID: 1048 RVA: 0x0000F9CC File Offset: 0x0000DBCC
		public unsafe static void CreateCubeTextureFromFileExW(Device deviceRef, string srcFileRef, int size, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out CubeTexture cubeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateCubeTextureFromFileExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, size, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			cubeTextureOut = ((zero == IntPtr.Zero) ? null : new CubeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000419 RID: 1049
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateCubeTextureFromFileExW")]
		private unsafe static extern int D3DXCreateCubeTextureFromFileExW_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, RawColorBGRA arg9, void* arg10, void* arg11, void* arg12);

		// Token: 0x0600041A RID: 1050 RVA: 0x0000FA6C File Offset: 0x0000DC6C
		public unsafe static ImageInformation GetImageInfoFromResourceW(IntPtr hSrcModule, string srcResourceRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			ImageInformation result = default(ImageInformation);
			Result result2 = D3DX9.D3DXGetImageInfoFromResourceW_((void*)hSrcModule, (void*)intPtr, (void*)(&result));
			Marshal.FreeHGlobal(intPtr);
			result2.CheckError();
			return result;
		}

		// Token: 0x0600041B RID: 1051
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXGetImageInfoFromResourceW")]
		private unsafe static extern int D3DXGetImageInfoFromResourceW_(void* arg0, void* arg1, void* arg2);

		// Token: 0x0600041C RID: 1052 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		public unsafe static void FillCubeTextureTX(CubeTexture cubeTextureRef, TextureShader textureShaderRef)
		{
			D3DX9.D3DXFillCubeTextureTX_((void*)((cubeTextureRef == null) ? IntPtr.Zero : cubeTextureRef.NativePointer), (void*)((textureShaderRef == null) ? IntPtr.Zero : textureShaderRef.NativePointer)).CheckError();
		}

		// Token: 0x0600041D RID: 1053
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillCubeTextureTX")]
		private unsafe static extern int D3DXFillCubeTextureTX_(void* arg0, void* arg1);

		// Token: 0x0600041E RID: 1054 RVA: 0x0000FAFC File Offset: 0x0000DCFC
		public unsafe static void FillTexture(Texture textureRef, FunctionCallback functionRef, IntPtr dataRef)
		{
			D3DX9.D3DXFillTexture_((void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), functionRef, (void*)dataRef).CheckError();
		}

		// Token: 0x0600041F RID: 1055
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillTexture")]
		private unsafe static extern int D3DXFillTexture_(void* arg0, void* arg1, void* arg2);

		// Token: 0x06000420 RID: 1056 RVA: 0x0000FB3C File Offset: 0x0000DD3C
		public unsafe static void SaveSurfaceToFileInMemory(out Blob destBufOut, ImageFileFormat destFormat, Surface srcSurfaceRef, PaletteEntry[] srcPaletteRef, IntPtr srcRectRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveSurfaceToFileInMemory_((void*)(&zero), (int)destFormat, (void*)((srcSurfaceRef == null) ? IntPtr.Zero : srcSurfaceRef.NativePointer), arg, (void*)srcRectRef);
			}
			destBufOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000421 RID: 1057
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveSurfaceToFileInMemory")]
		private unsafe static extern int D3DXSaveSurfaceToFileInMemory_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x06000422 RID: 1058 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
		public unsafe static void CreateVolumeTextureFromFileW(Device deviceRef, string srcFileRef, out VolumeTexture volumeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateVolumeTextureFromFileW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000423 RID: 1059
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromFileW")]
		private unsafe static extern int D3DXCreateVolumeTextureFromFileW_(void* arg0, void* arg1, void* arg2);

		// Token: 0x06000424 RID: 1060 RVA: 0x0000FC1C File Offset: 0x0000DE1C
		public unsafe static void CreateTextureFromResourceW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, out Texture textureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTextureFromResourceW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x06000425 RID: 1061
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromResourceW")]
		private unsafe static extern int D3DXCreateTextureFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3);

		// Token: 0x06000426 RID: 1062 RVA: 0x0000FC8C File Offset: 0x0000DE8C
		public unsafe static void LoadVolumeFromMemory(Volume destVolumeRef, PaletteEntry[] destPaletteRef, IntPtr destBoxRef, IntPtr srcMemoryRef, Format srcFormat, int srcRowPitch, int srcSlicePitch, PaletteEntry[] srcPaletteRef, IntPtr srcBoxRef, Filter filter, int colorKey)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (PaletteEntry[] array2 = srcPaletteRef)
				{
					void* arg2;
					if (srcPaletteRef == null || array2.Length == 0)
					{
						arg2 = null;
					}
					else
					{
						arg2 = (void*)(&array2[0]);
					}
					result = D3DX9.D3DXLoadVolumeFromMemory_((void*)((destVolumeRef == null) ? IntPtr.Zero : destVolumeRef.NativePointer), arg, (void*)destBoxRef, (void*)srcMemoryRef, (int)srcFormat, srcRowPitch, srcSlicePitch, arg2, (void*)srcBoxRef, (int)filter, colorKey);
				}
			}
			result.CheckError();
		}

		// Token: 0x06000427 RID: 1063
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadVolumeFromMemory")]
		private unsafe static extern int D3DXLoadVolumeFromMemory_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, int arg5, int arg6, void* arg7, void* arg8, int arg9, int arg10);

		// Token: 0x06000428 RID: 1064 RVA: 0x0000FD18 File Offset: 0x0000DF18
		public unsafe static void CreateVolumeTextureFromFileExW(Device deviceRef, string srcFileRef, int width, int height, int depth, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out VolumeTexture volumeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcFileRef);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateVolumeTextureFromFileExW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)intPtr, width, height, depth, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			Marshal.FreeHGlobal(intPtr);
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000429 RID: 1065
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromFileExW")]
		private unsafe static extern int D3DXCreateVolumeTextureFromFileExW_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, RawColorBGRA arg11, void* arg12, void* arg13, void* arg14);

		// Token: 0x0600042A RID: 1066 RVA: 0x0000FDBC File Offset: 0x0000DFBC
		public unsafe static void CreateTextureFromFileInMemoryEx(Device deviceRef, IntPtr srcDataRef, int srcDataSize, int width, int height, int mipLevels, int usage, Format format, Pool pool, int filter, int mipFilter, RawColorBGRA colorKey, IntPtr srcInfoRef, PaletteEntry[] paletteRef, out Texture textureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = paletteRef)
			{
				void* arg;
				if (paletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXCreateTextureFromFileInMemoryEx_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)srcDataRef, srcDataSize, width, height, mipLevels, usage, (int)format, (int)pool, filter, mipFilter, colorKey, (void*)srcInfoRef, arg, (void*)(&zero));
			}
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x0600042B RID: 1067
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTextureFromFileInMemoryEx")]
		private unsafe static extern int D3DXCreateTextureFromFileInMemoryEx_(void* arg0, void* arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, RawColorBGRA arg11, void* arg12, void* arg13, void* arg14);

		// Token: 0x0600042C RID: 1068 RVA: 0x0000FE50 File Offset: 0x0000E050
		public unsafe static void SaveVolumeToFileInMemory(out Blob destBufOut, ImageFileFormat destFormat, Volume srcVolumeRef, PaletteEntry[] srcPaletteRef, IntPtr srcBoxRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PaletteEntry[] array = srcPaletteRef)
			{
				void* arg;
				if (srcPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXSaveVolumeToFileInMemory_((void*)(&zero), (int)destFormat, (void*)((srcVolumeRef == null) ? IntPtr.Zero : srcVolumeRef.NativePointer), arg, (void*)srcBoxRef);
			}
			destBufOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600042D RID: 1069
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXSaveVolumeToFileInMemory")]
		private unsafe static extern int D3DXSaveVolumeToFileInMemory_(void* arg0, int arg1, void* arg2, void* arg3, void* arg4);

		// Token: 0x0600042E RID: 1070 RVA: 0x0000FEC8 File Offset: 0x0000E0C8
		public unsafe static void CreateVolumeTextureFromResourceW(Device deviceRef, IntPtr hSrcModule, string srcResourceRef, out VolumeTexture volumeTextureOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(srcResourceRef);
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateVolumeTextureFromResourceW_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), (void*)hSrcModule, (void*)intPtr, (void*)(&zero));
			Marshal.FreeHGlobal(intPtr);
			volumeTextureOut = ((zero == IntPtr.Zero) ? null : new VolumeTexture(zero));
			result.CheckError();
		}

		// Token: 0x0600042F RID: 1071
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateVolumeTextureFromResourceW")]
		private unsafe static extern int D3DXCreateVolumeTextureFromResourceW_(void* arg0, void* arg1, void* arg2, void* arg3);

		// Token: 0x06000430 RID: 1072 RVA: 0x0000FF38 File Offset: 0x0000E138
		public unsafe static void CreateTexture(Device deviceRef, int width, int height, int mipLevels, int usage, Format format, Pool pool, out Texture textureOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXCreateTexture_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), width, height, mipLevels, usage, (int)format, (int)pool, (void*)(&zero));
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x06000431 RID: 1073
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXCreateTexture")]
		private unsafe static extern int D3DXCreateTexture_(void* arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, void* arg7);

		// Token: 0x06000432 RID: 1074 RVA: 0x0000FF98 File Offset: 0x0000E198
		public unsafe static void FillVolumeTexture(VolumeTexture volumeTextureRef, FunctionCallback functionRef, IntPtr dataRef)
		{
			D3DX9.D3DXFillVolumeTexture_((void*)((volumeTextureRef == null) ? IntPtr.Zero : volumeTextureRef.NativePointer), functionRef, (void*)dataRef).CheckError();
		}

		// Token: 0x06000433 RID: 1075
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFillVolumeTexture")]
		private unsafe static extern int D3DXFillVolumeTexture_(void* arg0, void* arg1, void* arg2);

		// Token: 0x06000434 RID: 1076 RVA: 0x0000FFD8 File Offset: 0x0000E1D8
		public unsafe static void LoadSurfaceFromSurface(Surface destSurfaceRef, PaletteEntry[] destPaletteRef, IntPtr destRectRef, Surface srcSurfaceRef, PaletteEntry[] srcPaletteRef, IntPtr srcRectRef, Filter filter, int colorKey)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				fixed (PaletteEntry[] array2 = srcPaletteRef)
				{
					void* arg2;
					if (srcPaletteRef == null || array2.Length == 0)
					{
						arg2 = null;
					}
					else
					{
						arg2 = (void*)(&array2[0]);
					}
					result = D3DX9.D3DXLoadSurfaceFromSurface_((void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), arg, (void*)destRectRef, (void*)((srcSurfaceRef == null) ? IntPtr.Zero : srcSurfaceRef.NativePointer), arg2, (void*)srcRectRef, (int)filter, colorKey);
				}
			}
			result.CheckError();
		}

		// Token: 0x06000435 RID: 1077
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadSurfaceFromSurface")]
		private unsafe static extern int D3DXLoadSurfaceFromSurface_(void* arg0, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, int arg6, int arg7);

		// Token: 0x06000436 RID: 1078 RVA: 0x00010070 File Offset: 0x0000E270
		public unsafe static void LoadVolumeFromFileInMemory(Volume destVolumeRef, PaletteEntry[] destPaletteRef, IntPtr destBoxRef, IntPtr srcDataRef, int srcDataSize, IntPtr srcBoxRef, Filter filter, int colorKey, IntPtr srcInfoRef)
		{
			Result result;
			fixed (PaletteEntry[] array = destPaletteRef)
			{
				void* arg;
				if (destPaletteRef == null || array.Length == 0)
				{
					arg = null;
				}
				else
				{
					arg = (void*)(&array[0]);
				}
				result = D3DX9.D3DXLoadVolumeFromFileInMemory_((void*)((destVolumeRef == null) ? IntPtr.Zero : destVolumeRef.NativePointer), arg, (void*)destBoxRef, (void*)srcDataRef, srcDataSize, (void*)srcBoxRef, (int)filter, colorKey, (void*)srcInfoRef);
			}
			result.CheckError();
		}

		// Token: 0x06000437 RID: 1079
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXLoadVolumeFromFileInMemory")]
		private unsafe static extern int D3DXLoadVolumeFromFileInMemory_(void* arg0, void* arg1, void* arg2, void* arg3, int arg4, void* arg5, int arg6, int arg7, void* arg8);

		// Token: 0x06000438 RID: 1080 RVA: 0x000100E0 File Offset: 0x0000E2E0
		public unsafe static void FileCreate(out XFile lplpDirectXFile)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = D3DX9.D3DXFileCreate_((void*)(&zero));
			lplpDirectXFile = ((zero == IntPtr.Zero) ? null : new XFile(zero));
			result.CheckError();
		}

		// Token: 0x06000439 RID: 1081
		[DllImport("d3dx9_43.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DXFileCreate")]
		private unsafe static extern int D3DXFileCreate_(void* arg0);

		// Token: 0x040009AA RID: 2474
		public const int Version = 2306;

		// Token: 0x040009AB RID: 2475
		public const int SdkVersion = 43;
	}
}
