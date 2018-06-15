using UnityEngine;
using System.Collections; 

[ExecuteInEditMode]
public class Level23Base : MonoBehaviour 
{ 

	 int _index = 0; 
	 protected Element Cube9042559001;
	 protected Element Cube904225;
	 protected Element ButtonArea;
	 protected Element StartArea;
	 protected Element Cube96695;
	 protected Element Cube123538;
	 protected Element Cube903228;
	 protected Element Cube12538;
	 protected Element ThirdArea;
	 protected Element SecondArea;
	 protected Element Cube12;
	 protected Element Restart;
	 protected Element Cube9043;
	 protected Element Cube9029;
	 protected Element Cube9;
	 protected Element Cube456053;
	 protected Element Cube90553;
	 protected Element Cube9041;
	 protected Element hh;
	 protected Element Cube9022;
	 protected Element Cube9033;
	 protected Element portal;
	 protected Element ButtonCam;
	 protected Element ThirdCam;
	 protected Element StartCam;
	 protected Element Empty900211;
	 protected Element ThirdHover;
	 protected Element Empty90019001;
	 protected Element Empty9007;
	 protected Element PortalBridge;
	 protected Element Empty9005;
	 protected Element StartBridge;
	 protected Element Empty9004;
	 protected Element P4;
	 protected Element P3;
	 protected Element P2;
	 protected Element Cube9016;
	 protected Element Cube9005;
	 protected Element P1;
	 protected Element Empty9003;
	 protected Element TR3;
	 protected Element Cube9048;
	 protected Element TR2;
	 protected Element TR1;
	 protected Element Cube9021;
	 protected Element TR4;
	 protected Element Empty9002;
	 protected Element Cube2261412;
	 protected Element SecondHover;
	 protected Element SR4;
	 protected Element Cube9017;
	 protected Element SR1;
	 protected Element SR2;
	 protected Element Cube9014;
	 protected Element SR3;
	 protected Element SecondtCam;
	 protected Element Empty9001;
	 protected Element Cube1221156;
	 protected Element FirstArea;
	 protected Element FR2;
	 protected Element FR1;
	 protected Element Cube9004;
	 protected Element FirstCam;
	 protected Element Empty;
	 protected Element FinalHolder;
	 protected Element Opener1;
	 protected Element Opener2;
	 protected Element Empty9006;
	 protected Element B16;
	 protected Element B15;
	 protected Element B14;
	 protected Element B13;
	 protected Element B12;
	 protected Element B11;
	 protected Element B10;
	 protected Element B9;
	 protected Element B8;
	 protected Element B7;
	 protected Element B6;
	 protected Element B5;
	 protected Element B4;
	 protected Element B3;
	 protected Element B2;
	 protected Element B1;
	 protected Element Buttons;
	 protected Element Cube;
 
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
 
 
		Cube9042559001 = GameObject.Find("/Level23/Cube9042559001").GetComponent<Element>();
		Cube904225 = GameObject.Find("/Level23/Cube904225").GetComponent<Element>();
		ButtonArea = GameObject.Find("/Level23/ButtonArea").GetComponent<Element>();
		StartArea = GameObject.Find("/Level23/StartArea").GetComponent<Element>();
		Cube96695 = GameObject.Find("/Level23/Cube96695").GetComponent<Element>();
		Cube123538 = GameObject.Find("/Level23/Cube123538").GetComponent<Element>();
		Cube903228 = GameObject.Find("/Level23/Cube903228").GetComponent<Element>();
		Cube12538 = GameObject.Find("/Level23/Cube12538").GetComponent<Element>();
		ThirdArea = GameObject.Find("/Level23/ThirdArea").GetComponent<Element>();
		SecondArea = GameObject.Find("/Level23/SecondArea").GetComponent<Element>();
		Cube12 = GameObject.Find("/Level23/Cube12").GetComponent<Element>();
		Restart = GameObject.Find("/Level23/Restart").GetComponent<Element>();
		Cube9043 = GameObject.Find("/Level23/Cube9043").GetComponent<Element>();
		Cube9029 = GameObject.Find("/Level23/Cube9029").GetComponent<Element>();
		Cube9 = GameObject.Find("/Level23/Cube9").GetComponent<Element>();
		Cube456053 = GameObject.Find("/Level23/Cube456053").GetComponent<Element>();
		Cube90553 = GameObject.Find("/Level23/Cube90553").GetComponent<Element>();
		Cube9041 = GameObject.Find("/Level23/Cube9041").GetComponent<Element>();
		hh = GameObject.Find("/Level23/hh").GetComponent<Element>();
		Cube9022 = GameObject.Find("/Level23/Cube9022").GetComponent<Element>();
		Cube9033 = GameObject.Find("/Level23/Cube9033").GetComponent<Element>();
		portal = GameObject.Find("/Level23/portal").GetComponent<Element>();
		ButtonCam = GameObject.Find("/Level23/ButtonCam").GetComponent<Element>();
		ThirdCam = GameObject.Find("/Level23/ThirdCam").GetComponent<Element>();
		StartCam = GameObject.Find("/Level23/StartCam").GetComponent<Element>();
		Empty900211 = GameObject.Find("/Level23/Empty900211").GetComponent<Element>();
		ThirdHover = GameObject.Find("/Level23/Empty900211/ThirdHover").GetComponent<Element>();
		Empty90019001 = GameObject.Find("/Level23/Empty90019001").GetComponent<Element>();
		Empty9007 = GameObject.Find("/Level23/Empty9007").GetComponent<Element>();
		PortalBridge = GameObject.Find("/Level23/Empty9007/PortalBridge").GetComponent<Element>();
		Empty9005 = GameObject.Find("/Level23/Empty9005").GetComponent<Element>();
		StartBridge = GameObject.Find("/Level23/Empty9005/StartBridge").GetComponent<Element>();
		Empty9004 = GameObject.Find("/Level23/Empty9004").GetComponent<Element>();
		P4 = GameObject.Find("/Level23/Empty9004/P4").GetComponent<Element>();
		P3 = GameObject.Find("/Level23/Empty9004/P3").GetComponent<Element>();
		P2 = GameObject.Find("/Level23/Empty9004/P2").GetComponent<Element>();
		Cube9016 = GameObject.Find("/Level23/Empty9004/Cube9016").GetComponent<Element>();
		Cube9005 = GameObject.Find("/Level23/Empty9004/Cube9005").GetComponent<Element>();
		P1 = GameObject.Find("/Level23/Empty9004/P1").GetComponent<Element>();
		Empty9003 = GameObject.Find("/Level23/Empty9003").GetComponent<Element>();
		TR3 = GameObject.Find("/Level23/Empty9003/TR3").GetComponent<Element>();
		Cube9048 = GameObject.Find("/Level23/Empty9003/Cube9048").GetComponent<Element>();
		TR2 = GameObject.Find("/Level23/Empty9003/TR2").GetComponent<Element>();
		TR1 = GameObject.Find("/Level23/Empty9003/TR1").GetComponent<Element>();
		Cube9021 = GameObject.Find("/Level23/Empty9003/Cube9021").GetComponent<Element>();
		TR4 = GameObject.Find("/Level23/Empty9003/TR4").GetComponent<Element>();
		Empty9002 = GameObject.Find("/Level23/Empty9002").GetComponent<Element>();
		Cube2261412 = GameObject.Find("/Level23/Empty9002/Cube2261412").GetComponent<Element>();
		SecondHover = GameObject.Find("/Level23/Empty9002/SecondHover").GetComponent<Element>();
		SR4 = GameObject.Find("/Level23/Empty9002/SR4").GetComponent<Element>();
		Cube9017 = GameObject.Find("/Level23/Empty9002/Cube9017").GetComponent<Element>();
		SR1 = GameObject.Find("/Level23/Empty9002/SR1").GetComponent<Element>();
		SR2 = GameObject.Find("/Level23/Empty9002/SR2").GetComponent<Element>();
		Cube9014 = GameObject.Find("/Level23/Empty9002/Cube9014").GetComponent<Element>();
		SR3 = GameObject.Find("/Level23/Empty9002/SR3").GetComponent<Element>();
		SecondtCam = GameObject.Find("/Level23/Empty9002/SecondtCam").GetComponent<Element>();
		Empty9001 = GameObject.Find("/Level23/Empty9001").GetComponent<Element>();
		Cube1221156 = GameObject.Find("/Level23/Empty9001/Cube1221156").GetComponent<Element>();
		FirstArea = GameObject.Find("/Level23/Empty9001/FirstArea").GetComponent<Element>();
		FR2 = GameObject.Find("/Level23/Empty9001/FR2").GetComponent<Element>();
		FR1 = GameObject.Find("/Level23/Empty9001/FR1").GetComponent<Element>();
		Cube9004 = GameObject.Find("/Level23/Empty9001/Cube9004").GetComponent<Element>();
		FirstCam = GameObject.Find("/Level23/Empty9001/FirstCam").GetComponent<Element>();
		Empty = GameObject.Find("/Level23/Empty").GetComponent<Element>();
		FinalHolder = GameObject.Find("/Level23/Empty/FinalHolder").GetComponent<Element>();
		Opener1 = GameObject.Find("/Level23/Empty/Opener1").GetComponent<Element>();
		Opener2 = GameObject.Find("/Level23/Empty/Opener2").GetComponent<Element>();
		Empty9006 = GameObject.Find("/Level23/Empty9006").GetComponent<Element>();
		B16 = GameObject.Find("/Level23/Empty9006/B16").GetComponent<Element>();
		B15 = GameObject.Find("/Level23/Empty9006/B15").GetComponent<Element>();
		B14 = GameObject.Find("/Level23/Empty9006/B14").GetComponent<Element>();
		B13 = GameObject.Find("/Level23/Empty9006/B13").GetComponent<Element>();
		B12 = GameObject.Find("/Level23/Empty9006/B12").GetComponent<Element>();
		B11 = GameObject.Find("/Level23/Empty9006/B11").GetComponent<Element>();
		B10 = GameObject.Find("/Level23/Empty9006/B10").GetComponent<Element>();
		B9 = GameObject.Find("/Level23/Empty9006/B9").GetComponent<Element>();
		B8 = GameObject.Find("/Level23/Empty9006/B8").GetComponent<Element>();
		B7 = GameObject.Find("/Level23/Empty9006/B7").GetComponent<Element>();
		B6 = GameObject.Find("/Level23/Empty9006/B6").GetComponent<Element>();
		B5 = GameObject.Find("/Level23/Empty9006/B5").GetComponent<Element>();
		B4 = GameObject.Find("/Level23/Empty9006/B4").GetComponent<Element>();
		B3 = GameObject.Find("/Level23/Empty9006/B3").GetComponent<Element>();
		B2 = GameObject.Find("/Level23/Empty9006/B2").GetComponent<Element>();
		B1 = GameObject.Find("/Level23/Empty9006/B1").GetComponent<Element>();
		Buttons = GameObject.Find("/Level23/Empty9006/Buttons").GetComponent<Element>();
		Cube = GameObject.Find("/Level23/Empty9006/Cube").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
