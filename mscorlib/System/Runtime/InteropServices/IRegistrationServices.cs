using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides a set of services for registering and unregistering managed assemblies for use from COM.</summary>
	// Token: 0x0200093D RID: 2365
	[Guid("CCBD682C-73A5-4568-B8B0-C7007E11ABA2")]
	[ComVisible(true)]
	public interface IRegistrationServices
	{
		/// <summary>Registers the classes in a managed assembly to enable creation from COM.</summary>
		/// <param name="assembly">The assembly to be registered.</param>
		/// <param name="flags">An <see cref="T:System.Runtime.InteropServices.AssemblyRegistrationFlags" /> value indicating any special settings needed when registering <paramref name="assembly" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="assembly" /> contains types that were successfully registered; otherwise <see langword="false" /> if the assembly contains no eligible types.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The full name of <paramref name="assembly" /> is <see langword="null" />.  
		///  -or-  
		///  A method marked with <see cref="T:System.Runtime.InteropServices.ComRegisterFunctionAttribute" /> is not <see langword="static" />.  
		///  -or-  
		///  There is more than one method marked with <see cref="T:System.Runtime.InteropServices.ComRegisterFunctionAttribute" /> at a given level of the hierarchy.  
		///  -or-  
		///  The signature of the method marked with <see cref="T:System.Runtime.InteropServices.ComRegisterFunctionAttribute" /> is not valid.</exception>
		// Token: 0x06006110 RID: 24848
		[SecurityCritical]
		bool RegisterAssembly(Assembly assembly, AssemblyRegistrationFlags flags);

		/// <summary>Unregisters the classes in a managed assembly.</summary>
		/// <param name="assembly">The assembly to be unregistered.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="assembly" /> contains types that were successfully unregistered; otherwise <see langword="false" /> if the assembly contains no eligible types.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The full name of <paramref name="assembly" /> is <see langword="null" />.  
		///  -or-  
		///  A method marked with <see cref="T:System.Runtime.InteropServices.ComUnregisterFunctionAttribute" /> is not <see langword="static" />.  
		///  -or-  
		///  There is more than one method marked with <see cref="T:System.Runtime.InteropServices.ComUnregisterFunctionAttribute" /> at a given level of the hierarchy.  
		///  -or-  
		///  The signature of the method marked with <see cref="T:System.Runtime.InteropServices.ComUnregisterFunctionAttribute" /> is not valid.</exception>
		// Token: 0x06006111 RID: 24849
		[SecurityCritical]
		bool UnregisterAssembly(Assembly assembly);

		/// <summary>Retrieves a list of classes in an assembly that would be registered by a call to <see cref="M:System.Runtime.InteropServices.IRegistrationServices.RegisterAssembly(System.Reflection.Assembly,System.Runtime.InteropServices.AssemblyRegistrationFlags)" />.</summary>
		/// <param name="assembly">The assembly to search for classes.</param>
		/// <returns>A <see cref="T:System.Type" /> array containing a list of classes in <paramref name="assembly" />.</returns>
		// Token: 0x06006112 RID: 24850
		[SecurityCritical]
		Type[] GetRegistrableTypesInAssembly(Assembly assembly);

		/// <summary>Retrieves the COM ProgID for a specified type.</summary>
		/// <param name="type">The type whose ProgID is being requested.</param>
		/// <returns>The ProgID for the specified type.</returns>
		// Token: 0x06006113 RID: 24851
		[SecurityCritical]
		string GetProgIdForType(Type type);

		/// <summary>Registers the specified type with COM using the specified GUID.</summary>
		/// <param name="type">The type to be registered for use from COM.</param>
		/// <param name="g">GUID used to register the specified type.</param>
		// Token: 0x06006114 RID: 24852
		[SecurityCritical]
		void RegisterTypeForComClients(Type type, ref Guid g);

		/// <summary>Returns the GUID of the COM category that contains the managed classes.</summary>
		/// <returns>The GUID of the COM category that contains the managed classes.</returns>
		// Token: 0x06006115 RID: 24853
		Guid GetManagedCategoryGuid();

		/// <summary>Determines whether the specified type requires registration.</summary>
		/// <param name="type">The type to check for COM registration requirements.</param>
		/// <returns>
		///   <see langword="true" /> if the type must be registered for use from COM; otherwise <see langword="false" />.</returns>
		// Token: 0x06006116 RID: 24854
		[SecurityCritical]
		bool TypeRequiresRegistration(Type type);

		/// <summary>Determines whether the specified type is a COM type.</summary>
		/// <param name="type">The type to determine if it is a COM type.</param>
		/// <returns>
		///   <see langword="true" /> if the specified type is a COM type; otherwise <see langword="false" />.</returns>
		// Token: 0x06006117 RID: 24855
		bool TypeRepresentsComType(Type type);
	}
}
