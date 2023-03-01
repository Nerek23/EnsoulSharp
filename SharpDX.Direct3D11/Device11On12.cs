using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B5 RID: 181
	[Guid("85611e73-70a9-490e-9614-a9e302777904")]
	public class Device11On12 : ComObject
	{
		// Token: 0x06000377 RID: 887 RVA: 0x0000383E File Offset: 0x00001A3E
		public Device11On12(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000DA88 File Offset: 0x0000BC88
		public new static explicit operator Device11On12(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device11On12(nativePtr);
			}
			return null;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000DAA0 File Offset: 0x0000BCA0
		public unsafe void CreateWrappedResource(IUnknown resource12Ref, D3D11ResourceFlags flags11Ref, int inState, int outState, Guid riid, out Resource resource11Out)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(resource12Ref);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, &flags11Ref, inState, outState, &riid, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				resource11Out = new Resource(zero);
			}
			else
			{
				resource11Out = null;
			}
			result.CheckError();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000DB18 File Offset: 0x0000BD18
		public unsafe void ReleaseWrappedResources(Resource[] resourcesOut, int numResources)
		{
			IntPtr* ptr = null;
			if (resourcesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)resourcesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (resourcesOut != null)
			{
				for (int i = 0; i < resourcesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Resource>(resourcesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000DB80 File Offset: 0x0000BD80
		public unsafe void AcquireWrappedResources(Resource[] resourcesOut, int numResources)
		{
			IntPtr* ptr = null;
			if (resourcesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)resourcesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (resourcesOut != null)
			{
				for (int i = 0; i < resourcesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Resource>(resourcesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000DBE5 File Offset: 0x0000BDE5
		public unsafe void ReleaseWrappedResources(ComArray<Resource> resourcesOut, int numResources)
		{
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000DC1A File Offset: 0x0000BE1A
		private unsafe void ReleaseWrappedResources(IntPtr resourcesOut, int numResources)
		{
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)resourcesOut, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000DC40 File Offset: 0x0000BE40
		public unsafe void AcquireWrappedResources(ComArray<Resource> resourcesOut, int numResources)
		{
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((resourcesOut != null) ? resourcesOut.NativePointer : IntPtr.Zero), numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000DC75 File Offset: 0x0000BE75
		private unsafe void AcquireWrappedResources(IntPtr resourcesOut, int numResources)
		{
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)resourcesOut, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}
	}
}
