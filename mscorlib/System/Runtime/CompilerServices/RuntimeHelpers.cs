using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

namespace System.Runtime.CompilerServices
{
	/// <summary>Provides a set of static methods and properties that provide support for compilers. This class cannot be inherited.</summary>
	// Token: 0x0200087E RID: 2174
	[__DynamicallyInvokable]
	public static class RuntimeHelpers
	{
		/// <summary>Provides a fast way to initialize an array from data that is stored in a module.</summary>
		/// <param name="array">The array to be initialized.</param>
		/// <param name="fldHandle">A field handle that specifies the location of the data used to initialize the array.</param>
		// Token: 0x06005C65 RID: 23653
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void InitializeArray(Array array, RuntimeFieldHandle fldHandle);

		/// <summary>Boxes a value type.</summary>
		/// <param name="obj">The value type to be boxed.</param>
		/// <returns>A boxed copy of <paramref name="obj" /> if it is a value class; otherwise, <paramref name="obj" /> itself.</returns>
		// Token: 0x06005C66 RID: 23654
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetObjectValue(object obj);

		// Token: 0x06005C67 RID: 23655
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _RunClassConstructor(RuntimeType type);

		/// <summary>Runs a specified class constructor method.</summary>
		/// <param name="type">A type handle that specifies the class constructor method to run.</param>
		/// <exception cref="T:System.TypeInitializationException">The class initializer throws an exception.</exception>
		// Token: 0x06005C68 RID: 23656 RVA: 0x00144855 File Offset: 0x00142A55
		[__DynamicallyInvokable]
		public static void RunClassConstructor(RuntimeTypeHandle type)
		{
			RuntimeHelpers._RunClassConstructor(type.GetRuntimeType());
		}

		// Token: 0x06005C69 RID: 23657
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _RunModuleConstructor(RuntimeModule module);

		/// <summary>Runs a specified module constructor method.</summary>
		/// <param name="module">A handle that specifies the module constructor method to run.</param>
		/// <exception cref="T:System.TypeInitializationException">The module constructor throws an exception.</exception>
		// Token: 0x06005C6A RID: 23658 RVA: 0x00144863 File Offset: 0x00142A63
		public static void RunModuleConstructor(ModuleHandle module)
		{
			RuntimeHelpers._RunModuleConstructor(module.GetRuntimeModule());
		}

		// Token: 0x06005C6B RID: 23659
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void _PrepareMethod(IRuntimeMethodInfo method, IntPtr* pInstantiation, int cInstantiation);

		// Token: 0x06005C6C RID: 23660
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void _CompileMethod(IRuntimeMethodInfo method);

		/// <summary>Prepares a method for inclusion in a constrained execution region (CER).</summary>
		/// <param name="method">A handle to the method to prepare.</param>
		// Token: 0x06005C6D RID: 23661 RVA: 0x00144871 File Offset: 0x00142A71
		[SecurityCritical]
		public static void PrepareMethod(RuntimeMethodHandle method)
		{
			RuntimeHelpers._PrepareMethod(method.GetMethodInfo(), null, 0);
		}

		/// <summary>Prepares a method for inclusion in a constrained execution region (CER) with the specified instantiation.</summary>
		/// <param name="method">A handle to the method to prepare.</param>
		/// <param name="instantiation">The instantiation to pass to the method.</param>
		// Token: 0x06005C6E RID: 23662 RVA: 0x00144884 File Offset: 0x00142A84
		[SecurityCritical]
		public unsafe static void PrepareMethod(RuntimeMethodHandle method, RuntimeTypeHandle[] instantiation)
		{
			int cInstantiation;
			IntPtr[] array = RuntimeTypeHandle.CopyRuntimeTypeHandles(instantiation, out cInstantiation);
			fixed (IntPtr* ptr = array)
			{
				RuntimeHelpers._PrepareMethod(method.GetMethodInfo(), ptr, cInstantiation);
				GC.KeepAlive(instantiation);
			}
		}

		/// <summary>Indicates that the specified delegate should be prepared for inclusion in a constrained execution region (CER).</summary>
		/// <param name="d">The delegate type to prepare.</param>
		// Token: 0x06005C6F RID: 23663
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void PrepareDelegate(Delegate d);

		/// <summary>Provides a way for applications to dynamically prepare <see cref="T:System.AppDomain" /> event delegates.</summary>
		/// <param name="d">The event delegate to prepare.</param>
		// Token: 0x06005C70 RID: 23664
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void PrepareContractedDelegate(Delegate d);

		/// <summary>Serves as a hash function for a particular object, and is suitable for use in algorithms and data structures that use hash codes, such as a hash table.</summary>
		/// <param name="o">An object to retrieve the hash code for.</param>
		/// <returns>A hash code for the object identified by the <paramref name="o" /> parameter.</returns>
		// Token: 0x06005C71 RID: 23665
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetHashCode(object o);

		/// <summary>Determines whether the specified <see cref="T:System.Object" /> instances are considered equal.</summary>
		/// <param name="o1">The first object to compare.</param>
		/// <param name="o2">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="o1" /> parameter is the same instance as the <paramref name="o2" /> parameter, or if both are <see langword="null" />, or if o1.Equals(o2) returns <see langword="true" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005C72 RID: 23666
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public new static extern bool Equals(object o1, object o2);

		/// <summary>Gets the offset, in bytes, to the data in the given string.</summary>
		/// <returns>The byte offset, from the start of the <see cref="T:System.String" /> object to the first character in the string.</returns>
		// Token: 0x17000FF8 RID: 4088
		// (get) Token: 0x06005C73 RID: 23667 RVA: 0x001448C9 File Offset: 0x00142AC9
		[__DynamicallyInvokable]
		public static int OffsetToStringData
		{
			[NonVersionable]
			[__DynamicallyInvokable]
			get
			{
				return 12;
			}
		}

		/// <summary>Ensures that the remaining stack space is large enough to execute the average .NET Framework function.</summary>
		/// <exception cref="T:System.InsufficientExecutionStackException">The available stack space is insufficient to execute the average .NET Framework function.</exception>
		// Token: 0x06005C74 RID: 23668
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EnsureSufficientExecutionStack();

		/// <summary>Probes for a certain amount of stack space to ensure that a stack overflow cannot happen within a subsequent block of code (assuming that your code uses only a finite and moderate amount of stack space). We recommend that you use a constrained execution region (CER) instead of this method.</summary>
		// Token: 0x06005C75 RID: 23669
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ProbeForSufficientStack();

		/// <summary>Designates a body of code as a constrained execution region (CER).</summary>
		// Token: 0x06005C76 RID: 23670 RVA: 0x001448CD File Offset: 0x00142ACD
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void PrepareConstrainedRegions()
		{
			RuntimeHelpers.ProbeForSufficientStack();
		}

		/// <summary>Designates a body of code as a constrained execution region (CER) without performing any probing.</summary>
		// Token: 0x06005C77 RID: 23671 RVA: 0x001448D4 File Offset: 0x00142AD4
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void PrepareConstrainedRegionsNoOP()
		{
		}

		/// <summary>Executes code using a <see cref="T:System.Delegate" /> while using another <see cref="T:System.Delegate" /> to execute additional code in case of an exception.</summary>
		/// <param name="code">A delegate to the code to try.</param>
		/// <param name="backoutCode">A delegate to the code to run if an exception occurs.</param>
		/// <param name="userData">The data to pass to <paramref name="code" /> and <paramref name="backoutCode" />.</param>
		// Token: 0x06005C78 RID: 23672
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ExecuteCodeWithGuaranteedCleanup(RuntimeHelpers.TryCode code, RuntimeHelpers.CleanupCode backoutCode, object userData);

		// Token: 0x06005C79 RID: 23673 RVA: 0x001448D6 File Offset: 0x00142AD6
		[PrePrepareMethod]
		internal static void ExecuteBackoutCodeHelper(object backoutCode, object userData, bool exceptionThrown)
		{
			((RuntimeHelpers.CleanupCode)backoutCode)(userData, exceptionThrown);
		}

		/// <summary>Represents a delegate to code that should be run in a try block.</summary>
		/// <param name="userData">Data to pass to the delegate.</param>
		// Token: 0x02000C55 RID: 3157
		// (Invoke) Token: 0x06006FB8 RID: 28600
		public delegate void TryCode(object userData);

		/// <summary>Represents a method to run when an exception occurs.</summary>
		/// <param name="userData">Data to pass to the delegate.</param>
		/// <param name="exceptionThrown">
		///   <see langword="true" /> to express that an exception was thrown; otherwise, <see langword="false" />.</param>
		// Token: 0x02000C56 RID: 3158
		// (Invoke) Token: 0x06006FBC RID: 28604
		public delegate void CleanupCode(object userData, bool exceptionThrown);
	}
}
