using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000059 RID: 89
	[NullableContext(2)]
	[Nullable(0)]
	internal class FSharpFunction
	{
		// Token: 0x06000521 RID: 1313 RVA: 0x000161A5 File Offset: 0x000143A5
		public FSharpFunction(object instance, [Nullable(new byte[]
		{
			1,
			2,
			1
		})] MethodCall<object, object> invoker)
		{
			this._instance = instance;
			this._invoker = invoker;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x000161BB File Offset: 0x000143BB
		[NullableContext(1)]
		public object Invoke(params object[] args)
		{
			return this._invoker(this._instance, args);
		}

		// Token: 0x040001CA RID: 458
		private readonly object _instance;

		// Token: 0x040001CB RID: 459
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		private readonly MethodCall<object, object> _invoker;
	}
}
