using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200002B RID: 43
	public sealed class ResultDescriptor
	{
		// Token: 0x06000140 RID: 320 RVA: 0x00004593 File Offset: 0x00002793
		public ResultDescriptor(Result code, string module, string nativeApiCode, string apiCode, string description = null)
		{
			this.Result = code;
			this.Module = module;
			this.NativeApiCode = nativeApiCode;
			this.ApiCode = apiCode;
			this.Description = description;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000045C0 File Offset: 0x000027C0
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000045C8 File Offset: 0x000027C8
		public Result Result { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000143 RID: 323 RVA: 0x000045D4 File Offset: 0x000027D4
		public int Code
		{
			get
			{
				return this.Result.Code;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000144 RID: 324 RVA: 0x000045EF File Offset: 0x000027EF
		// (set) Token: 0x06000145 RID: 325 RVA: 0x000045F7 File Offset: 0x000027F7
		public string Module { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00004600 File Offset: 0x00002800
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00004608 File Offset: 0x00002808
		public string NativeApiCode { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00004611 File Offset: 0x00002811
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00004619 File Offset: 0x00002819
		public string ApiCode { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00004622 File Offset: 0x00002822
		// (set) Token: 0x0600014B RID: 331 RVA: 0x0000462A File Offset: 0x0000282A
		public string Description { get; set; }

		// Token: 0x0600014C RID: 332 RVA: 0x00004634 File Offset: 0x00002834
		public bool Equals(ResultDescriptor other)
		{
			return other != null && (this == other || other.Result.Equals(this.Result));
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004660 File Offset: 0x00002860
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != typeof(ResultDescriptor)) && this.Equals((ResultDescriptor)obj)));
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004694 File Offset: 0x00002894
		public override int GetHashCode()
		{
			return this.Result.GetHashCode();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000046B8 File Offset: 0x000028B8
		public override string ToString()
		{
			return string.Format("HRESULT: [0x{0:X}], Module: [{1}], ApiCode: [{2}/{3}], Message: {4}", new object[]
			{
				this.Result.Code,
				this.Module,
				this.NativeApiCode,
				this.ApiCode,
				this.Description
			});
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000470F File Offset: 0x0000290F
		public static implicit operator Result(ResultDescriptor result)
		{
			return result.Result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004718 File Offset: 0x00002918
		public static explicit operator int(ResultDescriptor result)
		{
			return result.Result.Code;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004734 File Offset: 0x00002934
		public static explicit operator uint(ResultDescriptor result)
		{
			return (uint)result.Result.Code;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004750 File Offset: 0x00002950
		public static bool operator ==(ResultDescriptor left, Result right)
		{
			return left != null && left.Result.Code == right.Code;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000477C File Offset: 0x0000297C
		public static bool operator !=(ResultDescriptor left, Result right)
		{
			return left != null && left.Result.Code != right.Code;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000047A8 File Offset: 0x000029A8
		public static void RegisterProvider(Type descriptorsProviderType)
		{
			object lockDescriptor = ResultDescriptor.LockDescriptor;
			lock (lockDescriptor)
			{
				if (!ResultDescriptor.RegisteredDescriptorProvider.Contains(descriptorsProviderType))
				{
					ResultDescriptor.RegisteredDescriptorProvider.Add(descriptorsProviderType);
				}
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000047FC File Offset: 0x000029FC
		public static ResultDescriptor Find(Result result)
		{
			object lockDescriptor = ResultDescriptor.LockDescriptor;
			ResultDescriptor resultDescriptor;
			lock (lockDescriptor)
			{
				if (ResultDescriptor.RegisteredDescriptorProvider.Count > 0)
				{
					foreach (Type type in ResultDescriptor.RegisteredDescriptorProvider)
					{
						ResultDescriptor.AddDescriptorsFromType(type);
					}
					ResultDescriptor.RegisteredDescriptorProvider.Clear();
				}
				if (!ResultDescriptor.Descriptors.TryGetValue(result, out resultDescriptor))
				{
					resultDescriptor = new ResultDescriptor(result, "Unknown", "Unknown", "Unknown", null);
				}
				if (resultDescriptor.Description == null)
				{
					string descriptionFromResultCode = ResultDescriptor.GetDescriptionFromResultCode(result.Code);
					resultDescriptor.Description = (descriptionFromResultCode ?? "Unknown");
				}
			}
			return resultDescriptor;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000048D8 File Offset: 0x00002AD8
		private static void AddDescriptorsFromType(Type type)
		{
			foreach (FieldInfo fieldInfo in type.GetTypeInfo().DeclaredFields)
			{
				if (fieldInfo.FieldType == typeof(ResultDescriptor) && fieldInfo.IsPublic && fieldInfo.IsStatic)
				{
					ResultDescriptor resultDescriptor = (ResultDescriptor)fieldInfo.GetValue(null);
					if (!ResultDescriptor.Descriptors.ContainsKey(resultDescriptor.Result))
					{
						ResultDescriptor.Descriptors.Add(resultDescriptor.Result, resultDescriptor);
					}
				}
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000497C File Offset: 0x00002B7C
		private static string GetDescriptionFromResultCode(int resultCode)
		{
			IntPtr zero = IntPtr.Zero;
			ResultDescriptor.FormatMessageW(4864, IntPtr.Zero, resultCode, 0, ref zero, 0, IntPtr.Zero);
			string result = Marshal.PtrToStringUni(zero);
			Marshal.FreeHGlobal(zero);
			return result;
		}

		// Token: 0x06000159 RID: 345
		[DllImport("kernel32.dll")]
		private static extern uint FormatMessageW(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, ref IntPtr lpBuffer, int nSize, IntPtr Arguments);

		// Token: 0x0400004A RID: 74
		private static readonly object LockDescriptor = new object();

		// Token: 0x0400004B RID: 75
		private static readonly List<Type> RegisteredDescriptorProvider = new List<Type>();

		// Token: 0x0400004C RID: 76
		private static readonly Dictionary<Result, ResultDescriptor> Descriptors = new Dictionary<Result, ResultDescriptor>();

		// Token: 0x0400004D RID: 77
		private const string UnknownText = "Unknown";
	}
}
