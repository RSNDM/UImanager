using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class VistorMode : MonoBehaviour {

    System.Diagnostics.Process pro = new System.Diagnostics.Process();
    //抽象元素角色
    public abstract class Element
    {
        public abstract void Accept(IVsitor vsitor);
        public abstract void Print();
    }

    public class ElementA:Element
    {
        public override void Accept(IVsitor vsitor)
        {
            //throw new System.NotImplementedException();
            vsitor.Visit(this);
        }
        public override void Print()
        {
            //throw new System.NotImplementedException();
            Debug.Log("Element A");
        }
    }
    public class ElementB : Element
    {
        public override void Accept(IVsitor vsitor)
        {
            //throw new System.NotImplementedException();
            vsitor.Visit(this);
        }
        public override void Print()
        {
            //throw new System.NotImplementedException();
            Debug.Log("Element B");
        }
    }
    public interface IVsitor
    {
        void Visit(ElementA element);
        void Visit(ElementB element);
    }

    public class ConcreteVisitor:IVsitor
    {
        public void Visit(ElementA a)
        {
            a.Print();
        }
        public void Visit(ElementB b)
        {
            b.Print();
        }
    }

    public class ObjectStructure
    {
        private ArrayList elements = new ArrayList();
        public ArrayList Elements
        {
            get { return elements; }
        }

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = Random.Range(0, 10);
                if (ranNum>5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }
	// Use this for initialization
	void Start () {
        pro.StartInfo.FileName = "cmd.exe";
        ObjectStructure objectStructure = new ObjectStructure();
        foreach (Element e in objectStructure.Elements)
        {
            Debug.Log("begin visit");
            e.Accept(new ConcreteVisitor());
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
//洗牌算法
namespace ListConsole
{
    public  class Application
    {
        public List<int> IntSort(List<int > list)
        {
            list.Sort(
                
                    delegate(int a,int b)
                    {
                        return a.CompareTo(b);
                    }
                
            );

            list.Sort((a, b) => b.CompareTo(a));
            return list;
        }
        //数组洗牌
        void ArrayShuffle()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = Random.Range(0, array.Length);
                int temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
            foreach (int a in array)
            {
                Debug.Log(a);
            }
        }
    }
}
