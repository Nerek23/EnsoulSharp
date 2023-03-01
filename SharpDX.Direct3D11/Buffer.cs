using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000009 RID: 9
	[Guid("48570b85-d1ee-4fcd-a250-eb350722b037")]
	public class Buffer : Resource
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000025C8 File Offset: 0x000007C8
		public Buffer(Device device, BufferDescription description) : base(IntPtr.Zero)
		{
			device.CreateBuffer(ref description, null, this);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000025F2 File Offset: 0x000007F2
		public Buffer(Device device, DataStream data, BufferDescription description) : base(IntPtr.Zero)
		{
			device.CreateBuffer(ref description, new DataBox?(new DataBox(data.PositionPointer, 0, 0)), this);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000261C File Offset: 0x0000081C
		public Buffer(Device device, IntPtr dataPointer, BufferDescription description) : base(IntPtr.Zero)
		{
			device.CreateBuffer(ref description, (dataPointer != IntPtr.Zero) ? new DataBox?(new DataBox(dataPointer, 0, 0)) : null, this);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002664 File Offset: 0x00000864
		public Buffer(Device device, int sizeInBytes, ResourceUsage usage, BindFlags bindFlags, CpuAccessFlags accessFlags, ResourceOptionFlags optionFlags, int structureByteStride) : base(IntPtr.Zero)
		{
			BufferDescription bufferDescription = new BufferDescription
			{
				BindFlags = bindFlags,
				CpuAccessFlags = accessFlags,
				OptionFlags = optionFlags,
				SizeInBytes = sizeInBytes,
				Usage = usage,
				StructureByteStride = structureByteStride
			};
			device.CreateBuffer(ref bufferDescription, null, this);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000026CC File Offset: 0x000008CC
		public Buffer(Device device, DataStream data, int sizeInBytes, ResourceUsage usage, BindFlags bindFlags, CpuAccessFlags accessFlags, ResourceOptionFlags optionFlags, int structureByteStride) : base(IntPtr.Zero)
		{
			BufferDescription bufferDescription = new BufferDescription
			{
				BindFlags = bindFlags,
				CpuAccessFlags = accessFlags,
				OptionFlags = optionFlags,
				SizeInBytes = sizeInBytes,
				Usage = usage,
				StructureByteStride = structureByteStride
			};
			device.CreateBuffer(ref bufferDescription, new DataBox?(new DataBox(data.PositionPointer, 0, 0)), this);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002740 File Offset: 0x00000940
		public unsafe static Buffer Create<T>(Device device, BindFlags bindFlags, ref T data, int sizeInBytes = 0, ResourceUsage usage = ResourceUsage.Default, CpuAccessFlags accessFlags = CpuAccessFlags.None, ResourceOptionFlags optionFlags = ResourceOptionFlags.None, int structureByteStride = 0) where T : struct
		{
			Buffer buffer = new Buffer(IntPtr.Zero);
			BufferDescription bufferDescription = new BufferDescription
			{
				BindFlags = bindFlags,
				CpuAccessFlags = accessFlags,
				OptionFlags = optionFlags,
				SizeInBytes = ((sizeInBytes == 0) ? Utilities.SizeOf<T>() : sizeInBytes),
				Usage = usage,
				StructureByteStride = structureByteStride
			};
			fixed (T* value = &data)
			{
				device.CreateBuffer(ref bufferDescription, new DataBox?(new DataBox((IntPtr)((void*)value))), buffer);
				return buffer;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000027BC File Offset: 0x000009BC
		public unsafe static Buffer Create<T>(Device device, BindFlags bindFlags, T[] data, int sizeInBytes = 0, ResourceUsage usage = ResourceUsage.Default, CpuAccessFlags accessFlags = CpuAccessFlags.None, ResourceOptionFlags optionFlags = ResourceOptionFlags.None, int structureByteStride = 0) where T : struct
		{
			Buffer buffer = new Buffer(IntPtr.Zero);
			BufferDescription bufferDescription = new BufferDescription
			{
				BindFlags = bindFlags,
				CpuAccessFlags = accessFlags,
				OptionFlags = optionFlags,
				SizeInBytes = ((sizeInBytes == 0) ? (Utilities.SizeOf<T>() * data.Length) : sizeInBytes),
				Usage = usage,
				StructureByteStride = structureByteStride
			};
			fixed (T* value = &data[0])
			{
				device.CreateBuffer(ref bufferDescription, new DataBox?(new DataBox((IntPtr)((void*)value))), buffer);
				return buffer;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002844 File Offset: 0x00000A44
		public unsafe static Buffer Create<T>(Device device, ref T data, BufferDescription description) where T : struct
		{
			Buffer buffer = new Buffer(IntPtr.Zero);
			if (description.SizeInBytes == 0)
			{
				description.SizeInBytes = Utilities.SizeOf<T>();
			}
			fixed (T* value = &data)
			{
				device.CreateBuffer(ref description, new DataBox?(new DataBox((IntPtr)((void*)value))), buffer);
				return buffer;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000288C File Offset: 0x00000A8C
		public unsafe static Buffer Create<T>(Device device, T[] data, BufferDescription description) where T : struct
		{
			Buffer buffer = new Buffer(IntPtr.Zero);
			if (description.SizeInBytes == 0)
			{
				description.SizeInBytes = Utilities.SizeOf<T>() * data.Length;
			}
			fixed (T* value = &data[0])
			{
				device.CreateBuffer(ref description, new DataBox?(new DataBox((IntPtr)((void*)value))), buffer);
				return buffer;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000028DE File Offset: 0x00000ADE
		public Buffer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000028E7 File Offset: 0x00000AE7
		public new static explicit operator Buffer(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Buffer(nativePtr);
			}
			return null;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002900 File Offset: 0x00000B00
		public BufferDescription Description
		{
			get
			{
				BufferDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002918 File Offset: 0x00000B18
		internal unsafe void GetDescription(out BufferDescription descRef)
		{
			descRef = default(BufferDescription);
			fixed (BufferDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
