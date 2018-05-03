using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Level1Base : MonoBehaviour 
{
 
	int _index = 0; 
 
	protected Element BaseLever;
	protected Element boxDoor;
	protected Element bridge;
	protected Element door;
	protected Element Empty;
	protected Element Ball;
	protected Element floor1;
	protected Element floor;
	protected Element lever;
	protected Element leverTrigger;
	protected Element Press;
	protected Element snoe;
	protected Element wall;
 
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
 
 
		BaseLever = GameObject.Find("/Level1/BaseLever").GetComponent<Element>();
		boxDoor = GameObject.Find("/Level1/boxDoor").GetComponent<Element>();
		bridge = GameObject.Find("/Level1/bridge").GetComponent<Element>();
		door = GameObject.Find("/Level1/door").GetComponent<Element>();
		Empty = GameObject.Find("/Level1/Empty").GetComponent<Element>();
		Ball = GameObject.Find("/Level1/Empty/Ball").GetComponent<Element>();
		floor1 = GameObject.Find("/Level1/floor1").GetComponent<Element>();
		floor = GameObject.Find("/Level1/floor").GetComponent<Element>();
		lever = GameObject.Find("/Level1/lever").GetComponent<Element>();
		leverTrigger = GameObject.Find("/Level1/leverTrigger").GetComponent<Element>();
		Press = GameObject.Find("/Level1/Press").GetComponent<Element>();
		snoe = GameObject.Find("/Level1/snoe").GetComponent<Element>();
		wall = GameObject.Find("/Level1/wall").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
