using System;
using System.Collections;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D3 RID: 211
	public class AppenderCollection : ICollection, IEnumerable, IList, ICloneable
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x0001371B File Offset: 0x0001271B
		public static AppenderCollection ReadOnly(AppenderCollection list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new AppenderCollection.ReadOnlyAppenderCollection(list);
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00013731 File Offset: 0x00012731
		public AppenderCollection()
		{
			this.m_array = new IAppender[16];
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00013746 File Offset: 0x00012746
		public AppenderCollection(int capacity)
		{
			this.m_array = new IAppender[capacity];
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0001375A File Offset: 0x0001275A
		public AppenderCollection(AppenderCollection c)
		{
			this.m_array = new IAppender[c.Count];
			this.AddRange(c);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0001377B File Offset: 0x0001277B
		public AppenderCollection(IAppender[] a)
		{
			this.m_array = new IAppender[a.Length];
			this.AddRange(a);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00013799 File Offset: 0x00012799
		public AppenderCollection(ICollection col)
		{
			this.m_array = new IAppender[col.Count];
			this.AddRange(col);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x000137BA File Offset: 0x000127BA
		protected internal AppenderCollection(AppenderCollection.Tag tag)
		{
			this.m_array = null;
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x000137C9 File Offset: 0x000127C9
		public virtual int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000137D1 File Offset: 0x000127D1
		public virtual void CopyTo(IAppender[] array)
		{
			this.CopyTo(array, 0);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x000137DB File Offset: 0x000127DB
		public virtual void CopyTo(IAppender[] array, int start)
		{
			if (this.m_count > array.GetUpperBound(0) + 1 - start)
			{
				throw new ArgumentException("Destination array was not long enough.");
			}
			Array.Copy(this.m_array, 0, array, start, this.m_count);
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x0001380F File Offset: 0x0001280F
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x00013812 File Offset: 0x00012812
		public virtual object SyncRoot
		{
			get
			{
				return this.m_array;
			}
		}

		// Token: 0x17000129 RID: 297
		public virtual IAppender this[int index]
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

		// Token: 0x06000620 RID: 1568 RVA: 0x0001384C File Offset: 0x0001284C
		public virtual int Add(IAppender item)
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

		// Token: 0x06000621 RID: 1569 RVA: 0x000138A4 File Offset: 0x000128A4
		public virtual void Clear()
		{
			this.m_version++;
			this.m_array = new IAppender[16];
			this.m_count = 0;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000138C8 File Offset: 0x000128C8
		public virtual object Clone()
		{
			AppenderCollection appenderCollection = new AppenderCollection(this.m_count);
			Array.Copy(this.m_array, 0, appenderCollection.m_array, 0, this.m_count);
			appenderCollection.m_count = this.m_count;
			appenderCollection.m_version = this.m_version;
			return appenderCollection;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00013914 File Offset: 0x00012914
		public virtual bool Contains(IAppender item)
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

		// Token: 0x06000624 RID: 1572 RVA: 0x00013948 File Offset: 0x00012948
		public virtual int IndexOf(IAppender item)
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

		// Token: 0x06000625 RID: 1573 RVA: 0x0001397C File Offset: 0x0001297C
		public virtual void Insert(int index, IAppender item)
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

		// Token: 0x06000626 RID: 1574 RVA: 0x000139FC File Offset: 0x000129FC
		public virtual void Remove(IAppender item)
		{
			int num = this.IndexOf(item);
			if (num < 0)
			{
				throw new ArgumentException("Cannot remove the specified item because it was not found in the specified Collection.");
			}
			this.m_version++;
			this.RemoveAt(num);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00013A38 File Offset: 0x00012A38
		public virtual void RemoveAt(int index)
		{
			this.ValidateIndex(index);
			this.m_count--;
			if (index < this.m_count)
			{
				Array.Copy(this.m_array, index + 1, this.m_array, index, this.m_count - index);
			}
			Array.Copy(new IAppender[1], 0, this.m_array, this.m_count, 1);
			this.m_version++;
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x00013AA7 File Offset: 0x00012AA7
		public virtual bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x00013AAA File Offset: 0x00012AAA
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00013AAD File Offset: 0x00012AAD
		public virtual AppenderCollection.IAppenderCollectionEnumerator GetEnumerator()
		{
			return new AppenderCollection.Enumerator(this);
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x00013AB5 File Offset: 0x00012AB5
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00013AC0 File Offset: 0x00012AC0
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
						IAppender[] array = new IAppender[value];
						Array.Copy(this.m_array, 0, array, 0, this.m_count);
						this.m_array = array;
						return;
					}
					this.m_array = new IAppender[16];
				}
			}
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00013B20 File Offset: 0x00012B20
		public virtual int AddRange(AppenderCollection x)
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

		// Token: 0x0600062E RID: 1582 RVA: 0x00013B9C File Offset: 0x00012B9C
		public virtual int AddRange(IAppender[] x)
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

		// Token: 0x0600062F RID: 1583 RVA: 0x00013C08 File Offset: 0x00012C08
		public virtual int AddRange(ICollection col)
		{
			if (this.m_count + col.Count >= this.m_array.Length)
			{
				this.EnsureCapacity(this.m_count + col.Count);
			}
			foreach (object obj in col)
			{
				this.Add((IAppender)obj);
			}
			return this.m_count;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00013C90 File Offset: 0x00012C90
		public virtual void TrimToSize()
		{
			this.Capacity = this.m_count;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00013CA0 File Offset: 0x00012CA0
		public virtual IAppender[] ToArray()
		{
			IAppender[] array = new IAppender[this.m_count];
			if (this.m_count > 0)
			{
				Array.Copy(this.m_array, 0, array, 0, this.m_count);
			}
			return array;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00013CD7 File Offset: 0x00012CD7
		private void ValidateIndex(int i)
		{
			this.ValidateIndex(i, false);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00013CE4 File Offset: 0x00012CE4
		private void ValidateIndex(int i, bool allowEqualEnd)
		{
			int num = allowEqualEnd ? this.m_count : (this.m_count - 1);
			if (i < 0 || i > num)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("i", i, "Index was out of range. Must be non-negative and less than the size of the collection. [" + i.ToString() + "] Specified argument was out of the range of valid values.");
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00013D34 File Offset: 0x00012D34
		private void EnsureCapacity(int min)
		{
			int num = (this.m_array.Length == 0) ? 16 : (this.m_array.Length * 2);
			if (num < min)
			{
				num = min;
			}
			this.Capacity = num;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00013D66 File Offset: 0x00012D66
		void ICollection.CopyTo(Array array, int start)
		{
			if (this.m_count > 0)
			{
				Array.Copy(this.m_array, 0, array, start, this.m_count);
			}
		}

		// Token: 0x1700012D RID: 301
		object IList.this[int i]
		{
			get
			{
				return this[i];
			}
			set
			{
				this[i] = (IAppender)value;
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00013D9D File Offset: 0x00012D9D
		int IList.Add(object x)
		{
			return this.Add((IAppender)x);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00013DAB File Offset: 0x00012DAB
		bool IList.Contains(object x)
		{
			return this.Contains((IAppender)x);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00013DB9 File Offset: 0x00012DB9
		int IList.IndexOf(object x)
		{
			return this.IndexOf((IAppender)x);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00013DC7 File Offset: 0x00012DC7
		void IList.Insert(int pos, object x)
		{
			this.Insert(pos, (IAppender)x);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00013DD6 File Offset: 0x00012DD6
		void IList.Remove(object x)
		{
			this.Remove((IAppender)x);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00013DE4 File Offset: 0x00012DE4
		void IList.RemoveAt(int pos)
		{
			this.RemoveAt(pos);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00013DED File Offset: 0x00012DED
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)this.GetEnumerator();
		}

		// Token: 0x040001C6 RID: 454
		private const int DEFAULT_CAPACITY = 16;

		// Token: 0x040001C7 RID: 455
		private IAppender[] m_array;

		// Token: 0x040001C8 RID: 456
		private int m_count;

		// Token: 0x040001C9 RID: 457
		private int m_version;

		// Token: 0x040001CA RID: 458
		public static readonly AppenderCollection EmptyCollection = AppenderCollection.ReadOnly(new AppenderCollection(0));

		// Token: 0x02000108 RID: 264
		public interface IAppenderCollectionEnumerator
		{
			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x0600082D RID: 2093
			IAppender Current { get; }

			// Token: 0x0600082E RID: 2094
			bool MoveNext();

			// Token: 0x0600082F RID: 2095
			void Reset();
		}

		// Token: 0x02000109 RID: 265
		protected internal enum Tag
		{
			// Token: 0x04000291 RID: 657
			Default
		}

		// Token: 0x0200010A RID: 266
		private sealed class Enumerator : IEnumerator, AppenderCollection.IAppenderCollectionEnumerator
		{
			// Token: 0x06000830 RID: 2096 RVA: 0x00019533 File Offset: 0x00018533
			internal Enumerator(AppenderCollection tc)
			{
				this.m_collection = tc;
				this.m_index = -1;
				this.m_version = tc.m_version;
			}

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000831 RID: 2097 RVA: 0x00019555 File Offset: 0x00018555
			public IAppender Current
			{
				get
				{
					return this.m_collection[this.m_index];
				}
			}

			// Token: 0x06000832 RID: 2098 RVA: 0x00019568 File Offset: 0x00018568
			public bool MoveNext()
			{
				if (this.m_version != this.m_collection.m_version)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				this.m_index++;
				return this.m_index < this.m_collection.Count;
			}

			// Token: 0x06000833 RID: 2099 RVA: 0x000195B4 File Offset: 0x000185B4
			public void Reset()
			{
				this.m_index = -1;
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x06000834 RID: 2100 RVA: 0x000195BD File Offset: 0x000185BD
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000292 RID: 658
			private readonly AppenderCollection m_collection;

			// Token: 0x04000293 RID: 659
			private int m_index;

			// Token: 0x04000294 RID: 660
			private int m_version;
		}

		// Token: 0x0200010B RID: 267
		private sealed class ReadOnlyAppenderCollection : AppenderCollection, ICollection, IEnumerable
		{
			// Token: 0x06000835 RID: 2101 RVA: 0x000195C5 File Offset: 0x000185C5
			internal ReadOnlyAppenderCollection(AppenderCollection list) : base(AppenderCollection.Tag.Default)
			{
				this.m_collection = list;
			}

			// Token: 0x06000836 RID: 2102 RVA: 0x000195D5 File Offset: 0x000185D5
			public override void CopyTo(IAppender[] array)
			{
				this.m_collection.CopyTo(array);
			}

			// Token: 0x06000837 RID: 2103 RVA: 0x000195E3 File Offset: 0x000185E3
			public override void CopyTo(IAppender[] array, int start)
			{
				this.m_collection.CopyTo(array, start);
			}

			// Token: 0x06000838 RID: 2104 RVA: 0x000195F2 File Offset: 0x000185F2
			void ICollection.CopyTo(Array array, int start)
			{
				((ICollection)this.m_collection).CopyTo(array, start);
			}

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x06000839 RID: 2105 RVA: 0x00019601 File Offset: 0x00018601
			public override int Count
			{
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x0600083A RID: 2106 RVA: 0x0001960E File Offset: 0x0001860E
			public override bool IsSynchronized
			{
				get
				{
					return this.m_collection.IsSynchronized;
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001961B File Offset: 0x0001861B
			public override object SyncRoot
			{
				get
				{
					return this.m_collection.SyncRoot;
				}
			}

			// Token: 0x170001BA RID: 442
			public override IAppender this[int i]
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

			// Token: 0x0600083E RID: 2110 RVA: 0x00019642 File Offset: 0x00018642
			public override int Add(IAppender x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x0600083F RID: 2111 RVA: 0x0001964E File Offset: 0x0001864E
			public override void Clear()
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000840 RID: 2112 RVA: 0x0001965A File Offset: 0x0001865A
			public override bool Contains(IAppender x)
			{
				return this.m_collection.Contains(x);
			}

			// Token: 0x06000841 RID: 2113 RVA: 0x00019668 File Offset: 0x00018668
			public override int IndexOf(IAppender x)
			{
				return this.m_collection.IndexOf(x);
			}

			// Token: 0x06000842 RID: 2114 RVA: 0x00019676 File Offset: 0x00018676
			public override void Insert(int pos, IAppender x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000843 RID: 2115 RVA: 0x00019682 File Offset: 0x00018682
			public override void Remove(IAppender x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x06000844 RID: 2116 RVA: 0x0001968E File Offset: 0x0001868E
			public override void RemoveAt(int pos)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000845 RID: 2117 RVA: 0x0001969A File Offset: 0x0001869A
			public override bool IsFixedSize
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001969D File Offset: 0x0001869D
			public override bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06000847 RID: 2119 RVA: 0x000196A0 File Offset: 0x000186A0
			public override AppenderCollection.IAppenderCollectionEnumerator GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06000848 RID: 2120 RVA: 0x000196AD File Offset: 0x000186AD
			// (set) Token: 0x06000849 RID: 2121 RVA: 0x000196BA File Offset: 0x000186BA
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

			// Token: 0x0600084A RID: 2122 RVA: 0x000196C6 File Offset: 0x000186C6
			public override int AddRange(AppenderCollection x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x0600084B RID: 2123 RVA: 0x000196D2 File Offset: 0x000186D2
			public override int AddRange(IAppender[] x)
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x0600084C RID: 2124 RVA: 0x000196DE File Offset: 0x000186DE
			public override IAppender[] ToArray()
			{
				return this.m_collection.ToArray();
			}

			// Token: 0x0600084D RID: 2125 RVA: 0x000196EB File Offset: 0x000186EB
			public override void TrimToSize()
			{
				throw new NotSupportedException("This is a Read Only Collection and can not be modified");
			}

			// Token: 0x04000295 RID: 661
			private readonly AppenderCollection m_collection;
		}
	}
}
