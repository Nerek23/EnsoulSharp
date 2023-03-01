using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000084 RID: 132
	[NullableContext(2)]
	[Nullable(0)]
	public class JsonContainerContract : JsonContract
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0001C466 File Offset: 0x0001A666
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x0001C46E File Offset: 0x0001A66E
		internal JsonContract ItemContract
		{
			get
			{
				return this._itemContract;
			}
			set
			{
				this._itemContract = value;
				if (this._itemContract != null)
				{
					this._finalItemContract = (this._itemContract.UnderlyingType.IsSealed() ? this._itemContract : null);
					return;
				}
				this._finalItemContract = null;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0001C4A8 File Offset: 0x0001A6A8
		internal JsonContract FinalItemContract
		{
			get
			{
				return this._finalItemContract;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x0001C4B0 File Offset: 0x0001A6B0
		// (set) Token: 0x06000699 RID: 1689 RVA: 0x0001C4B8 File Offset: 0x0001A6B8
		public JsonConverter ItemConverter { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0001C4C1 File Offset: 0x0001A6C1
		// (set) Token: 0x0600069B RID: 1691 RVA: 0x0001C4C9 File Offset: 0x0001A6C9
		public bool? ItemIsReference { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0001C4D2 File Offset: 0x0001A6D2
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x0001C4DA File Offset: 0x0001A6DA
		public ReferenceLoopHandling? ItemReferenceLoopHandling { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0001C4E3 File Offset: 0x0001A6E3
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x0001C4EB File Offset: 0x0001A6EB
		public TypeNameHandling? ItemTypeNameHandling { get; set; }

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		[NullableContext(1)]
		internal JsonContainerContract(Type underlyingType) : base(underlyingType)
		{
			JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(underlyingType);
			if (cachedAttribute != null)
			{
				if (cachedAttribute.ItemConverterType != null)
				{
					this.ItemConverter = JsonTypeReflector.CreateJsonConverterInstance(cachedAttribute.ItemConverterType, cachedAttribute.ItemConverterParameters);
				}
				this.ItemIsReference = cachedAttribute._itemIsReference;
				this.ItemReferenceLoopHandling = cachedAttribute._itemReferenceLoopHandling;
				this.ItemTypeNameHandling = cachedAttribute._itemTypeNameHandling;
			}
		}

		// Token: 0x0400023D RID: 573
		private JsonContract _itemContract;

		// Token: 0x0400023E RID: 574
		private JsonContract _finalItemContract;
	}
}
