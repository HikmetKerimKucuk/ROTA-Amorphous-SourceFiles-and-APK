using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class saveNloadSystem
{
    public static void SavePlayer(levelsPanel game)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.rota";
        FileStream stream = new FileStream(path, FileMode.Create);

        gameData data = new gameData(game);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static gameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/gamedata.rota";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            gameData data = formatter.Deserialize(stream) as gameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save error aga şu yok bak:" + path);
            return null;
        }
    }

}///////////
