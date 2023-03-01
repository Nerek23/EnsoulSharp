using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200001B RID: 27
	[Guid("ae02eedb-c735-4690-8d52-5a8dc20213aa")]
	public class Output : DXGIObject
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x00004051 File Offset: 0x00002251
		public void GetClosestMatchingMode(ComObject device, ModeDescription modeToMatch, out ModeDescription closestMatch)
		{
			this.FindClosestMatchingMode(ref modeToMatch, out closestMatch, device);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004060 File Offset: 0x00002260
		public ModeDescription[] GetDisplayModeList(Format format, DisplayModeEnumerationFlags flags)
		{
			int num = 0;
			this.GetDisplayModeList(format, (int)flags, ref num, null);
			ModeDescription[] array = new ModeDescription[num];
			if (num > 0)
			{
				this.GetDisplayModeList(format, (int)flags, ref num, array);
			}
			return array;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002165 File Offset: 0x00000365
		public Output(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004091 File Offset: 0x00002291
		public new static explicit operator Output(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output(nativePtr);
			}
			return null;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000040A8 File Offset: 0x000022A8
		public OutputDescription Description
		{
			get
			{
				OutputDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000040C0 File Offset: 0x000022C0
		public GammaControlCapabilities GammaControlCapabilities
		{
			get
			{
				GammaControlCapabilities result;
				this.GetGammaControlCapabilities(out result);
				return result;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000040D8 File Offset: 0x000022D8
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000040EE File Offset: 0x000022EE
		public GammaControl GammaControl
		{
			get
			{
				GammaControl result;
				this.GetGammaControl(out result);
				return result;
			}
			set
			{
				this.SetGammaControl(ref value);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000040F8 File Offset: 0x000022F8
		public FrameStatistics FrameStatistics
		{
			get
			{
				FrameStatistics result;
				this.GetFrameStatistics(out result);
				return result;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004110 File Offset: 0x00002310
		internal unsafe void GetDescription(out OutputDescription descRef)
		{
			OutputDescription.__Native _Native = default(OutputDescription.__Native);
			descRef = default(OutputDescription);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004164 File Offset: 0x00002364
		internal unsafe void GetDisplayModeList(Format enumFormat, int flags, ref int numModesRef, ModeDescription[] descRef)
		{
			Result result;
			fixed (ModeDescription[] array = descRef)
			{
				void* ptr;
				if (descRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int* ptr2 = &numModesRef)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, enumFormat, flags, ptr3, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000041C8 File Offset: 0x000023C8
		internal unsafe void FindClosestMatchingMode(ref ModeDescription modeToMatchRef, out ModeDescription closestMatchRef, IUnknown concernedDeviceRef)
		{
			closestMatchRef = default(ModeDescription);
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(concernedDeviceRef);
			Result result;
			fixed (ModeDescription* ptr = &closestMatchRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (ModeDescription* ptr3 = &modeToMatchRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004234 File Offset: 0x00002434
		public unsafe void WaitForVerticalBlank()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000426C File Offset: 0x0000246C
		public unsafe void TakeOwnership(IUnknown deviceRef, RawBool exclusive)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, exclusive, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000042B8 File Offset: 0x000024B8
		public unsafe void ReleaseOwnership()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000042D8 File Offset: 0x000024D8
		internal unsafe void GetGammaControlCapabilities(out GammaControlCapabilities gammaCapsRef)
		{
			GammaControlCapabilities.__Native _Native = default(GammaControlCapabilities.__Native);
			gammaCapsRef = default(GammaControlCapabilities);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			gammaCapsRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000432C File Offset: 0x0000252C
		internal unsafe void SetGammaControl(ref GammaControl arrayRef)
		{
			GammaControl.__Native _Native = default(GammaControl.__Native);
			arrayRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			arrayRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004380 File Offset: 0x00002580
		internal unsafe void GetGammaControl(out GammaControl arrayRef)
		{
			GammaControl.__Native _Native = default(GammaControl.__Native);
			arrayRef = default(GammaControl);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			arrayRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000043D4 File Offset: 0x000025D4
		public unsafe void SetDisplaySurface(Surface scanoutSurfaceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Surface>(scanoutSurfaceRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004420 File Offset: 0x00002620
		public unsafe void CopyDisplaySurfaceTo(Surface destinationRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Surface>(destinationRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000446C File Offset: 0x0000266C
		internal unsafe void GetFrameStatistics(out FrameStatistics statsRef)
		{
			statsRef = default(FrameStatistics);
			Result result;
			fixed (FrameStatistics* ptr = &statsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
