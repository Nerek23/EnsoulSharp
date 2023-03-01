using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000125 RID: 293
	public class ShaderBytecode : DisposeBase
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x0001AAA1 File Offset: 0x00018CA1
		public ShaderBytecode(DataStream data)
		{
			this.CreateFromPointer(data.PositionPointer, (int)(data.Length - data.Position));
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001AAC4 File Offset: 0x00018CC4
		public ShaderBytecode(Stream data)
		{
			int num = (int)(data.Length - data.Position);
			byte[] buffer = new byte[num];
			data.Read(buffer, 0, num);
			this.CreateFromBuffer(buffer);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0001AAFE File Offset: 0x00018CFE
		public ShaderBytecode(byte[] buffer)
		{
			this.CreateFromBuffer(buffer);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0001AB0D File Offset: 0x00018D0D
		public ShaderBytecode(IntPtr buffer, int sizeInBytes)
		{
			this.BufferPointer = buffer;
			this.BufferSize = sizeInBytes;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0001AB28 File Offset: 0x00018D28
		protected internal ShaderBytecode(Blob blob)
		{
			this.blob = blob;
			this.BufferPointer = blob.BufferPointer;
			this.BufferSize = blob.BufferSize;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x0001AB4F File Offset: 0x00018D4F
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x0001AB57 File Offset: 0x00018D57
		public IntPtr BufferPointer { get; private set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0001AB60 File Offset: 0x00018D60
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x0001AB68 File Offset: 0x00018D68
		public PointerSize BufferSize { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x0001AB74 File Offset: 0x00018D74
		public ConstantTable ConstantTable
		{
			get
			{
				if (this.constantTable != null)
				{
					return this.constantTable;
				}
				return this.constantTable = D3DX9.GetShaderConstantTable(this.BufferPointer);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0001ABA4 File Offset: 0x00018DA4
		public int Version
		{
			get
			{
				return D3DX9.GetShaderVersion(this.BufferPointer);
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0001ABB1 File Offset: 0x00018DB1
		public static int GetShaderSize(IntPtr shaderFunctionPtr)
		{
			return D3DX9.GetShaderSize(shaderFunctionPtr);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0001ABB9 File Offset: 0x00018DB9
		public static CompilationResult Assemble(byte[] sourceData, ShaderFlags flags)
		{
			return ShaderBytecode.Assemble(sourceData, null, null, flags);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001ABC4 File Offset: 0x00018DC4
		public static CompilationResult Assemble(string sourceData, ShaderFlags flags)
		{
			return ShaderBytecode.Assemble(sourceData, null, null, flags);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0001ABCF File Offset: 0x00018DCF
		public static CompilationResult Assemble(string sourceData, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			return ShaderBytecode.Assemble(Encoding.ASCII.GetBytes(sourceData), defines, includeFile, flags);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0001ABE4 File Offset: 0x00018DE4
		public unsafe static CompilationResult Assemble(byte[] sourceData, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			Result resultCode = Result.Ok;
			Blob blob = null;
			Blob blob2 = null;
			try
			{
				try
				{
					fixed (byte[] array = sourceData)
					{
						void* value;
						if (sourceData == null || array.Length == 0)
						{
							value = null;
						}
						else
						{
							value = (void*)(&array[0]);
						}
						D3DX9.AssembleShader((IntPtr)value, sourceData.Length, ShaderBytecode.PrepareMacros(defines), IncludeShadow.ToIntPtr(includeFile), (int)flags, out blob, out blob2);
					}
				}
				finally
				{
					byte[] array = null;
				}
			}
			catch (SharpDXException ex)
			{
				if (blob2 == null)
				{
					throw;
				}
				resultCode = ex.ResultCode;
				if (Configuration.ThrowOnShaderCompileError)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob2));
				}
			}
			return new CompilationResult((blob != null) ? new ShaderBytecode(blob) : null, resultCode, Utilities.BlobToString(blob2));
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001AC9C File Offset: 0x00018E9C
		public static CompilationResult AssembleFromFile(string fileName, ShaderFlags flags)
		{
			return ShaderBytecode.AssembleFromFile(fileName, null, null, flags);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001ACA7 File Offset: 0x00018EA7
		public static CompilationResult AssembleFromFile(string fileName, Macro[] defines, Include includeFile, ShaderFlags flags)
		{
			return ShaderBytecode.Assemble(File.ReadAllText(fileName), defines, includeFile, flags);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001ACB7 File Offset: 0x00018EB7
		public static CompilationResult Compile(string shaderSource, string profile, ShaderFlags shaderFlags)
		{
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			return ShaderBytecode.Compile(Encoding.ASCII.GetBytes(shaderSource), null, profile, shaderFlags, null, null);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001ACE1 File Offset: 0x00018EE1
		public static CompilationResult Compile(byte[] shaderSource, string profile, ShaderFlags shaderFlags)
		{
			return ShaderBytecode.Compile(shaderSource, null, profile, shaderFlags, null, null);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001ACEE File Offset: 0x00018EEE
		public static CompilationResult Compile(string shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags)
		{
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			return ShaderBytecode.Compile(Encoding.ASCII.GetBytes(shaderSource), entryPoint, profile, shaderFlags, null, null);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001AD18 File Offset: 0x00018F18
		public static CompilationResult Compile(byte[] shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags)
		{
			return ShaderBytecode.Compile(shaderSource, entryPoint, profile, shaderFlags, null, null);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0001AD25 File Offset: 0x00018F25
		public static CompilationResult Compile(string shaderSource, string profile, ShaderFlags shaderFlags, Macro[] defines, Include include)
		{
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			return ShaderBytecode.Compile(Encoding.ASCII.GetBytes(shaderSource), null, profile, shaderFlags, defines, include);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001AD50 File Offset: 0x00018F50
		public static CompilationResult Compile(byte[] shaderSource, string profile, ShaderFlags shaderFlags, Macro[] defines, Include include)
		{
			return ShaderBytecode.Compile(shaderSource, null, profile, shaderFlags, defines, include);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001AD5E File Offset: 0x00018F5E
		public static CompilationResult Compile(string shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags, Macro[] defines, Include include)
		{
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			return ShaderBytecode.Compile(Encoding.ASCII.GetBytes(shaderSource), entryPoint, profile, shaderFlags, defines, include);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001AD8A File Offset: 0x00018F8A
		public static CompilationResult CompileFromFile(string fileName, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, Macro[] defines = null, Include include = null)
		{
			return ShaderBytecode.CompileFromFile(fileName, null, profile, shaderFlags, defines, include);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001AD98 File Offset: 0x00018F98
		public static CompilationResult CompileFromFile(string fileName, string entryPoint, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, Macro[] defines = null, Include include = null)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (profile == null)
			{
				throw new ArgumentNullException("profile");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("Could not open the shader or effect file.", fileName);
			}
			return ShaderBytecode.Compile(File.ReadAllText(fileName), entryPoint, profile, shaderFlags, ShaderBytecode.PrepareMacros(defines), include);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001ADEC File Offset: 0x00018FEC
		public unsafe static CompilationResult Compile(byte[] shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags, Macro[] defines, Include include)
		{
			Result resultCode = Result.Ok;
			Blob blob = null;
			Blob blob2 = null;
			ConstantTable constantTable = null;
			try
			{
				try
				{
					fixed (byte* ptr = &shaderSource[0])
					{
						void* value = (void*)ptr;
						D3DX9.CompileShader((IntPtr)value, shaderSource.Length, ShaderBytecode.PrepareMacros(defines), IncludeShadow.ToIntPtr(include), entryPoint, profile, (int)shaderFlags, out blob, out blob2, out constantTable);
					}
				}
				finally
				{
					byte* ptr = null;
				}
			}
			catch (SharpDXException ex)
			{
				if (blob2 == null)
				{
					throw;
				}
				resultCode = ex.ResultCode;
				if (Configuration.ThrowOnShaderCompileError)
				{
					throw new CompilationException(ex.ResultCode, Utilities.BlobToString(blob2));
				}
			}
			finally
			{
				if (constantTable != null)
				{
					constantTable.Dispose();
				}
			}
			return new CompilationResult((blob != null) ? new ShaderBytecode(blob) : null, resultCode, Utilities.BlobToString(blob2));
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001AEB8 File Offset: 0x000190B8
		public string Disassemble()
		{
			return this.Disassemble(false, null);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001AEC2 File Offset: 0x000190C2
		public string Disassemble(bool enableColorCode)
		{
			return this.Disassemble(enableColorCode, null);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001AECC File Offset: 0x000190CC
		public string Disassemble(bool enableColorCode, string comments)
		{
			Blob blob;
			D3DX9.DisassembleShader(this.BufferPointer, enableColorCode, comments, out blob);
			return Utilities.BlobToString(blob);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001AEF4 File Offset: 0x000190F4
		public DataStream FindComment(Format fourCC)
		{
			IntPtr userBuffer;
			int num;
			D3DX9.FindShaderComment(this.BufferPointer, (int)fourCC, out userBuffer, out num);
			return new DataStream(userBuffer, (long)num, true, true);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001AF1C File Offset: 0x0001911C
		public ShaderSemantic[] GetInputSemantics()
		{
			int num = 0;
			D3DX9.GetShaderInputSemantics(this.BufferPointer, null, ref num);
			if (num == 0)
			{
				return null;
			}
			ShaderSemantic[] array = new ShaderSemantic[num];
			D3DX9.GetShaderInputSemantics(this.BufferPointer, array, ref num);
			return array;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001AF54 File Offset: 0x00019154
		public ShaderSemantic[] GetOutputSemantics()
		{
			int num = 0;
			D3DX9.GetShaderOutputSemantics(this.BufferPointer, null, ref num);
			if (num == 0)
			{
				return null;
			}
			ShaderSemantic[] array = new ShaderSemantic[num];
			D3DX9.GetShaderOutputSemantics(this.BufferPointer, array, ref num);
			return array;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001AF8C File Offset: 0x0001918C
		public unsafe string[] GetSamplers()
		{
			int num = 0;
			D3DX9.GetShaderSamplers(this.BufferPointer, IntPtr.Zero, ref num);
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			if (num < 1024)
			{
				IntPtr* ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)num) * (UIntPtr)sizeof(IntPtr))];
				D3DX9.GetShaderSamplers(this.BufferPointer, (IntPtr)((void*)ptr), ref num);
				for (int i = 0; i < num; i++)
				{
					array[i] = Marshal.PtrToStringAnsi(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				}
			}
			else
			{
				IntPtr[] array2 = new IntPtr[num];
				IntPtr[] array3;
				void* value;
				if ((array3 = array2) == null || array3.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array3[0]);
				}
				D3DX9.GetShaderSamplers(this.BufferPointer, (IntPtr)value, ref num);
				array3 = null;
				for (int j = 0; j < num; j++)
				{
					array[j] = Marshal.PtrToStringAnsi(array2[j]);
				}
			}
			return array;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001B05E File Offset: 0x0001925E
		public static int MajorVersion(int version)
		{
			return version >> 8 & 255;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001B069 File Offset: 0x00019269
		public static int MinorVersion(int version)
		{
			return version & 255;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001B072 File Offset: 0x00019272
		public static Version ParseVersion(int version)
		{
			return new Version(version >> 8 & 255, version & 255);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001B089 File Offset: 0x00019289
		public static ShaderBytecode Load(Stream stream)
		{
			return new ShaderBytecode(Utilities.ReadStream(stream));
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001B098 File Offset: 0x00019298
		public void Save(string fileName)
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				this.Save(fileStream);
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001B0D4 File Offset: 0x000192D4
		public void Save(Stream stream)
		{
			if (this.BufferSize == 0)
			{
				return;
			}
			byte[] array = new byte[this.BufferSize];
			Utilities.Read<byte>(this.BufferPointer, array, 0, array.Length);
			stream.Write(array, 0, array.Length);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001B122 File Offset: 0x00019322
		public static ShaderBytecode FromPointer(IntPtr pointer)
		{
			return new ShaderBytecode(new Blob(pointer));
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001B130 File Offset: 0x00019330
		public static string Preprocess(string shaderSource, Macro[] defines = null, Include include = null)
		{
			string text = null;
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
			string result;
			try
			{
				result = ShaderBytecode.Preprocess(intPtr, shaderSource.Length, defines, include, out text);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			return result;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001B194 File Offset: 0x00019394
		public static string Preprocess(byte[] shaderSource, Macro[] defines = null, Include include = null)
		{
			string text = null;
			return ShaderBytecode.Preprocess(shaderSource, defines, include, out text);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001B1B0 File Offset: 0x000193B0
		public unsafe static string Preprocess(byte[] shaderSource, Macro[] defines, Include include, out string compilationErrors)
		{
			fixed (byte* ptr = &shaderSource[0])
			{
				void* value = (void*)ptr;
				return ShaderBytecode.Preprocess((IntPtr)value, shaderSource.Length, defines, include, out compilationErrors);
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001B1DC File Offset: 0x000193DC
		public static string Preprocess(IntPtr shaderSourcePtr, int shaderSourceLength, Macro[] defines, Include include, out string compilationErrors)
		{
			Blob blob = null;
			Blob blob2 = null;
			compilationErrors = null;
			try
			{
				D3DX9.PreprocessShader(shaderSourcePtr, shaderSourceLength, ShaderBytecode.PrepareMacros(defines), IncludeShadow.ToIntPtr(include), out blob, out blob2);
			}
			catch (SharpDXException ex)
			{
				if (blob2 != null)
				{
					compilationErrors = Utilities.BlobToString(blob2);
					throw new CompilationException(ex.ResultCode, compilationErrors);
				}
				throw;
			}
			return Utilities.BlobToString(blob);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001B240 File Offset: 0x00019440
		public static string Preprocess(string shaderSource, Macro[] defines, Include include, out string compilationErrors)
		{
			if (string.IsNullOrEmpty(shaderSource))
			{
				throw new ArgumentNullException("shaderSource");
			}
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
			string result;
			try
			{
				result = ShaderBytecode.Preprocess(intPtr, shaderSource.Length, defines, include, out compilationErrors);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			return result;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001B2A0 File Offset: 0x000194A0
		public static string PreprocessFromFile(string fileName)
		{
			string text = null;
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("Could not open the shader or effect file.", fileName);
			}
			string text2 = File.ReadAllText(fileName);
			if (string.IsNullOrEmpty(text2))
			{
				throw new ArgumentNullException("fileName");
			}
			return ShaderBytecode.Preprocess(Encoding.ASCII.GetBytes(text2), null, null, out text);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001B300 File Offset: 0x00019500
		public static string PreprocessFromFile(string fileName, Macro[] defines, Include include)
		{
			string text = null;
			return ShaderBytecode.PreprocessFromFile(fileName, defines, include, out text);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001B319 File Offset: 0x00019519
		public static string PreprocessFromFile(string fileName, Macro[] defines, Include include, out string compilationErrors)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("Could not open the shader or effect file.", fileName);
			}
			return ShaderBytecode.Preprocess(File.ReadAllText(fileName), defines, include, out compilationErrors);
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x0001B34B File Offset: 0x0001954B
		public DataStream Data
		{
			get
			{
				return new DataStream(this.BufferPointer, this.BufferSize, true, true);
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001B365 File Offset: 0x00019565
		public static ShaderBytecode FromStream(Stream stream)
		{
			return new ShaderBytecode(stream);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001B36D File Offset: 0x0001956D
		public static ShaderBytecode FromFile(string fileName)
		{
			return new ShaderBytecode(File.ReadAllBytes(fileName));
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001B37C File Offset: 0x0001957C
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

		// Token: 0x060007B0 RID: 1968 RVA: 0x0001B3E0 File Offset: 0x000195E0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.blob != null)
				{
					this.blob.Dispose();
					this.blob = null;
				}
				if (this.constantTable != null)
				{
					this.constantTable.Dispose();
					this.constantTable = null;
				}
			}
			if (this.isOwner && this.BufferPointer != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.BufferPointer);
				this.BufferPointer = IntPtr.Zero;
				this.BufferSize = 0;
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001B460 File Offset: 0x00019660
		private unsafe void CreateFromBuffer(byte[] buffer)
		{
			fixed (byte* ptr = &buffer[0])
			{
				void* value = (void*)ptr;
				this.CreateFromPointer((IntPtr)value, buffer.Length);
			}
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0001B48A File Offset: 0x0001968A
		private void CreateFromPointer(IntPtr buffer, int sizeInBytes)
		{
			this.BufferPointer = Marshal.AllocHGlobal(sizeInBytes);
			this.BufferSize = sizeInBytes;
			this.isOwner = true;
			Utilities.CopyMemory(this.BufferPointer, buffer, sizeInBytes);
		}

		// Token: 0x04000E9A RID: 3738
		private bool isOwner;

		// Token: 0x04000E9B RID: 3739
		private Blob blob;

		// Token: 0x04000E9C RID: 3740
		private ConstantTable constantTable;
	}
}
