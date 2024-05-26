using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlProgress : BallEvents
{
    [SerializeField] private SceneHelper sceneHelper;
    [SerializeField] private ScoresCollector collector;

    private int currentLevel = 1;

    public int CurrentLevel => currentLevel;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish)
        {
            currentLevel++;
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("LevelProgress : CurrentLevel", currentLevel);
    }

    public void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgress : CurrentLevel", 1);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLvl()
    {
        sceneHelper.RestartLevel();
    }
}

