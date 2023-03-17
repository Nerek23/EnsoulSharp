using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	/// <summary>Provides the base functionality for writing resources to an output file or stream.</summary>
	// Token: 0x02000362 RID: 866
	[ComVisible(true)]
	public interface IResourceWriter : IDisposable
	{
		/// <summary>Adds a named resource of type <see cref="T:System.String" /> to the list of resources to be written.</summary>
		/// <param name="name">The name of the resource.</param>
		/// <param name="value">The value of the resource.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002BCE RID: 11214
		void AddResource(string name, string value);

		/// <summary>Adds a named resource of type <see cref="T:System.Object" /> to the list of resources to be written.</summary>
		/// <param name="name">The name of the resource.</param>
		/// <param name="value">The value of the resource.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002BCF RID: 11215
		void AddResource(string name, object value);

		/// <summary>Adds an 8-bit unsigned integer array as a named resource to the list of resources to be written.</summary>
		/// <param name="name">Name of a resource.</param>
		/// <param name="value">Value of a resource as an 8-bit unsigned integer array.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002BD0 RID: 11216
		void AddResource(string name, byte[] value);

		/// <summary>Closes the underlying resource file or stream, ensuring all the data has been written to the file.</summary>
		// Token: 0x06002BD1 RID: 11217
		void Close();

		/// <summary>Writes all the resources added by the <see cref="M:System.Resources.IResourceWriter.AddResource(System.String,System.String)" /> method to the output file or stream.</summary>
		// Token: 0x06002BD2 RID: 11218
		void Generate();
	}
}
