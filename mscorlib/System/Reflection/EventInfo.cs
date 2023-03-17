using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Discovers the attributes of an event and provides access to event metadata.</summary>
	// Token: 0x020005B5 RID: 1461
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_EventInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class EventInfo : MemberInfo, _EventInfo
	{
		/// <summary>Indicates whether two <see cref="T:System.Reflection.EventInfo" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004496 RID: 17558 RVA: 0x000FC819 File Offset: 0x000FAA19
		[__DynamicallyInvokable]
		public static bool operator ==(EventInfo left, EventInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeEventInfo) && !(right is RuntimeEventInfo) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.EventInfo" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004497 RID: 17559 RVA: 0x000FC840 File Offset: 0x000FAA40
		[__DynamicallyInvokable]
		public static bool operator !=(EventInfo left, EventInfo right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004498 RID: 17560 RVA: 0x000FC84C File Offset: 0x000FAA4C
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06004499 RID: 17561 RVA: 0x000FC855 File Offset: 0x000FAA55
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is an event.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is an event.</returns>
		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x0600449A RID: 17562 RVA: 0x000FC85D File Offset: 0x000FAA5D
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Event;
			}
		}

		/// <summary>Returns the methods that have been associated with the event in metadata using the <see langword=".other" /> directive, specifying whether to include non-public methods.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> to include non-public methods; otherwise, <see langword="false" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing methods that have been associated with an event in metadata by using the <see langword=".other" /> directive. If there are no methods matching the specification, an empty array is returned.</returns>
		/// <exception cref="T:System.NotImplementedException">This method is not implemented.</exception>
		// Token: 0x0600449B RID: 17563 RVA: 0x000FC860 File Offset: 0x000FAA60
		public virtual MethodInfo[] GetOtherMethods(bool nonPublic)
		{
			throw new NotImplementedException();
		}

		/// <summary>When overridden in a derived class, retrieves the <see langword="MethodInfo" /> object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)" /> method of the event, specifying whether to return non-public methods.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> if non-public methods can be returned; otherwise, <see langword="false" />.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method used to add an event handler delegate to the event source.</returns>
		/// <exception cref="T:System.MethodAccessException">
		///   <paramref name="nonPublic" /> is <see langword="true" />, the method used to add an event handler delegate is non-public, and the caller does not have permission to reflect on non-public methods.</exception>
		// Token: 0x0600449C RID: 17564
		[__DynamicallyInvokable]
		public abstract MethodInfo GetAddMethod(bool nonPublic);

		/// <summary>When overridden in a derived class, retrieves the <see langword="MethodInfo" /> object for removing a method of the event, specifying whether to return non-public methods.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> if non-public methods can be returned; otherwise, <see langword="false" />.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method used to remove an event handler delegate from the event source.</returns>
		/// <exception cref="T:System.MethodAccessException">
		///   <paramref name="nonPublic" /> is <see langword="true" />, the method used to add an event handler delegate is non-public, and the caller does not have permission to reflect on non-public methods.</exception>
		// Token: 0x0600449D RID: 17565
		[__DynamicallyInvokable]
		public abstract MethodInfo GetRemoveMethod(bool nonPublic);

		/// <summary>When overridden in a derived class, returns the method that is called when the event is raised, specifying whether to return non-public methods.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> if non-public methods can be returned; otherwise, <see langword="false" />.</param>
		/// <returns>A <see langword="MethodInfo" /> object that was called when the event was raised.</returns>
		/// <exception cref="T:System.MethodAccessException">
		///   <paramref name="nonPublic" /> is <see langword="true" />, the method used to add an event handler delegate is non-public, and the caller does not have permission to reflect on non-public methods.</exception>
		// Token: 0x0600449E RID: 17566
		[__DynamicallyInvokable]
		public abstract MethodInfo GetRaiseMethod(bool nonPublic);

		/// <summary>Gets the attributes for this event.</summary>
		/// <returns>The read-only attributes for this event.</returns>
		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x0600449F RID: 17567
		[__DynamicallyInvokable]
		public abstract EventAttributes Attributes { [__DynamicallyInvokable] get; }

		/// <summary>Gets the <see cref="T:System.Reflection.MethodInfo" /> object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)" /> method of the event, including non-public methods.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodInfo" /> object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)" /> method.</returns>
		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x060044A0 RID: 17568 RVA: 0x000FC867 File Offset: 0x000FAA67
		[__DynamicallyInvokable]
		public virtual MethodInfo AddMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetAddMethod(true);
			}
		}

		/// <summary>Gets the <see langword="MethodInfo" /> object for removing a method of the event, including non-public methods.</summary>
		/// <returns>The <see langword="MethodInfo" /> object for removing a method of the event.</returns>
		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x060044A1 RID: 17569 RVA: 0x000FC870 File Offset: 0x000FAA70
		[__DynamicallyInvokable]
		public virtual MethodInfo RemoveMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetRemoveMethod(true);
			}
		}

		/// <summary>Gets the method that is called when the event is raised, including non-public methods.</summary>
		/// <returns>The method that is called when the event is raised.</returns>
		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x060044A2 RID: 17570 RVA: 0x000FC879 File Offset: 0x000FAA79
		[__DynamicallyInvokable]
		public virtual MethodInfo RaiseMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetRaiseMethod(true);
			}
		}

		/// <summary>Returns the public methods that have been associated with an event in metadata using the <see langword=".other" /> directive.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing the public methods that have been associated with the event in metadata by using the <see langword=".other" /> directive. If there are no such public methods, an empty array is returned.</returns>
		// Token: 0x060044A3 RID: 17571 RVA: 0x000FC882 File Offset: 0x000FAA82
		public MethodInfo[] GetOtherMethods()
		{
			return this.GetOtherMethods(false);
		}

		/// <summary>Returns the method used to add an event handler delegate to the event source.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method used to add an event handler delegate to the event source.</returns>
		// Token: 0x060044A4 RID: 17572 RVA: 0x000FC88B File Offset: 0x000FAA8B
		[__DynamicallyInvokable]
		public MethodInfo GetAddMethod()
		{
			return this.GetAddMethod(false);
		}

		/// <summary>Returns the method used to remove an event handler delegate from the event source.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method used to remove an event handler delegate from the event source.</returns>
		// Token: 0x060044A5 RID: 17573 RVA: 0x000FC894 File Offset: 0x000FAA94
		[__DynamicallyInvokable]
		public MethodInfo GetRemoveMethod()
		{
			return this.GetRemoveMethod(false);
		}

		/// <summary>Returns the method that is called when the event is raised.</summary>
		/// <returns>The method that is called when the event is raised.</returns>
		// Token: 0x060044A6 RID: 17574 RVA: 0x000FC89D File Offset: 0x000FAA9D
		[__DynamicallyInvokable]
		public MethodInfo GetRaiseMethod()
		{
			return this.GetRaiseMethod(false);
		}

		/// <summary>Adds an event handler to an event source.</summary>
		/// <param name="target">The event source.</param>
		/// <param name="handler">Encapsulates a method or methods to be invoked when the event is raised by the target.</param>
		/// <exception cref="T:System.InvalidOperationException">The event does not have a public <see langword="add" /> accessor.</exception>
		/// <exception cref="T:System.ArgumentException">The handler that was passed in cannot be used.</exception>
		/// <exception cref="T:System.MethodAccessException">In .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The caller does not have access permission to the member.</exception>
		/// <exception cref="T:System.Reflection.TargetException">In .NET for Windows Store apps or the Portable Class Library, catch <see cref="T:System.Exception" /> instead.  
		///
		///
		///
		///
		///  The <paramref name="target" /> parameter is <see langword="null" /> and the event is not static.  
		///  -or-  
		///  The <see cref="T:System.Reflection.EventInfo" /> is not declared on the target.</exception>
		// Token: 0x060044A7 RID: 17575 RVA: 0x000FC8A8 File Offset: 0x000FAAA8
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public virtual void AddEventHandler(object target, Delegate handler)
		{
			MethodInfo addMethod = this.GetAddMethod();
			if (addMethod == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicAddMethod"));
			}
			if (addMethod.ReturnType == typeof(EventRegistrationToken))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotSupportedOnWinRTEvent"));
			}
			addMethod.Invoke(target, new object[]
			{
				handler
			});
		}

		/// <summary>Removes an event handler from an event source.</summary>
		/// <param name="target">The event source.</param>
		/// <param name="handler">The delegate to be disassociated from the events raised by target.</param>
		/// <exception cref="T:System.InvalidOperationException">The event does not have a public <see langword="remove" /> accessor.</exception>
		/// <exception cref="T:System.ArgumentException">The handler that was passed in cannot be used.</exception>
		/// <exception cref="T:System.Reflection.TargetException">In .NET for Windows Store apps or the Portable Class Library, catch <see cref="T:System.Exception" /> instead.  
		///
		///
		///
		///
		///  The <paramref name="target" /> parameter is <see langword="null" /> and the event is not static.  
		///  -or-  
		///  The <see cref="T:System.Reflection.EventInfo" /> is not declared on the target.</exception>
		/// <exception cref="T:System.MethodAccessException">In .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The caller does not have access permission to the member.</exception>
		// Token: 0x060044A8 RID: 17576 RVA: 0x000FC910 File Offset: 0x000FAB10
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public virtual void RemoveEventHandler(object target, Delegate handler)
		{
			MethodInfo removeMethod = this.GetRemoveMethod();
			if (removeMethod == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicRemoveMethod"));
			}
			ParameterInfo[] parametersNoCopy = removeMethod.GetParametersNoCopy();
			if (parametersNoCopy[0].ParameterType == typeof(EventRegistrationToken))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotSupportedOnWinRTEvent"));
			}
			removeMethod.Invoke(target, new object[]
			{
				handler
			});
		}

		/// <summary>Gets the <see langword="Type" /> object of the underlying event-handler delegate associated with this event.</summary>
		/// <returns>A read-only <see langword="Type" /> object representing the delegate event handler.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x060044A9 RID: 17577 RVA: 0x000FC980 File Offset: 0x000FAB80
		[__DynamicallyInvokable]
		public virtual Type EventHandlerType
		{
			[__DynamicallyInvokable]
			get
			{
				MethodInfo addMethod = this.GetAddMethod(true);
				ParameterInfo[] parametersNoCopy = addMethod.GetParametersNoCopy();
				Type typeFromHandle = typeof(Delegate);
				for (int i = 0; i < parametersNoCopy.Length; i++)
				{
					Type parameterType = parametersNoCopy[i].ParameterType;
					if (parameterType.IsSubclassOf(typeFromHandle))
					{
						return parameterType;
					}
				}
				return null;
			}
		}

		/// <summary>Gets a value indicating whether the <see langword="EventInfo" /> has a name with a special meaning.</summary>
		/// <returns>
		///   <see langword="true" /> if this event has a special name; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x060044AA RID: 17578 RVA: 0x000FC9CD File Offset: 0x000FABCD
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & EventAttributes.SpecialName) > EventAttributes.None;
			}
		}

		/// <summary>Gets a value indicating whether the event is multicast.</summary>
		/// <returns>
		///   <see langword="true" /> if the delegate is an instance of a multicast delegate; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x060044AB RID: 17579 RVA: 0x000FC9E0 File Offset: 0x000FABE0
		[__DynamicallyInvokable]
		public virtual bool IsMulticast
		{
			[__DynamicallyInvokable]
			get
			{
				Type eventHandlerType = this.EventHandlerType;
				Type typeFromHandle = typeof(MulticastDelegate);
				return typeFromHandle.IsAssignableFrom(eventHandlerType);
			}
		}

		/// <summary>Returns a T:System.Type object representing the <see cref="T:System.Reflection.EventInfo" /> type.</summary>
		/// <returns>A T:System.Type object representing the <see cref="T:System.Reflection.EventInfo" /> type.</returns>
		// Token: 0x060044AC RID: 17580 RVA: 0x000FCA06 File Offset: 0x000FAC06
		Type _EventInfo.GetType()
		{
			return base.GetType();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044AD RID: 17581 RVA: 0x000FCA0E File Offset: 0x000FAC0E
		void _EventInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044AE RID: 17582 RVA: 0x000FCA15 File Offset: 0x000FAC15
		void _EventInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044AF RID: 17583 RVA: 0x000FCA1C File Offset: 0x000FAC1C
		void _EventInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044B0 RID: 17584 RVA: 0x000FCA23 File Offset: 0x000FAC23
		void _EventInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
