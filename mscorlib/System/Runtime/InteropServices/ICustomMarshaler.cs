using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides custom wrappers for handling method calls.</summary>
	// Token: 0x0200091E RID: 2334
	[ComVisible(true)]
	public interface ICustomMarshaler
	{
		/// <summary>Converts the unmanaged data to managed data.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
		/// <returns>An object that represents the managed view of the COM data.</returns>
		// Token: 0x06005F8E RID: 24462
		object MarshalNativeToManaged(IntPtr pNativeData);

		/// <summary>Converts the managed data to unmanaged data.</summary>
		/// <param name="ManagedObj">The managed object to be converted.</param>
		/// <returns>A pointer to the COM view of the managed object.</returns>
		// Token: 0x06005F8F RID: 24463
		IntPtr MarshalManagedToNative(object ManagedObj);

		/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
		// Token: 0x06005F90 RID: 24464
		void CleanUpNativeData(IntPtr pNativeData);

		/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
		/// <param name="ManagedObj">The managed object to be destroyed.</param>
		// Token: 0x06005F91 RID: 24465
		void CleanUpManagedData(object ManagedObj);

		/// <summary>Returns the size of the native data to be marshaled.</summary>
		/// <returns>The size, in bytes, of the native data.</returns>
		// Token: 0x06005F92 RID: 24466
		int GetNativeDataSize();
	}
}
