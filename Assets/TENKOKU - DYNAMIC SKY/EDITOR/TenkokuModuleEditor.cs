using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

//this limits the editor to running on object that have type CameraLocationHolder
[CustomEditor(typeof(Tenkoku.Core.TenkokuModule))]
public class TenkokuModuleEditor : Editor {


	public override void OnInspectorGUI() {
    

    	Undo.RecordObject(target, "Changed Area Of Effect");


    	Color colorEnabled = new Color(1.0f,1.0f,1.0f,1.0f);
		Color colorDisabled = new Color(1.0f,1.0f,1.0f,0.25f);
    	Texture logoTex = Resources.Load("textures/gui_tex_tenkokulogo") as Texture;
		Texture divTex = Resources.Load("textures/gui_tex_tenkokudiv") as Texture;
		Texture divRevTex = Resources.Load("textures/gui_tex_tenkokudivrev") as Texture;


    	Tenkoku.Core.TenkokuModule script = (Tenkoku.Core.TenkokuModule) target;

    	EditorGUI.BeginChangeCheck();


		#if UNITY_PRO_LICENSE
			divRevTex = Resources.Load("textures/gui_tex_tenkokudivrev") as Texture;
			divTex = Resources.Load("textures/gui_tex_tenkokudiv") as Texture;
			logoTex = Resources.Load("textures/gui_tex_tenkokulogo") as Texture;
		#else
			divRevTex = Resources.Load("textures/gui_tex_tenkokudivrev_i") as Texture;
			divTex = Resources.Load("textures/gui_tex_tenkokudiv_i") as Texture;
			logoTex = Resources.Load("textures/gui_tex_tenkokulogo_i") as Texture;
		#endif



		//SET SCREEN WIDTH
		int setWidth = Screen.width-220;
		if (setWidth < 120) setWidth = 120;
		
		
		//TENKOKU LOGO
		GUIContent buttonText = new GUIContent(""); 
		GUIStyle buttonStyle = GUIStyle.none; 
		Rect rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
		int margin = 15;





		//start menu
		EditorGUI.LabelField(new Rect(rt.x+margin+2, rt.y+35, 50, 18),"Version");
		
		Rect linkVerRect = new Rect(rt.x+margin+51, rt.y+35, 40, 18);
		EditorGUI.LabelField(linkVerRect,script.tenkokuVersionNumber);

	    Rect linkHelpRect = new Rect(rt.x+margin+165, rt.y+35, 28, 18);
	    Rect linkBugRect = new Rect(rt.x+margin+165+42, rt.y+35, 65, 18);
	    Rect linkURLRect = new Rect(rt.x+margin+165+120, rt.y+35, 100, 18);
	    
		if (Event.current.type == EventType.MouseUp && linkHelpRect.Contains(Event.current.mousePosition)) Application.OpenURL("http://www.tanukidigital.com/forum/");
		if (Event.current.type == EventType.MouseUp && linkBugRect.Contains(Event.current.mousePosition)) Application.OpenURL("http://www.tanukidigital.com/forum/");
		if (Event.current.type == EventType.MouseUp && linkURLRect.Contains(Event.current.mousePosition)) Application.OpenURL("http://www.tanukidigital.com/tenkoku/");

		EditorGUI.LabelField(new Rect(rt.x+margin+165+30, rt.y+35, 220, 18),"|");
		EditorGUI.LabelField(new Rect(rt.x+margin+165+110, rt.y+35, 220, 18),"|");
		
		EditorGUI.LabelField(linkHelpRect,"help");
		EditorGUI.LabelField(linkBugRect,"report bug");
		EditorGUI.LabelField(linkURLRect,"tanukidigital.com");
		// end menu




        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,36),logoTex);
        GUILayout.Space(42.0f);

		
		
		
		
        
        //SKY TIMER
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showTimer = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showTimer, "");
        GUI.Label (new Rect(rt.x+margin+10, rt.y+5, 300, 20), new GUIContent("TIME AND POSITION"));
        
        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showTimer = !script.showTimer;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);

        if (script.showTimer){
        	EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+309,387,34),divRevTex);
        	GUI.contentColor = new Color(0.74f,0.65f,0.35f,1.0f);

        	float setAmMargin = 0.0f;
        	//string amLabel = "am";

        	script.displayHour = EditorGUI.FloatField(new Rect(rt.x+margin+20, rt.y+25, 24, 18), "", script.displayHour);
        	script.currentMinute = EditorGUI.IntField(new Rect(rt.x+margin+50, rt.y+25, 24, 18), "", script.currentMinute);
        	script.currentSecond = EditorGUI.IntField(new Rect(rt.x+margin+80, rt.y+25, 24, 18), "", script.currentSecond);
        	GUI.Label(new Rect(rt.x+margin+43, rt.y+25, 10, 18), ":");
        	GUI.Label(new Rect(rt.x+margin+73, rt.y+25, 10, 18), ":");
        	GUI.Label(new Rect(rt.x+margin+106, rt.y+25, 25, 18), script.hourMode);
        	script.currentMonth = EditorGUI.IntField(new Rect(rt.x+margin+setAmMargin+140, rt.y+25, 25, 18), "", script.currentMonth);
        	script.currentDay = EditorGUI.IntField(new Rect(rt.x+margin+setAmMargin+180, rt.y+25, 25, 18), "", script.currentDay);
        	script.currentYear = EditorGUI.IntField(new Rect(rt.x+margin+setAmMargin+220, rt.y+25, 35, 18), "", script.currentYear);
        	GUI.Label(new Rect(rt.x+margin+setAmMargin+168, rt.y+25, 10, 18), "/");
        	GUI.Label(new Rect(rt.x+margin+setAmMargin+208, rt.y+25, 10, 18), "/");
        	
        	GUI.contentColor = colorEnabled;
        	script.use24Clock = EditorGUI.Toggle(new Rect(rt.x+margin+275, rt.y+25, 60, 15), "", script.use24Clock);
        	GUI.Label (new Rect (rt.x+margin+290, rt.y+25, 100, 15), new GUIContent("12H Clock"));

			GUILayout.Space(10.0f);

        	if (script.autoDateSync){
        		GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+55, 80, 15), new GUIContent("Year"));
        	script.currentYear = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+55, setWidth+60, 18), "", script.currentYear,-20000,20000);
        	GUI.Label (new Rect (rt.x+margin+10, rt.y+75, 80, 15), new GUIContent("Month"));
        	script.currentMonth = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+75, setWidth+60, 18), "", script.currentMonth,1,12);
        	GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 80, 15), new GUIContent("Day"));
        	script.currentDay = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+95, setWidth+60, 18), "", script.currentDay,1,31);
            GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;    	

        	if (script.autoTimeSync){
        		GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}

			GUI.Label (new Rect (rt.x+margin+10, rt.y+125, 80, 15), new GUIContent("Hour"));
        	script.currentHour = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+125, setWidth+60, 18), "", script.currentHour,0,23);
        	GUI.Label (new Rect (rt.x+margin+10, rt.y+145, 80, 15), new GUIContent("Minute"));
        	script.currentMinute = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+145, setWidth+60, 18), "", script.currentMinute,0,59);
            GUI.Label (new Rect (rt.x+margin+10, rt.y+165, 80, 15), new GUIContent("Second"));
        	script.currentSecond = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+165, setWidth+60, 18), "", script.currentSecond,0,59);


        	GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			
			GUI.Label (new Rect (rt.x+margin+10, rt.y+195, 100, 15), new GUIContent ("Latitude"));
			script.setLatitude = EditorGUI.Slider(new Rect(rt.x+margin+100, rt.y+195, setWidth+60, 15), "", script.setLatitude, -90.0f, 90.0f);
			GUI.Label (new Rect (rt.x+margin+10, rt.y+215, 100, 15), new GUIContent ("Longitude"));
			script.setLongitude = EditorGUI.Slider(new Rect(rt.x+margin+100, rt.y+215, setWidth+60, 15), "", script.setLongitude, -180.0f, 180.0f);
			GUI.Label (new Rect (rt.x+margin+10, rt.y+235, 100, 15), new GUIContent ("Time Zone"));
			script.setTZOffset = EditorGUI.IntSlider(new Rect(rt.x+margin+100, rt.y+235, setWidth+60, 15), "", script.setTZOffset, -14, 14);

     		script.enableDST = EditorGUI.Toggle(new Rect(rt.x+margin+10, rt.y+265, 60, 15), "", script.enableDST);
        	GUI.Label (new Rect (rt.x+margin+30, rt.y+265, 230, 15), new GUIContent("Enable Daylight Savings Time"));


     		script.autoTimeSync = EditorGUI.Toggle(new Rect(rt.x+margin+10, rt.y+295, 60, 15), "", script.autoTimeSync);
        	GUI.Label (new Rect (rt.x+margin+30, rt.y+295, 230, 15), new GUIContent("Sync to System Time"));

     		script.autoDateSync = EditorGUI.Toggle(new Rect(rt.x+margin+210, rt.y+295, 60, 15), "", script.autoDateSync);
        	GUI.Label (new Rect (rt.x+margin+230, rt.y+295, 230, 15), new GUIContent("Sync to System Date"));


        	if (script.autoTimeSync){
        		GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			script.autoTime = EditorGUI.Toggle(new Rect(rt.x+margin+10, rt.y+315, 60, 15), "", script.autoTime);
        	GUI.Label (new Rect (rt.x+margin+30, rt.y+315, 140, 15), new GUIContent("Advance Time  x"));
        	script.timeCompression = EditorGUI.FloatField(new Rect(rt.x+margin+135, rt.y+315, 50, 15), "", script.timeCompression);

        	GUI.Label (new Rect (rt.x+margin+205, rt.y+315, 80, 15), new GUIContent("Speed Curve"));
        	script.timeCurves = EditorGUI.CurveField(new Rect(rt.x+margin+285, rt.y+315, 90, 15), "", script.timeCurves);

        	GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;

        	GUILayout.Space(310.0f);

        
        }
        GUILayout.Space(10.0f);
        
        
        
        
        //CONFIGURATION
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showConfig = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showConfig, "");
        GUI.Label (new Rect (rt.x+margin+10, rt.y+5, 300, 20), new GUIContent ("CONFIGURATION"));

        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showConfig = !script.showConfig;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);

        if (script.showConfig){
        	EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+425,387,34),divRevTex);
			GUILayout.Space(10.0f);


			EditorGUI.LabelField(new Rect(rt.x+margin+10, rt.y+25, 180, 18),"Camera Mode");
			string[] cameraTypeOptions = new string[]{"Auto Select Camera","Manual Select Camera"};
			script.cameraTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+25, 150, 18),"", script.cameraTypeIndex, cameraTypeOptions);


			if (script.cameraTypeIndex == 0){
        		GUI.contentColor = colorDisabled;
        		GUI.backgroundColor = colorDisabled;
			}
			GUI.Label (new Rect (rt.x+margin+10, rt.y+45, 100, 15), new GUIContent ("Main Camera"));

			script.manualCamera = EditorGUI.ObjectField(new Rect(rt.x+margin+165, rt.y+45, setWidth, 15), script.manualCamera, typeof(Transform), true) as Transform;
			GUI.contentColor = colorEnabled;
        	GUI.backgroundColor = colorEnabled;


			GUI.Label (new Rect (rt.x+margin+10, rt.y+75, 100, 15), new GUIContent ("Overall Tint"));
			script.colorOverlay = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+75, setWidth, 15), script.colorOverlay);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 100, 15), new GUIContent ("Sky Tint"));
			script.colorSky = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+95, setWidth, 15), script.colorSky);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+115, 100, 15), new GUIContent ("Ambient Tint"));
			script.colorAmbient = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+115, setWidth, 15), script.colorAmbient);


			GUI.Label (new Rect (rt.x+margin+10, rt.y+135, 100, 15), new GUIContent ("Sun Scattering"));
			script.colorSkyboxMie = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+135, setWidth, 15), script.colorSkyboxMie);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+155, 100, 15), new GUIContent ("Skybox Ground"));
			script.colorSkyboxGround = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+155, setWidth, 15), script.colorSkyboxGround);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+175, 100, 15), new GUIContent ("Fog Tint"));
			script.colorFog = EditorGUI.ColorField(new Rect(rt.x+margin+165, rt.y+175, setWidth, 15), script.colorFog);

         	GUI.Label (new Rect (rt.x+margin+10, rt.y+195, 100, 15), new GUIContent ("Color Texture"));
        	script.colorRamp = EditorGUI.ObjectField(new Rect(rt.x+margin+165, rt.y+195, setWidth, 35), script.colorRamp, typeof(Texture2D), true) as Texture2D;
        	
			EditorGUI.LabelField(new Rect(rt.x+margin+10, rt.y+240, 180, 18),"Scene Light Layers");
			if (script.gameObject.activeInHierarchy){
				script.lightLayer = EditorGUI.MaskField(new Rect(rt.x+margin+165, rt.y+240, 150, 18),"", script.lightLayer, script.tenLayerMasks.ToArray());
			}



        	GUI.Label (new Rect (rt.x+margin+10, rt.y+260, 140, 15), new GUIContent("Enable Reflection Probe"));
        	script.enableProbe = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+260, 40, 15), "", script.enableProbe);
			if (!script.enableProbe){
        		GUI.contentColor = colorDisabled;
        		GUI.backgroundColor = colorDisabled;
			}
        	GUI.Label (new Rect (rt.x+margin+200, rt.y+260, 140, 15), new GUIContent("Update FPS"));
        	script.reflectionProbeFPS = EditorGUI.FloatField(new Rect(rt.x+margin+275, rt.y+260, 40, 15), "", script.reflectionProbeFPS);
        	GUI.contentColor = colorEnabled;
        	GUI.backgroundColor = colorEnabled;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+290, 100, 15), new GUIContent ("Set Orientation"));
			script.setRotation = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+290, setWidth, 15), "", script.setRotation, 0.0f, 359.0f);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+310, 150, 15), new GUIContent ("Minimum Light Altitude"));
			script.minimumHeight = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+310, setWidth, 15), "", script.minimumHeight, 0.0f, 90.0f);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+330, 150, 15), new GUIContent ("Set Ambient Colors"));
			script.useAmbient = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+330, 60, 15), "", script.useAmbient);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+350, 150, 15), new GUIContent ("Allow Multi-Lighting"));
			script.allowMultiLights = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+350, 60, 15), "", script.allowMultiLights);




			script.enableAutoAdvance = EditorGUI.Toggle(new Rect(rt.x+margin+10, rt.y+380, 20, 18),"", script.enableAutoAdvance);

			if (!script.enableAutoAdvance){
	        	GUI.contentColor = colorDisabled;
        		GUI.backgroundColor = colorDisabled;
			}

			EditorGUI.LabelField(new Rect(rt.x+margin+30, rt.y+380, 340, 18),"AUTO-ADVANCE SYSTEM TIMER");
	        script.systemTime = EditorGUI.FloatField(new Rect(rt.x+margin+260, rt.y+380, 120, 18),"",script.systemTime);
			
        	GUI.contentColor = colorDisabled;
        	GUI.backgroundColor = colorDisabled;
        	EditorGUI.LabelField(new Rect(rt.x+margin+30, rt.y+395, 340, 18),"the 'systemTime' variable is automatically advanced by");
        	EditorGUI.LabelField(new Rect(rt.x+margin+30, rt.y+407, 340, 18),"default.  This variable can be shared across a network to");
			EditorGUI.LabelField(new Rect(rt.x+margin+30, rt.y+419, 340, 18),"sync cloud positions between client and server computers.");
			GUI.contentColor = colorEnabled;
        	GUI.backgroundColor = colorEnabled;


        	GUILayout.Space(415.0f);
        }
        GUILayout.Space(10.0f);

        


  
        
        //CELESTIAL SETTINGS
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showCelSet = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showCelSet, "");
        GUI.Label (new Rect (rt.x+margin+10, rt.y+5, 300, 20), new GUIContent ("CELESTIAL SETTINGS"));

        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showCelSet = !script.showCelSet;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);


        if (script.showCelSet){
        	EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+629,387,34),divRevTex);

        	//sun
        	GUI.contentColor = colorEnabled;
        	GUI.backgroundColor = colorEnabled;
			GUI.Label (new Rect (rt.x+margin+10, rt.y+28, 100, 20), new GUIContent ("Sun Rendering"));
			string[] sunTypeOptions = new string[]{"Realistic","Custom","Off"};
			script.sunTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+28, setWidth, 18),"",script.sunTypeIndex, sunTypeOptions);

			if (script.sunTypeIndex == 2){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+45, 100, 20), new GUIContent ("Light Amount"));
			script.sunBright = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+45, setWidth, 15), "", script.sunBright, 0.0f, 5.0f);
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+65, 100, 20), new GUIContent ("Light Saturation"));
			script.sunSat = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+65, setWidth, 15), "", script.sunSat, 0.0f, 1.0f);
        	GUI.Label (new Rect (rt.x+margin+20, rt.y+85, 180, 15), new GUIContent("Sky Amount (Day)"));
        	script.skyBrightness = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+85, setWidth, 18), "", script.skyBrightness,0.0f,5.0f);
        	GUI.Label (new Rect (rt.x+margin+20, rt.y+105, 180, 15), new GUIContent("Mie Amount"));
        	script.mieAmount = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+105, setWidth, 18), "", script.mieAmount,0.0f,2.0f);
		    GUI.Label (new Rect (rt.x+margin+20, rt.y+125, 100, 20), new GUIContent ("Size"));
			script.sunSize = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+125, setWidth, 15), "", script.sunSize, 0.005f, 1.1f);
			
					
			//moon
			GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			GUI.Label (new Rect (rt.x+margin+10, rt.y+158, 100, 20), new GUIContent ("Moon Rendering"));
			string[] moonTypeOptions = new string[]{"Realistic","Custom","Off"};
			script.moonTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+158, setWidth, 18),"",script.moonTypeIndex, moonTypeOptions);

			if (script.moonTypeIndex == 2){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+178, 100, 20), new GUIContent ("Light Amount"));
			script.moonBright = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+178, setWidth, 15), "", script.moonBright, 0.0f, 5.0f);
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+198, 100, 20), new GUIContent ("Light Saturation"));
			script.moonSat = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+198, setWidth, 15), "", script.moonSat, 0.0f, 1.0f);
        	GUI.Label (new Rect (rt.x+margin+20, rt.y+218, 180, 15), new GUIContent("Sky Amount (Night)"));
        	script.nightBrightness = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+218, setWidth, 18), "", script.nightBrightness,0.0f,1.0f);
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+238, 180, 15), new GUIContent("Mie Amount"));
        	script.mieMnAmount = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+238, setWidth, 18), "", script.mieMnAmount,0.0f,2.0f);
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+258, 100, 20), new GUIContent ("Size"));
			script.moonSize = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+258, setWidth, 15), "", script.moonSize, 0.005f, 1f);


			if (script.moonTypeIndex == 0){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}

			GUI.Label (new Rect (rt.x+margin+20, rt.y+278, 100, 20), new GUIContent ("Custom Offset"));
			script.moonPos = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+278, setWidth, 15), "", script.moonPos, 0.0f, 359.0f);
			//GUI.Label (new Rect (rt.x+margin+20, rt.y+258, 100, 20), new GUIContent ("Phase"));
			//script.moonPhase = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+258, setWidth, 15), "", script.moonPhase, 0.0f, 359.0f);
			


			//stars
			GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			GUI.Label (new Rect (rt.x+margin+10, rt.y+313, 120, 20), new GUIContent ("Star Rendering"));
			string[] starTypeOptions = new string[]{"Realistic","Custom","Off"};
			script.starTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+313, setWidth, 18),"",script.starTypeIndex, starTypeOptions);

			if (script.starTypeIndex == 2){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			
        	GUI.Label (new Rect (rt.x+margin+20, rt.y+333, 120, 15), new GUIContent("Brightness"));
        	script.starIntensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+333, setWidth, 18), "", script.starIntensity,0.0f,2.0f);

           	GUI.Label (new Rect (rt.x+margin+20, rt.y+353, 190, 15), new GUIContent("Planet Brightness"));
        	script.planetIntensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+353, setWidth, 18), "", script.planetIntensity,0.0f,2.0f);

			if (script.starTypeIndex == 0){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			
			GUI.Label (new Rect (rt.x+margin+20, rt.y+373, 120, 20), new GUIContent ("Star Offset"));
			script.starPos = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+373, setWidth, 15), "", script.starPos, 0.0f, 359.0f);

			

			//Aurora Borealis
			GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			GUI.Label (new Rect (rt.x+margin+10, rt.y+404, 120, 20), new GUIContent ("Aurora Rendering"));
			string[] auroraTypeOptions = new string[]{"On","Off"};
			script.auroraTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+404, setWidth, 18),"",script.auroraTypeIndex, auroraTypeOptions);
			
			if (script.auroraTypeIndex == 1){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			
	        GUI.Label (new Rect (rt.x+margin+20, rt.y+424, 120, 20), new GUIContent ("Visible Latitude"));
			script.auroraLatitude = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+424, setWidth, 15), "", script.auroraLatitude, 0.0f, 90.0f);

			GUI.Label (new Rect (rt.x+margin+20, rt.y+444, 120, 20), new GUIContent("Brightness"));
        	script.auroraIntensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+444, setWidth, 18), "", script.auroraIntensity,0.0f,1.0f);

        	GUI.Label (new Rect (rt.x+margin+20, rt.y+464, 120, 20), new GUIContent("Speed"));
        	script.auroraSpeed = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+464, setWidth, 18), "", script.auroraSpeed,0.0f,2.0f);



			//Galaxy / night skybox
			GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			GUI.Label (new Rect (rt.x+margin+10, rt.y+502, 120, 20), new GUIContent ("Galaxy Rendering"));
			string[] galaxyTypeOptions = new string[]{"Realistic","Custom","Off"};
			script.galaxyTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+502, setWidth, 18),"",script.galaxyTypeIndex, galaxyTypeOptions);
			
			if (script.galaxyTypeIndex == 2){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
        	GUI.Label (new Rect (rt.x+margin+20, rt.y+522, 180, 15), new GUIContent("Brightness"));
        	script.galaxyIntensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+522, setWidth, 18), "", script.galaxyIntensity,0.0f,2.0f);

			if (script.galaxyTypeIndex == 0){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}
			GUI.Label (new Rect (rt.x+margin+20, rt.y+542, 120, 20), new GUIContent ("Galaxy Offset"));
			script.galaxyPos = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+542, setWidth, 15), "", script.galaxyPos, 0.0f, 359.0f);

			GUI.contentColor = colorEnabled;
			GUI.backgroundColor = colorEnabled;
			if (script.galaxyTypeIndex == 2){
				GUI.contentColor = colorDisabled;
				GUI.backgroundColor = colorDisabled;
			}

         	GUI.Label (new Rect (rt.x+margin+20, rt.y+562, 100, 15), new GUIContent ("Galaxy Texture"));
         	string[] galaxyTexOptions = new string[]{"2D Spheremap","Custom","Cubemap"};
         	script.galaxyTexIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+562, setWidth, 18),"",script.galaxyTexIndex, galaxyTexOptions);
         	if (script.galaxyTexIndex == 0){
        		script.galaxyTex = EditorGUI.ObjectField(new Rect(rt.x+margin+165, rt.y+582, setWidth, 55), script.galaxyTex, typeof(Texture), true) as Texture;
			} else {
				script.galaxyCubeTex = EditorGUI.ObjectField(new Rect(rt.x+margin+165, rt.y+582, setWidth, 55), script.galaxyCubeTex, typeof(Texture), true) as Texture;
			}
        	
        	
        	GUILayout.Space(620.0f);
        }
        GUILayout.Space(10.0f);

        //#########################################################################################
        
        
        
        
        

        
        
               
        //ATMOSPHERICS
        GUI.contentColor = colorEnabled;
        GUI.backgroundColor = colorEnabled;
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showConfigAtmos = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showConfigAtmos, "");
        GUI.Label (new Rect (rt.x+margin+10, rt.y+5, 300, 20), new GUIContent ("ATMOSPHERICS"));
        float spaceAdjust = 0.0f;

        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showConfigAtmos = !script.showConfigAtmos;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);


        if (script.useSunRays) spaceAdjust += 40;
			
        if (script.showConfigAtmos){
        	EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+220+spaceAdjust,387,34),divRevTex);
			GUILayout.Space(10.0f);

        	//FOG
        	GUI.Label (new Rect (rt.x+margin+10, rt.y+25, 150, 15), new GUIContent("Enable Tenkoku Fog"));
        	script.enableFog = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+25, 60, 15), "", script.enableFog);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+45, 180, 15), new GUIContent("Start Fog"));
        	script.fogAtmosphere = EditorGUI.FloatField(new Rect(rt.x+margin+165, rt.y+45, setWidth, 18), "", script.fogAtmosphere);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+65, 180, 15), new GUIContent("Fog Distance"));
        	script.fogDistance = EditorGUI.FloatField(new Rect(rt.x+margin+165, rt.y+65, setWidth, 18), "", script.fogDistance);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+85, 180, 15), new GUIContent("Fade Distance"));
        	script.fadeDistance = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+85, setWidth, 18), "", script.fadeDistance,0.0f,1.0f);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+105, 180, 15), new GUIContent("Fog Density"));
        	script.fogDensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+105, setWidth, 18), "", script.fogDensity,0.0f,1.0f);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+125, 180, 15), new GUIContent("Fog Dispersion"));
        	//script.fogDisperse = EditorGUI.IntSlider(new Rect(rt.x+margin+165, rt.y+105, setWidth, 18), "", script.fogDisperse,3,40);
     		script.fogDispersion = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+125, setWidth, 18), "", script.fogDispersion,0f,10f);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+155, 180, 15), new GUIContent("Atmospheric Density"));
        	script.atmosphereDensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+155, setWidth, 18), "", script.atmosphereDensity,0.0f,4.0f);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+175, 180, 15), new GUIContent("Horizon Density"));
        	script.horizonDensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+175, setWidth, 18), "", script.horizonDensity,0.0f,6.0f);

        	GUI.Label (new Rect (rt.x+margin+10, rt.y+195, 180, 15), new GUIContent("Horizon Height"));
        	script.horizonDensityHeight = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+195, setWidth, 18), "", script.horizonDensityHeight,0.0f,1.0f);



			GUI.Label (new Rect (rt.x+margin+10, rt.y+225, 150, 15), new GUIContent ("Calculate Light Rays"));
			script.useSunRays = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+225, 60, 15), "", script.useSunRays);
			
			if (script.useSunRays){
				GUI.Label (new Rect (rt.x+margin+10, rt.y+245, 150, 15), new GUIContent ("Sun Ray Intensity"));
        		script.sunRayIntensity = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+245, setWidth, 18), "", script.sunRayIntensity,0.0f,1.0f);

        		GUI.Label (new Rect (rt.x+margin+10, rt.y+265, 150, 15), new GUIContent ("Sun Ray Length"));
        		script.sunRayLength = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+265, setWidth, 18), "", script.sunRayLength,0.0f,1.0f);
			}

        	GUILayout.Space(220.0f + spaceAdjust);
        }
        GUILayout.Space(10.0f);



        
        //WEATHER
        GUI.contentColor = colorEnabled;
        GUI.backgroundColor = colorEnabled;
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showConfigWeather = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showConfigWeather, "");
        GUI.Label (new Rect (rt.x+margin+10, rt.y+5, 300, 20), new GUIContent ("WEATHER"));
        
        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showConfigWeather = !script.showConfigWeather;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);





        if (script.showConfigWeather){
        	
			GUILayout.Space(10.0f);

						
        	GUI.Label (new Rect (rt.x+margin+10, rt.y+25, 190, 15), new GUIContent("Weather Setting"));
        	string[] weatherTypeOptions = new string[]{"Manual","Automatic (Random)","Automatic (Advanced)"};
        	script.weatherTypeIndex = EditorGUI.Popup(new Rect(rt.x+margin+165, rt.y+25, setWidth, 18),"",script.weatherTypeIndex, weatherTypeOptions);


		    GUI.Label (new Rect (rt.x+margin+30, rt.y+45, 190, 15), new GUIContent("Link Clouds to Timer"));
			script.cloudLinkToTime = EditorGUI.Toggle(new Rect(rt.x+margin+10, rt.y+45, 30, 18), "", script.cloudLinkToTime);


			#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
		    	GUI.Label (new Rect (rt.x+margin+230, rt.y+45, 190, 15), new GUIContent("Use Legacy Clouds"));
				script.useLegacyClouds = EditorGUI.Toggle(new Rect(rt.x+margin+210, rt.y+45, 30, 18), "", script.useLegacyClouds);


				if (script.useLegacyClouds){
					GUI.contentColor = colorDisabled;
        			GUI.backgroundColor = colorDisabled;
				}
	         	GUI.Label (new Rect (rt.x+margin+10, rt.y+65, 180, 15), new GUIContent("Cloud Quality"));
	        	script.cloudQuality = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+65, setWidth, 18), "", script.cloudQuality,0.0f,10.0f);

	        	GUI.contentColor = colorEnabled;
        		GUI.backgroundColor = colorEnabled;
	        	
			#else
			    GUI.contentColor = colorDisabled;
        		GUI.backgroundColor = colorDisabled;
		    	GUI.Label (new Rect (rt.x+margin+230, rt.y+45, 190, 15), new GUIContent("Use Legacy Clouds"));
				script.useLegacyClouds = EditorGUI.Toggle(new Rect(rt.x+margin+210, rt.y+45, 30, 18), "", script.useLegacyClouds);
				GUI.contentColor = colorEnabled;
        		GUI.backgroundColor = colorEnabled;
			#endif


			if (script.weatherTypeIndex == 0){ //custom
				EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+450,387,34),divRevTex);

	         	GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 180, 15), new GUIContent("Clouds AltoStratus"));
	        	script.weather_cloudAltoStratusAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+95, setWidth, 18), "", script.weather_cloudAltoStratusAmt,0.0f,1.0f);
	        	
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+115, 180, 15), new GUIContent("Clouds Cirrus"));
	        	script.weather_cloudCirrusAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+115, setWidth, 18), "", script.weather_cloudCirrusAmt,0.0f,1.0f);

	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+135, 180, 15), new GUIContent("Clouds Cumulus"));
	        	script.weather_cloudCumulusAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+135, setWidth, 18), "", script.weather_cloudCumulusAmt,0.0f,1.0f);
	        	
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+155, 180, 15), new GUIContent("Overcast Amount"));
	        	script.weather_OvercastAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+155, setWidth, 18), "", script.weather_OvercastAmt,0.0f,1.0f);


	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+175, 180, 15), new GUIContent("Cloud Scale"));
	        	script.weather_cloudScale = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+175, setWidth, 18), "", script.weather_cloudScale,0.0f,20.0f);
	        	       
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+195, 180, 15), new GUIContent("Cloud Speed"));
	        	script.weather_cloudSpeed = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+195, setWidth, 18), "", script.weather_cloudSpeed,0.0f,1.0f);
	        	       


	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+225, 180, 15), new GUIContent("Rain Amount"));
	        	script.weather_RainAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+225, setWidth, 18), "", script.weather_RainAmt,0.0f,1.0f);

	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+245, 180, 15), new GUIContent("Snow Amount"));
	        	script.weather_SnowAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+245, setWidth, 18), "", script.weather_SnowAmt,0.0f,1.0f);

	         	GUI.Label (new Rect (rt.x+margin+10, rt.y+265, 180, 15), new GUIContent("Fog Amount"));
	        	script.weather_FogAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+265, setWidth, 18), "", script.weather_FogAmt,0.0f,1.0f);
	       	
	          	GUI.Label (new Rect (rt.x+margin+10, rt.y+285, 180, 15), new GUIContent("Fog Max Height"));
	        	script.weather_FogHeight = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+285, setWidth, 18), "", script.weather_FogHeight,0.0f,10000.0f);
	       	


	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+315, 180, 15), new GUIContent("Wind Amount"));
	        	script.weather_WindAmt = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+315, setWidth, 18), "", script.weather_WindAmt,0.0f,1.0f);
	        	
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+335, 180, 15), new GUIContent("Wind Direction"));
	        	script.weather_WindDir = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+335, setWidth, 18), "", script.weather_WindDir,0.0f,359.0f);
			


				GUI.Label (new Rect (rt.x+margin+10, rt.y+365, 180, 15), new GUIContent("Temperature"));
	        	script.weather_temperature = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+365, setWidth, 18), "", script.weather_temperature,0.0f,120.0f);


				GUI.Label (new Rect (rt.x+margin+10, rt.y+385, 180, 15), new GUIContent("Rainbow"));
	        	script.weather_rainbow = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+385, setWidth, 18), "", script.weather_rainbow,0.0f,1.0f);



				GUI.Label (new Rect (rt.x+margin+10, rt.y+415, 180, 15), new GUIContent("Lightning Amount"));
	        	script.weather_lightning = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+415, setWidth, 18), "", script.weather_lightning,0.0f,1.0f);

				GUI.Label (new Rect (rt.x+margin+10, rt.y+435, 180, 15), new GUIContent("Lightning Direction"));
	        	script.weather_lightningDir = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+435, setWidth, 18), "", script.weather_lightningDir,0.0f,359.0f);

				GUI.Label (new Rect (rt.x+margin+10, rt.y+455, 180, 15), new GUIContent("Lightning Range"));
	        	script.weather_lightningRange = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+455, setWidth, 18), "", script.weather_lightningRange,0.0f,180.0f);


				GUILayout.Space(450.0f);
			}

			if (script.weatherTypeIndex == 1){ //AUTO Simple
				EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+130,387,34),divRevTex);

			    //GUI.Label (new Rect (rt.x+margin+10, rt.y+45, 190, 15), new GUIContent("Link Clouds to Timer"));
        		//script.cloudLinkToTime = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+45, setWidth, 18), "", script.cloudLinkToTime);

				GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 180, 15), new GUIContent ("Next Random Pattern"));
				script.weather_forceUpdate = EditorGUI.Toggle(new Rect(rt.x+margin+165, rt.y+95, 60, 15), "", script.weather_forceUpdate);  
			
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+115, 180, 15), new GUIContent("Weather Pattern Lifetime"));
	        	script.weather_autoForecastTime = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+115, setWidth, 18), "", script.weather_autoForecastTime,0.0f,120.0f);
	        	
	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+135, 180, 15), new GUIContent("Weather Transition Speed"));
	        	script.weather_TransitionTime = EditorGUI.Slider(new Rect(rt.x+margin+165, rt.y+135, setWidth, 18), "", script.weather_TransitionTime,0.0f,60.0f);



				GUILayout.Space(130.0f);
			}

    		if (script.weatherTypeIndex == 2){ //AUTO Advanced
				EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+90,387,34),divRevTex);

	        	GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 380, 15), new GUIContent("Advanced Weather is currently disabled. Coming Soon."));

				GUILayout.Space(90.0f);
			}    	
        }
        GUILayout.Space(10.0f);
        
    






       //SOUND EFFECTS
        GUI.contentColor = colorEnabled;
        GUI.backgroundColor = colorEnabled;
        rt = GUILayoutUtility.GetRect(buttonText, buttonStyle);
        EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y,387,24),divTex);
        script.showIBL = EditorGUI.Foldout(new Rect (rt.x+margin+3, rt.y+5, 20, 20), script.showIBL, "");
        GUI.Label (new Rect (rt.x+margin+10, rt.y+5, 300, 20), new GUIContent ("SOUND EFFECTS"));
        
        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,0.0f);
		if (GUI.Button(new Rect(rt.x+margin+10, rt.y+5, 370, 20),"")) script.showIBL = !script.showIBL;
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1.0f);

        if (script.showIBL){


        	EditorGUI.DrawPreviewTexture(new Rect(rt.x+margin,rt.y+210,387,34),divRevTex);
			GUILayout.Space(10.0f);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+25, 190, 15), new GUIContent("Enable Sound FX"));
        	script.enableSoundFX = EditorGUI.Toggle(new Rect(rt.x+margin+135, rt.y+25, 25, 18), "", script.enableSoundFX);

			GUI.Label (new Rect (rt.x+margin+190, rt.y+25, 190, 15), new GUIContent("Adjust via Timescale"));
        	script.enableTimeAdjust = EditorGUI.Toggle(new Rect(rt.x+margin+325, rt.y+25, 25, 18), "", script.enableTimeAdjust);



        	if (!script.enableSoundFX){
        		GUI.contentColor = colorDisabled;
        		GUI.backgroundColor = colorDisabled;
        	}

			GUI.Label (new Rect (rt.x+margin+10, rt.y+45, 120, 15), new GUIContent ("Master Volume"));
			script.overallVolume = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+45, setWidth+20, 18), "", script.overallVolume,0.0f,1.0f);


			GUI.Label (new Rect (rt.x+margin+10, rt.y+75, 120, 15), new GUIContent ("Wind Volume"));
			script.volumeWind = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+75, setWidth-55, 18), "", script.volumeWind,0.0f,1.0f);
			script.audioWind = EditorGUI.ObjectField(new Rect(rt.x+margin+315, rt.y+75, 70, 18), script.audioWind, typeof(AudioClip), true) as AudioClip;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+95, 120, 15), new GUIContent ("Low Turbulence"));
			script.volumeTurb1 = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+95, setWidth-55, 18), "", script.volumeTurb1,0.0f,1.0f);
			script.audioTurb1 = EditorGUI.ObjectField(new Rect(rt.x+margin+315, rt.y+95, 70, 18), script.audioTurb1, typeof(AudioClip), true) as AudioClip;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+115, 120, 15), new GUIContent ("High Turbulence"));
			script.volumeTurb2 = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+115, setWidth-55, 18), "", script.volumeTurb2,0.0f,1.0f);
			script.audioTurb2 = EditorGUI.ObjectField(new Rect(rt.x+margin+315, rt.y+115, 70, 18), script.audioTurb2, typeof(AudioClip), true) as AudioClip;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+135, 120, 15), new GUIContent ("Rain Volume"));
			script.volumeRain = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+135, setWidth-55, 18), "", script.volumeRain,0.0f,1.0f);
			script.audioRain = EditorGUI.ObjectField(new Rect(rt.x+margin+315, rt.y+135, 70, 18), script.audioRain, typeof(AudioClip), true) as AudioClip;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+155, 120, 15), new GUIContent ("Thunder Volume"));
			script.volumeThunder = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+155, setWidth-55, 18), "", script.volumeThunder,0.0f,1.0f);

			GUI.Label (new Rect (rt.x+margin+10, rt.y+185, 120, 15), new GUIContent ("Day Ambient"));
			script.volumeAmbDay = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+185, setWidth-95, 18), "", script.volumeAmbDay,0.0f,1.0f);
			script.curveAmbDay24 = EditorGUI.CurveField(new Rect(rt.x+margin+272, rt.y+184, 45, 10), "", script.curveAmbDay24);
			script.curveAmbDayYR = EditorGUI.CurveField(new Rect(rt.x+margin+272, rt.y+193, 45, 10), "", script.curveAmbDayYR);
			script.audioAmbDay = EditorGUI.ObjectField(new Rect(rt.x+margin+325, rt.y+185, 60, 18), script.audioAmbDay, typeof(AudioClip), true) as AudioClip;

			GUI.Label (new Rect (rt.x+margin+10, rt.y+205, 120, 15), new GUIContent ("Night Ambient"));
			script.volumeAmbNight = EditorGUI.Slider(new Rect(rt.x+margin+135, rt.y+205, setWidth-95, 18), "", script.volumeAmbNight,0.0f,1.0f);
			script.curveAmbNight24 = EditorGUI.CurveField(new Rect(rt.x+margin+272, rt.y+204, 45, 10), "", script.curveAmbNight24);
			script.curveAmbNightYR = EditorGUI.CurveField(new Rect(rt.x+margin+272, rt.y+213, 45, 10), "", script.curveAmbNightYR);
			script.audioAmbNight = EditorGUI.ObjectField(new Rect(rt.x+margin+325, rt.y+205, 60, 18), script.audioAmbNight, typeof(AudioClip), true) as AudioClip;

	        GUI.contentColor = colorEnabled;
	        GUI.backgroundColor = colorEnabled;


        	GUILayout.Space(200.0f);
        }
        
        GUILayout.Space(10.0f);    
        






        GUILayout.Space(10.0f);
        
        
        
        
        
        GUI.contentColor = colorEnabled;
        GUI.backgroundColor = colorEnabled;
        
        

        if (EditorGUI.EndChangeCheck ()) {
			EditorUtility.SetDirty(target);
		}


    }
    
    


    
}