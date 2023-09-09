using UnityEngine;

public class PlayerController : CreatureController
{
    private Vector2 _moveDir = Vector2.zero;
    private Animator _animator;

    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set { _moveDir = value.normalized; }
    }

    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        _speed = 5.0f;

        _animator = GetComponent<Animator>();

        return true;
    }

    void Start()
    {
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
    }

    void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
    }

    void Update()
    {
        //UpdateInput();
        //MovePlayer();
	}

    void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleOnMoveDirChanged(Vector2 dir)
    {
        _moveDir = dir;
    }

    void MovePlayer()
    {
        //_moveDir = Managers.Game.MoveDir;
        //Vector3 dir = _moveDir * _speed * Time.deltaTime;
        Vector3 dir = _moveDir * _speed * Time.fixedDeltaTime;
        transform.position += dir;

        GetComponent<SpriteRenderer>().flipX = dir.x < 0;
        _animator.SetFloat("Speed", _speed);
    }

    // Device Simulator¿¡¼­ ¸ÔÅë
    void UpdateInput()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            moveDir.y += 1;
		if (Input.GetKey(KeyCode.S))
			moveDir.y -= 1;
		if (Input.GetKey(KeyCode.A))
			moveDir.x -= 1;
		if (Input.GetKey(KeyCode.D))
			moveDir.x += 1;

        _moveDir = moveDir.normalized;
	}
}
