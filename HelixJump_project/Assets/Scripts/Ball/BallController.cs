using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement movement;

    [HideInInspector] public UnityEvent<SegmentType> CollisionSegment;

    private void Start()
    {
       movement = GetComponent<BallMovement>();
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        
        Segment segment = other.GetComponent<Segment>();

        if (segment != null)
        {
            if(segment.Type == SegmentType.Empty)
            {
                movement.Fall(other.transform.position.y);
            }

            if(segment.Type == SegmentType.Default)
            {
                movement.Jump();
            }
                
            if(segment.Type == SegmentType.Trap || segment.Type == SegmentType.Finish)
            {
                movement.Stop();
            }

            CollisionSegment.Invoke(segment.Type);
        }

    }
}
