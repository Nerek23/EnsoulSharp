using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AB RID: 171
	[Guid("ac8948ec-f86d-43e2-96de-31fc35f96d9e")]
	public class AnimationController : ComObject
	{
		// Token: 0x0600043F RID: 1087 RVA: 0x00002623 File Offset: 0x00000823
		public AnimationController(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00010570 File Offset: 0x0000E770
		public new static explicit operator AnimationController(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new AnimationController(nativePointer);
			}
			return null;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00010587 File Offset: 0x0000E787
		public int MaxNumAnimationOutputs
		{
			get
			{
				return this.GetMaxNumAnimationOutputs();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0001058F File Offset: 0x0000E78F
		public int MaxNumAnimationSets
		{
			get
			{
				return this.GetMaxNumAnimationSets();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00010597 File Offset: 0x0000E797
		public int MaxNumTracks
		{
			get
			{
				return this.GetMaxNumTracks();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x0001059F File Offset: 0x0000E79F
		public int MaxNumEvents
		{
			get
			{
				return this.GetMaxNumEvents();
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000105A7 File Offset: 0x0000E7A7
		public int NumAnimationSets
		{
			get
			{
				return this.GetNumAnimationSets();
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x000105AF File Offset: 0x0000E7AF
		public double Time
		{
			get
			{
				return this.GetTime();
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000105B7 File Offset: 0x0000E7B7
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000105BF File Offset: 0x0000E7BF
		public float PriorityBlend
		{
			get
			{
				return this.GetPriorityBlend();
			}
			set
			{
				this.SetPriorityBlend(value);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000105C8 File Offset: 0x0000E7C8
		public int CurrentPriorityBlend
		{
			get
			{
				return this.GetCurrentPriorityBlend();
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000105D0 File Offset: 0x0000E7D0
		internal unsafe int GetMaxNumAnimationOutputs()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetMaxNumAnimationSets()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000105EF File Offset: 0x0000E7EF
		internal unsafe int GetMaxNumTracks()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0001060E File Offset: 0x0000E80E
		internal unsafe int GetMaxNumEvents()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00010630 File Offset: 0x0000E830
		public unsafe void RegisterAnimationOutput(string nameRef, ref RawMatrix matrixRef, RawVector3 scaleRef, RawQuaternion rotationRef, RawVector3 translationRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, ptr2, &scaleRef, &rotationRef, &translationRef, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0001068C File Offset: 0x0000E88C
		public unsafe void RegisterAnimationSet(AnimationSet animSetRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((animSetRef == null) ? IntPtr.Zero : animSetRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000106D8 File Offset: 0x0000E8D8
		public unsafe void UnregisterAnimationSet(AnimationSet animSetRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((animSetRef == null) ? IntPtr.Zero : animSetRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00010725 File Offset: 0x0000E925
		internal unsafe int GetNumAnimationSets()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00010748 File Offset: 0x0000E948
		public unsafe void GetAnimationSet(int index, out AnimationSet animationSetOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			animationSetOut = ((zero == IntPtr.Zero) ? null : new AnimationSet(zero));
			result.CheckError();
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000107A4 File Offset: 0x0000E9A4
		public unsafe void GetAnimationSetByName(string szName, out AnimationSet animationSetOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(szName);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			animationSetOut = ((zero == IntPtr.Zero) ? null : new AnimationSet(zero));
			result.CheckError();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00010810 File Offset: 0x0000EA10
		public unsafe void AdvanceTime(double timeDelta, AnimationCallbackHandler callbackHandlerRef)
		{
			calli(System.Int32(System.Void*,System.Double,System.Void*), this._nativePointer, timeDelta, (void*)((callbackHandlerRef == null) ? IntPtr.Zero : callbackHandlerRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00010860 File Offset: 0x0000EA60
		public unsafe void ResetTime()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00010898 File Offset: 0x0000EA98
		internal unsafe double GetTime()
		{
			return calli(System.Double(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000108B8 File Offset: 0x0000EAB8
		public unsafe void SetTrackAnimationSet(int track, AnimationSet animSetRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, track, (void*)((animSetRef == null) ? IntPtr.Zero : animSetRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00010908 File Offset: 0x0000EB08
		public unsafe void GetTrackAnimationSet(int track, out AnimationSet animSetOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, track, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			animSetOut = ((zero == IntPtr.Zero) ? null : new AnimationSet(zero));
			result.CheckError();
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00010964 File Offset: 0x0000EB64
		public unsafe void SetTrackPriority(int track, TrackPriority priority)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, track, priority, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000109A0 File Offset: 0x0000EBA0
		public unsafe void SetTrackSpeed(int track, float speed)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Single), this._nativePointer, track, speed, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000109DC File Offset: 0x0000EBDC
		public unsafe void SetTrackWeight(int track, float weight)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Single), this._nativePointer, track, weight, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00010A18 File Offset: 0x0000EC18
		public unsafe void SetTrackPosition(int track, double position)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Double), this._nativePointer, track, position, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00010A54 File Offset: 0x0000EC54
		public unsafe void SetTrackEnable(int track, RawBool enable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, track, enable, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00010A90 File Offset: 0x0000EC90
		public unsafe void SetTrackDescription(int track, ref TrackDescription descRef)
		{
			Result result;
			fixed (TrackDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, track, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00010AD4 File Offset: 0x0000ECD4
		public unsafe void GetTrackDescription(int track, ref TrackDescription descRef)
		{
			Result result;
			fixed (TrackDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, track, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00010B18 File Offset: 0x0000ED18
		internal unsafe void SetPriorityBlend(float blendWeight)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, blendWeight, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00010B51 File Offset: 0x0000ED51
		internal unsafe float GetPriorityBlend()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00010B74 File Offset: 0x0000ED74
		public unsafe int KeyTrackSpeed(int track, float newSpeed, double startTime, double duration, TransitionType transition)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Single,System.Double,System.Double,System.Int32), this._nativePointer, track, newSpeed, startTime, duration, transition, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00010BA8 File Offset: 0x0000EDA8
		public unsafe int KeyTrackWeight(int track, float newWeight, double startTime, double duration, TransitionType transition)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Single,System.Double,System.Double,System.Int32), this._nativePointer, track, newWeight, startTime, duration, transition, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00010BDA File Offset: 0x0000EDDA
		public unsafe int KeyTrackPosition(int track, double newPosition, double startTime)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Double,System.Double), this._nativePointer, track, newPosition, startTime, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00010BFD File Offset: 0x0000EDFD
		public unsafe int KeyTrackEnable(int track, RawBool newEnable, double startTime)
		{
			return calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Double), this._nativePointer, track, newEnable, startTime, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00010C20 File Offset: 0x0000EE20
		public unsafe int KeyPriorityBlend(float newBlendWeight, double startTime, double duration, TransitionType transition)
		{
			return calli(System.Int32(System.Void*,System.Single,System.Double,System.Double,System.Int32), this._nativePointer, newBlendWeight, startTime, duration, transition, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00010C48 File Offset: 0x0000EE48
		public unsafe void UnkeyEvent(int hEvent)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00010C84 File Offset: 0x0000EE84
		public unsafe void UnkeyAllTrackEvents(int track)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, track, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00010CC0 File Offset: 0x0000EEC0
		public unsafe void UnkeyAllPriorityBlends()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00010CF8 File Offset: 0x0000EEF8
		public unsafe int GetCurrentTrackEvent(int track, EventType eventType)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, track, eventType, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00010D1A File Offset: 0x0000EF1A
		internal unsafe int GetCurrentPriorityBlend()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00010D3A File Offset: 0x0000EF3A
		public unsafe int GetUpcomingTrackEvent(int track, int hEvent)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, track, hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00010D5C File Offset: 0x0000EF5C
		public unsafe int GetUpcomingPriorityBlend(int hEvent)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00010D80 File Offset: 0x0000EF80
		public unsafe void ValidateEvent(int hEvent)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00010DBC File Offset: 0x0000EFBC
		public unsafe void GetEventDescription(int hEvent, ref EventDescription descRef)
		{
			Result result;
			fixed (EventDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, hEvent, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00010E00 File Offset: 0x0000F000
		public unsafe void CloneAnimationController(int maxNumAnimationOutputs, int maxNumAnimationSets, int maxNumTracks, int maxNumEvents, out AnimationController animControllerOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, maxNumAnimationOutputs, maxNumAnimationSets, maxNumTracks, maxNumEvents, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			animControllerOut = ((zero == IntPtr.Zero) ? null : new AnimationController(zero));
			result.CheckError();
		}
	}
}
