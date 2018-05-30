using UnityEngine;
using System.Collections; 

[ExecuteInEditMode]
public class Level11Base : MonoBehaviour 
{ 

	 int _index = 0; 
	 protected Element LeverArea;
	 protected Element Cube900590019007;
	 protected Element Cube900690019007;
	 protected Element Cube900690019006;
	 protected Element Cube900590019006;
	 protected Element Cube900590019005;
	 protected Element Cube900690019005;
	 protected Element Cube90129012;
	 protected Element Cube90119012;
	 protected Element Cube90119011;
	 protected Element Cube90129011;
	 protected Element Cube90129010;
	 protected Element Cube90119010;
	 protected Element Cube90119009;
	 protected Element Cube90129009;
	 protected Element Cube90129008;
	 protected Element Cube90119008;
	 protected Element Cube90119007;
	 protected Element Cube90129007;
	 protected Element Cube90129006;
	 protected Element Cube90119006;
	 protected Element Cube90119005;
	 protected Element Cube90129005;
	 protected Element Cube90129004;
	 protected Element Cube90119004;
	 protected Element Cube90119003;
	 protected Element Cube90129003;
	 protected Element Cube90129002;
	 protected Element Cube90119002;
	 protected Element Cube90119001;
	 protected Element Cube90129001;
	 protected Element Cube900690019004;
	 protected Element Cube900590019004;
	 protected Element Cube900590019003;
	 protected Element Cube900690019003;
	 protected Element Cube900690019002;
	 protected Element Cube900590019002;
	 protected Element Cube9005900190019001;
	 protected Element Cube9006900190019001;
	 protected Element Cube90439001;
	 protected Element aa9001;
	 protected Element Cube900790019001;
	 protected Element Cube901490019001;
	 protected Element Cube900590019001;
	 protected Element Cube900690019001;
	 protected Element Cube9001900190019001;
	 protected Element Cube9002900190019001;
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
	 protected Element Cube9001;
	 protected Element portal;
	 protected Element Cube9291;
	 protected Element Restart;
	 protected Element Empty9001;
	 protected Element Lever;
	 protected Element Cube900190019001;
	 protected Element Empty;
	 protected Element Bridge;
 
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
 
 
		LeverArea = GameObject.Find("/Level11/LeverArea").GetComponent<Element>();
		Cube900590019007 = GameObject.Find("/Level11/Cube900590019007").GetComponent<Element>();
		Cube900690019007 = GameObject.Find("/Level11/Cube900690019007").GetComponent<Element>();
		Cube900690019006 = GameObject.Find("/Level11/Cube900690019006").GetComponent<Element>();
		Cube900590019006 = GameObject.Find("/Level11/Cube900590019006").GetComponent<Element>();
		Cube900590019005 = GameObject.Find("/Level11/Cube900590019005").GetComponent<Element>();
		Cube900690019005 = GameObject.Find("/Level11/Cube900690019005").GetComponent<Element>();
		Cube90129012 = GameObject.Find("/Level11/Cube90129012").GetComponent<Element>();
		Cube90119012 = GameObject.Find("/Level11/Cube90119012").GetComponent<Element>();
		Cube90119011 = GameObject.Find("/Level11/Cube90119011").GetComponent<Element>();
		Cube90129011 = GameObject.Find("/Level11/Cube90129011").GetComponent<Element>();
		Cube90129010 = GameObject.Find("/Level11/Cube90129010").GetComponent<Element>();
		Cube90119010 = GameObject.Find("/Level11/Cube90119010").GetComponent<Element>();
		Cube90119009 = GameObject.Find("/Level11/Cube90119009").GetComponent<Element>();
		Cube90129009 = GameObject.Find("/Level11/Cube90129009").GetComponent<Element>();
		Cube90129008 = GameObject.Find("/Level11/Cube90129008").GetComponent<Element>();
		Cube90119008 = GameObject.Find("/Level11/Cube90119008").GetComponent<Element>();
		Cube90119007 = GameObject.Find("/Level11/Cube90119007").GetComponent<Element>();
		Cube90129007 = GameObject.Find("/Level11/Cube90129007").GetComponent<Element>();
		Cube90129006 = GameObject.Find("/Level11/Cube90129006").GetComponent<Element>();
		Cube90119006 = GameObject.Find("/Level11/Cube90119006").GetComponent<Element>();
		Cube90119005 = GameObject.Find("/Level11/Cube90119005").GetComponent<Element>();
		Cube90129005 = GameObject.Find("/Level11/Cube90129005").GetComponent<Element>();
		Cube90129004 = GameObject.Find("/Level11/Cube90129004").GetComponent<Element>();
		Cube90119004 = GameObject.Find("/Level11/Cube90119004").GetComponent<Element>();
		Cube90119003 = GameObject.Find("/Level11/Cube90119003").GetComponent<Element>();
		Cube90129003 = GameObject.Find("/Level11/Cube90129003").GetComponent<Element>();
		Cube90129002 = GameObject.Find("/Level11/Cube90129002").GetComponent<Element>();
		Cube90119002 = GameObject.Find("/Level11/Cube90119002").GetComponent<Element>();
		Cube90119001 = GameObject.Find("/Level11/Cube90119001").GetComponent<Element>();
		Cube90129001 = GameObject.Find("/Level11/Cube90129001").GetComponent<Element>();
		Cube900690019004 = GameObject.Find("/Level11/Cube900690019004").GetComponent<Element>();
		Cube900590019004 = GameObject.Find("/Level11/Cube900590019004").GetComponent<Element>();
		Cube900590019003 = GameObject.Find("/Level11/Cube900590019003").GetComponent<Element>();
		Cube900690019003 = GameObject.Find("/Level11/Cube900690019003").GetComponent<Element>();
		Cube900690019002 = GameObject.Find("/Level11/Cube900690019002").GetComponent<Element>();
		Cube900590019002 = GameObject.Find("/Level11/Cube900590019002").GetComponent<Element>();
		Cube9005900190019001 = GameObject.Find("/Level11/Cube9005900190019001").GetComponent<Element>();
		Cube9006900190019001 = GameObject.Find("/Level11/Cube9006900190019001").GetComponent<Element>();
		Cube90439001 = GameObject.Find("/Level11/Cube90439001").GetComponent<Element>();
		aa9001 = GameObject.Find("/Level11/aa9001").GetComponent<Element>();
		Cube900790019001 = GameObject.Find("/Level11/Cube900790019001").GetComponent<Element>();
		Cube901490019001 = GameObject.Find("/Level11/Cube901490019001").GetComponent<Element>();
		Cube900590019001 = GameObject.Find("/Level11/Cube900590019001").GetComponent<Element>();
		Cube900690019001 = GameObject.Find("/Level11/Cube900690019001").GetComponent<Element>();
		Cube9001900190019001 = GameObject.Find("/Level11/Cube9001900190019001").GetComponent<Element>();
		Cube9002900190019001 = GameObject.Find("/Level11/Cube9002900190019001").GetComponent<Element>();
		Cube90099001 = GameObject.Find("/Level11/Cube90099001").GetComponent<Element>();
		Cube90109001 = GameObject.Find("/Level11/Cube90109001").GetComponent<Element>();
		Cube90199001 = GameObject.Find("/Level11/Cube90199001").GetComponent<Element>();
		Cube90209001 = GameObject.Find("/Level11/Cube90209001").GetComponent<Element>();
		Cube90159001 = GameObject.Find("/Level11/Cube90159001").GetComponent<Element>();
		Cube90169001 = GameObject.Find("/Level11/Cube90169001").GetComponent<Element>();
		Cube9020 = GameObject.Find("/Level11/Cube9020").GetComponent<Element>();
		Cube9019 = GameObject.Find("/Level11/Cube9019").GetComponent<Element>();
		Cube9018 = GameObject.Find("/Level11/Cube9018").GetComponent<Element>();
		Cube9017 = GameObject.Find("/Level11/Cube9017").GetComponent<Element>();
		Cube9016 = GameObject.Find("/Level11/Cube9016").GetComponent<Element>();
		Cube9015 = GameObject.Find("/Level11/Cube9015").GetComponent<Element>();
		Cube90149001 = GameObject.Find("/Level11/Cube90149001").GetComponent<Element>();
		Cube90139001 = GameObject.Find("/Level11/Cube90139001").GetComponent<Element>();
		Cube9012 = GameObject.Find("/Level11/Cube9012").GetComponent<Element>();
		Cube9011 = GameObject.Find("/Level11/Cube9011").GetComponent<Element>();
		Cube9010 = GameObject.Find("/Level11/Cube9010").GetComponent<Element>();
		Cube9009 = GameObject.Find("/Level11/Cube9009").GetComponent<Element>();
		Cube9008 = GameObject.Find("/Level11/Cube9008").GetComponent<Element>();
		Cube90079001 = GameObject.Find("/Level11/Cube90079001").GetComponent<Element>();
		Cube90069001 = GameObject.Find("/Level11/Cube90069001").GetComponent<Element>();
		Cube90059001 = GameObject.Find("/Level11/Cube90059001").GetComponent<Element>();
		Cube9004 = GameObject.Find("/Level11/Cube9004").GetComponent<Element>();
		Cube9003 = GameObject.Find("/Level11/Cube9003").GetComponent<Element>();
		Cube90029001 = GameObject.Find("/Level11/Cube90029001").GetComponent<Element>();
		Cube90019001 = GameObject.Find("/Level11/Cube90019001").GetComponent<Element>();
		Cube = GameObject.Find("/Level11/Cube").GetComponent<Element>();
		Cube9045 = GameObject.Find("/Level11/Cube9045").GetComponent<Element>();
		Cube9043 = GameObject.Find("/Level11/Cube9043").GetComponent<Element>();
		Cube9014 = GameObject.Find("/Level11/Cube9014").GetComponent<Element>();
		Cube9007 = GameObject.Find("/Level11/Cube9007").GetComponent<Element>();
		aa = GameObject.Find("/Level11/aa").GetComponent<Element>();
		Cube9002 = GameObject.Find("/Level11/Cube9002").GetComponent<Element>();
		Cube9006 = GameObject.Find("/Level11/Cube9006").GetComponent<Element>();
		Cube9001 = GameObject.Find("/Level11/Cube9001").GetComponent<Element>();
		portal = GameObject.Find("/Level11/portal").GetComponent<Element>();
		Cube9291 = GameObject.Find("/Level11/Cube9291").GetComponent<Element>();
		Restart = GameObject.Find("/Level11/Restart").GetComponent<Element>();
		Empty9001 = GameObject.Find("/Level11/Empty9001").GetComponent<Element>();
		Lever = GameObject.Find("/Level11/Empty9001/Lever").GetComponent<Element>();
		Cube900190019001 = GameObject.Find("/Level11/Empty9001/Cube900190019001").GetComponent<Element>();
		Empty = GameObject.Find("/Level11/Empty").GetComponent<Element>();
		Bridge = GameObject.Find("/Level11/Empty/Bridge").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
