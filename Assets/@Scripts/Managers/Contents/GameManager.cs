using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player { get { return Managers.Object?.Player; } }
    
    private Vector2 _playerMoveDir;

    public event Action<Vector2> OnMoveDirChanged;

    public Vector2 PlayerMoveDir
    {
        get { return _playerMoveDir; }
        set
        {
            _playerMoveDir = value;
            OnMoveDirChanged?.Invoke(_playerMoveDir);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
