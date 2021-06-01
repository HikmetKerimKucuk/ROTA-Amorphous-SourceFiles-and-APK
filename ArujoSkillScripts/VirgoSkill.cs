using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirgoSkill : MonoBehaviour
{
	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;

	[Space(30f)]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	public bool VirgoDrawPermission;
	public bool VirgoDrawTimer;
	bool firstTime;

	VirgoPf currentLine;
	VirgoPf vpf;

	Camera cam;
	BasicMovements bm; 
	PlayerEntity mt;

	void Start()
	{
		cam = Camera.main;
		firstTime = true;
		cantDrawOverLayerIndex = LayerMask.NameToLayer("zxvc");
		bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
		mt = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
		//vpf = GameObject.FindGameObjectWithTag("Virgo").GetComponent<VirgoPf>();
	}
	//jfyt
	void Update()
	{
		
        if (bm.Android_or_Windows == 0) //Android 
		{
			if (VirgoDrawPermission == true)
			{
				if (Input.touchCount > 0)
				{

					Debug.Log("TC>0");
					Touch touch = Input.GetTouch(0);

					if (touch.phase == TouchPhase.Began)
					{
						if (firstTime)
						{
							FindObjectOfType<AudioManager>().Play("virgoDraw");
							firstTime = false;
						}
						Debug.Log("TC BEGAN");
						BeginDraw();
					}

					if (touch.phase == TouchPhase.Moved)
					{
						Debug.Log("TC MOVED");
						Draw();
					}

					if (touch.phase == TouchPhase.Ended)
					{
						FindObjectOfType<AudioManager>().Stop("virgoDraw");
						firstTime = true;
						Debug.Log("TC BEGAN");
						EndDraw();
						VirgoDrawPermission = false;
					}

				}
			}
        }

        /*else if (bm.Android_or_Windows == 1) // Windows 
        {
            if (VirgoDrawPermission == true)
            {

				if (Input.GetMouseButtonDown(1))
					BeginDraw();

				if (Input.GetMouseButton(1))
				{
					Draw();
				}

				if (Input.GetMouseButtonUp(1))
                {
					EndDraw();
					VirgoDrawPermission = false;
				}
					

			}
		}*/
	}

	public void UseVirgoSkill()
    {
		if (mt.playerMana >= 100)
        {
            if (VirgoDrawTimer == false)
            {
				VirgoDrawTimer = true;
				//VirgoDrawPermission = perm;
				mt.playerMana = mt.playerMana - 100;
				Invoke("SkillTimer", 5.5f);
				Invoke("DrawDelayer",0.1f);
			}
			
		}
	}
	public void DrawDelayer()
    {
		VirgoDrawPermission = true;

	}

	public void SkillTimer()
    {
		VirgoDrawTimer = false;
    }








	// Begin Draw ----------------------------------------------
	void BeginDraw()
	{
		currentLine = Instantiate(linePrefab, this.transform).GetComponent<VirgoPf>();
		//vpf = GameObject.FindGameObjectWithTag("Virgo").GetComponent<VirgoPf>();


		//Set line properties
		currentLine.UsePhysics(false);
		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);
		vpf = GameObject.FindGameObjectWithTag("Virgo").GetComponent<VirgoPf>();
		if (true)
		{

		}

	}
	// Draw ----------------------------------------------------
	void Draw()
    {
        if (bm.Android_or_Windows == 0)
        {
			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
			//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
			RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 0.1f, cantDrawOverLayer);

			if (hit)
				EndDraw();
			else
				currentLine.AddPoint(mousePosition);
		}

        else if (bm.Android_or_Windows == 1)
        {
			//RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
			//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
			RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 0.1f, cantDrawOverLayer);

			if (hit)
				EndDraw();
			else
				currentLine.AddPoint(mousePosition);
		}
		
	}
	// End Draw ------------------------------------------------
	void EndDraw()
	{
		if (currentLine != null)
		{
			/*if (currentLine.pointsCount < 2)
			{
				//If line has one point
				Destroy(currentLine.gameObject);
			}*/
			//else
			//{
			//Add the line to "CantDrawOver" layer
			//currentLine.gameObject.layer = cantDrawOverLayerIndex;

			//Activate Physics on the line
			currentLine.UsePhysics(true);

			currentLine = null;
			vpf.destroyVirgo();
			//Destroy(currentLine, 5f);
			//}
		}
	}

	
}///////
