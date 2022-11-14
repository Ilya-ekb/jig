using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform Player;

    private CameraParams camera;

    void Start()
    {
        camera = new CameraParams ();
    }

    /// <summary>
    /// Вызывается при движении игрока для обновления позиции камеры
    /// </summary>
    /// <param name="playerPosition"></param>
    public void UpdatePosition (Vector3 playerPosition) {
        float x = 0;
        float y = 0;
        float z = 0;
        camera.GetCameraPosition (out x, out y, out z);

        var additionalVec = new Vector3 (x, y, z);
        var newPosition = playerPosition + additionalVec;

        cameraTransform.position = newPosition;
    }
}