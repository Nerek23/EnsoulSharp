using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each AIBaseClient object.
	/// </summary>
	// Token: 0x0200005D RID: 93
	public class AIBaseClient : AttackableUnit
	{
		// Token: 0x0600035B RID: 859 RVA: 0x000016C4 File Offset: 0x00000AC4
		internal AIBaseClient()
		{
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000016AC File Offset: 0x00000AAC
		internal AIBaseClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe AIBaseClient* GetPtr()
		{
			return (AIBaseClient*)base.GetPtr();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00004CCC File Offset: 0x000040CC
		static AIBaseClient()
		{
			AppDomain.CurrentDomain.DomainUnload += AIBaseClient.DomainUnloadEventHandler;
			AIBaseClient.m_AggroNativeDelegate = new AIBaseClient.OnAggroNativeDelegate(AIBaseClient.OnAggroNative);
			AIBaseClient.m_AggroNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnAggroNativeDelegate>(AIBaseClient.m_AggroNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,unsigned\u0020int)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientAggroHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_AggroNative.ToPointer());
			AIBaseClient.m_BuffAddNativeDelegate = new AIBaseClient.OnBuffAddNativeDelegate(AIBaseClient.OnBuffAddNative);
			AIBaseClient.m_BuffAddNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnBuffAddNativeDelegate>(AIBaseClient.m_BuffAddNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientBuffAddHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_BuffAddNative.ToPointer());
			AIBaseClient.m_BuffRemoveNativeDelegate = new AIBaseClient.OnBuffRemoveNativeDelegate(AIBaseClient.OnBuffRemoveNative);
			AIBaseClient.m_BuffRemoveNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnBuffRemoveNativeDelegate>(AIBaseClient.m_BuffRemoveNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientBuffRemoveHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_BuffRemoveNative.ToPointer());
			AIBaseClient.m_DoCastNativeDelegate = new AIBaseClient.OnDoCastNativeDelegate(AIBaseClient.OnDoCastNative);
			AIBaseClient.m_DoCastNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnDoCastNativeDelegate>(AIBaseClient.m_DoCastNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientDoCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_DoCastNative.ToPointer());
			AIBaseClient.m_IssueOrderNativeDelegate = new AIBaseClient.OnIssueOrderNativeDelegate(AIBaseClient.OnIssueOrderNative);
			AIBaseClient.m_IssueOrderNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnIssueOrderNativeDelegate>(AIBaseClient.m_IssueOrderNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::IssuedOrder,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::AttackableUnit\u0020*,bool,bool,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientIssueOrderHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_IssueOrderNative.ToPointer());
			AIBaseClient.m_NewPathNativeDelegate = new AIBaseClient.OnNewPathNativeDelegate(AIBaseClient.OnNewPathNative);
			AIBaseClient.m_NewPathNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnNewPathNativeDelegate>(AIBaseClient.m_NewPathNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::StlArray<EnsoulSharp::Native::Vector3f>\u0020*,bool,float)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientNewPathHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_NewPathNative.ToPointer());
			AIBaseClient.m_PlayAnimationNativeDelegate = new AIBaseClient.OnPlayAnimationNativeDelegate(AIBaseClient.OnPlayAnimationNative);
			AIBaseClient.m_PlayAnimationNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnPlayAnimationNativeDelegate>(AIBaseClient.m_PlayAnimationNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,char\u0020const\u0020*,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientPlayAnimationHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_PlayAnimationNative.ToPointer());
			AIBaseClient.m_ProcessSpellCastNativeDelegate = new AIBaseClient.OnProcessSpellCastNativeDelegate(AIBaseClient.OnProcessSpellCastNative);
			AIBaseClient.m_ProcessSpellCastNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnProcessSpellCastNativeDelegate>(AIBaseClient.m_ProcessSpellCastNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientProcessSpellCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_ProcessSpellCastNative.ToPointer());
			AIBaseClient.m_VisibleEnterNativeDelegate = new AIBaseClient.OnVisibleEnterNativeDelegate(AIBaseClient.OnVisibleEnterNative);
			AIBaseClient.m_VisibleEnterNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnVisibleEnterNativeDelegate>(AIBaseClient.m_VisibleEnterNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientVisibleEnterHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_VisibleEnterNative.ToPointer());
			AIBaseClient.m_VisibleLeaveNativeDelegate = new AIBaseClient.OnVisibleLeaveNativeDelegate(AIBaseClient.OnVisibleLeaveNative);
			AIBaseClient.m_VisibleLeaveNative = Marshal.GetFunctionPointerForDelegate<AIBaseClient.OnVisibleLeaveNativeDelegate>(AIBaseClient.m_VisibleLeaveNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientVisibleLeaveHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_VisibleLeaveNative.ToPointer());
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000016EC File Offset: 0x00000AEC
		internal new static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,unsigned\u0020int)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientAggroHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_AggroNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientBuffAddHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_BuffAddNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientBuffRemoveHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_BuffRemoveNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientDoCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_DoCastNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::IssuedOrder,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::AttackableUnit\u0020*,bool,bool,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientIssueOrderHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_IssueOrderNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::StlArray<EnsoulSharp::Native::Vector3f>\u0020*,bool,float)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientNewPathHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_NewPathNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,char\u0020const\u0020*,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientPlayAnimationHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_PlayAnimationNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientProcessSpellCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_ProcessSpellCastNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientVisibleEnterHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_VisibleEnterNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIBaseClientVisibleLeaveHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIBaseClient.m_VisibleLeaveNative.ToPointer());
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000017F4 File Offset: 0x00000BF4
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnAggroNative(AIBaseClient* aiBaseClient, uint targetNetworkId)
		{
			AIBaseClientAggro[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					AIBaseClientAggroEventArgs args = new AIBaseClientAggroEventArgs((int)targetNetworkId);
					foreach (AIBaseClientAggro aibaseClientAggro in AIBaseClient.AggroHandlers.ToArray())
					{
						try
						{
							aibaseClientAggro(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00001AC4 File Offset: 0x00000EC4
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnBuffAddNative(AIBaseClient* aiBaseClient, BuffInstanceClient* buff)
		{
			AIBaseClientBuffAdd[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					AIBaseClientBuffAddEventArgs args = new AIBaseClientBuffAddEventArgs(new BuffInstance(buff));
					foreach (AIBaseClientBuffAdd aibaseClientBuffAdd in AIBaseClient.BuffAddHandlers.ToArray())
					{
						try
						{
							aibaseClientBuffAdd(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00001D98 File Offset: 0x00001198
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnBuffRemoveNative(AIBaseClient* aiBaseClient, BuffInstanceClient* buff)
		{
			AIBaseClientBuffRemove[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					AIBaseClientBuffRemoveEventArgs args = new AIBaseClientBuffRemoveEventArgs(new BuffInstance(buff));
					foreach (AIBaseClientBuffRemove aibaseClientBuffRemove in AIBaseClient.BuffRemoveHandlers.ToArray())
					{
						try
						{
							aibaseClientBuffRemove(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000206C File Offset: 0x0000146C
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnDoCastNative(AIBaseClient* aiBaseClient, SpellCastInfo* castInfo)
		{
			AIBaseClientDoCast[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					uint targetLocalId;
					if (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(castInfo) != 0)
					{
						targetLocalId = (uint)(*(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(castInfo)));
					}
					else
					{
						targetLocalId = 0U;
					}
					Vector3 end = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)));
					Vector3 to = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)));
					Vector3 start = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)));
					int slot = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSlot(castInfo);
					float totalTime = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerTotalTime(castInfo);
					float num = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerCastTime(castInfo);
					float num2 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetExtraTimeForCast(castInfo);
					int missileNetworkId = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetMissileNetworkID(castInfo);
					int num3 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellLevel(castInfo);
					AIBaseClientProcessSpellCastEventArgs args = new AIBaseClientProcessSpellCastEventArgs(new SpellData(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(castInfo)), num3 + 1, start, to, end, (int)targetLocalId, missileNetworkId, (float)((double)num + (double)num2), totalTime, (SpellSlot)slot);
					foreach (AIBaseClientDoCast aibaseClientDoCast in AIBaseClient.DoCastHandlers.ToArray())
					{
						try
						{
							aibaseClientDoCast(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00002424 File Offset: 0x00001824
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnIssueOrderNative(AIBaseClient* aiBaseClient, IssuedOrder order, Vector3f* position, AttackableUnit* target, [MarshalAs(UnmanagedType.U1)] bool isAttackMove, [MarshalAs(UnmanagedType.U1)] bool isPetCommand, bool* process)
		{
			AIBaseClientIssueOrder[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					AttackableUnit target2;
					if (target != null)
					{
						uint index = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(target));
						target2 = new AttackableUnit((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(target)), index);
					}
					else
					{
						target2 = null;
					}
					Vector3 targetPosition = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(position), <Module>.EnsoulSharp.Native.Vector3f.GetZ(position), <Module>.EnsoulSharp.Native.Vector3f.GetY(position));
					AIBaseClientIssueOrderEventArgs aibaseClientIssueOrderEventArgs = new AIBaseClientIssueOrderEventArgs(*process, (GameObjectOrder)order, targetPosition, target2, isAttackMove, isPetCommand);
					foreach (AIBaseClientIssueOrder aibaseClientIssueOrder in AIBaseClient.IssueOrderHandlers.ToArray())
					{
						try
						{
							aibaseClientIssueOrder(aibaseClient, aibaseClientIssueOrderEventArgs);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
					*process = aibaseClientIssueOrderEventArgs.Process;
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00002740 File Offset: 0x00001B40
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnNewPathNative(AIBaseClient* aiBaseClient, StlArray<EnsoulSharp::Native::Vector3f>* path, [MarshalAs(UnmanagedType.U1)] bool isDash, float speed)
		{
			AIBaseClientNewPath[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					Vector3[] array2 = new Vector3[*(int*)(path + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))];
					for (uint num = 0U; num < (uint)(*(int*)(path + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))); num += 1U)
					{
						Vector3f* ptr = num * 12U + (uint)(*(int*)path);
						Vector3 vector = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr));
						array2[(int)num] = vector;
					}
					AIBaseClientNewPathEventArgs args = new AIBaseClientNewPathEventArgs(array2, isDash, speed);
					foreach (AIBaseClientNewPath aibaseClientNewPath in AIBaseClient.NewPathHandlers.ToArray())
					{
						try
						{
							aibaseClientNewPath(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00002A64 File Offset: 0x00001E64
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnPlayAnimationNative(AIBaseClient* aiBaseClient, sbyte* animaton, bool* process)
		{
			AIBaseClientPlayAnimation[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					AIBaseClientPlayAnimationEventArgs aibaseClientPlayAnimationEventArgs = new AIBaseClientPlayAnimationEventArgs(*process, new string((sbyte*)animaton));
					foreach (AIBaseClientPlayAnimation aibaseClientPlayAnimation in AIBaseClient.PlayAnimationHandlers.ToArray())
					{
						try
						{
							aibaseClientPlayAnimation(aibaseClient, aibaseClientPlayAnimationEventArgs);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
					*process = aibaseClientPlayAnimationEventArgs.Process;
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00002D44 File Offset: 0x00002144
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnProcessSpellCastNative(AIBaseClient* aiBaseClient, SpellCastInfo* castInfo)
		{
			AIBaseClientProcessSpellCast[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					uint targetLocalId;
					if (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(castInfo) != 0)
					{
						targetLocalId = (uint)(*(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(castInfo)));
					}
					else
					{
						targetLocalId = 0U;
					}
					Vector3 end = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(castInfo)));
					Vector3 to = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(castInfo)));
					Vector3 start = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(castInfo)));
					int slot = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSlot(castInfo);
					float totalTime = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerTotalTime(castInfo);
					float num = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerCastTime(castInfo);
					float num2 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetExtraTimeForCast(castInfo);
					int missileNetworkId = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetMissileNetworkID(castInfo);
					int num3 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellLevel(castInfo);
					AIBaseClientProcessSpellCastEventArgs args = new AIBaseClientProcessSpellCastEventArgs(new SpellData(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(castInfo)), num3 + 1, start, to, end, (int)targetLocalId, missileNetworkId, (float)((double)num + (double)num2), totalTime, (SpellSlot)slot);
					foreach (AIBaseClientProcessSpellCast aibaseClientProcessSpellCast in AIBaseClient.ProcessSpellCastHandlers.ToArray())
					{
						try
						{
							aibaseClientProcessSpellCast(aibaseClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000030FC File Offset: 0x000024FC
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnVisibleEnterNative(AIBaseClient* aiBaseClient)
		{
			AIBaseClientVisibleEnter[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					foreach (AIBaseClientVisibleEnter aibaseClientVisibleEnter in AIBaseClient.VisibleEnterHandlers.ToArray())
					{
						try
						{
							aibaseClientVisibleEnter(aibaseClient, EventArgs.Empty);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000033C4 File Offset: 0x000027C4
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnVisibleLeaveNative(AIBaseClient* aiBaseClient)
		{
			AIBaseClientVisibleLeave[] array = null;
			try
			{
				AIBaseClient aibaseClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiBaseClient) as AIBaseClient;
				if (aibaseClient != null)
				{
					foreach (AIBaseClientVisibleLeave aibaseClientVisibleLeave in AIBaseClient.VisibleLeaveHandlers.ToArray())
					{
						try
						{
							aibaseClientVisibleLeave(aibaseClient, EventArgs.Empty);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		/// <summary>
		/// 	This event is fired before a object as attacker outline a target.
		/// </summary>
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600036A RID: 874 RVA: 0x0000368C File Offset: 0x00002A8C
		// (remove) Token: 0x0600036B RID: 875 RVA: 0x000036A4 File Offset: 0x00002AA4
		public static event AIBaseClientAggro OnAggro
		{
			add
			{
				AIBaseClient.AggroHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.AggroHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before a buff add.
		/// </summary>
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600036C RID: 876 RVA: 0x000036C0 File Offset: 0x00002AC0
		// (remove) Token: 0x0600036D RID: 877 RVA: 0x000036D8 File Offset: 0x00002AD8
		public static event AIBaseClientBuffAdd OnBuffAdd
		{
			add
			{
				AIBaseClient.BuffAddHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.BuffAddHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before a buff remove.
		/// </summary>
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600036E RID: 878 RVA: 0x000036F4 File Offset: 0x00002AF4
		// (remove) Token: 0x0600036F RID: 879 RVA: 0x0000370C File Offset: 0x00002B0C
		public static event AIBaseClientBuffRemove OnBuffRemove
		{
			add
			{
				AIBaseClient.BuffRemoveHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.BuffRemoveHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before starting spell cast.
		/// </summary>
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000370 RID: 880 RVA: 0x00003728 File Offset: 0x00002B28
		// (remove) Token: 0x06000371 RID: 881 RVA: 0x00003740 File Offset: 0x00002B40
		public static event AIBaseClientDoCast OnDoCast
		{
			add
			{
				AIBaseClient.DoCastHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.DoCastHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before issuing order.
		/// </summary>
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000372 RID: 882 RVA: 0x0000375C File Offset: 0x00002B5C
		// (remove) Token: 0x06000373 RID: 883 RVA: 0x00003774 File Offset: 0x00002B74
		public static event AIBaseClientIssueOrder OnIssueOrder
		{
			add
			{
				AIBaseClient.IssueOrderHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.IssueOrderHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before generating new path.
		/// </summary>
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000374 RID: 884 RVA: 0x00003790 File Offset: 0x00002B90
		// (remove) Token: 0x06000375 RID: 885 RVA: 0x000037A8 File Offset: 0x00002BA8
		public static event AIBaseClientNewPath OnNewPath
		{
			add
			{
				AIBaseClient.NewPathHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.NewPathHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before playing animation.
		/// </summary>
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000376 RID: 886 RVA: 0x000037C4 File Offset: 0x00002BC4
		// (remove) Token: 0x06000377 RID: 887 RVA: 0x000037DC File Offset: 0x00002BDC
		public static event AIBaseClientPlayAnimation OnPlayAnimation
		{
			add
			{
				AIBaseClient.PlayAnimationHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.PlayAnimationHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before spell launch.
		/// </summary>
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000378 RID: 888 RVA: 0x000037F8 File Offset: 0x00002BF8
		// (remove) Token: 0x06000379 RID: 889 RVA: 0x00003810 File Offset: 0x00002C10
		public static event AIBaseClientProcessSpellCast OnProcessSpellCast
		{
			add
			{
				AIBaseClient.ProcessSpellCastHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.ProcessSpellCastHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after visible enter client.
		/// </summary>
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600037A RID: 890 RVA: 0x0000382C File Offset: 0x00002C2C
		// (remove) Token: 0x0600037B RID: 891 RVA: 0x00003844 File Offset: 0x00002C44
		public static event AIBaseClientVisibleEnter OnVisibleEnter
		{
			add
			{
				AIBaseClient.VisibleEnterHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.VisibleEnterHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before visible leave client.
		/// </summary>
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600037C RID: 892 RVA: 0x00003860 File Offset: 0x00002C60
		// (remove) Token: 0x0600037D RID: 893 RVA: 0x00003878 File Offset: 0x00002C78
		public static event AIBaseClientVisibleLeave OnVisibleLeave
		{
			add
			{
				AIBaseClient.VisibleLeaveHandlers.Add(value);
			}
			remove
			{
				AIBaseClient.VisibleLeaveHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the character name of the object.
		/// </summary>
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00003894 File Offset: 0x00002C94
		public unsafe string CharacterName
		{
			get
			{
				StlString* ptr = <Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterName(this.GetPtr());
				return new string((*(ptr + 16) + 1 <= 16) ? ptr : (*ptr));
			}
		}

		/// <summary>
		/// 	Gets the skin name of the object.
		/// </summary>
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600037F RID: 895 RVA: 0x000038C4 File Offset: 0x00002CC4
		public unsafe string SkinName
		{
			get
			{
				CharacterData* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterData(this.GetPtr());
				if (ptr != null)
				{
					StlString* ptr2 = <Module>.EnsoulSharp.Native.CharacterData.GetSkinName(ptr);
					return new string((*(ptr2 + 16) + 1 <= 16) ? ptr2 : (*ptr2));
				}
				return "unknown";
			}
		}

		/// <summary>
		/// 	Gets the direction of the object.
		/// </summary>
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00003904 File Offset: 0x00002D04
		public unsafe Vector3 Direction
		{
			get
			{
				Vector3f* ptr = <Module>.EnsoulSharp.Native.FacingDirection.GetTargetFacing(<Module>.EnsoulSharp.Native.AIBaseCommon.GetDirection(this.GetPtr()));
				Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr));
				return result;
			}
		}

		/// <summary>
		/// 	Gets the server position of the object.
		/// </summary>
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0000393C File Offset: 0x00002D3C
		public unsafe Vector3 ServerPosition
		{
			get
			{
				MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
				if (ptr != null)
				{
					PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
					if (ptr2 != null)
					{
						Vector3f* ptr3 = <Module>.EnsoulSharp.Native.PathControllerCommon.GetPosition(ptr2);
						Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr3), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr3), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr3));
						return result;
					}
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the info component base position of the object.
		/// </summary>
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00003990 File Offset: 0x00002D90
		public unsafe Vector3 InfoComponentBasePosition
		{
			get
			{
				UnitInfoComponent* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::UnitInfoComponent\u0020*,EnsoulSharp::Native::UnitInfoComponent,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseClient.GetUnitInfoComponent(this.GetPtr()), null);
				if (ptr != null)
				{
					Vector3f vector3f;
					<Module>.EnsoulSharp.Native.UnitInfoComponent.GetDrawBasePosition(ptr, &vector3f);
					Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetY(ref vector3f));
					return result;
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the health bar position of the object.
		/// </summary>
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000383 RID: 899 RVA: 0x000039E0 File Offset: 0x00002DE0
		public unsafe Vector2 HPBarPosition
		{
			get
			{
				UnitInfoComponent* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::UnitInfoComponent\u0020*,EnsoulSharp::Native::UnitInfoComponent,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseClient.GetUnitInfoComponent(this.GetPtr()), null);
				if (ptr != null)
				{
					Vector2f vector2f;
					<Module>.EnsoulSharp.Native.UnitInfoComponent.GetHealthBarScreenPosition(ptr, &vector2f);
					Vector2 result = new Vector2(<Module>.EnsoulSharp.Native.Vector2f.GetX(ref vector2f), <Module>.EnsoulSharp.Native.Vector2f.GetY(ref vector2f));
					return result;
				}
				return Vector2.Zero;
			}
		}

		/// <summary>
		/// 	Gets the spell book of the object.
		/// </summary>
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00003A28 File Offset: 0x00002E28
		public Spellbook Spellbook
		{
			get
			{
				return new Spellbook(this.m_networkId);
			}
		}

		/// <summary>
		/// 	Gets the first basic attack of the object.
		/// </summary>
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00003A40 File Offset: 0x00002E40
		public unsafe SpellData BasicAttack
		{
			get
			{
				SpellData* ptr = <Module>.EnsoulSharp.Native.AIBaseCommon.GetBasicAttack(this.GetPtr());
				if (ptr != null)
				{
					return new SpellData(ptr);
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the first pet of the object.
		/// </summary>
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00003A64 File Offset: 0x00002E64
		public unsafe GameObject Pet
		{
			get
			{
				uint* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetPetObjectIds(this.GetPtr());
				if (ptr != null)
				{
					return ObjectManager.CreateObjectFromPointer(<Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex(*ptr));
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the inventory items of the object.
		/// </summary>
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00003A90 File Offset: 0x00002E90
		public unsafe InventorySlot[] InventoryItems
		{
			get
			{
				List<InventorySlot> list = new List<InventorySlot>();
				BaseInventory* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetInventory(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						InventorySlot* ptr2 = *(num * 4 + <Module>.EnsoulSharp.Native.HeroInventoryCommon.GetInventory(ptr));
						if (ptr2 != null && *<Module>.EnsoulSharp.Native.InventorySlot.GetItemInInventory(ptr2) != 0)
						{
							list.Add(new InventorySlot(this.m_networkId, (uint)num));
						}
						num++;
					}
					while (num < 39);
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the buffs of the object.
		/// </summary>
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00004FF4 File Offset: 0x000043F4
		public unsafe BuffInstance[] Buffs
		{
			get
			{
				List<BuffInstance> list = new List<BuffInstance>();
				StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffManager.GetSpellBuffs(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellBuffsClient(this.GetPtr()));
				StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)))
				{
					do
					{
						BuffInstanceClient* ptr3 = *(int*)ptr2;
						if (ptr3 != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr3) != null)
						{
							list.Add(new BuffInstance(ptr3));
						}
						ptr2 += 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>);
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)));
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the next path of the object.
		/// </summary>
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00003AF0 File Offset: 0x00002EF0
		public unsafe Vector3[] Path
		{
			get
			{
				List<Vector3> list = new List<Vector3>();
				MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
				if (ptr != null)
				{
					PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
					if (ptr2 != null && *<Module>.EnsoulSharp.Native.PathControllerCommon.GetPathActive(ptr2) != 0)
					{
						NavigationPath* ptr3 = <Module>.EnsoulSharp.Native.PathControllerCommon.GetPath(ptr2);
						uint num = (uint)(*<Module>.EnsoulSharp.Native.NavigationPath.GetNextWaypointIndex(ptr3));
						StlArray<EnsoulSharp::Native::Vector3f>* ptr4 = <Module>.EnsoulSharp.Native.NavigationPath.GetWaypointList(ptr3);
						uint num2 = num;
						if (num < (uint)(*(int*)(ptr4 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))))
						{
							int num3 = (int)(num * 12U);
							do
							{
								Vector3f* ptr5 = *(int*)ptr4 + num3;
								if (<Module>.EnsoulSharp.Native.Vector3f.IsValid(ptr5) != null)
								{
									Vector3 item = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr5), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr5), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr5));
									list.Add(item);
								}
								num2 += 1U;
								num3 += 12;
							}
							while (num2 < (uint)(*(int*)(ptr4 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))));
						}
					}
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the combat type of the object.
		/// </summary>
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00003BAC File Offset: 0x00002FAC
		public unsafe GameObjectCombatType CombatType
		{
			get
			{
				return (GameObjectCombatType)(*<Module>.EnsoulSharp.Native.AIBaseCommon.GetCombatType(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the skin id of the object.
		/// </summary>
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00003BC8 File Offset: 0x00002FC8
		public unsafe int SkinId
		{
			get
			{
				CharacterData* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterData(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.CharacterData.GetCharacterSkinID(ptr);
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the character state indicator index of the object.
		/// </summary>
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00003BF0 File Offset: 0x00002FF0
		public unsafe int CharacterStateIndicatorIndex
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterStateIndicatorIndexData.GetIndex(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterStateIndicatorIndex(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the character state indicator index is active.
		/// </summary>
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00003C10 File Offset: 0x00003010
		public unsafe bool CharacterStateIndicatorActive
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterStateIndicatorIndexData.GetActive(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterStateIndicatorIndex(this.GetPtr())) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object's health bar is rendered.
		/// </summary>
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00003C30 File Offset: 0x00003030
		public bool IsHPBarRendered
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.AIBaseClient.IsHPBarRendered(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object looks like invulnerable.
		/// </summary>
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00003C48 File Offset: 0x00003048
		public bool IsInvulnerableVisual
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.AIBaseClient.IsInvulnerableVisual(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is moving.
		/// </summary>
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00003C60 File Offset: 0x00003060
		public unsafe bool IsMoving
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
				if (ptr != null)
				{
					PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.PathControllerCommon.GetPathActive(ptr2) != 0;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is winding up.
		/// </summary>
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00003C98 File Offset: 0x00003098
		public bool IsWindingUp
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Spellbook.IsCastObjectWindingUp(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellbook(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is melee.
		/// </summary>
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00003CB8 File Offset: 0x000030B8
		public unsafe bool IsMelee
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((*<Module>.EnsoulSharp.Native.AIBaseCommon.GetCombatType(this.GetPtr()) == 1) ? 1 : 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is ranged.
		/// </summary>
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00003CD8 File Offset: 0x000030D8
		public unsafe bool IsRanged
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((*<Module>.EnsoulSharp.Native.AIBaseCommon.GetCombatType(this.GetPtr()) == 2) ? 1 : 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object's path can be overridden.
		/// </summary>
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00003CF8 File Offset: 0x000030F8
		public unsafe bool PathOverrideable
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
				if (ptr != null)
				{
					PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.NavigationPath.GetOverrideable(<Module>.EnsoulSharp.Native.PathControllerCommon.GetPath(ptr2)) != 0;
					}
				}
				return true;
			}
		}

		/// <summary>
		/// 	Gets the override speed of the path of the object.
		/// </summary>
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00003D34 File Offset: 0x00003134
		public unsafe float PathOverrideSpeed
		{
			get
			{
				MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
				if (ptr != null)
				{
					PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.NavigationPath.GetPathOverrideSpeed(<Module>.EnsoulSharp.Native.PathControllerCommon.GetPath(ptr2));
					}
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the duration of death of the object.
		/// </summary>
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00003D74 File Offset: 0x00003174
		public float DeathDuration
		{
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<float,float,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetDeathDuration(this.GetPtr()), 0f);
			}
		}

		/// <summary>
		/// 	Gets the experience give radius of the object.
		/// </summary>
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00003D98 File Offset: 0x00003198
		public float ExpGiveRadius
		{
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<float,float,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetExpGiveRadius(this.GetPtr()), 0f);
			}
		}

		/// <summary>
		/// 	Gets the current gold of the object.
		/// </summary>
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00003DBC File Offset: 0x000031BC
		public unsafe float Gold
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Gold.GetValue(<Module>.EnsoulSharp.Native.AIBaseCommon.GetGold(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the total gold of the object.
		/// </summary>
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00003DDC File Offset: 0x000031DC
		public unsafe float GoldTotal
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Gold.GetTotal(<Module>.EnsoulSharp.Native.AIBaseCommon.GetGold(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the bonus health of the object.
		/// </summary>
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00003DFC File Offset: 0x000031FC
		public unsafe float BonusHealth
		{
			get
			{
				AIBaseClient* ptr = this.GetPtr();
				double num = (double)(*<Module>.EnsoulSharp.Native.Health.GetMax(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(ptr)));
				return (float)(num - <Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterBaseHealth(ptr));
			}
		}

		/// <summary>
		/// 	Gets the bonus mana of the object.
		/// </summary>
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00005050 File Offset: 0x00004450
		public float BonusMana
		{
			get
			{
				return this.GetAbilityResource(AbilityResourceType.Mana, OutputType.Bonus);
			}
		}

		/// <summary>
		/// 	Gets the attack cast delay of the object.
		/// </summary>
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00003E28 File Offset: 0x00003228
		public float AttackCastDelay
		{
			get
			{
				return <Module>.EnsoulSharp.Native.AIBaseClient.ComputeCharacterAttackCastDelay(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the attack delay of the object.
		/// </summary>
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00003E40 File Offset: 0x00003240
		public float AttackDelay
		{
			get
			{
				return <Module>.EnsoulSharp.Native.AIBaseClient.ComputeCharacterAttackDelay(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object can attack.
		/// </summary>
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00003E58 File Offset: 0x00003258
		public bool CanAttack
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.CanAttack(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object can cast.
		/// </summary>
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00003E78 File Offset: 0x00003278
		public bool CanCast
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.CanCast(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object can move.
		/// </summary>
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00003E98 File Offset: 0x00003298
		public bool CanMove
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.CanMove(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object can walk.
		/// </summary>
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00003EB8 File Offset: 0x000032B8
		public bool CanWalk
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.CanWalk(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is asleep.
		/// </summary>
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00003ED8 File Offset: 0x000032D8
		public bool IsAsleep
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsAsleep(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is charmed.
		/// </summary>
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00003EF8 File Offset: 0x000032F8
		public bool IsCharmed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsCharmed(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is clickproof to enemies.
		/// </summary>
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00003F18 File Offset: 0x00003318
		public bool IsClickproofToEnemies
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsClickproofToEnemies(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is cursor allowed while untargetable.
		/// </summary>
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00003F38 File Offset: 0x00003338
		public bool IsCursorAllowedWhileUntargetable
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsCursorAllowedWhileUntargetable(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is dodging missiles.
		/// </summary>
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00003F58 File Offset: 0x00003358
		public bool IsDodgingMissiles
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsDodgingMissiles(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is feared.
		/// </summary>
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00003F78 File Offset: 0x00003378
		public bool IsFeared
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsFeared(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is fleeing.
		/// </summary>
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00003F98 File Offset: 0x00003398
		public bool IsFleeing
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsFleeing(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is force render particles.
		/// </summary>
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00003FB8 File Offset: 0x000033B8
		public bool IsForceRenderParticles
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsForceRenderParticles(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is ghosted.
		/// </summary>
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00003FD8 File Offset: 0x000033D8
		public bool IsGhosted
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsGhosted(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is ghoested for allies.
		/// </summary>
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00003FF8 File Offset: 0x000033F8
		public bool IsGhostedForAllies
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsGhostedForAllies(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is grounded.
		/// </summary>
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00004018 File Offset: 0x00003418
		public bool IsGrounded
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsGrounded(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is near sight.
		/// </summary>
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003AD RID: 941 RVA: 0x00004038 File Offset: 0x00003438
		public bool IsNearSight
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsNearSight(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is no render.
		/// </summary>
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00004058 File Offset: 0x00003458
		public bool IsNoRender
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsNoRender(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is obscured.
		/// </summary>
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060003AF RID: 943 RVA: 0x00004078 File Offset: 0x00003478
		public bool IsObscured
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsObscured(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is reveal specific unit.
		/// </summary>
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00004098 File Offset: 0x00003498
		public bool IsRevealSpecificUnit
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsRevealSpecificUnit(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is selectable.
		/// </summary>
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000040B8 File Offset: 0x000034B8
		public bool IsSelectable
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsSelectable(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is slowed.
		/// </summary>
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000040D8 File Offset: 0x000034D8
		public bool IsSlowed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsSlowed(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is stealthed.
		/// </summary>
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x000040F8 File Offset: 0x000034F8
		public bool IsStealthed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsStealthed(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is stunned.
		/// </summary>
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00004118 File Offset: 0x00003518
		public bool IsStunned
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsStunned(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is suppressed.
		/// </summary>
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00004138 File Offset: 0x00003538
		public bool IsSuppressed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsSuppressed(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is taunted.
		/// </summary>
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00004158 File Offset: 0x00003558
		public bool IsTaunted
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterState.IsTaunted(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharState(this.GetPtr())) != null;
			}
		}

		/// <summary>
		/// 	Gets the ability haste mod of the object.
		/// </summary>
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00004178 File Offset: 0x00003578
		public unsafe float AbilityHasteMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetAbilityHasteMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent cooldown mod of the object.
		/// </summary>
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00004198 File Offset: 0x00003598
		public unsafe float PercentCooldownMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentCooldownMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat magic damage mod of the object.
		/// </summary>
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x000041B8 File Offset: 0x000035B8
		public unsafe float FlatMagicDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatMagicDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent magic damage mod of the object.
		/// </summary>
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003BA RID: 954 RVA: 0x000041D8 File Offset: 0x000035D8
		public unsafe float PercentMagicDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentMagicDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the base ability damage of the object.
		/// </summary>
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003BB RID: 955 RVA: 0x000041F8 File Offset: 0x000035F8
		public unsafe float BaseAbilityDamage
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBaseAbilityDamage(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat physical damage mod of the object.
		/// </summary>
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00004218 File Offset: 0x00003618
		public unsafe float FlatPhysicalDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatPhysicalDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent physical damage mod of the object.
		/// </summary>
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00004238 File Offset: 0x00003638
		public unsafe float PercentPhysicalDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentPhysicalDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent bonus physical damage mod of the object.
		/// </summary>
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00004258 File Offset: 0x00003658
		public unsafe float PercentBonusPhysicalDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentBonusPhysicalDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent base physical damage as flat bonus mod of the object.
		/// </summary>
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00004278 File Offset: 0x00003678
		public unsafe float PercentBasePhysicalDamageAsFlatBonusMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentBasePhysicalDamageAsFlatBonusMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the base attack damage of the object.
		/// </summary>
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00004298 File Offset: 0x00003698
		public unsafe float BaseAttackDamage
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBaseAttackDamage(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent life steal mod of the object.
		/// </summary>
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x000042B8 File Offset: 0x000036B8
		public unsafe float PercentLifeStealMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentLifeStealMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent attack speed mod of the object.
		/// </summary>
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000042D8 File Offset: 0x000036D8
		public unsafe float PercentAttackSpeedMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentAttackSpeedMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the attack speed mod of the object.
		/// </summary>
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x000042F8 File Offset: 0x000036F8
		public unsafe float AttackSpeedMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetAttackSpeedMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat crit chance mod of the object.
		/// </summary>
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00004318 File Offset: 0x00003718
		public unsafe float FlatCritChanceMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatCritChanceMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat crit damage mod of the object.
		/// </summary>
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x00004338 File Offset: 0x00003738
		public unsafe float FlatCritDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatCritDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent crit damage mod of the object.
		/// </summary>
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00004358 File Offset: 0x00003758
		public unsafe float PercentCritDamageMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentCritDamageMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the crit damage multiplier of the object.
		/// </summary>
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00004378 File Offset: 0x00003778
		public unsafe float CritDamageMultiplier
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetCritDamageMultiplier(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the crit of the object.
		/// </summary>
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00004398 File Offset: 0x00003798
		public unsafe float Crit
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetCrit(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the armor of the object.
		/// </summary>
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000043B8 File Offset: 0x000037B8
		public unsafe float Armor
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetArmor(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the bonus armor of the object.
		/// </summary>
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060003CA RID: 970 RVA: 0x000043D8 File Offset: 0x000037D8
		public unsafe float BonusArmor
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBonusArmor(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the spell block of the object.
		/// </summary>
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060003CB RID: 971 RVA: 0x000043F8 File Offset: 0x000037F8
		public unsafe float SpellBlock
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetSpellBlock(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the bonus spell block of the object.
		/// </summary>
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060003CC RID: 972 RVA: 0x00004418 File Offset: 0x00003818
		public unsafe float BonusSpellBlock
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBonusSpellBlock(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the base par regen rate of the object.
		/// </summary>
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00004438 File Offset: 0x00003838
		public unsafe float BasePARRegenRate
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBasePARRegenRate(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the par regen rate of the object.
		/// </summary>
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00004458 File Offset: 0x00003858
		public unsafe float PARRegenRate
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPARRegenRate(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the base hp regen rate of the object.
		/// </summary>
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00004478 File Offset: 0x00003878
		public unsafe float BaseHPRegenRate
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetBaseHPRegenRate(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the hp regen rate of the object.
		/// </summary>
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00004498 File Offset: 0x00003898
		public unsafe float HPRegenRate
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetHPRegenRate(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the move speed of the object.
		/// </summary>
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x000044B8 File Offset: 0x000038B8
		public unsafe float MoveSpeed
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetMoveSpeed(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the attack range of the object.
		/// </summary>
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x000044D8 File Offset: 0x000038D8
		public unsafe float AttackRange
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetAttackRange(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat armor penetration mod of the object.
		/// </summary>
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x000044F8 File Offset: 0x000038F8
		public unsafe float FlatArmorPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatArmorPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the flat magic penetration mod of the object.
		/// </summary>
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00004518 File Offset: 0x00003918
		public unsafe float FlatMagicPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatMagicPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent armor penetration mod of the object.
		/// </summary>
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004538 File Offset: 0x00003938
		public unsafe float PercentArmorPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentArmorPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent magic penetration mod of the object.
		/// </summary>
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00004558 File Offset: 0x00003958
		public unsafe float PercentMagicPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentMagicPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent bonus armor penetration mod of the object.
		/// </summary>
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00004578 File Offset: 0x00003978
		public unsafe float PercentBonusArmorPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentBonusArmorPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent bonus magic penetration mod of the object.
		/// </summary>
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00004598 File Offset: 0x00003998
		public unsafe float PercentBonusMagicPenetrationMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentBonusMagicPenetrationMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the physical lethality of the object.
		/// </summary>
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x000045B8 File Offset: 0x000039B8
		public unsafe float PhysicalLethality
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPhysicalLethality(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the magic lethality of the object.
		/// </summary>
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060003DA RID: 986 RVA: 0x000045D8 File Offset: 0x000039D8
		public unsafe float MagicLethality
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetMagicLethality(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent spell vamp mod.
		/// </summary>
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060003DB RID: 987 RVA: 0x000045F8 File Offset: 0x000039F8
		public unsafe float PercentSpellVampMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentSpellVampMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the percent omnivamp mod.
		/// </summary>
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00004618 File Offset: 0x00003A18
		public unsafe float PercentOmnivampMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentOmnivampMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	 Gets the percent physical vamp mod.
		/// </summary>
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060003DD RID: 989 RVA: 0x000046B8 File Offset: 0x00003AB8
		public unsafe float PercentPhysicalVampMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentPhysicalVampMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00004638 File Offset: 0x00003A38
		public unsafe float FlatDamageToBarracksMinionMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatDamageToBarracksMinionMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00004658 File Offset: 0x00003A58
		public unsafe float PercentDamageToBarracksMinionMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentDamageToBarracksMinionMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00004678 File Offset: 0x00003A78
		public unsafe float FlatDamageReductionFromBarracksMinionMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetFlatDamageReductionFromBarracksMinionMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x00004698 File Offset: 0x00003A98
		public unsafe float PercentDamageReductionFromBarracksMinionMod
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.CharacterIntermediate.GetPercentDamageReductionFromBarracksMinionMod(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the total attack damage of the object.
		/// </summary>
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x000046D8 File Offset: 0x00003AD8
		public float TotalAttackDamage
		{
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterIntermediate.GetTotalAttackDamage(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the total magical damage of the object.
		/// </summary>
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x000046F8 File Offset: 0x00003AF8
		public float TotalMagicalDamage
		{
			get
			{
				return <Module>.EnsoulSharp.Native.CharacterIntermediate.GetTotalAbilityPower(<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharInter(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the base hp of the object.
		/// </summary>
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00004718 File Offset: 0x00003B18
		public unsafe float BaseHP
		{
			get
			{
				CharacterData* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterData(this.GetPtr());
				if (ptr != null)
				{
					CharacterRecord* ptr2 = *<Module>.EnsoulSharp.Native.CharacterData.GetCharRecord(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.CharacterRecord.GetBaseHP(ptr2);
					}
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the base move speed of the object.
		/// </summary>
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00004750 File Offset: 0x00003B50
		public unsafe float BaseMoveSpeed
		{
			get
			{
				CharacterData* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetCharacterData(this.GetPtr());
				if (ptr != null)
				{
					CharacterRecord* ptr2 = *<Module>.EnsoulSharp.Native.CharacterData.GetCharRecord(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.CharacterRecord.GetBaseMoveSpeed(ptr2);
					}
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Sets a specific skin.
		/// </summary>
		/// <param name="skinId">The skin id.</param>
		// Token: 0x060003E6 RID: 998 RVA: 0x00004788 File Offset: 0x00003B88
		public void SetSkin(int skinId)
		{
			<Module>.EnsoulSharp.Native.AIBaseCommon.PushCharacterData(this.GetPtr(), skinId);
		}

		/// <summary>
		/// 	Gets whether the object can use.
		/// </summary>
		/// <param name="target">The object.</param>
		/// <returns>A value indicating whether the object can use.</returns>
		// Token: 0x060003E7 RID: 999 RVA: 0x000047A4 File Offset: 0x00003BA4
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CanUseObject(AttackableUnit target)
		{
			return <Module>.EnsoulSharp.Native.AIBaseCommon.CanUseObject(this.GetPtr(), target.GetPtr()) != null;
		}

		/// <summary>
		/// 	Uses a object.
		/// </summary>
		/// <param name="target">The object.</param>
		/// <returns>A value indicating whether successfully use the object.</returns>
		// Token: 0x060003E8 RID: 1000 RVA: 0x000047C4 File Offset: 0x00003BC4
		[return: MarshalAs(UnmanagedType.U1)]
		public bool UseObject(AttackableUnit target)
		{
			return <Module>.EnsoulSharp.Native.AIBaseCommon.UseObject(this.GetPtr(), target.GetPtr()) != null;
		}

		/// <summary>
		/// 	Gets the specific ability resource value.
		/// </summary>
		/// <param name="abilityResourceType">The ability resource type.</param>
		/// <param name="outputType">The output type.</param>
		/// <returns>The ability resource value.</returns>
		// Token: 0x060003E9 RID: 1001 RVA: 0x000047E4 File Offset: 0x00003BE4
		public unsafe float GetAbilityResource(AbilityResourceType abilityResourceType, OutputType outputType)
		{
			IGameCalculationOwner* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetGameCalculationOwner(this.GetPtr());
			if (ptr != null)
			{
				return <Module>.EnsoulSharp.Native.IGameCalculationOwnerVtbl.GetAbilityResourceTotal(<Module>.EnsoulSharp.Native.IGameCalculationOwner.GetVftable(ptr), (AbilityResourceType)abilityResourceType, (OutputType)outputType);
			}
			return 0f;
		}

		/// <summary>
		/// 	Gets buff with specified name.
		/// </summary>
		/// <param name="name">The buff name.</param>
		/// <returns>The <see cref="T:EnsoulSharp.BuffInstance" /> result.</returns>
		// Token: 0x060003EA RID: 1002 RVA: 0x00005068 File Offset: 0x00004468
		public unsafe BuffInstance GetBuff(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				IntPtr hglobal = Marshal.StringToHGlobalAnsi(name);
				StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffManager.GetSpellBuffs(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellBuffsClient(this.GetPtr()));
				StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)))
				{
					BuffInstanceClient* ptr3;
					do
					{
						ptr3 = *(int*)ptr2;
						if (ptr3 != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr3) != null)
						{
							ScriptBaseBuff* ptr4 = *<Module>.EnsoulSharp.Native.BuffInstance.GetScript(ptr3);
							if (ptr4 != null && <Module>._stricmp(<Module>.EnsoulSharp.Native.ScriptBase.GetScriptName(ptr4), (sbyte*)hglobal.ToPointer()) == null)
							{
								goto IL_65;
							}
						}
						ptr2 += 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>);
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)));
					goto IL_73;
					IL_65:
					Marshal.FreeHGlobal(hglobal);
					return new BuffInstance(ptr3);
				}
				IL_73:
				Marshal.FreeHGlobal(hglobal);
			}
			return null;
		}

		/// <summary>
		/// 	Gets buff count with specified name.
		/// </summary>
		/// <param name="name">The buff name.</param>
		/// <returns>The buff count.</returns>
		// Token: 0x060003EB RID: 1003 RVA: 0x000050F0 File Offset: 0x000044F0
		public unsafe int GetBuffCount(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				IntPtr hglobal = Marshal.StringToHGlobalAnsi(name);
				StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffManager.GetSpellBuffs(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellBuffsClient(this.GetPtr()));
				StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)))
				{
					BuffInstanceClient* ptr3;
					do
					{
						ptr3 = *(int*)ptr2;
						if (ptr3 != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr3) != null)
						{
							ScriptBaseBuff* ptr4 = *<Module>.EnsoulSharp.Native.BuffInstance.GetScript(ptr3);
							if (ptr4 != null && <Module>._stricmp(<Module>.EnsoulSharp.Native.ScriptBase.GetScriptName(ptr4), (sbyte*)hglobal.ToPointer()) == null)
							{
								goto IL_65;
							}
						}
						ptr2 += 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>);
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)));
					goto IL_73;
					IL_65:
					Marshal.FreeHGlobal(hglobal);
					return <Module>.EnsoulSharp.Native.BuffInstance.GetCount(ptr3);
				}
				IL_73:
				Marshal.FreeHGlobal(hglobal);
			}
			return 0;
		}

		/// <summary>
		/// 	Gets whether the object has buff with specified name.
		/// </summary>
		/// <param name="name">The buff name.</param>
		/// <returns>A value indicating whether the object has buff.</returns>
		// Token: 0x060003EC RID: 1004 RVA: 0x00005178 File Offset: 0x00004578
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool HasBuff(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				IntPtr hglobal = Marshal.StringToHGlobalAnsi(name);
				StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffManager.GetSpellBuffs(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellBuffsClient(this.GetPtr()));
				StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)))
				{
					do
					{
						BuffInstanceClient* ptr3 = *(int*)ptr2;
						if (ptr3 != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr3) != null)
						{
							ScriptBaseBuff* ptr4 = *<Module>.EnsoulSharp.Native.BuffInstance.GetScript(ptr3);
							if (ptr4 != null && <Module>._stricmp(<Module>.EnsoulSharp.Native.ScriptBase.GetScriptName(ptr4), (sbyte*)hglobal.ToPointer()) == null)
							{
								goto IL_65;
							}
						}
						ptr2 += 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>);
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)));
					goto IL_6E;
					IL_65:
					Marshal.FreeHGlobal(hglobal);
					return true;
				}
				IL_6E:
				Marshal.FreeHGlobal(hglobal);
			}
			return false;
		}

		/// <summary>
		/// 	Gets whether the object has buff with specified type.
		/// </summary>
		/// <param name="type">The buff type.</param>
		/// <returns>A value indicating whether the object has buff.</returns>
		// Token: 0x060003ED RID: 1005 RVA: 0x000051FC File Offset: 0x000045FC
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool HasBuffOfType(BuffType type)
		{
			StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffManager.GetSpellBuffs(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellBuffsClient(this.GetPtr()));
			StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>* ptr2 = *(int*)ptr;
			if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)))
			{
				do
				{
					BuffInstanceClient* ptr3 = *(int*)ptr2;
					if (ptr3 != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr3) != null && *<Module>.EnsoulSharp.Native.BuffInstance.GetType(ptr3) == (byte)type)
					{
						return true;
					}
					ptr2 += 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>);
				}
				while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>)));
				return false;
			}
			return false;
		}

		/// <summary>
		/// 	Gets the path from start position to end position, and you can specify whether smooth the path.
		/// </summary>
		/// <param name="start">The start position.</param>
		/// <param name="end">The end position.</param>
		/// <param name="smoothPath">A value indicating whether smooth the path.</param>
		/// <returns>The path.</returns>
		// Token: 0x060003EE RID: 1006 RVA: 0x0000492C File Offset: 0x00003D2C
		public unsafe Vector3[] GetPath(Vector3 start, Vector3 end, [MarshalAs(UnmanagedType.U1)] bool smoothPath)
		{
			List<Vector3> list = new List<Vector3>();
			MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
			if (ptr != null)
			{
				PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
				if (ptr2 != null)
				{
					NavigationPath navigationPath;
					<Module>.EnsoulSharp.Native.NavigationPath.{ctor}(ref navigationPath);
					try
					{
						Vector3f vector3f;
						Vector3f vector3f2;
						if (<Module>.EnsoulSharp.Native.PathControllerCommon.CreatePath(ptr2, <Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, start.X, start.Z, start.Y), <Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f2, end.X, end.Z, end.Y), &navigationPath) != null)
						{
							if (smoothPath)
							{
								<Module>.EnsoulSharp.Native.PathControllerCommon.SmoothPath(ptr2, &navigationPath);
							}
							StlArray<EnsoulSharp::Native::Vector3f>* ptr3 = <Module>.EnsoulSharp.Native.NavigationPath.GetWaypointList(ref navigationPath);
							uint num = 0U;
							if (0 < *(int*)(ptr3 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>)))
							{
								int num2 = 0;
								do
								{
									Vector3f* ptr4 = *(int*)ptr3 + num2;
									if (<Module>.EnsoulSharp.Native.Vector3f.IsValid(ptr4) != null)
									{
										Vector3 item = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr4), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr4), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr4));
										list.Add(item);
									}
									num += 1U;
									num2 += 12;
								}
								while (num < (uint)(*(int*)(ptr3 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))));
							}
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(EnsoulSharp.Native.NavigationPath.{dtor}), (void*)(&navigationPath));
						throw;
					}
					<Module>.EnsoulSharp.Native.NavigationPath.{dtor}(ref navigationPath);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 	Gets the path from start position to end position.
		/// </summary>
		/// <param name="start">The start position.</param>
		/// <param name="end">The end position.</param>
		/// <returns>The path.</returns>
		// Token: 0x060003EF RID: 1007 RVA: 0x00005268 File Offset: 0x00004668
		public Vector3[] GetPath(Vector3 start, Vector3 end)
		{
			return this.GetPath(start, end, false);
		}

		/// <summary>
		/// 	Gets the path from object position to end position, and you can specify whether smooth the path.
		/// </summary>
		/// <param name="end">The end position.</param>
		/// <param name="smoothPath">A value indicating whether smooth the path.</param>
		/// <returns>The path.</returns>
		// Token: 0x060003F0 RID: 1008 RVA: 0x00004814 File Offset: 0x00003C14
		public unsafe Vector3[] GetPath(Vector3 end, [MarshalAs(UnmanagedType.U1)] bool smoothPath)
		{
			List<Vector3> list = new List<Vector3>();
			MovementControllerClient* ptr = <Module>.EnsoulSharp.Native.TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AIBaseCommon.GetMovementController(this.GetPtr()), null);
			if (ptr != null)
			{
				PathControllerClient* ptr2 = *<Module>.EnsoulSharp.Native.MovementControllerCommon.GetPathController(ptr);
				if (ptr2 != null)
				{
					NavigationPath navigationPath;
					<Module>.EnsoulSharp.Native.NavigationPath.{ctor}(ref navigationPath);
					try
					{
						Vector3f vector3f;
						if (<Module>.EnsoulSharp.Native.PathControllerCommon.CreatePath(ptr2, <Module>.EnsoulSharp.Native.GameObject.GetPosition(this.GetPtr()), <Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, end.X, end.Z, end.Y), &navigationPath) != null)
						{
							if (smoothPath)
							{
								<Module>.EnsoulSharp.Native.PathControllerCommon.SmoothPath(ptr2, &navigationPath);
							}
							StlArray<EnsoulSharp::Native::Vector3f>* ptr3 = <Module>.EnsoulSharp.Native.NavigationPath.GetWaypointList(ref navigationPath);
							uint num = 0U;
							if (0 < *(int*)(ptr3 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>)))
							{
								int num2 = 0;
								do
								{
									Vector3f* ptr4 = num2 + *(int*)ptr3;
									if (<Module>.EnsoulSharp.Native.Vector3f.IsValid(ptr4) != null)
									{
										Vector3 item = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr4), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr4), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr4));
										list.Add(item);
									}
									num += 1U;
									num2 += 12;
								}
								while (num < (uint)(*(int*)(ptr3 + 4 / sizeof(StlArray<EnsoulSharp::Native::Vector3f>))));
							}
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(EnsoulSharp.Native.NavigationPath.{dtor}), (void*)(&navigationPath));
						throw;
					}
					<Module>.EnsoulSharp.Native.NavigationPath.{dtor}(ref navigationPath);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 	Gets the path from object position to end position.
		/// </summary>
		/// <param name="end">The end position.</param>
		/// <returns>The path.</returns>
		// Token: 0x060003F1 RID: 1009 RVA: 0x00005250 File Offset: 0x00004650
		public Vector3[] GetPath(Vector3 end)
		{
			return this.GetPath(end, false);
		}

		/// <summary>
		/// 	Gets the tooltip calculation strings from given spell at specific spell level with specific calculation display mode.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <param name="mode">The mode</param>
		/// <param name="level">The spell level.</param>
		/// <returns>The strings.</returns>
		// Token: 0x060003F2 RID: 1010 RVA: 0x00004A54 File Offset: 0x00003E54
		public unsafe string[] GetSpellTooltipCalculationStrings(SpellDataInst spell, CalculationDisplayMode mode, int level)
		{
			List<string> list = new List<string>();
			IGameCalculationOwner* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetGameCalculationOwner(this.GetPtr());
			if (ptr != null)
			{
				SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(spell.GetPtr());
				if (ptr2 != null)
				{
					SpellDataResource* ptr3 = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(ptr2);
					if (ptr3 != null)
					{
						StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>* ptr4 = <Module>.EnsoulSharp.Native.SpellDataResource.GetSpellCalculations(ptr3);
						uint num = 0U;
						if (0 < *(int*)(ptr4 + 4 / sizeof(StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>)))
						{
							do
							{
								IGameCalculation* ptr5 = *(num * 8U + (uint)(*(int*)ptr4) + 4U);
								if (ptr5 != null)
								{
									StlAString value;
									<Module>.EnsoulSharp.Native.StlAString.{ctor}(ref value);
									try
									{
										<Module>.EnsoulSharp.Native.IGameCalculationVtbl.GetStringResult(<Module>.EnsoulSharp.Native.IGameCalculation.GetVftable(ptr5), ptr, (IGameCalculationDataSource*)ptr2, (SpellSlot)spell.Slot, level, (CalculationDisplayMode)mode, &value);
										list.Add(new string(value));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(EnsoulSharp.Native.StlAString.{dtor}), (void*)(&value));
										throw;
									}
									<Module>.EnsoulSharp.Native.StlAString.{dtor}(ref value);
								}
								num += 1U;
							}
							while (num < (uint)(*(int*)(ptr4 + 4 / sizeof(StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>))));
						}
					}
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 	Gets the tooltip calculation strings from given spell at current spell level with specific calculation display mode.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <param name="mode">The mode.</param>
		/// <returns>The strings.</returns>
		// Token: 0x060003F3 RID: 1011 RVA: 0x00005280 File Offset: 0x00004680
		public string[] GetSpellTooltipCalculationStrings(SpellDataInst spell, CalculationDisplayMode mode)
		{
			return this.GetSpellTooltipCalculationStrings(spell, mode, spell.Level);
		}

		/// <summary>
		/// 	Gets the tooltip calculation values from given spell at specific spell level.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <param name="level">The spell level.</param>
		/// <returns>The values.</returns>
		// Token: 0x060003F4 RID: 1012 RVA: 0x00004B30 File Offset: 0x00003F30
		public unsafe float[] GetSpellTooltipCalculationValues(SpellDataInst spell, int level)
		{
			List<float> list = new List<float>();
			IGameCalculationOwner* ptr = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetGameCalculationOwner(this.GetPtr());
			if (ptr != null)
			{
				SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(spell.GetPtr());
				if (ptr2 != null)
				{
					SpellDataResource* ptr3 = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(ptr2);
					if (ptr3 != null)
					{
						StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>* ptr4 = <Module>.EnsoulSharp.Native.SpellDataResource.GetSpellCalculations(ptr3);
						uint num = 0U;
						if (0 < *(int*)(ptr4 + 4 / sizeof(StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>)))
						{
							do
							{
								IGameCalculation* ptr5 = *(num * 8U + (uint)(*(int*)ptr4) + 4U);
								if (ptr5 != null)
								{
									list.Add(<Module>.EnsoulSharp.Native.IGameCalculationVtbl.GetResult(<Module>.EnsoulSharp.Native.IGameCalculation.GetVftable(ptr5), ptr, (IGameCalculationDataSource*)ptr2, (SpellSlot)spell.Slot, level));
								}
								num += 1U;
							}
							while (num < (uint)(*(int*)(ptr4 + 4 / sizeof(StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>))));
						}
					}
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 	Gets the tooltip calculation values from given spell at current spell level.
		/// </summary>
		/// <param name="spell">The spell.</param>
		/// <returns>The values.</returns>
		// Token: 0x060003F5 RID: 1013 RVA: 0x0000529C File Offset: 0x0000469C
		public float[] GetSpellTooltipCalculationValues(SpellDataInst spell)
		{
			return this.GetSpellTooltipCalculationValues(spell, spell.Level);
		}

		/// <summary>
		/// 	Issues order at the given position, and you can specify whether trigger event.
		/// </summary>
		/// <param name="order">The order.</param>
		/// <param name="targetPos">The position.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether successfully issue the order.</returns>
		// Token: 0x060003F6 RID: 1014 RVA: 0x00004BE8 File Offset: 0x00003FE8
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool IssueOrder(GameObjectOrder order, Vector3 targetPos, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			Vector3f vector3f;
			<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, targetPos.X, targetPos.Z, targetPos.Y);
			return <Module>.EnsoulSharp.Native.AIBaseClient.IssueOrder(this.GetPtr(), &vector3f, null, (IssuedOrder)order, triggerEvent) != null;
		}

		/// <summary>
		/// 	Issues order at the given position.
		/// </summary>
		/// <param name="order">The order.</param>
		/// <param name="targetPos">The position.</param>
		/// <returns>A value indicating whether successfully issue the order.</returns>
		// Token: 0x060003F7 RID: 1015 RVA: 0x000052D0 File Offset: 0x000046D0
		[return: MarshalAs(UnmanagedType.U1)]
		public bool IssueOrder(GameObjectOrder order, Vector3 targetPos)
		{
			return this.IssueOrder(order, targetPos, true);
		}

		/// <summary>
		/// 	Issues order on the given unit, and you can specify whether trigger event.
		/// </summary>
		/// <param name="order">The order.</param>
		/// <param name="targetUnit">The unit.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether successfully issue the order.</returns>
		// Token: 0x060003F8 RID: 1016 RVA: 0x00004BC0 File Offset: 0x00003FC0
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool IssueOrder(GameObjectOrder order, AttackableUnit targetUnit, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			AttackableUnit* ptr = targetUnit.GetPtr();
			return <Module>.EnsoulSharp.Native.AIBaseClient.IssueOrder(this.GetPtr(), <Module>.EnsoulSharp.Native.GameObject.GetPosition(ptr), ptr, (IssuedOrder)order, triggerEvent) != null;
		}

		/// <summary>
		/// 	Issues order on the given unit.
		/// </summary>
		/// <param name="order">The order.</param>
		/// <param name="targetUnit">The unit.</param>
		/// <returns>A value indicating whether successfully issue the order.</returns>
		// Token: 0x060003F9 RID: 1017 RVA: 0x000052B8 File Offset: 0x000046B8
		[return: MarshalAs(UnmanagedType.U1)]
		public bool IssueOrder(GameObjectOrder order, AttackableUnit targetUnit)
		{
			return this.IssueOrder(order, targetUnit, true);
		}

		// Token: 0x04000379 RID: 889
		internal static AIBaseClient.OnAggroNativeDelegate m_AggroNativeDelegate;

		// Token: 0x0400037A RID: 890
		internal static AIBaseClient.OnBuffAddNativeDelegate m_BuffAddNativeDelegate;

		// Token: 0x0400037B RID: 891
		internal static AIBaseClient.OnBuffRemoveNativeDelegate m_BuffRemoveNativeDelegate;

		// Token: 0x0400037C RID: 892
		internal static AIBaseClient.OnDoCastNativeDelegate m_DoCastNativeDelegate;

		// Token: 0x0400037D RID: 893
		internal static AIBaseClient.OnIssueOrderNativeDelegate m_IssueOrderNativeDelegate;

		// Token: 0x0400037E RID: 894
		internal static AIBaseClient.OnNewPathNativeDelegate m_NewPathNativeDelegate;

		// Token: 0x0400037F RID: 895
		internal static AIBaseClient.OnPlayAnimationNativeDelegate m_PlayAnimationNativeDelegate;

		// Token: 0x04000380 RID: 896
		internal static AIBaseClient.OnProcessSpellCastNativeDelegate m_ProcessSpellCastNativeDelegate;

		// Token: 0x04000381 RID: 897
		internal static AIBaseClient.OnVisibleEnterNativeDelegate m_VisibleEnterNativeDelegate;

		// Token: 0x04000382 RID: 898
		internal static AIBaseClient.OnVisibleLeaveNativeDelegate m_VisibleLeaveNativeDelegate;

		// Token: 0x04000383 RID: 899
		internal static IntPtr m_AggroNative = IntPtr.Zero;

		// Token: 0x04000384 RID: 900
		internal static IntPtr m_BuffAddNative = IntPtr.Zero;

		// Token: 0x04000385 RID: 901
		internal static IntPtr m_BuffRemoveNative = IntPtr.Zero;

		// Token: 0x04000386 RID: 902
		internal static IntPtr m_DoCastNative = IntPtr.Zero;

		// Token: 0x04000387 RID: 903
		internal static IntPtr m_IssueOrderNative = IntPtr.Zero;

		// Token: 0x04000388 RID: 904
		internal static IntPtr m_NewPathNative = IntPtr.Zero;

		// Token: 0x04000389 RID: 905
		internal static IntPtr m_PlayAnimationNative = IntPtr.Zero;

		// Token: 0x0400038A RID: 906
		internal static IntPtr m_ProcessSpellCastNative = IntPtr.Zero;

		// Token: 0x0400038B RID: 907
		internal static IntPtr m_VisibleEnterNative = IntPtr.Zero;

		// Token: 0x0400038C RID: 908
		internal static IntPtr m_VisibleLeaveNative = IntPtr.Zero;

		// Token: 0x0400038D RID: 909
		internal static List<AIBaseClientAggro> AggroHandlers = new List<AIBaseClientAggro>();

		// Token: 0x0400038E RID: 910
		internal static List<AIBaseClientBuffAdd> BuffAddHandlers = new List<AIBaseClientBuffAdd>();

		// Token: 0x0400038F RID: 911
		internal static List<AIBaseClientBuffRemove> BuffRemoveHandlers = new List<AIBaseClientBuffRemove>();

		// Token: 0x04000390 RID: 912
		internal static List<AIBaseClientDoCast> DoCastHandlers = new List<AIBaseClientDoCast>();

		// Token: 0x04000391 RID: 913
		internal static List<AIBaseClientIssueOrder> IssueOrderHandlers = new List<AIBaseClientIssueOrder>();

		// Token: 0x04000392 RID: 914
		internal static List<AIBaseClientNewPath> NewPathHandlers = new List<AIBaseClientNewPath>();

		// Token: 0x04000393 RID: 915
		internal static List<AIBaseClientPlayAnimation> PlayAnimationHandlers = new List<AIBaseClientPlayAnimation>();

		// Token: 0x04000394 RID: 916
		internal static List<AIBaseClientProcessSpellCast> ProcessSpellCastHandlers = new List<AIBaseClientProcessSpellCast>();

		// Token: 0x04000395 RID: 917
		internal static List<AIBaseClientVisibleEnter> VisibleEnterHandlers = new List<AIBaseClientVisibleEnter>();

		// Token: 0x04000396 RID: 918
		internal static List<AIBaseClientVisibleLeave> VisibleLeaveHandlers = new List<AIBaseClientVisibleLeave>();

		// Token: 0x0200005E RID: 94
		// (Invoke) Token: 0x060003FB RID: 1019
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnAggroNativeDelegate(AIBaseClient* aiBaseClient, uint targetNetworkId);

		// Token: 0x0200005F RID: 95
		// (Invoke) Token: 0x060003FF RID: 1023
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnBuffAddNativeDelegate(AIBaseClient* aiBaseClient, BuffInstanceClient* buff);

		// Token: 0x02000060 RID: 96
		// (Invoke) Token: 0x06000403 RID: 1027
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnBuffRemoveNativeDelegate(AIBaseClient* aiBaseClient, BuffInstanceClient* buff);

		// Token: 0x02000061 RID: 97
		// (Invoke) Token: 0x06000407 RID: 1031
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnDoCastNativeDelegate(AIBaseClient* aiBaseClient, SpellCastInfo* castInfo);

		// Token: 0x02000062 RID: 98
		// (Invoke) Token: 0x0600040B RID: 1035
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnIssueOrderNativeDelegate(AIBaseClient* aiBaseClient, IssuedOrder order, Vector3f* position, AttackableUnit* target, [MarshalAs(UnmanagedType.U1)] bool isAttackMove, [MarshalAs(UnmanagedType.U1)] bool isPetCommand, bool* process);

		// Token: 0x02000063 RID: 99
		// (Invoke) Token: 0x0600040F RID: 1039
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnNewPathNativeDelegate(AIBaseClient* aiBaseClient, StlArray<EnsoulSharp::Native::Vector3f>* path, [MarshalAs(UnmanagedType.U1)] bool isDash, float speed);

		// Token: 0x02000064 RID: 100
		// (Invoke) Token: 0x06000413 RID: 1043
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnPlayAnimationNativeDelegate(AIBaseClient* aiBaseClient, sbyte* animaton, bool* process);

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x06000417 RID: 1047
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnProcessSpellCastNativeDelegate(AIBaseClient* aiBaseClient, SpellCastInfo* castInfo);

		// Token: 0x02000066 RID: 102
		// (Invoke) Token: 0x0600041B RID: 1051
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnVisibleEnterNativeDelegate(AIBaseClient* aiBaseClient);

		// Token: 0x02000067 RID: 103
		// (Invoke) Token: 0x0600041F RID: 1055
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnVisibleLeaveNativeDelegate(AIBaseClient* aiBaseClient);
	}
}
