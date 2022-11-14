using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    /// <summary>
    /// Объект следования камеры (Игрок)
    /// </summary>
    [SerializeField] private Transform cameraFollowObject;

    private Vector3 savedCameraOffset;

    /*
     * Устанавливает камеру в нужное место в начале игры
     * (она не будет медленно ехать от того где она была на сцене до того где она должна быть в начале игры)
     * еще запоминает константый оффсет
    */


    public void Init()
    {
        savedCameraOffset = new Vector3(StaticData.CameraX,
            StaticData.CameraY,
            StaticData.CameraZ);
        transform.position = cameraFollowObject.position + savedCameraOffset;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, 
            cameraFollowObject.position + savedCameraOffset,
            StaticData.CameraPosSnappiness);
    }
}
