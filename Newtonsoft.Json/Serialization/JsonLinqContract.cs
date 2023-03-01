﻿using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200008F RID: 143
	public class JsonLinqContract : JsonContract
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x0001D03E File Offset: 0x0001B23E
		[NullableContext(1)]
		public JsonLinqContract(Type underlyingType) : base(underlyingType)
		{
			this.ContractType = JsonContractType.Linq;
		}
	}
}
