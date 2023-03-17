using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides support for user customization of interop stubs in managed-to-COM interop scenarios.</summary>
	// Token: 0x02000914 RID: 2324
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class ManagedToNativeComInteropStubAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ManagedToNativeComInteropStubAttribute" /> class with the specified class type and method name.</summary>
		/// <param name="classType">The class that contains the required stub method.</param>
		/// <param name="methodName">The name of the stub method.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="methodName" /> cannot be found.  
		/// -or-  
		/// The method is not static or non-generic.  
		/// -or-  
		/// The method's parameter list does not match the expected parameter list for the stub.</exception>
		/// <exception cref="T:System.MethodAccessException">The interface that contains the managed interop method has no access to the stub method, because the stub method has private or protected accessibility, or because of a security issue.</exception>
		// Token: 0x06005F45 RID: 24389 RVA: 0x0014749F File Offset: 0x0014569F
		public ManagedToNativeComInteropStubAttribute(Type classType, string methodName)
		{
			this._classType = classType;
			this._methodName = methodName;
		}

		/// <summary>Gets the class that contains the required stub method.</summary>
		/// <returns>The class that contains the customized interop stub.</returns>
		// Token: 0x170010DD RID: 4317
		// (get) Token: 0x06005F46 RID: 24390 RVA: 0x001474B5 File Offset: 0x001456B5
		public Type ClassType
		{
			get
			{
				return this._classType;
			}
		}

		/// <summary>Gets the name of the stub method.</summary>
		/// <returns>The name of a customized interop stub.</returns>
		// Token: 0x170010DE RID: 4318
		// (get) Token: 0x06005F47 RID: 24391 RVA: 0x001474BD File Offset: 0x001456BD
		public string MethodName
		{
			get
			{
				return this._methodName;
			}
		}

		// Token: 0x04002A76 RID: 10870
		internal Type _classType;

		// Token: 0x04002A77 RID: 10871
		internal string _methodName;
	}
}
