public static class Model
{
    public static PlayerData MyPlayer;

    public static void Start () {
        initializePlayer ();
    }
    private static void LoadConfig () {

    }

    private static void initializePlayer () {
        MyPlayer = new PlayerData ();
    }
}