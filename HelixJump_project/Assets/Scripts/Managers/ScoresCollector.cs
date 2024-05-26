using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LvlProgress lvlProgress;
    [SerializeField] private int maxScores;
    private int scores;

    public int Scores => scores;
    public int MaxScores => maxScores;

    protected override void Awake()
    {
        base.Awake();

        scores = PlayerPrefs.GetInt("Score", maxScores);
        maxScores = scores;
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            scores += lvlProgress.CurrentLevel * 2;
        }

        if (type == SegmentType.Finish)
        {
            if (scores > maxScores)
            {
                PlayerPrefs.SetInt("Score", scores);
                maxScores = scores;
            }
        }
    }
}
