using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AC RID: 172
	[Guid("698cfb3f-9289-4d95-9a57-33a94b5a65f9")]
	public class AnimationSet : ComObject
	{
		// Token: 0x06000471 RID: 1137 RVA: 0x00002623 File Offset: 0x00000823
		public AnimationSet(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00010E5F File Offset: 0x0000F05F
		public new static explicit operator AnimationSet(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new AnimationSet(nativePointer);
			}
			return null;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00010E76 File Offset: 0x0000F076
		public string Name
		{
			get
			{
				return this.GetName();
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00010E7E File Offset: 0x0000F07E
		public double Period
		{
			get
			{
				return this.GetPeriod();
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00010E86 File Offset: 0x0000F086
		public int NumAnimations
		{
			get
			{
				return this.GetNumAnimations();
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00010E8E File Offset: 0x0000F08E
		internal unsafe string GetName()
		{
			return Marshal.PtrToStringAnsi(calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00010EB2 File Offset: 0x0000F0B2
		internal unsafe double GetPeriod()
		{
			return calli(System.Double(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00010ED1 File Offset: 0x0000F0D1
		public unsafe double GetPeriodicPosition(double position)
		{
			return calli(System.Double(System.Void*,System.Double), this._nativePointer, position, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001060E File Offset: 0x0000E80E
		internal unsafe int GetNumAnimations()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00010EF4 File Offset: 0x0000F0F4
		public unsafe void GetAnimationNameByIndex(int index, string nameOut)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameOut);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00010F40 File Offset: 0x0000F140
		public unsafe void GetAnimationIndexByName(string nameRef, int indexRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &indexRef, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00010F90 File Offset: 0x0000F190
		public unsafe void GetSRT(double periodicPosition, int animation, out RawVector3 scaleRef, out RawQuaternion rotationRef, out RawVector3 translationRef)
		{
			scaleRef = default(RawVector3);
			rotationRef = default(RawQuaternion);
			translationRef = default(RawVector3);
			Result result;
			fixed (RawVector3* ptr = &scaleRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawQuaternion* ptr3 = &rotationRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (RawVector3* ptr5 = &translationRef)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Double,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, periodicPosition, animation, ptr2, ptr4, ptr6, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00011008 File Offset: 0x0000F208
		public unsafe void GetCallback(double position, int flags, out double callbackPositionRef, IntPtr callbackDataOut)
		{
			Result result;
			fixed (double* ptr = &callbackPositionRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Double,System.Int32,System.Void*,System.Void*), this._nativePointer, position, flags, ptr2, (void*)callbackDataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
