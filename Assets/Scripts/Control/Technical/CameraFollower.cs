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
        transform.position = cameraFollowObject.position + savedCameraOffset;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, 
            cameraFollowObject.position + savedCameraOffset,
            StaticData.CameraPosSnappiness);
    }
}
