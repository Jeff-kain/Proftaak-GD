using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Test;

	public Slider prefabslider; 
	public Slider prefabslider2; 

	public Slider CataSliderHori;
	public Slider CataSliderVert;

	Vector3 startingsize; 
	float slidervalue1; 
	float slidervalue2; 
	float catapultslider3; 
	public GameObject ShootingItem;

	public Vector3 CataStartPosition;
	public bool isElastic = false;



    // Use this for initialization
    void Start()
    {
        ItemPropertie(Test);
		startingsize = Test.transform.localScale;
		CataStartPosition = Test.transform.position;
    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPower(Test.GetComponent<Item>());
        }
        if(Input.GetAxis("Horizontal")!=0)
        {
            Propulsion(Test.GetComponent<Item>());
        }

		if(isElastic == true)
		{
			Stretch(Test);
		}


		ItemPropertie (Test);

		Test.transform.position = new Vector3 ((CataStartPosition.x - CataSliderHori.value), CataStartPosition.y + CataSliderVert.value, 0); 

	


    }

    public void JumpPower(Item I)
    {
        if (I.JumpPower != false)
        {

				I.GetComponent<Rigidbody>().AddForce(Vector3.up * 400);

        }
    }

    public void Propulsion(Item I)
    {
        if(I.Propulsion !=false)
        {
            I.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * 8, 0, 0)); 
        }
    }

	public void Stretch(GameObject obj)
	{
	


		Toggle TogX = GameObject.Find ("ToggleX").GetComponent<Toggle> ();
		Toggle TogY = GameObject.Find ("ToggleY").GetComponent<Toggle> ();
		Toggle TogZ = GameObject.Find ("ToggleZ").GetComponent<Toggle> ();

		if (prefabslider.value != slidervalue1) 
		{
			Debug.Log("S1");
			if (TogX.isOn == true) {    

				obj.transform.localScale = new Vector3 ((startingsize.x * prefabslider.value), obj.transform.localScale.y, obj.transform.localScale.z);
			}

			if (TogY.isOn == true) {				
				obj.transform.localScale = new Vector3 (obj.transform.localScale.x, (startingsize.y * prefabslider.value), obj.transform.localScale.z);
			}
			if (TogZ.isOn == true) {
				obj.transform.localScale = new Vector3 (obj.transform.localScale.x, obj.transform.localScale.y, (startingsize.z * prefabslider.value));
			}

			slidervalue1 = prefabslider.value;

		}

		if (prefabslider2.value != slidervalue2)
		{
			Debug.Log("S2");

			
			if(TogX.isOn == true)
			{    
				
				obj.transform.localScale = new Vector3((startingsize.x / prefabslider2.value), obj.transform.localScale.y, obj.transform.localScale.z);
			}
			
			if(TogY.isOn == true)
			{				
				obj.transform.localScale = new Vector3(obj.transform.localScale.x,(startingsize.y / prefabslider2.value), obj.transform.localScale.z);
			}
			if(TogZ.isOn == true)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, (startingsize.z / prefabslider2.value));
			}

			slidervalue2 = prefabslider2.value;
		}




	}


	public void Catapult()
	{
		GameObject projectile = Instantiate (ShootingItem, Test.transform.position + new Vector3(1f, 1f,0), Quaternion.identity) as GameObject;


		float multiplier = 10;
		float ymutti = 10;

		ymutti = ymutti - CataSliderVert.value;
		Test.transform.position = new Vector3 ((CataStartPosition.x - CataSliderHori.value), CataStartPosition.y + CataSliderVert.value, 0); 
		Vector3 DraggedPosition = Test.transform.position;

		Vector3 ForceVector = CataStartPosition - DraggedPosition;
		Debug.Log ("Forcevector values:" + ForceVector.x + ", " + ForceVector.y + ", " + ForceVector.z);
		projectile.GetComponent<Rigidbody> ().AddForce ((2f * CataSliderHori.value),(1f * ymutti), 0f, ForceMode.Impulse);

		//20,10
	}


    public void ItemPropertie(GameObject obj)
    {
        Item.instance.SetJump(obj);
        Item.instance.SetPropulsion(obj);

		if (obj.GetComponent<Item>().Floating == true)
		{
			Item.instance.SetFloating(obj);

		}
		
		if (obj.GetComponent<Item>().Sticky == true)
		{
			Item.instance.SetSticky(obj);
		
		}
		
		if (obj.GetComponent<Item>().Elastic == true)
		{
			Item.instance.SetElastic(obj);
			isElastic = true;

		}



    }




}
