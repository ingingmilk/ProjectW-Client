using System;
using System.Collections.Generic;

[Serializable]
public class NpcSpawnModel : BaseGameData<long>
{
    public int SpawnId;
    public int MaxSpawnCount;
    public int SpawnInterval;
    public List<int> SpawnNpcIdList;
}

