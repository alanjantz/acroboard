using UnityEngine;

public static class AcroboardConfiguration
{
    private const int TRUE = 1;
    private const int FALSE = 0;
    private const string FILE_PATH = "FILE_PATH";
    private const string PLAYER_VELOCITY = "PLAYER_VELOCITY";
    private const string PLATFORM_VELOCITY = "PLATFORM_VELOCITY";
    private const string PLAYER_VIEW_MAX_DISTANCE = "PLAYER_VIEW_MAX_DISTANCE";
    private const string LEVELS_AMOUNT = "LEVELS_AMOUNT";
    private const string SPECTATOR = "SPECTATOR";

    public static string FilesPath
    {
        get
        {
            return GetStringValue(FILE_PATH, DefaultValues.FilePath);
        }
        set
        {
            PlayerPrefs.SetString(FILE_PATH, value);
        }
    }

    public static float PlayerVelocity
    {
        get
        {
            return GetFloatValue(PLAYER_VELOCITY, DefaultValues.PlayerVelocity);
        }
        set
        {
            PlayerPrefs.SetFloat(PLAYER_VELOCITY, value);
        }
    }

    public static float PlatformVelocity
    {
        get
        {
            return GetFloatValue(PLATFORM_VELOCITY, DefaultValues.PlatformVelocity);
        }
        set
        {
            PlayerPrefs.SetFloat(PLATFORM_VELOCITY, value);
        }
    }

    public static float PlayerViewMaxDistance
    {
        get
        {
            return GetFloatValue(PLAYER_VIEW_MAX_DISTANCE, DefaultValues.PlayerViewMaxDistance);
        }
        set
        {
            PlayerPrefs.SetFloat(PLAYER_VIEW_MAX_DISTANCE, value);
        }
    }

    public static int LevelsAmount
    {
        get
        {
            return GetIntValue(LEVELS_AMOUNT, DefaultValues.LevelsAmount);
        }
        set
        {
            PlayerPrefs.SetInt(LEVELS_AMOUNT, value);
        }
    }

    public static bool SpectatorMode
    {
        get
        {
            return PlayerPrefs.GetInt(SPECTATOR) == TRUE;
        }
        set
        {
            PlayerPrefs.SetInt(SPECTATOR, value ? TRUE : FALSE);
        }
    }

    public static void Reset()
    {
        PlayerPrefs.SetString(FILE_PATH, DefaultValues.FilePath);
        PlayerPrefs.SetFloat(PLAYER_VELOCITY, DefaultValues.PlayerVelocity);
        PlayerPrefs.SetFloat(PLATFORM_VELOCITY, DefaultValues.PlatformVelocity);
        PlayerPrefs.SetFloat(PLAYER_VIEW_MAX_DISTANCE, DefaultValues.PlayerViewMaxDistance);
        PlayerPrefs.SetInt(SPECTATOR, FALSE);
    }

    private static string GetStringValue(string key, string defaultValue)
    {
        var result = PlayerPrefs.GetString(key);

        if (string.IsNullOrWhiteSpace(result))
        {
            PlayerPrefs.SetString(key, defaultValue);
            result = defaultValue;
        }

        return result;
    }

    private static float GetFloatValue(string key, float defaultValue)
    {
        var result = PlayerPrefs.GetFloat(key);

        if (result == 0)
        {
            PlayerPrefs.SetFloat(key, defaultValue);
            result = defaultValue;
        }

        return result;
    }

    private static int GetIntValue(string key, int defaultValue)
    {
        var result = PlayerPrefs.GetInt(key);

        if (result == 0)
        {
            PlayerPrefs.SetInt(key, defaultValue);
            result = defaultValue;
        }

        return result;
    }

    private class DefaultValues
    {
        public static string FilePath => Application.persistentDataPath;
        public static float PlayerVelocity => 12f;
        public static float PlatformVelocity => 12f;
        public static float PlayerViewMaxDistance => 25f;
        public static int LevelsAmount => 8;
    }
}
