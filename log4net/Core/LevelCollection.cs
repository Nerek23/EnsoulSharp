using System;
using System.Collections;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000B1 RID: 177
	public class LevelCollection : ICollection, IEnumerable, IList, ICloneable
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x0000F0D1 File Offset: 0x0000E0D1
		public static LevelCollection ReadOnly(LevelCollection list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new LevelCollection.ReadOnlyLevelCollection(list);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000F0E7 File Offset: 0x0000E0E7
		public LevelCollection()
		{
			this.m_array = new Level[16];
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000F0FC File Offset: 0x0000E0FC
		public LevelCollection(int capacity)
		{
			this.m_array = new Level[capacity];
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000F110 File Offset: 0x0000E110
		public LevelCollection(LevelCollection c)
		{
			this.m_array = new Level[c.Count];
			this.AddRange(c);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000F131 File Offset: 0x0000E131
		public LevelCollection(Level[] a)
		{
			this.m_array = new Level[a.Length];
			this.AddRange(a);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000F14F File Offset: 0x0000E14F
		public LevelCollection(ICollection col)
		{
			this.m_array = new Level[col.Count];
			this.AddRange(col);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000F170 File Offset: 0x0000E170
		protected internal LevelCollection(LevelCollection.Tag tag)
		{
			this.m_array = null;
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000F17F File Offset: 0x0000E17F
		public virtual int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000F187 File Offset: 0x0000E187
		public virtual void CopyTo(Level[] array)
		{
			this.CopyTo(array, 0);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000F191 File Offset: 0x0000E191
		public virtual void CopyTo(Level[] array, int start)
		{
			if (this.m_count > array.GetUpperBound(0) + 1 - start)
			{
				throw new ArgumentException("Destination array was not long enough.");
			}
			Array.Copy(this.m_array, 0, array, start, this.m_count);
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000F1C5 File Offset: 0x0000E1C5
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000F1C8 File Offset: 0x0000E1C8
		public virtual object SyncRoot
		{
			get
			{
				return this.m_array;
			}
		}

		// Token: 0x170000DA RID: 218
		public virtual Level this[int index]
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

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000F204 File Offset: 0x0000E204
		public virtual int Add(Level item)
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

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000F25C File Offset: 0x0000E25C
		public virtual void Clear()
		{
			this.m_version++;
			this.m_array = new Level[16];
			this.m_count = 0;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000F280 File Offset: 0x0000E280
		public virtual object Clone()
		{
			LevelCollection levelCollection = new LevelCollection(this.m_count);
			Array.Copy(this.m_array, 0, levelCollection.m_array, 0, this.m_count);
			levelCollection.m_count = this.m_count;
			levelCollection.m_version = this.m_version;
			return levelCollection;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0000F2CC File Offset: 0x0000E2CC
		public virtual bool Contains(Level item)
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

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000F300 File Offset: 0x0000E300
		public virtual int IndexOf(Level item)
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

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000F334 File Offset: 0x0000E334
		public virtual void Insert(int index, Level item)
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

		// Token: 0x060004BA RID: 1210 RVA: 0x0000F3B4 File Offset: 0x0000E3B4
		public virtual void Remove(Level item)
		{
			int num = this.IndexOf(item);
			if (num < 0)
			{
				throw new ArgumentException("Cannot remove the specified item because it was not found in the specified Collection.");
			}
			this.m_version++;
			this.RemoveAt(num);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000F3F0 File Offset: 0x0000E3F0
		public virtual void RemoveAt(int index)
		{
			this.ValidateIndex(index);
			this.m_count--;
			if (index < this.m_count)
			{
				Array.Copy(this.m_array, index + 1, this.m_array, index, this.m_count - index);
			}
			Array.Copy(new Level[1], 0, this.m_array, this.m_count, 1);
			this.m_version++;
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000F45F File Offset: 0x0000E45F
		public virtual bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000F462 File Offset: 0x0000E462
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000F465 File Offset: 0x0000E465
		public virtual LevelCollection.ILevelCollectionEnumerator GetEnumerator()
		{
			return new LevelCollection.Enumerator(this);
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x0000F46D File Offset: 0x0000E46D
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x0000F478 File Offset: 0x0000E478
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
						Level[] array = new Level[value];
						Array.Copy(this.m_array, 0, array, 0, this.m_count);
						this.m_array = array;
						return;
					}
					this.m_array = new Level[16];
				}
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000F4D8 File Offset: 0x0000E4D8
		public virtual int AddRange(LevelCollection x)
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

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000F554 File Offset: 0x0000E554
		public virtual int AddRange(Level[] x)
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

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000F5C0 File Offset: 0x0000E5C0
		public virtual int AddRange(ICollection col)
		{
			if (this.m_count + col.Count >= this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + col.Count);
			}
			foreach (object obj in col)
			{
				this.Add((Level)obj);
			}
			return this.m_count;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000F648 File Offset: 0x0000E648
		public virtual void TrimToSize()
		{
			this.Capacity = this.m_count;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000F656 File Offset: 0x0000E656
		private void ValidateIndex(int i)
		{
			this.ValidateIndex(i, false);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000F660 File Offset: 0x0000E660
		private void ValidateIndex(int i, bool allowEqualEnd)
		{
			int num = allowEqualEnd ? this.m_count : (this.m_count - 1);
			if (i < 0 || i > num)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("i", i, "Index was out of range. Must be non-negative and less than the size of the collection. [" + i.ToString() + "] Specified argument was out of the range of valid values.");
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000F6B0 File Offset: 0x0000E6B0
		private void EnsureCapacity(int min)
		{
			int num = (this.m_array.Length == 0) ? 16 : (this.m_array.Length * 2);
			if (num < min)
			{
				num = min;
			}
			this.Capacity = num;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000F6E2 File Offset: 0x0000E6E2
		void ICollection.CopyTo(Array array, int start)
		{
			Array.Copy(this.m_array, 0, array, start, this.m_count);
		}

		// Token: 0x170000DE RID: 222
		object IList.this[int i]
		{
			get
			{
				return this[i];
			}
			set
			{
				this[i] = (Level)value;
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000F710 File Offset: 0x0000E710
		int IList.Add(object x)
		{
			return this.Add((Level)x);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000F71E File Offset: 0x0000E71E
		bool IList.Contains(object x)
		{
			return this.Contains((Level)x);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000F72C File Offset: 0x0000E72C
		int IList.IndexOf(object x)
		{
			return this.IndexOf((Level)x);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000F73A File Offset: 0x0000E73A
		void IList.Insert(int pos, object x)
		{
			this.Insert(pos, (Level)x);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000F749 File Offset: 0x0000E749
		void IList.Remove(object x)
		{
			this.Remove((Level)x);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000F757 File Offset: 0x0000E757
		void IList.RemoveAt(int pos)
		{
			this.RemoveAt(pos);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000F760 File Offset: 0x0000E760
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)this.GetEnumerator();
		}

		// Token: 0x0400014F RID: 335
		private const int DEFAULT_CAPACITY = 16;

		// Token: 0x04000150 RID: 336
		private Level[] m_array;

		// Token: 0x04000151 RID: 337
		private int m_count;

		// Token: 0x04000152 RID: 338
		private int m_version;

		// Token: 0x02000100 RID: 256
		public interface ILevelCollectionEnumerator
		{
			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x06000801 RID: 2049
			Level Current { get; }

			// Token: 0x06000802 RID: 2050
			bool MoveNext();

			// Token: 0x06000803 RID: 2051
			void Reset();
		}

		// Token: 0x02000101 RID: 257
		protected internal enum Tag
		{
			// Token: 0x04000270 RID: 624
			Default
		}

		// Token: 0x02000102 RID: 258
		private sealed class Enumerator : IEnumerator, LevelCollection.ILevelCollectionEnumerator
		{
			// Token: 0x06000804 RID: 2052 RVA: 0x00019022 File Offset: 0x00018022
			internal Enumerator(LevelCollection tc)
			{
				this.m_collection = tc;
				this.m_index = -1;
				this.m_version = tc.m_version;
			}

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x06000805 RID: 2053 RVA: 0x00019044 File Offset: 0x00018044
			public Level Current
			{
				get
				{
					return this.m_collection[this.m_index];
				}
			}

			// Token: 0x06000806 RID: 2054 RVA: 0x00019058 File Offset: 0x00018058
			public bool MoveNext()
			{
				if (this.m_version != this.m_collection.m_version)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				this.m_index++;
				return this.m_index < this.m_collection.Count;
			}

			// Token: 0x06000807 RID: 2055 RVA: 0x000190A4 File Offset: 0x000180A4
			public void Reset()
			{
				this.m_index = -1;
			}

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x06000808 RID: 2056 RVA: 0x000190AD File Offset: 0x000180AD
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000271 RID: 625
			private readonly LevelCollection m_collection;

			// Token: 0x04000272 RID: 626
			private int m_index;

			// Token: 0x04000273 RID: 627
			private int m_version;
		}

		// Token: 0x02000103 RID: 259
		private sealed class ReadOnlyLevelCollection : LevelCollection
		{
			// Token: 0x06000809 RID: 2057 RVA: 0x000190B5 File Offset: 0x000180B5
			internal ReadOnlyLevelCollection(LevelCollection list) : base(LevelCollection.Tag.Default)
			{
				this.m_collection = list;
			}

			// Token: 0x0600080A RID: 2058 RVA: 0x000190C5 File Offset: 0x000180C5
			public override void CopyTo(Level[] array)
			{
				this.m_collection.CopyTo(array);
			}

			// Token: 0x0600080B RID: 2059 RVA: 0x000190D3 File Offset: 0x000180D3
			public override void CopyTo(Level[] array, int start)
			{
				this.m_collection.CopyTo(array, start);
			}

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x0600080C RID: 2060 RVA: 0x000190E2 File Offset: 0x000180E2
			public override int Count
			{
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x0600080D RID: 2061 RVA: 0x000190EF File Offset: 0x000180EF
			public override bool IsSynchronized
			{
				get
				{
					return this.m_collection.IsSynchronized;
				}
			}

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x0600080E RID: 2062 RVA: 0x000190FC File Offset: 0x000180FC
			public override object SyncRoot
			{
				get
				{
					return this.m_collection.SyncRoot;
				}
			}

			// Token: 0x170001AC RID: 428
			public override Level this[int i]
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

			// Token: 0x06000811 RID: 2065 RVA: 0x00019123 File Offset: 0x00018123
			public override int Add(Level x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000812 RID: 2066 RVA: 0x0001912F File Offset: 0x0001812F
			public override void Clear()
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000813 RID: 2067 RVA: 0x0001913B File Offset: 0x0001813B
			public override bool Contains(Level x)
			{
				return this.m_collection.Contains(x);
			}

			// Token: 0x06000814 RID: 2068 RVA: 0x00019149 File Offset: 0x00018149
			public override int IndexOf(Level x)
			{
				return this.m_collection.IndexOf(x);
			}

			// Token: 0x06000815 RID: 2069 RVA: 0x00019157 File Offset: 0x00018157
			public override void Insert(int pos, Level x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000816 RID: 2070 RVA: 0x00019163 File Offset: 0x00018163
			public override void Remove(Level x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000817 RID: 2071 RVA: 0x0001916F File Offset: 0x0001816F
			public override void RemoveAt(int pos)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x170001AD RID: 429
			// (get) Token: 0x06000818 RID: 2072 RVA: 0x0001917B File Offset: 0x0001817B
			public override bool IsFixedSize
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x06000819 RID: 2073 RVA: 0x0001917E File Offset: 0x0001817E
			public override bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x0600081A RID: 2074 RVA: 0x00019181 File Offset: 0x00018181
			public override LevelCollection.ILevelCollectionEnumerator GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x0600081B RID: 2075 RVA: 0x0001918E File Offset: 0x0001818E
			// (set) Token: 0x0600081C RID: 2076 RVA: 0x0001919B File Offset: 0x0001819B
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

			// Token: 0x0600081D RID: 2077 RVA: 0x000191A7 File Offset: 0x000181A7
			public override int AddRange(LevelCollection x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x0600081E RID: 2078 RVA: 0x000191B3 File Offset: 0x000181B3
			public override int AddRange(Level[] x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x04000274 RID: 628
			private readonly LevelCollection m_collection;
		}
	}
}
