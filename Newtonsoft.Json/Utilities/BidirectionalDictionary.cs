using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000042 RID: 66
	[NullableContext(1)]
	[Nullable(0)]
	internal class BidirectionalDictionary<[Nullable(2)] TFirst, [Nullable(2)] TSecond>
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x000105A8 File Offset: 0x0000E7A8
		public BidirectionalDictionary() : this(EqualityComparer<TFirst>.Default, EqualityComparer<TSecond>.Default)
		{
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000105BA File Offset: 0x0000E7BA
		public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer) : this(firstEqualityComparer, secondEqualityComparer, "Duplicate item already exists for '{0}'.", "Duplicate item already exists for '{0}'.")
		{
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000105CE File Offset: 0x0000E7CE
		public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer, string duplicateFirstErrorMessage, string duplicateSecondErrorMessage)
		{
			this._firstToSecond = new Dictionary<TFirst, TSecond>(firstEqualityComparer);
			this._secondToFirst = new Dictionary<TSecond, TFirst>(secondEqualityComparer);
			this._duplicateFirstErrorMessage = duplicateFirstErrorMessage;
			this._duplicateSecondErrorMessage = duplicateSecondErrorMessage;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00010600 File Offset: 0x0000E800
		public void Set(TFirst first, TSecond second)
		{
			TSecond tsecond;
			if (this._firstToSecond.TryGetValue(first, out tsecond) && !tsecond.Equals(second))
			{
				throw new ArgumentException(this._duplicateFirstErrorMessage.FormatWith(CultureInfo.InvariantCulture, first));
			}
			TFirst tfirst;
			if (this._secondToFirst.TryGetValue(second, out tfirst) && !tfirst.Equals(first))
			{
				throw new ArgumentException(this._duplicateSecondErrorMessage.FormatWith(CultureInfo.InvariantCulture, second));
			}
			this._firstToSecond.Add(first, second);
			this._secondToFirst.Add(second, first);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000106A9 File Offset: 0x0000E8A9
		public bool TryGetByFirst(TFirst first, out TSecond second)
		{
			return this._firstToSecond.TryGetValue(first, out second);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000106B8 File Offset: 0x0000E8B8
		public bool TryGetBySecond(TSecond second, out TFirst first)
		{
			return this._secondToFirst.TryGetValue(second, out first);
		}

		// Token: 0x04000153 RID: 339
		private readonly IDictionary<TFirst, TSecond> _firstToSecond;

		// Token: 0x04000154 RID: 340
		private readonly IDictionary<TSecond, TFirst> _secondToFirst;

		// Token: 0x04000155 RID: 341
		private readonly string _duplicateFirstErrorMessage;

		// Token: 0x04000156 RID: 342
		private readonly string _duplicateSecondErrorMessage;
	}
}
