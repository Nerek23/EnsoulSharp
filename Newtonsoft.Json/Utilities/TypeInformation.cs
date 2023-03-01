﻿using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000047 RID: 71
	[NullableContext(1)]
	[Nullable(0)]
	internal class TypeInformation
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x00010F42 File Offset: 0x0000F142
		public Type Type { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00010F4A File Offset: 0x0000F14A
		public PrimitiveTypeCode TypeCode { get; }

		// Token: 0x06000466 RID: 1126 RVA: 0x00010F52 File Offset: 0x0000F152
		public TypeInformation(Type type, PrimitiveTypeCode typeCode)
		{
			this.Type = type;
			this.TypeCode = typeCode;
		}
	}
}
