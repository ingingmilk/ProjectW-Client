using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public PlayerController Player { get; private set; }

    public HashSet<MonsterController> Monsters { get; } = new();
    public HashSet<ProjectileController> Projectiles { get; } = new();


    public ObjectManager()
    {

    }

    public T Spawn<T>(NpcDataModel npcData, bool isPooling = false) where T : BaseController
    {
        var spawnObject = Managers.Resource.Instantiate(npcData.PrefabStringKey, pooling: isPooling);
        if(spawnObject == null)
        {
            return null;
        }

        MonsterController mc = spawnObject.GetOrAddComponent<MonsterController>();
        if(mc.SetGameData(npcData) == true)
        {
            Monsters.Add(mc);
            return mc as T;
        }

        return mc as T;
    }

    public T SpawnOld<T>(int templateID = 0) where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            var go = Managers.Resource.Instantiate("Slime_01.prefab", pooling: true);
            go.name = "Player";

            PlayerController pc = go.GetOrAddComponent<PlayerController>();
            Player = pc;

            return pc as T;
        }
        else if (type == typeof(MonsterController))
        {
            string name = (templateID == 0 ? "Goblin_01" : "Snake_01");
            GameObject go = Managers.Resource.Instantiate(name + ".prefab", pooling: true);

            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);

            return mc as T;
        }

        return null;
    }

    public void Despawn(BaseController obj)
    {
        //System.Type type = typeof(T);

        //if (type == typeof(PlayerController))
        //{
        //    // ?
        //}
        //else if (type == typeof(MonsterController))
        //{
        //    Monsters.Remove(obj as MonsterController);
        //    Managers.Resource.Destroy(obj.gameObject);
        //}
        //else if (type == typeof(ProjectileController))
        //{
        //    Projectiles.Remove(obj as ProjectileController);
        //    Managers.Resource.Destroy(obj.gameObject);
        //}
    }
}
