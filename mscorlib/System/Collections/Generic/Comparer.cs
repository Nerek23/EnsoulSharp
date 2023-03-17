using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Collections.Generic
{
	/// <summary>Provides a base class for implementations of the <see cref="T:System.Collections.Generic.IComparer`1" /> generic interface.</summary>
	/// <typeparam name="T">The type of objects to compare.</typeparam>
	// Token: 0x0200048D RID: 1165
	[TypeDependency("System.Collections.Generic.ObjectComparer`1")]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Comparer<T> : IComparer, IComparer<T>
	{
		/// <summary>Returns a default sort order comparer for the type specified by the generic argument.</summary>
		/// <returns>An object that inherits <see cref="T:System.Collections.Generic.Comparer`1" /> and serves as a sort order comparer for type <paramref name="T" />.</returns>
		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06003905 RID: 14597 RVA: 0x000D9272 File Offset: 0x000D7472
		[__DynamicallyInvokable]
		public static Comparer<T> Default
		{
			[__DynamicallyInvokable]
			get
			{
				return Comparer<T>.defaultComparer;
			}
		}

		/// <summary>Creates a comparer by using the specified comparison.</summary>
		/// <param name="comparison">The comparison to use.</param>
		/// <returns>The new comparer.</returns>
		// Token: 0x06003906 RID: 14598 RVA: 0x000D9279 File Offset: 0x000D7479
		[__DynamicallyInvokable]
		public static Comparer<T> Create(Comparison<T> comparison)
		{
			if (comparison == null)
			{
				throw new ArgumentNullException("comparison");
			}
			return new ComparisonComparer<T>(comparison);
		}

		// Token: 0x06003907 RID: 14599 RVA: 0x000D9290 File Offset: 0x000D7490
		[SecuritySafeCritical]
		private static Comparer<T> CreateComparer()
		{
			RuntimeType runtimeType = (RuntimeType)typeof(T);
			if (typeof(IComparable<T>).IsAssignableFrom(runtimeType))
			{
				return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(GenericComparer<int>), runtimeType);
			}
			if (runtimeType.IsGenericType && runtimeType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				RuntimeType runtimeType2 = (RuntimeType)runtimeType.GetGenericArguments()[0];
				if (typeof(IComparable<>).MakeGenericType(new Type[]
				{
					runtimeType2
				}).IsAssignableFrom(runtimeType2))
				{
					return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(NullableComparer<int>), runtimeType2);
				}
			}
			return new ObjectComparer<T>();
		}

		/// <summary>When overridden in a derived class, performs a comparison of two objects of the same type and returns a value indicating whether one object is less than, equal to, or greater than the other.</summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.  
		///   Value  
		///
		///   Meaning  
		///
		///   Less than zero  
		///
		///  <paramref name="x" /> is less than <paramref name="y" />.  
		///
		///   Zero  
		///
		///  <paramref name="x" /> equals <paramref name="y" />.  
		///
		///   Greater than zero  
		///
		///  <paramref name="x" /> is greater than <paramref name="y" />.</returns>
		/// <exception cref="T:System.ArgumentException">Type <paramref name="T" /> does not implement either the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface.</exception>
		// Token: 0x06003908 RID: 14600
		[__DynamicallyInvokable]
		public abstract int Compare(T x, T y);

		/// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.  
		///   Value  
		///
		///   Meaning  
		///
		///   Less than zero  
		///
		///  <paramref name="x" /> is less than <paramref name="y" />.  
		///
		///   Zero  
		///
		///  <paramref name="x" /> equals <paramref name="y" />.  
		///
		///   Greater than zero  
		///
		///  <paramref name="x" /> is greater than <paramref name="y" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="x" /> or <paramref name="y" /> is of a type that cannot be cast to type <paramref name="T" />.  
		/// -or-  
		/// <paramref name="x" /> and <paramref name="y" /> do not implement either the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface.</exception>
		// Token: 0x06003909 RID: 14601 RVA: 0x000D9348 File Offset: 0x000D7548
		[__DynamicallyInvokable]
		int IComparer.Compare(object x, object y)
		{
			if (x == null)
			{
				if (y != null)
				{
					return -1;
				}
				return 0;
			}
			else
			{
				if (y == null)
				{
					return 1;
				}
				if (x is T && y is T)
				{
					return this.Compare((T)((object)x), (T)((object)y));
				}
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
				return 0;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.Comparer`1" /> class.</summary>
		// Token: 0x0600390A RID: 14602 RVA: 0x000D9383 File Offset: 0x000D7583
		[__DynamicallyInvokable]
		protected Comparer()
		{
		}

		// Token: 0x04001885 RID: 6277
		private static readonly Comparer<T> defaultComparer = Comparer<T>.CreateComparer();
	}
}
