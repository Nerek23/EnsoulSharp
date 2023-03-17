using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
	/// <summary>Represents a value tuple with a single component.</summary>
	/// <typeparam name="T1">The type of the value tuple's only element.</typeparam>
	// Token: 0x0200006A RID: 106
	[Serializable]
	public struct ValueTuple<T1> : IEquatable<ValueTuple<T1>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1>>, IValueTupleInternal, ITuple
	{
		/// <summary>Initializes a new <see cref="T:System.ValueTuple`1" /> instance.</summary>
		/// <param name="item1">The value tuple's first element.</param>
		// Token: 0x060003FB RID: 1019 RVA: 0x0000A70D File Offset: 0x0000890D
		public ValueTuple(T1 item1)
		{
			this.Item1 = item1;
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`1" /> instance is equal to a specified object.</summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060003FC RID: 1020 RVA: 0x0000A716 File Offset: 0x00008916
		public override bool Equals(object obj)
		{
			return obj is ValueTuple<T1> && this.Equals((ValueTuple<T1>)obj);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`1" /> instance is equal to a specified <see cref="T:System.ValueTuple`1" /> instance.</summary>
		/// <param name="other">The value tuple to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified tuple; otherwise, <see langword="false" />.</returns>
		// Token: 0x060003FD RID: 1021 RVA: 0x0000A72E File Offset: 0x0000892E
		public bool Equals(ValueTuple<T1> other)
		{
			return EqualityComparer<T1>.Default.Equals(this.Item1, other.Item1);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`1" /> instance is equal to a specified object based on a specified comparison method.</summary>
		/// <param name="other">The object to compare with this instance.</param>
		/// <param name="comparer">An object that defines the method to use to evaluate whether the two objects are equal.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060003FE RID: 1022 RVA: 0x0000A748 File Offset: 0x00008948
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			if (other == null || !(other is ValueTuple<T1>))
			{
				return false;
			}
			ValueTuple<T1> valueTuple = (ValueTuple<T1>)other;
			return comparer.Equals(this.Item1, valueTuple.Item1);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`1" /> instance to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="obj" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x060003FF RID: 1023 RVA: 0x0000A788 File Offset: 0x00008988
		int IComparable.CompareTo(object other)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[]
				{
					base.GetType().ToString()
				}), "other");
			}
			ValueTuple<T1> valueTuple = (ValueTuple<T1>)other;
			return Comparer<T1>.Default.Compare(this.Item1, valueTuple.Item1);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`1" /> instance to a specified <see cref="T:System.ValueTuple`1" /> instance.</summary>
		/// <param name="other">The tuple to compare with this instance.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="other" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x06000400 RID: 1024 RVA: 0x0000A7F2 File Offset: 0x000089F2
		public int CompareTo(ValueTuple<T1> other)
		{
			return Comparer<T1>.Default.Compare(this.Item1, other.Item1);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`1" /> instance to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <param name="comparer">An object that provides custom rules for comparison.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="other" /> in the sort order, as shown in the following table.  
		///   Vaue  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x06000401 RID: 1025 RVA: 0x0000A80C File Offset: 0x00008A0C
		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[]
				{
					base.GetType().ToString()
				}), "other");
			}
			ValueTuple<T1> valueTuple = (ValueTuple<T1>)other;
			return comparer.Compare(this.Item1, valueTuple.Item1);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`1" /> instance.</summary>
		/// <returns>The hash code for the current <see cref="T:System.ValueTuple`1" /> instance.</returns>
		// Token: 0x06000402 RID: 1026 RVA: 0x0000A87C File Offset: 0x00008A7C
		public override int GetHashCode()
		{
			return EqualityComparer<T1>.Default.GetHashCode(this.Item1);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`1" /> instance by using a specified computation method.</summary>
		/// <param name="comparer">An object whose <see cref="M:System.Collections.IEqualityComparer.GetHashCode(System.Object)" /> method calculates the hash code of the current <see cref="T:System.ValueTuple`1" /> instance.</param>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06000403 RID: 1027 RVA: 0x0000A88E File Offset: 0x00008A8E
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			return comparer.GetHashCode(this.Item1);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000A8A1 File Offset: 0x00008AA1
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer)
		{
			return comparer.GetHashCode(this.Item1);
		}

		/// <summary>Returns a string that represents the value of this <see cref="T:System.ValueTuple`1" /> instance.</summary>
		/// <returns>The string representation of this <see cref="T:System.ValueTuple`1" /> instance.</returns>
		// Token: 0x06000405 RID: 1029 RVA: 0x0000A8B4 File Offset: 0x00008AB4
		public override string ToString()
		{
			string str = "(";
			ref T1 ptr = ref this.Item1;
			T1 t = default(T1);
			string str2;
			if (t == null)
			{
				t = this.Item1;
				ptr = ref t;
				if (t == null)
				{
					str2 = null;
					goto IL_3A;
				}
			}
			str2 = ptr.ToString();
			IL_3A:
			return str + str2 + ")";
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000A908 File Offset: 0x00008B08
		string IValueTupleInternal.ToStringEnd()
		{
			ref T1 ptr = ref this.Item1;
			T1 t = default(T1);
			string str;
			if (t == null)
			{
				t = this.Item1;
				ptr = ref t;
				if (t == null)
				{
					str = null;
					goto IL_35;
				}
			}
			str = ptr.ToString();
			IL_35:
			return str + ")";
		}

		/// <summary>Gets the number of elements in the <see langword="ValueTuple" />.</summary>
		/// <returns>1, the number of elements in a <see cref="T:System.ValueTuple`1" /> object.</returns>
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000A954 File Offset: 0x00008B54
		int ITuple.Length
		{
			get
			{
				return 1;
			}
		}

		/// <summary>Gets the value of the <see langword="ValueTuple" /> element.</summary>
		/// <param name="index">The index of the <see langword="ValueTuple" /> element. <paramref name="index" /> must be 0.</param>
		/// <returns>The value of the <see langword="ValueTuple" /> element.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="index" /> is less than 0 or greater than 0.</exception>
		// Token: 0x17000075 RID: 117
		object ITuple.this[int index]
		{
			get
			{
				if (index != 0)
				{
					throw new IndexOutOfRangeException();
				}
				return this.Item1;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`1" /> instance's first element.</summary>
		// Token: 0x0400025F RID: 607
		public T1 Item1;
	}
}
