using System;
using System.Collections.Generic;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to object manager.
	/// </summary>
	// Token: 0x0200006A RID: 106
	public class ObjectManager
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x0000D878 File Offset: 0x0000CC78
		internal static Type NativeTypeToManagedType(ClassId nativeType)
		{
			switch (nativeType)
			{
			case (ClassId)1:
				return typeof(AIHeroClient);
			case (ClassId)2:
				return typeof(AIMarker);
			case (ClassId)3:
				return typeof(AIMinionClient);
			case (ClassId)4:
				return typeof(AITurretClient);
			case (ClassId)5:
				return typeof(AITurretCommon);
			case (ClassId)6:
				return typeof(AnimatedBuildingClient);
			case (ClassId)7:
				return typeof(Barracks);
			case (ClassId)8:
				return typeof(BarracksDampenerClient);
			case (ClassId)9:
				return typeof(BuildingClient);
			case (ClassId)10:
				return typeof(DrawFX);
			case (ClassId)11:
				return typeof(GameObject);
			case (ClassId)12:
				return typeof(GrassObject);
			case (ClassId)13:
				return typeof(HQClient);
			case (ClassId)14:
				return typeof(LevelPropAIClient);
			case (ClassId)15:
				return typeof(LevelPropGameObjectClient);
			case (ClassId)16:
				return typeof(LevelPropSpawnerPoint);
			case (ClassId)17:
				return typeof(MapPropClient);
			case (ClassId)18:
				return typeof(MissileClient);
			case (ClassId)19:
				return typeof(NeutralMinionCampClient);
			case (ClassId)20:
				return typeof(EffectEmitter);
			case (ClassId)21:
				return typeof(Obj_InfoPoint);
			case (ClassId)22:
				return typeof(Obj_Levelsizer);
			case (ClassId)23:
				return typeof(Obj_NavPoint);
			case (ClassId)24:
				return typeof(Obj_SpawnPoint);
			case (ClassId)25:
				return typeof(ObjectAttacher);
			case (ClassId)26:
				return typeof(Pawn);
			case (ClassId)27:
				return typeof(ShopClient);
			case (ClassId)28:
				return typeof(Turret);
			case (ClassId)29:
				return typeof(UnrevealedTarget);
			default:
				return null;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000DA48 File Offset: 0x0000CE48
		internal static ClassId ManagedTypeToNativeType(Type managedType)
		{
			if (managedType == typeof(AIHeroClient))
			{
				return (ClassId)1;
			}
			if (managedType == typeof(AIMarker))
			{
				return (ClassId)2;
			}
			if (managedType == typeof(AIMinionClient))
			{
				return (ClassId)3;
			}
			if (managedType == typeof(AITurretClient))
			{
				return (ClassId)4;
			}
			if (managedType == typeof(AITurretCommon))
			{
				return (ClassId)5;
			}
			if (managedType == typeof(AnimatedBuildingClient))
			{
				return (ClassId)6;
			}
			if (managedType == typeof(Barracks))
			{
				return (ClassId)7;
			}
			if (managedType == typeof(BarracksDampenerClient))
			{
				return (ClassId)8;
			}
			if (managedType == typeof(BuildingClient))
			{
				return (ClassId)9;
			}
			if (managedType == typeof(DrawFX))
			{
				return (ClassId)10;
			}
			if (managedType == typeof(GameObject))
			{
				return (ClassId)11;
			}
			if (managedType == typeof(GrassObject))
			{
				return (ClassId)12;
			}
			if (managedType == typeof(HQClient))
			{
				return (ClassId)13;
			}
			if (managedType == typeof(LevelPropAIClient))
			{
				return (ClassId)14;
			}
			if (managedType == typeof(LevelPropGameObjectClient))
			{
				return (ClassId)15;
			}
			if (managedType == typeof(LevelPropSpawnerPoint))
			{
				return (ClassId)16;
			}
			if (managedType == typeof(MapPropClient))
			{
				return (ClassId)17;
			}
			if (managedType == typeof(MissileClient))
			{
				return (ClassId)18;
			}
			if (managedType == typeof(NeutralMinionCampClient))
			{
				return (ClassId)19;
			}
			if (managedType == typeof(EffectEmitter))
			{
				return (ClassId)20;
			}
			if (managedType == typeof(Obj_InfoPoint))
			{
				return (ClassId)21;
			}
			if (managedType == typeof(Obj_Levelsizer))
			{
				return (ClassId)22;
			}
			if (managedType == typeof(Obj_NavPoint))
			{
				return (ClassId)23;
			}
			if (managedType == typeof(Obj_SpawnPoint))
			{
				return (ClassId)24;
			}
			if (managedType == typeof(ObjectAttacher))
			{
				return (ClassId)25;
			}
			if (managedType == typeof(Pawn))
			{
				return (ClassId)26;
			}
			if (managedType == typeof(ShopClient))
			{
				return (ClassId)27;
			}
			if (managedType == typeof(Turret))
			{
				return (ClassId)28;
			}
			return (managedType == typeof(UnrevealedTarget)) ? ((ClassId)29) : ((ClassId)0);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000DCB4 File Offset: 0x0000D0B4
		internal unsafe static GameObject CreateObjectFromPointer(GameObject* nativeObject)
		{
			if (nativeObject == null)
			{
				return null;
			}
			switch (<Module>.EnsoulSharp.Native.GameObject.GetType(nativeObject))
			{
			case (ClassId)1:
			{
				uint index = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AIHeroClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index);
			}
			case (ClassId)2:
			{
				uint index2 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AIMarker((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index2);
			}
			case (ClassId)3:
			{
				uint index3 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AIMinionClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index3);
			}
			case (ClassId)4:
			{
				uint index4 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AITurretClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index4);
			}
			case (ClassId)5:
			{
				uint index5 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AITurretCommon((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index5);
			}
			case (ClassId)6:
			{
				uint index6 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new AnimatedBuildingClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index6);
			}
			case (ClassId)7:
			{
				uint index7 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Barracks((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index7);
			}
			case (ClassId)8:
			{
				uint index8 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new BarracksDampenerClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index8);
			}
			case (ClassId)9:
			{
				uint index9 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new BuildingClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index9);
			}
			case (ClassId)10:
			{
				uint index10 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new DrawFX((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index10);
			}
			case (ClassId)11:
			{
				uint index11 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new GameObject((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index11);
			}
			case (ClassId)12:
			{
				uint index12 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new GrassObject((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index12);
			}
			case (ClassId)13:
			{
				uint index13 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new HQClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index13);
			}
			case (ClassId)14:
			{
				uint index14 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new LevelPropAIClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index14);
			}
			case (ClassId)15:
			{
				uint index15 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new LevelPropGameObjectClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index15);
			}
			case (ClassId)16:
			{
				uint index16 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new LevelPropSpawnerPoint((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index16);
			}
			case (ClassId)17:
			{
				uint index17 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new MapPropClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index17);
			}
			case (ClassId)18:
			{
				uint index18 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new MissileClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index18);
			}
			case (ClassId)19:
			{
				uint index19 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new NeutralMinionCampClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index19);
			}
			case (ClassId)20:
			{
				uint index20 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new EffectEmitter((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index20);
			}
			case (ClassId)21:
			{
				uint index21 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Obj_InfoPoint((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index21);
			}
			case (ClassId)22:
			{
				uint index22 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Obj_Levelsizer((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index22);
			}
			case (ClassId)23:
			{
				uint index23 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Obj_NavPoint((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index23);
			}
			case (ClassId)24:
			{
				uint index24 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Obj_SpawnPoint((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index24);
			}
			case (ClassId)25:
			{
				uint index25 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new ObjectAttacher((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index25);
			}
			case (ClassId)26:
			{
				uint index26 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Pawn((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index26);
			}
			case (ClassId)27:
			{
				uint index27 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new ShopClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index27);
			}
			case (ClassId)28:
			{
				uint index28 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new Turret((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index28);
			}
			case (ClassId)29:
			{
				uint index29 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new UnrevealedTarget((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index29);
			}
			default:
			{
				uint index30 = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(nativeObject));
				return new GameObject((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(nativeObject)), index30);
			}
			}
		}

		/// <summary>
		/// 	Gets the local player.
		/// </summary>
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000E014 File Offset: 0x0000D414
		public unsafe static AIHeroClient Player
		{
			get
			{
				if (ObjectManager.cachedPlayer == null)
				{
					AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
					if (ptr != null)
					{
						uint index = (uint)(*<Module>.EnsoulSharp.Native.GameObject.GetID(ptr));
						ObjectManager.cachedPlayer = new AIHeroClient((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr)), index);
					}
				}
				return ObjectManager.cachedPlayer;
			}
		}

		/// <summary>
		/// 	Gets the unit by specified index if valid, otherwise null.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The unit.</returns>
		// Token: 0x06000431 RID: 1073 RVA: 0x0000162C File Offset: 0x00000A2C
		public unsafe static ObjectType GetUnitByIndex<ObjectType>(int index) where ObjectType : GameObject
		{
			GameObject* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex((uint)index);
			if (ptr != null)
			{
				return (ObjectType)((object)ObjectManager.CreateObjectFromPointer(ptr));
			}
			return default(ObjectType);
		}

		/// <summary>
		/// 	Gets the unit by specified network id if valid, otherwise null.
		/// </summary>
		/// <param name="networkId">The network id.</param>
		/// <returns>The unit.</returns>
		// Token: 0x06000432 RID: 1074 RVA: 0x00001658 File Offset: 0x00000A58
		public unsafe static ObjectType GetUnitByNetworkId<ObjectType>(int networkId) where ObjectType : GameObject
		{
			GameObject* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId((uint)networkId);
			if (ptr != null)
			{
				return (ObjectType)((object)ObjectManager.CreateObjectFromPointer(ptr));
			}
			return default(ObjectType);
		}

		/// <summary>
		/// 	Gets all units can assign to specified object type.
		/// </summary>
		/// <returns>The units.</returns>
		// Token: 0x06000433 RID: 1075 RVA: 0x00004BA4 File Offset: 0x00003FA4
		public unsafe static IEnumerable<ObjectType> Get<ObjectType>() where ObjectType : GameObject
		{
			List<ObjectType> list = new List<ObjectType>();
			bool flag = typeof(ObjectType) == typeof(GameObject);
			ObjectManager* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetInstance();
			if (ptr != null)
			{
				StlVector<EnsoulSharp::Native::GameObjectContainer::GObjectEntry>* ptr2 = <Module>.EnsoulSharp.Native.GameObjectContainer.GetObjectArray(<Module>.EnsoulSharp.Native.ObjectManager.GetGameObjectContainer(ptr));
				GameObjectContainer.GObjectEntry* ptr3 = *(int*)ptr2;
				if (ptr3 != *(int*)(ptr2 + 4 / sizeof(StlVector<EnsoulSharp::Native::GameObjectContainer::GObjectEntry>)))
				{
					do
					{
						uint num = (uint)(*(int*)ptr3);
						if ((num & 1U) == 0U && num != 0U)
						{
							GameObject gameObject = ObjectManager.CreateObjectFromPointer(num);
							if (gameObject != null && (flag || typeof(ObjectType).IsAssignableFrom(ObjectManager.NativeTypeToManagedType((ClassId)<Module>.EnsoulSharp.Native.GameObject.GetType(*(int*)ptr3)))))
							{
								list.Add((ObjectType)((object)gameObject));
							}
						}
						ptr3 += 4 / sizeof(GameObjectContainer.GObjectEntry);
					}
					while (ptr3 != *(int*)(ptr2 + 4 / sizeof(StlVector<EnsoulSharp::Native::GameObjectContainer::GObjectEntry>)));
				}
			}
			return list;
		}

		// Token: 0x0400039A RID: 922
		private static AIHeroClient cachedPlayer = null;
	}
}
