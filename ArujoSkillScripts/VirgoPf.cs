using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirgoPf : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rigidBody;

	[HideInInspector] public List<Vector2> points = new List<Vector2>();
	[HideInInspector] public int pointsCount = 0;

	//The minimum distance between line's points.
	public float pointsMinDistance = 0.1f;
	public float pointsMaxDistance = 5f;

	//Circle collider added to each line's point
	float circleColliderRadius;
	void Start()
	{
		rigidBody.bodyType = RigidbodyType2D.Static;
	}

	public void AddPoint(Vector2 newPoint)
	{
		//If distance between last point and new point is less than pointsMinDistance do nothing (return)
		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
			return;

		else if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) > pointsMaxDistance)
		{
			return;
		}
		if (pointsCount <= 100)
		{
			points.Add(newPoint);
			pointsCount++;

			//Add Circle Collider to the Point
			CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
			circleCollider.offset = newPoint;
			circleCollider.radius = circleColliderRadius;

			//Line Renderer
			lineRenderer.positionCount = pointsCount;
			lineRenderer.SetPosition(pointsCount - 1, newPoint);

			//Edge Collider
			//Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
			if (pointsCount > 1)
				edgeCollider.points = points.ToArray();
		}
		/*points.Add(newPoint);
		pointsCount++;*/


	}

	public Vector2 GetLastPoint()
	{
		return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
	}

	public void UsePhysics(bool usePhysics)
	{
		// isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
		rigidBody.isKinematic = !usePhysics;
		//rigidBody.isKinematic = false;
	}

	public void SetLineColor(Gradient colorGradient)
	{
		lineRenderer.colorGradient = colorGradient;
	}

	public void SetPointsMinDistance(float distance)
	{
		pointsMinDistance = distance;
	}

	public void SetLineWidth(float width)
	{

		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 2f;

		edgeCollider.edgeRadius = circleColliderRadius;
	}

	public void destroyVirgo()
	{
		Destroy(gameObject, 5f);
		Debug.Log("dstry");
	}


}////////
