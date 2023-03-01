using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000B RID: 11
	[Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
	public class ClassInstance : DeviceChild
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000029A0 File Offset: 0x00000BA0
		public ClassInstance(ClassLinkage linkage, string classTypeName, int constantBufferOffset, int constantVectorOffset, int textureOffset, int samplerOffset) : base(IntPtr.Zero)
		{
			linkage.CreateClassInstance(classTypeName, constantBufferOffset, constantVectorOffset, textureOffset, samplerOffset, this);
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000029BC File Offset: 0x00000BBC
		public unsafe string InstanceName
		{
			get
			{
				PointerSize value = default(PointerSize);
				this.GetInstanceName(IntPtr.Zero, ref value);
				sbyte* value2 = stackalloc sbyte[(UIntPtr)value];
				this.GetInstanceName((IntPtr)((void*)value2), ref value);
				return Marshal.PtrToStringAnsi((IntPtr)((void*)value2));
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002A04 File Offset: 0x00000C04
		public unsafe string TypeName
		{
			get
			{
				PointerSize value = default(PointerSize);
				this.GetInstanceName(IntPtr.Zero, ref value);
				sbyte* value2 = stackalloc sbyte[(UIntPtr)value];
				this.GetTypeName((IntPtr)((void*)value2), ref value);
				return Marshal.PtrToStringAnsi((IntPtr)((void*)value2));
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002075 File Offset: 0x00000275
		public ClassInstance(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002A49 File Offset: 0x00000C49
		public new static explicit operator ClassInstance(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ClassInstance(nativePtr);
			}
			return null;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002A60 File Offset: 0x00000C60
		public ClassLinkage ClassLinkage
		{
			get
			{
				ClassLinkage result;
				this.GetClassLinkage(out result);
				return result;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002A78 File Offset: 0x00000C78
		public ClassInstanceDescription Description
		{
			get
			{
				ClassInstanceDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002A90 File Offset: 0x00000C90
		internal unsafe void GetClassLinkage(out ClassLinkage linkageOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				linkageOut = new ClassLinkage(zero);
				return;
			}
			linkageOut = null;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002ADC File Offset: 0x00000CDC
		internal unsafe void GetDescription(out ClassInstanceDescription descRef)
		{
			descRef = default(ClassInstanceDescription);
			fixed (ClassInstanceDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002B18 File Offset: 0x00000D18
		internal unsafe void GetInstanceName(IntPtr instanceNameRef, ref PointerSize bufferLengthRef)
		{
			fixed (PointerSize* ptr = &bufferLengthRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)instanceNameRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002B54 File Offset: 0x00000D54
		internal unsafe void GetTypeName(IntPtr typeNameRef, ref PointerSize bufferLengthRef)
		{
			fixed (PointerSize* ptr = &bufferLengthRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)typeNameRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
