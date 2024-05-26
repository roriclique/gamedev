using UnityEngine;
using UnityEngine.UI;

public class UILvlProgress : BallEvents
{
    [SerializeField] private LvlProgress lvlProgress;
    [SerializeField] private LvlGenerator lvlGenerator;

    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;

    [SerializeField] private Image progressBar;

    private float fillAmountStep;

    private void Start()
    {
        currentLevelText.text = lvlProgress.CurrentLevel.ToString();
        nextLevelText.text = (lvlProgress.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;
    }
    private void Update()
    {
        fillAmountStep = 1 / lvlGenerator.FloorAmount;
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty || type == SegmentType.Finish)
        {
            progressBar.fillAmount += fillAmountStep;
        }
    }
}
