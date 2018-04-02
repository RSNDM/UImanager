using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubject_Delegate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


///具体观察者
public class  Customer:MonoBehaviour
{
    ///声明委托
    public delegate void CustomerEventHandler();

    //创建委托
    public static CustomerEventHandler Handler;

    //有购买行为，就发送事件
    void Update()
    {
        Handler
            ();
    }
}

///<summary >
///财务，已经不需要实现抽象的观察者类，并且不用引用具体的主题
///</summary>

    public class Accountant:MonoBehaviour
{
    private void Start()
    {
        //注册
        Customer.Handler += GiveInvoice;
    }

    public void GiveInvoice()
    {
        Debug.Log("开发票");
    }
}

///<summary >
///出纳，已经不需要实现抽象的观察者类，并且不用引用具体的主题
///</summary>
public class Cashier:MonoBehaviour
{
    private void Start()
    {
        Customer.Handler += Recoded;

    }

    public void Recoded()
    {
        Debug.Log("出纳员，我给登陆机长");
    }
}
