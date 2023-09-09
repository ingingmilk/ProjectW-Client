using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameScene : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    void Start()
    {
        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                StartLoaded();

                Managers.Resource.LoadAllAsync<TextAsset>("Data", (key3, count3, totalCount3) =>
                {
                    if (count3 == totalCount3)
                    {
                        //StartLoaded();
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
        var player = Managers.Resource.Instantiate("Player.prefab");
        player.AddComponent<PlayerController>();

        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";
        //joystick.SetActive(false);
        //joystick.GetComponent<UI_Joystick>().UiPrefab = joystick;

        var map = Managers.Resource.Instantiate("Map.prefab");
        map.name = "@Map";

        Camera.main.GetComponent<CameraController>().Target = player;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}
