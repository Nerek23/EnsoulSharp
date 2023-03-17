using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Runtime.DesignerServices
{
	/// <summary>Provides customized assembly binding for designers that are used to create Windows 8.x Store apps.</summary>
	// Token: 0x020006EE RID: 1774
	public sealed class WindowsRuntimeDesignerContext
	{
		// Token: 0x06005019 RID: 20505
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern IntPtr CreateDesignerContext([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] paths, int count, bool shared);

		// Token: 0x0600501A RID: 20506 RVA: 0x00119C2C File Offset: 0x00117E2C
		[SecurityCritical]
		internal static IntPtr CreateDesignerContext(IEnumerable<string> paths, [MarshalAs(UnmanagedType.Bool)] bool shared)
		{
			List<string> list = new List<string>(paths);
			string[] array = list.ToArray();
			foreach (string text in array)
			{
				if (text == null)
				{
					throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_Path"));
				}
				if (Path.IsRelative(text))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_AbsolutePathRequired"));
				}
			}
			return WindowsRuntimeDesignerContext.CreateDesignerContext(array, array.Length, shared);
		}

		// Token: 0x0600501B RID: 20507
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetCurrentContext([MarshalAs(UnmanagedType.Bool)] bool isDesignerContext, IntPtr context);

		// Token: 0x0600501C RID: 20508 RVA: 0x00119C94 File Offset: 0x00117E94
		[SecurityCritical]
		private WindowsRuntimeDesignerContext(IEnumerable<string> paths, string name, bool designModeRequired)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (paths == null)
			{
				throw new ArgumentNullException("paths");
			}
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (!AppDomain.IsAppXModel())
			{
				throw new NotSupportedException();
			}
			if (designModeRequired && !AppDomain.IsAppXDesignMode())
			{
				throw new NotSupportedException();
			}
			this.m_name = name;
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				if (WindowsRuntimeDesignerContext.s_sharedContext == IntPtr.Zero)
				{
					WindowsRuntimeDesignerContext.InitializeSharedContext(new string[0]);
				}
			}
			this.m_contextObject = WindowsRuntimeDesignerContext.CreateDesignerContext(paths, false);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.DesignerServices.WindowsRuntimeDesignerContext" /> class, specifying the set of paths to search for third-party Windows Runtime types and for managed assemblies, and specifying the name of the context.</summary>
		/// <param name="paths">The paths to search.</param>
		/// <param name="name">The name of the context.</param>
		/// <exception cref="T:System.NotSupportedException">The current application domain is not the default application domain.  
		///  -or-  
		///  The process is not running in the app container.  
		///  -or-  
		///  The computer does not have a developer license.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="paths" /> is <see langword="null" />.</exception>
		// Token: 0x0600501D RID: 20509 RVA: 0x00119D50 File Offset: 0x00117F50
		[SecurityCritical]
		public WindowsRuntimeDesignerContext(IEnumerable<string> paths, string name) : this(paths, name, true)
		{
		}

		/// <summary>Creates a context and sets it as the shared context.</summary>
		/// <param name="paths">An enumerable collection of paths that are used to resolve binding requests that cannot be satisfied by the iteration context.</param>
		/// <exception cref="T:System.NotSupportedException">The shared context has already been set in this application domain.  
		///  -or-  
		///  The current application domain is not the default application domain.  
		///  -or-  
		///  The process is not running in the app container.  
		///  -or-  
		///  The computer does not have a developer license.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="paths" /> is <see langword="null" />.</exception>
		// Token: 0x0600501E RID: 20510 RVA: 0x00119D5C File Offset: 0x00117F5C
		[SecurityCritical]
		public static void InitializeSharedContext(IEnumerable<string> paths)
		{
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (paths == null)
			{
				throw new ArgumentNullException("paths");
			}
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				if (WindowsRuntimeDesignerContext.s_sharedContext != IntPtr.Zero)
				{
					throw new NotSupportedException();
				}
				IntPtr context = WindowsRuntimeDesignerContext.CreateDesignerContext(paths, true);
				WindowsRuntimeDesignerContext.SetCurrentContext(false, context);
				WindowsRuntimeDesignerContext.s_sharedContext = context;
			}
		}

		/// <summary>Sets a context to handle iterations of assembly binding requests, as assemblies are recompiled during the design process.</summary>
		/// <param name="context">The context that handles iterations of assembly binding requests.</param>
		/// <exception cref="T:System.NotSupportedException">The current application domain is not the default application domain.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="context" /> is <see langword="null" />.</exception>
		// Token: 0x0600501F RID: 20511 RVA: 0x00119DE4 File Offset: 0x00117FE4
		[SecurityCritical]
		public static void SetIterationContext(WindowsRuntimeDesignerContext context)
		{
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				WindowsRuntimeDesignerContext.SetCurrentContext(true, context.m_contextObject);
			}
		}

		/// <summary>Loads the specified assembly from the current context.</summary>
		/// <param name="assemblyName">The full name of the assembly to load. For a description of full assembly names, see the <see cref="P:System.Reflection.Assembly.FullName" /> property.</param>
		/// <returns>The assembly, if it is found in the current context; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005020 RID: 20512 RVA: 0x00119E4C File Offset: 0x0011804C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Assembly GetAssembly(string assemblyName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyName, null, ref stackCrawlMark, this.m_contextObject, false);
		}

		/// <summary>Loads the specified type from the current context.</summary>
		/// <param name="typeName">The assembly-qualified name of the type to load. For a description of assembly-qualified names, see the <see cref="P:System.Type.AssemblyQualifiedName" /> property.</param>
		/// <returns>The type, if it is found in the current context; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005021 RID: 20513 RVA: 0x00119E6C File Offset: 0x0011806C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Type GetType(string typeName)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeTypeHandle.GetTypeByName(typeName, false, false, false, ref stackCrawlMark, this.m_contextObject, false);
		}

		/// <summary>Gets the name of the designer binding context.</summary>
		/// <returns>The name of the context.</returns>
		// Token: 0x17000D44 RID: 3396
		// (get) Token: 0x06005022 RID: 20514 RVA: 0x00119E9B File Offset: 0x0011809B
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x04002342 RID: 9026
		private static object s_lock = new object();

		// Token: 0x04002343 RID: 9027
		private static IntPtr s_sharedContext;

		// Token: 0x04002344 RID: 9028
		private IntPtr m_contextObject;

		// Token: 0x04002345 RID: 9029
		private string m_name;
	}
}
