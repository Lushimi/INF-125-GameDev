using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveLoad
{
    public static bool Save(PlayerControl player)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save");
        }

        string path = Application.persistentDataPath + "/save/" + "currSave.xml";

        FileStream file = new FileStream(path, FileMode.Create);

        SaveData saveData = new SaveData();

        saveData.dodge = player.loadout.DodgeList.IndexOf(player.dodgeMove);
        saveData.meleeAttack = player.loadout.MeleeList.IndexOf(player.meleeAttack);
        saveData.rangedAttack = player.loadout.RangedList.IndexOf(player.rangedAttack);
        saveData.specialAttack = player.loadout.SpecialList.IndexOf(player.specialAttack);
        saveData.parry = player.loadout.ParryList.IndexOf(player.parryMove);
        saveData.bossesDefeated = player.bossesDefeated.ToArray();

        //serialize to xml
        DataContractSerializer ser = new DataContractSerializer(typeof(SaveData));
        ser.WriteObject(file, saveData);
        file.Close();

        Debug.LogFormat("Saved file at {0}", path);

        return true;
    }

    public static SaveData Load()
    {
       
        string path = Application.persistentDataPath + "/save/" + "currSave.xml";

        if (!File.Exists(path))
        {
            return null;
        }

        FileStream file = new FileStream(path, FileMode.Open);

        try
        {
            //XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(file, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(SaveData));
            SaveData save = (SaveData)ser.ReadObject(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }
}
