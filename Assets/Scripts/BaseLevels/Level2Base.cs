using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Level2Base : MonoBehaviour 
{
 
	int _index = 0; 
 
	protected Element blueCube;
	protected Element bluePress;
	protected Element Circle;
	protected Element cube02;
	protected Element Cube9;
	protected Element Cube44;
	protected Element Cube45;
	protected Element Cube302;
	protected Element FGate;
	protected Element FGateLits;
	protected Element floor;
	protected Element greenCube;
	protected Element greenPress;
	protected Element greenUp;
	protected Element portalUp;
	protected Element redCube;
	protected Element redPress;
	protected Element redUp;
 
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
 
 
		blueCube = GameObject.Find("/Level2/blueCube").GetComponent<Element>();
		bluePress = GameObject.Find("/Level2/bluePress").GetComponent<Element>();
		Circle = GameObject.Find("/Level2/Circle").GetComponent<Element>();
		cube02 = GameObject.Find("/Level2/cube02").GetComponent<Element>();
		Cube9 = GameObject.Find("/Level2/Cube9").GetComponent<Element>();
		Cube44 = GameObject.Find("/Level2/Cube44").GetComponent<Element>();
		Cube45 = GameObject.Find("/Level2/Cube45").GetComponent<Element>();
		Cube302 = GameObject.Find("/Level2/Cube302").GetComponent<Element>();
		FGate = GameObject.Find("/Level2/FGate").GetComponent<Element>();
		FGateLits = GameObject.Find("/Level2/FGateLits").GetComponent<Element>();
		floor = GameObject.Find("/Level2/floor").GetComponent<Element>();
		greenCube = GameObject.Find("/Level2/greenCube").GetComponent<Element>();
		greenPress = GameObject.Find("/Level2/greenPress").GetComponent<Element>();
		greenUp = GameObject.Find("/Level2/greenUp").GetComponent<Element>();
		portalUp = GameObject.Find("/Level2/portalUp").GetComponent<Element>();
		redCube = GameObject.Find("/Level2/redCube").GetComponent<Element>();
		redPress = GameObject.Find("/Level2/redPress").GetComponent<Element>();
		redUp = GameObject.Find("/Level2/redUp").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
