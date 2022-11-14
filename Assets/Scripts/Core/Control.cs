using UnityEngine;
public static class Control
{
    public static void Start () {
        initializeCamera ();
    }

    private static void initializeCamera () {
        var cameraFollower = Model.MyPlayer.GetCameraFollower ();
        cameraFollower.Initialize ();
    }
}