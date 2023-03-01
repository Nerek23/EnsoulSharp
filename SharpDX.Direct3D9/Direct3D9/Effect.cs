using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000022 RID: 34
	[Guid("f6ceb4b3-4e4c-40dd-b883-8d8de5ea0cd5")]
	public class Effect : BaseEffect
	{
		// Token: 0x06000244 RID: 580 RVA: 0x00009625 File Offset: 0x00007825
		public int Begin()
		{
			return this.Begin(FX.None);
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000962E File Offset: 0x0000782E
		// (set) Token: 0x06000246 RID: 582 RVA: 0x00009636 File Offset: 0x00007836
		public EffectHandle Technique
		{
			get
			{
				return this.GetCurrentTechnique();
			}
			set
			{
				this.SetTechnique(value);
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000963F File Offset: 0x0000783F
		public static Effect FromFile(Device device, string fileName, ShaderFlags flags)
		{
			return Effect.FromFile(device, fileName, null, null, null, flags, null);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000964D File Offset: 0x0000784D
		public static Effect FromFile(Device device, string fileName, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags)
		{
			return Effect.FromFile(device, fileName, preprocessorDefines, includeFile, skipConstants, flags, null);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000965D File Offset: 0x0000785D
		public static Effect FromFile(Device device, string fileName, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags, EffectPool pool)
		{
			return Effect.FromString(device, File.ReadAllText(fileName), preprocessorDefines, includeFile, skipConstants, flags, pool);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00009673 File Offset: 0x00007873
		public static Effect FromMemory(Device device, byte[] memory, ShaderFlags flags)
		{
			return Effect.FromMemory(device, memory, null, null, null, flags, null);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009681 File Offset: 0x00007881
		public static Effect FromMemory(Device device, byte[] memory, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags)
		{
			return Effect.FromMemory(device, memory, preprocessorDefines, includeFile, skipConstants, flags, null);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00009694 File Offset: 0x00007894
		public unsafe static Effect FromMemory(Device device, byte[] memory, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags, EffectPool pool)
		{
			Effect result = null;
			Blob blob = null;
			try
			{
				try
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
						D3DX9.CreateEffectEx(device, (IntPtr)value, memory.Length, Effect.PrepareMacros(preprocessorDefines), IncludeShadow.ToIntPtr(includeFile), skipConstants, (int)flags, pool, out result, out blob);
					}
				}
				finally
				{
					byte[] array = null;
				}
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
			return result;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00009720 File Offset: 0x00007920
		public static Effect FromStream(Device device, Stream stream, ShaderFlags flags)
		{
			return Effect.FromStream(device, stream, null, null, null, flags, null);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000972E File Offset: 0x0000792E
		public static Effect FromStream(Device device, Stream stream, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags)
		{
			return Effect.FromStream(device, stream, preprocessorDefines, includeFile, skipConstants, flags, null);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00009740 File Offset: 0x00007940
		public unsafe static Effect FromStream(Device device, Stream stream, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags, EffectPool pool)
		{
			Effect result = null;
			Blob blob = null;
			try
			{
				if (stream is DataStream)
				{
					D3DX9.CreateEffectEx(device, ((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), Effect.PrepareMacros(preprocessorDefines), IncludeShadow.ToIntPtr(includeFile), skipConstants, (int)flags, pool, out result, out blob);
				}
				else
				{
					byte[] array = Utilities.ReadStream(stream);
					try
					{
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
						D3DX9.CreateEffectEx(device, (IntPtr)value, array.Length, Effect.PrepareMacros(preprocessorDefines), IncludeShadow.ToIntPtr(includeFile), skipConstants, (int)flags, pool, out result, out blob);
					}
					finally
					{
						byte[] array2 = null;
					}
				}
				stream.Position = stream.Length;
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
			return result;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00009824 File Offset: 0x00007A24
		public static Effect FromString(Device device, string sourceData, ShaderFlags flags)
		{
			return Effect.FromString(device, sourceData, null, null, null, flags, null);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00009832 File Offset: 0x00007A32
		public static Effect FromString(Device device, string sourceData, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags)
		{
			return Effect.FromString(device, sourceData, preprocessorDefines, includeFile, skipConstants, flags, null);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00009844 File Offset: 0x00007A44
		public static Effect FromString(Device device, string sourceData, Macro[] preprocessorDefines, Include includeFile, string skipConstants, ShaderFlags flags, EffectPool pool)
		{
			Effect result = null;
			Blob blob = null;
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(sourceData);
			try
			{
				D3DX9.CreateEffectEx(device, intPtr, sourceData.Length, Effect.PrepareMacros(preprocessorDefines), IncludeShadow.ToIntPtr(includeFile), skipConstants, (int)flags, pool, out result, out blob);
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return result;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000098C0 File Offset: 0x00007AC0
		public void SetRawValue(EffectHandle handle, float[] data)
		{
			this.SetRawValue(handle, data, 0, data.Length);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000098CE File Offset: 0x00007ACE
		public void SetRawValue(EffectHandle handle, DataStream data)
		{
			this.SetRawValue(handle, data, 0, (int)data.Length);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000098E0 File Offset: 0x00007AE0
		public void SetRawValue(EffectHandle handle, DataStream data, int offset, int countInBytes)
		{
			this.SetRawValue(handle, data.PositionPointer, offset, countInBytes);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000098F4 File Offset: 0x00007AF4
		public unsafe void SetRawValue(EffectHandle handle, float[] data, int startIndex, int count)
		{
			fixed (float* ptr = &data[startIndex])
			{
				void* value = (void*)ptr;
				this.SetRawValue(handle, (IntPtr)value, 0, count << 2);
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009924 File Offset: 0x00007B24
		internal static Macro[] PrepareMacros(Macro[] macros)
		{
			if (macros == null)
			{
				return null;
			}
			if (macros.Length == 0)
			{
				return null;
			}
			if (macros[macros.Length - 1].Name == null && macros[macros.Length - 1].Definition == null)
			{
				return macros;
			}
			Macro[] array = new Macro[macros.Length + 1];
			Array.Copy(macros, array, macros.Length);
			array[macros.Length] = new Macro(null, null);
			return array;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00009988 File Offset: 0x00007B88
		public Effect(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009991 File Offset: 0x00007B91
		public new static explicit operator Effect(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Effect(nativePointer);
			}
			return null;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600025A RID: 602 RVA: 0x000099A8 File Offset: 0x00007BA8
		public EffectPool Pool
		{
			get
			{
				EffectPool result;
				this.GetPool(out result);
				return result;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000099C0 File Offset: 0x00007BC0
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000099D8 File Offset: 0x00007BD8
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000099EE File Offset: 0x00007BEE
		public EffectStateManager StateManager
		{
			get
			{
				EffectStateManager result;
				this.GetStateManager(out result);
				return result;
			}
			set
			{
				this.SetStateManager(value);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000099F8 File Offset: 0x00007BF8
		internal unsafe void GetPool(out EffectPool poolOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			poolOut = ((zero == IntPtr.Zero) ? null : new EffectPool(zero));
			result.CheckError();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00009A54 File Offset: 0x00007C54
		internal unsafe void SetTechnique(EffectHandle hTechnique)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			result.CheckError();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009AAC File Offset: 0x00007CAC
		internal unsafe EffectHandle GetCurrentTechnique()
		{
			return calli(System.Void*(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00009AD4 File Offset: 0x00007CD4
		public unsafe void ValidateTechnique(EffectHandle hTechnique)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			result.CheckError();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00009B2C File Offset: 0x00007D2C
		public unsafe EffectHandle FindNextValidTechnique(EffectHandle hTechnique)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value);
			EffectHandle.__Native _Native = default(EffectHandle.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hTechnique, ref value);
			EffectHandle result2 = new EffectHandle();
			EffectHandle.__MarshalFrom(ref result2, ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00009BA0 File Offset: 0x00007DA0
		public unsafe RawBool IsParameterUsed(EffectHandle hParameter, EffectHandle hTechnique)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			EffectHandle.__Native value2 = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hTechnique, ref value2);
			RawBool result = calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*,System.Void*), this._nativePointer, value, value2, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			EffectHandle.__MarshalFree(ref hTechnique, ref value2);
			return result;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00009C0C File Offset: 0x00007E0C
		public unsafe int Begin(FX flags)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, &result, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00009C4C File Offset: 0x00007E4C
		public unsafe void BeginPass(int pass)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, pass, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00009C88 File Offset: 0x00007E88
		public unsafe void CommitChanges()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00009CC0 File Offset: 0x00007EC0
		public unsafe void EndPass()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00009CF8 File Offset: 0x00007EF8
		public unsafe void End()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00009D30 File Offset: 0x00007F30
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00009D8C File Offset: 0x00007F8C
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00009DC4 File Offset: 0x00007FC4
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00009DFC File Offset: 0x00007FFC
		internal unsafe void SetStateManager(EffectStateManager managerRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((managerRef == null) ? IntPtr.Zero : managerRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00009E4C File Offset: 0x0000804C
		internal unsafe void GetStateManager(out EffectStateManager managerOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*)));
			managerOut = ((zero == IntPtr.Zero) ? null : new EffectStateManager(zero));
			result.CheckError();
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00009EA8 File Offset: 0x000080A8
		public unsafe void BeginParameterBlock()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00009EE0 File Offset: 0x000080E0
		public unsafe EffectHandle EndParameterBlock()
		{
			return calli(System.Void*(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00009F08 File Offset: 0x00008108
		public unsafe void ApplyParameterBlock(EffectHandle hParameterBlock)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameterBlock, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameterBlock, ref value);
			result.CheckError();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00009F60 File Offset: 0x00008160
		public unsafe void DeleteParameterBlock(EffectHandle hParameterBlock)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameterBlock, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, value, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameterBlock, ref value);
			result.CheckError();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00009FB8 File Offset: 0x000081B8
		public unsafe Effect Clone(Device deviceRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*)));
			Effect result2 = (zero == IntPtr.Zero) ? null : new Effect(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A024 File Offset: 0x00008224
		internal unsafe void SetRawValue(EffectHandle hParameter, IntPtr dataRef, int byteOffset, int bytes)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, value, (void*)dataRef, byteOffset, bytes, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}
	}
}
