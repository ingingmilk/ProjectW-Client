using System;
using System.Collections.Generic;

[Serializable]
public class NpcSpawnModel : BaseGameData<long>
{
    public int SpawnId;
    public List<int> SpawnNpcIdList;
}

