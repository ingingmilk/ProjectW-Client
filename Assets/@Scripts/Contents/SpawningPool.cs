using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    // 리스폰 주기는? 
    // 몬스터 최대 개수는?
    // 스톱?
    private StageDataModel _stageData;
    private Coroutine _coUpdateSpawningPool;

    void Start()
    {
    }

    public void StartSpawn(StageDataModel stageData)
    {
        _stageData = stageData;

        _coUpdateSpawningPool = StartCoroutine(CoUpdateSpawningPool());
    }

    public void StopSpawn()
    {

    }

    IEnumerator CoUpdateSpawningPool()
    {
        while (true)
        {
            TrySpawn();
            yield return new WaitForSeconds(_stageData.SpawnInterval / 1000);
        }
    }

    void TrySpawn()
    {
        int monsterCount = Managers.Object.Monsters.Count;
        if (monsterCount >= _stageData.MaxSpawnCount)
        {
            // 코루틴 스탑
            return;
        }
            

        foreach (var spawnId in _stageData.SpawnIdList)
        {
            var spawnMonsterData = Managers.Data.GetByTemplateId<NpcSpawnModel>(spawnId);
            
            foreach (var spawnNpcId in spawnMonsterData.SpawnNpcIdList)
            {
                var npcData = Managers.Data.GetByTemplateId<NpcDataModel>(spawnNpcId);
                if(npcData == null)
                {
                    continue;
                }
                
                var mc = Managers.Object.Spawn<MonsterController>(npcData);
                mc.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            }
        }
    }
}
