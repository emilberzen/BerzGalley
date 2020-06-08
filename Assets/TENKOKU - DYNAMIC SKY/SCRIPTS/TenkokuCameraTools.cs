using System;
using UnityEngine;
using System.Collections;

namespace Tenkoku.Core
{

	[ExecuteInEditMode]
    public class TenkokuCameraTools : MonoBehaviour
	{



	//Public Variables
	public enum tenCamToolType{sky,skybox,particles,none};
	public tenCamToolType cameraType;
	public RenderTexture renderTexDiff;
	public Material skyMaterial;


	//Private Variables
	private Tenkoku.Core.TenkokuModule tenkokuModuleObject;
	//private Renderer surfaceRenderer;
	private Camera cam;
	private Camera copyCam;
	private Matrix4x4 camMatrix;
	//private float updateTimer = 0.0f;
	//private int currResolution = 256;
	//private bool doUpdate = false;




	void Start () {

		if (Application.isPlaying){

			tenkokuModuleObject = GameObject.Find("Tenkoku DynamicSky").gameObject.GetComponent<Tenkoku.Core.TenkokuModule>() as Tenkoku.Core.TenkokuModule;
			cam = gameObject.GetComponent<Camera>() as Camera;
			if (tenkokuModuleObject != null){
				copyCam = tenkokuModuleObject.mainCamera.GetComponent<Camera>();
			}
		}

		//BuildTexture();
		//RenderSettings.skybox = skyMaterial;
	}




	//void Update () {
	//	if (!Application.isPlaying){
	//		RenderSettings.skybox = skyMaterial;
	//	}
	//}




	void LateUpdate () {

		if (!Application.isPlaying){
			if (skyMaterial != null){
				if (cameraType == tenCamToolType.sky){
					RenderSettings.skybox = skyMaterial;
				}
			}
		}


		if (Application.isPlaying){

			if (skyMaterial != null){
				if (cameraType == tenCamToolType.sky){
					if (RenderSettings.skybox == null){
						RenderSettings.skybox = skyMaterial;
					}
				}
			}


			//update camera tracking when necessary
			if (tenkokuModuleObject.mainCamera != null){
				copyCam = tenkokuModuleObject.mainCamera.GetComponent<Camera>();
				CameraUpdate();
			}
		}

	}




	void CameraUpdate () {

		if (copyCam != null && cam != null){

			//set camera settings
			cam.enabled = true;
			cam.transform.position = copyCam.transform.position;
			cam.transform.rotation = copyCam.transform.rotation;
			cam.projectionMatrix = copyCam.projectionMatrix;
			cam.fieldOfView = copyCam.fieldOfView;
			cam.renderingPath = copyCam.actualRenderingPath;
			cam.farClipPlane = copyCam.farClipPlane;


			if (renderTexDiff != null){

				

				//pass texture to shader
				//if (surfaceRenderer != null){
				//	if (cameraType == tenCamToolType.sky){
				//		surfaceRenderer.material.SetTexture("_Tenkoku_SkyTex2",renderTexDiff);
				//	}
				//}
				//pass texture to shader
				if (cameraType == tenCamToolType.skybox){
					cam.targetTexture = renderTexDiff;
					Shader.SetGlobalTexture("_Tenkoku_SkyBox",renderTexDiff);
				}


				if (cameraType == tenCamToolType.particles){
					cam.targetTexture = renderTexDiff;
					Shader.SetGlobalTexture("_Tenkoku_ParticleTex",renderTexDiff);
				}

			//} else {
				//BuildTexture();
			}

		}

	}

	//void BuildTexture(){

		//build texture
	//	renderTexDiff = new RenderTexture(64,64,16,RenderTextureFormat.DefaultHDR, RenderTextureReadWrite.Linear);
	//	renderTexDiff.useMipMap = true;
	//	renderTexDiff.generateMips = true;

	//	cam.targetTexture = renderTexDiff;

	//}



}
}