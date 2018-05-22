using UnityEngine;
using System.Collections; 

[ExecuteInEditMode]
public class Level2Base : MonoBehaviour 
{ 

	 int _index = 0; 
	 protected Element Cube90439001;
	 protected Element aa9001;
	 protected Element Cube900790019001;
	 protected Element Cube901490019001;
	 protected Element Cube900590019001;
	 protected Element Cube900690019001;
	 protected Element Cube9001900190019001;
	 protected Element Cube9002900190019001;
	 protected Element Cube900290019001;
	 protected Element Cube900190019001;
	 protected Element Cube90099001;
	 protected Element Cube90109001;
	 protected Element Cube90199001;
	 protected Element Cube90209001;
	 protected Element Cube90159001;
	 protected Element Cube90169001;
	 protected Element Cube9020;
	 protected Element Cube9019;
	 protected Element Cube9018;
	 protected Element Cube9017;
	 protected Element Cube9016;
	 protected Element Cube9015;
	 protected Element Cube90149001;
	 protected Element Cube90139001;
	 protected Element Cube9012;
	 protected Element Cube9011;
	 protected Element Cube9010;
	 protected Element Cube9009;
	 protected Element Cube9008;
	 protected Element Cube90079001;
	 protected Element Cube90069001;
	 protected Element Cube90059001;
	 protected Element Cube9004;
	 protected Element Cube9003;
	 protected Element Cube90029001;
	 protected Element Cube90019001;
	 protected Element Cube;
	 protected Element Cube9045;
	 protected Element Cube9043;
	 protected Element Cube9014;
	 protected Element Cube9007;
	 protected Element aa;
	 protected Element Cube9002;
	 protected Element Cube9006;
	 protected Element Bridge;
	 protected Element Cube9005;
	 protected Element Cube9001;
	 protected Element Circle;
	 protected Element Cube9291;
 
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
 
 
		Cube90439001 = GameObject.Find("/Level2/Cube90439001").GetComponent<Element>();
		aa9001 = GameObject.Find("/Level2/aa9001").GetComponent<Element>();
		Cube900790019001 = GameObject.Find("/Level2/Cube900790019001").GetComponent<Element>();
		Cube901490019001 = GameObject.Find("/Level2/Cube901490019001").GetComponent<Element>();
		Cube900590019001 = GameObject.Find("/Level2/Cube900590019001").GetComponent<Element>();
		Cube900690019001 = GameObject.Find("/Level2/Cube900690019001").GetComponent<Element>();
		Cube9001900190019001 = GameObject.Find("/Level2/Cube9001900190019001").GetComponent<Element>();
		Cube9002900190019001 = GameObject.Find("/Level2/Cube9002900190019001").GetComponent<Element>();
		Cube900290019001 = GameObject.Find("/Level2/Cube900290019001").GetComponent<Element>();
		Cube900190019001 = GameObject.Find("/Level2/Cube900190019001").GetComponent<Element>();
		Cube90099001 = GameObject.Find("/Level2/Cube90099001").GetComponent<Element>();
		Cube90109001 = GameObject.Find("/Level2/Cube90109001").GetComponent<Element>();
		Cube90199001 = GameObject.Find("/Level2/Cube90199001").GetComponent<Element>();
		Cube90209001 = GameObject.Find("/Level2/Cube90209001").GetComponent<Element>();
		Cube90159001 = GameObject.Find("/Level2/Cube90159001").GetComponent<Element>();
		Cube90169001 = GameObject.Find("/Level2/Cube90169001").GetComponent<Element>();
		Cube9020 = GameObject.Find("/Level2/Cube9020").GetComponent<Element>();
		Cube9019 = GameObject.Find("/Level2/Cube9019").GetComponent<Element>();
		Cube9018 = GameObject.Find("/Level2/Cube9018").GetComponent<Element>();
		Cube9017 = GameObject.Find("/Level2/Cube9017").GetComponent<Element>();
		Cube9016 = GameObject.Find("/Level2/Cube9016").GetComponent<Element>();
		Cube9015 = GameObject.Find("/Level2/Cube9015").GetComponent<Element>();
		Cube90149001 = GameObject.Find("/Level2/Cube90149001").GetComponent<Element>();
		Cube90139001 = GameObject.Find("/Level2/Cube90139001").GetComponent<Element>();
		Cube9012 = GameObject.Find("/Level2/Cube9012").GetComponent<Element>();
		Cube9011 = GameObject.Find("/Level2/Cube9011").GetComponent<Element>();
		Cube9010 = GameObject.Find("/Level2/Cube9010").GetComponent<Element>();
		Cube9009 = GameObject.Find("/Level2/Cube9009").GetComponent<Element>();
		Cube9008 = GameObject.Find("/Level2/Cube9008").GetComponent<Element>();
		Cube90079001 = GameObject.Find("/Level2/Cube90079001").GetComponent<Element>();
		Cube90069001 = GameObject.Find("/Level2/Cube90069001").GetComponent<Element>();
		Cube90059001 = GameObject.Find("/Level2/Cube90059001").GetComponent<Element>();
		Cube9004 = GameObject.Find("/Level2/Cube9004").GetComponent<Element>();
		Cube9003 = GameObject.Find("/Level2/Cube9003").GetComponent<Element>();
		Cube90029001 = GameObject.Find("/Level2/Cube90029001").GetComponent<Element>();
		Cube90019001 = GameObject.Find("/Level2/Cube90019001").GetComponent<Element>();
		Cube = GameObject.Find("/Level2/Cube").GetComponent<Element>();
		Cube9045 = GameObject.Find("/Level2/Cube9045").GetComponent<Element>();
		Cube9043 = GameObject.Find("/Level2/Cube9043").GetComponent<Element>();
		Cube9014 = GameObject.Find("/Level2/Cube9014").GetComponent<Element>();
		Cube9007 = GameObject.Find("/Level2/Cube9007").GetComponent<Element>();
		aa = GameObject.Find("/Level2/aa").GetComponent<Element>();
		Cube9002 = GameObject.Find("/Level2/Cube9002").GetComponent<Element>();
		Cube9006 = GameObject.Find("/Level2/Cube9006").GetComponent<Element>();
		Bridge = GameObject.Find("/Level2/Bridge").GetComponent<Element>();
		Cube9005 = GameObject.Find("/Level2/Cube9005").GetComponent<Element>();
		Cube9001 = GameObject.Find("/Level2/Cube9001").GetComponent<Element>();
		Circle = GameObject.Find("/Level2/Circle").GetComponent<Element>();
		Cube9291 = GameObject.Find("/Level2/Cube9291").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
