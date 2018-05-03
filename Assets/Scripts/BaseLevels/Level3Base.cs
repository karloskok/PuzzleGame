using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Level3Base : MonoBehaviour 
{
 
	int _index = 0; 
 
	protected Element Cube0034;
	protected Element Cube0035;
	protected Element Cube0036;
	protected Element Cube0037;
	protected Element Cube0038;
	protected Element Cube0039;
	protected Element Cube0040;
	protected Element Cube0041;
	protected Element Cube0042;
	protected Element Cube0043;
	protected Element Cube0044;
	protected Element Cube0045;
	protected Element Cube0046;
	protected Element Cube0047;
	protected Element Cube0048;
	protected Element Cube0049;
	protected Element Cube0050;
	protected Element Cube0051;
	protected Element Cube0052;
	protected Element Cube0053;
	protected Element Cube0054;
	protected Element Cube0055;
	protected Element Cube0056;
	protected Element Cube0058;
	protected Element Cube0059;
	protected Element Cube0060;
	protected Element Cube0061;
	protected Element Empty;
	protected Element bridge;
	protected Element Empty0001;
	protected Element bridgeLever;
	protected Element Cube0057;
	protected Element Plane0010;
	protected Element Sun;
 
	void Awake () 
	{
 
		Transform[] _elements = GetComponentsInChildren<Transform>(); 
		for (int i = 1; i < _elements.Length; i++)
		{
	 	 	if (!_elements[i].gameObject.GetComponent<Element>())
	 	  		_elements[i].gameObject.AddComponent<Element>();
	 	  	_elements[i].gameObject.GetComponent<Element>()._name = _elements[i].gameObject.name;
	  		_elements[i].gameObject.GetComponent<Element>()._index = ++_index;
 
 
			if (!_elements[i].gameObject.GetComponent<GenerateComponents>())
			_elements[i].gameObject.AddComponent<GenerateComponents>();
 
		}
 
 
		Cube0034 = GameObject.Find("/Level3/Cube0034").GetComponent<Element>();
		Cube0035 = GameObject.Find("/Level3/Cube0035").GetComponent<Element>();
		Cube0036 = GameObject.Find("/Level3/Cube0036").GetComponent<Element>();
		Cube0037 = GameObject.Find("/Level3/Cube0037").GetComponent<Element>();
		Cube0038 = GameObject.Find("/Level3/Cube0038").GetComponent<Element>();
		Cube0039 = GameObject.Find("/Level3/Cube0039").GetComponent<Element>();
		Cube0040 = GameObject.Find("/Level3/Cube0040").GetComponent<Element>();
		Cube0041 = GameObject.Find("/Level3/Cube0041").GetComponent<Element>();
		Cube0042 = GameObject.Find("/Level3/Cube0042").GetComponent<Element>();
		Cube0043 = GameObject.Find("/Level3/Cube0043").GetComponent<Element>();
		Cube0044 = GameObject.Find("/Level3/Cube0044").GetComponent<Element>();
		Cube0045 = GameObject.Find("/Level3/Cube0045").GetComponent<Element>();
		Cube0046 = GameObject.Find("/Level3/Cube0046").GetComponent<Element>();
		Cube0047 = GameObject.Find("/Level3/Cube0047").GetComponent<Element>();
		Cube0048 = GameObject.Find("/Level3/Cube0048").GetComponent<Element>();
		Cube0049 = GameObject.Find("/Level3/Cube0049").GetComponent<Element>();
		Cube0050 = GameObject.Find("/Level3/Cube0050").GetComponent<Element>();
		Cube0051 = GameObject.Find("/Level3/Cube0051").GetComponent<Element>();
		Cube0052 = GameObject.Find("/Level3/Cube0052").GetComponent<Element>();
		Cube0053 = GameObject.Find("/Level3/Cube0053").GetComponent<Element>();
		Cube0054 = GameObject.Find("/Level3/Cube0054").GetComponent<Element>();
		Cube0055 = GameObject.Find("/Level3/Cube0055").GetComponent<Element>();
		Cube0056 = GameObject.Find("/Level3/Cube0056").GetComponent<Element>();
		Cube0058 = GameObject.Find("/Level3/Cube0058").GetComponent<Element>();
		Cube0059 = GameObject.Find("/Level3/Cube0059").GetComponent<Element>();
		Cube0060 = GameObject.Find("/Level3/Cube0060").GetComponent<Element>();
		Cube0061 = GameObject.Find("/Level3/Cube0061").GetComponent<Element>();
		Empty = GameObject.Find("/Level3/Empty").GetComponent<Element>();
		bridge = GameObject.Find("/Level3/Empty/bridge").GetComponent<Element>();
		Empty0001 = GameObject.Find("/Level3/Empty0001").GetComponent<Element>();
		bridgeLever = GameObject.Find("/Level3/Empty0001/bridgeLever").GetComponent<Element>();
		Cube0057 = GameObject.Find("/Level3/Empty0001/Cube0057").GetComponent<Element>();
		Plane0010 = GameObject.Find("/Level3/Plane0010").GetComponent<Element>();
		Sun = GameObject.Find("/Level3/Sun").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
