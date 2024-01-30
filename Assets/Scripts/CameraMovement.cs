using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraMoveSpeed;

    Transform PlayerTransform;
    Vector3 cameraPos = new Vector3(0, 0, -10);
    Vector3 mapPos;
    float cameraWidth, cameraHeight;
    Camera thisCam;
    Tilemap tilemap;
    BoundsInt bounds;
    [SerializeField] float minLimitX = 0;
    [SerializeField] float maxLimitX = 0;
    [SerializeField] float minLimitY = 0;
    [SerializeField] float maxLimitY = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameManager.Instance.PlayerTransform;
        thisCam = GetComponent<Camera>();

        cameraHeight = thisCam.orthographicSize;
        cameraWidth = cameraHeight * ((float)Screen.width / (float)Screen.height);
        //StartCoroutine(curMapWait_Coroutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTransform.position + cameraPos, cameraMoveSpeed);
        if (tilemap)
        {
            float lx = (bounds.size.x / 2) - cameraWidth;
            float ClampX = Mathf.Clamp(transform.position.x, mapPos.x + (bounds.center.x - lx) + minLimitX, mapPos.x + (bounds.center.x + lx) + maxLimitX);

            float ly = (bounds.size.y / 2) - cameraHeight;
            float ClampY = Mathf.Clamp(transform.position.y, mapPos.y + (bounds.center.y - ly) + minLimitY, mapPos.y + (bounds.center.y + ly) + maxLimitY);

            transform.position = new Vector3(ClampX, ClampY, cameraPos.z);
        }
    }

    public void LimitCameraArea()
    {
        switch (GameManager.Instance.eWaveType)
        {
            case WAVETYPE.NORMAL:
            case WAVETYPE.BOSS:
                tilemap = GameManager.Instance.curMap.transform.Find("Floor").GetComponent<Tilemap>();
                mapPos = GameManager.Instance.curMap.transform.position;
                break;
            case WAVETYPE.SHOP:
                tilemap = GameManager.Instance.shop.transform.Find("Floor").GetComponent<Tilemap>();
                mapPos = tilemap.transform.position;
                break;
            default:
                Debug.Log("CameraMovement : LimitCameraArea에 eWaveType을 찾을 수 없음.");
                break;
        }
        transform.position = mapPos;
        bounds = tilemap.cellBounds;
    }
    //test
    IEnumerator curMapWait_Coroutine()
    {
        yield return new WaitUntil(() => GameManager.Instance.curMap);
        LimitCameraArea();
    }
}
