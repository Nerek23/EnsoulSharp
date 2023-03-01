using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200020B RID: 523
	[Guid("483473d7-cd46-4f9d-9d3a-3112aa80159d")]
	public class Properties : ComObject
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x0001FCE7 File Offset: 0x0001DEE7
		// (set) Token: 0x06000B28 RID: 2856 RVA: 0x0001FCF4 File Offset: 0x0001DEF4
		public bool Cached
		{
			get
			{
				return this.GetBoolValue(-2147483642);
			}
			set
			{
				this.SetValue(-2147483642, value);
			}
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0001FD04 File Offset: 0x0001DF04
		public unsafe string GetPropertyName(int index)
		{
			int propertyNameLength = this.GetPropertyNameLength(index);
			if (propertyNameLength == 0)
			{
				return null;
			}
			int num = propertyNameLength + 1;
			char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
			this.GetPropertyName(index, new IntPtr((void*)value), num);
			return new string(value, 0, propertyNameLength);
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0001FD40 File Offset: 0x0001DF40
		public unsafe int GetIntValue(int index)
		{
			int result;
			this.GetValue(index, PropertyType.Int32, new IntPtr((void*)(&result)), 4);
			return result;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0001FD60 File Offset: 0x0001DF60
		public unsafe uint GetUIntValue(int index)
		{
			uint result;
			this.GetValue(index, PropertyType.UInt32, new IntPtr((void*)(&result)), 4);
			return result;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0001FD80 File Offset: 0x0001DF80
		public unsafe float GetFloatValue(int index)
		{
			float result;
			this.GetValue(index, PropertyType.Float, new IntPtr((void*)(&result)), 4);
			return result;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0001FDA0 File Offset: 0x0001DFA0
		public unsafe bool GetBoolValue(int index)
		{
			int num;
			this.GetValue(index, PropertyType.Bool, new IntPtr((void*)(&num)), 4);
			return num != 0;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0001FDC4 File Offset: 0x0001DFC4
		public unsafe Guid GetGuidValue(int index)
		{
			Guid result;
			this.GetValue(index, PropertyType.Clsid, new IntPtr((void*)(&result)), Utilities.SizeOf<Guid>());
			return result;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0001FDE8 File Offset: 0x0001DFE8
		public unsafe RawVector2 GetVector2Value(int index)
		{
			RawVector2 result;
			this.GetValue(index, PropertyType.Vector2, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector2>());
			return result;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0001FE0C File Offset: 0x0001E00C
		public unsafe RawVector3 GetVector3Value(int index)
		{
			RawVector3 result;
			this.GetValue(index, PropertyType.Vector3, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector3>());
			return result;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0001FE30 File Offset: 0x0001E030
		public unsafe RawColor3 GetColor3Value(int index)
		{
			RawColor3 result;
			this.GetValue(index, PropertyType.Vector3, new IntPtr((void*)(&result)), Utilities.SizeOf<RawColor3>());
			return result;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0001FE54 File Offset: 0x0001E054
		public unsafe RawVector4 GetVector4Value(int index)
		{
			RawVector4 result;
			this.GetValue(index, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector4>());
			return result;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0001FE78 File Offset: 0x0001E078
		public unsafe RawRectangleF GetRectangleFValue(int index)
		{
			RawRectangleF result;
			this.GetValue(index, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawRectangleF>());
			return result;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0001FE9C File Offset: 0x0001E09C
		public unsafe RawColor4 GetColor4Value(int index)
		{
			RawColor4 result;
			this.GetValue(index, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawColor4>());
			return result;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		public unsafe RawMatrix GetMatrixValue(int index)
		{
			RawMatrix result;
			this.GetValue(index, PropertyType.Matrix4x4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix>());
			return result;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0001FEE4 File Offset: 0x0001E0E4
		public unsafe RawMatrix3x2 GetMatrix3x2Value(int index)
		{
			RawMatrix3x2 result;
			this.GetValue(index, PropertyType.Matrix3x2, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix3x2>());
			return result;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0001FF08 File Offset: 0x0001E108
		public unsafe RawMatrix5x4 GetMatrix5x4Value(int index)
		{
			RawMatrix5x4 result;
			this.GetValue(index, PropertyType.Matrix5x4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix5x4>());
			return result;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0001FF2C File Offset: 0x0001E12C
		public T GetEnumValue<T>(int index) where T : struct
		{
			if (Utilities.SizeOf<T>() != 4)
			{
				throw new ArgumentException("value", "enum must be sizeof(int)");
			}
			T result = default(T);
			this.GetValue(index, PropertyType.Enum, (IntPtr)Interop.Cast<T>(ref result), 4);
			return result;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0001FF70 File Offset: 0x0001E170
		public unsafe T GetComObjectValue<T>(int index) where T : ComObject
		{
			IntPtr intPtr;
			this.GetValue(index, PropertyType.IUnknown, new IntPtr((void*)(&intPtr)), Utilities.SizeOf<IntPtr>());
			if (!(intPtr == IntPtr.Zero))
			{
				return ComObject.As<T>(intPtr);
			}
			return default(T);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0001FFB0 File Offset: 0x0001E1B0
		public T GetValue<T>(int index, PropertyType type) where T : struct
		{
			T result = default(T);
			this.GetValue(index, type, (IntPtr)Interop.Cast<T>(ref result), Utilities.SizeOf<T>());
			return result;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0001FFE0 File Offset: 0x0001E1E0
		public unsafe uint GetUIntValueByName(string name)
		{
			uint result;
			this.GetValueByName(name, PropertyType.UInt32, new IntPtr((void*)(&result)), 4);
			return result;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x00020000 File Offset: 0x0001E200
		public unsafe float GetFloatValueByName(string name)
		{
			float result;
			this.GetValueByName(name, PropertyType.Float, new IntPtr((void*)(&result)), 4);
			return result;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00020020 File Offset: 0x0001E220
		public unsafe bool GetBoolValueByName(string name)
		{
			int num;
			this.GetValueByName(name, PropertyType.Bool, new IntPtr((void*)(&num)), 4);
			return num != 0;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00020044 File Offset: 0x0001E244
		public unsafe Guid GetGuidValueByName(string name)
		{
			Guid result;
			this.GetValueByName(name, PropertyType.Clsid, new IntPtr((void*)(&result)), Utilities.SizeOf<Guid>());
			return result;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00020068 File Offset: 0x0001E268
		public unsafe RawVector2 GetVector2ValueByName(string name)
		{
			RawVector2 result;
			this.GetValueByName(name, PropertyType.Vector2, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector2>());
			return result;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0002008C File Offset: 0x0001E28C
		public unsafe RawVector3 GetVector3ValueByName(string name)
		{
			RawVector3 result;
			this.GetValueByName(name, PropertyType.Vector3, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector3>());
			return result;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x000200B0 File Offset: 0x0001E2B0
		public unsafe RawColor3 GetColor3ValueByName(string name)
		{
			RawColor3 result;
			this.GetValueByName(name, PropertyType.Vector3, new IntPtr((void*)(&result)), Utilities.SizeOf<RawColor3>());
			return result;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000200D4 File Offset: 0x0001E2D4
		public unsafe RawVector4 GetVector4ValueByName(string name)
		{
			RawVector4 result;
			this.GetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawVector4>());
			return result;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x000200F8 File Offset: 0x0001E2F8
		public unsafe RawRectangleF GetRectangleFValueByName(string name)
		{
			RawRectangleF result;
			this.GetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawRectangleF>());
			return result;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0002011C File Offset: 0x0001E31C
		public unsafe RawColor4 GetColor4ValueByName(string name)
		{
			RawColor4 result;
			this.GetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawColor4>());
			return result;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x00020140 File Offset: 0x0001E340
		public unsafe RawMatrix GetMatrixValueByName(string name)
		{
			RawMatrix result;
			this.GetValueByName(name, PropertyType.Matrix4x4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix>());
			return result;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00020164 File Offset: 0x0001E364
		public unsafe RawMatrix3x2 GetMatrix3x2ValueByName(string name)
		{
			RawMatrix3x2 result;
			this.GetValueByName(name, PropertyType.Matrix3x2, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix3x2>());
			return result;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x00020188 File Offset: 0x0001E388
		public unsafe RawMatrix5x4 GetMatrix5x4ValueByName(string name)
		{
			RawMatrix5x4 result;
			this.GetValueByName(name, PropertyType.Matrix5x4, new IntPtr((void*)(&result)), Utilities.SizeOf<RawMatrix5x4>());
			return result;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x000201AC File Offset: 0x0001E3AC
		public T GetEnumValueByName<T>(string name) where T : struct
		{
			if (Utilities.SizeOf<T>() != 4)
			{
				throw new ArgumentException("value", "enum must be sizeof(int)");
			}
			T result = default(T);
			this.GetValueByName(name, PropertyType.Enum, (IntPtr)Interop.Cast<T>(ref result), 4);
			return result;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000201F0 File Offset: 0x0001E3F0
		public unsafe T GetComObjectValueByName<T>(string name) where T : ComObject
		{
			IntPtr intPtr;
			this.GetValueByName(name, PropertyType.IUnknown, new IntPtr((void*)(&intPtr)), Utilities.SizeOf<IntPtr>());
			if (!(intPtr == IntPtr.Zero))
			{
				return ComObject.As<T>(intPtr);
			}
			return default(T);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00020230 File Offset: 0x0001E430
		public T GetValue<T>(string name, PropertyType type) where T : struct
		{
			T result = default(T);
			this.GetValueByName(name, type, (IntPtr)Interop.Cast<T>(ref result), Utilities.SizeOf<T>());
			return result;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0002025F File Offset: 0x0001E45F
		public unsafe void SetValueByName(string name, int value)
		{
			this.SetValueByName(name, PropertyType.Int32, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00020272 File Offset: 0x0001E472
		public unsafe void SetValueByName(string name, uint value)
		{
			this.SetValueByName(name, PropertyType.UInt32, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00020288 File Offset: 0x0001E488
		public unsafe void SetValueByName(string name, bool value)
		{
			int num = value ? 1 : 0;
			this.SetValueByName(name, PropertyType.Bool, new IntPtr((void*)(&num)), 4);
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x000202AE File Offset: 0x0001E4AE
		public unsafe void SetValueByName(string name, Guid value)
		{
			this.SetValueByName(name, PropertyType.Clsid, new IntPtr((void*)(&value)), Utilities.SizeOf<Guid>());
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x000202C6 File Offset: 0x0001E4C6
		public unsafe void SetValueByName(string name, float value)
		{
			this.SetValueByName(name, PropertyType.Float, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x000202D9 File Offset: 0x0001E4D9
		public unsafe void SetValueByName(string name, RawVector2 value)
		{
			this.SetValueByName(name, PropertyType.Vector2, new IntPtr((void*)(&value)), sizeof(RawVector2));
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x000202F1 File Offset: 0x0001E4F1
		public unsafe void SetValueByName(string name, RawColor3 value)
		{
			this.SetValueByName(name, PropertyType.Vector3, new IntPtr((void*)(&value)), sizeof(RawColor3));
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x00020309 File Offset: 0x0001E509
		public unsafe void SetValueByName(string name, RawVector4 value)
		{
			this.SetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawVector4));
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00020321 File Offset: 0x0001E521
		public unsafe void SetValueByName(string name, RawRectangleF value)
		{
			this.SetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawRectangleF));
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00020339 File Offset: 0x0001E539
		public unsafe void SetValueByName(string name, RawColor4 value)
		{
			this.SetValueByName(name, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawColor4));
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x00020351 File Offset: 0x0001E551
		public unsafe void SetValueByName(string name, RawMatrix3x2 value)
		{
			this.SetValueByName(name, PropertyType.Matrix3x2, new IntPtr((void*)(&value)), sizeof(RawMatrix3x2));
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0002036A File Offset: 0x0001E56A
		public unsafe void SetValueByName(string name, RawMatrix value)
		{
			this.SetValueByName(name, PropertyType.Matrix4x4, new IntPtr((void*)(&value)), sizeof(RawMatrix));
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x00020383 File Offset: 0x0001E583
		public unsafe void SetValueByName(string name, RawMatrix5x4 value)
		{
			this.SetValueByName(name, PropertyType.Matrix5x4, new IntPtr((void*)(&value)), sizeof(RawMatrix5x4));
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0002039C File Offset: 0x0001E59C
		public void SetValueByName(string name, string value)
		{
			IntPtr intPtr = Marshal.StringToHGlobalUni(value);
			this.SetValueByName(name, PropertyType.String, intPtr, (value != null) ? value.Length : 0);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x000203CC File Offset: 0x0001E5CC
		public unsafe void SetValueByName<T>(string name, T value) where T : ComObject
		{
			IntPtr intPtr = (value == null) ? IntPtr.Zero : value.NativePointer;
			this.SetValueByName(name, PropertyType.IUnknown, new IntPtr((void*)(&intPtr)), Utilities.SizeOf<IntPtr>());
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0002040A File Offset: 0x0001E60A
		public void SetValueByName<T>(string name, PropertyType type, T value) where T : struct
		{
			this.SetValueByName(name, type, (IntPtr)Interop.Cast<T>(ref value), Utilities.SizeOf<T>());
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00020425 File Offset: 0x0001E625
		public unsafe void SetValue(int index, int value)
		{
			this.SetValue(index, PropertyType.Int32, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00020438 File Offset: 0x0001E638
		public unsafe void SetValue(int index, uint value)
		{
			this.SetValue(index, PropertyType.UInt32, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0002044C File Offset: 0x0001E64C
		public unsafe void SetValue(int index, bool value)
		{
			int num = value ? 1 : 0;
			this.SetValue(index, PropertyType.Bool, new IntPtr((void*)(&num)), 4);
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00020472 File Offset: 0x0001E672
		public unsafe void SetValue(int index, Guid value)
		{
			this.SetValue(index, PropertyType.Clsid, new IntPtr((void*)(&value)), Utilities.SizeOf<Guid>());
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0002048A File Offset: 0x0001E68A
		public unsafe void SetValue(int index, float value)
		{
			this.SetValue(index, PropertyType.Float, new IntPtr((void*)(&value)), 4);
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0002049D File Offset: 0x0001E69D
		public unsafe void SetValue(int index, RawVector2 value)
		{
			this.SetValue(index, PropertyType.Vector2, new IntPtr((void*)(&value)), sizeof(RawVector2));
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x000204B5 File Offset: 0x0001E6B5
		public unsafe void SetValue(int index, RawVector3 value)
		{
			this.SetValue(index, PropertyType.Vector3, new IntPtr((void*)(&value)), sizeof(RawVector3));
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x000204CD File Offset: 0x0001E6CD
		public unsafe void SetValue(int index, RawColor3 value)
		{
			this.SetValue(index, PropertyType.Vector3, new IntPtr((void*)(&value)), sizeof(RawColor3));
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x000204E5 File Offset: 0x0001E6E5
		public unsafe void SetValue(int index, RawVector4 value)
		{
			this.SetValue(index, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawVector4));
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x000204FD File Offset: 0x0001E6FD
		public unsafe void SetValue(int index, RawRectangleF value)
		{
			this.SetValue(index, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawRectangleF));
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00020515 File Offset: 0x0001E715
		public unsafe void SetValue(int index, RawColor4 value)
		{
			this.SetValue(index, PropertyType.Vector4, new IntPtr((void*)(&value)), sizeof(RawColor4));
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0002052D File Offset: 0x0001E72D
		public unsafe void SetValue(int index, RawMatrix3x2 value)
		{
			this.SetValue(index, PropertyType.Matrix3x2, new IntPtr((void*)(&value)), sizeof(RawMatrix3x2));
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x00020546 File Offset: 0x0001E746
		public unsafe void SetValue(int index, RawMatrix value)
		{
			this.SetValue(index, PropertyType.Matrix4x4, new IntPtr((void*)(&value)), sizeof(RawMatrix));
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0002055F File Offset: 0x0001E75F
		public unsafe void SetValue(int index, RawMatrix5x4 value)
		{
			this.SetValue(index, PropertyType.Matrix5x4, new IntPtr((void*)(&value)), sizeof(RawMatrix5x4));
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x00020578 File Offset: 0x0001E778
		public void SetValue(int index, string value)
		{
			IntPtr intPtr = Marshal.StringToHGlobalUni(value);
			this.SetValue(index, PropertyType.String, intPtr, (value != null) ? value.Length : 0);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x000205A7 File Offset: 0x0001E7A7
		public void SetEnumValue<T>(int index, T value) where T : struct
		{
			if (Utilities.SizeOf<T>() != 4)
			{
				throw new ArgumentException("value", "enum must be sizeof(int)");
			}
			this.SetValue(index, PropertyType.Enum, (IntPtr)Interop.Cast<T>(ref value), 4);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x000205D8 File Offset: 0x0001E7D8
		public unsafe void SetValue<T>(int index, T value) where T : ComObject
		{
			IntPtr intPtr = (value == null) ? IntPtr.Zero : value.NativePointer;
			this.SetValue(index, PropertyType.IUnknown, new IntPtr((void*)(&intPtr)), Utilities.SizeOf<IntPtr>());
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00020616 File Offset: 0x0001E816
		public void SetValue<T>(int index, PropertyType type, T value) where T : struct
		{
			this.SetValue(index, type, (IntPtr)Interop.Cast<T>(ref value), Utilities.SizeOf<T>());
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Properties(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00020631 File Offset: 0x0001E831
		public new static explicit operator Properties(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Properties(nativePtr);
			}
			return null;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x00020648 File Offset: 0x0001E848
		public int PropertyCount
		{
			get
			{
				return this.GetPropertyCount();
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetPropertyCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00020650 File Offset: 0x0001E850
		internal unsafe void GetPropertyName(int index, IntPtr name, int nameCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, index, (void*)name, nameCount, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0002068F File Offset: 0x0001E88F
		internal unsafe int GetPropertyNameLength(int index)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x000206AF File Offset: 0x0001E8AF
		public unsafe PropertyType GetTypeInfo(int index)
		{
			return calli(SharpDX.Direct2D1.PropertyType(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x000206D0 File Offset: 0x0001E8D0
		public unsafe int GetPropertyIndex(string name)
		{
			int result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x00020710 File Offset: 0x0001E910
		public unsafe void SetValueByName(string name, PropertyType type, IntPtr data, int dataSize)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr, type, (void*)data, dataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x00020764 File Offset: 0x0001E964
		public unsafe void SetValue(int index, PropertyType type, IntPtr data, int dataSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, index, type, (void*)data, dataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x000207A8 File Offset: 0x0001E9A8
		public unsafe void GetValueByName(string name, PropertyType type, IntPtr data, int dataSize)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, ptr, type, (void*)data, dataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000207FC File Offset: 0x0001E9FC
		public unsafe void GetValue(int index, PropertyType type, IntPtr data, int dataSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, index, type, (void*)data, dataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0002083E File Offset: 0x0001EA3E
		public unsafe int GetValueSize(int index)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x00020860 File Offset: 0x0001EA60
		public unsafe Properties GetSubProperties(int index)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			Properties result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Properties(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
