using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Diagnostics
{
	/// <summary>Enables communication with a debugger. This class cannot be inherited.</summary>
	// Token: 0x020003B9 RID: 953
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class Debugger
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Debugger" /> class.</summary>
		// Token: 0x060031D9 RID: 12761 RVA: 0x000C0045 File Offset: 0x000BE245
		[Obsolete("Do not create instances of the Debugger class.  Call the static methods directly on this type instead", true)]
		public Debugger()
		{
		}

		/// <summary>Signals a breakpoint to an attached debugger.</summary>
		/// <exception cref="T:System.Security.SecurityException">The <see cref="T:System.Security.Permissions.UIPermission" /> is not set to break into the debugger.</exception>
		// Token: 0x060031DA RID: 12762 RVA: 0x000C0050 File Offset: 0x000BE250
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void Break()
		{
			if (!Debugger.IsAttached)
			{
				try
				{
					new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				}
				catch (SecurityException)
				{
					return;
				}
			}
			Debugger.BreakInternal();
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x000C008C File Offset: 0x000BE28C
		[SecuritySafeCritical]
		private static void BreakCanThrow()
		{
			if (!Debugger.IsAttached)
			{
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			}
			Debugger.BreakInternal();
		}

		// Token: 0x060031DC RID: 12764
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BreakInternal();

		/// <summary>Launches and attaches a debugger to the process.</summary>
		/// <returns>
		///   <see langword="true" /> if the startup is successful or if the debugger is already attached; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The <see cref="T:System.Security.Permissions.UIPermission" /> is not set to start the debugger.</exception>
		// Token: 0x060031DD RID: 12765 RVA: 0x000C00A8 File Offset: 0x000BE2A8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static bool Launch()
		{
			if (Debugger.IsAttached)
			{
				return true;
			}
			try
			{
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			}
			catch (SecurityException)
			{
				return false;
			}
			return Debugger.LaunchInternal();
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000C00E8 File Offset: 0x000BE2E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void NotifyOfCrossThreadDependencySlow()
		{
			Debugger.CrossThreadDependencyNotification data = new Debugger.CrossThreadDependencyNotification();
			Debugger.CustomNotification(data);
			if (Debugger.s_triggerThreadAbortExceptionForDebugger)
			{
				throw new ThreadAbortException();
			}
		}

		/// <summary>Notifies a debugger that execution is about to enter a path that involves a cross-thread dependency.</summary>
		// Token: 0x060031DF RID: 12767 RVA: 0x000C010E File Offset: 0x000BE30E
		[ComVisible(false)]
		public static void NotifyOfCrossThreadDependency()
		{
			if (Debugger.IsAttached)
			{
				Debugger.NotifyOfCrossThreadDependencySlow();
			}
		}

		// Token: 0x060031E0 RID: 12768
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool LaunchInternal();

		/// <summary>Gets a value that indicates whether a debugger is attached to the process.</summary>
		/// <returns>
		///   <see langword="true" /> if a debugger is attached; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x060031E1 RID: 12769
		[__DynamicallyInvokable]
		public static extern bool IsAttached { [SecuritySafeCritical] [__DynamicallyInvokable] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		/// <summary>Posts a message for the attached debugger.</summary>
		/// <param name="level">A description of the importance of the message.</param>
		/// <param name="category">The category of the message.</param>
		/// <param name="message">The message to show.</param>
		// Token: 0x060031E2 RID: 12770
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Log(int level, string category, string message);

		/// <summary>Checks to see if logging is enabled by an attached debugger.</summary>
		/// <returns>
		///   <see langword="true" /> if a debugger is attached and logging is enabled; otherwise, <see langword="false" />. The attached debugger is the registered managed debugger in the <see langword="DbgManagedDebugger" /> registry key. For more information on this key, see Enabling JIT-Attach Debugging.</returns>
		// Token: 0x060031E3 RID: 12771
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsLogging();

		// Token: 0x060031E4 RID: 12772
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CustomNotification(ICustomDebuggerNotification data);

		// Token: 0x040015E5 RID: 5605
		private static bool s_triggerThreadAbortExceptionForDebugger;

		/// <summary>Represents the default category of message with a constant.</summary>
		// Token: 0x040015E6 RID: 5606
		public static readonly string DefaultCategory;

		// Token: 0x02000B49 RID: 2889
		private class CrossThreadDependencyNotification : ICustomDebuggerNotification
		{
		}
	}
}
