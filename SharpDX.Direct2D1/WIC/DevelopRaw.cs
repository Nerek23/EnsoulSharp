using System;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x0200006C RID: 108
	[Guid("fbec5e44-f7be-4b65-b7f8-c0c81fef026d")]
	public class DevelopRaw : BitmapFrameDecode
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x00008628 File Offset: 0x00006828
		public DevelopRaw(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00008631 File Offset: 0x00006831
		public new static explicit operator DevelopRaw(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DevelopRaw(nativePtr);
			}
			return null;
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00008648 File Offset: 0x00006848
		public PropertyBag CurrentParameterSet
		{
			get
			{
				PropertyBag result;
				this.GetCurrentParameterSet(out result);
				return result;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00008660 File Offset: 0x00006860
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00008676 File Offset: 0x00006876
		public double ExposureCompensation
		{
			get
			{
				double result;
				this.GetExposureCompensation(out result);
				return result;
			}
			set
			{
				this.SetExposureCompensation(value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00008680 File Offset: 0x00006880
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00008696 File Offset: 0x00006896
		public NamedWhitePoint NamedWhitePoint
		{
			get
			{
				NamedWhitePoint result;
				this.GetNamedWhitePoint(out result);
				return result;
			}
			set
			{
				this.SetNamedWhitePoint(value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000086A0 File Offset: 0x000068A0
		// (set) Token: 0x060001FA RID: 506 RVA: 0x000086B6 File Offset: 0x000068B6
		public int WhitePointKelvin
		{
			get
			{
				int result;
				this.GetWhitePointKelvin(out result);
				return result;
			}
			set
			{
				this.SetWhitePointKelvin(value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001FB RID: 507 RVA: 0x000086C0 File Offset: 0x000068C0
		// (set) Token: 0x060001FC RID: 508 RVA: 0x000086D6 File Offset: 0x000068D6
		public double Contrast
		{
			get
			{
				double result;
				this.GetContrast(out result);
				return result;
			}
			set
			{
				this.SetContrast(value);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001FD RID: 509 RVA: 0x000086E0 File Offset: 0x000068E0
		// (set) Token: 0x060001FE RID: 510 RVA: 0x000086F6 File Offset: 0x000068F6
		public double Gamma
		{
			get
			{
				double result;
				this.GetGamma(out result);
				return result;
			}
			set
			{
				this.SetGamma(value);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00008700 File Offset: 0x00006900
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00008716 File Offset: 0x00006916
		public double Sharpness
		{
			get
			{
				double result;
				this.GetSharpness(out result);
				return result;
			}
			set
			{
				this.SetSharpness(value);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00008720 File Offset: 0x00006920
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00008736 File Offset: 0x00006936
		public double Saturation
		{
			get
			{
				double result;
				this.GetSaturation(out result);
				return result;
			}
			set
			{
				this.SetSaturation(value);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00008740 File Offset: 0x00006940
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00008756 File Offset: 0x00006956
		public double Tint
		{
			get
			{
				double result;
				this.GetTint(out result);
				return result;
			}
			set
			{
				this.SetTint(value);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00008760 File Offset: 0x00006960
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00008776 File Offset: 0x00006976
		public double NoiseReduction
		{
			get
			{
				double result;
				this.GetNoiseReduction(out result);
				return result;
			}
			set
			{
				this.SetNoiseReduction(value);
			}
		}

		// Token: 0x1700005C RID: 92
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0000877F File Offset: 0x0000697F
		public ColorContext DestinationColorContext
		{
			set
			{
				this.SetDestinationColorContext(value);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00008788 File Offset: 0x00006988
		// (set) Token: 0x06000209 RID: 521 RVA: 0x0000879E File Offset: 0x0000699E
		public double Rotation
		{
			get
			{
				double result;
				this.GetRotation(out result);
				return result;
			}
			set
			{
				this.SetRotation(value);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000087A8 File Offset: 0x000069A8
		// (set) Token: 0x0600020B RID: 523 RVA: 0x000087BE File Offset: 0x000069BE
		public RawRenderMode RenderMode
		{
			get
			{
				RawRenderMode result;
				this.GetRenderMode(out result);
				return result;
			}
			set
			{
				this.SetRenderMode(value);
			}
		}

		// Token: 0x1700005F RID: 95
		// (set) Token: 0x0600020C RID: 524 RVA: 0x000087C7 File Offset: 0x000069C7
		internal DevelopRawNotificationCallback NotificationCallback
		{
			set
			{
				this.SetNotificationCallback(value);
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000087D0 File Offset: 0x000069D0
		public unsafe void QueryRawCapabilitiesInfo(ref RawCapabilitiesInfo infoRef)
		{
			Result result;
			fixed (RawCapabilitiesInfo* ptr = &infoRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00008814 File Offset: 0x00006A14
		public unsafe void LoadParameterSet(RawParameterSet parameterSet)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, parameterSet, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00008850 File Offset: 0x00006A50
		internal unsafe void GetCurrentParameterSet(out PropertyBag currentParameterSetOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				currentParameterSetOut = new PropertyBag(zero);
			}
			else
			{
				currentParameterSetOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000210 RID: 528 RVA: 0x000088AC File Offset: 0x00006AAC
		internal unsafe void SetExposureCompensation(double ev)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, ev, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000088E8 File Offset: 0x00006AE8
		internal unsafe void GetExposureCompensation(out double eVRef)
		{
			Result result;
			fixed (double* ptr = &eVRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000892C File Offset: 0x00006B2C
		public unsafe void SetWhitePointRGB(int red, int green, int blue)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, red, green, blue, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00008968 File Offset: 0x00006B68
		public unsafe void GetWhitePointRGB(out int redRef, out int greenRef, out int blueRef)
		{
			Result result;
			fixed (int* ptr = &blueRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &greenRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (int* ptr5 = &redRef)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000089C4 File Offset: 0x00006BC4
		internal unsafe void SetNamedWhitePoint(NamedWhitePoint whitePoint)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, whitePoint, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00008A00 File Offset: 0x00006C00
		internal unsafe void GetNamedWhitePoint(out NamedWhitePoint whitePointRef)
		{
			Result result;
			fixed (NamedWhitePoint* ptr = &whitePointRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008A44 File Offset: 0x00006C44
		internal unsafe void SetWhitePointKelvin(int whitePointKelvin)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, whitePointKelvin, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00008A80 File Offset: 0x00006C80
		internal unsafe void GetWhitePointKelvin(out int whitePointKelvinRef)
		{
			Result result;
			fixed (int* ptr = &whitePointKelvinRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00008AC4 File Offset: 0x00006CC4
		public unsafe void GetKelvinRangeInfo(out int minKelvinTempRef, out int maxKelvinTempRef, out int kelvinTempStepValueRef)
		{
			Result result;
			fixed (int* ptr = &kelvinTempStepValueRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &maxKelvinTempRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (int* ptr5 = &minKelvinTempRef)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00008B20 File Offset: 0x00006D20
		internal unsafe void SetContrast(double contrast)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, contrast, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00008B5C File Offset: 0x00006D5C
		internal unsafe void GetContrast(out double contrastRef)
		{
			Result result;
			fixed (double* ptr = &contrastRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00008BA0 File Offset: 0x00006DA0
		internal unsafe void SetGamma(double gamma)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, gamma, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00008BDC File Offset: 0x00006DDC
		internal unsafe void GetGamma(out double gammaRef)
		{
			Result result;
			fixed (double* ptr = &gammaRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00008C20 File Offset: 0x00006E20
		internal unsafe void SetSharpness(double sharpness)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, sharpness, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00008C5C File Offset: 0x00006E5C
		internal unsafe void GetSharpness(out double sharpnessRef)
		{
			Result result;
			fixed (double* ptr = &sharpnessRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00008CA0 File Offset: 0x00006EA0
		internal unsafe void SetSaturation(double saturation)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, saturation, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00008CDC File Offset: 0x00006EDC
		internal unsafe void GetSaturation(out double saturationRef)
		{
			Result result;
			fixed (double* ptr = &saturationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00008D20 File Offset: 0x00006F20
		internal unsafe void SetTint(double tint)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, tint, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00008D5C File Offset: 0x00006F5C
		internal unsafe void GetTint(out double tintRef)
		{
			Result result;
			fixed (double* ptr = &tintRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00008DA0 File Offset: 0x00006FA0
		internal unsafe void SetNoiseReduction(double noiseReduction)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, noiseReduction, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00008DDC File Offset: 0x00006FDC
		internal unsafe void GetNoiseReduction(out double noiseReductionRef)
		{
			Result result;
			fixed (double* ptr = &noiseReductionRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00008E20 File Offset: 0x00007020
		internal unsafe void SetDestinationColorContext(ColorContext colorContextRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ColorContext>(colorContextRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00008E6C File Offset: 0x0000706C
		public unsafe void SetToneCurve(int toneCurveSize, RawToneCurve[] toneCurveRef)
		{
			RawToneCurve.__Native[] array = new RawToneCurve.__Native[toneCurveRef.Length];
			for (int i = 0; i < toneCurveRef.Length; i++)
			{
				toneCurveRef[i].__MarshalTo(ref array[i]);
			}
			RawToneCurve.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, toneCurveSize, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			array2 = null;
			for (int j = 0; j < toneCurveRef.Length; j++)
			{
				toneCurveRef[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00008F18 File Offset: 0x00007118
		public unsafe void GetToneCurve(int toneCurveBufferSize, RawToneCurve[] toneCurveRef, IntPtr actualToneCurveBufferSizeRef)
		{
			RawToneCurve.__Native[] array = (toneCurveRef == null) ? null : new RawToneCurve.__Native[toneCurveRef.Length];
			RawToneCurve.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, toneCurveBufferSize, ptr, (void*)actualToneCurveBufferSizeRef, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			array2 = null;
			if (toneCurveRef != null)
			{
				for (int i = 0; i < toneCurveRef.Length; i++)
				{
					if (toneCurveRef != null)
					{
						toneCurveRef[i].__MarshalFrom(ref array[i]);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00008FB0 File Offset: 0x000071B0
		internal unsafe void SetRotation(double rotation)
		{
			calli(System.Int32(System.Void*,System.Double), this._nativePointer, rotation, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00008FEC File Offset: 0x000071EC
		internal unsafe void GetRotation(out double rotationRef)
		{
			Result result;
			fixed (double* ptr = &rotationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00009030 File Offset: 0x00007230
		internal unsafe void SetRenderMode(RawRenderMode renderMode)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, renderMode, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000906C File Offset: 0x0000726C
		internal unsafe void GetRenderMode(out RawRenderMode renderModeRef)
		{
			Result result;
			fixed (RawRenderMode* ptr = &renderModeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000090B0 File Offset: 0x000072B0
		internal unsafe void SetNotificationCallback(DevelopRawNotificationCallback callbackRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DevelopRawNotificationCallback>(callbackRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
