using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000023 RID: 35
	[Guid("51b8a949-1a31-47e6-bea0-4b30db53f1e0")]
	public class EffectCompiler : BaseEffect
	{
		// Token: 0x06000274 RID: 628 RVA: 0x0000A088 File Offset: 0x00008288
		public EffectCompiler(string data, Macro[] defines, Include includeFile, ShaderFlags flags) : base(IntPtr.Zero)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(data);
			try
			{
				EffectCompiler.CreateEffectCompiler(intPtr, data.Length, defines, includeFile, flags, this);
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000A0D4 File Offset: 0x000082D4
		public DataStream CompileEffect(ShaderFlags flags)
		{
			Blob blob = null;
			Blob buffer;
			try
			{
				this.CompileEffect((int)flags, out buffer, out blob);
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
			return new DataStream(buffer);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A120 File Offset: 0x00008320
		public ShaderBytecode CompileShader(EffectHandle functionHandle, string target, ShaderFlags flags)
		{
			ConstantTable constantTable;
			ShaderBytecode result = this.CompileShader(functionHandle, target, flags, out constantTable);
			constantTable.Dispose();
			return result;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A140 File Offset: 0x00008340
		public ShaderBytecode CompileShader(EffectHandle functionHandle, string target, ShaderFlags flags, out ConstantTable constantTable)
		{
			Blob blob = null;
			Blob blob2;
			try
			{
				this.CompileShader(functionHandle, target, (int)flags, out blob2, out blob, out constantTable);
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
			return new ShaderBytecode(blob2);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A190 File Offset: 0x00008390
		public static EffectCompiler FromFile(string fileName, ShaderFlags flags)
		{
			return new EffectCompiler(File.ReadAllText(fileName), null, null, flags);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000A1A0 File Offset: 0x000083A0
		public static EffectCompiler FromFile(string fileName, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			return new EffectCompiler(File.ReadAllText(fileName), defines, includeFile, flags);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A1B0 File Offset: 0x000083B0
		public static EffectCompiler FromMemory(byte[] data, ShaderFlags flags)
		{
			return EffectCompiler.FromMemory(data, null, null, flags);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000A1BC File Offset: 0x000083BC
		public unsafe static EffectCompiler FromMemory(byte[] data, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			EffectCompiler effectCompiler = new EffectCompiler(IntPtr.Zero);
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
				EffectCompiler.CreateEffectCompiler((IntPtr)value, data.Length, defines, includeFile, flags, effectCompiler);
			}
			return effectCompiler;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000A201 File Offset: 0x00008401
		public static EffectCompiler FromStream(Stream stream, ShaderFlags flags)
		{
			return EffectCompiler.FromStream(stream, null, null, flags);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000A20C File Offset: 0x0000840C
		public static EffectCompiler FromStream(Stream stream, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			if (stream is DataStream)
			{
				EffectCompiler effectCompiler = new EffectCompiler(IntPtr.Zero);
				EffectCompiler.CreateEffectCompiler(((DataStream)stream).PositionPointer, (int)(stream.Length - stream.Position), defines, includeFile, flags, effectCompiler);
				return effectCompiler;
			}
			return EffectCompiler.FromMemory(Utilities.ReadStream(stream), defines, includeFile, flags);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A260 File Offset: 0x00008460
		private static void CreateEffectCompiler(IntPtr data, int length, Macro[] defines, Include includeFile, ShaderFlags flags, EffectCompiler instance)
		{
			Blob blob = null;
			try
			{
				D3DX9.CreateEffectCompiler(data, length, defines, IncludeShadow.ToIntPtr(includeFile), (int)flags, instance, out blob);
			}
			catch (SharpDXException ex)
			{
				if (blob != null)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob));
				}
				throw;
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00009988 File Offset: 0x00007B88
		public EffectCompiler(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000A2B0 File Offset: 0x000084B0
		public new static explicit operator EffectCompiler(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new EffectCompiler(nativePointer);
			}
			return null;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000A2C8 File Offset: 0x000084C8
		public unsafe void SetLiteral(EffectHandle hParameter, RawBool literal)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, value, literal, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result.CheckError();
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A324 File Offset: 0x00008524
		public unsafe RawBool GetLiteral(EffectHandle hParameter)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hParameter, ref value);
			RawBool result = default(RawBool);
			Result result2 = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hParameter, ref value);
			result2.CheckError();
			return result;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000A388 File Offset: 0x00008588
		internal unsafe void CompileEffect(int flags, out Blob effectOut, out Blob errorMsgsOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, flags, &zero, &zero2, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
			effectOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			result.CheckError();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000A404 File Offset: 0x00008604
		internal unsafe void CompileShader(EffectHandle hFunction, string targetRef, int flags, out Blob shaderOut, out Blob errorMsgsOut, out ConstantTable constantTableOut)
		{
			EffectHandle.__Native value = default(EffectHandle.__Native);
			EffectHandle.__MarshalTo(ref hFunction, ref value);
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(targetRef);
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, value, (void*)intPtr, flags, &zero, &zero2, &zero3, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*)));
			EffectHandle.__MarshalFree(ref hFunction, ref value);
			Marshal.FreeHGlobal(intPtr);
			shaderOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			errorMsgsOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			constantTableOut = ((zero3 == IntPtr.Zero) ? null : new ConstantTable(zero3));
			result.CheckError();
		}
	}
}
