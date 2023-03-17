using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Persists an 8-byte <see cref="T:System.DateTime" /> constant for a field or parameter.</summary>
	// Token: 0x02000882 RID: 2178
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DateTimeConstantAttribute : CustomConstantAttribute
	{
		/// <summary>Initializes a new instance of the <see langword="DateTimeConstantAttribute" /> class with the number of 100-nanosecond ticks that represent the date and time of this instance.</summary>
		/// <param name="ticks">The number of 100-nanosecond ticks that represent the date and time of this instance.</param>
		// Token: 0x06005C7F RID: 23679 RVA: 0x00144988 File Offset: 0x00142B88
		[__DynamicallyInvokable]
		public DateTimeConstantAttribute(long ticks)
		{
			this.date = new DateTime(ticks);
		}

		/// <summary>Gets the number of 100-nanosecond ticks that represent the date and time of this instance.</summary>
		/// <returns>The number of 100-nanosecond ticks that represent the date and time of this instance.</returns>
		// Token: 0x17000FFA RID: 4090
		// (get) Token: 0x06005C80 RID: 23680 RVA: 0x0014499C File Offset: 0x00142B9C
		[__DynamicallyInvokable]
		public override object Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.date;
			}
		}

		// Token: 0x06005C81 RID: 23681 RVA: 0x001449AC File Offset: 0x00142BAC
		internal static DateTime GetRawDateTimeConstant(CustomAttributeData attr)
		{
			foreach (CustomAttributeNamedArgument customAttributeNamedArgument in attr.NamedArguments)
			{
				if (customAttributeNamedArgument.MemberInfo.Name.Equals("Value"))
				{
					return new DateTime((long)customAttributeNamedArgument.TypedValue.Value);
				}
			}
			return new DateTime((long)attr.ConstructorArguments[0].Value);
		}

		// Token: 0x04002956 RID: 10582
		private DateTime date;
	}
}
