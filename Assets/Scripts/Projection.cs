/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene phisicsScene;
    [SerializeField] private Transform[] obstacleParent;

    private void Start()
    {
        CreatePhisicsScene();
    }

    void CreatePhisicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        phisicsScene = simulationScene.GetPhysicsScene();

        foreach (Transform obj in obstacleParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        }
    }

    [SerializeField] private LineRenderer line;
    [SerializeField] private int maxPhisicsFrameIterations;

    public void SimulateTrajectory(PlayerController ballPrefab, Vector3 pos, Vector3 velocity)
    {
        var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, simulationScene);

        ghostObj.Init(velocity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
*/