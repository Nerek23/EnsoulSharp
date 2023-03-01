using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000057 RID: 87
	public static class EnumerableExtensions
	{
		// Token: 0x06000352 RID: 850 RVA: 0x00018ED8 File Offset: 0x000170D8
		public static T ClearFlags<T>(this T value, T flags) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' is not an enum.");
			}
			if (!Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' doesn't have the 'Flags' attribute.");
			}
			return value.SetFlags(flags, false);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00018F64 File Offset: 0x00017164
		public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' is not an enum.");
			}
			if (!Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' doesn't have the 'Flags' attribute.");
			}
			return (T)((object)Enum.ToObject(typeof(T), flags.Aggregate(0L, (long current, T flag) => current | Convert.ToInt64(flag))));
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00019020 File Offset: 0x00017220
		public static TSource Find<TSource>(this IEnumerable<TSource> source, Predicate<TSource> match)
		{
			return ((source as List<TSource>) ?? source.ToList<TSource>()).Find(match);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00019038 File Offset: 0x00017238
		public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
		{
			foreach (T obj in list)
			{
				action(obj);
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00019080 File Offset: 0x00017280
		public static IEnumerable<List<Vector2>> GetCombinations(this IReadOnlyCollection<Vector2> allValues)
		{
			List<List<Vector2>> list = new List<List<Vector2>>();
			int counter;
			int counter2;
			for (counter = 0; counter < 1 << allValues.Count; counter = counter2)
			{
				list.Add(allValues.Where((Vector2 t, int i) => (counter & 1 << i) == 0).ToList<Vector2>());
				counter2 = counter + 1;
			}
			return list;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000190E4 File Offset: 0x000172E4
		public static string GetFlagDescription<T>(this T value) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' is not an enum.");
			}
			if (!Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' doesn't have the 'Flags' attribute.");
			}
			string name = Enum.GetName(typeof(T), value);
			if (string.IsNullOrEmpty(name))
			{
				FieldInfo field = typeof(T).GetField(name);
				if (field != null)
				{
					DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (descriptionAttribute == null)
					{
						return null;
					}
					return descriptionAttribute.Description;
				}
			}
			return null;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000191C0 File Offset: 0x000173C0
		public static IEnumerable<T> GetFlags<T>(this T value) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' is not an enum.");
			}
			if (!Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' doesn't have the 'Flags' attribute.");
			}
			return from T flag in Enum.GetValues(typeof(T))
			where (Convert.ToInt64(value) & Convert.ToInt64(flag)) != 0L
			select flag;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00019274 File Offset: 0x00017474
		public static bool In<T>(this T source, params T[] list)
		{
			return list.Any((T x) => x.Equals(source));
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000192A0 File Offset: 0x000174A0
		public static IEnumerable<int> IndexOf<T>(this T[] haystack, T[] needle)
		{
			EnumerableExtensions.<>c__DisplayClass8_0<T> CS$<>8__locals1 = new EnumerableExtensions.<>c__DisplayClass8_0<T>();
			CS$<>8__locals1.haystack = haystack;
			if (needle == null || CS$<>8__locals1.haystack.Length < needle.Length)
			{
				yield break;
			}
			EnumerableExtensions.<>c__DisplayClass8_1<T> CS$<>8__locals2 = new EnumerableExtensions.<>c__DisplayClass8_1<T>();
			CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
			CS$<>8__locals2.l = 0;
			while (CS$<>8__locals2.l < CS$<>8__locals2.CS$<>8__locals1.haystack.Length - needle.Length + 1)
			{
				if (!needle.Where((T data, int index) => !CS$<>8__locals2.CS$<>8__locals1.haystack[CS$<>8__locals2.l + index].Equals(data)).Any<T>())
				{
					yield return CS$<>8__locals2.l;
				}
				int l = CS$<>8__locals2.l;
				CS$<>8__locals2.l = l + 1;
			}
			CS$<>8__locals2 = null;
			yield break;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000192B7 File Offset: 0x000174B7
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MaxBy(selector, null);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000192C4 File Offset: 0x000174C4
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			comparer = (comparer ?? Comparer<TKey>.Default);
			TSource tsource;
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					tsource = default(TSource);
					tsource = tsource;
				}
				else
				{
					TSource tsource2 = enumerator.Current;
					TKey y = selector(tsource2);
					while (enumerator.MoveNext())
					{
						TSource tsource3 = enumerator.Current;
						TKey tkey = selector(tsource3);
						if (comparer.Compare(tkey, y) > 0)
						{
							tsource2 = tsource3;
							y = tkey;
						}
					}
					tsource = tsource2;
				}
			}
			return tsource;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00019370 File Offset: 0x00017570
		public static T MaxOrDefault<T, TR>(this IEnumerable<T> container, Func<T, TR> comparer) where TR : IComparable
		{
			IEnumerator<T> enumerator = container.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return default(T);
			}
			T t = enumerator.Current;
			TR tr = comparer(t);
			while (enumerator.MoveNext())
			{
				T arg = enumerator.Current;
				TR tr2 = comparer(arg);
				if (tr2.CompareTo(tr) > 0)
				{
					tr = tr2;
					t = enumerator.Current;
				}
			}
			return t;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000193DE File Offset: 0x000175DE
		public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MinBy(selector, null);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000193E8 File Offset: 0x000175E8
		public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			comparer = (comparer ?? Comparer<TKey>.Default);
			TSource tsource;
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					tsource = default(TSource);
					tsource = tsource;
				}
				else
				{
					TSource tsource2 = enumerator.Current;
					TKey y = selector(tsource2);
					while (enumerator.MoveNext())
					{
						TSource tsource3 = enumerator.Current;
						TKey tkey = selector(tsource3);
						if (comparer.Compare(tkey, y) < 0)
						{
							tsource2 = tsource3;
							y = tkey;
						}
					}
					tsource = tsource2;
				}
			}
			return tsource;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00019494 File Offset: 0x00017694
		public static T MinOrDefault<T, TR>(this IEnumerable<T> container, Func<T, TR> comparer) where TR : IComparable
		{
			IEnumerator<T> enumerator = container.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return default(T);
			}
			T t = enumerator.Current;
			TR tr = comparer(t);
			while (enumerator.MoveNext())
			{
				T arg = enumerator.Current;
				TR tr2 = comparer(arg);
				if (tr2.CompareTo(tr) < 0)
				{
					tr = tr2;
					t = enumerator.Current;
				}
			}
			return t;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00019504 File Offset: 0x00017704
		public static T SetFlags<T>(this T value, T flags, bool status = true) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' is not an enum.");
			}
			if (!Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
			{
				throw new ArgumentException("Type '" + typeof(T).FullName + "' doesn't have the 'Flags' attribute.");
			}
			return (T)((object)Enum.ToObject(typeof(T), status ? (Convert.ToInt64(flags) | Convert.ToInt64(value)) : (~Convert.ToInt64(flags) & Convert.ToInt64(value))));
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000195D0 File Offset: 0x000177D0
		public static double StandardDeviation(this IEnumerable<int> values)
		{
			int[] source = (values as int[]) ?? values.ToArray<int>();
			double avg = source.Average();
			return Math.Sqrt(source.Average((int v) => Math.Pow((double)v - avg, 2.0)));
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00019617 File Offset: 0x00017817
		public static T To<T>(this IConvertible @object)
		{
			return (T)((object)Convert.ChangeType(@object, typeof(T)));
		}
	}
}
