using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private const string StaticDataDifficultyPath = "StaticData/DifficultyLevel";

    public DifficultyStaticData CurrentDifficulty { get; private set; }

    private Dictionary<int, DifficultyStaticData> _difficulty = new Dictionary<int, DifficultyStaticData>();


    public StaticDataService()
    {
        _difficulty = Resources.LoadAll<DifficultyStaticData>(StaticDataDifficultyPath)
            .ToDictionary(x => x.Difficultylevel, x => x);

        SetDifficulty(difficultyLevel: 1);
    }

    public void SetDifficulty(int difficultyLevel)
    {
        if (_difficulty.TryGetValue(difficultyLevel, out DifficultyStaticData staticData))
            CurrentDifficulty = staticData;
    }
}

