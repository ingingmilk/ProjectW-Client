using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    // ������ �ֱ��? 
    // ���� �ִ� ������?
    // ����?
    float _spawnInterval = 0.1f;
    int _maxMonsterCount = 100;
    Coroutine _coUpdateSpawningPool;

    void Start()
    {
        _coUpdateSpawningPool = StartCoroutine(CoUpdateSpawningPool());
    }

    IEnumerator CoUpdateSpawningPool()
    {
        while (true)
        {
            TrySpawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    void TrySpawn()
    {
        int monsterCount = Managers.Object.Monsters.Count;
        if (monsterCount >= _maxMonsterCount)
            return;

        var templateID = 1; // TODO : �������� �޾ƿ� ����Ÿ
        var stageData = Managers.Data.GetByTemplateId<StageDataModel>(templateID);

        foreach(var spawnId in stageData.SpawnIdList)
        {
            var spawnMonsterData = Managers.Data.GetByTemplateId<NpcSpawnModel>(spawnId);
            foreach (var spawnNpcId in spawnMonsterData.SpawnNpcIdList)
            {
                var npcData = Managers.Data.GetByTemplateId<NpcDataModel>(spawnNpcId);
                
                var mc = Managers.Object.Spawn<MonsterController>(npcData);
                mc.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            }
        }
    }
}
