using System.IO;
using System.Text;
using UnityEngine;

public class FilePlayerStorage : IPlayerStorage
{
    readonly string path;

    public FilePlayerStorage(string filename = "player.json")
    {
        path = Path.Combine(Application.persistentDataPath, filename);
    }

    public void Save(Player player)
    {
        File.WriteAllText(path, player.ToJson());
    }

    public Player Load()
    {
        if (!File.Exists(path))
            return new Player();

        string json = Encoding.UTF8.GetString(File.ReadAllBytes(path));
        return Player.FromJson(json);
    }
}