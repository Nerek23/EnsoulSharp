using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CC RID: 204
	[Guid("2518526C-E789-4111-A7B9-47EF328D13E6")]
	public class VolumeTexture : BaseTexture
	{
		// Token: 0x060006C0 RID: 1728 RVA: 0x000050B7 File Offset: 0x000032B7
		public VolumeTexture(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00018221 File Offset: 0x00016421
		public new static explicit operator VolumeTexture(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new VolumeTexture(nativePointer);
			}
			return null;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00018238 File Offset: 0x00016438
		public unsafe VolumeDescription GetLevelDescription(int level)
		{
			VolumeDescription result = default(VolumeDescription);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, level, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00018280 File Offset: 0x00016480
		public unsafe Volume GetVolumeLevel(int level)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, level, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			Volume result2 = (zero == IntPtr.Zero) ? null : new Volume(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000182D8 File Offset: 0x000164D8
		internal unsafe void LockBox(int level, out LockedBox lockedVolumeRef, IntPtr boxRef, LockFlags flags)
		{
			lockedVolumeRef = default(LockedBox);
			Result result;
			fixed (LockedBox* ptr = &lockedVolumeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, level, ptr2, (void*)boxRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001832C File Offset: 0x0001652C
		public unsafe void UnlockBox(int level)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, level, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00018368 File Offset: 0x00016568
		internal unsafe void AddDirtyBox(IntPtr dirtyBoxRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)dirtyBoxRef, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000183A8 File Offset: 0x000165A8
		public VolumeTexture(Device device, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool) : base(IntPtr.Zero)
		{
			device.CreateVolumeTexture(width, height, depth, levelCount, (int)usage, format, pool, this, IntPtr.Zero);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000183D8 File Offset: 0x000165D8
		public unsafe VolumeTexture(Device device, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, ref IntPtr sharedHandle) : base(IntPtr.Zero)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				device.CreateVolumeTexture(width, height, depth, levelCount, (int)usage, format, pool, this, new IntPtr(value));
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00018414 File Offset: 0x00016614
		public static VolumeTextureRequirements CheckRequirements(Device device, int width, int height, int depth, int mipLevelCount, Usage usage, Format format, Pool pool)
		{
			VolumeTextureRequirements result = default(VolumeTextureRequirements);
			D3DX9.CheckVolumeTextureRequirements(device, ref result.Width, ref result.Height, ref result.Depth, ref result.MipLevelCount, (int)usage, ref result.Format, pool);
			return result;
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00018458 File Offset: 0x00016658
		public void Fill(Fill3DCallback callback)
		{
			GCHandle value = GCHandle.Alloc(callback);
			try
			{
				D3DX9.FillVolumeTexture(this, FillCallbackHelper.Native2DCallbackPtr, GCHandle.ToIntPtr(value));
			}
			finally
			{
				value.Free();
			}
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001849C File Offset: 0x0001669C
		public void Fill(TextureShader shader)
		{
			D3DX9.FillVolumeTextureTX(this, shader);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x000184A8 File Offset: 0x000166A8
		public DataBox LockBox(int level, LockFlags flags)
		{
			LockedBox lockedBox;
			this.LockBox(level, out lockedBox, IntPtr.Zero, flags);
			return new DataBox(lockedBox.PBits, lockedBox.RowPitch, lockedBox.SlicePitch);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x000184DC File Offset: 0x000166DC
		public unsafe DataBox LockBox(int level, Box box, LockFlags flags)
		{
			LockedBox lockedBox;
			this.LockBox(level, out lockedBox, new IntPtr((void*)(&box)), flags);
			return new DataBox(lockedBox.PBits, lockedBox.RowPitch, lockedBox.SlicePitch);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00018512 File Offset: 0x00016712
		public void AddDirtyBox()
		{
			this.AddDirtyBox(IntPtr.Zero);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001851F File Offset: 0x0001671F
		public unsafe void AddDirtyBox(Box directBoxRef)
		{
			this.AddDirtyBox(new IntPtr((void*)(&directBoxRef)));
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00018530 File Offset: 0x00016730
		public static VolumeTexture FromFile(Device device, string filename)
		{
			VolumeTexture result;
			D3DX9.CreateVolumeTextureFromFileW(device, filename, out result);
			return result;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00018548 File Offset: 0x00016748
		public static VolumeTexture FromFile(Device device, string filename, Usage usage, Pool pool)
		{
			return VolumeTexture.FromFile(device, filename, -1, -1, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00018568 File Offset: 0x00016768
		public static VolumeTexture FromFile(Device device, string filename, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return VolumeTexture.CreateFromFile(device, filename, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00018594 File Offset: 0x00016794
		public unsafe static VolumeTexture FromFile(Device device, string filename, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromFile(device, filename, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x000185C8 File Offset: 0x000167C8
		public unsafe static VolumeTexture FromFile(Device device, string filename, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromFile(device, filename, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001860C File Offset: 0x0001680C
		public unsafe static VolumeTexture FromMemory(Device device, byte[] buffer)
		{
			VolumeTexture result;
			fixed (byte[] array = buffer)
			{
				void* value;
				if (buffer == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				D3DX9.CreateVolumeTextureFromFileInMemory(device, (IntPtr)value, buffer.Length, out result);
			}
			return result;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00018648 File Offset: 0x00016848
		public static VolumeTexture FromMemory(Device device, byte[] buffer, Usage usage, Pool pool)
		{
			return VolumeTexture.FromMemory(device, buffer, -1, -1, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00018668 File Offset: 0x00016868
		public static VolumeTexture FromMemory(Device device, byte[] buffer, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return VolumeTexture.CreateFromMemory(device, buffer, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00018694 File Offset: 0x00016894
		public unsafe static VolumeTexture FromMemory(Device device, byte[] buffer, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromMemory(device, buffer, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x000186C8 File Offset: 0x000168C8
		public unsafe static VolumeTexture FromMemory(Device device, byte[] buffer, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromMemory(device, buffer, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001870C File Offset: 0x0001690C
		public unsafe static VolumeTexture FromStream(Device device, Stream stream)
		{
			VolumeTexture result;
			if (stream is DataStream)
			{
				D3DX9.CreateVolumeTextureFromFileInMemory(device, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), out result);
			}
			else
			{
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
				D3DX9.CreateVolumeTextureFromFileInMemory(device, (IntPtr)value, array.Length, out result);
				array2 = null;
			}
			return result;
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00018778 File Offset: 0x00016978
		public static VolumeTexture FromStream(Device device, Stream stream, Usage usage, Pool pool)
		{
			return VolumeTexture.FromStream(device, stream, 0, -1, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00018798 File Offset: 0x00016998
		public static VolumeTexture FromStream(Device device, Stream stream, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return VolumeTexture.FromStream(device, stream, 0, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey);
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x000187C0 File Offset: 0x000169C0
		public static VolumeTexture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return VolumeTexture.CreateFromStream(device, stream, sizeBytes, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x000187F0 File Offset: 0x000169F0
		public unsafe static VolumeTexture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromStream(device, stream, sizeBytes, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00018828 File Offset: 0x00016A28
		public unsafe static VolumeTexture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return VolumeTexture.CreateFromStream(device, stream, sizeBytes, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0001886C File Offset: 0x00016A6C
		private unsafe static VolumeTexture CreateFromMemory(Device device, byte[] buffer, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			VolumeTexture result;
			fixed (byte[] array = buffer)
			{
				void* value;
				if (buffer == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				result = VolumeTexture.CreateFromPointer(device, (IntPtr)value, buffer.Length, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
			}
			return result;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x000188B8 File Offset: 0x00016AB8
		private unsafe static VolumeTexture CreateFromStream(Device device, Stream stream, int sizeBytes, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			sizeBytes = ((sizeBytes == 0) ? ((int)(stream.Length - stream.Position)) : sizeBytes);
			VolumeTexture result;
			if (stream is DataStream)
			{
				result = VolumeTexture.CreateFromPointer(device, ((DataStream)stream).PositionPointer, sizeBytes, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
			}
			else
			{
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
				result = VolumeTexture.CreateFromPointer(device, (IntPtr)value, array.Length, width, height, depth, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
				array2 = null;
			}
			stream.Position = (long)sizeBytes;
			return result;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00018960 File Offset: 0x00016B60
		private unsafe static VolumeTexture CreateFromPointer(Device device, IntPtr pointer, int sizeInBytes, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			VolumeTexture result;
			D3DX9.CreateVolumeTextureFromFileInMemoryEx(device, pointer, sizeInBytes, width, height, depth, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00018998 File Offset: 0x00016B98
		private unsafe static VolumeTexture CreateFromFile(Device device, string fileName, int width, int height, int depth, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			VolumeTexture result;
			D3DX9.CreateVolumeTextureFromFileExW(device, fileName, width, height, depth, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}
	}
}
