using UnityEngine;
using System.Collections; 

[ExecuteInEditMode]
public class Level21Base : MonoBehaviour 
{ 

	 int _index = 0; 
	 protected Element Cube9006;
	 protected Element Cube9005;
	 protected Element Cube9004;
	 protected Element Cube90024;
	 protected Element HandleArea;
	 protected Element Cube9003;
	 protected Element Hover;
	 protected Element HoverHandle;
	 protected Element Cube4;
	 protected Element LeftArea;
	 protected Element RightArea;
	 protected Element Cube900122;
	 protected Element Cube22;
	 protected Element Cube90559001;
	 protected Element Cube90479001;
	 protected Element Cube90489001;
	 protected Element Cube90529001;
	 protected Element Cube9060;
	 protected Element Cube9059;
	 protected Element Cube9055;
	 protected Element Restart;
	 protected Element Cube9052;
	 protected Element Cube9051;
	 protected Element Cube9048;
	 protected Element Cube9047;
	 protected Element Cube9045;
	 protected Element Cube9044;
	 protected Element Cube9043;
	 protected Element Cube9042;
	 protected Element Cube9041;
	 protected Element Cube9040;
	 protected Element Cube9039;
	 protected Element Cube9038;
	 protected Element portal;
	 protected Element Cube9033;
	 protected Element Cube9025;
	 protected Element Cube9022;
	 protected Element Cylinder9016;
	 protected Element Cylinder9013;
	 protected Element Cylinder9011;
	 protected Element Cylinder9012;
	 protected Element Cube9008;
	 protected Element Cube90044;
	 protected Element Cube;
	 protected Element Cylinder9002;
	 protected Element Cube9002;
	 protected Element RightCam;
	 protected Element StarttCam;
	 protected Element leftCam;
	 protected Element Empty9001;
	 protected Element BridgeStart;
	 protected Element Empty;
	 protected Element HandleInside;
	 protected Element empBridge;
	 protected Element Bridge;
	 protected Element Cube9010;
	 protected Element empRightHolder;
	 protected Element RightHolder;
	 protected Element empLeftHolder;
	 protected Element LeftHolder;
	 protected Element empLeftHandle;
	 protected Element LeftHandle;
	 protected Element empRightHandle;
	 protected Element RightHandle;
 
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
 
 
		Cube9006 = GameObject.Find("/Level21/Cube9006").GetComponent<Element>();
		Cube9005 = GameObject.Find("/Level21/Cube9005").GetComponent<Element>();
		Cube9004 = GameObject.Find("/Level21/Cube9004").GetComponent<Element>();
		Cube90024 = GameObject.Find("/Level21/Cube90024").GetComponent<Element>();
		HandleArea = GameObject.Find("/Level21/HandleArea").GetComponent<Element>();
		Cube9003 = GameObject.Find("/Level21/Cube9003").GetComponent<Element>();
		Hover = GameObject.Find("/Level21/Hover").GetComponent<Element>();
		HoverHandle = GameObject.Find("/Level21/Hover").GetComponent<Element>();
		Cube4 = GameObject.Find("/Level21/Cube4").GetComponent<Element>();
		LeftArea = GameObject.Find("/Level21/LeftArea").GetComponent<Element>();
		RightArea = GameObject.Find("/Level21/RightArea").GetComponent<Element>();
		Cube900122 = GameObject.Find("/Level21/Cube900122").GetComponent<Element>();
		Cube22 = GameObject.Find("/Level21/Cube22").GetComponent<Element>();
		Cube90559001 = GameObject.Find("/Level21/Cube90559001").GetComponent<Element>();
		Cube90479001 = GameObject.Find("/Level21/Cube90479001").GetComponent<Element>();
		Cube90489001 = GameObject.Find("/Level21/Cube90489001").GetComponent<Element>();
		Cube90529001 = GameObject.Find("/Level21/Cube90529001").GetComponent<Element>();
		Cube9060 = GameObject.Find("/Level21/Cube9060").GetComponent<Element>();
		Cube9059 = GameObject.Find("/Level21/Cube9059").GetComponent<Element>();
		Cube9055 = GameObject.Find("/Level21/Cube9055").GetComponent<Element>();
		Restart = GameObject.Find("/Level21/Restart").GetComponent<Element>();
		Cube9052 = GameObject.Find("/Level21/Cube9052").GetComponent<Element>();
		Cube9051 = GameObject.Find("/Level21/Cube9051").GetComponent<Element>();
		Cube9048 = GameObject.Find("/Level21/Cube9048").GetComponent<Element>();
		Cube9047 = GameObject.Find("/Level21/Cube9047").GetComponent<Element>();
		Cube9045 = GameObject.Find("/Level21/Cube9045").GetComponent<Element>();
		Cube9044 = GameObject.Find("/Level21/Cube9044").GetComponent<Element>();
		Cube9043 = GameObject.Find("/Level21/Cube9043").GetComponent<Element>();
		Cube9042 = GameObject.Find("/Level21/Cube9042").GetComponent<Element>();
		Cube9041 = GameObject.Find("/Level21/Cube9041").GetComponent<Element>();
		Cube9040 = GameObject.Find("/Level21/Cube9040").GetComponent<Element>();
		Cube9039 = GameObject.Find("/Level21/Cube9039").GetComponent<Element>();
		Cube9038 = GameObject.Find("/Level21/Cube9038").GetComponent<Element>();
		portal = GameObject.Find("/Level21/portal").GetComponent<Element>();
		Cube9033 = GameObject.Find("/Level21/Cube9033").GetComponent<Element>();
		Cube9025 = GameObject.Find("/Level21/Cube9025").GetComponent<Element>();
		Cube9022 = GameObject.Find("/Level21/Cube9022").GetComponent<Element>();
		Cylinder9016 = GameObject.Find("/Level21/Cylinder9016").GetComponent<Element>();
		Cylinder9013 = GameObject.Find("/Level21/Cylinder9013").GetComponent<Element>();
		Cylinder9011 = GameObject.Find("/Level21/Cylinder9011").GetComponent<Element>();
		Cylinder9012 = GameObject.Find("/Level21/Cylinder9012").GetComponent<Element>();
		Cube9008 = GameObject.Find("/Level21/Cube9008").GetComponent<Element>();
		Cube90044 = GameObject.Find("/Level21/Cube90044").GetComponent<Element>();
		Cube = GameObject.Find("/Level21/Cube").GetComponent<Element>();
		Cylinder9002 = GameObject.Find("/Level21/Cylinder9002").GetComponent<Element>();
		Cube9002 = GameObject.Find("/Level21/Cube9002").GetComponent<Element>();
		RightCam = GameObject.Find("/Level21/RightCam").GetComponent<Element>();
		StarttCam = GameObject.Find("/Level21/StarttCam").GetComponent<Element>();
		leftCam = GameObject.Find("/Level21/leftCam").GetComponent<Element>();
		Empty9001 = GameObject.Find("/Level21/Empty9001").GetComponent<Element>();
		BridgeStart = GameObject.Find("/Level21/Empty9001/BridgeStart").GetComponent<Element>();
		Empty = GameObject.Find("/Level21/Empty").GetComponent<Element>();
		HandleInside = GameObject.Find("/Level21/Empty/HandleInside").GetComponent<Element>();
		empBridge = GameObject.Find("/Level21/empBridge").GetComponent<Element>();
		Bridge = GameObject.Find("/Level21/empBridge/Bridge").GetComponent<Element>();
		Cube9010 = GameObject.Find("/Level21/empBridge/Bridge").GetComponent<Element>();
		empRightHolder = GameObject.Find("/Level21/empRightHolder").GetComponent<Element>();
		RightHolder = GameObject.Find("/Level21/empRightHolder/RightHolder").GetComponent<Element>();
		empLeftHolder = GameObject.Find("/Level21/empLeftHolder").GetComponent<Element>();
		LeftHolder = GameObject.Find("/Level21/empLeftHolder/LeftHolder").GetComponent<Element>();
		empLeftHandle = GameObject.Find("/Level21/empLeftHandle").GetComponent<Element>();
		LeftHandle = GameObject.Find("/Level21/empLeftHandle/LeftHandle").GetComponent<Element>();
		empRightHandle = GameObject.Find("/Level21/empRightHandle").GetComponent<Element>();
		RightHandle = GameObject.Find("/Level21/empRightHandle/RightHandle").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
