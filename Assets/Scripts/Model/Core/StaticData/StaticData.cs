/// <summary>
/// ��� ��������� (����)
/// ����� ��������� ����������
/// ����� PlayerPrefs
/// ����� enum
/// �������� ����
/// </summary>
public static class StaticData
{
    #region PlayerPrefs
    public static readonly string[] PPNames = { "Coins" }; // ???
    #endregion

    #region Animator States
    #endregion

    #region Main Settings
    public const float CameraX = 5.0f;
    public const float CameraY = 2.0f;
    public const float CameraZ = 0.0f;

    public const float CameraPosSnappiness = 0.125f;
    #endregion

    #region Scene Names
    #endregion

    //Example
    #region Your Script Name
    /// <summary>
    /// �������� ������������� ����������
    /// </summary>
    public const int a = 4;
    public const string msg = "Hello, world";
    #endregion
}