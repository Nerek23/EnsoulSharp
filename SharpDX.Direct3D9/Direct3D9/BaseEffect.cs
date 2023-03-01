using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200000D RID: 13
	[Guid("017c18ac-103f-4417-8c51-6bf6ef1e56be")]
	public class BaseEffect : ComObject
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000024DB File Offset: 0x000006DB
		public string GetString(EffectHandle parameter)
		{
			return Marshal.PtrToStringAnsi(this.GetString_(parameter));
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000024EC File Offset: 0x000006EC
		public unsafe T GetValue<T>(EffectHandle parameter) where T : struct
		{
			T result = default(T);
			fixed (T* value = &result)
			{
				this.GetValue(parameter, (IntPtr)((void*)value), Utilities.SizeOf<T>());
				return result;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002518 File Offset: 0x00000718
		public unsafe T[] GetValue<T>(EffectHandle parameter, int count) where T : struct
		{
			T[] array = new T[count];
			fixed (T* value = &array[0])
			{
				this.GetValue(parameter, (IntPtr)((void*)value), Utilities.SizeOf<T>());
				return array;
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002547 File Offset: 0x00000747
		public void SetValue(EffectHandle effectHandle, bool value)
		{
			this.SetBool(effectHandle, value);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002556 File Offset: 0x00000756
		public void SetValue(EffectHandle effectHandle, float value)
		{
			this.SetFloat(effectHandle, value);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002560 File Offset: 0x00000760
		public void SetValue(EffectHandle effectHandle, int value)
		{
			this.SetInt(effectHandle, value);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000256A File Offset: 0x0000076A
		public void SetValue(EffectHandle effectHandle, RawMatrix value)
		{
			this.SetMatrix(effectHandle, ref value);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002575 File Offset: 0x00000775
		public void SetValue(EffectHandle effectHandle, RawVector4 value)
		{
			this.SetVector(effectHandle, value);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002580 File Offset: 0x00000780
		public unsafe void SetValue<T>(EffectHandle effectHandle, T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetValue(effectHandle, (IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000025A4 File Offset: 0x000007A4
		public void SetValue(EffectHandle effectHandle, bool[] values)
		{
			RawBool[] bRef = Utilities.ConvertToIntArray(values);
			this.SetBoolArray(effectHandle, bRef, values.Length);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000025C3 File Offset: 0x000007C3
		public void SetValue(EffectHandle effectHandle, float[] values)
		{
			this.SetFloatArray(effectHandle, values, values.Length);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000025D0 File Offset: 0x000007D0
		public void SetValue(EffectHandle effectHandle, int[] values)
		{
			this.SetIntArray(effectHandle, values, values.Length);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000025DD File Offset: 0x000007DD
		public void SetValue(EffectHandle effectHandle, RawMatrix[] values)
		{
			this.SetMatrixArray(effectHandle, values, values.Length);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000025EA File Offset: 0x000007EA
		public void SetValue(EffectHandle effectHandle, RawVector4[] values)
		{
			this.SetVectorArray(effectHandle, values, values.Length);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000025F8 File Offset: 0x000007F8
		public unsafe void SetValue<T>(EffectHandle effectHandle, T[] values) where T : struct
		{
			fixed (T* value = &values[0])
			{
				this.SetValue(effectHandle, (IntPtr)((void*)value), Utilities.SizeOf<T>() * values.Length);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002623 File Offset: 0x00000823
		public BaseEffect(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000262C File Offset: 0x0000082C
		public new static explicit operator BaseEffect(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new BaseEffect(nativePointer);
			}
			return null;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002644 File Offset: 0x00000844
		public EffectDescription Description
		{
			get
			{
				EffectDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000265C File Offset: 0x0000085C
		internal unsafe void GetDescription(out EffectDescription descRef)
		{
			EffectDescription.__Native _Native = default(EffectDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			descRef = default(EffectDescription);
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000026B0 File Offset: 0x000008B0
		public unsafe ParameterDescription GetParameterDescription(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			ParameterDescription.__Native _Native = default(ParameterDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			ParameterDescription result2 = default(ParameterDescription);
			result2.__MarshalFrom(ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002724 File Offset: 0x00000924
		public unsafe TechniqueDescription GetTechniqueDescription(EffectHandle hTechnique)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			TechniqueDescription.__Native _Native = default(TechniqueDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			TechniqueDescription result2 = default(TechniqueDescription);
			result2.__MarshalFrom(ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002798 File Offset: 0x00000998
		public unsafe PassDescription GetPassDescription(EffectHandle hPass)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hPass, ref value);
			PassDescription.__Native _Native = default(PassDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hPass, ref value);
			PassDescription result2 = default(PassDescription);
			result2.__MarshalFrom(ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000280C File Offset: 0x00000A0C
		public unsafe FunctionDescription GetFunctionDescription(EffectHandle hShader)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hShader, ref value);
			FunctionDescription.__Native _Native = default(FunctionDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hShader, ref value);
			FunctionDescription result2 = default(FunctionDescription);
			result2.__MarshalFrom(ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002880 File Offset: 0x00000A80
		public unsafe EffectHandle GetParameter(EffectHandle hParameter, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000028D0 File Offset: 0x00000AD0
		public unsafe EffectHandle GetParameter(EffectHandle hParameter, string nameRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002934 File Offset: 0x00000B34
		public unsafe EffectHandle GetParameterBySemantic(EffectHandle hParameter, string semanticRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(semanticRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002998 File Offset: 0x00000B98
		public unsafe EffectHandle GetParameterElement(EffectHandle hParameter, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			return result;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000029E9 File Offset: 0x00000BE9
		public unsafe EffectHandle GetTechnique(int index)
		{
			return calli(System.Void*(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002A10 File Offset: 0x00000C10
		public unsafe EffectHandle GetTechnique(string nameRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002A54 File Offset: 0x00000C54
		public unsafe EffectHandle GetPass(EffectHandle hTechnique, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			return result;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public unsafe EffectHandle GetPass(EffectHandle hTechnique, string nameRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002B0B File Offset: 0x00000D0B
		public unsafe EffectHandle GetFunction(int index)
		{
			return calli(System.Void*(System.Void*,System.Int32), this._nativePointer, index, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002B34 File Offset: 0x00000D34
		public unsafe EffectHandle GetFunction(string nameRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002B78 File Offset: 0x00000D78
		public unsafe EffectHandle GetAnnotation(EffectHandle hObject, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hObject, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hObject, ref value);
			return result;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002BCC File Offset: 0x00000DCC
		public unsafe EffectHandle GetAnnotation(EffectHandle hObject, string nameRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hObject, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hObject, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002C30 File Offset: 0x00000E30
		internal unsafe void SetValue(EffectHandle hParameter, IntPtr dataRef, int bytes)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, (void*)dataRef, bytes, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002C90 File Offset: 0x00000E90
		internal unsafe void GetValue(EffectHandle hParameter, IntPtr dataRef, int bytes)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, (void*)dataRef, bytes, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002CF0 File Offset: 0x00000EF0
		internal unsafe void SetBool(EffectHandle hParameter, RawBool b)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, value, b, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002D4C File Offset: 0x00000F4C
		internal unsafe void GetBool(EffectHandle hParameter, out RawBool bRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			bRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &bRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002DB4 File Offset: 0x00000FB4
		internal unsafe void SetBoolArray(EffectHandle hParameter, RawBool[] bRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawBool[] array = bRef)
			{
				void* ptr;
				if (bRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002E28 File Offset: 0x00001028
		internal unsafe void GetBoolArray(EffectHandle hParameter, RawBool[] bRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawBool[] array = bRef)
			{
				void* ptr;
				if (bRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002E9C File Offset: 0x0000109C
		internal unsafe void SetInt(EffectHandle hParameter, int n)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, value, n, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002EF8 File Offset: 0x000010F8
		internal unsafe void GetInt(EffectHandle hParameter, out int nRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (int* ptr = &nRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002F5C File Offset: 0x0000115C
		internal unsafe void SetIntArray(EffectHandle hParameter, int[] nRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (int[] array = nRef)
			{
				void* ptr;
				if (nRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002FD0 File Offset: 0x000011D0
		internal unsafe void GetIntArray(EffectHandle hParameter, int[] nRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (int[] array = nRef)
			{
				void* ptr;
				if (nRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003044 File Offset: 0x00001244
		internal unsafe void SetFloat(EffectHandle hParameter, float f)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Single), this._nativePointer, value, f, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000030A0 File Offset: 0x000012A0
		internal unsafe void GetFloat(EffectHandle hParameter, out float fRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (float* ptr = &fRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003104 File Offset: 0x00001304
		internal unsafe void SetFloatArray(EffectHandle hParameter, float[] fRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (float[] array = fRef)
			{
				void* ptr;
				if (fRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003178 File Offset: 0x00001378
		internal unsafe void GetFloatArray(EffectHandle hParameter, float[] fRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (float[] array = fRef)
			{
				void* ptr;
				if (fRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000031EC File Offset: 0x000013EC
		internal unsafe void SetVector(EffectHandle hParameter, RawVector4 vectorRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &vectorRef, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003248 File Offset: 0x00001448
		internal unsafe void GetVector(EffectHandle hParameter, out RawVector4 vectorRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			vectorRef = default(RawVector4);
			Result result;
			fixed (RawVector4* ptr = &vectorRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000032B0 File Offset: 0x000014B0
		internal unsafe void SetVectorArray(EffectHandle hParameter, RawVector4[] vectorRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawVector4[] array = vectorRef)
			{
				void* ptr;
				if (vectorRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003324 File Offset: 0x00001524
		internal unsafe void GetVectorArray(EffectHandle hParameter, RawVector4[] vectorRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawVector4[] array = vectorRef)
			{
				void* ptr;
				if (vectorRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003398 File Offset: 0x00001598
		internal unsafe void SetMatrix(EffectHandle hParameter, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000033FC File Offset: 0x000015FC
		internal unsafe void GetMatrix(EffectHandle hParameter, out RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			matrixRef = default(RawMatrix);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003464 File Offset: 0x00001664
		internal unsafe void SetMatrixArray(EffectHandle hParameter, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix[] array = matrixRef)
			{
				void* ptr;
				if (matrixRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000034D8 File Offset: 0x000016D8
		internal unsafe void GetMatrixArray(EffectHandle hParameter, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix[] array = matrixRef)
			{
				void* ptr;
				if (matrixRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000354C File Offset: 0x0000174C
		internal unsafe void SetMatrixPointerArray(EffectHandle hParameter, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000035B0 File Offset: 0x000017B0
		internal unsafe void GetMatrixPointerArray(EffectHandle hParameter, out RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			matrixOut = default(RawMatrix);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000361C File Offset: 0x0000181C
		internal unsafe void SetMatrixTranspose(EffectHandle hParameter, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003680 File Offset: 0x00001880
		internal unsafe void GetMatrixTranspose(EffectHandle hParameter, out RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			matrixRef = default(RawMatrix);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000036E8 File Offset: 0x000018E8
		internal unsafe void SetMatrixTransposeArray(EffectHandle hParameter, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix[] array = matrixRef)
			{
				void* ptr;
				if (matrixRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000375C File Offset: 0x0000195C
		internal unsafe void GetMatrixTransposeArray(EffectHandle hParameter, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix[] array = matrixRef)
			{
				void* ptr;
				if (matrixRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000037D0 File Offset: 0x000019D0
		public unsafe void SetMatrixTransposePointerArray(EffectHandle hParameter, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003834 File Offset: 0x00001A34
		public unsafe void GetMatrixTransposePointerArray(EffectHandle hParameter, out RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			matrixOut = default(RawMatrix);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000038A0 File Offset: 0x00001AA0
		public unsafe void SetString(EffectHandle hParameter, string stringRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(stringRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000390C File Offset: 0x00001B0C
		internal unsafe IntPtr GetString_(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr result2;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003968 File Offset: 0x00001B68
		public unsafe void SetTexture(EffectHandle hParameter, BaseTexture textureRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000039D8 File Offset: 0x00001BD8
		public unsafe BaseTexture GetTexture(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			BaseTexture result2 = (zero == IntPtr.Zero) ? null : new BaseTexture(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003A50 File Offset: 0x00001C50
		public unsafe PixelShader GetPixelShader(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			PixelShader result2 = (zero == IntPtr.Zero) ? null : new PixelShader(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public unsafe VertexShader GetVertexShader(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			VertexShader result2 = (zero == IntPtr.Zero) ? null : new VertexShader(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003B40 File Offset: 0x00001D40
		internal unsafe void SetArrayRange(EffectHandle hParameter, int uStart, int uEnd)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, value, uStart, uEnd, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}
	}
}
