using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000013 RID: 19
	[Guid("ab3c758f-093e-4356-b762-4db18f1b3a01")]
	public class ConstantTable : ComObject
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003E56 File Offset: 0x00002056
		public DataStream Buffer
		{
			get
			{
				return new DataStream(this.BufferPointer, (long)this.BufferSize, true, true);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003E6C File Offset: 0x0000206C
		public ConstantDescription GetConstantDescription(EffectHandle effectHandle)
		{
			int num = 1;
			ConstantDescription[] array = new ConstantDescription[1];
			this.GetConstantDescription(effectHandle, array, ref num);
			return array[0];
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003E94 File Offset: 0x00002094
		public ConstantDescription[] GetConstantDescriptionArray(EffectHandle effectHandle)
		{
			int num = 0;
			this.GetConstantDescription(effectHandle, null, ref num);
			ConstantDescription[] array = new ConstantDescription[num];
			this.GetConstantDescription(effectHandle, array, ref num);
			return array;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003EBF File Offset: 0x000020BF
		public void SetValue(Device device, EffectHandle effectHandle, bool value)
		{
			this.SetBool(device, effectHandle, value);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003ECF File Offset: 0x000020CF
		public void SetValue(Device device, EffectHandle effectHandle, float value)
		{
			this.SetFloat(device, effectHandle, value);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003EDA File Offset: 0x000020DA
		public void SetValue(Device device, EffectHandle effectHandle, int value)
		{
			this.SetInt(device, effectHandle, value);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003EE5 File Offset: 0x000020E5
		public void SetValue(Device device, EffectHandle effectHandle, RawMatrix value)
		{
			this.SetMatrix(device, effectHandle, ref value);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003EF1 File Offset: 0x000020F1
		public void SetValue(Device device, EffectHandle effectHandle, RawVector4 value)
		{
			this.SetVector(device, effectHandle, value);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003EFC File Offset: 0x000020FC
		public unsafe void SetValue<T>(Device device, EffectHandle effectHandle, T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetValue(device, effectHandle, (IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003F20 File Offset: 0x00002120
		public void SetValue(Device device, EffectHandle effectHandle, bool[] values)
		{
			RawBool[] bRef = Utilities.ConvertToIntArray(values);
			this.SetBoolArray(device, effectHandle, bRef, values.Length);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003F40 File Offset: 0x00002140
		public void SetValue(Device device, EffectHandle effectHandle, float[] values)
		{
			this.SetFloatArray(device, effectHandle, values, values.Length);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003F4E File Offset: 0x0000214E
		public void SetValue(Device device, EffectHandle effectHandle, int[] values)
		{
			this.SetIntArray(device, effectHandle, values, values.Length);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003F5C File Offset: 0x0000215C
		public void SetValue(Device device, EffectHandle effectHandle, RawMatrix[] values)
		{
			this.SetMatrixArray(device, effectHandle, values, values.Length);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003F6A File Offset: 0x0000216A
		public void SetValue(Device device, EffectHandle effectHandle, RawVector4[] values)
		{
			this.SetVectorArray(device, effectHandle, values, values.Length);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003F78 File Offset: 0x00002178
		public unsafe void SetValue<T>(Device device, EffectHandle effectHandle, T[] values) where T : struct
		{
			fixed (T* value = &values[0])
			{
				this.SetValue(device, effectHandle, (IntPtr)((void*)value), Utilities.SizeOf<T>() * values.Length);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002623 File Offset: 0x00000823
		public ConstantTable(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003FA4 File Offset: 0x000021A4
		public new static explicit operator ConstantTable(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new ConstantTable(nativePointer);
			}
			return null;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003FBB File Offset: 0x000021BB
		public IntPtr BufferPointer
		{
			get
			{
				return this.GetBufferPointer();
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003FC3 File Offset: 0x000021C3
		public int BufferSize
		{
			get
			{
				return this.GetBufferSize();
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003FCC File Offset: 0x000021CC
		public ConstantTableDescription Description
		{
			get
			{
				ConstantTableDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003FE2 File Offset: 0x000021E2
		internal unsafe IntPtr GetBufferPointer()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetBufferSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00004020 File Offset: 0x00002220
		internal unsafe void GetDescription(out ConstantTableDescription descRef)
		{
			ConstantTableDescription.__Native _Native = default(ConstantTableDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			descRef = default(ConstantTableDescription);
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004074 File Offset: 0x00002274
		internal unsafe void GetConstantDescription(EffectHandle effectHandle, ConstantDescription[] constantDescRef, ref int countRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			ConstantDescription.__Native[] array = new ConstantDescription.__Native[constantDescRef.Length];
			ConstantDescription.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result;
			fixed (int* ptr2 = &countRef)
			{
				void* ptr3 = (void*)ptr2;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			array2 = null;
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			for (int i = 0; i < constantDescRef.Length; i++)
			{
				constantDescRef[i].__MarshalFrom(ref array[i]);
			}
			result.CheckError();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004128 File Offset: 0x00002328
		public unsafe int GetSamplerIndex(EffectHandle effectHandle)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			int result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004174 File Offset: 0x00002374
		public unsafe EffectHandle GetConstant(EffectHandle effectHandle, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000041C4 File Offset: 0x000023C4
		public unsafe EffectHandle GetConstantByName(EffectHandle effectHandle, string nameRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004228 File Offset: 0x00002428
		public unsafe EffectHandle GetConstantElement(EffectHandle effectHandle, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000427C File Offset: 0x0000247C
		internal unsafe void SetDefaults(Device deviceRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000042CC File Offset: 0x000024CC
		internal unsafe void SetValue(Device deviceRef, EffectHandle effectHandle, IntPtr dataRef, int bytes)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, (void*)dataRef, bytes, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004344 File Offset: 0x00002544
		internal unsafe void SetBool(Device deviceRef, EffectHandle effectHandle, RawBool b)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, b, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000043B4 File Offset: 0x000025B4
		internal unsafe void SetBoolArray(Device deviceRef, EffectHandle effectHandle, RawBool[] bRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004440 File Offset: 0x00002640
		internal unsafe void SetInt(Device deviceRef, EffectHandle effectHandle, int n)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, n, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000044B0 File Offset: 0x000026B0
		internal unsafe void SetIntArray(Device deviceRef, EffectHandle effectHandle, int[] nRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000453C File Offset: 0x0000273C
		internal unsafe void SetFloat(Device deviceRef, EffectHandle effectHandle, float f)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, f, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000045AC File Offset: 0x000027AC
		internal unsafe void SetFloatArray(Device deviceRef, EffectHandle effectHandle, float[] fRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004638 File Offset: 0x00002838
		internal unsafe void SetVector(Device deviceRef, EffectHandle effectHandle, RawVector4 vectorRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, &vectorRef, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000046A8 File Offset: 0x000028A8
		internal unsafe void SetVectorArray(Device deviceRef, EffectHandle effectHandle, RawVector4[] vectorRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004734 File Offset: 0x00002934
		internal unsafe void SetMatrix(Device deviceRef, EffectHandle effectHandle, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000047AC File Offset: 0x000029AC
		internal unsafe void SetMatrixArray(Device deviceRef, EffectHandle effectHandle, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004838 File Offset: 0x00002A38
		internal unsafe void SetMatrixPointerArray(Device deviceRef, EffectHandle effectHandle, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000048B0 File Offset: 0x00002AB0
		internal unsafe void SetMatrixTranspose(Device deviceRef, EffectHandle effectHandle, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004928 File Offset: 0x00002B28
		internal unsafe void SetMatrixTransposeArray(Device deviceRef, EffectHandle effectHandle, RawMatrix[] matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000049B4 File Offset: 0x00002BB4
		internal unsafe void SetMatrixTransposePointerArray(Device deviceRef, EffectHandle effectHandle, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}
	}
}
