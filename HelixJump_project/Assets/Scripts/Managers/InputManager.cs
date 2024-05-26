using UnityEngine;

public class InputManager : BallEvents
{
    [SerializeField] private MouseRotation InputRotator;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type == SegmentType.Finish || type == SegmentType.Trap)
        {
            InputRotator.enabled = false;
        }
    }
}
