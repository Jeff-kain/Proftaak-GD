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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            JumpPower(Test.GetComponent<Item>());
        }
        if(Input.GetAxis("Horizontal")!=0)
        {
            Propulsion(Test.GetComponent<Item>());
        }
    }

    public void JumpPower(Item I)
    {
        if (I.JumpPower != false)
        {
            I.rigidbody.AddForce(Vector3.up * 400);
        }
    }

    public void Propulsion(Item I)
    {
        if(I.Propulsion !=false)
        {
            I.rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * 8, 0, 0)); 
        }
    }

    public void ItemPropertie(GameObject obj)
    {
        Item.instance.SetJump(obj);
        Item.instance.SetPropulsion(obj);
    }
}
