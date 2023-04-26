using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ballRb;
    public Rigidbody shootRigid;
    public GameObject hoop;

    [SerializeField] private Transform[] points;
    [SerializeField] private Lr_Controller line;

    private bool isPresed = false;

    private float maxDistance = 2f;
    private float minTorque = 0;
    private float maxTorque = 25;

    private int score = 0;
    private bool scoreAreaTouched = false;

    void Start()
    {
        Debug.Log(shootRigid.gameObject.transform.position);
        line.SetUpLine(points);
        ballRb = GetComponent<Rigidbody>();
        ballRb.isKinematic = true;
    }

    void Update()
    {
        Aim();
    }

    private void OnMouseDown()
    {
        isPresed = true;
        ballRb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPresed = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10.1f));
        if (Vector3.Distance(mousePos, shootRigid.position) > 0.5f)
        {
            ballRb.isKinematic = false;
            StartCoroutine(LetGo());
        }
        else
        {
            ballRb.position = shootRigid.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score Area"))
        {
            scoreAreaTouched = true;
        }

        if (other.CompareTag("Shot Failed Area"))
        {
            if (scoreAreaTouched)
            {
                UpdateScore();
                
            }

            scoreAreaTouched = false;
        }


    }

    private void UpdateScore()
    {
        score++;
        Debug.Log(score);
    }

    private void Aim()
    {
        if (isPresed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10.1f));
            if (Vector3.Distance(mousePos, shootRigid.position) > maxDistance)
            {
                ballRb.position = shootRigid.position + (mousePos - shootRigid.position).normalized * maxDistance;
            }
            else
            {
                ballRb.position = mousePos;
            }
        }
    }

    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpringJoint>().breakForce = 0;
        this.enabled = false;

        Vector3 torque = new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque));
        ballRb.AddTorque(torque);

        line.lr.enabled = false;
    }
}
