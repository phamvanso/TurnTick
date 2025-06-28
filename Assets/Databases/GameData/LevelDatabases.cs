using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDatabases", menuName = "Scriptable Objects/LevelDatabases")]
public class LevelDatabases : ScriptableObject
{
    public List<LevelData> levels;

    public LevelData GetLevelByID(int id)
    {
        return levels.Find(level => level.levelID == id);
    }
}
