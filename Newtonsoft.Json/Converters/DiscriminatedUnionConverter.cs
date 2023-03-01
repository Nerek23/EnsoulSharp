using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000E3 RID: 227
	[NullableContext(1)]
	[Nullable(0)]
	public class DiscriminatedUnionConverter : JsonConverter
	{
		// Token: 0x06000C36 RID: 3126 RVA: 0x000312AC File Offset: 0x0002F4AC
		private static Type CreateUnionTypeLookup(Type t)
		{
			MethodCall<object, object> getUnionCases = FSharpUtils.Instance.GetUnionCases;
			object target = null;
			object[] array = new object[2];
			array[0] = t;
			object arg = ((object[])getUnionCases(target, array)).First<object>();
			return (Type)FSharpUtils.Instance.GetUnionCaseInfoDeclaringType(arg);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x000312F4 File Offset: 0x0002F4F4
		private static DiscriminatedUnionConverter.Union CreateUnion(Type t)
		{
			MethodCall<object, object> preComputeUnionTagReader = FSharpUtils.Instance.PreComputeUnionTagReader;
			object target = null;
			object[] array = new object[2];
			array[0] = t;
			DiscriminatedUnionConverter.Union union = new DiscriminatedUnionConverter.Union((FSharpFunction)preComputeUnionTagReader(target, array), new List<DiscriminatedUnionConverter.UnionCase>());
			MethodCall<object, object> getUnionCases = FSharpUtils.Instance.GetUnionCases;
			object target2 = null;
			object[] array2 = new object[2];
			array2[0] = t;
			foreach (object obj in (object[])getUnionCases(target2, array2))
			{
				int tag = (int)FSharpUtils.Instance.GetUnionCaseInfoTag(obj);
				string name = (string)FSharpUtils.Instance.GetUnionCaseInfoName(obj);
				PropertyInfo[] fields = (PropertyInfo[])FSharpUtils.Instance.GetUnionCaseInfoFields(obj, new object[0]);
				MethodCall<object, object> preComputeUnionReader = FSharpUtils.Instance.PreComputeUnionReader;
				object target3 = null;
				object[] array4 = new object[2];
				array4[0] = obj;
				FSharpFunction fieldReader = (FSharpFunction)preComputeUnionReader(target3, array4);
				MethodCall<object, object> preComputeUnionConstructor = FSharpUtils.Instance.PreComputeUnionConstructor;
				object target4 = null;
				object[] array5 = new object[2];
				array5[0] = obj;
				DiscriminatedUnionConverter.UnionCase item = new DiscriminatedUnionConverter.UnionCase(tag, name, fields, fieldReader, (FSharpFunction)preComputeUnionConstructor(target4, array5));
				union.Cases.Add(item);
			}
			return union;
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x000313FC File Offset: 0x0002F5FC
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}
			DefaultContractResolver defaultContractResolver = serializer.ContractResolver as DefaultContractResolver;
			Type key = DiscriminatedUnionConverter.UnionTypeLookupCache.Get(value.GetType());
			DiscriminatedUnionConverter.Union union = DiscriminatedUnionConverter.UnionCache.Get(key);
			int tag = (int)union.TagReader.Invoke(new object[]
			{
				value
			});
			DiscriminatedUnionConverter.UnionCase unionCase = union.Cases.Single((DiscriminatedUnionConverter.UnionCase c) => c.Tag == tag);
			writer.WriteStartObject();
			writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Case") : "Case");
			writer.WriteValue(unionCase.Name);
			if (unionCase.Fields != null && unionCase.Fields.Length != 0)
			{
				object[] array = (object[])unionCase.FieldReader.Invoke(new object[]
				{
					value
				});
				writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Fields") : "Fields");
				writer.WriteStartArray();
				foreach (object value2 in array)
				{
					serializer.Serialize(writer, value2);
				}
				writer.WriteEndArray();
			}
			writer.WriteEndObject();
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0003152C File Offset: 0x0002F72C
		[return: Nullable(2)]
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			DiscriminatedUnionConverter.UnionCase unionCase = null;
			string caseName = null;
			JArray jarray = null;
			reader.ReadAndAssert();
			Func<DiscriminatedUnionConverter.UnionCase, bool> <>9__0;
			while (reader.TokenType == JsonToken.PropertyName)
			{
				string text = reader.Value.ToString();
				if (string.Equals(text, "Case", StringComparison.OrdinalIgnoreCase))
				{
					reader.ReadAndAssert();
					DiscriminatedUnionConverter.Union union = DiscriminatedUnionConverter.UnionCache.Get(objectType);
					caseName = reader.Value.ToString();
					IEnumerable<DiscriminatedUnionConverter.UnionCase> cases = union.Cases;
					Func<DiscriminatedUnionConverter.UnionCase, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((DiscriminatedUnionConverter.UnionCase c) => c.Name == caseName));
					}
					unionCase = cases.SingleOrDefault(predicate);
					if (unionCase == null)
					{
						throw JsonSerializationException.Create(reader, "No union type found with the name '{0}'.".FormatWith(CultureInfo.InvariantCulture, caseName));
					}
				}
				else
				{
					if (!string.Equals(text, "Fields", StringComparison.OrdinalIgnoreCase))
					{
						throw JsonSerializationException.Create(reader, "Unexpected property '{0}' found when reading union.".FormatWith(CultureInfo.InvariantCulture, text));
					}
					reader.ReadAndAssert();
					if (reader.TokenType != JsonToken.StartArray)
					{
						throw JsonSerializationException.Create(reader, "Union fields must been an array.");
					}
					jarray = (JArray)JToken.ReadFrom(reader);
				}
				reader.ReadAndAssert();
			}
			if (unionCase == null)
			{
				throw JsonSerializationException.Create(reader, "No '{0}' property with union name found.".FormatWith(CultureInfo.InvariantCulture, "Case"));
			}
			object[] array = new object[unionCase.Fields.Length];
			if (unionCase.Fields.Length != 0 && jarray == null)
			{
				throw JsonSerializationException.Create(reader, "No '{0}' property with union fields found.".FormatWith(CultureInfo.InvariantCulture, "Fields"));
			}
			if (jarray != null)
			{
				if (unionCase.Fields.Length != jarray.Count)
				{
					throw JsonSerializationException.Create(reader, "The number of field values does not match the number of properties defined by union '{0}'.".FormatWith(CultureInfo.InvariantCulture, caseName));
				}
				for (int i = 0; i < jarray.Count; i++)
				{
					JToken jtoken = jarray[i];
					PropertyInfo propertyInfo = unionCase.Fields[i];
					array[i] = jtoken.ToObject(propertyInfo.PropertyType, serializer);
				}
			}
			object[] args = new object[]
			{
				array
			};
			return unionCase.Constructor.Invoke(args);
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00031728 File Offset: 0x0002F928
		public override bool CanConvert(Type objectType)
		{
			if (typeof(IEnumerable).IsAssignableFrom(objectType))
			{
				return false;
			}
			object[] customAttributes = objectType.GetCustomAttributes(true);
			bool flag = false;
			object[] array = customAttributes;
			for (int i = 0; i < array.Length; i++)
			{
				Type type = array[i].GetType();
				if (type.FullName == "Microsoft.FSharp.Core.CompilationMappingAttribute")
				{
					FSharpUtils.EnsureInitialized(type.Assembly());
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			MethodCall<object, object> isUnion = FSharpUtils.Instance.IsUnion;
			object target = null;
			object[] array2 = new object[2];
			array2[0] = objectType;
			return (bool)isUnion(target, array2);
		}

		// Token: 0x040003D0 RID: 976
		private const string CasePropertyName = "Case";

		// Token: 0x040003D1 RID: 977
		private const string FieldsPropertyName = "Fields";

		// Token: 0x040003D2 RID: 978
		private static readonly ThreadSafeStore<Type, DiscriminatedUnionConverter.Union> UnionCache = new ThreadSafeStore<Type, DiscriminatedUnionConverter.Union>(new Func<Type, DiscriminatedUnionConverter.Union>(DiscriminatedUnionConverter.CreateUnion));

		// Token: 0x040003D3 RID: 979
		private static readonly ThreadSafeStore<Type, Type> UnionTypeLookupCache = new ThreadSafeStore<Type, Type>(new Func<Type, Type>(DiscriminatedUnionConverter.CreateUnionTypeLookup));

		// Token: 0x020001DD RID: 477
		[Nullable(0)]
		internal class Union
		{
			// Token: 0x06001033 RID: 4147 RVA: 0x00047767 File Offset: 0x00045967
			public Union(FSharpFunction tagReader, List<DiscriminatedUnionConverter.UnionCase> cases)
			{
				this.TagReader = tagReader;
				this.Cases = cases;
			}

			// Token: 0x0400084B RID: 2123
			public readonly FSharpFunction TagReader;

			// Token: 0x0400084C RID: 2124
			public readonly List<DiscriminatedUnionConverter.UnionCase> Cases;
		}

		// Token: 0x020001DE RID: 478
		[Nullable(0)]
		internal class UnionCase
		{
			// Token: 0x06001034 RID: 4148 RVA: 0x0004777D File Offset: 0x0004597D
			public UnionCase(int tag, string name, PropertyInfo[] fields, FSharpFunction fieldReader, FSharpFunction constructor)
			{
				this.Tag = tag;
				this.Name = name;
				this.Fields = fields;
				this.FieldReader = fieldReader;
				this.Constructor = constructor;
			}

			// Token: 0x0400084D RID: 2125
			public readonly int Tag;

			// Token: 0x0400084E RID: 2126
			public readonly string Name;

			// Token: 0x0400084F RID: 2127
			public readonly PropertyInfo[] Fields;

			// Token: 0x04000850 RID: 2128
			public readonly FSharpFunction FieldReader;

			// Token: 0x04000851 RID: 2129
			public readonly FSharpFunction Constructor;
		}
	}
}
