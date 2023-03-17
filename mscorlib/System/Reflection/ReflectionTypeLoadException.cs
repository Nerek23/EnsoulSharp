using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	/// <summary>The exception that is thrown by the <see cref="M:System.Reflection.Module.GetTypes" /> method if any of the classes in a module cannot be loaded. This class cannot be inherited.</summary>
	// Token: 0x020005F1 RID: 1521
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ReflectionTypeLoadException : SystemException, ISerializable
	{
		// Token: 0x06004782 RID: 18306 RVA: 0x00102AF3 File Offset: 0x00100CF3
		private ReflectionTypeLoadException() : base(Environment.GetResourceString("ReflectionTypeLoad_LoadFailed"))
		{
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x06004783 RID: 18307 RVA: 0x00102B10 File Offset: 0x00100D10
		private ReflectionTypeLoadException(string message) : base(message)
		{
			base.SetErrorCode(-2146232830);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ReflectionTypeLoadException" /> class with the given classes and their associated exceptions.</summary>
		/// <param name="classes">An array of type <see langword="Type" /> containing the classes that were defined in the module and loaded. This array can contain null reference (<see langword="Nothing" /> in Visual Basic) values.</param>
		/// <param name="exceptions">An array of type <see langword="Exception" /> containing the exceptions that were thrown by the class loader. The null reference (<see langword="Nothing" /> in Visual Basic) values in the <paramref name="classes" /> array line up with the exceptions in this <paramref name="exceptions" /> array.</param>
		// Token: 0x06004784 RID: 18308 RVA: 0x00102B24 File Offset: 0x00100D24
		[__DynamicallyInvokable]
		public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions) : base(null)
		{
			this._classes = classes;
			this._exceptions = exceptions;
			base.SetErrorCode(-2146232830);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ReflectionTypeLoadException" /> class with the given classes, their associated exceptions, and exception descriptions.</summary>
		/// <param name="classes">An array of type <see langword="Type" /> containing the classes that were defined in the module and loaded. This array can contain null reference (<see langword="Nothing" /> in Visual Basic) values.</param>
		/// <param name="exceptions">An array of type <see langword="Exception" /> containing the exceptions that were thrown by the class loader. The null reference (<see langword="Nothing" /> in Visual Basic) values in the <paramref name="classes" /> array line up with the exceptions in this <paramref name="exceptions" /> array.</param>
		/// <param name="message">A <see langword="String" /> describing the reason the exception was thrown.</param>
		// Token: 0x06004785 RID: 18309 RVA: 0x00102B46 File Offset: 0x00100D46
		[__DynamicallyInvokable]
		public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions, string message) : base(message)
		{
			this._classes = classes;
			this._exceptions = exceptions;
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x06004786 RID: 18310 RVA: 0x00102B68 File Offset: 0x00100D68
		internal ReflectionTypeLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._classes = (Type[])info.GetValue("Types", typeof(Type[]));
			this._exceptions = (Exception[])info.GetValue("Exceptions", typeof(Exception[]));
		}

		/// <summary>Gets the array of classes that were defined in the module and loaded.</summary>
		/// <returns>An array of type <see langword="Type" /> containing the classes that were defined in the module and loaded. This array can contain some <see langword="null" /> values.</returns>
		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06004787 RID: 18311 RVA: 0x00102BBD File Offset: 0x00100DBD
		[__DynamicallyInvokable]
		public Type[] Types
		{
			[__DynamicallyInvokable]
			get
			{
				return this._classes;
			}
		}

		/// <summary>Gets the array of exceptions thrown by the class loader.</summary>
		/// <returns>An array of type <see langword="Exception" /> containing the exceptions thrown by the class loader. The null values in the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types" /> array of this instance line up with the exceptions in this array.</returns>
		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x06004788 RID: 18312 RVA: 0x00102BC5 File Offset: 0x00100DC5
		[__DynamicallyInvokable]
		public Exception[] LoaderExceptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this._exceptions;
			}
		}

		/// <summary>Provides an <see cref="T:System.Runtime.Serialization.ISerializable" /> implementation for serialized objects.</summary>
		/// <param name="info">The information and data needed to serialize or deserialize an object.</param>
		/// <param name="context">The context for the serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <see langword="info" /> is <see langword="null" />.</exception>
		// Token: 0x06004789 RID: 18313 RVA: 0x00102BD0 File Offset: 0x00100DD0
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Types", this._classes, typeof(Type[]));
			info.AddValue("Exceptions", this._exceptions, typeof(Exception[]));
		}

		// Token: 0x04001D5C RID: 7516
		private Type[] _classes;

		// Token: 0x04001D5D RID: 7517
		private Exception[] _exceptions;
	}
}
