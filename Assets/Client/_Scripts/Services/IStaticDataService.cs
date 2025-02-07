public interface IStaticDataService
{
    DifficultyStaticData CurrentDifficulty { get; }

    void SetDifficulty(int difficultyLevel);
}