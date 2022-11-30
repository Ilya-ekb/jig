/// <summary>
/// Все настройки (поля)
/// Имена состояний аниматоров
/// Имена PlayerPrefs
/// Общие enum
/// Название сцен
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
    /// Описание использования переменной
    /// </summary>
    public const int a = 4;
    public const string msg = "Hello, world";
    #endregion
}