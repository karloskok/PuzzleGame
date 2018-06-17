using UnityEngine;
using System.Collections; 

[ExecuteInEditMode]
public class Level24Base : MonoBehaviour 
{ 

	 int _index = 0; 
	 protected Element Cube9004;
	 protected Element Cube9003;
	 protected Element Cube;
	 protected Element Cylinder;
	 protected Element Cube3365;
	 protected Element Cube90019001;
	 protected Element FinalArea;
	 protected Element Cylinder90289001;
	 protected Element Cylinder901290019001;
	 protected Element Cylinder9000;
	 protected Element Restart;
	 protected Element ThirdArea;
	 protected Element Cylinder90129001;
	 protected Element Cube900390069002;
	 protected Element SecondArea;
	 protected Element Cylinder90219001;
	 protected Element FirstArea;
	 protected Element Cylinder9032;
	 protected Element Cylinder9031;
	 protected Element Cylinder9029;
	 protected Element Cylinder9028;
	 protected Element Cylinder9027;
	 protected Element Cylinder9026;
	 protected Element Cylinder9023;
	 protected Element Cylinder9022;
	 protected Element Cylinder9021;
	 protected Element Cylinder9020;
	 protected Element Cylinder9019;
	 protected Element Cylinder9018;
	 protected Element Cylinder9016;
	 protected Element Cylinder9015;
	 protected Element Cylinder9014;
	 protected Element Cylinder9013;
	 protected Element Cylinder9012;
	 protected Element Cylinder9011;
	 protected Element Cylinder9005;
	 protected Element Cube9007;
	 protected Element Cube903302;
	 protected Element Cube9001;
	 protected Element Cube325;
	 protected Element FinalCam;
	 protected Element ThirdCam;
	 protected Element SecondCam;
	 protected Element FirstCam;
	 protected Element Empty9002;
	 protected Element ThirdHover;
	 protected Element Cubeaa11;
	 protected Element Empty90019001;
	 protected Element Cube665984;
	 protected Element SecondHover;
	 protected Element Empty5546;
	 protected Element FinalHover;
	 protected Element Final2;
	 protected Element Final3;
	 protected Element Cylinder9001;
	 protected Element Final1;
	 protected Element Empty82875;
	 protected Element Cube177892;
	 protected Element TR4;
	 protected Element TR1;
	 protected Element TR2;
	 protected Element TR3;
	 protected Element Empty123;
	 protected Element SR3;
	 protected Element SR2;
	 protected Element SR1;
	 protected Element SR4;
	 protected Element Cube1122112;
	 protected Element Empty9965;
	 protected Element Cube911102;
	 protected Element FR4;
	 protected Element FR1;
	 protected Element FR2;
	 protected Element FR3;
	 protected Element Empty9001;
	 protected Element Cube9022;
	 protected Element Cube9033;
	 protected Element portal;
 
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
 
 
		Cube9004 = GameObject.Find("/Level24/Cube9004").GetComponent<Element>();
		Cube9003 = GameObject.Find("/Level24/Cube9003").GetComponent<Element>();
		Cube = GameObject.Find("/Level24/Cube").GetComponent<Element>();
		Cylinder = GameObject.Find("/Level24/Cylinder").GetComponent<Element>();
		Cube3365 = GameObject.Find("/Level24/Cube3365").GetComponent<Element>();
		Cube90019001 = GameObject.Find("/Level24/Cube90019001").GetComponent<Element>();
		FinalArea = GameObject.Find("/Level24/FinalArea").GetComponent<Element>();
		Cylinder90289001 = GameObject.Find("/Level24/Cylinder90289001").GetComponent<Element>();
		Cylinder901290019001 = GameObject.Find("/Level24/Cylinder901290019001").GetComponent<Element>();
		Cylinder9000 = GameObject.Find("/Level24/Cylinder9000").GetComponent<Element>();
		Restart = GameObject.Find("/Level24/Restart").GetComponent<Element>();
		ThirdArea = GameObject.Find("/Level24/ThirdArea").GetComponent<Element>();
		Cylinder90129001 = GameObject.Find("/Level24/Cylinder90129001").GetComponent<Element>();
		Cube900390069002 = GameObject.Find("/Level24/Cube900390069002").GetComponent<Element>();
		SecondArea = GameObject.Find("/Level24/SecondArea").GetComponent<Element>();
		Cylinder90219001 = GameObject.Find("/Level24/Cylinder90219001").GetComponent<Element>();
		FirstArea = GameObject.Find("/Level24/FirstArea").GetComponent<Element>();
		Cylinder9032 = GameObject.Find("/Level24/Cylinder9032").GetComponent<Element>();
		Cylinder9031 = GameObject.Find("/Level24/Cylinder9031").GetComponent<Element>();
		Cylinder9029 = GameObject.Find("/Level24/Cylinder9029").GetComponent<Element>();
		Cylinder9028 = GameObject.Find("/Level24/Cylinder9028").GetComponent<Element>();
		Cylinder9027 = GameObject.Find("/Level24/Cylinder9027").GetComponent<Element>();
		Cylinder9026 = GameObject.Find("/Level24/Cylinder9026").GetComponent<Element>();
		Cylinder9023 = GameObject.Find("/Level24/Cylinder9023").GetComponent<Element>();
		Cylinder9022 = GameObject.Find("/Level24/Cylinder9022").GetComponent<Element>();
		Cylinder9021 = GameObject.Find("/Level24/Cylinder9021").GetComponent<Element>();
		Cylinder9020 = GameObject.Find("/Level24/Cylinder9020").GetComponent<Element>();
		Cylinder9019 = GameObject.Find("/Level24/Cylinder9019").GetComponent<Element>();
		Cylinder9018 = GameObject.Find("/Level24/Cylinder9018").GetComponent<Element>();
		Cylinder9016 = GameObject.Find("/Level24/Cylinder9016").GetComponent<Element>();
		Cylinder9015 = GameObject.Find("/Level24/Cylinder9015").GetComponent<Element>();
		Cylinder9014 = GameObject.Find("/Level24/Cylinder9014").GetComponent<Element>();
		Cylinder9013 = GameObject.Find("/Level24/Cylinder9013").GetComponent<Element>();
		Cylinder9012 = GameObject.Find("/Level24/Cylinder9012").GetComponent<Element>();
		Cylinder9011 = GameObject.Find("/Level24/Cylinder9011").GetComponent<Element>();
		Cylinder9005 = GameObject.Find("/Level24/Cylinder9005").GetComponent<Element>();
		Cube9007 = GameObject.Find("/Level24/Cube9007").GetComponent<Element>();
		Cube903302 = GameObject.Find("/Level24/Cube903302").GetComponent<Element>();
		Cube9001 = GameObject.Find("/Level24/Cube9001").GetComponent<Element>();
		Cube325 = GameObject.Find("/Level24/Cube325").GetComponent<Element>();
		FinalCam = GameObject.Find("/Level24/FinalCam").GetComponent<Element>();
		ThirdCam = GameObject.Find("/Level24/ThirdCam").GetComponent<Element>();
		SecondCam = GameObject.Find("/Level24/SecondCam").GetComponent<Element>();
		FirstCam = GameObject.Find("/Level24/FirstCam").GetComponent<Element>();
		Empty9002 = GameObject.Find("/Level24/Empty9002").GetComponent<Element>();
		ThirdHover = GameObject.Find("/Level24/Empty9002/ThirdHover").GetComponent<Element>();
		Cubeaa11 = GameObject.Find("/Level24/Empty9002/Cubeaa11").GetComponent<Element>();
		Empty90019001 = GameObject.Find("/Level24/Empty90019001").GetComponent<Element>();
		Cube665984 = GameObject.Find("/Level24/Empty90019001/Cube665984").GetComponent<Element>();
		SecondHover = GameObject.Find("/Level24/Empty90019001/SecondHover").GetComponent<Element>();
		Empty5546 = GameObject.Find("/Level24/Empty5546").GetComponent<Element>();
		FinalHover = GameObject.Find("/Level24/Empty5546/FinalHover").GetComponent<Element>();
		Final2 = GameObject.Find("/Level24/Empty5546/Final2").GetComponent<Element>();
		Final3 = GameObject.Find("/Level24/Empty5546/Final3").GetComponent<Element>();
		Cylinder9001 = GameObject.Find("/Level24/Empty5546/Cylinder9001").GetComponent<Element>();
		Final1 = GameObject.Find("/Level24/Empty5546/Final1").GetComponent<Element>();
		Empty82875 = GameObject.Find("/Level24/Empty82875").GetComponent<Element>();
		Cube177892 = GameObject.Find("/Level24/Empty82875/Cube177892").GetComponent<Element>();
		TR4 = GameObject.Find("/Level24/Empty82875/TR4").GetComponent<Element>();
		TR1 = GameObject.Find("/Level24/Empty82875/TR1").GetComponent<Element>();
		TR2 = GameObject.Find("/Level24/Empty82875/TR2").GetComponent<Element>();
		TR3 = GameObject.Find("/Level24/Empty82875/TR3").GetComponent<Element>();
		Empty123 = GameObject.Find("/Level24/Empty123").GetComponent<Element>();
		SR3 = GameObject.Find("/Level24/Empty123/SR3").GetComponent<Element>();
		SR2 = GameObject.Find("/Level24/Empty123/SR2").GetComponent<Element>();
		SR1 = GameObject.Find("/Level24/Empty123/SR1").GetComponent<Element>();
		SR4 = GameObject.Find("/Level24/Empty123/SR4").GetComponent<Element>();
		Cube1122112 = GameObject.Find("/Level24/Empty123/Cube1122112").GetComponent<Element>();
		Empty9965 = GameObject.Find("/Level24/Empty9965").GetComponent<Element>();
		Cube911102 = GameObject.Find("/Level24/Empty9965/Cube911102").GetComponent<Element>();
		FR4 = GameObject.Find("/Level24/Empty9965/FR4").GetComponent<Element>();
		FR1 = GameObject.Find("/Level24/Empty9965/FR1").GetComponent<Element>();
		FR2 = GameObject.Find("/Level24/Empty9965/FR2").GetComponent<Element>();
		FR3 = GameObject.Find("/Level24/Empty9965/FR3").GetComponent<Element>();
		Empty9001 = GameObject.Find("/Level24/Empty9001").GetComponent<Element>();
		Cube9022 = GameObject.Find("/Level24/Empty9001/Cube9022").GetComponent<Element>();
		Cube9033 = GameObject.Find("/Level24/Empty9001/Cube9033").GetComponent<Element>();
		portal = GameObject.Find("/Level24/Empty9001/portal").GetComponent<Element>();
		DestroyImmediate(GetComponent<Element>());
		DestroyImmediate(GetComponent<Animation>());
 
	}
 
}
