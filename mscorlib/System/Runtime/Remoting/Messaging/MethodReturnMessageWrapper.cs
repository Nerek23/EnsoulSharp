using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Implements the <see cref="T:System.Runtime.Remoting.Messaging.IMethodReturnMessage" /> interface to create a message that acts as a response to a method call on a remote object.</summary>
	// Token: 0x02000847 RID: 2119
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class MethodReturnMessageWrapper : InternalMessageWrapper, IMethodReturnMessage, IMethodMessage, IMessage
	{
		/// <summary>Wraps an <see cref="T:System.Runtime.Remoting.Messaging.IMethodReturnMessage" /> to create a <see cref="T:System.Runtime.Remoting.Messaging.MethodReturnMessageWrapper" />.</summary>
		/// <param name="msg">A message that acts as an outgoing method call on a remote object.</param>
		// Token: 0x06005AF4 RID: 23284 RVA: 0x0013E288 File Offset: 0x0013C488
		public MethodReturnMessageWrapper(IMethodReturnMessage msg) : base(msg)
		{
			this._msg = msg;
			this._args = this._msg.Args;
			this._returnValue = this._msg.ReturnValue;
			this._exception = this._msg.Exception;
		}

		/// <summary>Gets the Uniform Resource Identifier (URI) of the remote object on which the method call is being made.</summary>
		/// <returns>The URI of a remote object.</returns>
		// Token: 0x17000FB3 RID: 4019
		// (get) Token: 0x06005AF5 RID: 23285 RVA: 0x0013E2D6 File Offset: 0x0013C4D6
		// (set) Token: 0x06005AF6 RID: 23286 RVA: 0x0013E2E3 File Offset: 0x0013C4E3
		public string Uri
		{
			[SecurityCritical]
			get
			{
				return this._msg.Uri;
			}
			set
			{
				this._msg.Properties[Message.UriKey] = value;
			}
		}

		/// <summary>Gets the name of the invoked method.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the name of the invoked method.</returns>
		// Token: 0x17000FB4 RID: 4020
		// (get) Token: 0x06005AF7 RID: 23287 RVA: 0x0013E2FB File Offset: 0x0013C4FB
		public virtual string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodName;
			}
		}

		/// <summary>Gets the full type name of the remote object on which the method call is being made.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the full type name of the remote object on which the method call is being made.</returns>
		// Token: 0x17000FB5 RID: 4021
		// (get) Token: 0x06005AF8 RID: 23288 RVA: 0x0013E308 File Offset: 0x0013C508
		public virtual string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._msg.TypeName;
			}
		}

		/// <summary>Gets an object that contains the method signature.</summary>
		/// <returns>A <see cref="T:System.Object" /> that contains the method signature.</returns>
		// Token: 0x17000FB6 RID: 4022
		// (get) Token: 0x06005AF9 RID: 23289 RVA: 0x0013E315 File Offset: 0x0013C515
		public virtual object MethodSignature
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodSignature;
			}
		}

		/// <summary>Gets the <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> for the current method call.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> for the current method call.</returns>
		// Token: 0x17000FB7 RID: 4023
		// (get) Token: 0x06005AFA RID: 23290 RVA: 0x0013E322 File Offset: 0x0013C522
		public virtual LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._msg.LogicalCallContext;
			}
		}

		/// <summary>Gets the <see cref="T:System.Reflection.MethodBase" /> of the called method.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodBase" /> of the called method.</returns>
		// Token: 0x17000FB8 RID: 4024
		// (get) Token: 0x06005AFB RID: 23291 RVA: 0x0013E32F File Offset: 0x0013C52F
		public virtual MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodBase;
			}
		}

		/// <summary>Gets the number of arguments passed to the method.</summary>
		/// <returns>A <see cref="T:System.Int32" /> that represents the number of arguments passed to a method.</returns>
		// Token: 0x17000FB9 RID: 4025
		// (get) Token: 0x06005AFC RID: 23292 RVA: 0x0013E33C File Offset: 0x0013C53C
		public virtual int ArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._args != null)
				{
					return this._args.Length;
				}
				return 0;
			}
		}

		/// <summary>Gets the name of a method argument at a specified index.</summary>
		/// <param name="index">The index of the requested argument.</param>
		/// <returns>The name of the method argument.</returns>
		// Token: 0x06005AFD RID: 23293 RVA: 0x0013E350 File Offset: 0x0013C550
		[SecurityCritical]
		public virtual string GetArgName(int index)
		{
			return this._msg.GetArgName(index);
		}

		/// <summary>Gets a method argument, as an object, at a specified index.</summary>
		/// <param name="argNum">The index of the requested argument.</param>
		/// <returns>The method argument as an object.</returns>
		// Token: 0x06005AFE RID: 23294 RVA: 0x0013E35E File Offset: 0x0013C55E
		[SecurityCritical]
		public virtual object GetArg(int argNum)
		{
			return this._args[argNum];
		}

		/// <summary>Gets an array of arguments passed to the method.</summary>
		/// <returns>An array of type <see cref="T:System.Object" /> that represents the arguments passed to a method.</returns>
		// Token: 0x17000FBA RID: 4026
		// (get) Token: 0x06005AFF RID: 23295 RVA: 0x0013E368 File Offset: 0x0013C568
		// (set) Token: 0x06005B00 RID: 23296 RVA: 0x0013E370 File Offset: 0x0013C570
		public virtual object[] Args
		{
			[SecurityCritical]
			get
			{
				return this._args;
			}
			set
			{
				this._args = value;
			}
		}

		/// <summary>Gets a flag that indicates whether the method can accept a variable number of arguments.</summary>
		/// <returns>
		///   <see langword="true" /> if the method can accept a variable number of arguments; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000FBB RID: 4027
		// (get) Token: 0x06005B01 RID: 23297 RVA: 0x0013E379 File Offset: 0x0013C579
		public virtual bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._msg.HasVarArgs;
			}
		}

		/// <summary>Gets the number of arguments in the method call that are marked as <see langword="ref" /> parameters or <see langword="out" /> parameters.</summary>
		/// <returns>A <see cref="T:System.Int32" /> that represents the number of arguments in the method call that are marked as <see langword="ref" /> parameters or <see langword="out" /> parameters.</returns>
		// Token: 0x17000FBC RID: 4028
		// (get) Token: 0x06005B02 RID: 23298 RVA: 0x0013E386 File Offset: 0x0013C586
		public virtual int OutArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.ArgCount;
			}
		}

		/// <summary>Returns the specified argument marked as a <see langword="ref" /> parameter or an <see langword="out" /> parameter.</summary>
		/// <param name="argNum">The index of the requested argument.</param>
		/// <returns>The specified argument marked as a <see langword="ref" /> parameter or an <see langword="out" /> parameter.</returns>
		// Token: 0x06005B03 RID: 23299 RVA: 0x0013E3A8 File Offset: 0x0013C5A8
		[SecurityCritical]
		public virtual object GetOutArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArg(argNum);
		}

		/// <summary>Returns the name of the specified argument marked as a <see langword="ref" /> parameter or an <see langword="out" /> parameter.</summary>
		/// <param name="index">The index of the requested argument.</param>
		/// <returns>The argument name, or <see langword="null" /> if the current method is not implemented.</returns>
		// Token: 0x06005B04 RID: 23300 RVA: 0x0013E3CB File Offset: 0x0013C5CB
		[SecurityCritical]
		public virtual string GetOutArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArgName(index);
		}

		/// <summary>Gets an array of arguments in the method call that are marked as <see langword="ref" /> parameters or <see langword="out" /> parameters.</summary>
		/// <returns>An array of type <see cref="T:System.Object" /> that represents the arguments in the method call that are marked as <see langword="ref" /> parameters or <see langword="out" /> parameters.</returns>
		// Token: 0x17000FBD RID: 4029
		// (get) Token: 0x06005B05 RID: 23301 RVA: 0x0013E3EE File Offset: 0x0013C5EE
		public virtual object[] OutArgs
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.Args;
			}
		}

		/// <summary>Gets the exception thrown during the method call, or <see langword="null" /> if the method did not throw an exception.</summary>
		/// <returns>The <see cref="T:System.Exception" /> thrown during the method call, or <see langword="null" /> if the method did not throw an exception.</returns>
		// Token: 0x17000FBE RID: 4030
		// (get) Token: 0x06005B06 RID: 23302 RVA: 0x0013E410 File Offset: 0x0013C610
		// (set) Token: 0x06005B07 RID: 23303 RVA: 0x0013E418 File Offset: 0x0013C618
		public virtual Exception Exception
		{
			[SecurityCritical]
			get
			{
				return this._exception;
			}
			set
			{
				this._exception = value;
			}
		}

		/// <summary>Gets the return value of the method call.</summary>
		/// <returns>A <see cref="T:System.Object" /> that represents the return value of the method call.</returns>
		// Token: 0x17000FBF RID: 4031
		// (get) Token: 0x06005B08 RID: 23304 RVA: 0x0013E421 File Offset: 0x0013C621
		// (set) Token: 0x06005B09 RID: 23305 RVA: 0x0013E429 File Offset: 0x0013C629
		public virtual object ReturnValue
		{
			[SecurityCritical]
			get
			{
				return this._returnValue;
			}
			set
			{
				this._returnValue = value;
			}
		}

		/// <summary>An <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</returns>
		// Token: 0x17000FC0 RID: 4032
		// (get) Token: 0x06005B0A RID: 23306 RVA: 0x0013E432 File Offset: 0x0013C632
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					this._properties = new MethodReturnMessageWrapper.MRMWrapperDictionary(this, this._msg.Properties);
				}
				return this._properties;
			}
		}

		// Token: 0x040028DD RID: 10461
		private IMethodReturnMessage _msg;

		// Token: 0x040028DE RID: 10462
		private IDictionary _properties;

		// Token: 0x040028DF RID: 10463
		private ArgMapper _argMapper;

		// Token: 0x040028E0 RID: 10464
		private object[] _args;

		// Token: 0x040028E1 RID: 10465
		private object _returnValue;

		// Token: 0x040028E2 RID: 10466
		private Exception _exception;

		// Token: 0x02000C45 RID: 3141
		private class MRMWrapperDictionary : Hashtable
		{
			// Token: 0x06006F91 RID: 28561 RVA: 0x0017FE58 File Offset: 0x0017E058
			public MRMWrapperDictionary(IMethodReturnMessage msg, IDictionary idict)
			{
				this._mrmsg = msg;
				this._idict = idict;
			}

			// Token: 0x17001339 RID: 4921
			public override object this[object key]
			{
				[SecuritySafeCritical]
				get
				{
					string text = key as string;
					if (text != null)
					{
						if (text == "__Uri")
						{
							return this._mrmsg.Uri;
						}
						if (text == "__MethodName")
						{
							return this._mrmsg.MethodName;
						}
						if (text == "__MethodSignature")
						{
							return this._mrmsg.MethodSignature;
						}
						if (text == "__TypeName")
						{
							return this._mrmsg.TypeName;
						}
						if (text == "__Return")
						{
							return this._mrmsg.ReturnValue;
						}
						if (text == "__OutArgs")
						{
							return this._mrmsg.OutArgs;
						}
					}
					return this._idict[key];
				}
				[SecuritySafeCritical]
				set
				{
					string text = key as string;
					if (text != null)
					{
						if (text == "__MethodName" || text == "__MethodSignature" || text == "__TypeName" || text == "__Return" || text == "__OutArgs")
						{
							throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
						}
						this._idict[key] = value;
					}
				}
			}

			// Token: 0x04003724 RID: 14116
			private IMethodReturnMessage _mrmsg;

			// Token: 0x04003725 RID: 14117
			private IDictionary _idict;
		}
	}
}
