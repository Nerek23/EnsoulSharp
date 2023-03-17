﻿using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.BIND_OPTS" /> instead.</summary>
	// Token: 0x0200094E RID: 2382
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IBindCtx instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("0000000e-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIBindCtx
	{
		/// <summary>Register the passed object as one of the objects that has been bound during a moniker operation and which should be released when it is complete.</summary>
		/// <param name="punk">The object to register for release.</param>
		// Token: 0x0600615A RID: 24922
		void RegisterObjectBound([MarshalAs(UnmanagedType.Interface)] object punk);

		/// <summary>Removes the object from the set of registered objects that need to be released.</summary>
		/// <param name="punk">The object to unregister for release.</param>
		// Token: 0x0600615B RID: 24923
		void RevokeObjectBound([MarshalAs(UnmanagedType.Interface)] object punk);

		/// <summary>Releases all the objects currently registered with the bind context by <see cref="M:System.Runtime.InteropServices.UCOMIBindCtx.RegisterObjectBound(System.Object)" />.</summary>
		// Token: 0x0600615C RID: 24924
		void ReleaseBoundObjects();

		/// <summary>Store in the bind context a block of parameters that will apply to later <see langword="UCOMIMoniker" /> operations using this bind context.</summary>
		/// <param name="pbindopts">The structure containing the binding options to set.</param>
		// Token: 0x0600615D RID: 24925
		void SetBindOptions([In] ref BIND_OPTS pbindopts);

		/// <summary>Return the current binding options stored in this bind context.</summary>
		/// <param name="pbindopts">A pointer to the structure to receive the binding options.</param>
		// Token: 0x0600615E RID: 24926
		void GetBindOptions(ref BIND_OPTS pbindopts);

		/// <summary>Return access to the Running Object Table (ROT) relevant to this binding process.</summary>
		/// <param name="pprot">On successful return, a reference to the ROT.</param>
		// Token: 0x0600615F RID: 24927
		void GetRunningObjectTable(out UCOMIRunningObjectTable pprot);

		/// <summary>Register the given object pointer under the specified name in the internally-maintained table of object pointers.</summary>
		/// <param name="pszKey">The name to register <paramref name="punk" /> with.</param>
		/// <param name="punk">The object to register.</param>
		// Token: 0x06006160 RID: 24928
		void RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] object punk);

		/// <summary>Lookup the given key in the internally-maintained table of contextual object parameters and return the corresponding object, if one exists.</summary>
		/// <param name="pszKey">The name of the object to search for.</param>
		/// <param name="ppunk">On successful return, the object interface pointer.</param>
		// Token: 0x06006161 RID: 24929
		void GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

		/// <summary>Enumerate the strings which are the keys of the internally-maintained table of contextual object parameters.</summary>
		/// <param name="ppenum">On successful return, a reference to the object parameter enumerator.</param>
		// Token: 0x06006162 RID: 24930
		void EnumObjectParam(out UCOMIEnumString ppenum);

		/// <summary>Revoke the registration of the object currently found under this key in the internally-maintained table of contextual object parameters, if any such key is currently registered.</summary>
		/// <param name="pszKey">The key to unregister.</param>
		// Token: 0x06006163 RID: 24931
		void RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
	}
}
