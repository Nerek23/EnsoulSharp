using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200001C RID: 28
	[Guid("00cddea8-939b-4b83-a340-a685226666cc")]
	public class Output1 : Output
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x000044B4 File Offset: 0x000026B4
		public ModeDescription1[] GetDisplayModeList1(Format enumFormat, DisplayModeEnumerationFlags flags)
		{
			int num = 0;
			this.GetDisplayModeList1(enumFormat, (int)flags, ref num, null);
			ModeDescription1[] array = new ModeDescription1[num];
			if (num > 0)
			{
				this.GetDisplayModeList1(enumFormat, (int)flags, ref num, array);
			}
			return array;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000044E5 File Offset: 0x000026E5
		public Output1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000044EE File Offset: 0x000026EE
		public new static explicit operator Output1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output1(nativePtr);
			}
			return null;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004508 File Offset: 0x00002708
		internal unsafe void GetDisplayModeList1(Format enumFormat, int flags, ref int numModesRef, ModeDescription1[] descRef)
		{
			Result result;
			fixed (ModeDescription1[] array = descRef)
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
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, enumFormat, flags, ptr3, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000456C File Offset: 0x0000276C
		public unsafe void FindClosestMatchingMode1(ref ModeDescription1 modeToMatchRef, out ModeDescription1 closestMatchRef, IUnknown concernedDeviceRef)
		{
			closestMatchRef = default(ModeDescription1);
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(concernedDeviceRef);
			Result result;
			fixed (ModeDescription1* ptr = &closestMatchRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (ModeDescription1* ptr3 = &modeToMatchRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000045D8 File Offset: 0x000027D8
		public unsafe void GetDisplaySurfaceData1(Resource destinationRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(destinationRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004624 File Offset: 0x00002824
		public unsafe OutputDuplication DuplicateOutput(IUnknown deviceRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			OutputDuplication result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new OutputDuplication(zero);
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
