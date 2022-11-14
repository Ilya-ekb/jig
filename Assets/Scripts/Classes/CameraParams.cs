public class CameraParams
{
    private float x;
    private float y;
    private float z;

    public void GetCameraPosition (out float x, out float y, out float z) {
        x = Constants.CameraX;
        y = Constants.CameraY;
        z = Constants.CameraZ;
    }
}