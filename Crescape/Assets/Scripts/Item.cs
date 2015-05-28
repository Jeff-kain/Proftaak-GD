using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public bool Elastic;
	public bool Floating; 
	public bool JumpPower; 
	public bool IsPlatform;
	public bool Proportions;
	public bool Sticky; 

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetSticky(Item I)
	{
		I.Sticky = true;
	}

	public void SetFloating(Item I)
	{
		I.Floating = true;
	}

	public void SetElastic(Item I)
	{
		I.Elastic = true;
	}

}
