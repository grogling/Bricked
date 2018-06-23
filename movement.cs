using UnityEngine;
using System.Collections;
using DG.Tweening;

public class movement : MonoBehaviour {

    private float unitspeed = 5f;
	private Vector3 unitposition= new Vector3(0,0,0);
	private bool canMove = true , moving=false;
	private float unitfreq =0f;

	public bool IsUnit1;
	public bool IsUnit2;
	public bool IsUnit3;
	public bool IsUnit4;
	public float turntime=2f;

	public GameObject[] Units = new GameObject[4];

	// Update is called once per frame
	void Update ()
    {
	unitfreq += Time.deltaTime;

	if (IsUnit1 == true) 
	{
		if (unitfreq >0 && unitfreq < turntime)
		{

			MoveExecution ();			
		}
	}
	if (IsUnit2 == true) 
	{
		if (unitfreq > turntime && unitfreq < 2*turntime)
		{
			MoveExecution ();

		}
	}
	if (IsUnit3 == true) 
	{
		if (unitfreq >2*turntime && unitfreq <3*turntime)
		{
			MoveExecution ();
				
		}
	}
	if (IsUnit4 == true) 
	{
		if (unitfreq >3*turntime && unitfreq <4*turntime)
		{
			MoveExecution ();
				
		}
	}
	if (unitfreq >4*turntime)
	{
		unitfreq =0;
	}

	}
		 //transform.position= Vector3.MoveTowards(transform.position,unitposition,Time.deltaTime*unitspeed);
        //playerposition = new Vector3(0f, Mathf.Clamp(ypos, -7, 9), 0);
        //gameObject.transform.position = playerposition;

	private void Movefun() 
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		{ 
			canMove = false;
			moving = true;
			unitposition += Vector3.up;
		} else if (Input.GetKey (KeyCode.DownArrow)) 
		{ 		 
			canMove = false;
			moving = true;
			unitposition += Vector3.down;
		} else if (Input.GetKey (KeyCode.RightArrow)) 
		{ 		 
			canMove = false;
			moving = true;
			unitposition += Vector3.right;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
		 
			canMove = false;
			moving = true;
			unitposition+=Vector3.left;
		}

	}
	private void MoveExecution()
	{


		if (canMove) 
		{
			unitposition = transform.position;
			Movefun ();
			
		}
		if (moving) 
		{
			if (transform.position==unitposition)
			{
				moving=false;
				canMove= true;			
				Movefun ();
			}
			transform.position = Vector3.MoveTowards (transform.position, unitposition, Time.deltaTime*unitspeed);
		}
	}
}
