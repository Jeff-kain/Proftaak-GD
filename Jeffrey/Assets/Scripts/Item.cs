using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public static Item instance;

	public bool Elastic;
	public bool Floating; 
	public bool JumpPower; 
	public bool IsPlatform;
	public bool Propulsion;
	public bool Sticky; 

	// Use this for initialization
	void Start ()
	{

	}
	
    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetSticky(Item I)
	{
		if (I.Sticky != false)
		{

		}

	}

	public void SetFloating(GameObject GO)
	{
		if (Floating != false && GO.GetComponent<Rigidbody> () == null) 
		{
			GO.AddComponent<Rigidbody>();		
		}

	}

	public void SetElastic(Item I)
	{
		if (I.Elastic != false)
		{
			//Animations?
		}


	}

    public void SetJump(GameObject GO)
    {
        if(JumpPower!=false && GO.GetComponent<Rigidbody>()==null)
        {
            GO.AddComponent<Rigidbody>();
        }
    }

    public void SetPropulsion(GameObject GO)
    {
        if (Propulsion != false && GO.GetComponent<Rigidbody>() == null)
        {
            GO.AddComponent<Rigidbody>();
        }
    }

    // TODO: ADD TO GITHUB
    public void SetPlatform(GameObject GO)
    {
        if(IsPlatform != false)
        {

        }
    }


	


}
