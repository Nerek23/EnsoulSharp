using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D3 RID: 211
	[NullableContext(1)]
	[Nullable(0)]
	internal abstract class PathFilter
	{
		// Token: 0x06000BFD RID: 3069
		public abstract IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch);

		// Token: 0x06000BFE RID: 3070 RVA: 0x00030218 File Offset: 0x0002E418
		[return: Nullable(2)]
		protected static JToken GetTokenIndex(JToken t, bool errorWhenNoMatch, int index)
		{
			JArray jarray = t as JArray;
			if (jarray != null)
			{
				if (jarray.Count > index)
				{
					return jarray[index];
				}
				if (errorWhenNoMatch)
				{
					throw new JsonException("Index {0} outside the bounds of JArray.".FormatWith(CultureInfo.InvariantCulture, index));
				}
				return null;
			}
			else
			{
				JConstructor jconstructor = t as JConstructor;
				if (jconstructor != null)
				{
					if (jconstructor.Count > index)
					{
						return jconstructor[index];
					}
					if (errorWhenNoMatch)
					{
						throw new JsonException("Index {0} outside the bounds of JConstructor.".FormatWith(CultureInfo.InvariantCulture, index));
					}
					return null;
				}
				else
				{
					if (errorWhenNoMatch)
					{
						throw new JsonException("Index {0} not valid on {1}.".FormatWith(CultureInfo.InvariantCulture, index, t.GetType().Name));
					}
					return null;
				}
			}
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x000302CC File Offset: 0x0002E4CC
		[NullableContext(2)]
		protected static JToken GetNextScanValue([Nullable(1)] JToken originalParent, JToken container, JToken value)
		{
			if (container != null && container.HasValues)
			{
				value = container.First;
			}
			else
			{
				while (value != null && value != originalParent && value == value.Parent.Last)
				{
					value = value.Parent;
				}
				if (value == null || value == originalParent)
				{
					return null;
				}
				value = value.Next;
			}
			return value;
		}
	}
}
