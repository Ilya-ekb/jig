using UnityEngine;

public class Config : PlayerPrefs
{
    public static void Init () {
        // TODO ???
        foreach (string name in StaticData.PPNames)
        {
            LoadData (name);
        }
    }

    //���������� ���� � ��� ��������� (��� ���� ����� ���� ������� ��������� ��������� ����� ����������)
    public static void SaveData(string prefName, object save) 
    {
        if (save is int)
        {
            SetInt(prefName, (int)save);
        }
        else if (save is string)
        {
            SetString(prefName, (string)save);
        }
        else if (save is float)
        {
            SetFloat(prefName, (float)save);
        }
        else
        {
            Debug.LogWarning ("������������ ��� ������ ��� ����������! ���������: Int, String, Float");
        }
    }

    public static object LoadData(string prefName)
    {   
        if (!HasKey(prefName))
        {
            Debug.Log("No Key Found");
            return null;
        }
        return GetString(prefName);
    }
}
