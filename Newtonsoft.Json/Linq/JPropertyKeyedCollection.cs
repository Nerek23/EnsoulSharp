using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C0 RID: 192
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class JPropertyKeyedCollection : Collection<JToken>
	{
		// Token: 0x06000A95 RID: 2709 RVA: 0x0002A76B File Offset: 0x0002896B
		public JPropertyKeyedCollection() : base(new List<JToken>())
		{
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0002A778 File Offset: 0x00028978
		private void AddKey(string key, JToken item)
		{
			this.EnsureDictionary();
			this._dictionary[key] = item;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0002A790 File Offset: 0x00028990
		protected void ChangeItemKey(JToken item, string newKey)
		{
			if (!this.ContainsItem(item))
			{
				throw new ArgumentException("The specified item does not exist in this KeyedCollection.");
			}
			string keyForItem = this.GetKeyForItem(item);
			if (!JPropertyKeyedCollection.Comparer.Equals(keyForItem, newKey))
			{
				if (newKey != null)
				{
					this.AddKey(newKey, item);
				}
				if (keyForItem != null)
				{
					this.RemoveKey(keyForItem);
				}
			}
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x0002A7DC File Offset: 0x000289DC
		protected override void ClearItems()
		{
			base.ClearItems();
			Dictionary<string, JToken> dictionary = this._dictionary;
			if (dictionary == null)
			{
				return;
			}
			dictionary.Clear();
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0002A7F4 File Offset: 0x000289F4
		public bool Contains(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this._dictionary != null && this._dictionary.ContainsKey(key);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0002A81C File Offset: 0x00028A1C
		private bool ContainsItem(JToken item)
		{
			if (this._dictionary == null)
			{
				return false;
			}
			string keyForItem = this.GetKeyForItem(item);
			JToken jtoken;
			return this._dictionary.TryGetValue(keyForItem, out jtoken);
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x0002A849 File Offset: 0x00028A49
		private void EnsureDictionary()
		{
			if (this._dictionary == null)
			{
				this._dictionary = new Dictionary<string, JToken>(JPropertyKeyedCollection.Comparer);
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0002A863 File Offset: 0x00028A63
		private string GetKeyForItem(JToken item)
		{
			return ((JProperty)item).Name;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0002A870 File Offset: 0x00028A70
		protected override void InsertItem(int index, JToken item)
		{
			this.AddKey(this.GetKeyForItem(item), item);
			base.InsertItem(index, item);
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0002A888 File Offset: 0x00028A88
		public bool Remove(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			JToken item;
			return this._dictionary != null && this._dictionary.TryGetValue(key, out item) && base.Remove(item);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0002A8C8 File Offset: 0x00028AC8
		protected override void RemoveItem(int index)
		{
			string keyForItem = this.GetKeyForItem(base.Items[index]);
			this.RemoveKey(keyForItem);
			base.RemoveItem(index);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0002A8F6 File Offset: 0x00028AF6
		private void RemoveKey(string key)
		{
			Dictionary<string, JToken> dictionary = this._dictionary;
			if (dictionary == null)
			{
				return;
			}
			dictionary.Remove(key);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0002A90C File Offset: 0x00028B0C
		protected override void SetItem(int index, JToken item)
		{
			string keyForItem = this.GetKeyForItem(item);
			string keyForItem2 = this.GetKeyForItem(base.Items[index]);
			if (JPropertyKeyedCollection.Comparer.Equals(keyForItem2, keyForItem))
			{
				if (this._dictionary != null)
				{
					this._dictionary[keyForItem] = item;
				}
			}
			else
			{
				this.AddKey(keyForItem, item);
				if (keyForItem2 != null)
				{
					this.RemoveKey(keyForItem2);
				}
			}
			base.SetItem(index, item);
		}

		// Token: 0x170001E9 RID: 489
		public JToken this[string key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				if (this._dictionary != null)
				{
					return this._dictionary[key];
				}
				throw new KeyNotFoundException();
			}
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0002A99D File Offset: 0x00028B9D
		public bool TryGetValue(string key, [Nullable(2)] [NotNullWhen(true)] out JToken value)
		{
			if (this._dictionary == null)
			{
				value = null;
				return false;
			}
			return this._dictionary.TryGetValue(key, out value);
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x0002A9B9 File Offset: 0x00028BB9
		public ICollection<string> Keys
		{
			get
			{
				this.EnsureDictionary();
				return this._dictionary.Keys;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0002A9CC File Offset: 0x00028BCC
		public ICollection<JToken> Values
		{
			get
			{
				this.EnsureDictionary();
				return this._dictionary.Values;
			}
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0002A9DF File Offset: 0x00028BDF
		public int IndexOfReference(JToken t)
		{
			return ((List<JToken>)base.Items).IndexOfReference(t);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0002A9F4 File Offset: 0x00028BF4
		public bool Compare(JPropertyKeyedCollection other)
		{
			if (this == other)
			{
				return true;
			}
			Dictionary<string, JToken> dictionary = this._dictionary;
			Dictionary<string, JToken> dictionary2 = other._dictionary;
			if (dictionary == null && dictionary2 == null)
			{
				return true;
			}
			if (dictionary == null)
			{
				return dictionary2.Count == 0;
			}
			if (dictionary2 == null)
			{
				return dictionary.Count == 0;
			}
			if (dictionary.Count != dictionary2.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, JToken> keyValuePair in dictionary)
			{
				JToken jtoken;
				if (!dictionary2.TryGetValue(keyValuePair.Key, out jtoken))
				{
					return false;
				}
				JProperty jproperty = (JProperty)keyValuePair.Value;
				JProperty jproperty2 = (JProperty)jtoken;
				if (jproperty.Value == null)
				{
					return jproperty2.Value == null;
				}
				if (!jproperty.Value.DeepEquals(jproperty2.Value))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400036C RID: 876
		private static readonly IEqualityComparer<string> Comparer = StringComparer.Ordinal;

		// Token: 0x0400036D RID: 877
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, JToken> _dictionary;
	}
}
