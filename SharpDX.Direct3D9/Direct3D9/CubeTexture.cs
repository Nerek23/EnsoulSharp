using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000014 RID: 20
	[Guid("FFF32F81-D953-473a-9223-93D652ABA93F")]
	public class CubeTexture : BaseTexture
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00004A2C File Offset: 0x00002C2C
		public CubeTexture(Device device, int edgeLength, int levelCount, Usage usage, Format format, Pool pool = Pool.Managed) : base(IntPtr.Zero)
		{
			device.CreateCubeTexture(edgeLength, levelCount, (int)usage, format, pool, this, IntPtr.Zero);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004A50 File Offset: 0x00002C50
		public unsafe CubeTexture(Device device, int edgeLength, int levelCount, Usage usage, Format format, Pool pool, ref IntPtr sharedHandle) : base(IntPtr.Zero)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				device.CreateCubeTexture(edgeLength, levelCount, (int)usage, format, pool, this, (IntPtr)value);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004A88 File Offset: 0x00002C88
		public static CubeTextureRequirements CheckRequirements(Device device, int size, int mipLevelCount, Usage usage, Format format, Pool pool)
		{
			CubeTextureRequirements result = new CubeTextureRequirements
			{
				Size = size,
				MipLevelCount = mipLevelCount,
				Format = format
			};
			D3DX9.CheckCubeTextureRequirements(device, ref result.Size, ref result.MipLevelCount, (int)usage, ref result.Format, pool);
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004AD8 File Offset: 0x00002CD8
		public void Fill(Fill3DCallback callback)
		{
			GCHandle value = GCHandle.Alloc(callback);
			try
			{
				D3DX9.FillCubeTexture(this, FillCallbackHelper.Native3DCallbackPtr, GCHandle.ToIntPtr(value));
			}
			finally
			{
				value.Free();
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004B1C File Offset: 0x00002D1C
		public void Fill(TextureShader shader)
		{
			D3DX9.FillCubeTextureTX(this, shader);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004B28 File Offset: 0x00002D28
		public DataRectangle LockRectangle(CubeMapFace faceType, int level, LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(faceType, level, out lockedRectangle, IntPtr.Zero, flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004B58 File Offset: 0x00002D58
		public DataRectangle LockRectangle(CubeMapFace faceType, int level, LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(faceType, level, out lockedRectangle, IntPtr.Zero, flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.GetLevelDescription(level).Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004BB0 File Offset: 0x00002DB0
		public unsafe DataRectangle LockRectangle(CubeMapFace faceType, int level, RawRectangle rectangle, LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(faceType, level, out lockedRectangle, new IntPtr((void*)(&rectangle)), flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004BE4 File Offset: 0x00002DE4
		public unsafe DataRectangle LockRectangle(CubeMapFace faceType, int level, RawRectangle rectangle, LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(faceType, level, out lockedRectangle, new IntPtr((void*)(&rectangle)), flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.GetLevelDescription(level).Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004C41 File Offset: 0x00002E41
		public void AddDirtyRectangle(CubeMapFace faceType)
		{
			this.AddDirtyRectangle(faceType, IntPtr.Zero);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004C4F File Offset: 0x00002E4F
		public unsafe void AddDirtyRectangle(CubeMapFace faceType, RawRectangle dirtyRectRef)
		{
			this.AddDirtyRectangle(faceType, new IntPtr((void*)(&dirtyRectRef)));
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004C60 File Offset: 0x00002E60
		public static CubeTexture FromFile(Device device, string filename)
		{
			CubeTexture result;
			D3DX9.CreateCubeTextureFromFileW(device, filename, out result);
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004C78 File Offset: 0x00002E78
		public static CubeTexture FromFile(Device device, string filename, Usage usage, Pool pool)
		{
			return CubeTexture.FromFile(device, filename, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004C94 File Offset: 0x00002E94
		public static CubeTexture FromFile(Device device, string filename, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return CubeTexture.CreateFromFile(device, filename, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004CBC File Offset: 0x00002EBC
		public unsafe static CubeTexture FromFile(Device device, string filename, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromFile(device, filename, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004CEC File Offset: 0x00002EEC
		public unsafe static CubeTexture FromFile(Device device, string filename, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromFile(device, filename, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004D2C File Offset: 0x00002F2C
		public unsafe static CubeTexture FromMemory(Device device, byte[] buffer)
		{
			CubeTexture result;
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
				D3DX9.CreateCubeTextureFromFileInMemory(device, (IntPtr)value, buffer.Length, out result);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004D68 File Offset: 0x00002F68
		public static CubeTexture FromMemory(Device device, byte[] buffer, Usage usage, Pool pool)
		{
			return CubeTexture.FromMemory(device, buffer, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004D84 File Offset: 0x00002F84
		public static CubeTexture FromMemory(Device device, byte[] buffer, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return CubeTexture.CreateFromMemory(device, buffer, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004DAC File Offset: 0x00002FAC
		public unsafe static CubeTexture FromMemory(Device device, byte[] buffer, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromMemory(device, buffer, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004DDC File Offset: 0x00002FDC
		public unsafe static CubeTexture FromMemory(Device device, byte[] buffer, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromMemory(device, buffer, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004E1C File Offset: 0x0000301C
		public unsafe static CubeTexture FromStream(Device device, Stream stream)
		{
			CubeTexture result;
			if (stream is DataStream)
			{
				D3DX9.CreateCubeTextureFromFileInMemory(device, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), out result);
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
				D3DX9.CreateCubeTextureFromFileInMemory(device, (IntPtr)value, array.Length, out result);
				array2 = null;
			}
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004E88 File Offset: 0x00003088
		public static CubeTexture FromStream(Device device, Stream stream, Usage usage, Pool pool)
		{
			return CubeTexture.FromStream(device, stream, 0, -1, -1, usage, Format.Unknown, pool, Filter.Default, Filter.Default, 0);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004EA8 File Offset: 0x000030A8
		public static CubeTexture FromStream(Device device, Stream stream, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return CubeTexture.FromStream(device, stream, 0, size, levelCount, usage, format, pool, filter, mipFilter, colorKey);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004ECC File Offset: 0x000030CC
		public static CubeTexture FromStream(Device device, Stream stream, int sizeBytes, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey)
		{
			return CubeTexture.CreateFromStream(device, stream, sizeBytes, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, IntPtr.Zero, null);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004EF8 File Offset: 0x000030F8
		public unsafe static CubeTexture FromStream(Device device, Stream stream, int sizeBytes, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromStream(device, stream, sizeBytes, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, null);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004F2C File Offset: 0x0000312C
		public unsafe static CubeTexture FromStream(Device device, Stream stream, int sizeBytes, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, out ImageInformation imageInformation, out PaletteEntry[] palette)
		{
			palette = new PaletteEntry[256];
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				return CubeTexture.CreateFromStream(device, stream, sizeBytes, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, (IntPtr)value, palette);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004F6C File Offset: 0x0000316C
		private unsafe static CubeTexture CreateFromMemory(Device device, byte[] buffer, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			CubeTexture result;
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
				result = CubeTexture.CreateFromPointer(device, (IntPtr)value, buffer.Length, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
			}
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004FB4 File Offset: 0x000031B4
		private unsafe static CubeTexture CreateFromStream(Device device, Stream stream, int sizeBytes, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			sizeBytes = ((sizeBytes == 0) ? ((int)(stream.Length - stream.Position)) : sizeBytes);
			CubeTexture result;
			if (stream is DataStream)
			{
				result = CubeTexture.CreateFromPointer(device, ((DataStream)stream).PositionPointer, sizeBytes, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
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
				result = CubeTexture.CreateFromPointer(device, (IntPtr)value, array.Length, size, levelCount, usage, format, pool, filter, mipFilter, colorKey, imageInformation, palette);
				array2 = null;
			}
			stream.Position = (long)sizeBytes;
			return result;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005054 File Offset: 0x00003254
		private unsafe static CubeTexture CreateFromPointer(Device device, IntPtr pointer, int sizeInBytes, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			CubeTexture result;
			D3DX9.CreateCubeTextureFromFileInMemoryEx(device, pointer, sizeInBytes, size, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005088 File Offset: 0x00003288
		private unsafe static CubeTexture CreateFromFile(Device device, string fileName, int size, int levelCount, Usage usage, Format format, Pool pool, Filter filter, Filter mipFilter, int colorKey, IntPtr imageInformation, PaletteEntry[] palette)
		{
			CubeTexture result;
			D3DX9.CreateCubeTextureFromFileExW(device, fileName, size, levelCount, (int)usage, format, pool, (int)filter, (int)mipFilter, *(RawColorBGRA*)(&colorKey), imageInformation, palette, out result);
			return result;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000050B7 File Offset: 0x000032B7
		public CubeTexture(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000050C0 File Offset: 0x000032C0
		public new static explicit operator CubeTexture(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new CubeTexture(nativePointer);
			}
			return null;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000050D8 File Offset: 0x000032D8
		public unsafe SurfaceDescription GetLevelDescription(int level)
		{
			SurfaceDescription result = default(SurfaceDescription);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, level, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005120 File Offset: 0x00003320
		public unsafe Surface GetCubeMapSurface(CubeMapFace faceType, int level)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, faceType, level, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000517C File Offset: 0x0000337C
		internal unsafe void LockRectangle(CubeMapFace faceType, int level, out LockedRectangle lockedRectRef, IntPtr rectRef, LockFlags flags)
		{
			lockedRectRef = default(LockedRectangle);
			Result result;
			fixed (LockedRectangle* ptr = &lockedRectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, faceType, level, ptr2, (void*)rectRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000051D0 File Offset: 0x000033D0
		public unsafe void UnlockRectangle(CubeMapFace faceType, int level)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, faceType, level, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000520C File Offset: 0x0000340C
		internal unsafe void AddDirtyRectangle(CubeMapFace faceType, IntPtr dirtyRectRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, faceType, (void*)dirtyRectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
