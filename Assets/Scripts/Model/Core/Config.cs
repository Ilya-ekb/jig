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

    //Сохранение даты и его оверлоуды (для того чтобы одна функция принимала несколько типов переменных)
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
            Debug.LogWarning ("Неправильный тип данных для сохранения! Доступные: Int, String, Float");
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
