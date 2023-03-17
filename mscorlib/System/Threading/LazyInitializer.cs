using System;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Provides lazy initialization routines.</summary>
	// Token: 0x02000511 RID: 1297
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class LazyInitializer
	{
		/// <summary>Initializes a target reference type with the type's default constructor if it hasn't already been initialized.</summary>
		/// <param name="target">A reference of type T to initialize if it has not already been initialized.</param>
		/// <typeparam name="T">The type of the reference to be initialized.</typeparam>
		/// <returns>The initialized reference of type <paramref name="T" />.</returns>
		/// <exception cref="T:System.MemberAccessException">Permissions to access the constructor of type <paramref name="T" /> were missing.</exception>
		/// <exception cref="T:System.MissingMemberException">Type <paramref name="T" /> does not have a default constructor.</exception>
		// Token: 0x06003DC1 RID: 15809 RVA: 0x000E548D File Offset: 0x000E368D
		[__DynamicallyInvokable]
		public static T EnsureInitialized<T>(ref T target) where T : class
		{
			if (Volatile.Read<T>(ref target) != null)
			{
				return target;
			}
			return LazyInitializer.EnsureInitializedCore<T>(ref target, LazyHelpers<T>.s_activatorFactorySelector);
		}

		/// <summary>Initializes a target reference type by using a specified function if it hasn't already been initialized.</summary>
		/// <param name="target">The reference of type T to initialize if it hasn't already been initialized.</param>
		/// <param name="valueFactory">The function that is called to initialize the reference.</param>
		/// <typeparam name="T">The reference type of the reference to be initialized.</typeparam>
		/// <returns>The initialized value of type <paramref name="T" />.</returns>
		/// <exception cref="T:System.MissingMemberException">Type <paramref name="T" /> does not have a default constructor.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="valueFactory" /> returned null (Nothing in Visual Basic).</exception>
		// Token: 0x06003DC2 RID: 15810 RVA: 0x000E54AE File Offset: 0x000E36AE
		[__DynamicallyInvokable]
		public static T EnsureInitialized<T>(ref T target, Func<T> valueFactory) where T : class
		{
			if (Volatile.Read<T>(ref target) != null)
			{
				return target;
			}
			return LazyInitializer.EnsureInitializedCore<T>(ref target, valueFactory);
		}

		// Token: 0x06003DC3 RID: 15811 RVA: 0x000E54CC File Offset: 0x000E36CC
		private static T EnsureInitializedCore<T>(ref T target, Func<T> valueFactory) where T : class
		{
			T t = valueFactory();
			if (t == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Lazy_StaticInit_InvalidOperation"));
			}
			Interlocked.CompareExchange<T>(ref target, t, default(T));
			return target;
		}

		/// <summary>Initializes a target reference or value type with its default constructor if it hasn't already been initialized.</summary>
		/// <param name="target">A reference or value of type T to initialize if it hasn't already been initialized.</param>
		/// <param name="initialized">A reference to a Boolean value that determines whether the target has already been initialized.</param>
		/// <param name="syncLock">A reference to an object used as the mutually exclusive lock for initializing <paramref name="target" />. If <paramref name="syncLock" /> is <see langword="null" />, a new object will be instantiated.</param>
		/// <typeparam name="T">The type of the reference to be initialized.</typeparam>
		/// <returns>The initialized value of type <paramref name="T" />.</returns>
		/// <exception cref="T:System.MemberAccessException">Permissions to access the constructor of type <paramref name="T" /> were missing.</exception>
		/// <exception cref="T:System.MissingMemberException">Type <paramref name="T" /> does not have a default constructor.</exception>
		// Token: 0x06003DC4 RID: 15812 RVA: 0x000E550F File Offset: 0x000E370F
		[__DynamicallyInvokable]
		public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock)
		{
			if (Volatile.Read(ref initialized))
			{
				return target;
			}
			return LazyInitializer.EnsureInitializedCore<T>(ref target, ref initialized, ref syncLock, LazyHelpers<T>.s_activatorFactorySelector);
		}

		/// <summary>Initializes a target reference or value type by using a specified function if it hasn't already been initialized.</summary>
		/// <param name="target">A reference or value of type T to initialize if it hasn't already been initialized.</param>
		/// <param name="initialized">A reference to a Boolean value that determines whether the target has already been initialized.</param>
		/// <param name="syncLock">A reference to an object used as the mutually exclusive lock for initializing <paramref name="target" />. If <paramref name="syncLock" /> is <see langword="null" />, a new object will be instantiated.</param>
		/// <param name="valueFactory">The function that is called to initialize the reference or value.</param>
		/// <typeparam name="T">The type of the reference to be initialized.</typeparam>
		/// <returns>The initialized value of type <paramref name="T" />.</returns>
		/// <exception cref="T:System.MemberAccessException">Permissions to access the constructor of type <paramref name="T" /> were missing.</exception>
		/// <exception cref="T:System.MissingMemberException">Type <paramref name="T" /> does not have a default constructor.</exception>
		// Token: 0x06003DC5 RID: 15813 RVA: 0x000E552D File Offset: 0x000E372D
		[__DynamicallyInvokable]
		public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory)
		{
			if (Volatile.Read(ref initialized))
			{
				return target;
			}
			return LazyInitializer.EnsureInitializedCore<T>(ref target, ref initialized, ref syncLock, valueFactory);
		}

		// Token: 0x06003DC6 RID: 15814 RVA: 0x000E5548 File Offset: 0x000E3748
		private static T EnsureInitializedCore<T>(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory)
		{
			object obj = syncLock;
			if (obj == null)
			{
				object obj2 = new object();
				obj = Interlocked.CompareExchange(ref syncLock, obj2, null);
				if (obj == null)
				{
					obj = obj2;
				}
			}
			object obj3 = obj;
			lock (obj3)
			{
				if (!Volatile.Read(ref initialized))
				{
					target = valueFactory();
					Volatile.Write(ref initialized, true);
				}
			}
			return target;
		}
	}
}
