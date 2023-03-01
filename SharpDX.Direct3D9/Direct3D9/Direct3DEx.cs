using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200001B RID: 27
	[Guid("02177241-69FC-400C-8FF1-93A44DF6861D")]
	public class Direct3DEx : Direct3D
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00009163 File Offset: 0x00007363
		public Direct3DEx() : base(IntPtr.Zero)
		{
			D3D9.Create9Ex(32, this);
			base.Adapters = new AdapterCollection(this);
			this.AdaptersEx = new AdapterExCollection(this);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009190 File Offset: 0x00007390
		public DisplayModeEx GetAdapterDisplayModeEx(int adapter)
		{
			DisplayRotation displayRotation;
			return this.GetAdapterDisplayModeEx(adapter, out displayRotation);
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600022F RID: 559 RVA: 0x000091A6 File Offset: 0x000073A6
		// (set) Token: 0x06000230 RID: 560 RVA: 0x000091AE File Offset: 0x000073AE
		public AdapterExCollection AdaptersEx { get; private set; }

		// Token: 0x06000231 RID: 561 RVA: 0x000091B7 File Offset: 0x000073B7
		public Direct3DEx(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000091C0 File Offset: 0x000073C0
		public new static explicit operator Direct3DEx(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Direct3DEx(nativePointer);
			}
			return null;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000091D7 File Offset: 0x000073D7
		public unsafe int GetAdapterModeCountEx(int adapter, DisplayModeFilter filterRef)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &filterRef, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000091FC File Offset: 0x000073FC
		public unsafe DisplayModeEx EnumerateAdapterModesEx(int adapter, DisplayModeFilter filterRef, int mode)
		{
			DisplayModeEx.__Native _Native = DisplayModeEx.__NewNative();
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &filterRef, mode, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			DisplayModeEx displayModeEx = new DisplayModeEx();
			displayModeEx.__MarshalFrom(ref _Native);
			result.CheckError();
			return displayModeEx;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00009250 File Offset: 0x00007450
		public unsafe DisplayModeEx GetAdapterDisplayModeEx(int adapter, out DisplayRotation rotationRef)
		{
			DisplayModeEx.__Native _Native = DisplayModeEx.__NewNative();
			Result result;
			fixed (DisplayRotation* ptr = &rotationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, adapter, &_Native, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			DisplayModeEx displayModeEx = new DisplayModeEx();
			displayModeEx.__MarshalFrom(ref _Native);
			result.CheckError();
			return displayModeEx;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000092A8 File Offset: 0x000074A8
		internal unsafe void CreateDeviceEx(int adapter, DeviceType deviceType, IntPtr hFocusWindow, int behaviorFlags, PresentParameters[] presentationParametersRef, DisplayModeEx[] fullscreenDisplayModeRef, DeviceEx returnedDeviceInterfaceOut)
		{
			DisplayModeEx.__Native[] array = (fullscreenDisplayModeRef == null) ? null : new DisplayModeEx.__Native[fullscreenDisplayModeRef.Length];
			if (fullscreenDisplayModeRef != null)
			{
				for (int i = 0; i < fullscreenDisplayModeRef.Length; i++)
				{
					fullscreenDisplayModeRef[i].__MarshalTo(ref array[i]);
				}
			}
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PresentParameters[] array2 = presentationParametersRef)
			{
				void* ptr;
				if (presentationParametersRef == null || array2.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array2[0]);
				}
				DisplayModeEx.__Native[] array3;
				void* ptr2;
				if ((array3 = array) == null || array3.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array3[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, adapter, deviceType, (void*)hFocusWindow, behaviorFlags, ptr, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
				array3 = null;
			}
			if (fullscreenDisplayModeRef != null)
			{
				for (int j = 0; j < fullscreenDisplayModeRef.Length; j++)
				{
					fullscreenDisplayModeRef[j].__MarshalFree(ref array[j]);
				}
			}
			returnedDeviceInterfaceOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000093A0 File Offset: 0x000075A0
		public unsafe long GetAdapterLuid(int adapter)
		{
			long result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
