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

	public void SetSticky(GameObject GO)
	{
		if (Sticky != false && GO.GetComponent<Rigidbody> () == null)
		{
			GO.AddComponent<Rigidbody>();
		}

	}

	public void SetFloating(GameObject GO)
	{
		if (Floating != false && GO.GetComponent<Rigidbody> () == null) 
		{
			GO.AddComponent<Rigidbody>();		
		}

	}

	public void SetElastic(GameObject GO)
	{
		if (Elastic != false && GO.GetComponent<Rigidbody> () == null)
		{
			GO.AddComponent<Rigidbody>();
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

	private void OnCollisionEnter(Collision c)
	{
		if (Sticky == true) {
			if (c.collider.gameObject.layer != LayerMask.NameToLayer("Ground")) {
				c.transform.parent = gameObject.transform;
			}
		}

	}

	private void OnCollisionExit(Collision c)
	{
		
		if (transform.parent != null)
		{
			Debug.Log("Object" + name + "has a parent!");
			if (Vector3.Distance (c.transform.position, transform.position) > 0f) {
				transform.parent = null;
			}
		}
		

	}

}
