using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C9 RID: 201
	[Guid("DD13C59C-36FA-4098-A8FB-C7ED39DC8546")]
	public class VertexDeclaration : ComObject
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x00002623 File Offset: 0x00000823
		public VertexDeclaration(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00017939 File Offset: 0x00015B39
		public new static explicit operator VertexDeclaration(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new VertexDeclaration(nativePointer);
			}
			return null;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x00017950 File Offset: 0x00015B50
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00017968 File Offset: 0x00015B68
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x000179C0 File Offset: 0x00015BC0
		internal unsafe void GetDeclaration(VertexElement[] elementRef, ref int numElementsRef)
		{
			Result result;
			fixed (VertexElement[] array = elementRef)
			{
				void* ptr;
				if (elementRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int* ptr2 = &numElementsRef)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00017A1E File Offset: 0x00015C1E
		public VertexDeclaration(Device device, VertexElement[] elements)
		{
			device.CreateVertexDeclaration(elements, this);
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x00017A30 File Offset: 0x00015C30
		public VertexElement[] Elements
		{
			get
			{
				int num = 0;
				this.GetDeclaration(null, ref num);
				if (num == 0)
				{
					return null;
				}
				VertexElement[] array = new VertexElement[num];
				this.GetDeclaration(array, ref num);
				return array;
			}
		}
	}
}
