using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Static Data/Difficulty")]
public class DifficultyStaticData : ScriptableObject
{
    public int Difficultylevel;

    [Range(0f, 1000f)]
    public int bossHp;

    public AssetReferenceGameObject bossPrefab;

    [Range(0f, 100f)]
    public int noteDamage;

    [Range(0f, 100000f)] //1sec = 1000milsec
    [Header ("In milliseconds (1sec = 1000milsec)")]
    public float noteSpawnInterval;

    [Range(0f, 5f)]
    public float noteLifetime;

    [Range(0f, 1f)]
    public float spawnAcceleration;

}
