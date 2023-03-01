using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200006D RID: 109
	[NullableContext(1)]
	[Nullable(0)]
	internal readonly struct StructMultiKey<[Nullable(2)] T1, [Nullable(2)] T2> : IEquatable<StructMultiKey<T1, T2>>
	{
		// Token: 0x060005EE RID: 1518 RVA: 0x00019421 File Offset: 0x00017621
		public StructMultiKey(T1 v1, T2 v2)
		{
			this.Value1 = v1;
			this.Value2 = v2;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00019434 File Offset: 0x00017634
		public override int GetHashCode()
		{
			T1 value = this.Value1;
			ref T1 ptr = ref value;
			T1 t = default(T1);
			int num;
			if (t == null)
			{
				t = value;
				ptr = ref t;
				if (t == null)
				{
					num = 0;
					goto IL_38;
				}
			}
			num = ptr.GetHashCode();
			IL_38:
			T2 value2 = this.Value2;
			ref T2 ptr2 = ref value2;
			T2 t2 = default(T2);
			int num2;
			if (t2 == null)
			{
				t2 = value2;
				ptr2 = ref t2;
				if (t2 == null)
				{
					num2 = 0;
					goto IL_70;
				}
			}
			num2 = ptr2.GetHashCode();
			IL_70:
			return num ^ num2;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x000194B4 File Offset: 0x000176B4
		public override bool Equals(object obj)
		{
			if (obj is StructMultiKey<T1, T2>)
			{
				StructMultiKey<T1, T2> other = (StructMultiKey<T1, T2>)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x000194DB File Offset: 0x000176DB
		public bool Equals([Nullable(new byte[]
		{
			0,
			1,
			1
		})] StructMultiKey<T1, T2> other)
		{
			return object.Equals(this.Value1, other.Value1) && object.Equals(this.Value2, other.Value2);
		}

		// Token: 0x0400020A RID: 522
		public readonly T1 Value1;

		// Token: 0x0400020B RID: 523
		public readonly T2 Value2;
	}
}
