using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B5 RID: 181
	[Guid("fa4e8e3a-9786-407d-8b4c-5995893764af")]
	public class KeyframedAnimationSet : AnimationSet
	{
		// Token: 0x060004DE RID: 1246 RVA: 0x000115B7 File Offset: 0x0000F7B7
		public KeyframedAnimationSet(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000122D4 File Offset: 0x000104D4
		public new static explicit operator KeyframedAnimationSet(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new KeyframedAnimationSet(nativePointer);
			}
			return null;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000122EB File Offset: 0x000104EB
		public PlaybackType PlaybackType
		{
			get
			{
				return this.GetPlaybackType();
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x000122F3 File Offset: 0x000104F3
		public double SourceTicksPerSecond
		{
			get
			{
				return this.GetSourceTicksPerSecond();
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x000122FB File Offset: 0x000104FB
		public int NumCallbackKeys
		{
			get
			{
				return this.GetNumCallbackKeys();
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00011606 File Offset: 0x0000F806
		internal unsafe PlaybackType GetPlaybackType()
		{
			return calli(SharpDX.Direct3D9.PlaybackType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00011626 File Offset: 0x0000F826
		internal unsafe double GetSourceTicksPerSecond()
		{
			return calli(System.Double(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00012303 File Offset: 0x00010503
		public unsafe int GetNumScaleKeys(int animation)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, animation, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00012324 File Offset: 0x00010524
		public unsafe void GetScaleKeys(int animation, ScaleKey scaleKeysRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, animation, &scaleKeysRef, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00012360 File Offset: 0x00010560
		public unsafe void GetScaleKey(int animation, int key, ScaleKey scaleKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, &scaleKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000123A0 File Offset: 0x000105A0
		public unsafe void SetScaleKey(int animation, int key, ScaleKey scaleKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, &scaleKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000123DD File Offset: 0x000105DD
		public unsafe int GetNumRotationKeys(int animation)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, animation, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00012400 File Offset: 0x00010600
		public unsafe void GetRotationKeys(int animation, ref RotationKey rotationKeysRef)
		{
			Result result;
			fixed (RotationKey* ptr = &rotationKeysRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, animation, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00012444 File Offset: 0x00010644
		public unsafe void GetRotationKey(int animation, int key, ref RotationKey rotationKeyRef)
		{
			Result result;
			fixed (RotationKey* ptr = &rotationKeyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00012488 File Offset: 0x00010688
		public unsafe void SetRotationKey(int animation, int key, ref RotationKey rotationKeyRef)
		{
			Result result;
			fixed (RotationKey* ptr = &rotationKeyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x000124CB File Offset: 0x000106CB
		public unsafe int GetNumTranslationKeys(int animation)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, animation, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000124EC File Offset: 0x000106EC
		public unsafe void GetTranslationKeys(int animation, ScaleKey translationKeysRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, animation, &translationKeysRef, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00012528 File Offset: 0x00010728
		public unsafe void GetTranslationKey(int animation, int key, ScaleKey translationKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, &translationKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00012568 File Offset: 0x00010768
		public unsafe void SetTranslationKey(int animation, int key, ScaleKey translationKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, animation, key, &translationKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000125A5 File Offset: 0x000107A5
		internal unsafe int GetNumCallbackKeys()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000125C8 File Offset: 0x000107C8
		public unsafe void GetCallbackKeys(CallbackKey callbackKeysRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &callbackKeysRef, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00012604 File Offset: 0x00010804
		public unsafe void GetCallbackKey(int key, CallbackKey callbackKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, key, &callbackKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00012640 File Offset: 0x00010840
		public unsafe void SetCallbackKey(int key, CallbackKey callbackKeyRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, key, &callbackKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0001267C File Offset: 0x0001087C
		public unsafe void UnregisterScaleKey(int animation, int key)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, animation, key, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000126B8 File Offset: 0x000108B8
		public unsafe void UnregisterRotationKey(int animation, int key)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, animation, key, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x000126F4 File Offset: 0x000108F4
		public unsafe void UnregisterTranslationKey(int animation, int key)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, animation, key, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00012730 File Offset: 0x00010930
		public unsafe void RegisterAnimationSRTKeys(string nameRef, int numScaleKeys, int numRotationKeys, int numTranslationKeys, ScaleKey scaleKeysRef, ref RotationKey rotationKeysRef, ScaleKey translationKeysRef, int animationIndexRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			Result result;
			fixed (RotationKey* ptr = &rotationKeysRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, numScaleKeys, numRotationKeys, numTranslationKeys, &scaleKeysRef, ptr2, &translationKeysRef, &animationIndexRef, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00012794 File Offset: 0x00010994
		public unsafe void Compress(int flags, float lossiness, ref Frame hierarchyRef, out Blob compressedDataOut)
		{
			Frame.__Native _Native = default(Frame.__Native);
			hierarchyRef.__MarshalTo(ref _Native);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Single,System.Void*,System.Void*), this._nativePointer, flags, lossiness, &_Native, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			hierarchyRef.__MarshalFree(ref _Native);
			compressedDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0001280C File Offset: 0x00010A0C
		public unsafe void UnregisterAnimation(int index)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
