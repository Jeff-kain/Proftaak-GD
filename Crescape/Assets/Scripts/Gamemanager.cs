using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Test;


    // Use this for initialization
    void Start()
    {
        ItemPropertie(Test);
    }
    void Awake()
    {
        instance = this;
		ItemPropertie (Test);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            JumpPower(Test.GetComponent<Item>());
        }


    }

    public void JumpPower(Item I)
    {
        Test.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
    }

    public void ItemPropertie(GameObject obj)
    {

        Item.instance.SetJump(obj);

		if (obj.GetComponent<Item>().Floating == true)
		{
			Item.instance.SetFloating(obj);
			Debug.Log("Object" + obj.name + "is eligible to float");

		}

		if (obj.GetComponent<Item>().Sticky == true)
		{
			Item.instance.SetSticky(obj);
			Debug.Log("Object" + obj.name + " is sticky!");
		}

		if (obj.GetComponent<Item>().Elastic == true)
		{
			Item.instance.SetElastic(obj);
			Debug.Log("Object" + obj.name + " is elastic!");
		}


    }


}
