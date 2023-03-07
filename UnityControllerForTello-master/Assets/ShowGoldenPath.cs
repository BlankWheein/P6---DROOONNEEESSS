using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
// ShowGoldenPath
using UnityEngine;
using UnityEngine.AI;

public class ShowGoldenPath : MonoBehaviour
{
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    public LineRenderer lineRenderer;
    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            if (i == 0)
            {
                lineRenderer.SetPosition(0, path.corners[i]);
                lineRenderer.SetPosition(1, path.corners[i + 1]);
            }
        }
    }
}
