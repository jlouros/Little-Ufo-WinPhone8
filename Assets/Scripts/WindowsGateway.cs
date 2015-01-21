using System;

public static class WindowsGateway
{

    static WindowsGateway()
    {
        UnityLoaded = delegate() { };

        ShareHighScore = delegate() { };
    }

    public static Action UnityLoaded;

    public static Action ShareHighScore;
}
