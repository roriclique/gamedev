using UnityEngine;
using UnityEngine.UI;

public class UIScoreTextCount : BallEvents
{
    [SerializeField] private ScoresCollector collector;
    [SerializeField] private Text scoreText;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {
            scoreText.text = collector.Scores.ToString();
        }
    }
}