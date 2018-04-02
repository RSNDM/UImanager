using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ConcreteSubject subject = new ConcreteSubject();

        subject.Attach(new ConcreteObserver(subject, "Observe A"));
        subject.Attach(new ConcreteObserver(subject, "Observe B"));
        subject.Attach(new ConcreteObserver(subject, "Observe C"));

        subject.SubjectState = "Ready";
        subject.Notify();

        MyDelegate.testDelegate += log1;
        MyDelegate.testDelegate += log2;
        MyDelegate.testDe("TestDelegate");
	}

    void log1(string sa)
    {
        Debug.Log("First Delegate");
    }
    void log2(string sa)
    {
        Debug.Log("Second Delegate");

    }
    // Update is called once per frame
    void Update () {
		
	}
}

/// <summary>
/// abstract class observe
/// </summary>
public abstract class ObservePlayer
{
    public abstract void Receive();
}

public abstract class Subject
{
    private List<ObservePlayer> observers = new List<ObservePlayer>();
    ///<summary>
    ///add observe
    ///</summary>
    ///<param name="observer"></param>

    public void Attach(ObservePlayer ob)
    {
        observers.Add(ob);
    }

    ///<summary>
    ///remove observe
    ///</summary>
    ///<param name="observer"></param>

    public void  Detach(ObservePlayer ob)
    {
        observers.Remove(ob);
    }

    ///<summary>
    ///Notify observe
    ///</summary>
    ///<param name="observer"></param>

    public void Notify()
    {
        foreach (ObservePlayer o in observers)
        {
            o.Receive();
        }
    }
}

public  class ConcreteSubject:Subject
{
    private string subjectState;

    ///<summary>
    ///state of observe
    ///</summary>
    public string SubjectState
    {
        get { return subjectState; }
        set { subjectState = value; }
    }
}

public class ConcreteObserver:ObservePlayer
{
    private string observerState;
    private string name;
    private ConcreteSubject subject;

    public ConcreteSubject Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public ConcreteObserver(ConcreteSubject subject,string name)
    {
        this.subject = subject;
        this.name = name;
    }

    /// <summary>
    /// 收到消息后，开始更新操作
    /// </summary>
    public override void Receive()
    {
        //throw new System.NotImplementedException();
        observerState = subject.SubjectState;
        Debug.LogFormat("The observer's steate of {0} is {1}", name, observerState);
    }
}

public class    MyDelegate
{
    public delegate void TestDelegate(string log);
    public static TestDelegate testDelegate;
    public static void testDe(string s)
    {
        if (testDelegate!=null)
        {
            testDelegate(s);
        }
    }

}
