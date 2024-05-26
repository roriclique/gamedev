using UnityEngine;

public class UIGamePanel : BallEvents
{
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject failedPanel;

    [SerializeField] private Animator passedAnimator;
    [SerializeField] private Animator failedAnimator;

    private void Start()
    {
        passedPanel.SetActive(false);
        failedPanel.SetActive(false);

    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Trap)
        {
            failedPanel.SetActive(true);
            failedAnimator.enabled = true;

        }

        if (type == SegmentType.Finish)
        {
            passedPanel.SetActive(true);
            passedAnimator.enabled = true;
        }
    }
}
