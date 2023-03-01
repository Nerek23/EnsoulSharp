using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C4 RID: 452
	public static class D2D1
	{
		// Token: 0x060008AE RID: 2222 RVA: 0x00018CD0 File Offset: 0x00016ED0
		public static float ComputeFlatteningTolerance(ref RawMatrix3x2 matrix, float dpiX = 96f, float dpiY = 96f, float maxZoomFactor = 1f)
		{
			float num = dpiX / 96f;
			float num2 = dpiY / 96f;
			RawMatrix3x2 rawMatrix3x = new RawMatrix3x2
			{
				M11 = matrix.M11 * num,
				M12 = matrix.M12 * num2,
				M21 = matrix.M21 * num,
				M22 = matrix.M22 * num2,
				M31 = matrix.M31 * num,
				M32 = matrix.M32 * num2
			};
			float num3 = (maxZoomFactor > 0f) ? maxZoomFactor : (-maxZoomFactor);
			return 0.25f / (num3 * D2D1.ComputeMaximumScaleFactor(ref rawMatrix3x));
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00018D70 File Offset: 0x00016F70
		public unsafe static void CreateFactory(FactoryType factoryType, Guid riid, FactoryOptions? factoryOptionsRef, out IntPtr iFactoryOut)
		{
			FactoryOptions value;
			if (factoryOptionsRef != null)
			{
				value = factoryOptionsRef.Value;
			}
			Result result;
			fixed (IntPtr* ptr = &iFactoryOut)
			{
				void* param = (void*)ptr;
				result = D2D1.D2D1CreateFactory_((int)factoryType, (void*)(&riid), (factoryOptionsRef == null) ? null : ((void*)(&value)), param);
			}
			result.CheckError();
		}

		// Token: 0x060008B0 RID: 2224
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1CreateFactory")]
		private unsafe static extern int D2D1CreateFactory_(int param0, void* param1, void* param2, void* param3);

		// Token: 0x060008B1 RID: 2225 RVA: 0x00018DC0 File Offset: 0x00016FC0
		public unsafe static void MakeRotateMatrix(float angle, RawVector2 center, out RawMatrix3x2 matrix)
		{
			matrix = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				void* param = (void*)ptr;
				D2D1.D2D1MakeRotateMatrix_(angle, center, param);
			}
		}

		// Token: 0x060008B2 RID: 2226
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1MakeRotateMatrix")]
		private unsafe static extern void D2D1MakeRotateMatrix_(float param0, RawVector2 param1, void* param2);

		// Token: 0x060008B3 RID: 2227 RVA: 0x00018DE4 File Offset: 0x00016FE4
		public unsafe static void MakeSkewMatrix(float angleX, float angleY, RawVector2 center, out RawMatrix3x2 matrix)
		{
			matrix = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				void* param = (void*)ptr;
				D2D1.D2D1MakeSkewMatrix_(angleX, angleY, center, param);
			}
		}

		// Token: 0x060008B4 RID: 2228
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1MakeSkewMatrix")]
		private unsafe static extern void D2D1MakeSkewMatrix_(float param0, float param1, RawVector2 param2, void* param3);

		// Token: 0x060008B5 RID: 2229 RVA: 0x00018E0C File Offset: 0x0001700C
		public unsafe static RawBool IsMatrixInvertible(ref RawMatrix3x2 matrix)
		{
			RawBool result;
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				void* param = (void*)ptr;
				result = D2D1.D2D1IsMatrixInvertible_(param);
			}
			return result;
		}

		// Token: 0x060008B6 RID: 2230
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1IsMatrixInvertible")]
		private unsafe static extern RawBool D2D1IsMatrixInvertible_(void* param0);

		// Token: 0x060008B7 RID: 2231 RVA: 0x00018E28 File Offset: 0x00017028
		public unsafe static RawBool InvertMatrix(ref RawMatrix3x2 matrix)
		{
			RawBool result;
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				void* param = (void*)ptr;
				result = D2D1.D2D1InvertMatrix_(param);
			}
			return result;
		}

		// Token: 0x060008B8 RID: 2232
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1InvertMatrix")]
		private unsafe static extern RawBool D2D1InvertMatrix_(void* param0);

		// Token: 0x060008B9 RID: 2233 RVA: 0x00018E44 File Offset: 0x00017044
		public unsafe static void CreateDevice(Device dxgiDevice, CreationProperties? creationProperties, Device d2dDevice)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			CreationProperties value2;
			if (creationProperties != null)
			{
				value2 = creationProperties.Value;
			}
			Result result = D2D1.D2D1CreateDevice_((void*)value, (creationProperties == null) ? null : ((void*)(&value2)), (void*)(&zero2));
			d2dDevice.NativePointer = zero2;
			result.CheckError();
		}

		// Token: 0x060008BA RID: 2234
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1CreateDevice")]
		private unsafe static extern int D2D1CreateDevice_(void* param0, void* param1, void* param2);

		// Token: 0x060008BB RID: 2235 RVA: 0x00018EA8 File Offset: 0x000170A8
		public unsafe static void CreateDeviceContext(Surface dxgiSurface, CreationProperties? creationProperties, DeviceContext d2dDeviceContext)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr value = CppObject.ToCallbackPtr<Surface>(dxgiSurface);
			CreationProperties value2;
			if (creationProperties != null)
			{
				value2 = creationProperties.Value;
			}
			Result result = D2D1.D2D1CreateDeviceContext_((void*)value, (creationProperties == null) ? null : ((void*)(&value2)), (void*)(&zero2));
			d2dDeviceContext.NativePointer = zero2;
			result.CheckError();
		}

		// Token: 0x060008BC RID: 2236
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1CreateDeviceContext")]
		private unsafe static extern int D2D1CreateDeviceContext_(void* param0, void* param1, void* param2);

		// Token: 0x060008BD RID: 2237 RVA: 0x00018F0C File Offset: 0x0001710C
		public unsafe static RawColor4 ConvertColorSpace(ColorSpace sourceColorSpace, ColorSpace destinationColorSpace, RawColor4 color)
		{
			RawColor4 result;
			D2D1.D2D1ConvertColorSpace_((void*)(&result), (int)sourceColorSpace, (int)destinationColorSpace, (void*)(&color));
			return result;
		}

		// Token: 0x060008BE RID: 2238
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1ConvertColorSpace")]
		private unsafe static extern void* D2D1ConvertColorSpace_(void* param0, int param1, int param2, void* param3);

		// Token: 0x060008BF RID: 2239 RVA: 0x00018F28 File Offset: 0x00017128
		public unsafe static void SinCos(float angle, out float s, out float c)
		{
			fixed (float* ptr = &c)
			{
				void* param = (void*)ptr;
				fixed (float* ptr2 = &s)
				{
					void* param2 = (void*)ptr2;
					D2D1.D2D1SinCos_(angle, param2, param);
				}
			}
		}

		// Token: 0x060008C0 RID: 2240
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1SinCos")]
		private unsafe static extern void D2D1SinCos_(float param0, void* param1, void* param2);

		// Token: 0x060008C1 RID: 2241 RVA: 0x00018F4D File Offset: 0x0001714D
		public static float Tan(float angle)
		{
			return D2D1.D2D1Tan_(angle);
		}

		// Token: 0x060008C2 RID: 2242
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1Tan")]
		private static extern float D2D1Tan_(float param0);

		// Token: 0x060008C3 RID: 2243 RVA: 0x00018F55 File Offset: 0x00017155
		public static float Vec3Length(float x, float y, float z)
		{
			return D2D1.D2D1Vec3Length_(x, y, z);
		}

		// Token: 0x060008C4 RID: 2244
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1Vec3Length")]
		private static extern float D2D1Vec3Length_(float param0, float param1, float param2);

		// Token: 0x060008C5 RID: 2245 RVA: 0x00018F60 File Offset: 0x00017160
		public unsafe static float ComputeMaximumScaleFactor(ref RawMatrix3x2 matrix)
		{
			float result;
			fixed (RawMatrix3x2* ptr = &matrix)
			{
				void* param = (void*)ptr;
				result = D2D1.D2D1ComputeMaximumScaleFactor_(param);
			}
			return result;
		}

		// Token: 0x060008C6 RID: 2246
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1ComputeMaximumScaleFactor")]
		private unsafe static extern float D2D1ComputeMaximumScaleFactor_(void* param0);

		// Token: 0x060008C7 RID: 2247 RVA: 0x00018F7C File Offset: 0x0001717C
		public unsafe static void GetGradientMeshInteriorPointsFromCoonsPatch(RawVector2 point0Ref, RawVector2 point1Ref, RawVector2 point2Ref, RawVector2 point3Ref, RawVector2 point4Ref, RawVector2 point5Ref, RawVector2 point6Ref, RawVector2 point7Ref, RawVector2 point8Ref, RawVector2 point9Ref, RawVector2 point10Ref, RawVector2 point11Ref, out RawVector2 tensorPoint11Ref, out RawVector2 tensorPoint12Ref, out RawVector2 tensorPoint21Ref, out RawVector2 tensorPoint22Ref)
		{
			tensorPoint11Ref = default(RawVector2);
			tensorPoint12Ref = default(RawVector2);
			tensorPoint21Ref = default(RawVector2);
			tensorPoint22Ref = default(RawVector2);
			fixed (RawVector2* ptr = &tensorPoint22Ref)
			{
				void* param = (void*)ptr;
				fixed (RawVector2* ptr2 = &tensorPoint21Ref)
				{
					void* param2 = (void*)ptr2;
					fixed (RawVector2* ptr3 = &tensorPoint12Ref)
					{
						void* param3 = (void*)ptr3;
						fixed (RawVector2* ptr4 = &tensorPoint11Ref)
						{
							void* param4 = (void*)ptr4;
							D2D1.D2D1GetGradientMeshInteriorPointsFromCoonsPatch_((void*)(&point0Ref), (void*)(&point1Ref), (void*)(&point2Ref), (void*)(&point3Ref), (void*)(&point4Ref), (void*)(&point5Ref), (void*)(&point6Ref), (void*)(&point7Ref), (void*)(&point8Ref), (void*)(&point9Ref), (void*)(&point10Ref), (void*)(&point11Ref), param4, param3, param2, param);
						}
					}
				}
			}
		}

		// Token: 0x060008C8 RID: 2248
		[DllImport("d2d1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D2D1GetGradientMeshInteriorPointsFromCoonsPatch")]
		private unsafe static extern void D2D1GetGradientMeshInteriorPointsFromCoonsPatch_(void* param0, void* param1, void* param2, void* param3, void* param4, void* param5, void* param6, void* param7, void* param8, void* param9, void* param10, void* param11, void* param12, void* param13, void* param14, void* param15);

		// Token: 0x0400061E RID: 1566
		public const float DefaultFlatteningTolerance = 0.25f;

		// Token: 0x0400061F RID: 1567
		public const float DefaultDpi = 96f;
	}
}
