using System;

namespace System.Reflection
{
	/// <summary>Contains methods for converting <see cref="T:System.Type" /> objects.</summary>
	// Token: 0x020005BF RID: 1471
	[__DynamicallyInvokable]
	public static class IntrospectionExtensions
	{
		/// <summary>Returns the <see cref="T:System.Reflection.TypeInfo" /> representation of the specified type.</summary>
		/// <param name="type">The type to convert.</param>
		/// <returns>The converted object.</returns>
		// Token: 0x06004533 RID: 17715 RVA: 0x000FDAE8 File Offset: 0x000FBCE8
		[__DynamicallyInvokable]
		public static TypeInfo GetTypeInfo(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			IReflectableType reflectableType = (IReflectableType)type;
			if (reflectableType == null)
			{
				return null;
			}
			return reflectableType.GetTypeInfo();
		}
	}
}
