using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{   
    public GameObject trajectoryPrefab;
    private List<List<GameObject>> renderedTrajectory = new List<List<GameObject>>();
    // Update is called once per frame
    public void newLaunch() {
        renderedTrajectory.Add(new List<GameObject>());
    }
    public void addTrajectoryPoint(Vector2 point)
    {
        GameObject newPoint = Instantiate(trajectoryPrefab, transform);
        newPoint.transform.localPosition = new Vector3((float)point.x, (float)point.y + 0.25f, 0);
        newPoint.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        renderedTrajectory[renderedTrajectory.Count - 1].Add(newPoint); 
    }
    public void fadeTrajectories()
    {
        for (int i = 0; i < renderedTrajectory.Count; i++)
        {
            foreach (GameObject point in renderedTrajectory[i])
            {
                Color color = point.GetComponent<SpriteRenderer>().color;
                Debug.Log("i: " + i + " count: " + renderedTrajectory.Count);
                color.a = ((float)(i+1))/(renderedTrajectory.Count+1);
                Debug.Log("i: " + i + " Color: " + color.a);
                point.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
