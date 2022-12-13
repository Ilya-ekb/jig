using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    /// <summary>
    /// ������ ���������� ������ (�����)
    /// </summary>
    [SerializeField] private Transform cameraFollowObject;

    private Vector3 savedCameraOffset;

    /*
     * ������������� ������ � ������ ����� � ������ ����
     * (��� �� ����� �������� ����� �� ���� ��� ��� ���� �� ����� �� ���� ��� ��� ������ ���� � ������ ����)
     * ��� ���������� ���������� ������
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
