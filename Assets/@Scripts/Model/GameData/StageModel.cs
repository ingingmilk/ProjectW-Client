using System;
using System.Collections.Generic;

[Serializable]
public class StageDataModel : BaseGameData<long>
{
    public int StageNo;
    public string StateName;
    public bool IsTutorial;
    public List<int> SpawnIdList;
}
