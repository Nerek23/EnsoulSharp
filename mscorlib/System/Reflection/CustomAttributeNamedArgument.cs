using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Represents a named argument of a custom attribute in the reflection-only context.</summary>
	// Token: 0x020005A8 RID: 1448
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct CustomAttributeNamedArgument
	{
		/// <summary>Tests whether two <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> structures are equivalent.</summary>
		/// <param name="left">The structure to the left of the equality operator.</param>
		/// <param name="right">The structure to the right of the equality operator.</param>
		/// <returns>
		///   <see langword="true" /> if the two <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> structures are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004429 RID: 17449 RVA: 0x000FA21F File Offset: 0x000F841F
		public static bool operator ==(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right)
		{
			return left.Equals(right);
		}

		/// <summary>Tests whether two <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> structures are different.</summary>
		/// <param name="left">The structure to the left of the inequality operator.</param>
		/// <param name="right">The structure to the right of the inequality operator.</param>
		/// <returns>
		///   <see langword="true" /> if the two <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> structures are different; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600442A RID: 17450 RVA: 0x000FA234 File Offset: 0x000F8434
		public static bool operator !=(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right)
		{
			return !left.Equals(right);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> class, which represents the specified field or property of the custom attribute, and specifies the value of the field or property.</summary>
		/// <param name="memberInfo">A field or property of the custom attribute. The new <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> object represents this member and its value.</param>
		/// <param name="value">The value of the field or property of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="memberInfo" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="memberInfo" /> is not a field or property of the custom attribute.</exception>
		// Token: 0x0600442B RID: 17451 RVA: 0x000FA24C File Offset: 0x000F844C
		public CustomAttributeNamedArgument(MemberInfo memberInfo, object value)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException("memberInfo");
			}
			FieldInfo fieldInfo = memberInfo as FieldInfo;
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			Type argumentType;
			if (fieldInfo != null)
			{
				argumentType = fieldInfo.FieldType;
			}
			else
			{
				if (!(propertyInfo != null))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidMemberForNamedArgument"));
				}
				argumentType = propertyInfo.PropertyType;
			}
			this.m_memberInfo = memberInfo;
			this.m_value = new CustomAttributeTypedArgument(argumentType, value);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> class, which represents the specified field or property of the custom attribute, and specifies a <see cref="T:System.Reflection.CustomAttributeTypedArgument" /> object that describes the type and value of the field or property.</summary>
		/// <param name="memberInfo">A field or property of the custom attribute. The new <see cref="T:System.Reflection.CustomAttributeNamedArgument" /> object represents this member and its value.</param>
		/// <param name="typedArgument">An object that describes the type and value of the field or property.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="memberInfo" /> is <see langword="null" />.</exception>
		// Token: 0x0600442C RID: 17452 RVA: 0x000FA2C5 File Offset: 0x000F84C5
		public CustomAttributeNamedArgument(MemberInfo memberInfo, CustomAttributeTypedArgument typedArgument)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException("memberInfo");
			}
			this.m_memberInfo = memberInfo;
			this.m_value = typedArgument;
		}

		/// <summary>Returns a string that consists of the argument name, the equal sign, and a string representation of the argument value.</summary>
		/// <returns>A string that consists of the argument name, the equal sign, and a string representation of the argument value.</returns>
		// Token: 0x0600442D RID: 17453 RVA: 0x000FA2EC File Offset: 0x000F84EC
		public override string ToString()
		{
			if (this.m_memberInfo == null)
			{
				return base.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "{0} = {1}", this.MemberInfo.Name, this.TypedValue.ToString(this.ArgumentType != typeof(object)));
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x0600442E RID: 17454 RVA: 0x000FA355 File Offset: 0x000F8555
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600442F RID: 17455 RVA: 0x000FA367 File Offset: 0x000F8567
		public override bool Equals(object obj)
		{
			return obj == this;
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x06004430 RID: 17456 RVA: 0x000FA377 File Offset: 0x000F8577
		internal Type ArgumentType
		{
			get
			{
				if (!(this.m_memberInfo is FieldInfo))
				{
					return ((PropertyInfo)this.m_memberInfo).PropertyType;
				}
				return ((FieldInfo)this.m_memberInfo).FieldType;
			}
		}

		/// <summary>Gets the attribute member that would be used to set the named argument.</summary>
		/// <returns>The attribute member that would be used to set the named argument.</returns>
		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x06004431 RID: 17457 RVA: 0x000FA3A7 File Offset: 0x000F85A7
		public MemberInfo MemberInfo
		{
			get
			{
				return this.m_memberInfo;
			}
		}

		/// <summary>Gets a <see cref="T:System.Reflection.CustomAttributeTypedArgument" /> structure that can be used to obtain the type and value of the current named argument.</summary>
		/// <returns>A structure that can be used to obtain the type and value of the current named argument.</returns>
		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x06004432 RID: 17458 RVA: 0x000FA3AF File Offset: 0x000F85AF
		[__DynamicallyInvokable]
		public CustomAttributeTypedArgument TypedValue
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_value;
			}
		}

		/// <summary>Gets the name of the attribute member that would be used to set the named argument.</summary>
		/// <returns>The name of the attribute member that would be used to set the named argument.</returns>
		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06004433 RID: 17459 RVA: 0x000FA3B7 File Offset: 0x000F85B7
		[__DynamicallyInvokable]
		public string MemberName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberInfo.Name;
			}
		}

		/// <summary>Gets a value that indicates whether the named argument is a field.</summary>
		/// <returns>
		///   <see langword="true" /> if the named argument is a field; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06004434 RID: 17460 RVA: 0x000FA3C4 File Offset: 0x000F85C4
		[__DynamicallyInvokable]
		public bool IsField
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberInfo is FieldInfo;
			}
		}

		// Token: 0x04001BA5 RID: 7077
		private MemberInfo m_memberInfo;

		// Token: 0x04001BA6 RID: 7078
		private CustomAttributeTypedArgument m_value;
	}
}
