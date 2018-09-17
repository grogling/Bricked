using UnityEngine;
using System.Collections;
using DG.Tweening;

public class movement : MonoBehaviour {

    private float unitspeed = 6f;
	private Vector3 unitposition= new Vector3(0,0,0);
	private bool canMove = true , moving=false;
    public GameObject AU;
   

    void Update ()
    {
        AU = GameManager.Instance.ActiveUnit;

        if (AU == gameObject)
        {
            MoveExecution();
        }


    }
		
    

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
	public void MoveExecution()
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
