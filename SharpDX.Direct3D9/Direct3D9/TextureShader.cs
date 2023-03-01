using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C7 RID: 199
	[Guid("3e3d67f8-aa7a-405d-a857-ba01d4758426")]
	public class TextureShader : ComObject
	{
		// Token: 0x06000667 RID: 1639 RVA: 0x00002623 File Offset: 0x00000823
		public TextureShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00016E95 File Offset: 0x00015095
		public new static explicit operator TextureShader(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new TextureShader(nativePointer);
			}
			return null;
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00016EAC File Offset: 0x000150AC
		public Blob Function
		{
			get
			{
				Blob result;
				this.GetFunction(out result);
				return result;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00016EC4 File Offset: 0x000150C4
		public Blob ConstantBuffer
		{
			get
			{
				Blob result;
				this.GetConstantBuffer(out result);
				return result;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00016EDC File Offset: 0x000150DC
		public ConstantTableDescription Description
		{
			get
			{
				ConstantTableDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00016EF4 File Offset: 0x000150F4
		internal unsafe void GetFunction(out Blob functionOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			functionOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00016F4C File Offset: 0x0001514C
		internal unsafe void GetConstantBuffer(out Blob constantBufferOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			constantBufferOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00016FA4 File Offset: 0x000151A4
		internal unsafe void GetDescription(out ConstantTableDescription descRef)
		{
			ConstantTableDescription.__Native _Native = default(ConstantTableDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			descRef = default(ConstantTableDescription);
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00016FF8 File Offset: 0x000151F8
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

		// Token: 0x06000670 RID: 1648 RVA: 0x000170AC File Offset: 0x000152AC
		public unsafe EffectHandle GetConstant(EffectHandle effectHandle, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			return result;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x000170FC File Offset: 0x000152FC
		public unsafe EffectHandle GetConstantByName(EffectHandle effectHandle, string nameRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00017160 File Offset: 0x00015360
		public unsafe EffectHandle GetConstantElement(EffectHandle effectHandle, int index)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			EffectHandle result = calli(System.Void*(System.Void*,System.Void*,System.Int32), this._nativePointer, value, index, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			return result;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x000171B4 File Offset: 0x000153B4
		public unsafe void SetDefaults()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x000171EC File Offset: 0x000153EC
		public unsafe void SetValue(EffectHandle effectHandle, IntPtr dataRef, int bytes)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, (void*)dataRef, bytes, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001724C File Offset: 0x0001544C
		public unsafe void SetBool(EffectHandle effectHandle, RawBool b)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, value, b, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x000172A8 File Offset: 0x000154A8
		public unsafe void SetBoolArray(EffectHandle effectHandle, RawBool bRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, &bRef, count, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00017304 File Offset: 0x00015504
		public unsafe void SetInt(EffectHandle effectHandle, int n)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, value, n, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00017360 File Offset: 0x00015560
		public unsafe void SetIntArray(EffectHandle effectHandle, int nRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, &nRef, count, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x000173BC File Offset: 0x000155BC
		public unsafe void SetFloat(EffectHandle effectHandle, float f)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Single), this._nativePointer, value, f, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00017418 File Offset: 0x00015618
		public unsafe void SetFloatArray(EffectHandle effectHandle, float fRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, &fRef, count, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00017474 File Offset: 0x00015674
		public unsafe void SetVector(EffectHandle effectHandle, RawVector4 vectorRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &vectorRef, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x000174D0 File Offset: 0x000156D0
		public unsafe void SetVectorArray(EffectHandle effectHandle, RawVector4 vectorRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, &vectorRef, count, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001752C File Offset: 0x0001572C
		public unsafe void SetMatrix(EffectHandle effectHandle, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00017590 File Offset: 0x00015790
		public unsafe void SetMatrixArray(EffectHandle effectHandle, ref RawMatrix matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x000175F4 File Offset: 0x000157F4
		public unsafe void SetMatrixPointerArray(EffectHandle effectHandle, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00017658 File Offset: 0x00015858
		public unsafe void SetMatrixTranspose(EffectHandle effectHandle, ref RawMatrix matrixRef)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x000176BC File Offset: 0x000158BC
		public unsafe void SetMatrixTransposeArray(EffectHandle effectHandle, ref RawMatrix matrixRef, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00017720 File Offset: 0x00015920
		public unsafe void SetMatrixTransposePointerArray(EffectHandle effectHandle, ref RawMatrix matrixOut, int count)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref effectHandle, ref value);
			Result result;
			fixed (RawMatrix* ptr = &matrixOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, value, ptr2, count, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			}
			EffectHandle.__MarshalFree(ref effectHandle, ref value);
			result.CheckError();
		}
	}
}
