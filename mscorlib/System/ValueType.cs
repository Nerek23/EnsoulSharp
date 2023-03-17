using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
	/// <summary>Provides the base class for value types.</summary>
	// Token: 0x02000159 RID: 345
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class ValueType
	{
		/// <summary>Indicates whether this instance and a specified object are equal.</summary>
		/// <param name="obj">The object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001570 RID: 5488 RVA: 0x0003EC40 File Offset: 0x0003CE40
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			RuntimeType runtimeType = (RuntimeType)base.GetType();
			RuntimeType left = (RuntimeType)obj.GetType();
			if (left != runtimeType)
			{
				return false;
			}
			if (ValueType.CanCompareBits(this))
			{
				return ValueType.FastEqualsCheck(this, obj);
			}
			FieldInfo[] fields = runtimeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i++)
			{
				object obj2 = ((RtFieldInfo)fields[i]).UnsafeGetValue(this);
				object obj3 = ((RtFieldInfo)fields[i]).UnsafeGetValue(obj);
				if (obj2 == null)
				{
					if (obj3 != null)
					{
						return false;
					}
				}
				else if (!obj2.Equals(obj3))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001571 RID: 5489
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanCompareBits(object obj);

		// Token: 0x06001572 RID: 5490
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool FastEqualsCheck(object a, object b);

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
		// Token: 0x06001573 RID: 5491
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public override extern int GetHashCode();

		// Token: 0x06001574 RID: 5492
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetHashCodeOfPtr(IntPtr ptr);

		/// <summary>Returns the fully qualified type name of this instance.</summary>
		/// <returns>The fully qualified type name.</returns>
		// Token: 0x06001575 RID: 5493 RVA: 0x0003ECDD File Offset: 0x0003CEDD
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return base.GetType().ToString();
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.ValueType" /> class.</summary>
		// Token: 0x06001576 RID: 5494 RVA: 0x0003ECEA File Offset: 0x0003CEEA
		[__DynamicallyInvokable]
		protected ValueType()
		{
		}
	}
}
