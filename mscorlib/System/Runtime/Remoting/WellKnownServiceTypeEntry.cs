using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace System.Runtime.Remoting
{
	/// <summary>Holds values for an object type registered on the service end as a server-activated type object (single call or singleton).</summary>
	// Token: 0x02000797 RID: 1943
	[ComVisible(true)]
	public class WellKnownServiceTypeEntry : TypeEntry
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.WellKnownServiceTypeEntry" /> class with the given type name, assembly name, object URI, and <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" />.</summary>
		/// <param name="typeName">The full type name of the server-activated service type.</param>
		/// <param name="assemblyName">The assembly name of the server-activated service type.</param>
		/// <param name="objectUri">The URI of the server-activated object.</param>
		/// <param name="mode">The <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the type, which defines how the object is activated.</param>
		// Token: 0x060054EA RID: 21738 RVA: 0x0012C8A8 File Offset: 0x0012AAA8
		public WellKnownServiceTypeEntry(string typeName, string assemblyName, string objectUri, WellKnownObjectMode mode)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (objectUri == null)
			{
				throw new ArgumentNullException("objectUri");
			}
			base.TypeName = typeName;
			base.AssemblyName = assemblyName;
			this._objectUri = objectUri;
			this._mode = mode;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.WellKnownServiceTypeEntry" /> class with the given <see cref="T:System.Type" />, object URI, and <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" />.</summary>
		/// <param name="type">The <see cref="T:System.Type" /> of the server-activated service type object.</param>
		/// <param name="objectUri">The URI of the server-activated type.</param>
		/// <param name="mode">The <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the type, which defines how the object is activated.</param>
		// Token: 0x060054EB RID: 21739 RVA: 0x0012C904 File Offset: 0x0012AB04
		public WellKnownServiceTypeEntry(Type type, string objectUri, WellKnownObjectMode mode)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (objectUri == null)
			{
				throw new ArgumentNullException("objectUri");
			}
			if (!(type is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			base.TypeName = type.FullName;
			base.AssemblyName = type.Module.Assembly.FullName;
			this._objectUri = objectUri;
			this._mode = mode;
		}

		/// <summary>Gets the URI of the well-known service type.</summary>
		/// <returns>The URI of the server-activated service type.</returns>
		// Token: 0x17000E1C RID: 3612
		// (get) Token: 0x060054EC RID: 21740 RVA: 0x0012C981 File Offset: 0x0012AB81
		public string ObjectUri
		{
			get
			{
				return this._objectUri;
			}
		}

		/// <summary>Gets the <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the server-activated service type.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the server-activated service type.</returns>
		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x060054ED RID: 21741 RVA: 0x0012C989 File Offset: 0x0012AB89
		public WellKnownObjectMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		/// <summary>Gets the <see cref="T:System.Type" /> of the server-activated service type.</summary>
		/// <returns>The <see cref="T:System.Type" /> of the server-activated service type.</returns>
		// Token: 0x17000E1E RID: 3614
		// (get) Token: 0x060054EE RID: 21742 RVA: 0x0012C994 File Offset: 0x0012AB94
		public Type ObjectType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				return RuntimeTypeHandle.GetTypeByName(base.TypeName + ", " + base.AssemblyName, ref stackCrawlMark);
			}
		}

		/// <summary>Gets or sets the context attributes for the server-activated service type.</summary>
		/// <returns>The context attributes for the server-activated service type.</returns>
		// Token: 0x17000E1F RID: 3615
		// (get) Token: 0x060054EF RID: 21743 RVA: 0x0012C9C0 File Offset: 0x0012ABC0
		// (set) Token: 0x060054F0 RID: 21744 RVA: 0x0012C9C8 File Offset: 0x0012ABC8
		public IContextAttribute[] ContextAttributes
		{
			get
			{
				return this._contextAttributes;
			}
			set
			{
				this._contextAttributes = value;
			}
		}

		/// <summary>Returns the type name, assembly name, object URI and the <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the server-activated type as a <see cref="T:System.String" />.</summary>
		/// <returns>The type name, assembly name, object URI, and the <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" /> of the server-activated type as a <see cref="T:System.String" />.</returns>
		// Token: 0x060054F1 RID: 21745 RVA: 0x0012C9D4 File Offset: 0x0012ABD4
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"type='",
				base.TypeName,
				", ",
				base.AssemblyName,
				"'; objectUri=",
				this._objectUri,
				"; mode=",
				this._mode.ToString()
			});
		}

		// Token: 0x040026CA RID: 9930
		private string _objectUri;

		// Token: 0x040026CB RID: 9931
		private WellKnownObjectMode _mode;

		// Token: 0x040026CC RID: 9932
		private IContextAttribute[] _contextAttributes;
	}
}
