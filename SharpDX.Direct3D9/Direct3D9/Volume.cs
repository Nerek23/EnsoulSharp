using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CB RID: 203
	[Guid("24F416E6-1F67-4aa7-B88E-D33F6F3128A1")]
	public class Volume : ComObject
	{
		// Token: 0x0600069B RID: 1691 RVA: 0x00002623 File Offset: 0x00000823
		public Volume(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00017B9F File Offset: 0x00015D9F
		public new static explicit operator Volume(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Volume(nativePointer);
			}
			return null;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00017BB8 File Offset: 0x00015DB8
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x00017BD0 File Offset: 0x00015DD0
		public VolumeDescription Description
		{
			get
			{
				VolumeDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00017BE8 File Offset: 0x00015DE8
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00017C40 File Offset: 0x00015E40
		public unsafe void SetPrivateData(Guid refguid, IntPtr dataRef, int sizeOfData, int flags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, &refguid, (void*)dataRef, sizeOfData, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00017C84 File Offset: 0x00015E84
		public unsafe void GetPrivateData(Guid refguid, IntPtr dataRef, out int sizeOfDataRef)
		{
			Result result;
			fixed (int* ptr = &sizeOfDataRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &refguid, (void*)dataRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00017CD0 File Offset: 0x00015ED0
		public unsafe void FreePrivateData(Guid refguid)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &refguid, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00017D0C File Offset: 0x00015F0C
		public unsafe void GetContainer(Guid riid, IntPtr containerOut)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, (void*)containerOut, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00017D4C File Offset: 0x00015F4C
		internal unsafe void GetDescription(out VolumeDescription descRef)
		{
			descRef = default(VolumeDescription);
			Result result;
			fixed (VolumeDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00017D94 File Offset: 0x00015F94
		internal unsafe void LockBox(out LockedBox lockedVolumeRef, IntPtr boxRef, LockFlags flags)
		{
			lockedVolumeRef = default(LockedBox);
			Result result;
			fixed (LockedBox* ptr = &lockedVolumeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, ptr2, (void*)boxRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00017DE4 File Offset: 0x00015FE4
		public unsafe void UnlockBox()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00017E1C File Offset: 0x0001601C
		public unsafe void LoadFromMemory(PaletteEntry[] destPaletteRef, Box? destBox, IntPtr srcMemoryPointer, Format srcFormat, int srcRowPitch, int srcSlicePitch, PaletteEntry[] srcPaletteRef, Box srcBox, Filter filter, RawColorBGRA colorKey)
		{
			Box value;
			if (destBox != null)
			{
				value = destBox.Value;
			}
			D3DX9.LoadVolumeFromMemory(this, destPaletteRef, new IntPtr((void*)(&value)), srcMemoryPointer, srcFormat, srcRowPitch, srcSlicePitch, srcPaletteRef, new IntPtr((void*)(&srcBox)), filter, *(int*)(&colorKey));
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00017E60 File Offset: 0x00016060
		public static void FromFile(Volume volume, string fileName, Filter filter, int colorKey)
		{
			D3DX9.LoadVolumeFromFileW(volume, null, IntPtr.Zero, fileName, IntPtr.Zero, filter, colorKey, IntPtr.Zero);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00017E7B File Offset: 0x0001607B
		public unsafe static void FromFile(Volume volume, string fileName, Filter filter, int colorKey, Box sourceBox, Box destinationBox)
		{
			D3DX9.LoadVolumeFromFileW(volume, null, new IntPtr((void*)(&destinationBox)), fileName, new IntPtr((void*)(&sourceBox)), filter, colorKey, IntPtr.Zero);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00017E9C File Offset: 0x0001609C
		public static void FromFile(Volume volume, string fileName, Filter filter, int colorKey, Box sourceBox, Box destinationBox, out ImageInformation imageInformation)
		{
			Volume.FromFile(volume, fileName, filter, colorKey, sourceBox, destinationBox, null, out imageInformation);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00017EB0 File Offset: 0x000160B0
		public unsafe static void FromFile(Volume volume, string fileName, Filter filter, int colorKey, Box sourceBox, Box destinationBox, PaletteEntry[] palette, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				D3DX9.LoadVolumeFromFileW(volume, palette, new IntPtr((void*)(&destinationBox)), fileName, new IntPtr((void*)(&sourceBox)), filter, colorKey, (IntPtr)value);
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00017EE8 File Offset: 0x000160E8
		public unsafe static void FromFileInMemory(Volume volume, byte[] memory, Filter filter, int colorKey)
		{
			fixed (byte[] array = memory)
			{
				void* value;
				if (memory == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				D3DX9.LoadVolumeFromFileInMemory(volume, null, IntPtr.Zero, (IntPtr)value, memory.Length, IntPtr.Zero, filter, colorKey, IntPtr.Zero);
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00017F30 File Offset: 0x00016130
		public unsafe static void FromFileInMemory(Volume volume, byte[] memory, Filter filter, int colorKey, Box sourceBox, Box destinationBox)
		{
			fixed (byte[] array = memory)
			{
				void* value;
				if (memory == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				D3DX9.LoadVolumeFromFileInMemory(volume, null, new IntPtr((void*)(&destinationBox)), (IntPtr)value, memory.Length, new IntPtr((void*)(&sourceBox)), filter, colorKey, IntPtr.Zero);
			}
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00017F7E File Offset: 0x0001617E
		public static void FromFileInMemory(Volume volume, byte[] memory, Filter filter, int colorKey, Box sourceBox, Box destinationBox, out ImageInformation imageInformation)
		{
			Volume.FromFileInMemory(volume, memory, filter, colorKey, sourceBox, destinationBox, null, out imageInformation);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00017F90 File Offset: 0x00016190
		public unsafe static void FromFileInMemory(Volume volume, byte[] memory, Filter filter, int colorKey, Box sourceBox, Box destinationBox, PaletteEntry[] palette, out ImageInformation imageInformation)
		{
			fixed (byte[] array = memory)
			{
				void* value;
				if (memory == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				fixed (ImageInformation* ptr = &imageInformation)
				{
					void* value2 = (void*)ptr;
					D3DX9.LoadVolumeFromFileInMemory(volume, palette, new IntPtr((void*)(&destinationBox)), (IntPtr)value, memory.Length, new IntPtr((void*)(&sourceBox)), filter, colorKey, (IntPtr)value2);
				}
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00017FE9 File Offset: 0x000161E9
		public static void FromFileInStream(Volume volume, Stream stream, Filter filter, int colorKey)
		{
			Volume.CreateFromFileInStream(volume, stream, filter, colorKey, IntPtr.Zero, IntPtr.Zero, null, IntPtr.Zero);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00018004 File Offset: 0x00016204
		public unsafe static void FromFileInStream(Volume volume, Stream stream, Filter filter, int colorKey, Box sourceBox, Box destinationBox)
		{
			Volume.CreateFromFileInStream(volume, stream, filter, colorKey, new IntPtr((void*)(&sourceBox)), new IntPtr((void*)(&destinationBox)), null, IntPtr.Zero);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00018025 File Offset: 0x00016225
		public static void FromFileInStream(Volume volume, Stream stream, Filter filter, int colorKey, Box sourceBox, Box destinationBox, out ImageInformation imageInformation)
		{
			Volume.FromFileInStream(volume, stream, filter, colorKey, sourceBox, destinationBox, null, out imageInformation);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00018038 File Offset: 0x00016238
		public unsafe static void FromFileInStream(Volume volume, Stream stream, Filter filter, int colorKey, Box sourceBox, Box destinationBox, PaletteEntry[] palette, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				Volume.CreateFromFileInStream(volume, stream, filter, colorKey, new IntPtr((void*)(&sourceBox)), new IntPtr((void*)(&destinationBox)), palette, (IntPtr)value);
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00018070 File Offset: 0x00016270
		private unsafe static void CreateFromFileInStream(Volume volume, Stream stream, Filter filter, int colorKey, IntPtr sourceBox, IntPtr destinationBox, PaletteEntry[] palette, IntPtr imageInformation)
		{
			if (stream is DataStream)
			{
				D3DX9.LoadVolumeFromFileInMemory(volume, palette, destinationBox, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), sourceBox, filter, colorKey, imageInformation);
				return;
			}
			byte[] array = Utilities.ReadStream(stream);
			byte[] array2;
			void* value;
			if ((array2 = array) == null || array2.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array2[0]);
			}
			D3DX9.LoadVolumeFromFileInMemory(volume, palette, destinationBox, (IntPtr)value, array.Length, sourceBox, filter, colorKey, imageInformation);
			array2 = null;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x000180E9 File Offset: 0x000162E9
		public static void FromVolume(Volume destinationVolume, Volume sourceVolume, Filter filter, int colorKey)
		{
			D3DX9.LoadVolumeFromVolume(destinationVolume, null, IntPtr.Zero, sourceVolume, null, IntPtr.Zero, filter, colorKey);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00018100 File Offset: 0x00016300
		public static void FromVolume(Volume destinationVolume, Volume sourceVolume, Filter filter, int colorKey, Box sourceBox, Box destinationBox)
		{
			Volume.FromVolume(destinationVolume, sourceVolume, filter, colorKey, sourceBox, destinationBox, null, null);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00018111 File Offset: 0x00016311
		public unsafe static void FromVolume(Volume destinationVolume, Volume sourceVolume, Filter filter, int colorKey, Box sourceBox, Box destinationBox, PaletteEntry[] destinationPalette, PaletteEntry[] sourcePalette)
		{
			D3DX9.LoadVolumeFromVolume(destinationVolume, destinationPalette, new IntPtr((void*)(&destinationBox)), sourceVolume, sourcePalette, new IntPtr((void*)(&sourceBox)), filter, colorKey);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00018130 File Offset: 0x00016330
		public DataBox LockBox(LockFlags flags)
		{
			LockedBox lockedBox;
			this.LockBox(out lockedBox, IntPtr.Zero, flags);
			return new DataBox(lockedBox.PBits, lockedBox.RowPitch, lockedBox.SlicePitch);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00018164 File Offset: 0x00016364
		public unsafe DataBox LockBox(Box box, LockFlags flags)
		{
			LockedBox lockedBox;
			this.LockBox(out lockedBox, new IntPtr((void*)(&box)), flags);
			return new DataBox(lockedBox.PBits, lockedBox.RowPitch, lockedBox.SlicePitch);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00018199 File Offset: 0x00016399
		public static void ToFile(Volume volume, string fileName, ImageFileFormat format)
		{
			D3DX9.SaveVolumeToFileW(fileName, format, volume, null, IntPtr.Zero);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000181A9 File Offset: 0x000163A9
		public static void ToFile(Volume volume, string fileName, ImageFileFormat format, Box box)
		{
			Volume.ToFile(volume, fileName, format, box, null);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000181B5 File Offset: 0x000163B5
		public unsafe static void ToFile(Volume volume, string fileName, ImageFileFormat format, Box box, PaletteEntry[] palette)
		{
			D3DX9.SaveVolumeToFileW(fileName, format, volume, palette, new IntPtr((void*)(&box)));
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000181CC File Offset: 0x000163CC
		public static DataStream ToStream(Volume volume, ImageFileFormat format)
		{
			Blob buffer;
			D3DX9.SaveVolumeToFileInMemory(out buffer, format, volume, null, IntPtr.Zero);
			return new DataStream(buffer);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x000181EE File Offset: 0x000163EE
		public static DataStream ToStream(Volume volume, ImageFileFormat format, Box box)
		{
			return Volume.ToStream(volume, format, box, null);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x000181FC File Offset: 0x000163FC
		public unsafe static DataStream ToStream(Volume volume, ImageFileFormat format, Box box, PaletteEntry[] palette)
		{
			Blob buffer;
			D3DX9.SaveVolumeToFileInMemory(out buffer, format, volume, palette, new IntPtr((void*)(&box)));
			return new DataStream(buffer);
		}
	}
}
