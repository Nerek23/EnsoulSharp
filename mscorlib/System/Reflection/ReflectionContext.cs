using System;

namespace System.Reflection
{
	/// <summary>Represents a context that can provide reflection objects.</summary>
	// Token: 0x020005F0 RID: 1520
	[__DynamicallyInvokable]
	public abstract class ReflectionContext
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ReflectionContext" /> class.</summary>
		// Token: 0x0600477E RID: 18302 RVA: 0x00102ACA File Offset: 0x00100CCA
		[__DynamicallyInvokable]
		protected ReflectionContext()
		{
		}

		/// <summary>Gets the representation, in this reflection context, of an assembly that is represented by an object from another reflection context.</summary>
		/// <param name="assembly">The external representation of the assembly to represent in this context.</param>
		/// <returns>The representation of the assembly in this reflection context.</returns>
		// Token: 0x0600477F RID: 18303
		[__DynamicallyInvokable]
		public abstract Assembly MapAssembly(Assembly assembly);

		/// <summary>Gets the representation, in this reflection context, of a type represented by an object from another reflection context.</summary>
		/// <param name="type">The external representation of the type to represent in this context.</param>
		/// <returns>The representation of the type in this reflection context.</returns>
		// Token: 0x06004780 RID: 18304
		[__DynamicallyInvokable]
		public abstract TypeInfo MapType(TypeInfo type);

		/// <summary>Gets the representation of the type of the specified object in this reflection context.</summary>
		/// <param name="value">The object to represent.</param>
		/// <returns>An object that represents the type of the specified object.</returns>
		// Token: 0x06004781 RID: 18305 RVA: 0x00102AD2 File Offset: 0x00100CD2
		[__DynamicallyInvokable]
		public virtual TypeInfo GetTypeForObject(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return this.MapType(value.GetType().GetTypeInfo());
		}
	}
}
