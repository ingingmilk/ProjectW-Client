using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    public ObjectType ObjectType { get; protected set; }

    void Awake()
    {
        Init();
    }

    bool _init = false;
    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    public virtual bool SetGameData(IGameData gameData)
    {
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
