using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public int levelID;
    public string levelName;
    public Sprite thumbnail;
    public TextAsset levelMapFile;
    public int requiredScore;
    public float timeLimit;
}
