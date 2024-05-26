using UnityEngine;

public enum SegmentType
{
    Default,
    Trap,
    Empty,
    Finish,
}

public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;
    [SerializeField] private Material trapMaterial;
    [SerializeField] private Material finishMaterial; 

    private MeshRenderer meshRenderer;
    public SegmentType Type => type;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetDefault()
    {
        meshRenderer.enabled = true;

        type = SegmentType.Default;
    }

    public void SetTrap()
    {
        meshRenderer.enabled = true;
        meshRenderer.material = trapMaterial;

        type = SegmentType.Trap;
    }

    public void SetEmpty()
    {
        meshRenderer.enabled = false;

        type = SegmentType.Empty;
    }

    public void SetFinish()
    {
        meshRenderer.enabled = true;
        meshRenderer.material = finishMaterial;

        type = SegmentType.Finish;
    }

}

