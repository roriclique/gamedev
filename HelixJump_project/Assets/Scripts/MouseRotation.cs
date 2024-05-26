using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private string mouseInputAxis;
    [SerializeField] private float sensitive;

    void Update()
    {
        if(Input.GetMouseButton(0) == true)
        {
            transform.Rotate(0, Input.GetAxis(mouseInputAxis) * -sensitive, 0);
        }
    }
}
