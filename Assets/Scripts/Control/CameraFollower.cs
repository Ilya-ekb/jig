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
        transform.position = MoveCamera ();
    }


    void Update()
    {
        transform.position = Vector3.Lerp (transform.position,
            MoveCamera (),
            StaticData.CameraPosSnappiness);

    }

    private Vector3 MoveCamera () {
        var movVec = cameraFollowObject.position + savedCameraOffset;
        var x = movVec.x;
        var y = movVec.y;

        return new Vector3 (x, y, StaticData.CameraZ);
    }
}
