using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C3 RID: 195
	[Guid("0CFBAF3A-9FF6-429a-99B3-A2796AF8B89B")]
	public class Surface : Resource
	{
		// Token: 0x060005ED RID: 1517 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public Surface(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000156FF File Offset: 0x000138FF
		public new static explicit operator Surface(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Surface(nativePointer);
			}
			return null;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x00015718 File Offset: 0x00013918
		public SurfaceDescription Description
		{
			get
			{
				SurfaceDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00015730 File Offset: 0x00013930
		internal unsafe void GetContainer(Guid riid, out IntPtr containerOut)
		{
			Result result;
			fixed (IntPtr* ptr = &containerOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00015774 File Offset: 0x00013974
		internal unsafe void GetDescription(out SurfaceDescription descRef)
		{
			descRef = default(SurfaceDescription);
			Result result;
			fixed (SurfaceDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000157BC File Offset: 0x000139BC
		internal unsafe void LockRectangle(out LockedRectangle lockedRectRef, IntPtr rectRef, LockFlags flags)
		{
			lockedRectRef = default(LockedRectangle);
			Result result;
			fixed (LockedRectangle* ptr = &lockedRectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, ptr2, (void*)rectRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001580C File Offset: 0x00013A0C
		public unsafe void UnlockRectangle()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00015844 File Offset: 0x00013A44
		public unsafe IntPtr GetDC()
		{
			IntPtr result;
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00015880 File Offset: 0x00013A80
		public unsafe void ReleaseDC(IntPtr hdc)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)hdc, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000158BE File Offset: 0x00013ABE
		public static Surface CreateDepthStencil(Device device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool discard)
		{
			return device.CreateDepthStencilSurface(width, height, format, multisampleType, multisampleQuality, discard, IntPtr.Zero);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000158DC File Offset: 0x00013ADC
		public unsafe static Surface CreateDepthStencil(Device device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool discard, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateDepthStencilSurface(width, height, format, multisampleType, multisampleQuality, discard, (IntPtr)value);
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001590C File Offset: 0x00013B0C
		public static Surface CreateDepthStencilEx(DeviceEx device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool discard, Usage usage)
		{
			return device.CreateDepthStencilSurfaceEx(width, height, format, multisampleType, multisampleQuality, discard, IntPtr.Zero, (int)usage);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00015934 File Offset: 0x00013B34
		public unsafe static Surface CreateDepthStencilEx(DeviceEx device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool discard, Usage usage, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateDepthStencilSurfaceEx(width, height, format, multisampleType, multisampleQuality, discard, (IntPtr)value, (int)usage);
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00015963 File Offset: 0x00013B63
		public static Surface CreateOffscreenPlain(Device device, int width, int height, Format format, Pool pool)
		{
			return device.CreateOffscreenPlainSurface(width, height, format, pool, IntPtr.Zero);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00015978 File Offset: 0x00013B78
		public unsafe static Surface CreateOffscreenPlain(Device device, int width, int height, Format format, Pool pool, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateOffscreenPlainSurface(width, height, format, pool, (IntPtr)value);
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0001599C File Offset: 0x00013B9C
		public static Surface CreateOffscreenPlainEx(DeviceEx device, int width, int height, Format format, Pool pool, Usage usage)
		{
			return device.CreateOffscreenPlainSurfaceEx(width, height, format, pool, IntPtr.Zero, (int)usage);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x000159B0 File Offset: 0x00013BB0
		public unsafe static Surface CreateOffscreenPlainEx(DeviceEx device, int width, int height, Format format, Pool pool, Usage usage, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateOffscreenPlainSurfaceEx(width, height, format, pool, (IntPtr)value, (int)usage);
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000159D6 File Offset: 0x00013BD6
		public static Surface CreateRenderTarget(Device device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool lockable)
		{
			return device.CreateRenderTarget(width, height, format, multisampleType, multisampleQuality, lockable, IntPtr.Zero);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000159F4 File Offset: 0x00013BF4
		public unsafe static Surface CreateRenderTarget(Device device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool lockable, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateRenderTarget(width, height, format, multisampleType, multisampleQuality, lockable, (IntPtr)value);
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00015A24 File Offset: 0x00013C24
		public static Surface CreateRenderTargetEx(DeviceEx device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool lockable, Usage usage)
		{
			return device.CreateRenderTargetEx(width, height, format, multisampleType, multisampleQuality, lockable, IntPtr.Zero, (int)usage);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00015A4C File Offset: 0x00013C4C
		public unsafe static Surface CreateRenderTargetEx(DeviceEx device, int width, int height, Format format, MultisampleType multisampleType, int multisampleQuality, bool lockable, Usage usage, ref IntPtr sharedHandle)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				return device.CreateRenderTargetEx(width, height, format, multisampleType, multisampleQuality, lockable, (IntPtr)value, (int)usage);
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00015A7B File Offset: 0x00013C7B
		public static void FromFile(Surface surface, string fileName, Filter filter, int colorKey)
		{
			D3DX9.LoadSurfaceFromFileW(surface, null, IntPtr.Zero, fileName, IntPtr.Zero, filter, colorKey, IntPtr.Zero);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00015A96 File Offset: 0x00013C96
		public unsafe static void FromFile(Surface surface, string fileName, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			D3DX9.LoadSurfaceFromFileW(surface, null, new IntPtr((void*)(&destinationRectangle)), fileName, new IntPtr((void*)(&sourceRectangle)), filter, colorKey, IntPtr.Zero);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00015AB7 File Offset: 0x00013CB7
		public static void FromFile(Surface surface, string fileName, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, out ImageInformation imageInformation)
		{
			Surface.FromFile(surface, fileName, filter, colorKey, sourceRectangle, destinationRectangle, null, out imageInformation);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00015ACC File Offset: 0x00013CCC
		public unsafe static void FromFile(Surface surface, string fileName, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] palette, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				D3DX9.LoadSurfaceFromFileW(surface, palette, new IntPtr((void*)(&destinationRectangle)), fileName, new IntPtr((void*)(&sourceRectangle)), filter, colorKey, (IntPtr)value);
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00015B04 File Offset: 0x00013D04
		public unsafe static void FromFileInMemory(Surface surface, byte[] memory, Filter filter, int colorKey)
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
				D3DX9.LoadSurfaceFromFileInMemory(surface, null, IntPtr.Zero, (IntPtr)value, memory.Length, IntPtr.Zero, filter, colorKey, IntPtr.Zero);
			}
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00015B4C File Offset: 0x00013D4C
		public unsafe static void FromFileInMemory(Surface surface, byte[] memory, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
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
				D3DX9.LoadSurfaceFromFileInMemory(surface, null, new IntPtr((void*)(&destinationRectangle)), (IntPtr)value, memory.Length, new IntPtr((void*)(&sourceRectangle)), filter, colorKey, IntPtr.Zero);
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00015B9A File Offset: 0x00013D9A
		public static void FromFileInMemory(Surface surface, byte[] memory, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, out ImageInformation imageInformation)
		{
			Surface.FromFileInMemory(surface, memory, filter, colorKey, sourceRectangle, destinationRectangle, null, out imageInformation);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00015BAC File Offset: 0x00013DAC
		public unsafe static void FromFileInMemory(Surface surface, byte[] memory, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] palette, out ImageInformation imageInformation)
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
					D3DX9.LoadSurfaceFromFileInMemory(surface, palette, new IntPtr((void*)(&destinationRectangle)), (IntPtr)value, memory.Length, new IntPtr((void*)(&sourceRectangle)), filter, colorKey, (IntPtr)value2);
				}
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00015C08 File Offset: 0x00013E08
		public unsafe static void FromFileInStream(Surface surface, Stream stream, Filter filter, int colorKey)
		{
			if (stream is DataStream)
			{
				D3DX9.LoadSurfaceFromFileInMemory(surface, null, IntPtr.Zero, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), IntPtr.Zero, filter, colorKey, IntPtr.Zero);
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
			D3DX9.LoadSurfaceFromFileInMemory(surface, null, IntPtr.Zero, (IntPtr)value, array.Length, IntPtr.Zero, filter, colorKey, IntPtr.Zero);
			array2 = null;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00015C91 File Offset: 0x00013E91
		public static void FromFileInStream(Surface surface, Stream stream, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			Surface.CreateFromFileInStream(surface, stream, filter, colorKey, sourceRectangle, destinationRectangle, null, IntPtr.Zero);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00015CA6 File Offset: 0x00013EA6
		public static void FromFileInStream(Surface surface, Stream stream, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, out ImageInformation imageInformation)
		{
			Surface.FromFileInStream(surface, stream, filter, colorKey, sourceRectangle, destinationRectangle, null, out imageInformation);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00015CB8 File Offset: 0x00013EB8
		public unsafe static void FromFileInStream(Surface surface, Stream stream, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] palette, out ImageInformation imageInformation)
		{
			fixed (ImageInformation* ptr = &imageInformation)
			{
				void* value = (void*)ptr;
				Surface.CreateFromFileInStream(surface, stream, filter, colorKey, sourceRectangle, destinationRectangle, palette, (IntPtr)value);
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00015CE4 File Offset: 0x00013EE4
		private unsafe static void CreateFromFileInStream(Surface surface, Stream stream, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] palette, IntPtr imageInformation)
		{
			if (stream is DataStream)
			{
				D3DX9.LoadSurfaceFromFileInMemory(surface, palette, new IntPtr((void*)(&destinationRectangle)), ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), new IntPtr((void*)(&sourceRectangle)), filter, colorKey, imageInformation);
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
			D3DX9.LoadSurfaceFromFileInMemory(surface, palette, new IntPtr((void*)(&destinationRectangle)), (IntPtr)value, array.Length, new IntPtr((void*)(&sourceRectangle)), filter, colorKey, imageInformation);
			array2 = null;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00015D78 File Offset: 0x00013F78
		public static void FromMemory(Surface surface, byte[] data, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle)
		{
			Surface.FromMemory(surface, data, filter, colorKey, sourceFormat, sourcePitch, sourceRectangle, null, null);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00015D98 File Offset: 0x00013F98
		public static void FromMemory(Surface surface, byte[] data, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			Surface.FromMemory(surface, data, filter, colorKey, sourceFormat, sourcePitch, sourceRectangle, destinationRectangle, null, null);
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00015DB8 File Offset: 0x00013FB8
		public unsafe static void FromMemory(Surface surface, byte[] data, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, PaletteEntry[] sourcePalette, PaletteEntry[] destinationPalette)
		{
			fixed (byte[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, IntPtr.Zero, (IntPtr)value, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00015E04 File Offset: 0x00014004
		public unsafe static void FromMemory(Surface surface, byte[] data, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] sourcePalette, PaletteEntry[] destinationPalette)
		{
			fixed (byte[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, new IntPtr((void*)(&destinationRectangle)), (IntPtr)value, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00015E54 File Offset: 0x00014054
		public static void FromStream(Surface surface, Stream stream, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle)
		{
			Surface.FromStream(surface, stream, filter, colorKey, sourceFormat, sourcePitch, sourceRectangle, null, null);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00015E74 File Offset: 0x00014074
		public static void FromStream(Surface surface, Stream stream, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			Surface.FromStream(surface, stream, filter, colorKey, sourceFormat, sourcePitch, sourceRectangle, destinationRectangle, null, null);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00015E94 File Offset: 0x00014094
		public unsafe static void FromStream(Surface surface, Stream stream, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, PaletteEntry[] sourcePalette, PaletteEntry[] destinationPalette)
		{
			if (stream is DataStream)
			{
				D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, IntPtr.Zero, ((DataStream)stream).PositionPointer, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
				return;
			}
			byte[] array;
			void* value;
			if ((array = Utilities.ReadStream(stream)) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, IntPtr.Zero, (IntPtr)value, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
			array = null;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00015F14 File Offset: 0x00014114
		public unsafe static void FromStream(Surface surface, Stream stream, Filter filter, int colorKey, Format sourceFormat, int sourcePitch, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] sourcePalette, PaletteEntry[] destinationPalette)
		{
			if (stream is DataStream)
			{
				D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, new IntPtr((void*)(&destinationRectangle)), ((DataStream)stream).PositionPointer, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
				return;
			}
			byte[] array;
			void* value;
			if ((array = Utilities.ReadStream(stream)) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			D3DX9.LoadSurfaceFromMemory(surface, destinationPalette, new IntPtr((void*)(&destinationRectangle)), (IntPtr)value, sourceFormat, sourcePitch, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
			array = null;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00015F9A File Offset: 0x0001419A
		public static void FromSurface(Surface destinationSurface, Surface sourceSurface, Filter filter, int colorKey)
		{
			D3DX9.LoadSurfaceFromSurface(destinationSurface, null, IntPtr.Zero, sourceSurface, null, IntPtr.Zero, filter, colorKey);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00015FB1 File Offset: 0x000141B1
		public static void FromSurface(Surface destinationSurface, Surface sourceSurface, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			Surface.FromSurface(destinationSurface, sourceSurface, filter, colorKey, sourceRectangle, destinationRectangle, null, null);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00015FC2 File Offset: 0x000141C2
		public unsafe static void FromSurface(Surface destinationSurface, Surface sourceSurface, Filter filter, int colorKey, RawRectangle sourceRectangle, RawRectangle destinationRectangle, PaletteEntry[] destinationPalette, PaletteEntry[] sourcePalette)
		{
			D3DX9.LoadSurfaceFromSurface(destinationSurface, destinationPalette, new IntPtr((void*)(&destinationRectangle)), sourceSurface, sourcePalette, new IntPtr((void*)(&sourceRectangle)), filter, colorKey);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00015FE4 File Offset: 0x000141E4
		public T GetContainer<T>(Guid guid) where T : ComObject
		{
			IntPtr comObjectPtr;
			this.GetContainer(guid, out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00016000 File Offset: 0x00014200
		public DataRectangle LockRectangle(LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(out lockedRectangle, IntPtr.Zero, flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001602C File Offset: 0x0001422C
		public unsafe DataRectangle LockRectangle(RawRectangle rect, LockFlags flags)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(out lockedRectangle, new IntPtr((void*)(&rect)), flags);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001605C File Offset: 0x0001425C
		public DataRectangle LockRectangle(LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(out lockedRectangle, IntPtr.Zero, flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.Description.Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x000160B0 File Offset: 0x000142B0
		public unsafe DataRectangle LockRectangle(RawRectangle rect, LockFlags flags, out DataStream stream)
		{
			LockedRectangle lockedRectangle;
			this.LockRectangle(out lockedRectangle, new IntPtr((void*)(&rect)), flags);
			stream = new DataStream(lockedRectangle.PBits, (long)(lockedRectangle.Pitch * this.Description.Height), true, (flags & LockFlags.ReadOnly) == LockFlags.None);
			return new DataRectangle(lockedRectangle.PBits, lockedRectangle.Pitch);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00016107 File Offset: 0x00014307
		public static void ToFile(Surface surface, string fileName, ImageFileFormat format)
		{
			D3DX9.SaveSurfaceToFileW(fileName, format, surface, null, IntPtr.Zero);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00016117 File Offset: 0x00014317
		public static void ToFile(Surface surface, string fileName, ImageFileFormat format, RawRectangle rectangle)
		{
			Surface.ToFile(surface, fileName, format, rectangle, null);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00016123 File Offset: 0x00014323
		public unsafe static void ToFile(Surface surface, string fileName, ImageFileFormat format, RawRectangle rectangle, PaletteEntry[] palette)
		{
			D3DX9.SaveSurfaceToFileW(fileName, format, surface, palette, new IntPtr((void*)(&rectangle)));
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00016138 File Offset: 0x00014338
		public static DataStream ToStream(Surface surface, ImageFileFormat format)
		{
			Blob buffer;
			D3DX9.SaveSurfaceToFileInMemory(out buffer, format, surface, null, IntPtr.Zero);
			return new DataStream(buffer);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001615A File Offset: 0x0001435A
		public static DataStream ToStream(Surface surface, ImageFileFormat format, RawRectangle rectangle)
		{
			return Surface.ToStream(surface, format, rectangle, null);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00016168 File Offset: 0x00014368
		public unsafe static DataStream ToStream(Surface surface, ImageFileFormat format, RawRectangle rectangle, PaletteEntry[] palette)
		{
			Blob buffer;
			D3DX9.SaveSurfaceToFileInMemory(out buffer, format, surface, palette, new IntPtr((void*)(&rectangle)));
			return new DataStream(buffer);
		}
	}
}
