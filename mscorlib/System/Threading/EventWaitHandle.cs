using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	/// <summary>Represents a thread synchronization event.</summary>
	// Token: 0x020004C7 RID: 1223
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class EventWaitHandle : WaitHandle
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.EventWaitHandle" /> class, specifying whether the wait handle is initially signaled, and whether it resets automatically or manually.</summary>
		/// <param name="initialState">
		///   <see langword="true" /> to set the initial state to signaled; <see langword="false" /> to set it to nonsignaled.</param>
		/// <param name="mode">One of the <see cref="T:System.Threading.EventResetMode" /> values that determines whether the event resets automatically or manually.</param>
		// Token: 0x06003AB9 RID: 15033 RVA: 0x000DE3FE File Offset: 0x000DC5FE
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public EventWaitHandle(bool initialState, EventResetMode mode) : this(initialState, mode, null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.EventWaitHandle" /> class, specifying whether the wait handle is initially signaled if created as a result of this call, whether it resets automatically or manually, and the name of a system synchronization event.</summary>
		/// <param name="initialState">
		///   <see langword="true" /> to set the initial state to signaled if the named event is created as a result of this call; <see langword="false" /> to set it to nonsignaled.</param>
		/// <param name="mode">One of the <see cref="T:System.Threading.EventResetMode" /> values that determines whether the event resets automatically or manually.</param>
		/// <param name="name">The name of a system-wide synchronization event.</param>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists and has access control security, but the user does not have <see cref="F:System.Security.AccessControl.EventWaitHandleRights.FullControl" />.</exception>
		/// <exception cref="T:System.Threading.WaitHandleCannotBeOpenedException">The named event cannot be created, perhaps because a wait handle of a different type has the same name.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is longer than 260 characters.</exception>
		// Token: 0x06003ABA RID: 15034 RVA: 0x000DE40C File Offset: 0x000DC60C
		[SecurityCritical]
		[__DynamicallyInvokable]
		public EventWaitHandle(bool initialState, EventResetMode mode, string name)
		{
			if (name != null && 260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			SafeWaitHandle safeWaitHandle;
			if (mode != EventResetMode.AutoReset)
			{
				if (mode != EventResetMode.ManualReset)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFlag", new object[]
					{
						name
					}));
				}
				safeWaitHandle = Win32Native.CreateEvent(null, true, initialState, name);
			}
			else
			{
				safeWaitHandle = Win32Native.CreateEvent(null, false, initialState, name);
			}
			if (safeWaitHandle.IsInvalid)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				safeWaitHandle.SetHandleAsInvalid();
				if (name != null && name.Length != 0 && 6 == lastWin32Error)
				{
					throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
					{
						name
					}));
				}
				__Error.WinIOError(lastWin32Error, name);
			}
			base.SetHandleInternal(safeWaitHandle);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.EventWaitHandle" /> class, specifying whether the wait handle is initially signaled if created as a result of this call, whether it resets automatically or manually, the name of a system synchronization event, and a Boolean variable whose value after the call indicates whether the named system event was created.</summary>
		/// <param name="initialState">
		///   <see langword="true" /> to set the initial state to signaled if the named event is created as a result of this call; <see langword="false" /> to set it to nonsignaled.</param>
		/// <param name="mode">One of the <see cref="T:System.Threading.EventResetMode" /> values that determines whether the event resets automatically or manually.</param>
		/// <param name="name">The name of a system-wide synchronization event.</param>
		/// <param name="createdNew">When this method returns, contains <see langword="true" /> if a local event was created (that is, if <paramref name="name" /> is <see langword="null" /> or an empty string) or if the specified named system event was created; <see langword="false" /> if the specified named system event already existed. This parameter is passed uninitialized.</param>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists and has access control security, but the user does not have <see cref="F:System.Security.AccessControl.EventWaitHandleRights.FullControl" />.</exception>
		/// <exception cref="T:System.Threading.WaitHandleCannotBeOpenedException">The named event cannot be created, perhaps because a wait handle of a different type has the same name.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is longer than 260 characters.</exception>
		// Token: 0x06003ABB RID: 15035 RVA: 0x000DE4CF File Offset: 0x000DC6CF
		[SecurityCritical]
		[__DynamicallyInvokable]
		public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew) : this(initialState, mode, name, out createdNew, null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.EventWaitHandle" /> class, specifying whether the wait handle is initially signaled if created as a result of this call, whether it resets automatically or manually, the name of a system synchronization event, a Boolean variable whose value after the call indicates whether the named system event was created, and the access control security to be applied to the named event if it is created.</summary>
		/// <param name="initialState">
		///   <see langword="true" /> to set the initial state to signaled if the named event is created as a result of this call; <see langword="false" /> to set it to nonsignaled.</param>
		/// <param name="mode">One of the <see cref="T:System.Threading.EventResetMode" /> values that determines whether the event resets automatically or manually.</param>
		/// <param name="name">The name of a system-wide synchronization event.</param>
		/// <param name="createdNew">When this method returns, contains <see langword="true" /> if a local event was created (that is, if <paramref name="name" /> is <see langword="null" /> or an empty string) or if the specified named system event was created; <see langword="false" /> if the specified named system event already existed. This parameter is passed uninitialized.</param>
		/// <param name="eventSecurity">An <see cref="T:System.Security.AccessControl.EventWaitHandleSecurity" /> object that represents the access control security to be applied to the named system event.</param>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists and has access control security, but the user does not have <see cref="F:System.Security.AccessControl.EventWaitHandleRights.FullControl" />.</exception>
		/// <exception cref="T:System.Threading.WaitHandleCannotBeOpenedException">The named event cannot be created, perhaps because a wait handle of a different type has the same name.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is longer than 260 characters.</exception>
		// Token: 0x06003ABC RID: 15036 RVA: 0x000DE4E0 File Offset: 0x000DC6E0
		[SecurityCritical]
		public unsafe EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew, EventWaitHandleSecurity eventSecurity)
		{
			if (name != null && 260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			Win32Native.SECURITY_ATTRIBUTES security_ATTRIBUTES = null;
			if (eventSecurity != null)
			{
				security_ATTRIBUTES = new Win32Native.SECURITY_ATTRIBUTES();
				security_ATTRIBUTES.nLength = Marshal.SizeOf<Win32Native.SECURITY_ATTRIBUTES>(security_ATTRIBUTES);
				byte[] securityDescriptorBinaryForm = eventSecurity.GetSecurityDescriptorBinaryForm();
				byte* ptr = stackalloc byte[checked(unchecked((UIntPtr)securityDescriptorBinaryForm.Length) * 1)];
				Buffer.Memcpy(ptr, 0, securityDescriptorBinaryForm, 0, securityDescriptorBinaryForm.Length);
				security_ATTRIBUTES.pSecurityDescriptor = ptr;
			}
			bool isManualReset;
			if (mode != EventResetMode.AutoReset)
			{
				if (mode != EventResetMode.ManualReset)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFlag", new object[]
					{
						name
					}));
				}
				isManualReset = true;
			}
			else
			{
				isManualReset = false;
			}
			SafeWaitHandle safeWaitHandle = Win32Native.CreateEvent(security_ATTRIBUTES, isManualReset, initialState, name);
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (safeWaitHandle.IsInvalid)
			{
				safeWaitHandle.SetHandleAsInvalid();
				if (name != null && name.Length != 0 && 6 == lastWin32Error)
				{
					throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
					{
						name
					}));
				}
				__Error.WinIOError(lastWin32Error, name);
			}
			createdNew = (lastWin32Error != 183);
			base.SetHandleInternal(safeWaitHandle);
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x000DE5EE File Offset: 0x000DC7EE
		[SecurityCritical]
		private EventWaitHandle(SafeWaitHandle handle)
		{
			base.SetHandleInternal(handle);
		}

		/// <summary>Opens the specified named synchronization event, if it already exists.</summary>
		/// <param name="name">The name of the system synchronization event to open.</param>
		/// <returns>An  object that represents the named system event.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is an empty string.  
		/// -or-  
		/// <paramref name="name" /> is longer than 260 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.WaitHandleCannotBeOpenedException">The named system event does not exist.</exception>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists, but the user does not have the security access required to use it.</exception>
		// Token: 0x06003ABE RID: 15038 RVA: 0x000DE5FD File Offset: 0x000DC7FD
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static EventWaitHandle OpenExisting(string name)
		{
			return EventWaitHandle.OpenExisting(name, EventWaitHandleRights.Modify | EventWaitHandleRights.Synchronize);
		}

		/// <summary>Opens the specified named synchronization event, if it already exists, with the desired security access.</summary>
		/// <param name="name">The name of the system synchronization event to open.</param>
		/// <param name="rights">A bitwise combination of the enumeration values that represent the desired security access.</param>
		/// <returns>An object that represents the named system event.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is an empty string.  
		/// -or-  
		/// <paramref name="name" /> is longer than 260 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.WaitHandleCannotBeOpenedException">The named system event does not exist.</exception>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists, but the user does not have the desired security access.</exception>
		// Token: 0x06003ABF RID: 15039 RVA: 0x000DE60C File Offset: 0x000DC80C
		[SecurityCritical]
		public static EventWaitHandle OpenExisting(string name, EventWaitHandleRights rights)
		{
			EventWaitHandle result;
			switch (EventWaitHandle.OpenExistingWorker(name, rights, out result))
			{
			case WaitHandle.OpenExistingResult.NameNotFound:
				throw new WaitHandleCannotBeOpenedException();
			case WaitHandle.OpenExistingResult.PathNotFound:
				__Error.WinIOError(3, "");
				return result;
			case WaitHandle.OpenExistingResult.NameInvalid:
				throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
				{
					name
				}));
			default:
				return result;
			}
		}

		/// <summary>Opens the specified named synchronization event, if it already exists, and returns a value that indicates whether the operation succeeded.</summary>
		/// <param name="name">The name of the system synchronization event to open.</param>
		/// <param name="result">When this method returns, contains a <see cref="T:System.Threading.EventWaitHandle" /> object that represents the named synchronization event if the call succeeded, or <see langword="null" /> if the call failed. This parameter is treated as uninitialized.</param>
		/// <returns>
		///   <see langword="true" /> if the named synchronization event was opened successfully; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is an empty string.  
		/// -or-  
		/// <paramref name="name" /> is longer than 260 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists, but the user does not have the desired security access.</exception>
		// Token: 0x06003AC0 RID: 15040 RVA: 0x000DE667 File Offset: 0x000DC867
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static bool TryOpenExisting(string name, out EventWaitHandle result)
		{
			return EventWaitHandle.OpenExistingWorker(name, EventWaitHandleRights.Modify | EventWaitHandleRights.Synchronize, out result) == WaitHandle.OpenExistingResult.Success;
		}

		/// <summary>Opens the specified named synchronization event, if it already exists, with the desired security access, and returns a value that indicates whether the operation succeeded.</summary>
		/// <param name="name">The name of the system synchronization event to open.</param>
		/// <param name="rights">A bitwise combination of the enumeration values that represent the desired security access.</param>
		/// <param name="result">When this method returns, contains a <see cref="T:System.Threading.EventWaitHandle" /> object that represents the named synchronization event if the call succeeded, or <see langword="null" /> if the call failed. This parameter is treated as uninitialized.</param>
		/// <returns>
		///   <see langword="true" /> if the named synchronization event was opened successfully; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is an empty string.  
		/// -or-  
		/// <paramref name="name" /> is longer than 260 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.IOException">A Win32 error occurred.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The named event exists, but the user does not have the desired security access.</exception>
		// Token: 0x06003AC1 RID: 15041 RVA: 0x000DE678 File Offset: 0x000DC878
		[SecurityCritical]
		public static bool TryOpenExisting(string name, EventWaitHandleRights rights, out EventWaitHandle result)
		{
			return EventWaitHandle.OpenExistingWorker(name, rights, out result) == WaitHandle.OpenExistingResult.Success;
		}

		// Token: 0x06003AC2 RID: 15042 RVA: 0x000DE688 File Offset: 0x000DC888
		[SecurityCritical]
		private static WaitHandle.OpenExistingResult OpenExistingWorker(string name, EventWaitHandleRights rights, out EventWaitHandle result)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", Environment.GetResourceString("ArgumentNull_WithParamName"));
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (name != null && 260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			result = null;
			SafeWaitHandle safeWaitHandle = Win32Native.OpenEvent((int)rights, false, name);
			if (safeWaitHandle.IsInvalid)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (2 == lastWin32Error || 123 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.NameNotFound;
				}
				if (3 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.PathNotFound;
				}
				if (name != null && name.Length != 0 && 6 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.NameInvalid;
				}
				__Error.WinIOError(lastWin32Error, "");
			}
			result = new EventWaitHandle(safeWaitHandle);
			return WaitHandle.OpenExistingResult.Success;
		}

		/// <summary>Sets the state of the event to nonsignaled, causing threads to block.</summary>
		/// <returns>
		///   <see langword="true" /> if the operation succeeds; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="M:System.Threading.WaitHandle.Close" /> method was previously called on this <see cref="T:System.Threading.EventWaitHandle" />.</exception>
		// Token: 0x06003AC3 RID: 15043 RVA: 0x000DE744 File Offset: 0x000DC944
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public bool Reset()
		{
			bool flag = Win32Native.ResetEvent(this.safeWaitHandle);
			if (!flag)
			{
				__Error.WinIOError();
			}
			return flag;
		}

		/// <summary>Sets the state of the event to signaled, allowing one or more waiting threads to proceed.</summary>
		/// <returns>
		///   <see langword="true" /> if the operation succeeds; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="M:System.Threading.WaitHandle.Close" /> method was previously called on this <see cref="T:System.Threading.EventWaitHandle" />.</exception>
		// Token: 0x06003AC4 RID: 15044 RVA: 0x000DE768 File Offset: 0x000DC968
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public bool Set()
		{
			bool flag = Win32Native.SetEvent(this.safeWaitHandle);
			if (!flag)
			{
				__Error.WinIOError();
			}
			return flag;
		}

		/// <summary>Gets an <see cref="T:System.Security.AccessControl.EventWaitHandleSecurity" /> object that represents the access control security for the named system event represented by the current <see cref="T:System.Threading.EventWaitHandle" /> object.</summary>
		/// <returns>An <see cref="T:System.Security.AccessControl.EventWaitHandleSecurity" /> object that represents the access control security for the named system event.</returns>
		/// <exception cref="T:System.UnauthorizedAccessException">The current <see cref="T:System.Threading.EventWaitHandle" /> object represents a named system event, and the user does not have <see cref="F:System.Security.AccessControl.EventWaitHandleRights.ReadPermissions" />.  
		///  -or-  
		///  The current <see cref="T:System.Threading.EventWaitHandle" /> object represents a named system event, and was not opened with <see cref="F:System.Security.AccessControl.EventWaitHandleRights.ReadPermissions" />.</exception>
		/// <exception cref="T:System.NotSupportedException">Not supported for Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="M:System.Threading.WaitHandle.Close" /> method was previously called on this <see cref="T:System.Threading.EventWaitHandle" />.</exception>
		// Token: 0x06003AC5 RID: 15045 RVA: 0x000DE78C File Offset: 0x000DC98C
		[SecuritySafeCritical]
		public EventWaitHandleSecurity GetAccessControl()
		{
			return new EventWaitHandleSecurity(this.safeWaitHandle, AccessControlSections.Access | AccessControlSections.Owner | AccessControlSections.Group);
		}

		/// <summary>Sets the access control security for a named system event.</summary>
		/// <param name="eventSecurity">An <see cref="T:System.Security.AccessControl.EventWaitHandleSecurity" /> object that represents the access control security to be applied to the named system event.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="eventSecurity" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The user does not have <see cref="F:System.Security.AccessControl.EventWaitHandleRights.ChangePermissions" />.  
		///  -or-  
		///  The event was not opened with <see cref="F:System.Security.AccessControl.EventWaitHandleRights.ChangePermissions" />.</exception>
		/// <exception cref="T:System.SystemException">The current <see cref="T:System.Threading.EventWaitHandle" /> object does not represent a named system event.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="M:System.Threading.WaitHandle.Close" /> method was previously called on this <see cref="T:System.Threading.EventWaitHandle" />.</exception>
		// Token: 0x06003AC6 RID: 15046 RVA: 0x000DE79D File Offset: 0x000DC99D
		[SecuritySafeCritical]
		public void SetAccessControl(EventWaitHandleSecurity eventSecurity)
		{
			if (eventSecurity == null)
			{
				throw new ArgumentNullException("eventSecurity");
			}
			eventSecurity.Persist(this.safeWaitHandle);
		}
	}
}
