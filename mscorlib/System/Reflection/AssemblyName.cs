using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Reflection
{
	/// <summary>Describes an assembly's unique identity in full.</summary>
	// Token: 0x0200059A RID: 1434
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_AssemblyName))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class AssemblyName : _AssemblyName, ICloneable, ISerializable, IDeserializationCallback
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyName" /> class.</summary>
		// Token: 0x0600435E RID: 17246 RVA: 0x000F7B7F File Offset: 0x000F5D7F
		[__DynamicallyInvokable]
		public AssemblyName()
		{
			this._HashAlgorithm = AssemblyHashAlgorithm.None;
			this._VersionCompatibility = AssemblyVersionCompatibility.SameMachine;
			this._Flags = AssemblyNameFlags.None;
		}

		/// <summary>Gets or sets the simple name of the assembly. This is usually, but not necessarily, the file name of the manifest file of the assembly, minus its extension.</summary>
		/// <returns>The simple name of the assembly.</returns>
		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x0600435F RID: 17247 RVA: 0x000F7B9C File Offset: 0x000F5D9C
		// (set) Token: 0x06004360 RID: 17248 RVA: 0x000F7BA4 File Offset: 0x000F5DA4
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this._Name;
			}
			[__DynamicallyInvokable]
			set
			{
				this._Name = value;
			}
		}

		/// <summary>Gets or sets the major, minor, build, and revision numbers of the assembly.</summary>
		/// <returns>An object that represents the major, minor, build, and revision numbers of the assembly.</returns>
		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06004361 RID: 17249 RVA: 0x000F7BAD File Offset: 0x000F5DAD
		// (set) Token: 0x06004362 RID: 17250 RVA: 0x000F7BB5 File Offset: 0x000F5DB5
		[__DynamicallyInvokable]
		public Version Version
		{
			[__DynamicallyInvokable]
			get
			{
				return this._Version;
			}
			[__DynamicallyInvokable]
			set
			{
				this._Version = value;
			}
		}

		/// <summary>Gets or sets the culture supported by the assembly.</summary>
		/// <returns>An object that represents the culture supported by the assembly.</returns>
		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06004363 RID: 17251 RVA: 0x000F7BBE File Offset: 0x000F5DBE
		// (set) Token: 0x06004364 RID: 17252 RVA: 0x000F7BC6 File Offset: 0x000F5DC6
		[__DynamicallyInvokable]
		public CultureInfo CultureInfo
		{
			[__DynamicallyInvokable]
			get
			{
				return this._CultureInfo;
			}
			[__DynamicallyInvokable]
			set
			{
				this._CultureInfo = value;
			}
		}

		/// <summary>Gets or sets the name of the culture associated with the assembly.</summary>
		/// <returns>The culture name.</returns>
		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06004365 RID: 17253 RVA: 0x000F7BCF File Offset: 0x000F5DCF
		// (set) Token: 0x06004366 RID: 17254 RVA: 0x000F7BE6 File Offset: 0x000F5DE6
		[__DynamicallyInvokable]
		public string CultureName
		{
			[__DynamicallyInvokable]
			get
			{
				if (this._CultureInfo != null)
				{
					return this._CultureInfo.Name;
				}
				return null;
			}
			[__DynamicallyInvokable]
			set
			{
				this._CultureInfo = ((value == null) ? null : new CultureInfo(value));
			}
		}

		/// <summary>Gets or sets the location of the assembly as a URL.</summary>
		/// <returns>A string that is the URL location of the assembly.</returns>
		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06004367 RID: 17255 RVA: 0x000F7BFA File Offset: 0x000F5DFA
		// (set) Token: 0x06004368 RID: 17256 RVA: 0x000F7C02 File Offset: 0x000F5E02
		public string CodeBase
		{
			get
			{
				return this._CodeBase;
			}
			set
			{
				this._CodeBase = value;
			}
		}

		/// <summary>Gets the URI, including escape characters, that represents the codebase.</summary>
		/// <returns>A URI with escape characters.</returns>
		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06004369 RID: 17257 RVA: 0x000F7C0B File Offset: 0x000F5E0B
		public string EscapedCodeBase
		{
			[SecuritySafeCritical]
			get
			{
				if (this._CodeBase == null)
				{
					return null;
				}
				return AssemblyName.EscapeCodeBase(this._CodeBase);
			}
		}

		/// <summary>Gets or sets a value that identifies the processor and bits-per-word of the platform targeted by an executable.</summary>
		/// <returns>One of the enumeration values that identifies the processor and bits-per-word of the platform targeted by an executable.</returns>
		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x0600436A RID: 17258 RVA: 0x000F7C24 File Offset: 0x000F5E24
		// (set) Token: 0x0600436B RID: 17259 RVA: 0x000F7C44 File Offset: 0x000F5E44
		[__DynamicallyInvokable]
		public ProcessorArchitecture ProcessorArchitecture
		{
			[__DynamicallyInvokable]
			get
			{
				int num = (int)((this._Flags & (AssemblyNameFlags)112) >> 4);
				if (num > 5)
				{
					num = 0;
				}
				return (ProcessorArchitecture)num;
			}
			[__DynamicallyInvokable]
			set
			{
				int num = (int)(value & (ProcessorArchitecture)7);
				if (num <= 5)
				{
					this._Flags = (AssemblyNameFlags)((long)this._Flags & (long)((ulong)-241));
					this._Flags |= (AssemblyNameFlags)(num << 4);
				}
			}
		}

		/// <summary>Gets or sets a value that indicates what type of content the assembly contains.</summary>
		/// <returns>A value that indicates what type of content the assembly contains.</returns>
		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x0600436C RID: 17260 RVA: 0x000F7C80 File Offset: 0x000F5E80
		// (set) Token: 0x0600436D RID: 17261 RVA: 0x000F7CA4 File Offset: 0x000F5EA4
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public AssemblyContentType ContentType
		{
			[__DynamicallyInvokable]
			get
			{
				int num = (int)((this._Flags & (AssemblyNameFlags)3584) >> 9);
				if (num > 1)
				{
					num = 0;
				}
				return (AssemblyContentType)num;
			}
			[__DynamicallyInvokable]
			set
			{
				int num = (int)(value & (AssemblyContentType)7);
				if (num <= 1)
				{
					this._Flags = (AssemblyNameFlags)((long)this._Flags & (long)((ulong)-3585));
					this._Flags |= (AssemblyNameFlags)(num << 9);
				}
			}
		}

		/// <summary>Makes a copy of this <see cref="T:System.Reflection.AssemblyName" /> object.</summary>
		/// <returns>An object that is a copy of this <see cref="T:System.Reflection.AssemblyName" /> object.</returns>
		// Token: 0x0600436E RID: 17262 RVA: 0x000F7CE0 File Offset: 0x000F5EE0
		public object Clone()
		{
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Init(this._Name, this._PublicKey, this._PublicKeyToken, this._Version, this._CultureInfo, this._HashAlgorithm, this._VersionCompatibility, this._CodeBase, this._Flags, this._StrongNameKeyPair);
			assemblyName._HashForControl = this._HashForControl;
			assemblyName._HashAlgorithmForControl = this._HashAlgorithmForControl;
			return assemblyName;
		}

		/// <summary>Gets the <see cref="T:System.Reflection.AssemblyName" /> for a given file.</summary>
		/// <param name="assemblyFile">The path for the assembly whose <see cref="T:System.Reflection.AssemblyName" /> is to be returned.</param>
		/// <returns>An object that represents the given assembly file.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="assemblyFile" /> is invalid, such as an assembly with an invalid culture.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have path discovery permission.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly.</exception>
		/// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different sets of evidence.</exception>
		// Token: 0x0600436F RID: 17263 RVA: 0x000F7D50 File Offset: 0x000F5F50
		[SecuritySafeCritical]
		public static AssemblyName GetAssemblyName(string assemblyFile)
		{
			if (assemblyFile == null)
			{
				throw new ArgumentNullException("assemblyFile");
			}
			string fullPathInternal = Path.GetFullPathInternal(assemblyFile);
			new FileIOPermission(FileIOPermissionAccess.PathDiscovery, fullPathInternal).Demand();
			return AssemblyName.nGetFileInformation(fullPathInternal);
		}

		// Token: 0x06004370 RID: 17264 RVA: 0x000F7D84 File Offset: 0x000F5F84
		internal void SetHashControl(byte[] hash, AssemblyHashAlgorithm hashAlgorithm)
		{
			this._HashForControl = hash;
			this._HashAlgorithmForControl = hashAlgorithm;
		}

		/// <summary>Gets the public key of the assembly.</summary>
		/// <returns>A byte array that contains the public key of the assembly.</returns>
		/// <exception cref="T:System.Security.SecurityException">A public key was provided (for example, by using the <see cref="M:System.Reflection.AssemblyName.SetPublicKey(System.Byte[])" /> method), but no public key token was provided.</exception>
		// Token: 0x06004371 RID: 17265 RVA: 0x000F7D94 File Offset: 0x000F5F94
		[__DynamicallyInvokable]
		public byte[] GetPublicKey()
		{
			return this._PublicKey;
		}

		/// <summary>Sets the public key identifying the assembly.</summary>
		/// <param name="publicKey">A byte array containing the public key of the assembly.</param>
		// Token: 0x06004372 RID: 17266 RVA: 0x000F7D9C File Offset: 0x000F5F9C
		[__DynamicallyInvokable]
		public void SetPublicKey(byte[] publicKey)
		{
			this._PublicKey = publicKey;
			if (publicKey == null)
			{
				this._Flags &= ~AssemblyNameFlags.PublicKey;
				return;
			}
			this._Flags |= AssemblyNameFlags.PublicKey;
		}

		/// <summary>Gets the public key token, which is the last 8 bytes of the SHA-1 hash of the public key under which the application or assembly is signed.</summary>
		/// <returns>A byte array that contains the public key token.</returns>
		// Token: 0x06004373 RID: 17267 RVA: 0x000F7DC6 File Offset: 0x000F5FC6
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public byte[] GetPublicKeyToken()
		{
			if (this._PublicKeyToken == null)
			{
				this._PublicKeyToken = this.nGetPublicKeyToken();
			}
			return this._PublicKeyToken;
		}

		/// <summary>Sets the public key token, which is the last 8 bytes of the SHA-1 hash of the public key under which the application or assembly is signed.</summary>
		/// <param name="publicKeyToken">A byte array containing the public key token of the assembly.</param>
		// Token: 0x06004374 RID: 17268 RVA: 0x000F7DE2 File Offset: 0x000F5FE2
		[__DynamicallyInvokable]
		public void SetPublicKeyToken(byte[] publicKeyToken)
		{
			this._PublicKeyToken = publicKeyToken;
		}

		/// <summary>Gets or sets the attributes of the assembly.</summary>
		/// <returns>A value that represents the attributes of the assembly.</returns>
		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x06004375 RID: 17269 RVA: 0x000F7DEB File Offset: 0x000F5FEB
		// (set) Token: 0x06004376 RID: 17270 RVA: 0x000F7DF9 File Offset: 0x000F5FF9
		[__DynamicallyInvokable]
		public AssemblyNameFlags Flags
		{
			[__DynamicallyInvokable]
			get
			{
				return this._Flags & (AssemblyNameFlags)(-3825);
			}
			[__DynamicallyInvokable]
			set
			{
				this._Flags &= (AssemblyNameFlags)3824;
				this._Flags |= (value & (AssemblyNameFlags)(-3825));
			}
		}

		/// <summary>Gets or sets the hash algorithm used by the assembly manifest.</summary>
		/// <returns>The hash algorithm used by the assembly manifest.</returns>
		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06004377 RID: 17271 RVA: 0x000F7E21 File Offset: 0x000F6021
		// (set) Token: 0x06004378 RID: 17272 RVA: 0x000F7E29 File Offset: 0x000F6029
		public AssemblyHashAlgorithm HashAlgorithm
		{
			get
			{
				return this._HashAlgorithm;
			}
			set
			{
				this._HashAlgorithm = value;
			}
		}

		/// <summary>Gets or sets the information related to the assembly's compatibility with other assemblies.</summary>
		/// <returns>A value that represents information about the assembly's compatibility with other assemblies.</returns>
		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06004379 RID: 17273 RVA: 0x000F7E32 File Offset: 0x000F6032
		// (set) Token: 0x0600437A RID: 17274 RVA: 0x000F7E3A File Offset: 0x000F603A
		public AssemblyVersionCompatibility VersionCompatibility
		{
			get
			{
				return this._VersionCompatibility;
			}
			set
			{
				this._VersionCompatibility = value;
			}
		}

		/// <summary>Gets or sets the public and private cryptographic key pair that is used to create a strong name signature for the assembly.</summary>
		/// <returns>The public and private cryptographic key pair to be used to create a strong name for the assembly.</returns>
		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x0600437B RID: 17275 RVA: 0x000F7E43 File Offset: 0x000F6043
		// (set) Token: 0x0600437C RID: 17276 RVA: 0x000F7E4B File Offset: 0x000F604B
		public StrongNameKeyPair KeyPair
		{
			get
			{
				return this._StrongNameKeyPair;
			}
			set
			{
				this._StrongNameKeyPair = value;
			}
		}

		/// <summary>Gets the full name of the assembly, also known as the display name.</summary>
		/// <returns>A string that is the full name of the assembly, also known as the display name.</returns>
		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x0600437D RID: 17277 RVA: 0x000F7E54 File Offset: 0x000F6054
		[__DynamicallyInvokable]
		public string FullName
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				string text = this.nToString();
				if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8 && string.IsNullOrEmpty(text))
				{
					return base.ToString();
				}
				return text;
			}
		}

		/// <summary>Returns the full name of the assembly, also known as the display name.</summary>
		/// <returns>The full name of the assembly, or the class name if the full name cannot be determined.</returns>
		// Token: 0x0600437E RID: 17278 RVA: 0x000F7E80 File Offset: 0x000F6080
		[__DynamicallyInvokable]
		public override string ToString()
		{
			string fullName = this.FullName;
			if (fullName == null)
			{
				return base.ToString();
			}
			return fullName;
		}

		/// <summary>Gets serialization information with all the data needed to recreate an instance of this <see langword="AssemblyName" />.</summary>
		/// <param name="info">The object to be populated with serialization information.</param>
		/// <param name="context">The destination context of the serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x0600437F RID: 17279 RVA: 0x000F7EA0 File Offset: 0x000F60A0
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("_Name", this._Name);
			info.AddValue("_PublicKey", this._PublicKey, typeof(byte[]));
			info.AddValue("_PublicKeyToken", this._PublicKeyToken, typeof(byte[]));
			info.AddValue("_CultureInfo", (this._CultureInfo == null) ? -1 : this._CultureInfo.LCID);
			info.AddValue("_CodeBase", this._CodeBase);
			info.AddValue("_Version", this._Version);
			info.AddValue("_HashAlgorithm", this._HashAlgorithm, typeof(AssemblyHashAlgorithm));
			info.AddValue("_HashAlgorithmForControl", this._HashAlgorithmForControl, typeof(AssemblyHashAlgorithm));
			info.AddValue("_StrongNameKeyPair", this._StrongNameKeyPair, typeof(StrongNameKeyPair));
			info.AddValue("_VersionCompatibility", this._VersionCompatibility, typeof(AssemblyVersionCompatibility));
			info.AddValue("_Flags", this._Flags, typeof(AssemblyNameFlags));
			info.AddValue("_HashForControl", this._HashForControl, typeof(byte[]));
		}

		/// <summary>Implements the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface and is called back by the deserialization event when deserialization is complete.</summary>
		/// <param name="sender">The source of the deserialization event.</param>
		// Token: 0x06004380 RID: 17280 RVA: 0x000F7FFC File Offset: 0x000F61FC
		public void OnDeserialization(object sender)
		{
			if (this.m_siInfo == null)
			{
				return;
			}
			this._Name = this.m_siInfo.GetString("_Name");
			this._PublicKey = (byte[])this.m_siInfo.GetValue("_PublicKey", typeof(byte[]));
			this._PublicKeyToken = (byte[])this.m_siInfo.GetValue("_PublicKeyToken", typeof(byte[]));
			int @int = this.m_siInfo.GetInt32("_CultureInfo");
			if (@int != -1)
			{
				this._CultureInfo = new CultureInfo(@int);
			}
			this._CodeBase = this.m_siInfo.GetString("_CodeBase");
			this._Version = (Version)this.m_siInfo.GetValue("_Version", typeof(Version));
			this._HashAlgorithm = (AssemblyHashAlgorithm)this.m_siInfo.GetValue("_HashAlgorithm", typeof(AssemblyHashAlgorithm));
			this._StrongNameKeyPair = (StrongNameKeyPair)this.m_siInfo.GetValue("_StrongNameKeyPair", typeof(StrongNameKeyPair));
			this._VersionCompatibility = (AssemblyVersionCompatibility)this.m_siInfo.GetValue("_VersionCompatibility", typeof(AssemblyVersionCompatibility));
			this._Flags = (AssemblyNameFlags)this.m_siInfo.GetValue("_Flags", typeof(AssemblyNameFlags));
			try
			{
				this._HashAlgorithmForControl = (AssemblyHashAlgorithm)this.m_siInfo.GetValue("_HashAlgorithmForControl", typeof(AssemblyHashAlgorithm));
				this._HashForControl = (byte[])this.m_siInfo.GetValue("_HashForControl", typeof(byte[]));
			}
			catch (SerializationException)
			{
				this._HashAlgorithmForControl = AssemblyHashAlgorithm.None;
				this._HashForControl = null;
			}
			this.m_siInfo = null;
		}

		// Token: 0x06004381 RID: 17281 RVA: 0x000F81D8 File Offset: 0x000F63D8
		internal AssemblyName(SerializationInfo info, StreamingContext context)
		{
			this.m_siInfo = info;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyName" /> class with the specified display name.</summary>
		/// <param name="assemblyName">The display name of the assembly, as returned by the <see cref="P:System.Reflection.AssemblyName.FullName" /> property.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="assemblyName" /> is a zero length string.</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///
		///
		///  The referenced assembly could not be found, or could not be loaded.</exception>
		// Token: 0x06004382 RID: 17282 RVA: 0x000F81E8 File Offset: 0x000F63E8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public AssemblyName(string assemblyName)
		{
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (assemblyName.Length == 0 || assemblyName[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Format_StringZeroLength"));
			}
			this._Name = assemblyName;
			this.nInit();
		}

		/// <summary>Returns a value indicating whether two assembly names are the same. The comparison is based on the simple assembly names.</summary>
		/// <param name="reference">The reference assembly name.</param>
		/// <param name="definition">The assembly name that is compared to the reference assembly.</param>
		/// <returns>
		///   <see langword="true" /> if the simple assembly names are the same; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004383 RID: 17283 RVA: 0x000F8237 File Offset: 0x000F6437
		[SecuritySafeCritical]
		public static bool ReferenceMatchesDefinition(AssemblyName reference, AssemblyName definition)
		{
			return reference == definition || AssemblyName.ReferenceMatchesDefinitionInternal(reference, definition, true);
		}

		// Token: 0x06004384 RID: 17284
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool ReferenceMatchesDefinitionInternal(AssemblyName reference, AssemblyName definition, bool parse);

		// Token: 0x06004385 RID: 17285
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void nInit(out RuntimeAssembly assembly, bool forIntrospection, bool raiseResolveEvent);

		// Token: 0x06004386 RID: 17286 RVA: 0x000F8248 File Offset: 0x000F6448
		[SecurityCritical]
		internal void nInit()
		{
			RuntimeAssembly runtimeAssembly = null;
			this.nInit(out runtimeAssembly, false, false);
		}

		// Token: 0x06004387 RID: 17287 RVA: 0x000F8261 File Offset: 0x000F6461
		internal void SetProcArchIndex(PortableExecutableKinds pek, ImageFileMachine ifm)
		{
			this.ProcessorArchitecture = AssemblyName.CalculateProcArchIndex(pek, ifm, this._Flags);
		}

		// Token: 0x06004388 RID: 17288 RVA: 0x000F8278 File Offset: 0x000F6478
		internal static ProcessorArchitecture CalculateProcArchIndex(PortableExecutableKinds pek, ImageFileMachine ifm, AssemblyNameFlags flags)
		{
			if ((flags & (AssemblyNameFlags)240) == (AssemblyNameFlags)112)
			{
				return ProcessorArchitecture.None;
			}
			if ((pek & PortableExecutableKinds.PE32Plus) == PortableExecutableKinds.PE32Plus)
			{
				if (ifm != ImageFileMachine.I386)
				{
					if (ifm == ImageFileMachine.IA64)
					{
						return ProcessorArchitecture.IA64;
					}
					if (ifm == ImageFileMachine.AMD64)
					{
						return ProcessorArchitecture.Amd64;
					}
				}
				else if ((pek & PortableExecutableKinds.ILOnly) == PortableExecutableKinds.ILOnly)
				{
					return ProcessorArchitecture.MSIL;
				}
			}
			else if (ifm == ImageFileMachine.I386)
			{
				if ((pek & PortableExecutableKinds.Required32Bit) == PortableExecutableKinds.Required32Bit)
				{
					return ProcessorArchitecture.X86;
				}
				if ((pek & PortableExecutableKinds.ILOnly) == PortableExecutableKinds.ILOnly)
				{
					return ProcessorArchitecture.MSIL;
				}
				return ProcessorArchitecture.X86;
			}
			else if (ifm == ImageFileMachine.ARM)
			{
				return ProcessorArchitecture.Arm;
			}
			return ProcessorArchitecture.None;
		}

		// Token: 0x06004389 RID: 17289 RVA: 0x000F82E4 File Offset: 0x000F64E4
		internal void Init(string name, byte[] publicKey, byte[] publicKeyToken, Version version, CultureInfo cultureInfo, AssemblyHashAlgorithm hashAlgorithm, AssemblyVersionCompatibility versionCompatibility, string codeBase, AssemblyNameFlags flags, StrongNameKeyPair keyPair)
		{
			this._Name = name;
			if (publicKey != null)
			{
				this._PublicKey = new byte[publicKey.Length];
				Array.Copy(publicKey, this._PublicKey, publicKey.Length);
			}
			if (publicKeyToken != null)
			{
				this._PublicKeyToken = new byte[publicKeyToken.Length];
				Array.Copy(publicKeyToken, this._PublicKeyToken, publicKeyToken.Length);
			}
			if (version != null)
			{
				this._Version = (Version)version.Clone();
			}
			this._CultureInfo = cultureInfo;
			this._HashAlgorithm = hashAlgorithm;
			this._VersionCompatibility = versionCompatibility;
			this._CodeBase = codeBase;
			this._Flags = flags;
			this._StrongNameKeyPair = keyPair;
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600438A RID: 17290 RVA: 0x000F8384 File Offset: 0x000F6584
		void _AssemblyName.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600438B RID: 17291 RVA: 0x000F838B File Offset: 0x000F658B
		void _AssemblyName.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array that receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600438C RID: 17292 RVA: 0x000F8392 File Offset: 0x000F6592
		void _AssemblyName.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DispIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600438D RID: 17293 RVA: 0x000F8399 File Offset: 0x000F6599
		void _AssemblyName.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600438E RID: 17294 RVA: 0x000F83A0 File Offset: 0x000F65A0
		internal string GetNameWithPublicKey()
		{
			byte[] publicKey = this.GetPublicKey();
			return this.Name + ", PublicKey=" + Hex.EncodeHexString(publicKey);
		}

		// Token: 0x0600438F RID: 17295
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AssemblyName nGetFileInformation(string s);

		// Token: 0x06004390 RID: 17296
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string nToString();

		// Token: 0x06004391 RID: 17297
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern byte[] nGetPublicKeyToken();

		// Token: 0x06004392 RID: 17298
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string EscapeCodeBase(string codeBase);

		// Token: 0x04001B57 RID: 6999
		private string _Name;

		// Token: 0x04001B58 RID: 7000
		private byte[] _PublicKey;

		// Token: 0x04001B59 RID: 7001
		private byte[] _PublicKeyToken;

		// Token: 0x04001B5A RID: 7002
		private CultureInfo _CultureInfo;

		// Token: 0x04001B5B RID: 7003
		private string _CodeBase;

		// Token: 0x04001B5C RID: 7004
		private Version _Version;

		// Token: 0x04001B5D RID: 7005
		private StrongNameKeyPair _StrongNameKeyPair;

		// Token: 0x04001B5E RID: 7006
		private SerializationInfo m_siInfo;

		// Token: 0x04001B5F RID: 7007
		private byte[] _HashForControl;

		// Token: 0x04001B60 RID: 7008
		private AssemblyHashAlgorithm _HashAlgorithm;

		// Token: 0x04001B61 RID: 7009
		private AssemblyHashAlgorithm _HashAlgorithmForControl;

		// Token: 0x04001B62 RID: 7010
		private AssemblyVersionCompatibility _VersionCompatibility;

		// Token: 0x04001B63 RID: 7011
		private AssemblyNameFlags _Flags;
	}
}
