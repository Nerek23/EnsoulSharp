using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000BC RID: 188
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct JEnumerable<[Nullable(0)] T> : IJEnumerable<T>, IEnumerable<T>, IEnumerable, IEquatable<JEnumerable<T>> where T : JToken
	{
		// Token: 0x06000A1F RID: 2591 RVA: 0x00029690 File Offset: 0x00027890
		public JEnumerable(IEnumerable<T> enumerable)
		{
			ValidationUtils.ArgumentNotNull(enumerable, "enumerable");
			this._enumerable = enumerable;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000296A4 File Offset: 0x000278A4
		public IEnumerator<T> GetEnumerator()
		{
			return (this._enumerable ?? JEnumerable<T>.Empty).GetEnumerator();
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x000296BF File Offset: 0x000278BF
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x170001D9 RID: 473
		public IJEnumerable<JToken> this[object key]
		{
			get
			{
				if (this._enumerable == null)
				{
					return JEnumerable<JToken>.Empty;
				}
				return new JEnumerable<JToken>(this._enumerable.Values(key));
			}
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000296F2 File Offset: 0x000278F2
		public bool Equals([Nullable(new byte[]
		{
			0,
			1
		})] JEnumerable<T> other)
		{
			return object.Equals(this._enumerable, other._enumerable);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00029708 File Offset: 0x00027908
		public override bool Equals(object obj)
		{
			if (obj is JEnumerable<T>)
			{
				JEnumerable<T> other = (JEnumerable<T>)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0002972D File Offset: 0x0002792D
		public override int GetHashCode()
		{
			if (this._enumerable == null)
			{
				return 0;
			}
			return this._enumerable.GetHashCode();
		}

		// Token: 0x04000365 RID: 869
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static readonly JEnumerable<T> Empty = new JEnumerable<T>(Enumerable.Empty<T>());

		// Token: 0x04000366 RID: 870
		private readonly IEnumerable<T> _enumerable;
	}
}
