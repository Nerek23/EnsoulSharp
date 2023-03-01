using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C6 RID: 198
	[Guid("85C31227-3DE5-4f00-9B3A-F11AC38C18B5")]
	public class Texture : BaseTexture
	{
		// Token: 0x0600063F RID: 1599 RVA: 0x000050B7 File Offset: 0x000032B7
		public Texture(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00016646 File Offset: 0x00014846
		public new static explicit operator Texture(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Texture(nativePointer);
			}
			return null;
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00016660 File Offset: 0x00014860
		public unsafe SurfaceDescription GetLevelDescription(int level)
		{
			SurfaceDescription result = default(SurfaceDescription);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, level, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x000166A8 File Offset: 0x000148A8
		public unsafe Surface GetSurfaceLevel(int level)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, level, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00016700 File Offset: 0x00014900
		internal unsafe void LockRectangle(int level, out LockedRectangle lockedRectRef, IntPtr rectRef, LockFlags flags)
		{
			lockedRectRef = default(LockedRectangle);
			Result result;
			fixed (LockedRectangle* ptr = &lockedRectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, level, ptr2, (void*)rectRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00016754 File Offset: 0x00014954
		public unsafe void UnlockRectangle(int level)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, level, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00016790 File Offset: 0x00014990
		internal unsafe void AddDirtyRectangle(IntPtr dirtyRectRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)dirtyRectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000167D0 File Offset: 0x000149D0
		public Texture(Device device, int width, int height, int levelCount, Usage usage, Format format, Pool pool) : base(IntPtr.Zero)
		{
			device.CreateTexture(width, height, levelCount, (int)usage, format, pool, this, IntPtr.Zero);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00016800 File Offset: 0x00014A00
		public unsafe Texture(Device device, int width, int height, int levelCount, Usage usage, Format format, Pool pool, ref IntPtr sharedHandle) : base(IntPtr.Zero)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				device.CreateTexture(width, height, levelCount, (int)usage, format, pool, this, new IntPtr(value));
			}
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00016838 File Offset: 0x00014A38
		public static TextureRequirements CheckRequirements(Device device, int width, int height, int mipLevelCount, Usage usage, Format format, Pool pool)
		{
			TextureRequirements result = default(TextureRequirements);
			D3DX9.CheckTextureRequirements(device, ref result.Width, ref result.Height, ref result.MipLevelCount, (int)usage, ref result.Format, pool);
			return result;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00016874 File Offset: 0x00014A74
		public static void ComputeNormalMap(Texture texture, Texture sourceTexture, NormalMapFlags flags, Channel channel, float amplitude)
		{
			D3DX9.ComputeNormalMap(texture, sourceTexture, null, (int)flags, (int)channel, amplitude);
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00016882 File Offset: 0x00014A82
		public static void ComputeNormalMap(Texture texture, Texture sourceTexture, PaletteEntry[] palette, NormalMapFlags flags, Channel channel, float amplitude)
		{
			D3DX9.ComputeNormalMap(texture, sourceTexture, palette, (int)flags, (int)channel, amplitude);
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00016894 File Offset: 0x00014A94
		public void Fill(Fill2DCallback callback)
		{
			GCHandle value = GCHandle.Alloc(callback);
			try
			{
				D3DX9.FillTexture(this, FillCallbackHelper.Native2DCallbackPtr, GCHandle.ToIntPtr(value));
			}
			finally
			{
				value.Free();
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x000168D8 File Offset: 0x00014AD8
		public void Fill(TextureShader shader)
		{
			D3DX9.FillTextureTX(this, shader);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x000168E4 File Offset: 0x00014AE4
		public DataRectangle LockRectangle(int level, LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(level, out lockedRectangle, IntPtr.Zero, flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00016914 File Offset: 0x00014B14
		public DataRectangle LockRectangle(int level, LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(level, out lockedRectangle, IntPtr.Zero, flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.GetLevelDescription(level).Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0001696C File Offset: 0x00014B6C
		public unsafe DataRectangle LockRectangle(int level, RawRectangle rectangle, LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(level, out lockedRectangle, new IntPtr((void*)(&rectangle)), flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001699C File Offset: 0x00014B9C
		public unsafe DataRectangle LockRectangle(int level, RawRectangle rectangle, LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(level, out lockedRectangle, new IntPtr((void*)(&rectangle)), flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.GetLevelDescription(level).Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000169F6 File Offset: 0x00014BF6
		public void AddDirtyRectangle()
		{
			this.AddDirtyRectangle(IntPtr.Zero);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x00016A03 File Offset: 0x00014C03
		public unsafe void AddDirtyRectangle(RawRectangle dirtyRectRef)
		{
			this.AddDirtyRectangle(new IntPtr((void*)(&dirtyRectRef)));
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00016A14 File Offset: 0x00014C14
		public static Texture FromFile(Device device, string filename)
		{
			Texture result;
			D3DX9.CreateTextureFromFileW(device, filename, out result);
			return result;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00016A2C File Offset: 0x00014C2C
		public static Texture FromFile(Device device, string filename, Usage usage, Pool pool)
		{
			return Texture.FromFile(device, filename, -1, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00016A4C File Offset: 0x00014C4C
		public static Texture FromFile(Device device, string filename, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return Texture.CreateFromFile(device, filename, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00016A78 File Offset: 0x00014C78
		public unsafe static Texture FromFile(Device device, string filename, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromFile(device, filename, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00016AAC File Offset: 0x00014CAC
		public unsafe static Texture FromFile(Device device, string filename, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromFile(device, filename, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00016AEC File Offset: 0x00014CEC
		public unsafe static Texture FromMemory(Device device, byte[] buffer)
		{
			Texture result;
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
				D3DX9.CreateTextureFromFileInMemory(device, (IntPtr)value, buffer.Length, out result);
			}
			return result;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00016B28 File Offset: 0x00014D28
		public static Texture FromMemory(Device device, byte[] buffer, Usage usage, Pool pool)
		{
			return Texture.FromMemory(device, buffer, -1, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00016B48 File Offset: 0x00014D48
		public static Texture FromMemory(Device device, byte[] buffer, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return Texture.CreateFromMemory(device, buffer, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00016B74 File Offset: 0x00014D74
		public unsafe static Texture FromMemory(Device device, byte[] buffer, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromMemory(device, buffer, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00016BA8 File Offset: 0x00014DA8
		public unsafe static Texture FromMemory(Device device, byte[] buffer, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromMemory(device, buffer, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00016BE8 File Offset: 0x00014DE8
		public unsafe static Texture FromStream(Device device, Stream stream)
		{
			Texture result;
			if (stream is DataStream)
			{
				D3DX9.CreateTextureFromFileInMemory(device, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), out result);
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
				D3DX9.CreateTextureFromFileInMemory(device, (IntPtr)value, array.Length, out result);
				array2 = null;
			}
			return result;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00016C54 File Offset: 0x00014E54
		public static Texture FromStream(Device device, Stream stream, Usage usage, Pool pool)
		{
			return Texture.FromStream(device, stream, 0, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00016C74 File Offset: 0x00014E74
		public static Texture FromStream(Device device, Stream stream, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return Texture.FromStream(device, stream, 0, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00016C9C File Offset: 0x00014E9C
		public static Texture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return Texture.CreateFromStream(device, stream, sizeBytes, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00016CC8 File Offset: 0x00014EC8
		public unsafe static Texture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromStream(device, stream, sizeBytes, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00016CFC File Offset: 0x00014EFC
		public unsafe static Texture FromStream(Device device, Stream stream, int sizeBytes, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return Texture.CreateFromStream(device, stream, sizeBytes, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00016D40 File Offset: 0x00014F40
		private unsafe static Texture CreateFromMemory(Device device, byte[] buffer, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			Texture result;
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
				result = Texture.CreateFromPointer(device, (IntPtr)value, buffer.Length, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
			}
			return result;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00016D8C File Offset: 0x00014F8C
		private unsafe static Texture CreateFromStream(Device device, Stream stream, int sizeBytes, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			sizeBytes = ((sizeBytes == 0) ? ((int)(stream.Length - stream.Position)) : sizeBytes);
			Texture result;
			if (stream is DataStream)
			{
				result = Texture.CreateFromPointer(device, ((DataStream)stream).PositionPointer, sizeBytes, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
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
				result = Texture.CreateFromPointer(device, (IntPtr)value, array.Length, width, height, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
				array2 = null;
			}
			stream.Position = (long)sizeBytes;
			return result;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00016E30 File Offset: 0x00015030
		private unsafe static Texture CreateFromPointer(Device device, IntPtr pointer, int sizeInBytes, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			Texture result;
			D3DX9.CreateTextureFromFileInMemoryEx(device, pointer, sizeInBytes, width, height, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00016E64 File Offset: 0x00015064
		private unsafe static Texture CreateFromFile(Device device, string fileName, int width, int height, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			Texture result;
			D3DX9.CreateTextureFromFileExW(device, fileName, width, height, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}
	}
}
