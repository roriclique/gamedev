using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LvlGenerator lvlGenerator;
    [SerializeField] private BallController ballController;
    [SerializeField] private LvlProgress lvlProgress;


    private void Start()
    {
        lvlGenerator.Generate(lvlProgress.CurrentLevel);

        ballController.transform.position = new Vector3(ballController.transform.position.x, lvlGenerator._lastFloorY, ballController.transform.position.z);
    }
}
