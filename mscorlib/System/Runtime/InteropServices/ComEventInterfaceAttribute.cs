using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Identifies the source interface and the class that implements the methods of the event interface that is generated when a coclass is imported from a COM type library.</summary>
	// Token: 0x0200090E RID: 2318
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComEventInterfaceAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ComEventInterfaceAttribute" /> class with the source interface and event provider class.</summary>
		/// <param name="SourceInterface">A <see cref="T:System.Type" /> that contains the original source interface from the type library. COM uses this interface to call back to the managed class.</param>
		/// <param name="EventProvider">A <see cref="T:System.Type" /> that contains the class that implements the methods of the event interface.</param>
		// Token: 0x06005F35 RID: 24373 RVA: 0x001473D8 File Offset: 0x001455D8
		[__DynamicallyInvokable]
		public ComEventInterfaceAttribute(Type SourceInterface, Type EventProvider)
		{
			this._SourceInterface = SourceInterface;
			this._EventProvider = EventProvider;
		}

		/// <summary>Gets the original source interface from the type library.</summary>
		/// <returns>A <see cref="T:System.Type" /> containing the source interface.</returns>
		// Token: 0x170010D3 RID: 4307
		// (get) Token: 0x06005F36 RID: 24374 RVA: 0x001473EE File Offset: 0x001455EE
		[__DynamicallyInvokable]
		public Type SourceInterface
		{
			[__DynamicallyInvokable]
			get
			{
				return this._SourceInterface;
			}
		}

		/// <summary>Gets the class that implements the methods of the event interface.</summary>
		/// <returns>A <see cref="T:System.Type" /> that contains the class that implements the methods of the event interface.</returns>
		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x06005F37 RID: 24375 RVA: 0x001473F6 File Offset: 0x001455F6
		[__DynamicallyInvokable]
		public Type EventProvider
		{
			[__DynamicallyInvokable]
			get
			{
				return this._EventProvider;
			}
		}

		// Token: 0x04002A6B RID: 10859
		internal Type _SourceInterface;

		// Token: 0x04002A6C RID: 10860
		internal Type _EventProvider;
	}
}
