using System;
using System.Collections;
using log4net.Util;

namespace log4net.Plugin
{
	// Token: 0x02000061 RID: 97
	public class PluginCollection : ICollection, IEnumerable, IList, ICloneable
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0000AA55 File Offset: 0x00009A55
		public static PluginCollection ReadOnly(PluginCollection list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new PluginCollection.ReadOnlyPluginCollection(list);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000AA6B File Offset: 0x00009A6B
		public PluginCollection()
		{
			this.m_array = new IPlugin[16];
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000AA80 File Offset: 0x00009A80
		public PluginCollection(int capacity)
		{
			this.m_array = new IPlugin[capacity];
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000AA94 File Offset: 0x00009A94
		public PluginCollection(PluginCollection c)
		{
			this.m_array = new IPlugin[c.Count];
			this.AddRange(c);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000AAB5 File Offset: 0x00009AB5
		public PluginCollection(IPlugin[] a)
		{
			this.m_array = new IPlugin[a.Length];
			this.AddRange(a);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000AAD3 File Offset: 0x00009AD3
		public PluginCollection(ICollection col)
		{
			this.m_array = new IPlugin[col.Count];
			this.AddRange(col);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000AAF4 File Offset: 0x00009AF4
		protected internal PluginCollection(PluginCollection.Tag tag)
		{
			this.m_array = null;
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0000AB03 File Offset: 0x00009B03
		public virtual int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000AB0B File Offset: 0x00009B0B
		public virtual void CopyTo(IPlugin[] array)
		{
			this.CopyTo(array, 0);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000AB15 File Offset: 0x00009B15
		public virtual void CopyTo(IPlugin[] array, int start)
		{
			if (this.m_count > array.GetUpperBound(0) + 1 - start)
			{
				throw new ArgumentException("Destination array was not long enough.");
			}
			Array.Copy(this.m_array, 0, array, start, this.m_count);
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0000AB49 File Offset: 0x00009B49
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000AB4C File Offset: 0x00009B4C
		public virtual object SyncRoot
		{
			get
			{
				return this.m_array;
			}
		}

		// Token: 0x170000A1 RID: 161
		public virtual IPlugin this[int index]
		{
			get
			{
				this.ValidateIndex(index);
				return this.m_array[index];
			}
			set
			{
				this.ValidateIndex(index);
				this.m_version++;
				this.m_array[index] = value;
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000AB88 File Offset: 0x00009B88
		public virtual int Add(IPlugin item)
		{
			if (this.m_count == this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + 1);
			}
			this.m_array[this.m_count] = item;
			this.m_version++;
			int count = this.m_count;
			this.m_count = count + 1;
			return count;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000ABE0 File Offset: 0x00009BE0
		public virtual void Clear()
		{
			this.m_version++;
			this.m_array = new IPlugin[16];
			this.m_count = 0;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000AC04 File Offset: 0x00009C04
		public virtual object Clone()
		{
			PluginCollection pluginCollection = new PluginCollection(this.m_count);
			Array.Copy(this.m_array, 0, pluginCollection.m_array, 0, this.m_count);
			pluginCollection.m_count = this.m_count;
			pluginCollection.m_version = this.m_version;
			return pluginCollection;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000AC50 File Offset: 0x00009C50
		public virtual bool Contains(IPlugin item)
		{
			for (int num = 0; num != this.m_count; num++)
			{
				if (this.m_array[num].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000AC84 File Offset: 0x00009C84
		public virtual int IndexOf(IPlugin item)
		{
			for (int num = 0; num != this.m_count; num++)
			{
				if (this.m_array[num].Equals(item))
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000ACB8 File Offset: 0x00009CB8
		public virtual void Insert(int index, IPlugin item)
		{
			this.ValidateIndex(index, true);
			if (this.m_count == this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + 1);
			}
			if (index < this.m_count)
			{
				Array.Copy(this.m_array, index, this.m_array, index + 1, this.m_count - index);
			}
			this.m_array[index] = item;
			this.m_count++;
			this.m_version++;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000AD38 File Offset: 0x00009D38
		public virtual void Remove(IPlugin item)
		{
			int num = this.IndexOf(item);
			if (num < 0)
			{
				throw new ArgumentException("Cannot remove the specified item because it was not found in the specified Collection.");
			}
			this.m_version++;
			this.RemoveAt(num);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000AD74 File Offset: 0x00009D74
		public virtual void RemoveAt(int index)
		{
			this.ValidateIndex(index);
			this.m_count--;
			if (index < this.m_count)
			{
				Array.Copy(this.m_array, index + 1, this.m_array, index, this.m_count - index);
			}
			Array.Copy(new IPlugin[1], 0, this.m_array, this.m_count, 1);
			this.m_version++;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0000ADE3 File Offset: 0x00009DE3
		public virtual bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000ADE6 File Offset: 0x00009DE6
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000ADE9 File Offset: 0x00009DE9
		public virtual PluginCollection.IPluginCollectionEnumerator GetEnumerator()
		{
			return new PluginCollection.Enumerator(this);
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000ADF1 File Offset: 0x00009DF1
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0000ADFC File Offset: 0x00009DFC
		public virtual int Capacity
		{
			get
			{
				return this.m_array.Length;
			}
			set
			{
				if (value < this.m_count)
				{
					value = this.m_count;
				}
				if (value != this.m_array.Length)
				{
					if (value > 0)
					{
						IPlugin[] array = new IPlugin[value];
						Array.Copy(this.m_array, 0, array, 0, this.m_count);
						this.m_array = array;
						return;
					}
					this.m_array = new IPlugin[16];
				}
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000AE5C File Offset: 0x00009E5C
		public virtual int AddRange(PluginCollection x)
		{
			if (this.m_count + x.Count >= this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + x.Count);
			}
			Array.Copy(x.m_array, 0, this.m_array, this.m_count, x.Count);
			this.m_count += x.Count;
			this.m_version++;
			return this.m_count;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000AED8 File Offset: 0x00009ED8
		public virtual int AddRange(IPlugin[] x)
		{
			if (this.m_count + x.Length >= this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + x.Length);
			}
			Array.Copy(x, 0, this.m_array, this.m_count, x.Length);
			this.m_count += x.Length;
			this.m_version++;
			return this.m_count;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000AF44 File Offset: 0x00009F44
		public virtual int AddRange(ICollection col)
		{
			if (this.m_count + col.Count >= this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + col.Count);
			}
			foreach (object obj in col)
			{
				this.Add((IPlugin)obj);
			}
			return this.m_count;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000AFCC File Offset: 0x00009FCC
		public virtual void TrimToSize()
		{
			this.Capacity = this.m_count;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000AFDA File Offset: 0x00009FDA
		private void ValidateIndex(int i)
		{
			this.ValidateIndex(i, false);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000AFE4 File Offset: 0x00009FE4
		private void ValidateIndex(int i, bool allowEqualEnd)
		{
			int num = allowEqualEnd ? this.m_count : (this.m_count - 1);
			if (i < 0 || i > num)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("i", i, "Index was out of range. Must be non-negative and less than the size of the collection. [" + i.ToString() + "] Specified argument was out of the range of valid values.");
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000B034 File Offset: 0x0000A034
		private void EnsureCapacity(int min)
		{
			int num = (this.m_array.Length == 0) ? 16 : (this.m_array.Length * 2);
			if (num < min)
			{
				num = min;
			}
			this.Capacity = num;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000B066 File Offset: 0x0000A066
		void ICollection.CopyTo(Array array, int start)
		{
			Array.Copy(this.m_array, 0, array, start, this.m_count);
		}

		// Token: 0x170000A5 RID: 165
		object IList.this[int i]
		{
			get
			{
				return this[i];
			}
			set
			{
				this[i] = (IPlugin)value;
			}
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000B094 File Offset: 0x0000A094
		int IList.Add(object x)
		{
			return this.Add((IPlugin)x);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000B0A2 File Offset: 0x0000A0A2
		bool IList.Contains(object x)
		{
			return this.Contains((IPlugin)x);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000B0B0 File Offset: 0x0000A0B0
		int IList.IndexOf(object x)
		{
			return this.IndexOf((IPlugin)x);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000B0BE File Offset: 0x0000A0BE
		void IList.Insert(int pos, object x)
		{
			this.Insert(pos, (IPlugin)x);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000B0CD File Offset: 0x0000A0CD
		void IList.Remove(object x)
		{
			this.Remove((IPlugin)x);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000B0DB File Offset: 0x0000A0DB
		void IList.RemoveAt(int pos)
		{
			this.RemoveAt(pos);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000B0E4 File Offset: 0x0000A0E4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)this.GetEnumerator();
		}

		// Token: 0x040000C3 RID: 195
		private const int DEFAULT_CAPACITY = 16;

		// Token: 0x040000C4 RID: 196
		private IPlugin[] m_array;

		// Token: 0x040000C5 RID: 197
		private int m_count;

		// Token: 0x040000C6 RID: 198
		private int m_version;

		// Token: 0x020000FB RID: 251
		public interface IPluginCollectionEnumerator
		{
			// Token: 0x1700019C RID: 412
			// (get) Token: 0x060007E0 RID: 2016
			IPlugin Current { get; }

			// Token: 0x060007E1 RID: 2017
			bool MoveNext();

			// Token: 0x060007E2 RID: 2018
			void Reset();
		}

		// Token: 0x020000FC RID: 252
		protected internal enum Tag
		{
			// Token: 0x04000269 RID: 617
			Default
		}

		// Token: 0x020000FD RID: 253
		private sealed class Enumerator : IEnumerator, PluginCollection.IPluginCollectionEnumerator
		{
			// Token: 0x060007E3 RID: 2019 RVA: 0x00018E3F File Offset: 0x00017E3F
			internal Enumerator(PluginCollection tc)
			{
				this.m_collection = tc;
				this.m_index = -1;
				this.m_version = tc.m_version;
			}

			// Token: 0x1700019D RID: 413
			// (get) Token: 0x060007E4 RID: 2020 RVA: 0x00018E61 File Offset: 0x00017E61
			public IPlugin Current
			{
				get
				{
					return this.m_collection[this.m_index];
				}
			}

			// Token: 0x060007E5 RID: 2021 RVA: 0x00018E74 File Offset: 0x00017E74
			public bool MoveNext()
			{
				if (this.m_version != this.m_collection.m_version)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				this.m_index++;
				return this.m_index < this.m_collection.Count;
			}

			// Token: 0x060007E6 RID: 2022 RVA: 0x00018EC0 File Offset: 0x00017EC0
			public void Reset()
			{
				this.m_index = -1;
			}

			// Token: 0x1700019E RID: 414
			// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00018EC9 File Offset: 0x00017EC9
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400026A RID: 618
			private readonly PluginCollection m_collection;

			// Token: 0x0400026B RID: 619
			private int m_index;

			// Token: 0x0400026C RID: 620
			private int m_version;
		}

		// Token: 0x020000FE RID: 254
		private sealed class ReadOnlyPluginCollection : PluginCollection
		{
			// Token: 0x060007E8 RID: 2024 RVA: 0x00018ED1 File Offset: 0x00017ED1
			internal ReadOnlyPluginCollection(PluginCollection list) : base(PluginCollection.Tag.Default)
			{
				this.m_collection = list;
			}

			// Token: 0x060007E9 RID: 2025 RVA: 0x00018EE1 File Offset: 0x00017EE1
			public override void CopyTo(IPlugin[] array)
			{
				this.m_collection.CopyTo(array);
			}

			// Token: 0x060007EA RID: 2026 RVA: 0x00018EEF File Offset: 0x00017EEF
			public override void CopyTo(IPlugin[] array, int start)
			{
				this.m_collection.CopyTo(array, start);
			}

			// Token: 0x1700019F RID: 415
			// (get) Token: 0x060007EB RID: 2027 RVA: 0x00018EFE File Offset: 0x00017EFE
			public override int Count
			{
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x170001A0 RID: 416
			// (get) Token: 0x060007EC RID: 2028 RVA: 0x00018F0B File Offset: 0x00017F0B
			public override bool IsSynchronized
			{
				get
				{
					return this.m_collection.IsSynchronized;
				}
			}

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x060007ED RID: 2029 RVA: 0x00018F18 File Offset: 0x00017F18
			public override object SyncRoot
			{
				get
				{
					return this.m_collection.SyncRoot;
				}
			}

			// Token: 0x170001A2 RID: 418
			public override IPlugin this[int i]
			{
				get
				{
					return this.m_collection[i];
				}
				set
				{
					throw new NotSupportedException("This is a Read Only Collection and can not be modified");
				}
			}

			// Token: 0x060007F0 RID: 2032 RVA: 0x00018F3F File Offset: 0x00017F3F
			public override int Add(IPlugin x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x060007F1 RID: 2033 RVA: 0x00018F4B File Offset: 0x00017F4B
			public override void Clear()
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x060007F2 RID: 2034 RVA: 0x00018F57 File Offset: 0x00017F57
			public override bool Contains(IPlugin x)
			{
				return this.m_collection.Contains(x);
			}

			// Token: 0x060007F3 RID: 2035 RVA: 0x00018F65 File Offset: 0x00017F65
			public override int IndexOf(IPlugin x)
			{
				return this.m_collection.IndexOf(x);
			}

			// Token: 0x060007F4 RID: 2036 RVA: 0x00018F73 File Offset: 0x00017F73
			public override void Insert(int pos, IPlugin x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x060007F5 RID: 2037 RVA: 0x00018F7F File Offset: 0x00017F7F
			public override void Remove(IPlugin x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x060007F6 RID: 2038 RVA: 0x00018F8B File Offset: 0x00017F8B
			public override void RemoveAt(int pos)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00018F97 File Offset: 0x00017F97
			public override bool IsFixedSize
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x060007F8 RID: 2040 RVA: 0x00018F9A File Offset: 0x00017F9A
			public override bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060007F9 RID: 2041 RVA: 0x00018F9D File Offset: 0x00017F9D
			public override PluginCollection.IPluginCollectionEnumerator GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x060007FA RID: 2042 RVA: 0x00018FAA File Offset: 0x00017FAA
			// (set) Token: 0x060007FB RID: 2043 RVA: 0x00018FB7 File Offset: 0x00017FB7
			public override int Capacity
			{
				get
				{
					return this.m_collection.Capacity;
				}
				set
				{
					throw new NotSupportedException("This is a Read Only Collection and can not be modified");
				}
			}

			// Token: 0x060007FC RID: 2044 RVA: 0x00018FC3 File Offset: 0x00017FC3
			public override int AddRange(PluginCollection x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x060007FD RID: 2045 RVA: 0x00018FCF File Offset: 0x00017FCF
			public override int AddRange(IPlugin[] x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x0400026D RID: 621
			private readonly PluginCollection m_collection;
		}
	}
}
