using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200008E RID: 142
	public class JsonISerializableContract : JsonContainerContract
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x0001D01D File Offset: 0x0001B21D
		// (set) Token: 0x060006F7 RID: 1783 RVA: 0x0001D025 File Offset: 0x0001B225
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public ObjectConstructor<object> ISerializableCreator { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x060006F8 RID: 1784 RVA: 0x0001D02E File Offset: 0x0001B22E
		[NullableContext(1)]
		public JsonISerializableContract(Type underlyingType) : base(underlyingType)
		{
			this.ContractType = JsonContractType.Serializable;
		}
	}
}
