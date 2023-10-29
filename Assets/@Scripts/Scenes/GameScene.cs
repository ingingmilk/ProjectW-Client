using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameScene : MonoBehaviour
{

    SpawningPool _spawningPool;

    void Start()
    {
        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                Managers.Resource.LoadAllAsync<TextAsset>("GameData", (key3, count3, totalCount3) =>
                {
                    if (count3 == totalCount3)
                    {
                        StartLoaded();
                    }
                });
            }
        });
    }

    void Update()
    {

    }

    void StartLoaded()
    {
        _spawningPool = new SpawningPool();

        Managers.Data.Init();

        var player = Managers.Resource.Instantiate("Pc_Wiyina.prefab");
        player.AddComponent<PlayerController>();

        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";
        //joystick.SetActive(false);
        //joystick.GetComponent<UI_Joystick>().UiPrefab = joystick;

        var map = Managers.Resource.Instantiate("Map.prefab");
        map.name = "@Map";

        Camera.main.GetComponent<CameraController>().Target = player;
    }
}
