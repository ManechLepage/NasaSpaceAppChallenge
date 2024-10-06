using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{   
    public GameObject trajectoryPrefab;
    private List<GameObject> renderedTrajectory = new List<GameObject>();
    // Update is called once per frame
    public void addTrajectoryPoint(Vector2 point)
    {
        GameObject newPoint = Instantiate(trajectoryPrefab, transform);
        newPoint.transform.localPosition = new Vector3((float)point.x, (float)point.y + 0.25f, 0);
        newPoint.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        renderedTrajectory.Add(newPoint); 
    }
    public void deleteTrajectory()
    {
        for (int i = 0; i < renderedTrajectory.Count; i++)
        {
            foreach (GameObject point in renderedTrajectory[i])
            {
                Color color = point.GetComponent<SpriteRenderer>().color;
                color.a = ((float)(i+1))/(1.25f*(renderedTrajectory.Count+1));
                point.GetComponent<SpriteRenderer>().color = color;
            }
        }
        renderedTrajectory.Clear();
    }
}
