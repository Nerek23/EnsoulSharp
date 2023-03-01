using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200008B RID: 139
	[NullableContext(2)]
	[Nullable(0)]
	public class JsonDictionaryContract : JsonContainerContract
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0001C932 File Offset: 0x0001AB32
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0001C93A File Offset: 0x0001AB3A
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Func<string, string> DictionaryKeyResolver { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x0001C943 File Offset: 0x0001AB43
		public Type DictionaryKeyType { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x0001C94B File Offset: 0x0001AB4B
		public Type DictionaryValueType { get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x0001C953 File Offset: 0x0001AB53
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x0001C95B File Offset: 0x0001AB5B
		internal JsonContract KeyContract { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0001C964 File Offset: 0x0001AB64
		internal bool ShouldCreateWrapper { get; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x0001C96C File Offset: 0x0001AB6C
		[Nullable(new byte[]
		{
			2,
			1
		})]
		internal ObjectConstructor<object> ParameterizedCreator
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				if (this._parameterizedCreator == null && this._parameterizedConstructor != null)
				{
					this._parameterizedCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(this._parameterizedConstructor);
				}
				return this._parameterizedCreator;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001C9A0 File Offset: 0x0001ABA0
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x0001C9A8 File Offset: 0x0001ABA8
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public ObjectConstructor<object> OverrideCreator
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return this._overrideCreator;
			}
			[param: Nullable(new byte[]
			{
				2,
				1
			})]
			set
			{
				this._overrideCreator = value;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0001C9B1 File Offset: 0x0001ABB1
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x0001C9B9 File Offset: 0x0001ABB9
		public bool HasParameterizedCreator { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001C9C2 File Offset: 0x0001ABC2
		internal bool HasParameterizedCreatorInternal
		{
			get
			{
				return this.HasParameterizedCreator || this._parameterizedCreator != null || this._parameterizedConstructor != null;
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
		[NullableContext(1)]
		public JsonDictionaryContract(Type underlyingType) : base(underlyingType)
		{
			this.ContractType = JsonContractType.Dictionary;
			Type type;
			Type type2;
			if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(IDictionary<, >), out this._genericCollectionDefinitionType))
			{
				type = this._genericCollectionDefinitionType.GetGenericArguments()[0];
				type2 = this._genericCollectionDefinitionType.GetGenericArguments()[1];
				if (ReflectionUtils.IsGenericDefinition(base.UnderlyingType, typeof(IDictionary<, >)))
				{
					base.CreatedType = typeof(Dictionary<, >).MakeGenericType(new Type[]
					{
						type,
						type2
					});
				}
				else if (underlyingType.IsGenericType() && underlyingType.GetGenericTypeDefinition().FullName == "System.Collections.Concurrent.ConcurrentDictionary`2")
				{
					this.ShouldCreateWrapper = 1;
				}
				this.IsReadOnlyOrFixedSize = ReflectionUtils.InheritsGenericDefinition(underlyingType, typeof(ReadOnlyDictionary<, >));
			}
			else if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(IReadOnlyDictionary<, >), out this._genericCollectionDefinitionType))
			{
				type = this._genericCollectionDefinitionType.GetGenericArguments()[0];
				type2 = this._genericCollectionDefinitionType.GetGenericArguments()[1];
				if (ReflectionUtils.IsGenericDefinition(base.UnderlyingType, typeof(IReadOnlyDictionary<, >)))
				{
					base.CreatedType = typeof(ReadOnlyDictionary<, >).MakeGenericType(new Type[]
					{
						type,
						type2
					});
				}
				this.IsReadOnlyOrFixedSize = true;
			}
			else
			{
				ReflectionUtils.GetDictionaryKeyValueTypes(base.UnderlyingType, out type, out type2);
				if (base.UnderlyingType == typeof(IDictionary))
				{
					base.CreatedType = typeof(Dictionary<object, object>);
				}
			}
			if (type != null && type2 != null)
			{
				this._parameterizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(base.CreatedType, typeof(KeyValuePair<, >).MakeGenericType(new Type[]
				{
					type,
					type2
				}), typeof(IDictionary<, >).MakeGenericType(new Type[]
				{
					type,
					type2
				}));
				if (!this.HasParameterizedCreatorInternal && underlyingType.Name == "FSharpMap`2")
				{
					FSharpUtils.EnsureInitialized(underlyingType.Assembly());
					this._parameterizedCreator = FSharpUtils.Instance.CreateMap(type, type2);
				}
			}
			if (!typeof(IDictionary).IsAssignableFrom(base.CreatedType))
			{
				this.ShouldCreateWrapper = 1;
			}
			this.DictionaryKeyType = type;
			this.DictionaryValueType = type2;
			Type createdType;
			ObjectConstructor<object> parameterizedCreator;
			if (this.DictionaryKeyType != null && this.DictionaryValueType != null && ImmutableCollectionsUtils.TryBuildImmutableForDictionaryContract(underlyingType, this.DictionaryKeyType, this.DictionaryValueType, out createdType, out parameterizedCreator))
			{
				base.CreatedType = createdType;
				this._parameterizedCreator = parameterizedCreator;
				this.IsReadOnlyOrFixedSize = true;
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0001CC70 File Offset: 0x0001AE70
		[NullableContext(1)]
		internal IWrappedDictionary CreateWrapper(object dictionary)
		{
			if (this._genericWrapperCreator == null)
			{
				this._genericWrapperType = typeof(DictionaryWrapper<, >).MakeGenericType(new Type[]
				{
					this.DictionaryKeyType,
					this.DictionaryValueType
				});
				ConstructorInfo constructor = this._genericWrapperType.GetConstructor(new Type[]
				{
					this._genericCollectionDefinitionType
				});
				this._genericWrapperCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(constructor);
			}
			return (IWrappedDictionary)this._genericWrapperCreator(new object[]
			{
				dictionary
			});
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001CCF8 File Offset: 0x0001AEF8
		[NullableContext(1)]
		internal IDictionary CreateTemporaryDictionary()
		{
			if (this._genericTemporaryDictionaryCreator == null)
			{
				Type type = typeof(Dictionary<, >).MakeGenericType(new Type[]
				{
					this.DictionaryKeyType ?? typeof(object),
					this.DictionaryValueType ?? typeof(object)
				});
				this._genericTemporaryDictionaryCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type);
			}
			return (IDictionary)this._genericTemporaryDictionaryCreator();
		}

		// Token: 0x04000266 RID: 614
		private readonly Type _genericCollectionDefinitionType;

		// Token: 0x04000267 RID: 615
		private Type _genericWrapperType;

		// Token: 0x04000268 RID: 616
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ObjectConstructor<object> _genericWrapperCreator;

		// Token: 0x04000269 RID: 617
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<object> _genericTemporaryDictionaryCreator;

		// Token: 0x0400026B RID: 619
		private readonly ConstructorInfo _parameterizedConstructor;

		// Token: 0x0400026C RID: 620
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ObjectConstructor<object> _overrideCreator;

		// Token: 0x0400026D RID: 621
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ObjectConstructor<object> _parameterizedCreator;
	}
}
