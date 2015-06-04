using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Test;

    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

	public float WantedSizeX; 
	public float WantedSizeY;
	public float WantedSizeZ;

	public bool duringjump; 

    public List<GameObject> Combination = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        Combination.Add(Object1);
        Combination.Add(Object2);
        Combination.Add(Object3);
        CombineObjects(Combination);
    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
			duringjump = true;
            JumpPower(GameObject.Find("Combined Object").GetComponent<Item>());

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Propulsion(GameObject.Find("Combined Object").GetComponent<Item>());
        }
	
		foreach (GameObject GO in Combination)
		{
			if(GameObject.Find("Combined Object").GetComponent<Item>().Elastic == true)
			{
				if(GO.GetComponent<Item>().Elastic == true)
				{
					Stretch(GO);
				}
			}
		
			if(GO.GetComponent<Item>().Sticky == true)
			{
				SetSticky();

			}
			
				

		}


	

		

    }

    public void JumpPower(Item I)
    {
        if (I.JumpPower != false)
        {
            I.GetComponent<Rigidbody>().AddForce(Vector3.up * 15);
        }
    }

    public void Propulsion(Item I)
    {
        if (I.Propulsion != false)
        {
            I.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * 8, 0, 0));
        }
    }

    public void ItemPropertie(GameObject obj)
    {
        Item.instance.SetJump(obj);
        Item.instance.SetPropulsion(obj);
	
    }

    public void SetAttributes(Item g1, Item g2)
    {
        if (g1.JumpPower == true)
        {
            g2.JumpPower = true;
        }
        if (g1.IsPlatform == true)
        {
            g2.IsPlatform = true;
        }
        if (g1.Propulsion == true)
        {
            g2.Propulsion = true;
        }

		if (g1.Elastic == true) 
		{
			g2.Elastic = true;
		}
		if (g1.Floating == true) 
		{
			g2.Floating = true;
			GameObject.Find("Combined Object").AddComponent<Floater>();
			GameObject.Find("Combined Object").GetComponent<Floater>().waterLevel = 1f;
			GameObject.Find("Combined Object").GetComponent<Floater>().floatHeight = 1f;
			GameObject.Find("Combined Object").GetComponent<Floater>().buoyancyCentreOffset.y = 0.25f;
			GameObject.Find("Combined Object").GetComponent<Floater>().bounceDamp = 0.05f;


		} 
		if (g1.Sticky == true)
		{
			g2.Sticky = true;
		}


    }

	public void Stretch(GameObject obj)
	{
		float ObjX = Mathf.Round (obj.transform.localScale.x);
		float ObjY = Mathf.Round (obj.transform.localScale.y);
		float ObjZ = Mathf.Round (obj.transform.localScale.z);

		Vector3 firstobjvalue = new Vector3 (ObjX, ObjY, ObjZ);



		float X = Mathf.Round (WantedSizeX);
		float Y = Mathf.Round (WantedSizeY);
		float Z = Mathf.Round (WantedSizeZ);


		Vector3 newvalue = new Vector3 (X, Y, Z);


		if (WantedSizeX == 0 && WantedSizeY == 0 && WantedSizeZ == 0) {
			WantedSizeX = firstobjvalue.x;
			WantedSizeY = firstobjvalue.y;
			WantedSizeZ = firstobjvalue.z;
		}

		if (firstobjvalue != newvalue) 
		{

			if(WantedSizeX <= 2.5f && WantedSizeY <= 2.5f && WantedSizeZ <= 2.5f)
			{

			obj.transform.localScale = new Vector3 (WantedSizeX, WantedSizeY, WantedSizeZ);
			}
		}
	
	}

	public void SetSticky ()
	{
		foreach (GameObject GO in Combination) 
		{
			GameObject objA= GO;
			GameObject objB= GameObject.Find("Combined Object");
			// attach a to b
			objA.transform.parent=objB.transform;
			// make sure its exactly on it
			objA.transform.localPosition= objA.transform.position;
			objA.transform.localRotation=Quaternion.identity;
		}
	}



    public void CombineObjects(List<GameObject> Items)
    {
        foreach (GameObject G in Items)
        {
            G.transform.parent = GameObject.Find("Combined Object").transform;
            SetAttributes(G.GetComponent<Item>(),GameObject.Find("Combined Object").GetComponent<Item>());
        }
        ItemPropertie(GameObject.Find("Combined Object"));
        GameObject.Find("Combined Object").GetComponent<Rigidbody>().freezeRotation = true;
    }
}
