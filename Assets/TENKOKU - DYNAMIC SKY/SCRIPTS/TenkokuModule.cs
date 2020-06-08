using System;
using System.Collections.Generic;
using Tenkoku.Effects;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace Tenkoku.Core
{
    [ExecuteInEditMode]
    [Serializable]
    public class TenkokuModule : MonoBehaviour
    {
        public bool allowMultiLights = true;

        private float altAdjust = -1.0f;
        private int aM = 1;

        public float ambHorizonHeight = 1.0f;
        public float ambHorizonScale = 30.0f;
        private Color ambientBaseCol = Color.black;
        private Color ambientCloudCol = Color.black;

        //private var sunFlare : LensFlare;

        public Color ambientCol = Color.gray;
        private Color ambientGI = Color.black;
        private GameObject ambientObject;
        //bool starIsVisible = true;

        public float ambientShift;

        private TenkokuGlobalSound ambientSoundObject;
        private int aquarialStart;

        public float atmosphereDensity = 0.55f;
        private float atmosTime = 1.0f;
        public AudioClip audioAmbDay;
        public AudioClip audioAmbNight;
        public AudioClip audioRain;
        public AudioClip audioTurb1;
        public AudioClip audioTurb2;
        public AudioClip audioWind;
        private float aurAmt = -1.0f;
        public float auroraIntensity = 1.0f;

        bool auroraIsVisible = true;
        public float auroraLatitude = 1.0f;
        public float auroraSize = 1.4f;
        public float auroraSpeed = 0.5f;
        public int auroraTypeIndex;
        private float aurSpan = -1.0f;
        public bool autoDateSync;
        public bool autoTime;

        public bool autoTimeSync;

        private Color baseGAmbColor = new Color(0.38f, 0.6f, 0.69f, 0.7f);
        private Color baseHighlightCloudCol = new Color(0.19f, 0.19f, 0.19f, 1.0f);
        private Color baseHorizonCol = new Color(0.7f, 0.8f, 0.9f, 1.0f);
        private Color baseRainCol = new Color(0.65f, 0.75f, 0.75f, 1.0f);
        private Color baseRayCol = Color.black;
        private Color baseSkyCol = new Color(0.3f, 0.4f, 0.5f, 1.0f);
        private Color baseSnowCol = new Color(0.85f, 0.85f, 0.85f, 1f);
        private Color bgSCol = new Color(0f, 0f, 0f, 0f);

        private TenkokuCalculations calcComponent;
        private float calcTime;

        float calcTimeM;
        private GameObject callbackObject;
        public int cameraTypeIndex;

        private float cAmt;
        private float chanceOfRain = -1.0f;
        private float clampRes;

        public bool cloudLinkToTime;
        float cloudOverRot;

        GameObject cloudPlaneObject;

        private Vector3 cloudPosition = Vector3.zero;
        public float cloudQuality = 1f;

        float cloudRotSpeed = 0.2f;
        //float cloudSz = 1.0f;
        float cloudSc = 1.0f;
        private Color cloudSpeeds;
        GameObject cloudSphereObject;
        private float cloudStepTime;

        private Vector2 cloudTexScale = Vector2.zero;
        public Color colorAmbient = new Color(0f, 0f, 0f, 0.6f);
        public Color colorClouds = Color.white;

        public Color colorFog = new Color(0f, 0.25f, 1f, 0.25f);
        public Color colorHighlightClouds = Color.white;
        public Color colorHorizon = Color.white;
        public Color colorHorizonLow = Color.white;
        public Color colorMoon = Color.white;

        public Color colorOverlay = Color.white;

        public Texture2D colorRamp;
        private Color[] colors;
        private Color[] colorsAmb;
        public Color colorSky = new Color(1f, 1f, 1f, 0f);
        public Color colorSkyAmbient = Color.white;
        public Color colorSkyBase = Color.white;
        public Color colorSkyBaseLow = Color.white;
        public Color colorSkyboxGround = Color.black;
        public Color colorSkyboxMie = Color.white;
        private Color[] colorsLow;
        public Color colorSun = Color.white;
        public float countMinute;
        public float countMinuteMoon;
        public float countMinuteStar;

        public float countSecond;

        public float countSecondMoon;

        public float countSecondStar;
        private Vector3 cSphereSize;

        private float csSize;
        private float currClipDistance;
        private Vector2 currCoords = Vector2.zero;
        public int currentDay = 22;
        public int currentHour = 5;
        public int currentMinute = 45;
        public int currentMonth = 3;
        public int currentSecond;


        //Weather Variables
        public int currentWeatherTypeIndex = -1;
        public int currentYear = 2013;
        private float currIsLin = -1.0f;
        private int currTime;

        public AnimationCurve curveAmbDay24;
        public AnimationCurve curveAmbDayYR;
        public AnimationCurve curveAmbNight24;
        public AnimationCurve curveAmbNightYR;
        private float curveVal = 1.0f;
        private string dat;
        private string[] data;
        private string[] dataArray;


        private string dataString;
        //private int xP = 0;
        //private int ax = 0;
        private string dataUpdate;

        public float dayValue = 0.5f;
        private Color decodeColorAmbientcloud = Color.black;
        //private Color decodeColorSunray = Color.black;
        private Color decodeColorAmbientcolor = Color.black;
        private Color decodeColorAmbientGI = Color.black;
        private Color decodeColorColorcloud = Color.black;
        private Color decodeColorColorhorizon = Color.black;
        private Color decodeColorMoon = Color.black;
        private Color decodeColorSkyambient = Color.black;
        private Color decodeColorSkybase = Color.black;
        private Color decodeColorSun = Color.black;

        //flag variables
        //float currWeather_OvercastAmt = -1.0f;

        private Color[] DecodedColors;
        private Vector3 delta;
        private Vector2 dir = Vector2.zero;
        public float displayHour;


        //TIMER VARIABLES
        public string displayTime = "";
        bool doTransition;
        private bool doWeatherUpdate;
        public float ecldiff = -1.0f;
        private GameObject eclipseObject;
        private Vector3 eclipsePosition = Vector3.zero;
        private float eclipticoffset;
        private float eclipticStarAngle = -1.0f;
        public bool enableAutoAdvance = true;
        public bool enableDST;
        public bool enableFog;
        //bool _isForward = false;

        public bool enableIBL;

        public bool enableProbe = true;


        //sound variables
        public bool enableSoundFX = true;
        public bool enableTimeAdjust = true;
        private int endTime;
        private bool endTransition;
        private string eon = "";
        public float fadeDistance = 1.0f;
        public float fogAtmosphere = 0.2f;
        private TenkokuSkyBlur fogCameraBlur;
        private Camera fogCameraCam;
        private Color fogCol = Color.black;
        private Color fogColStart = new Color(.95f, .95f, .95f, .95f);
        public float fogDensity = 0.55f;

        //public int fogDisperse = 25;
        public float fogDispersion = 4f;
        public float fogDist = -1.0f;
        public float fogDistance = 0.0015f;
        private float fogFac = -1.0f;
        private float fogFull = -1.0f;
        private ParticleSystem fogSystem;
        private string func;
        private float fxUseLight = -1.0f;
        private Vector3 galaxyBasePosition = new Vector3(18.1f, 281.87f, 338.4f);
        private Vector3 galaxyBaseScale = new Vector3(1f, 0.92f, 0.98f);
        private Color galaxyColor = Color.black;
        public Texture galaxyCubeTex;
        public float galaxyIntensity = 1.0f;

        public float galaxyPos;
        private Vector3 galaxyPosition = Vector3.zero;
        private Vector3 galaxyScale = new Vector3(0.5f, 0.5f, 0.5f);

        public Texture galaxyTex;
        public int galaxyTexIndex;
        public int galaxyTypeIndex;
        private float galaxyVis = -1.0f;


        AudioClip[] globalSoundFile;
        Vector4[] globalSoundVolDay;
        Vector4[] globalSoundVolYear;
        private RaycastHit hit;
        public float horizonDensity = 2.0f;
        public float horizonDensityHeight = 0.34f;

        public float horizonHeight = 0.5f;
        public float horizonScale = 45.0f;

        public string hourMode = "";

        private int i;
        private float isLin;
        private int lastSecond;
        private string layerName;
        private float lDiff = -1.0f;


        public bool leapYear;
        private int length;
        private Vector3 lightClampVector = Vector3.one;
        //var cameraTypeOptions = new Array("Auto Select Camera","Manual Select Camera");
        //List<string> cameraTypeOptions = new List<string>{"Auto Select Camera","Manual Select Camera"};
        //static string[] cameraTypeOptions = new string[]{"Auto Select Camera","Manual Select Camera"};

        public int lightLayer = 2;
        public LayerMask lightLayerMask;


        private Light lightObjectNight;
        private Light lightObjectWorld;
        private string lightVals;
        private Quaternion look;

        public float lowHorizonHeight = 0.5f;
        public float lowHorizonScale = 1.0f;
        public Transform mainCamera;
        public Transform manualCamera;
        private Material materialObjectCloudSphere;
        private float mC;
        private Color mCol = new Color(0.25f, 0.33f, 0.36f, 1.0f);
        private Color mColMixCol = new Color(0.25f, 0.33f, 0.36f, 1.0f);
        private Color mDCol = Color.black;
        private Color medCol = new Color(0.3f, 0.3f, 0.3f, 1.0f);

        private Mesh mesh;
        private Mesh meshAmb;
        public float mieAmount = 1.0f;
        public float mieMnAmount = 1.0f;

        public float minimumHeight;
        private Color mixColor = Color.black;
        private float mMult;
        private float monthAddition;
        public int monthFac = 31;
        private int monthLength = -1;
        public float monthValue;

        private float moonApoSize = -1.0f;
        private Vector3 moonBasePosition = new Vector3(-0.51f, 0f, 0f);
        public float moonBright = 1.0f;
        private float moonCalcSize;
        public int moonDay;
        public float moonDayIntensity = 0.2f;
        private float moonFac;
        private Color moonFaceCol;
        public int moonHour;


        bool moonIsVisible = true;

        public float moonLightAmt;
        public float moonLightIntensity = 0.25f;
        public Transform moonlightObject;
        public int moonMinute;
        public int moonMonth;
        private GameObject moonObject;
        public float moonPhase;
        public float moonPos;
        private Vector3 moonPosition = Vector3.zero;
        public float moonRayIntensity = 1.0f;
        public float moonSat = 1.0f;
        private Vector3 moonScale = Vector3.one;

        public int moonSecond;
        private float moonsetFac;
        public float moonSize = 0.02f;
        private GameObject moonSphereObject;

        public Vector3 moonTime;
        public int moonTypeIndex;
        public float moonValue;
        public int moonYear;
        private Ray mRay;
        private Quaternion mres;
        private Matrix4x4 MV;
        public float nightBrightness = 0.4f;
        //private float prevDeltaTime = 0f;

        private Transform nightSkyLightObject;
        private Vector3 nightSkyPosition = Vector3.zero;
        public float overallVolume = 1.0f;
        private Color overcastCol;
        private Color particleCol = Color.black;
        private ParticleSystem particleObjectFog;

        private ParticleSystem particleObjectRainFog;
        private ParticleSystem particleObjectRainSplash;
        private Vector3 particlePosition = Vector3.zero;
        private Vector3 particleRayPosition = Vector3.zero;

        private Vector3 planeObjectScale = new Vector3(0.5f, 0.5f, 0.1f);

        public float planetIntensity = 1.0f;
        private ParticlePlanetHandler planetObjJupiter;
        private ParticlePlanetHandler planetObjMars;

        private ParticlePlanetHandler planetObjMercury;
        private ParticlePlanetHandler planetObjNeptune;
        private ParticlePlanetHandler planetObjSaturn;
        private ParticlePlanetHandler planetObjUranus;
        private ParticlePlanetHandler planetObjVenus;
        private Renderer planetRendererJupiter;
        private Renderer planetRendererMars;
        private Renderer planetRendererMercury;
        private Renderer planetRendererNeptune;
        private Renderer planetRendererSaturn;
        private Renderer planetRendererUranus;
        private Renderer planetRendererVenus;
        private Vector3 plJupiterPosition = Vector3.zero;
        private Vector3 plMarsPosition = Vector3.zero;

        private Vector3 plMercuryPosition = Vector3.zero;
        private Vector3 plNeptunePosition = Vector3.zero;
        private Vector3 plSaturnPosition = Vector3.zero;
        private Vector3 plUranusPosition = Vector3.zero;
        private Vector3 plVenusPosition = Vector3.zero;
        private int pos1;
        private int pos2;
        private float precFactor = -1.0f;
        private float precNudge = -1.0f;
        private float precRate = -1.0f;
        private float pVisFac = -1.0f;
        private int px;
        private Color rainCol = Color.black;
        private Color rainfogCol = Color.black;
        private float rainfogFac = -1.0f;
        private ParticleSystem rainFogSystem;
        private ParticleSystem rainSplashSystem;
        private ParticleSystem rainSystem;
        public int randSeed;

        private Color rayCol;
        public float reflectionProbeFPS = 1.0f;
        private Vector3 reflectionSize = new Vector3(100f, 500f, 100f);
        private float reflectionTimer;
        private Renderer renderObjectAurora;


        private Renderer renderObjectCloudPlane;
        private Renderer renderObjectCloudSphere;
        private Renderer renderObjectFog;
        private Renderer renderObjectGalaxy;

        private Renderer renderObjectMoon;

        private Renderer renderObjectRain;
        private Renderer renderObjectRainFog;
        private Renderer renderObjectRainSplash;
        private Renderer renderObjectSnow;
        private Color returnColor = Color.black;


        private float rOC;
        private Transform saveCamera;
        private float sC;
        private Color sCol = Color.black;
        private Color setAmbCol = Color.black;
        private Color setAmbientColor = Color.black;
        private float setAtmosphereDensity;

        public float setDay = 22000.0f;
        public int setHour = 5;
        public float setLatitude;
        public float setLongitude;
        public float setMonth = 22000.0f;
        public float setMoon = 22000.0f;
        //private Color setCloudFog1 = Color.black;
        private Color setOverallCol = new Color(0f, 0f, 0f, 0f);
        private ParticleSystem.Particle[] setParticles;

        public float setRotation = 180.0f;
        private Vector3 setScale = new Vector3(1f, 1f, 1f);
        private Vector3 setScale2 = Vector3.zero;
        private Color setSkyAmbient = Color.black;
        //private float setSkySize = 20.0f;
        private float setSkyUseSize = 1.0f;
        public float setStar = 22000.0f;
        private string setString = "format";
        private string setSun;


        //collect for GC
        private float setTime;
        float setTimeM;
        private float setTimeSpan = -1.0f;
        private int setTransHour;
        private int setTransMinute;
        private int setTransSecond;
        private float setTransVal;
        public int setTZOffset;
        private string setUpdate;
        public float setYear = 22000.0f;
        public bool showCelSet;

        public bool showConfig;
        public bool showConfigAtmos;

        public bool showConfigTime;
        public bool showConfigWeather;

        public bool showIBL;
        public bool showSounds;
        public bool showTimer = true;
        private Color skyAmbientCol = Color.black;
        public float skyBrightness = 1.0f;
        private Color skyHorizonCol = Color.black;
        private GameObject skyObject;
        private Color snowCol = Color.black;
        private ParticleSystem snowSystem;
        private Color splashCol = Color.black;
        private Ray sRay;

        private float sSDiv = -1.0f;
        private float starAngle = -1.0f;
        public int starDay;
        private GameObject starfieldObject;
        private GameObject starGalaxyObject;
        public int starHour;
        public float starIntensity = 1.0f;
        public int starMinute;
        public int starMonth;
        private Renderer starParticleSystem;

        public float starPos;

        private Vector3 starPosition = Vector3.zero;


        private ParticleStarfieldHandler starRenderSystem;


        public int starSecond;
        private Quaternion starTarget;
        private int startHour;
        private int startMinute;
        private int startSecond;
        private int startTime;
        public int starTypeIndex;
        public float starValue = 0.5f;
        public int starYear;

        int stepTime;
        int stepTimeM;
        private Vector3 sunBasePosition = new Vector3(-0.51f, 0f, 0f);
        public float sunBright = 1.0f;
        private float sunCalcSize = -1.0f;

        public GameObject sunlightObject;
        private GameObject sunObject;
        private Vector4 sunPos = Vector4.zero;
        private Vector3 sunPosition = Vector3.zero;
        public float sunRayIntensity = 1.0f;
        public float sunRayLength = 0.2f;

        private TenkokuSunShafts sunRayObject;
        public float sunSat = 1.0f;
        private Vector3 sunScale = Vector3.one;

        private float sunsetDegrees;

        //bool sunIsVisible = true;
        public float sunSize = 0.02f;
        public GameObject sunSphereObject;
        public int sunTypeIndex;
        private float sunVert;

        public float systemTime = 1f;
        DateTime sysTime;
        private Vector3 tempAngle = Vector3.zero;
        private Vector2 tempAngleVec2 = Vector2.zero;
        private Transform tempTrans;

        private ReflectionProbe tenkokuReflectionObject;
        //PUBLIC VARIABLES
        public string tenkokuVersionNumber = "";
        private WindZone tenkokuWindObject;
        [NonSerialized] public List<string> tenLayerMasks = new List<string>();


        public Random TenRandom;
        private int testMonth = -1;
        private int texPos;
        public float timeCompression = 100.0f;
        public AnimationCurve timeCurves;
        float timeLerp;
        float timeLerpM;
        private float timerCloudMod = -1.0f;
        private float timeVal;
        bool transitionCallback;
        GameObject transitionCallbackObject;
        float transitionDirection = 1.0f;
        float transitionDuration = 5.0f;
        string transitionStartTime = "";
        string transitionTargetDate;
        string transitionTargetTime;


        //Transition variables
        float transitionTime;
        private bool transSameDay = true;
        public bool use24Clock;
        private Color useAlpha = Color.black;
        public bool useAmbient = true;
        private Color useAmbientColor = Color.black;

        public bool useAutoTime;

        public Transform useCamera;
        private Camera useCameraCam;
        private Color useColorAmbient = new Color(0f, 0f, 0f, 0.6f);
        public float useDay;
        public float useHour;

        float useLatitude;
        public bool useLegacyClouds;
        public float useMinute;
        public float useMonth;
        private float useMult = -1.0f;
        private float useOvercast = -1.0f;
        private float usePoint;
        public float useSecond;
        float useSkyBright = 1.0f;

        public bool useSunRays = true;
        public float useTimeCompression = 100.0f;
        private Vector3 useVec = new Vector3(0f, 0.35f, 0.75f);
        public float useYear;
        private string[] values;
        private float vertical;
        private Vector3[] vertices;
        private Vector3[] verticesAmb;

        private Vector3[] verticesLow;
        public float volumeAmbDay = 1.0f;
        public float volumeAmbNight = 1.0f;
        public float volumeRain = 1.0f;
        public float volumeThunder = 1.0f;
        public float volumeTurb1 = 1.0f;
        public float volumeTurb2 = 1.0f;
        public float volumeWind = 1.0f;
        private float w_cloudAmtCumulus;
        private Vector4 w_cloudAmts;
        private float w_cloudTgtCumulus;
        private Vector4 w_cloudTgts;


        // auto weather variables
        private float w_isCloudy;
        private float w_isOvercast;
        private float w_lightningAmt;
        private float w_lightningTgt;
        private float w_overcastAmt;
        private float w_overcastTgt;
        private float w_rainAmt;
        private float w_rainTgt;
        private float w_snowAmt;
        private float w_snowTgt;
        private float w_windAmt;
        private float w_windCAmt;
        private float w_windCTgt;
        private float w_windDir;
        private float w_windDirTgt;
        private float w_windTgt;

        public float weather_autoForecastTime = 5.0f;
        public float weather_cloudAltAmt = 1.0f;

        public float weather_cloudAltoStratusAmt;
        public float weather_cloudCirrusAmt;
        private Vector4 weather_CloudCoords = Vector4.zero;

        public float weather_cloudCumulusAmt = 0.2f;
        public float weather_cloudScale = 0.5f;
        public float weather_cloudSpeed;
        public float weather_FogAmt;
        public float weather_FogHeight;
        public bool weather_forceUpdate;
        public float weather_lightning;
        public float weather_lightningDir = 110.0f;
        public float weather_lightningRange = 180.0f;

        public float weather_OvercastAmt;
        public float weather_PatternTime;
        public float weather_qualityCloud = 0.7f;
        public float weather_RainAmt;
        public float weather_rainbow;

        public bool weather_setAuto;
        public float weather_SnowAmt;

        public float weather_temperature = 75.0f;
        public float weather_TransitionTime = 1.0f;
        public float weather_WindAmt;
        private Vector2 weather_WindCoords = Vector2.zero;
        public float weather_WindDir;

        public int weatherTypeIndex;

        private Vector4 windPosition = Vector4.zero;
        private Vector3 windVector = Vector3.one;
        private Color WorldCol;
        private GameObject worldlightObject;
        private float yearDiv = 365.0f;
        public float yearValue;


        void Awake()
        {
            //GET CAMERA OBJECT
            if (Application.isPlaying)
                if (mainCamera == null)
                    mainCamera = Camera.main.transform;

            //set custom random generator instance
            randSeed = Environment.TickCount;
            TenRandom = new Random(randSeed);

            //set System Time
            //systemTime = randSeed * 1f;


            // Manually Set Execution Order
            // This ensures that Tenkoku runs after Update() in other functions which
            // prevents unintended timing issues.  This is intended to fix sky/camera
            // stuttering issues when used with some controllers and 3rd party assets.
#if UNITY_EDITOR
            var scriptName = typeof(TenkokuModule).Name;
            foreach (var monoScript in MonoImporter.GetAllRuntimeMonoScripts())
                if (monoScript.name == scriptName)
                {
                    if (MonoImporter.GetExecutionOrder(monoScript) != 1000)
                        MonoImporter.SetExecutionOrder(monoScript, 1000);
                    break;
                }
#endif
        }


        void Start()
        {
            //disconnect object from prefab connection
#if UNITY_EDITOR
            PrefabUtility.DisconnectPrefabInstance(gameObject);
#endif


            //turn off Antialiasing in forward mode
            if (mainCamera != null)
                if (mainCamera.gameObject.GetComponent<Camera>().renderingPath == RenderingPath.Forward)
                    QualitySettings.antiAliasing = 0;


            //get object references
            LoadObjects();

            //get color map
            UpdateColorMap();

            //get decoded colors
            LoadDecodedColors();

            //set project layer masks
            tenLayerMasks.Clear();
            for (i = 0; i < 32; i++)
            {
                layerName = LayerMask.LayerToName(i);
                tenLayerMasks.Add(layerName);
            }
        }


        void LoadObjects()
        {
            //GET TENKOKU OBJECTS
            calcComponent =
                gameObject.GetComponent<TenkokuCalculations>();

            //GET WINDZONE OBJECT
            tenkokuWindObject = GameObject.Find("Tenkoku_WindZone").GetComponent<WindZone>();


            //GET REFLECTION PROBE
            if (GameObject.Find("Tenkoku_ReflectionProbe") != null)
                tenkokuReflectionObject = GameObject.Find("Tenkoku_ReflectionProbe").GetComponent<ReflectionProbe>();


            //GET CELESTIAL OBJECTS
            worldlightObject = GameObject.Find("LIGHT_World");
            sunlightObject = GameObject.Find("LIGHT_Sun");
            sunSphereObject = GameObject.Find("SkySphereSun");
            sunObject = GameObject.Find("Sun");
            eclipseObject = GameObject.Find("sun_solareclipsefx");
            moonSphereObject = GameObject.Find("SkySphereMoon");
            moonObject = GameObject.Find("Moon");
            moonlightObject = GameObject.Find("LIGHT_Moon").transform;
            skyObject = GameObject.Find("SkySphere");

            starfieldObject = GameObject.Find("SkySphereStar");
            starGalaxyObject = GameObject.Find("SkySphereGalaxy");

            if (GameObject.Find("StarRenderSystem") != null)
            {
                starRenderSystem =
                    GameObject.Find("StarRenderSystem").GetComponent<ParticleStarfieldHandler>();
                starParticleSystem = GameObject.Find("StarRenderSystem").GetComponent<Renderer>();
            }

            if (GameObject.Find("planetMars"))
                planetObjMars =
                    GameObject.Find("planetMars").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetMercury"))
                planetObjMercury =
                    GameObject.Find("planetMercury").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetVenus"))
                planetObjVenus =
                    GameObject.Find("planetVenus").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetJupiter"))
                planetObjJupiter =
                    GameObject.Find("planetJupiter").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetSaturn"))
                planetObjSaturn =
                    GameObject.Find("planetSaturn").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetUranus"))
                planetObjUranus =
                    GameObject.Find("planetUranus").gameObject.GetComponent<ParticlePlanetHandler>();
            if (GameObject.Find("planetNeptune"))
                planetObjNeptune =
                    GameObject.Find("planetNeptune").gameObject.GetComponent<ParticlePlanetHandler>();

            if (planetObjSaturn != null)
                planetRendererSaturn = GameObject.Find("planetSaturn").GetComponent<Renderer>();
            if (planetObjJupiter != null)
                planetRendererJupiter = GameObject.Find("planetJupiter").GetComponent<Renderer>();
            if (planetObjNeptune != null)
                planetRendererNeptune = GameObject.Find("planetNeptune").GetComponent<Renderer>();
            if (planetObjUranus != null)
                planetRendererUranus = GameObject.Find("planetUranus").GetComponent<Renderer>();
            if (planetObjMercury != null)
                planetRendererMercury = GameObject.Find("planetMercury").GetComponent<Renderer>();
            if (planetObjVenus != null)
                planetRendererVenus = GameObject.Find("planetVenus").GetComponent<Renderer>();
            if (planetObjMars != null)
                planetRendererMars = GameObject.Find("planetMars").GetComponent<Renderer>();


            nightSkyLightObject = GameObject.Find("LIGHT_NightSky").transform;

            //GET SOUND OBJECT
            ambientSoundObject =
                GameObject.Find("AMBIENT_SOUNDS").gameObject.GetComponent<TenkokuGlobalSound>();

            //GET FLARE OBJECTS
            //sunFlare = sunObject.GetComponent(LensFlare);


            //GET WEATHER OBJECTS
            if (GameObject.Find("fxRain"))
                rainSystem = GameObject.Find("fxRain").gameObject.GetComponent<ParticleSystem>();
            if (GameObject.Find("fxRainFog"))
                rainFogSystem = GameObject.Find("fxRainFog").gameObject.GetComponent<ParticleSystem>();
            if (GameObject.Find("fxRainSplash"))
                rainSplashSystem = GameObject.Find("fxRainSplash").gameObject.GetComponent<ParticleSystem>();
            if (GameObject.Find("fxSnow"))
                snowSystem = GameObject.Find("fxSnow").gameObject.GetComponent<ParticleSystem>();
            if (GameObject.Find("fxFog"))
                fogSystem = GameObject.Find("fxFog").gameObject.GetComponent<ParticleSystem>();


            //GET AURORA OBJECTS
            renderObjectAurora = GameObject.Find("fxAuroraPlane").gameObject.GetComponent<Renderer>();
            renderObjectAurora.enabled = false;

            //GET COMPONENT REFERENCES
            lightObjectNight = nightSkyLightObject.GetComponent<Light>();
            lightObjectWorld = worldlightObject.GetComponent<Light>();


            renderObjectMoon = moonObject.GetComponent<Renderer>();
            renderObjectGalaxy = starGalaxyObject.GetComponent<Renderer>();

            if (Application.isPlaying)
            {
                if (rainSystem) renderObjectRain = rainSystem.GetComponent<Renderer>();
                if (rainSplashSystem) renderObjectRainSplash = rainSplashSystem.GetComponent<Renderer>();
                if (rainFogSystem) renderObjectRainFog = rainFogSystem.GetComponent<Renderer>();
                if (fogSystem) renderObjectFog = fogSystem.GetComponent<Renderer>();
                if (snowSystem) renderObjectSnow = snowSystem.GetComponent<Renderer>();

                if (rainFogSystem) particleObjectRainFog = rainFogSystem.GetComponent<ParticleSystem>();
                if (rainSplashSystem) particleObjectRainSplash = rainSplashSystem.GetComponent<ParticleSystem>();
                if (fogSystem) particleObjectFog = fogSystem.GetComponent<ParticleSystem>();
            }

            //Get Cloud Objects
            cloudPlaneObject = GameObject.Find("fxCloudPlane").gameObject;
            renderObjectCloudPlane = cloudPlaneObject.GetComponent<Renderer>();

#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
            cloudSphereObject = GameObject.Find("fxCloudSphere").gameObject;
            renderObjectCloudSphere = cloudSphereObject.GetComponent<Renderer>();
            materialObjectCloudSphere = renderObjectCloudSphere.sharedMaterial;
#endif

            fogCameraCam = GameObject.Find("Tenkoku_SkyFog").GetComponent<Camera>();
            fogCameraBlur =
                GameObject.Find("Tenkoku_SkyFog").GetComponent<TenkokuSkyBlur>();


            //set default cameras
            if (Application.isPlaying)
            {
                useCamera = null;
                useCameraCam = null;
            }
        }


        void HandleGlobalSound()
        {
            //--------------------------------------
            //---    CALCULATE MASTER VOLUME    ----
            //--------------------------------------
            overallVolume = Mathf.Clamp01(overallVolume);


            //---------------------------------------
            //---    CALCULATE ELEMENT VOLUME    ----
            //---------------------------------------
            ambientSoundObject.volWind = Mathf.Lerp(0.0f, 1.5f, weather_WindAmt)*volumeWind*overallVolume;
            ambientSoundObject.volTurb1 = Mathf.Lerp(0.0f, 2.0f, weather_WindAmt)*volumeTurb1*overallVolume;
            ambientSoundObject.volTurb2 = Mathf.Lerp(-1.0f, 1.5f, weather_WindAmt)*volumeTurb2*overallVolume;
            ambientSoundObject.volRain = volumeRain*(weather_RainAmt*1.5f)*overallVolume;


            //---------------------------------------------
            //---    CALCULATE AMBIENT AUDIO CURVES    ----
            //---------------------------------------------
            ambientSoundObject.volAmbNight = volumeAmbNight*curveAmbNight24.Evaluate(dayValue)*
                                             curveAmbNightYR.Evaluate(yearValue)*overallVolume;
            ambientSoundObject.volAmbDay = volumeAmbDay*curveAmbDay24.Evaluate(dayValue)*
                                           curveAmbDayYR.Evaluate(yearValue)*overallVolume;

            //-----------------------------------------
            //---    SEND DATA TO SOUND HANDLER    ----
            //-----------------------------------------
            ambientSoundObject.enableSounds = enableSoundFX;
            ambientSoundObject.enableTimeAdjust = enableTimeAdjust;

            if (audioWind != null)
                ambientSoundObject.audioWind = audioWind;
            else
                ambientSoundObject.audioWind = null;

            if (audioTurb1 != null)
                ambientSoundObject.audioTurb1 = audioTurb1;
            else
                ambientSoundObject.audioTurb1 = null;

            if (audioTurb2 != null)
                ambientSoundObject.audioTurb2 = audioTurb2;
            else
                ambientSoundObject.audioTurb2 = null;

            if (audioRain != null)
                ambientSoundObject.audioRain = audioRain;
            else
                ambientSoundObject.audioRain = null;

            if (audioAmbDay != null)
                ambientSoundObject.audioAmbDay = audioAmbDay;
            else
                ambientSoundObject.audioAmbDay = null;

            if (audioAmbNight != null)
                ambientSoundObject.audioAmbNight = audioAmbNight;
            else
                ambientSoundObject.audioAmbNight = null;
        }


        void Update()
        {
            if (!doTransition)
                useAutoTime = autoTime;

            // EDITOR MODE SPECIFIC
            if (!Application.isPlaying)
            {
                //get objects in editor mode
                LoadObjects();

                //rotate sun in editor mode
                sunlightObject.transform.LookAt(sunSphereObject.transform);
                worldlightObject.transform.localRotation = sunlightObject.transform.localRotation;
                lightObjectNight.transform.localRotation = moonObject.transform.localRotation;

                //set layers
                if (lightObjectWorld.gameObject.activeInHierarchy)
                {
                    lightObjectWorld.cullingMask = lightLayer;
                    lightObjectNight.cullingMask = lightLayer;
                }


                //recalculate time
                //TimeUpdate();
            }
        }


        void UpdatePositions()
        {
            // -------------------------------
            // --   SET SKY POSITIONING   ---
            // -------------------------------
            if (Application.isPlaying)
                if (useCamera != null)
                {
                    skyObject.transform.position = useCamera.transform.position;

                    //sky sizing based on camera
                    if (useCameraCam != null)
                        if (currClipDistance != useCameraCam.farClipPlane)
                        {
                            currClipDistance = useCameraCam.farClipPlane;

                            setSkyUseSize = currClipDistance/20.0f*2f;
                            setScale.x = setSkyUseSize;
                            setScale.y = setSkyUseSize;
                            setScale.z = setSkyUseSize;

                            setScale2.x = setSkyUseSize*0.9f;
                            setScale2.y = setSkyUseSize*0.9f;
                            setScale2.z = setSkyUseSize*0.9f;

                            sunSphereObject.transform.localScale = setScale2;
                            moonSphereObject.transform.localScale = setScale2;
                            starfieldObject.transform.localScale = setScale;
                            starRenderSystem.starDistance = currClipDistance;
                            starRenderSystem.setSize = starRenderSystem.baseSize*(currClipDistance/800f);
                            starGalaxyObject.transform.localScale = galaxyScale;
                        }
                }
        }


        void LateUpdate()
        {
            //if (Application.isPlaying){

            //SET VERSION NUMBER
            tenkokuVersionNumber = "1.1.3";


            //UPDATE SYSTEM TIMER
            timerCloudMod = 1f;
            if (cloudLinkToTime)
                if (!useAutoTime)
                {
                    timerCloudMod = 0.0f;
                }
                else
                {
                    cloudStepTime += Time.fixedDeltaTime*useTimeCompression;
                    if (cloudStepTime >= 1f) cloudStepTime = 0f;
                    if (lastSecond != currentSecond) cloudStepTime = 0f;
                }


            if (enableAutoAdvance)
                if (cloudLinkToTime)
                {
                    systemTime = calcComponent.UT*500f*weather_cloudSpeed;
                }
                else
                {
                    if (enableAutoAdvance) systemTime += timerCloudMod*0.0031f*weather_cloudSpeed;
                }
            Shader.SetGlobalFloat("_tenkokuTimer", systemTime);


            //UPDATE TENKOKU SYSTEM TIME
            TimeUpdate();


            // UPDATE DECODED COLOR MAP
            // This is only in edit mode and is used for convenience when editing color gradient texture.
            // Keep it on for live editing of color texture.  Turn off for improved in-editor performance.  
#if UNITY_EDITOR
            //UpdateColorMap();
#endif

            // UPDATE DECODED COLORS
            // This resamples the gradient texture map based on current time of day.
            LoadDecodedColors();


            // -----------------------------
            // --   GET CAMERA OBJECTS   ---
            // -----------------------------
            // This is put into the main update loop in order to have updating
            // in edit mode, while the scene is not playing.
            if (cameraTypeIndex == 0)
            {
                if (Camera.main != null)
                    mainCamera = Camera.main.transform;
                manualCamera = null;
            }
            if (cameraTypeIndex == 1)
                if (manualCamera != null)
                {
                    mainCamera = manualCamera;
                }
                else
                {
                    if (Camera.main != null)
                        mainCamera = Camera.main.transform;
                }

            //if (useCamera != mainCamera){ 
            //	useCamera = mainCamera;
            //}


            if ((useCamera != mainCamera) && (mainCamera != null))
            {
                useCamera = mainCamera;
                useCameraCam = useCamera.GetComponent<Camera>();

                MV = useCameraCam.worldToCameraMatrix.inverse;
                Shader.SetGlobalMatrix("_Tenkoku_CameraMV", MV);
                useCameraCam.clearFlags = CameraClearFlags.Skybox;
                sunRayObject = useCamera.GetComponent<TenkokuSunShafts>();
            }


            if (Application.isPlaying)
                if ((useCameraCam == null) && (mainCamera != null))
                    useCameraCam = useCamera.GetComponent<Camera>();

            //sunRayObject = useCamera.GetComponent<Tenkoku.Effects.TenkokuSunShafts>();


            // -----------------------------
            // --   TRACK CAMERA   ---
            // -----------------------------
            if (Application.isPlaying)
                UpdatePositions();

            //TURN OFF BUILT-IN FOG
            if (enableFog) RenderSettings.fog = false;

            //TURN OFF ANTI ALIASING
            if (enableFog) QualitySettings.antiAliasing = 0;

            //SYNC TIME TO SYSTEM
            if (Application.isPlaying)
                if (autoTimeSync || autoDateSync)
                {
                    sysTime = DateTime.Now;

                    if (autoTimeSync)
                    {
                        currentHour = Mathf.FloorToInt(sysTime.Hour);
                        currentMinute = Mathf.FloorToInt(sysTime.Minute);
                        currentSecond = Mathf.FloorToInt(sysTime.Second);
                        useTimeCompression = 1.0f;
                    }
                    if (autoDateSync)
                    {
                        currentYear = Mathf.FloorToInt(sysTime.Year);
                        currentMonth = Mathf.FloorToInt(sysTime.Month);
                        currentDay = Mathf.FloorToInt(sysTime.Day);
                    }
                }
                else
                {
                    if (!doTransition)
                        useTimeCompression = timeCompression*curveVal;
                }


            //SET LIGHTING LAYERS
            if (Application.isPlaying)
                if (lightObjectWorld.gameObject.activeInHierarchy)
                {
                    lightObjectWorld.cullingMask = lightLayer;
                    lightObjectNight.cullingMask = lightLayer;
                }


            // -------------------------------
            // --   SET REFLECTION PROBE   ---
            // -------------------------------
            if (tenkokuReflectionObject != null)
                if (enableProbe && Application.isPlaying)
                {
                    //enable probe during play mode
                    tenkokuReflectionObject.enabled = true;
                    tenkokuReflectionObject.mode = ReflectionProbeMode.Realtime;
                    tenkokuReflectionObject.refreshMode = ReflectionProbeRefreshMode.ViaScripting;

                    //set size to world size
                    if (useCameraCam != null)
                    {
                        reflectionSize.x = useCameraCam.farClipPlane*2f;
                        reflectionSize.y = useCameraCam.farClipPlane;
                        reflectionSize.z = useCameraCam.farClipPlane*2f;
                        tenkokuReflectionObject.size = reflectionSize;
                    }

                    //handle probe update when set to "scripting"
                    if (tenkokuReflectionObject.refreshMode ==
                        ReflectionProbeRefreshMode.ViaScripting)
                    {
                        reflectionTimer += Time.deltaTime;
                        if (reflectionTimer >= 1.0f/reflectionProbeFPS)
                        {
                            tenkokuReflectionObject.RenderProbe(null);
                            reflectionTimer = 0.0f;
                        }
                    }
                }
                else
                {
                    //disable probe update during scene-mode
                    tenkokuReflectionObject.mode = ReflectionProbeMode.Baked;
                    tenkokuReflectionObject.refreshMode = ReflectionProbeRefreshMode.OnAwake;
                }


            // --------------------
            // --   SET FLAGS   ---
            // --------------------
            //Set Linear Mode on Shader
            isLin = 0.0f;
            if (QualitySettings.activeColorSpace == ColorSpace.Linear) isLin = 1.0f;
            if (isLin != currIsLin)
            {
                currIsLin = isLin;
                Shader.SetGlobalFloat("_tenkokuIsLinear", isLin);
            }


            // --------------------------------
            // --   CALCULATE WEATHER   ---
            // --------------------------------
            if (weatherTypeIndex == 1)
            {
                //calculate weather pattern timer and initialize update
                doWeatherUpdate = false;
                weather_PatternTime += Time.deltaTime;

                //inherit variables
                if (currentWeatherTypeIndex != weatherTypeIndex)
                {
                    currentWeatherTypeIndex = weatherTypeIndex;
                    doWeatherUpdate = true;
                }

                //check for weather update
                if ((weather_PatternTime > weather_autoForecastTime*60.0f) && (weather_autoForecastTime >= 0.05f))
                    doWeatherUpdate = true;
                if (weather_forceUpdate) doWeatherUpdate = true;

                if (doWeatherUpdate)
                {
                    weather_forceUpdate = false;
                    weather_PatternTime = 0.0f;

                    //determine next random weather pattern
                    w_isCloudy = Mathf.Clamp(TenRandom.Next(-0.25f, 1.5f), 0.0f, 1.0f);

                    //record current weather
                    w_cloudAmts.y = weather_cloudAltoStratusAmt;
                    w_cloudAmts.z = weather_cloudCirrusAmt;
                    w_cloudAmtCumulus = weather_cloudCumulusAmt;
                    w_overcastAmt = weather_OvercastAmt;
                    w_windCAmt = weather_cloudSpeed;
                    w_windAmt = weather_WindAmt;
                    w_rainAmt = weather_RainAmt;
                    w_lightningAmt = weather_lightning;

                    //set clear weather default
                    w_cloudTgts = Vector4.zero;
                    w_cloudTgtCumulus = 0.0f;
                    w_overcastTgt = 0.0f;
                    w_windCTgt = 0.0f;
                    w_windTgt = 0.0f;
                    w_rainTgt = 0.0f;
                    w_lightningTgt = 0.0f;

                    //set clouds
                    w_cloudTgts.y = Mathf.Clamp(Mathf.Lerp(0.0f, TenRandom.Next(0.0f, 0.4f), w_isCloudy), 0.0f, 0.4f);
                        //AltoCumulus
                    w_cloudTgts.z = Mathf.Clamp(Mathf.Lerp(0.0f, TenRandom.Next(0.0f, 0.8f), w_isCloudy), 0.0f, 0.8f);
                        //Cirrus
                    w_cloudTgtCumulus = Mathf.Clamp(Mathf.Lerp(0.0f, TenRandom.Next(0.1f, 1.25f), w_isCloudy), 0.0f,
                        1.0f); // Cumulus
                    if (w_cloudTgtCumulus > 0.8f)
                        w_overcastTgt = Mathf.Clamp(Mathf.Lerp(0.0f, TenRandom.Next(-1.0f, 1.0f), w_isCloudy), 0.0f,
                            1.0f); // overcast amount

                    //set weather
                    chanceOfRain = Mathf.Clamp(TenRandom.Next(-1.0f, 1.0f), 0.0f, 1.0f);
                    w_rainTgt = Mathf.Lerp(0.0f, TenRandom.Next(0.2f, 1.4f), w_overcastTgt*chanceOfRain);
                    w_lightningTgt = Mathf.Lerp(0.0f, TenRandom.Next(0.0f, 0.6f), w_overcastTgt*chanceOfRain);

                    //set wind
                    w_windCTgt = TenRandom.Next(0.1f, 0.3f)*0.1f;
                    w_windTgt = TenRandom.Next(0.1f, 0.5f) + Mathf.Lerp(0.0f, 0.5f, weather_OvercastAmt);
                }

                //set weather systems
                weather_cloudAltoStratusAmt = Mathf.SmoothStep(w_cloudAmts.y, w_cloudTgts.y,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_cloudCirrusAmt = Mathf.SmoothStep(w_cloudAmts.z, w_cloudTgts.z,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_cloudCumulusAmt = Mathf.SmoothStep(w_cloudAmtCumulus, w_cloudTgtCumulus,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_OvercastAmt = Mathf.SmoothStep(w_overcastAmt, w_overcastTgt,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_cloudSpeed = Mathf.SmoothStep(w_windCAmt, w_windCTgt,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_WindAmt = Mathf.SmoothStep(w_windAmt, w_windTgt,
                    weather_PatternTime/(weather_TransitionTime*60.0f));
                weather_RainAmt = Mathf.SmoothStep(w_rainAmt, w_rainTgt,
                    weather_PatternTime/(weather_TransitionTime*60.0f)*2.0f);
                weather_lightning = Mathf.SmoothStep(w_lightningAmt, w_lightningTgt,
                    weather_PatternTime/(weather_TransitionTime*60.0f)*2.0f);

                //extra modifiers
                weather_RainAmt *= Mathf.Lerp(-1.0f, 1.0f, weather_OvercastAmt);
                weather_lightning *= Mathf.Lerp(-3.0f, 0.5f, weather_OvercastAmt);
                volumeAmbDay = Mathf.Lerp(1.0f, -2.0f, weather_OvercastAmt);
            }


            //Handle Temperature
            Shader.SetGlobalFloat("_Tenkoku_HeatDistortAmt",
                Mathf.Lerp(0.0f, 0.04f, Mathf.Clamp(weather_temperature - 90.0f, 0.0f, 120.0f)/30.0f));


            //Handle Rainbow Rendering
            rOC = 1.0f - Mathf.Clamp(weather_OvercastAmt*2f, 0.0f, 1.0f);
            Shader.SetGlobalFloat("_tenkoku_rainbowFac1",
                Mathf.Clamp(Mathf.Lerp(0.0f, 1.25f, weather_rainbow), 0.0f, rOC));
            Shader.SetGlobalFloat("_tenkoku_rainbowFac2",
                Mathf.Clamp(Mathf.Lerp(-2.0f, 1.0f, weather_rainbow), 0.0f, rOC));


            // --------------------
            // --   SET sOUND   ---
            // --------------------
            HandleGlobalSound();


            // --------------------------------
            // --   SET ECLIPTIC ROTATION   ---
            // --------------------------------
            //yAmt = ((calcComponent.yamt+calcComponent.day)/365.242f)*2.0f;
            //setEcliptic = Mathf.PingPong(yAmt*23.4f*2f,23.4f*2f);
            //setEcliptic = Mathf.Sin(((calcComponent.yamt+calcComponent.day)/(365.242f*0.15915f)))*15f;
            useLatitude = setLatitude;


            // ----------------------------
            // --   SET DAYLIGHT TIME   ---
            // ----------------------------
            calcTime =
                Vector3.Angle(sunObject.transform.position - skyObject.transform.position, skyObject.transform.up)/
                180.0f;
            calcTime = 1.0f - calcTime;
            setTime = calcTime*1.0f*colorRamp.width;
            stepTime = Mathf.FloorToInt(setTime);
            timeLerp = setTime - stepTime;


            // ----------------------------
            // --   SET MOONLIGHT TIME   ---
            // ----------------------------
            calcTimeM =
                Vector3.Angle(moonObject.transform.position - skyObject.transform.position, skyObject.transform.up)/
                180.0f;
            calcTimeM = 1.0f - calcTimeM;
            setTimeM = calcTimeM*1.0f*colorRamp.width;
            stepTimeM = Mathf.FloorToInt(setTimeM);
            timeLerpM = setTimeM - stepTimeM;


            // --------------
            // --   SUN   ---
            // --------------
            //if (sunTypeIndex == 2){
            //	sunIsVisible = false;
            //} else {
            //	sunIsVisible = true;
            //}

            sunSphereObject.gameObject.SetActive(true);
            sunObject.gameObject.SetActive(true);
            sunlightObject.gameObject.SetActive(true);

            //solar ecliptic movement
            calcComponent.CalculateNode(1); //sunstatic
            eclipticoffset = 0.0f;

            sunObject.transform.localPosition = sunBasePosition;
            sunSphereObject.transform.localPosition = Vector3.zero;

            //sun initial position and light
            //direction based on Solar Day Calculation
            calcComponent.CalculateNode(2); //sun
            sunPosition.x = 0.0f;
            sunPosition.y = 90f + calcComponent.azimuth + setRotation + 0.5f;
            sunPosition.z = -180.0f + calcComponent.altitude - 0.5f;
            sunSphereObject.transform.localEulerAngles = sunPosition;


            //sun apparent horizon size
            //due to optical atmospheric refraction as well as relative viusal proportion artifacts
            //at the horizon, the sun appears larger at the horizon than it does while overhead.
            //we're artificially changing the size of the sun to simulate this visual trickery.
            sSDiv = Mathf.Abs((sunSphereObject.transform.eulerAngles.z - 180.0f)/180.0f);
            if (sSDiv == 0.0f) sSDiv = 1.0f;
            if ((sSDiv < 0.5f) && (sSDiv > 0.0f)) sSDiv = 0.5f + (0.5f - sSDiv);
            sunCalcSize = sunSize +
                          Mathf.Lerp(0.0f, sunSize*Mathf.Lerp(-2.0f, 2.0f, sSDiv), Mathf.Lerp(-1.0f, 1.0f, sSDiv));

            //set explicit size of sun in Custom mode
            sunCalcSize = sunSize*0.5f;
            Shader.SetGlobalFloat("_Tenkoku_SunSize", sunSize + 0.005f);

            sunPos.x = sunObject.transform.position.x/360.0f;
            sunPos.y = sunObject.transform.position.y/360.0f;
            sunPos.z = sunObject.transform.position.z/360.0f;
            sunPos.w = 0.0f;
            Shader.SetGlobalColor("_Tenkoku_SunPos", sunPos);

            sunScale.x = sunCalcSize;
            sunScale.y = sunCalcSize;
            sunScale.z = sunCalcSize;
            sunObject.transform.localScale = sunScale;


            //solar parhelion
            //models the non-circular orbit of the earth.  The sun is not a constant distance
            //varying over the course of the year, this offsets the perceived sunset and
            //sunrise times from where they would be given a perfectly circular orbit.
            //--- no code yet ---

            //sun color
            colorSun = decodeColorSun;
            //sunColor = colorSun * (ambientCol.r);

            //sun lightsource, point toward camera
            if (useCamera != null)
                sunlightObject.transform.LookAt(useCamera.transform);


            // ---------------
            // --   MOON   ---
            // ---------------

            if (moonTypeIndex == 2)
                moonIsVisible = false;
            else
                moonIsVisible = true;

            if (!moonIsVisible)
                renderObjectMoon.enabled = false;
            else
                renderObjectMoon.enabled = true;


            //Moon Realistic Movement
            //moon position and light direction
            //rotate the moon around a spherical axis centered on the earth
            moonObject.transform.localPosition = moonBasePosition;
            moonSphereObject.transform.localPosition = Vector3.zero;


            //Moon Simple Movement
            calcComponent.moonPos = -1;
            if (moonTypeIndex == 1)
                calcComponent.moonPos = moonPos;

            //Calculate Moon Position
            calcComponent.CalculateNode(3);
            moonPosition.x = 0f;
            moonPosition.y = 90f + calcComponent.azimuth + setRotation + 0.15f;
            moonPosition.z = -180f + calcComponent.altitude - 0.5f;
            moonSphereObject.transform.localEulerAngles = moonPosition;


            //CALCULATE MOON LIGHT AND PHASE

            //Calculate Moon Light Coverage
            moonLightAmt = Quaternion.Angle(sunlightObject.transform.rotation, moonlightObject.transform.rotation)/
                           180.0f;

            // Manual Quaternion Angle Construction
            // We do this instead of Unity's Quaternion.Angle() function because we don't want it automatically clamped.
            mres = moonlightObject.transform.rotation*Quaternion.Inverse(sunlightObject.transform.rotation);
            moonPhase = Mathf.Acos(mres.w)*2.0f*57.2957795f/360f;


            //moon libration
            //as the moon travels across the lunar month it appears to wobbleback and
            //forth as it transits from one phase to another.  This is called "libration"
            //var monthAngle = (monthValue);
            //if (monthAngle == 0.0) monthAngle = 1.0;
            //if (monthAngle < 0.5 && monthAngle > 0.0) monthAngle = 0.5 + (0.5 - monthAngle);
            //moonObject.transform.localEulerAngles.z = 0.0-Mathf.SmoothStep(336.0,384.0,Mathf.Lerp(-1.0,1.0,moonClipAngle));


            //moon horizon size - turned off for now
            //due to optical atmospheric refraction as well as relative viusal proportion artifacts
            //at the horizon, the moon appears larger at the horizon than it does while overhead.
            //we're artificially changing the size of the moon to simulate this visual trickery.
            //also due to libration the moon also appears larger and smaller over the course of it's phase.
            //var mSDiv : float = Mathf.Abs(moonSphereObject.transform.eulerAngles.z/180.0);
            //if (mSDiv == 0.0) mSDiv = 1.0;
            //if (mSDiv < 0.5 && mSDiv > 0.0) mSDiv = 0.5 + (0.5 - mSDiv);


            //set explicit size of sun in Custom mode
            moonCalcSize = moonSize*1.21f;

            // moon apogee and perigree
            moonApoSize = Mathf.Lerp(1.2f, 0.82f, calcComponent.moonApogee);
            moonCalcSize *= moonApoSize;
            moonScale.x = moonCalcSize;
            moonScale.y = moonCalcSize;
            moonScale.z = moonCalcSize;
            moonObject.transform.localScale = moonScale;

            //moon color
            colorMoon = decodeColorMoon*1.0f;
            colorSkyAmbient = decodeColorSkyambient;

            //moon intensity
            moonLightIntensity = Mathf.Clamp(moonLightIntensity, 0.0f, 1.0f);


            //moon day fade
            // we apply an extra fade during daylight hours so the moon recedes into the sky.
            // it is still visible, yet it's visiblilty is superceded by the bright atmosphere.
            moonDayIntensity = Mathf.Clamp(moonDayIntensity, 0.0f, 1.0f);
            mDCol = Color.gray;
            mDCol.a = Mathf.Lerp(1.0f, moonDayIntensity, colorSkyAmbient.r);

            renderObjectMoon.sharedMaterial.SetColor("_Color",
                Color.Lerp(mDCol, ambientCol*colorSun, ambientCol.r)*mDCol);
            renderObjectMoon.sharedMaterial.SetColor("_AmbientTint", ambientCol);

            //moon light intensity
            //setMCol = moonWorlIntensity;
            renderObjectMoon.sharedMaterial.SetColor("_AmbientTint", colorSkyAmbient);

            //set moon face light color
            moonFaceCol = colorMoon*(1.0f - decodeColorAmbientcolor.r);
            Shader.SetGlobalColor("Tenkoku_MoonLightColor", moonFaceCol);

            //Get moon/horizon atitude
            sunsetDegrees = 20.0f;
            moonFac = nightSkyLightObject.transform.eulerAngles.x;
            if (moonFac > 90.0f) moonFac = 0.0f;
            moonsetFac = Mathf.Clamp01(Mathf.Lerp(-0.5f, 1.0f, Mathf.Clamp01(moonFac/sunsetDegrees)));
            Shader.SetGlobalFloat("Tenkoku_MoonHFac", moonsetFac);


            // ---------------------------------
            // --   LIGHTNING HANDLING   ---
            // ---------------------------------

            //SET SKY CAMERA POSITIONS
            if (useCamera != null)
            {
                //set global shader for camera forward direction
                Shader.SetGlobalVector("Tenkoku_Vec_CameraFwd", useCamera.transform.forward);
                Shader.SetGlobalVector("Tenkoku_Vec_SunFwd", -sunlightObject.transform.forward);
                Shader.SetGlobalVector("Tenkoku_Vec_MoonFwd", -moonlightObject.transform.forward);
            }


            // ------------------
            // --   PLANETS   ---
            // ------------------
            useMult = 1.0f;
            pVisFac = Mathf.Lerp(0.75f, 0.1f, colorSkyAmbient.r);

            if (Application.isPlaying)
            {
                //enable visibility
                if (planetRendererSaturn != null) planetRendererSaturn.enabled = true;
                if (planetRendererJupiter != null) planetRendererJupiter.enabled = true;
                if (planetRendererNeptune != null) planetRendererNeptune.enabled = true;
                if (planetRendererUranus != null) planetRendererUranus.enabled = true;
                if (planetRendererMercury != null) planetRendererMercury.enabled = true;
                if (planetRendererVenus != null) planetRendererVenus.enabled = true;
                if (planetRendererMars != null) planetRendererMars.enabled = true;


                //set planetary positions
                if (planetObjMercury)
                {
                    calcComponent.CalculateNode(4); //mercury
                    planetObjMercury.transform.localPosition = Vector3.zero;
                    plMercuryPosition.x = 0f;
                    plMercuryPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plMercuryPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjMercury.transform.localEulerAngles = plMercuryPosition;
                    tempTrans = planetObjMercury.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjMercury.planetOffset = tempTrans.localPosition;
                    planetObjMercury.planetVis = pVisFac*planetIntensity;
                }

                if (planetObjVenus)
                {
                    calcComponent.CalculateNode(5); //venus
                    planetObjVenus.transform.localPosition = Vector3.zero;
                    plVenusPosition.x = 0f;
                    plVenusPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plVenusPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjVenus.transform.localEulerAngles = plVenusPosition;
                    tempTrans = planetObjVenus.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjVenus.planetOffset = tempTrans.localPosition;
                    planetObjVenus.planetVis = Mathf.Clamp(pVisFac, 0.1f, 1.0f)*planetIntensity;
                }

                if (planetObjMars)
                {
                    calcComponent.CalculateNode(6); //mars
                    planetObjMars.transform.localPosition = Vector3.zero;
                    plMarsPosition.x = 0f;
                    plMarsPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plMarsPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjMars.transform.localEulerAngles = plMarsPosition;
                    tempTrans = planetObjMars.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjMars.planetOffset = tempTrans.localPosition;
                    planetObjMars.planetVis = Mathf.Clamp(pVisFac, 0.02f, 1.0f)*planetIntensity;
                }

                if (planetObjJupiter)
                {
                    calcComponent.CalculateNode(7); //jupiter
                    planetObjJupiter.transform.localPosition = Vector3.zero;
                    plJupiterPosition.x = 0f;
                    plJupiterPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plJupiterPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjJupiter.transform.localEulerAngles = plJupiterPosition;
                    tempTrans = planetObjJupiter.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjJupiter.planetOffset = tempTrans.localPosition;
                    planetObjJupiter.planetVis = Mathf.Clamp(pVisFac, 0.05f, 1.0f)*planetIntensity;
                }

                if (planetObjSaturn)
                {
                    calcComponent.CalculateNode(8); //saturn
                    planetObjSaturn.transform.localPosition = Vector3.zero;
                    plSaturnPosition.x = 0f;
                    plSaturnPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plSaturnPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjSaturn.transform.localEulerAngles = plSaturnPosition;
                    tempTrans = planetObjSaturn.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjSaturn.planetOffset = tempTrans.localPosition;
                    planetObjSaturn.planetVis = pVisFac*planetIntensity;
                }

                if (planetObjUranus)
                {
                    calcComponent.CalculateNode(9); //uranus
                    planetObjUranus.transform.localPosition = Vector3.zero;
                    plUranusPosition.x = 0f;
                    plUranusPosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plUranusPosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjUranus.transform.localEulerAngles = plUranusPosition;
                    tempTrans = planetObjUranus.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjUranus.planetOffset = tempTrans.localPosition;
                    planetObjUranus.planetVis = pVisFac*planetIntensity;
                }

                if (planetObjNeptune)
                {
                    calcComponent.CalculateNode(10); //neptune
                    planetObjNeptune.transform.localPosition = Vector3.zero;
                    plNeptunePosition.x = 0f;
                    plNeptunePosition.y = 90.0f + calcComponent.azimuth + setRotation;
                    plNeptunePosition.z = -180.0f + calcComponent.altitude - 0.5f;
                    planetObjNeptune.transform.localEulerAngles = plNeptunePosition;
                    tempTrans = planetObjNeptune.transform;
                    tempTrans.localPosition = Vector3.zero;
                    tempTrans.Translate(useVec*(eclipticoffset*useMult), Space.World);
                    planetObjNeptune.planetOffset = tempTrans.localPosition;
                    planetObjNeptune.planetVis = pVisFac*planetIntensity;
                }
            }


            // ----------------
            // --   STARS   ---
            // ----------------

            //SIDEAREAL DAY CALCULATION
            //The sideareal day is more accurate than the solar day, and is
            //the actual determining calculation for the passage of a full year.
            if ((starTypeIndex == 0) || (starTypeIndex == 2))
            {
                starAngle = -1.0f;
                starTarget = Quaternion.Euler(useLatitude, 183.0f, -starAngle);
                starfieldObject.transform.rotation = starTarget;
                starPosition.x = starfieldObject.transform.eulerAngles.x;
                starPosition.y = starfieldObject.transform.eulerAngles.y;
                starPosition.z = -(calcComponent.UT/23.99972f*360.0f) - (setLongitude + 95.0f) -
                                 360.0f*Mathf.Abs(Mathf.Floor(calcComponent.day/365.25f) - calcComponent.day/365.25f);

                //CALCULATE PRECESSIONAL MOVEMENT
                //precessional movement occurs at a rate of 1 degree every 71.666 years, thus each precessional epoch
                //takes up exactly 32 degrees on the spherical celestial star plane. this is calculated on the
                //assumption that the Aquarial age begins in the year 2600ad.  if you disagree and would like to
                //see other aquarian start calibrations (year 2148 for example), simply change the 'aquarialStart' variable.
                aquarialStart = 2600;
                precRate = 71.6f;
                precNudge = 258.58f; //this value simply helps set the exact position of the star sphere.
                precFactor = aquarialStart/precRate*aquarialStart + (aquarialStart - currentYear)/precRate +
                             precNudge;
                starPosition.z = starPosition.z - precFactor - 4.0f;
            }
            else
            {
                starPosition.x = starfieldObject.transform.eulerAngles.x;
                starPosition.y = starfieldObject.transform.eulerAngles.y;
                starPosition.z = starPos;
            }

            //Set final star position
            starPosition.y = setRotation;
            starfieldObject.transform.eulerAngles = starPosition;


            //solar ecliptic movement
            eclipticStarAngle = starValue;
            if (eclipticStarAngle == 0.0) eclipticStarAngle = 1.0f;
            if ((eclipticStarAngle < 0.5f) && (eclipticStarAngle > 0.0f))
                eclipticStarAngle = 0.5f + (0.5f - eclipticStarAngle);
            eclipticStarAngle += 1.35f;


            //GALAXY / Skybox Rendering
            renderObjectGalaxy.enabled = true;
            //useGalaxyIntensity = galaxyIntensity;
            if ((galaxyTypeIndex == 2) && (starTypeIndex == 2))
            {
                renderObjectGalaxy.enabled = false;
            }
            else
            {
                renderObjectGalaxy.enabled = true;

                // Realistic Galaxy Rotation (match star positions)
                if ((galaxyTypeIndex == 0) || (galaxyTypeIndex == 2))
                {
                    starGalaxyObject.transform.localEulerAngles = galaxyBasePosition;
                    starGalaxyObject.transform.localScale = galaxyBaseScale;
                }

                // Custom Galaxy Rotation
                if (galaxyTypeIndex == 1)
                {
                    galaxyPosition.x = starPosition.x;
                    galaxyPosition.y = starPosition.y;
                    galaxyPosition.z = galaxyPos;
                    starGalaxyObject.transform.localEulerAngles = galaxyPosition;
                }
            }
            galaxyColor = Color.white;
            galaxyVis = (1.0f - colorSkyAmbient.r*1.0f)*galaxyIntensity;

            renderObjectGalaxy.sharedMaterial.SetFloat("_GIntensity", galaxyVis);
            renderObjectGalaxy.sharedMaterial.SetColor("_Color", galaxyColor);

            renderObjectGalaxy.sharedMaterial.SetFloat("_useGlxy", galaxyTypeIndex*1.0f);
            renderObjectGalaxy.sharedMaterial.SetTexture("_GTex", galaxyTex);

            renderObjectGalaxy.sharedMaterial.SetFloat("_useCube", galaxyTexIndex*1.0f);
            renderObjectGalaxy.sharedMaterial.SetTexture("_CubeTex", galaxyCubeTex);

            renderObjectGalaxy.sharedMaterial.SetFloat("_useStar", starTypeIndex*1.0f);
            renderObjectGalaxy.sharedMaterial.SetFloat("_SIntensity", starIntensity);


            if (starRenderSystem != null)
                if (starTypeIndex == 2)
                {
                    if (starParticleSystem.enabled) starParticleSystem.enabled = false;
                }
                else
                {
                    if (!starParticleSystem.enabled) starParticleSystem.enabled = true;
                    starRenderSystem.starBrightness.a = starIntensity;
                }


            // --------------
            // --   SKY   ---   
            //---------------                                                                                                                                                                                                                                                  
            //get ramp colors
            ambientShift = Mathf.Clamp(ambientShift, 0.0f, 1.0f);
            colorSkyBase = decodeColorSkybase;
            ambientCol = decodeColorSkyambient;
            ambientCloudCol = decodeColorAmbientcloud;

            setSkyAmbient = colorSkyAmbient;
            setSkyAmbient.r += ambientShift;
            setSkyAmbient.g += ambientShift;
            setSkyAmbient.b += ambientShift;

            useAlpha.r = 1f;
            useAlpha.g = 1f;
            useAlpha.b = 1f;
            useAlpha.a = 1.0f - setSkyAmbient.r;

            setAmbCol = useAlpha;
            setAmbCol.a = useAlpha.a*0.75f;
            setAmbCol.a = useAlpha.a*1.5f;
            if (setAmbCol.a > 1.0f) setAmbCol.a = 1.0f;

            colorSkyBaseLow = colorSkyBase;
            colorHorizonLow = colorHorizon;

            colorSkyBase = colorSkyBase*0.8f;
            colorHorizon = Color.Lerp(colorHorizon, colorSkyBase, 0.9f)*1.1f;


            // ------------------
            // --   AMBIENT   ---   
            //-------------------
            mixColor = colorSun;
            setAmbientColor.r = 1.0f - mixColor.r;
            setAmbientColor.g = 1.0f - mixColor.g;
            setAmbientColor.b = 1.0f - mixColor.b;

            useAmbientColor = Color.Lerp(Color.Lerp(colorSkyBase, setAmbientColor, 0.7f), Color.black, 0.12f);
            useAmbientColor = Color.Lerp(useAmbientColor, medCol, 0.5f)*colorSkyAmbient;
            useAmbientColor *= sunBright*skyBrightness;

            //HORIZON
            colorHorizon = decodeColorColorhorizon*1.2f;

            if (useAmbient)
            {
                useAmbientColor = decodeColorAmbientcolor;
                useColorAmbient = colorAmbient;

                useColorAmbient.a = colorAmbient.a*Mathf.Lerp(1.0f, 0.0f, weather_OvercastAmt*4f);
                useAmbientColor = Color.Lerp(useAmbientColor, Color.gray, weather_OvercastAmt*3f);

                useAmbientColor = Color.Lerp(useAmbientColor, useAmbientColor*colorAmbient, useColorAmbient.a);

                // the original intended behavior.
                RenderSettings.ambientMode = AmbientMode.Trilight;
                var skyAmb = decodeColorColorhorizon*0.6f;
                skyAmb = Color.Lerp(skyAmb, Color.white*Mathf.Lerp(0.25f, 1.75f, nightBrightness*setSkyAmbient.r),
                    weather_OvercastAmt*2f);

                var gAmb = Color.Lerp(
                    baseGAmbColor*(nightBrightness*0.5f),
                    useAmbientColor,
                    setSkyAmbient.r);

                var sAmb = skyAmb*Mathf.Lerp(
                                 nightBrightness + Mathf.Lerp(0.25f, 1.75f, nightBrightness),
                                 1f,
                                 setSkyAmbient.r);

                var eAmb = Color.Lerp(
                    RenderSettings.ambientGroundColor,
                    RenderSettings.ambientSkyColor,
                    0.25f);


                RenderSettings.ambientSkyColor = Color.Lerp(sAmb, sAmb*useColorAmbient, useColorAmbient.a);
                RenderSettings.ambientEquatorColor = Color.Lerp(eAmb, eAmb*useColorAmbient,
                    useColorAmbient.a);
                RenderSettings.ambientGroundColor = Color.Lerp(gAmb, gAmb*useColorAmbient, useColorAmbient.a);


                RenderSettings.ambientIntensity = 1.0f;
            }


            // ----------------------------------
            // --      LENS FLARE EFFECTS       --
            // -----------------------------------

            //set default flare
            //sunFlare.color = Color.white;

            //fade flare based on overcast
            //sunFlare.color = Color.Lerp(sunFlare.color,new Color(0f,0f,0f,0f),weather_OvercastAmt*2.0f);
            //sunFlare.brightness = Mathf.Lerp(1.0f,0.0f,weather_OvercastAmt*2.0);

            //fade flare based on gamma
            //sunFlare.color *= Mathf.Lerp(0.25f,1.0f,isLin);
            //sunFlare.brightness *= Mathf.Lerp(0.25f,1.0f,isLin);

            //fade flare based on brightness
            //sunFlare.color *= Mathf.Lerp(0.0f,1.0f,sunBright*0.6f);
            //sunFlare.brightness *= Mathf.Lerp(0.0f,1.0f,sunBright*0.6f);

            //fade flare based on occlusion
            //(soon)


            // --------------------------------
            // --      WEATHER EFFECTS       --
            // --------------------------------
            if (Application.isPlaying)
            {
                //manage particle systems
                if (rainSystem != null)
                {
#if UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
					rainEmission = rainSystem.emission;
					rainEmission.enabled = true;
					rainCurve.constant = Mathf.Lerp(2,5000,weather_RainAmt);
					rainEmission.rate = rainCurve;
					if (rainSystem.particleCount <= 10){
						renderObjectRain.enabled = false;
					} else {
						renderObjectRain.enabled = true;
					}
					//add force
					rainForces = rainSystem.forceOverLifetime;
					rainForces.enabled = true;
					rainCurveForceX.constant = -weather_WindCoords.x * (weather_WindAmt*46f);
					rainForces.x = rainCurveForceX;
					rainCurveForceY.constant = weather_WindCoords.y * (weather_WindAmt*46f);
					rainForces.y = rainCurveForceY;
				#else
                    renderObjectRain.enabled = true;
                    rainSystem.enableEmission = true;
                    rainSystem.emissionRate = Mathf.FloorToInt(Mathf.Lerp(0, 5000, weather_RainAmt));
#endif
                }

                if (rainFogSystem != null)
                {
#if UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
					rainFogEmission = rainFogSystem.emission;
					rainFogEmission.enabled = true;
					rainCurveFog.constant = Mathf.Lerp(2,800,weather_RainAmt);
					rainFogEmission.rate = rainCurveFog;
					if (rainFogSystem.particleCount <= 20){
						renderObjectRainFog.enabled = false;
					} else {
						renderObjectRainFog.enabled = true;
					}
					//add force
					rainFogForces = rainFogSystem.forceOverLifetime;
					rainFogForces.enabled = true;
					rainCurveFogForceX.constant = -weather_WindCoords.x * (weather_WindAmt*4f);
					rainFogForces.x = rainCurveFogForceX;
					rainCurveFogForceY.constant = weather_WindCoords.y * (weather_WindAmt*4f);
					rainFogForces.y = rainCurveFogForceY;
				#else
                    rainFogSystem.enableEmission = true;
                    renderObjectRainFog.enabled = true;
                    rainFogSystem.emissionRate = Mathf.FloorToInt(Mathf.Lerp(0, 800, weather_RainAmt));
#endif
                }


                if (rainSplashSystem != null)
                {
#if UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
					splashEmission = rainSplashSystem.emission;
					splashEmission.enabled = true;
					splashCurve.constant = Mathf.Lerp(50,800,weather_RainAmt);
					splashEmission.rate = splashCurve;
					if (rainSplashSystem.particleCount <= 10){
						renderObjectRainSplash.enabled = false;
					} else {
						renderObjectRainSplash.enabled = true;
					}
				#else
                    rainSplashSystem.enableEmission = true;
                    renderObjectRainSplash.enabled = true;
                    rainSplashSystem.emissionRate = Mathf.FloorToInt(Mathf.Lerp(0, 800, weather_RainAmt));
#endif
                }

                if (fogSystem != null)
                {
#if UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
					fogEmission = fogSystem.emission;
					fogEmission.enabled = true;
					fogCurve.constant = Mathf.Lerp(2,1200,weather_FogAmt);
					fogEmission.rate = fogCurve;
					if (fogSystem.particleCount <= 10){
						renderObjectFog.enabled = false;
					} else {
						renderObjectFog.enabled = true;
					}
					//add force
					fogForces = fogSystem.forceOverLifetime;
					fogForces.enabled = true;
					fogCurveForceX.constant = -weather_WindCoords.x * (weather_WindAmt*6);
					fogForces.x = fogCurveForceX;
					fogCurveForceY.constant = weather_WindCoords.y * (weather_WindAmt*6);
					fogForces.y = fogCurveForceY;
				#else
                    fogSystem.enableEmission = true;
                    renderObjectFog.enabled = true;
                    fogSystem.emissionRate = Mathf.FloorToInt(Mathf.Lerp(0, 1200, weather_FogAmt));
#endif
                }

                if (snowSystem != null)
                {
#if UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
					snowEmission = snowSystem.emission;
					snowEmission.enabled = true;
					snowCurve.constant = Mathf.Lerp(2,1500,weather_SnowAmt);
					snowEmission.rate = snowCurve;
					if (snowSystem.particleCount <= 10){
						renderObjectSnow.enabled = false;
					} else {
						renderObjectSnow.enabled = true;
					}
					//add force
					snowPosition.x = snowSystem.transform.localPosition.x;
					snowPosition.y = Mathf.Lerp(0.24f,0.14f,weather_WindAmt);
					snowPosition.z = snowSystem.transform.localPosition.z;
					snowSystem.transform.localPosition = snowPosition;
					snowForces = snowSystem.forceOverLifetime;
					snowForces.enabled = true;
					snowCurveForceX.constant = -weather_WindCoords.x * (weather_WindAmt*2f);
					snowForces.x = snowCurveForceX;
					snowCurveForceY.constant = weather_WindCoords.y * (weather_WindAmt*2f);
					snowForces.y = snowCurveForceY;
				#else
                    snowSystem.enableEmission = true;
                    renderObjectSnow.enabled = true;
                    snowSystem.emissionRate = Mathf.FloorToInt(Mathf.Lerp(0, 2000, weather_SnowAmt));
#endif
                }
            }


            //Overcast Calculations
            useOvercast = Mathf.Clamp(Mathf.Lerp(-1.0f, 1.0f, weather_OvercastAmt), 0.0f, 1.0f);
            colorSkyBase = Color.Lerp(colorSkyBase, baseSkyCol*ambientCol.r, useOvercast);
            colorHorizon = Color.Lerp(colorHorizon, baseHorizonCol*ambientCol.r, useOvercast);


            //apply color and lighting
            //fxUseLight = 0.8f;//Mathf.Clamp(4.0f,0.1f,0.8f);
            lDiff = (lightObjectWorld.intensity - 0.0f)/0.68f;
            lDiff += Mathf.Lerp(0.0f, 0.8f, useOvercast);
            fxUseLight = Mathf.Lerp(0.0f, lightObjectWorld.intensity, lDiff);

            rainCol = baseRainCol*fxUseLight;
            rainCol.a = 0.12f;
            if (renderObjectRainSplash)
                renderObjectRain.sharedMaterial.SetColor("_TintColor", rainCol*Mathf.Lerp(0.35f, 1.0f, ambientCol.r));

            splashCol = Color.white*fxUseLight;
            splashCol.a = 0.65f;
            if (renderObjectRainSplash) renderObjectRainSplash.sharedMaterial.SetColor("_TintColor", splashCol);

            rainfogCol = Color.white*fxUseLight;
            rainfogFac = Mathf.Lerp(0.004f, 0.025f, Mathf.Clamp01((weather_RainAmt - 0.5f)*2.0f));
            rainfogCol.a = rainfogFac;
            if (renderObjectRainFog) renderObjectRainFog.sharedMaterial.SetColor("_TintColor", rainfogCol);

            fogCol = fogColStart*fxUseLight;
            fogFac = Mathf.Lerp(0.0f, 0.04f, Mathf.Clamp01(weather_FogAmt));
            fogCol.a = fogFac;
            if (renderObjectFog) renderObjectFog.sharedMaterial.SetColor("_TintColor", fogCol);

            snowCol = baseSnowCol*fxUseLight;
            snowCol.a = 0.45f;
            if (renderObjectSnow) renderObjectSnow.sharedMaterial.SetColor("_TintColor", snowCol);

            //clamp weather systems
            if (particleObjectRainFog != null)
            {
                //if (particleObjectRainFog.particleCount > 0.0f) ClampParticle("rain fog");
            }
            if (particleObjectRainSplash != null)
                if (particleObjectRainSplash.particleCount > 0.0f) ClampParticle("rain splash");
            if (particleObjectFog != null)
            {
                //if (particleObjectFog.particleCount > 0.0f) ClampParticle("fog");
            }


            // --------------
            // --   FOG   ---   
            //---------------
            if (enableFog)
            {
                Shader.SetGlobalFloat("_Tenkoku_FogStart", fogAtmosphere);
                Shader.SetGlobalFloat("_Tenkoku_FogEnd", fogDistance);
                Shader.SetGlobalFloat("_Tenkoku_FogDensity", fogDensity);

                if (useCameraCam != null)
                {
                    //Shader.SetGlobalFloat("_Tenkoku_shaderDepth",fogDistance/useCameraCam.farClipPlane);
                    Shader.SetGlobalColor("_Tenkoku_FogColor", colorFog);
                    Shader.SetGlobalFloat("_Tenkoku_shaderDepth", useCameraCam.farClipPlane);
                    Shader.SetGlobalFloat("_Tenkoku_FadeDistance", fadeDistance);
                }
            }
            else
            {
                Shader.SetGlobalFloat("_Tenkoku_FogDensity", 0.0f);
            }


            // -------------------------------------
            // --   CALCULATE WIND COORDINATES   ---
            // -------------------------------------
            weather_WindCoords = TenkokuConvertAngleToVector(weather_WindDir);

            windVector.x = tenkokuWindObject.transform.eulerAngles.x;
            windVector.y = weather_WindDir;
            windVector.z = tenkokuWindObject.transform.eulerAngles.z;

            tenkokuWindObject.transform.eulerAngles = windVector;

            tenkokuWindObject.windMain = weather_WindAmt;
            tenkokuWindObject.windTurbulence = Mathf.Lerp(0.0f, 0.4f, weather_WindAmt);
            tenkokuWindObject.windPulseMagnitude = Mathf.Lerp(0.0f, 2.0f, weather_WindAmt);
            tenkokuWindObject.windPulseFrequency = Mathf.Lerp(0.0f, 0.4f, weather_WindAmt);


            // ------------------------
            // --   CLOUD SETTINGS   ---   
            //-------------------------


            //set legacy clouds
#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER

#else
			useLegacyClouds = true;
		#endif


            //GLOBAL CLOUD SETTINGS -----
            colorClouds = decodeColorColorcloud;
            colorClouds = Color.Lerp(colorClouds, colorClouds*colorOverlay, colorOverlay.a);
            colorHighlightClouds = decodeColorAmbientcloud;
            colorHighlightClouds = Color.Lerp(colorHighlightClouds, baseHighlightCloudCol, weather_OvercastAmt*2.0f)*
                                   skyAmbientCol;
            colorHighlightClouds = Color.Lerp(colorHighlightClouds, colorHighlightClouds*colorOverlay, colorOverlay.a);

            Shader.SetGlobalColor("_TenkokuCloudColor", colorClouds);
            Shader.SetGlobalColor("_TenkokuCloudAmbientColor", colorHighlightClouds);


            //LEGACY CLOUD SETTINGS -----
            if (useLegacyClouds)
            {
                if (renderObjectCloudPlane != null) renderObjectCloudPlane.enabled = true;
#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
                if (renderObjectCloudSphere != null) renderObjectCloudSphere.enabled = false;
#endif

                if (renderObjectCloudPlane != null)
                {
                    currCoords.x = systemTime*weather_WindCoords.x*0.1f;
                    currCoords.y = systemTime*weather_WindCoords.y*0.1f;

                    windPosition.x = currCoords.x;
                    windPosition.y = currCoords.y;
                    windPosition.z = 0f;
                    windPosition.w = 0f;
                    Shader.SetGlobalColor("windCoords", windPosition);

                    cloudOverRot += systemTime*cloudRotSpeed*2.1f;
                    cloudOverRot = Mathf.Clamp(cloudOverRot, 0.0f, 1.0f);

                    cloudSpeeds.r = 0.1f*cloudOverRot; //altostratus
                    cloudSpeeds.g = 0.7f*cloudOverRot; //Cirrus
                    cloudSpeeds.b = 1.0f*cloudOverRot; //cumulus
                    cloudSpeeds.a = 2.0f*cloudOverRot; //overcast
                    renderObjectCloudPlane.sharedMaterial.SetColor("_cloudSpd", cloudSpeeds);

                    cloudTexScale.x = cloudSc;
                    cloudTexScale.y = cloudSc;
                    renderObjectCloudPlane.sharedMaterial.SetTextureScale("_MainTex", cloudTexScale);
                    renderObjectCloudPlane.sharedMaterial.SetTextureScale("_CloudTexB", cloudTexScale);
                    if ((useCameraCam != null) && (renderObjectCloudPlane != null))
                        renderObjectCloudPlane.sharedMaterial.SetFloat("_TenkokuDist", 1200f);

                    renderObjectCloudPlane.sharedMaterial.SetFloat("_sizeCloud", weather_cloudCumulusAmt);

                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudS", weather_cloudAltoStratusAmt);
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudC", weather_cloudCirrusAmt);
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudO", Mathf.Clamp01(weather_OvercastAmt*2.0f));
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_cloudHeight",
                        Mathf.Lerp(10.0f, 70.0f, weather_cloudCumulusAmt));


                    //set cloud scale
                    cloudPlaneObject.transform.localScale = planeObjectScale;
                    cloudPosition.x = cloudPlaneObject.transform.localPosition.x;
                    cloudPosition.y = -1.0f;
                    cloudPosition.z = cloudPlaneObject.transform.localPosition.z;
                    cloudPlaneObject.transform.localPosition = cloudPosition;
                    cloudSc = weather_cloudScale;

                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudS", weather_cloudAltoStratusAmt);
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudC", weather_cloudCirrusAmt);
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_amtCloudO", Mathf.Clamp01(weather_OvercastAmt*2.0f));
                    renderObjectCloudPlane.sharedMaterial.SetFloat("_cloudHeight",
                        Mathf.Lerp(10.0f, 70.0f, weather_cloudCumulusAmt));
                }
            }


            //ADVANCED CLOUD SETTINGS (Requires Unity 5.3.4+) -----
#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
            if (!useLegacyClouds)
            {
                if (renderObjectCloudPlane != null) renderObjectCloudPlane.enabled = false;
                if (renderObjectCloudSphere != null) renderObjectCloudSphere.enabled = true;

                if (materialObjectCloudSphere != null)
                {
                    //set sphere size based on camera distance
                    if (useCameraCam != null)
                    {
                        csSize = useCameraCam.farClipPlane/20f*1.75f;
                        cSphereSize.x = csSize;
                        cSphereSize.y = csSize;
                        cSphereSize.z = csSize;
                        cloudSphereObject.transform.localScale = cSphereSize;
                    }

                    //set sphere shader attributes
                    cAmt = Mathf.Max(Mathf.Lerp(0.0f, 0.75f, weather_cloudCumulusAmt), weather_OvercastAmt*4f);

                    //Quality Settings
                    materialObjectCloudSphere.SetFloat("_SampleCount0", Mathf.Lerp(32f, 8f, cAmt)*cloudQuality);
                    materialObjectCloudSphere.SetFloat("_SampleCount1", Mathf.Lerp(32f, 8f, cAmt)*cloudQuality);
                    materialObjectCloudSphere.SetFloat("_SampleCountL", Mathf.Lerp(8f, 4f, cAmt)*cloudQuality);
                    materialObjectCloudSphere.SetFloat("_FarDist", Mathf.Lerp(5000f, 20000f, cloudQuality));
                    materialObjectCloudSphere.SetFloat("_Edge", Mathf.Lerp(0.95f, 0.5f, cloudQuality));
                    materialObjectCloudSphere.SetFloat("quality", cloudQuality);

                    //Cloud Height
                    materialObjectCloudSphere.SetFloat("_Altitude0", Mathf.Lerp(1400f, 900f, cAmt));
                    materialObjectCloudSphere.SetFloat("_Altitude1", Mathf.Lerp(1400f, 3000f, cAmt));
                    materialObjectCloudSphere.SetFloat("_Altitude2", 3500f);
                    materialObjectCloudSphere.SetFloat("_Altitude3", 4000f);
                    materialObjectCloudSphere.SetFloat("_Altitude4", 6500f);
                    materialObjectCloudSphere.SetFloat("_Altitude5", 7000f);

                    //Cloud Frequency
                    materialObjectCloudSphere.SetFloat("_NoiseFreq1", Mathf.Lerp(1.0f, 5.5f, cAmt));
                    materialObjectCloudSphere.SetFloat("_NoiseFreq2", Mathf.Lerp(30f, 15f, cAmt));

                    //Cloud Scattering
                    materialObjectCloudSphere.SetFloat("_Scatter", Mathf.Lerp(0.1f, 0.5f, cAmt)); //0.07
                    materialObjectCloudSphere.SetFloat("_HGCoeff", 0.0f); //0.3
                    materialObjectCloudSphere.SetFloat("_Extinct", Mathf.Lerp(0.005f, 0.005f, cAmt)); //0.003

                    //Cloud Amount
                    materialObjectCloudSphere.SetFloat("_NoiseBias", Mathf.Max(cAmt, weather_OvercastAmt*4f));
                    materialObjectCloudSphere.SetFloat("_NoiseBias2", weather_cloudCirrusAmt);
                    materialObjectCloudSphere.SetFloat("_NoiseBias3", weather_cloudAltoStratusAmt);


                    //set direction and scale
                    weather_CloudCoords = CloudsConvertAngleToVector(weather_WindDir);
                    materialObjectCloudSphere.SetVector("_Scroll1", weather_CloudCoords*0.5f);
                    materialObjectCloudSphere.SetVector("_Scroll2", weather_CloudCoords*2f);
                    materialObjectCloudSphere.SetFloat("_cS", weather_cloudScale/8);

                    //Darkness
                    materialObjectCloudSphere.SetFloat("_Darkness", Mathf.Clamp(Mathf.Lerp(0.5f, 0.5f, cAmt), 0f, 1f));
                        //2
                }
            }
#endif


            // -------------------------------
            // --   Set Global Tint Color   --
            // -------------------------------
            Shader.SetGlobalColor("_TenkokuSkyColor", decodeColorSkybase);
            Shader.SetGlobalColor("tenkoku_globalTintColor", colorOverlay);
            Shader.SetGlobalColor("tenkoku_globalSkyColor", colorSky);


            // -------------------------------
            // --   Altitude Adjustment   --
            // -------------------------------
            // adjust colors and alpha based on altitude height attributes.
            // can simulate entering and leaving planet atmosphere;
            altAdjust = 5000.0f;
            Shader.SetGlobalFloat("tenkoku_altitudeAdjust", altAdjust);


            // -------------------------
            // --   BRDF Sky Object   --
            // -------------------------
            if (useCamera != null)
                if (useCameraCam != null)
                {
                    fogDist = 1.0f/useCameraCam.farClipPlane*(0.9f + fogDistance);
                    fogFull = useCameraCam.farClipPlane;
                }
            colorHorizon = Color.Lerp(colorHorizon, colorHorizon*0.5f, weather_OvercastAmt);
            skyAmbientCol = ambientCol*Mathf.Lerp(1.0f, 0.7f, useOvercast);
            skyHorizonCol = colorHorizon*Mathf.Lerp(1.0f, 0.8f, useOvercast);

            Shader.SetGlobalColor("_Tenkoku_SkyHorizonColor", skyHorizonCol);
            Shader.SetGlobalFloat("_tenkokufogFull", floatRound(fogFull));
            Shader.SetGlobalFloat("_tenkokufogStretch", floatRound(fogDist));
            Shader.SetGlobalFloat("_tenkokufogAtmospheric", floatRound(fogAtmosphere));
            Shader.SetGlobalFloat("_Tenkoku_SkyBright", floatRound(useSkyBright));
            Shader.SetGlobalFloat("_Tenkoku_NightBright", floatRound(nightBrightness));
            Shader.SetGlobalColor("_TenkokuAmbientColor", skyAmbientCol);

            //adjust and set atmospheric density based on day factor
            atmosTime =
                Vector3.Angle(sunObject.transform.position - skyObject.transform.position, skyObject.transform.up)/
                180.0f;
            atmosTime = Mathf.Clamp(Mathf.Lerp(-0.75f, 1.75f, atmosTime), 0.0f, 0.5f);

            setAtmosphereDensity = horizonDensity*2.0f*atmosTime;

            Shader.SetGlobalFloat("_Tenkoku_AtmosphereDensity", floatRound(atmosphereDensity));
            Shader.SetGlobalFloat("_Tenkoku_HorizonDensity", floatRound(setAtmosphereDensity));
            Shader.SetGlobalFloat("_Tenkoku_HorizonHeight", floatRound(horizonDensityHeight));

            if (enableFog)
                Shader.SetGlobalFloat("_Tenkoku_FogDensity", floatRound(fogDensity));

            //overcast color
            overcastCol = decodeColorSkyambient; //decodeColorAmbientcolor;
            overcastCol.a = weather_OvercastAmt;
            Shader.SetGlobalColor("_Tenkoku_overcastColor", overcastCol);
            Shader.SetGlobalFloat("_Tenkoku_overcastAmt", weather_OvercastAmt);


            // assign colors
            if (useCamera != null)
            {
                if (useCameraCam != null)
                {
                    useCameraCam.backgroundColor = decodeColorSkybase*
                                                   Color.Lerp(Color.white, Color.black, atmosphereDensity*0.25f);
                    useCameraCam.backgroundColor = Color.Lerp(Color.black, useCameraCam.backgroundColor,
                        Mathf.Clamp(atmosphereDensity*2f, 0.0f, 1.0f));
                    useCameraCam.backgroundColor *= Mathf.Clamp(skyBrightness, 0.0f, 1.0f);
                }
                nightSkyPosition.x = 60.0f;
                nightSkyPosition.y = useCamera.transform.eulerAngles.y;
                nightSkyPosition.z = useCamera.transform.eulerAngles.z;
                nightSkyLightObject.transform.eulerAngles = nightSkyPosition;
            }

            if (fogCameraCam != null)
            {
                fogCameraCam.backgroundColor = decodeColorSkybase*
                                               Color.Lerp(Color.white, Color.black, atmosphereDensity*0.25f);
                fogCameraCam.backgroundColor = Color.Lerp(Color.black, fogCameraCam.backgroundColor,
                    Mathf.Clamp(atmosphereDensity*2f, 0.0f, 1.0f));
                fogCameraCam.backgroundColor *= Mathf.Clamp(skyBrightness, 0.0f, 1.0f);
            }


            if (RenderSettings.skybox != null)
            {
                RenderSettings.skybox.SetColor("_GroundColor", colorSkyboxGround);
                RenderSettings.skybox.SetColor("_MieColor", colorSkyboxMie);
                RenderSettings.skybox.SetFloat("_Tenkoku_MieAmt", mieAmount);
                RenderSettings.skybox.SetFloat("_Tenkoku_MnMieAmt", mieMnAmount);
            }
            else
            {
                Debug.Log("Tenkoku Warning: No Skybox material has been set!");
            }


            setOverallCol = colorSun*ambientCol*Color.Lerp(Color.white, colorOverlay, colorOverlay.a);
            Shader.SetGlobalColor("_overallCol", setOverallCol);

            bgSCol = skyHorizonCol;
            // convert camera color to linear space when appropriate
            // the scene camera does not render background colors in linear space, so we need to
            // convert the background color to linear before assigning to in-scene shaders.
            if (QualitySettings.activeColorSpace == ColorSpace.Linear)
            {
                bgSCol.r = Mathf.GammaToLinearSpace(bgSCol.r);
                bgSCol.g = Mathf.GammaToLinearSpace(bgSCol.g);
                bgSCol.b = Mathf.GammaToLinearSpace(bgSCol.b);
            }
            Shader.SetGlobalColor("tenkoku_backgroundColor", bgSCol);


            //set GI Ambient
            ambientGI = decodeColorAmbientGI;


            //handle gamma brightness
            useSkyBright = skyBrightness;
            if (QualitySettings.activeColorSpace != ColorSpace.Linear)
                useSkyBright *= 0.42f;

            //assign blur settings
            if (fogCameraBlur != null)
                fogCameraBlur.blurSpread = 1; //0.1f;

            useSkyBright = useSkyBright*Mathf.Lerp(1.0f, 10.0f, ambientGI.r);

            // ------------------------
            // --   Cloud Objects   --
            // ------------------------
            Shader.SetGlobalColor("_TenkokuCloudColor", colorClouds);
            Shader.SetGlobalColor("_TenkokuCloudHighlightColor", colorHighlightClouds);

            //set cloud effect distance color
            Shader.SetGlobalFloat("_fogStretch", floatRound(fogDist));
            Shader.SetGlobalColor("_Tenkoku_SkyColor", colorSkyBase*ambientCloudCol.r*setOverallCol*useSkyBright);
            Shader.SetGlobalColor("_Tenkoku_HorizonColor", colorHorizon*setOverallCol*useSkyBright);
            Shader.SetGlobalFloat("_Tenkoku_Ambient", ambientCloudCol.r);
            Shader.SetGlobalFloat("_Tenkoku_AmbientGI", ambientGI.r);

            //set aurora settings
            auroraIsVisible = false;
            if (auroraTypeIndex == 0)
                auroraIsVisible = true;


            if (!auroraIsVisible || (auroraLatitude > Mathf.Abs(setLatitude)))
            {
                renderObjectAurora.enabled = false;
            }
            else
            {
                renderObjectAurora.enabled = true;

                aurSpan = 30.0f;
                aurAmt = Mathf.Lerp(0.0f, 1.0f,
                    Mathf.Clamp((Mathf.Abs(setLatitude) - auroraLatitude)/aurSpan, 0.0f, 1.0f));
                Shader.SetGlobalFloat("_Tenkoku_AuroraSpd", auroraSpeed);
                Shader.SetGlobalFloat("_Tenkoku_AuroraAmt", auroraIntensity*aurAmt);
            }


            // ----------------------------
            // --   WORLD LIGHT OBJECT   --
            // ----------------------------
            worldlightObject.transform.rotation = sunlightObject.transform.rotation;

            //Clamp light height
            if (minimumHeight > 0f)
                if (worldlightObject.transform.eulerAngles.x < minimumHeight)
                {
                    lightClampVector = worldlightObject.transform.eulerAngles;
                    lightClampVector.x = minimumHeight;
                    worldlightObject.transform.eulerAngles = lightClampVector;
                }

            ambientBaseCol.r = ambientCol.r;
            ambientBaseCol.g = ambientCol.r;
            ambientBaseCol.b = ambientCol.r;
            ambientBaseCol.a = 1f;
            WorldCol = Color.Lerp(decodeColorSun*ambientCol.r, ambientBaseCol*0.7f,
                Mathf.Clamp01(weather_OvercastAmt*2.0f));

            //tint light color with overall color
            WorldCol = WorldCol*Color.Lerp(Color.white, colorOverlay, colorOverlay.a);

            sC = WorldCol.grayscale;
            sCol.r = sC;
            sCol.g = sC;
            sCol.b = sC;
            sCol.a = WorldCol.a;
            WorldCol = Color.Lerp(sCol, WorldCol, sunSat);

            lightObjectWorld.color = WorldCol;
            lightObjectWorld.intensity = 2.0f*(sunBright*0.68f)*ambientCol.r;
            //lightObjectWorld.shadowStrength = Mathf.Lerp(1.0f,0.25f,weather_OvercastAmt);

            WorldCol.a = lightObjectWorld.intensity;
            Shader.SetGlobalColor("_TenkokuSunColor", WorldCol);


            // ------------------------------
            // --   HANDLE SUN RAY EFFECTS   --
            // ------------------------------
            if (useCamera != null)
            {
                rayCol = colorSun;
                baseRayCol.r = rayCol.r;
                baseRayCol.g = rayCol.r;
                baseRayCol.b = rayCol.r;
                baseRayCol.a = rayCol.a;
                rayCol = Color.Lerp(rayCol, baseRayCol, Mathf.Clamp01(weather_OvercastAmt*2f));

                if (sunRayObject != null)
                {
                    sunRayObject.enabled = useSunRays ? true : false;
                    sunRayObject.sunTransform = sunlightObject.transform;
                    sunRayObject.sunColor = rayCol;
                    sunRayObject.sunShaftIntensity = Mathf.Lerp(0.0f, 20.0f, sunRayIntensity);
                    sunRayObject.maxRadius = sunRayLength;
                }
            }


            // ----------------------------
            // --   NIGHT LIGHT OBJECT   --
            // ----------------------------
            nightSkyLightObject.transform.rotation = moonlightObject.transform.rotation;

            //Clamp light height
            if (minimumHeight > 0f)
                if (nightSkyLightObject.transform.eulerAngles.x < minimumHeight)
                {
                    lightClampVector = nightSkyLightObject.transform.eulerAngles;
                    lightClampVector.x = minimumHeight;
                    nightSkyLightObject.transform.eulerAngles = lightClampVector;
                }

            lightObjectNight.intensity = Mathf.Lerp(0.0f, 1.0f, nightBrightness*1.2f*(1.0f - ambientCol.r)) +
                                         moonBright*(1.0f - ambientCol.r)*(1.0f - weather_OvercastAmt);


            mC = mCol.grayscale;
            mCol.r = mC;
            mCol.g = mC;
            mCol.b = mC;

            //mCol = Color.Lerp(mCol, ambientBaseCol*0.7f,Mathf.Clamp01(weather_OvercastAmt*2.0f));

            lightObjectNight.color = Color.Lerp(mCol, mColMixCol, moonSat);


            //modulate night intensity based on altitude
            if ((lightObjectNight != null) && (moonSphereObject != null))
            {
                //find the light factor based on the rotation of the light
                delta = moonSphereObject.transform.position - moonObject.transform.position;
                look = Quaternion.LookRotation(delta);
                vertical = look.eulerAngles.x;

                if (vertical > 90.0f) vertical = 90f - (vertical - 90.0f);
                vertical = Mathf.Clamp01(vertical/10.0f); //degrees

                //set the light intensity
                lightObjectNight.intensity = lightObjectNight.intensity*Mathf.Lerp(0.0f, 1.0f, vertical);
            }


            //modulate day intensity based on altitude
            if ((lightObjectWorld != null) && (sunSphereObject != null))
            {
                //find the light factor based on the rotation of the light
                delta = sunSphereObject.transform.position - sunObject.transform.position;
                look = Quaternion.LookRotation(delta);
                vertical = look.eulerAngles.x;

                sunVert = vertical;
                if (vertical > 90.0f) vertical = 90f - (vertical - 90.0f);
                vertical = Mathf.Clamp01(vertical/10.0f); //degrees

                //set the light intensity
                lightObjectWorld.intensity = lightObjectWorld.intensity*Mathf.Lerp(0.0f, 1.0f, vertical);

                //modulate moon intensity via sun angle
                if (lightObjectNight != null)
                {
                    mMult = Mathf.Clamp01((356.0f - sunVert)/5.0f);
                    if (sunVert > 90.0f) mMult = 1.0f;
                    if (lightObjectWorld.intensity > 0.0f) mMult = 0.0f;
                    lightObjectNight.intensity = lightObjectNight.intensity*mMult;
                }
            }


            // ---------------------------------
            // --   SOLAR ECLIPSE HANDLING   ---
            // ---------------------------------
//            ecldiff = 0.0f;
//            if (useCamera != null)
//            {
//                mRay = new Ray(useCamera.transform.position, moonObject.transform.position);
//                sRay = new Ray(useCamera.transform.position, sunObject.transform.position);
//                ecldiff = Vector3.Angle(sRay.direction, mRay.direction);
//                ecldiff = 1.0f - ecldiff;
//            }
//
//            Shader.SetGlobalFloat("_Tenkoku_EclipseFactor",
//                Mathf.Clamp01(Mathf.Lerp(1.0f, 0.0f, Mathf.Clamp01(ecldiff*1.1f))));
//            lightObjectWorld.intensity *= Mathf.Clamp01(Mathf.Lerp(1.0f, 0.0f, Mathf.Clamp01(ecldiff*1.1f)));
//            if ((eclipseObject != null) && (ecldiff > 0.0f))
//            {
//                eclipsePosition.x = eclipseObject.transform.eulerAngles.x;
//                eclipsePosition.y = eclipseObject.transform.eulerAngles.y;
//                eclipsePosition.z = eclipseObject.transform.eulerAngles.z + Time.deltaTime*4.0f;
//                eclipseObject.transform.eulerAngles = eclipsePosition;
//                eclipseObject.transform.localScale = Vector3.one*Mathf.Lerp(1f, 7f, ecldiff);
//            }


            //handle gamma world lighting brightness
            if (QualitySettings.activeColorSpace != ColorSpace.Linear)
                lightObjectWorld.intensity = lightObjectWorld.intensity*0.8f;

            //set minimum world light setting
            if (allowMultiLights)
            {
                lightObjectWorld.intensity = Mathf.Clamp(lightObjectWorld.intensity, 0.001f, 8.0f);
                lightObjectWorld.renderMode = LightRenderMode.ForcePixel;
                lightObjectNight.renderMode = LightRenderMode.ForcePixel;
                lightObjectNight.shadows = LightShadows.Soft;

                //enable/disable lights
                if (lightObjectWorld.intensity <= 0.55f)
                    lightObjectWorld.enabled = false;
                else
                    lightObjectWorld.enabled = true;

                if (lightObjectNight.intensity <= 0.6f)
                    lightObjectNight.enabled = false;
                else
                    lightObjectNight.enabled = true;
            }
            else
            {
                lightObjectWorld.intensity = Mathf.Clamp(lightObjectWorld.intensity, 0.001f, 8.0f);
                lightObjectWorld.renderMode = LightRenderMode.ForcePixel;
                lightObjectNight.renderMode = LightRenderMode.ForcePixel;
                lightObjectNight.shadows = LightShadows.Soft;

                //enable/disable lights
                if (lightObjectWorld.intensity <= 0.55f)
                    lightObjectWorld.enabled = false;
                else
                    lightObjectWorld.enabled = true;

                if ((lightObjectNight.intensity <= 0.6f) || lightObjectWorld.enabled)
                    lightObjectNight.enabled = false;
                else
                    lightObjectNight.enabled = true;

/*
                                                            lightObjectNight.renderMode = LightRenderMode.ForceVertex;
                                                            lightObjectNight.shadows = LightShadows.None;
                                                            lightObjectWorld.intensity = Mathf.Clamp(lightObjectWorld.intensity,0.0f,8.0f);
                                                            if (lightObjectWorld.intensity <= 0.55f){
                                                                lightObjectWorld.enabled = false;
                                                                lightObjectNight.enabled = true;
                                                            } else {
                                                                lightObjectWorld.enabled = true;
                                                                lightObjectNight.enabled = false;
                                                            }
                                                */
            }

            Shader.SetGlobalColor("_Tenkoku_Daylight", lightObjectWorld.color*(lightObjectWorld.intensity*0.5f)*calcTime);
            Shader.SetGlobalColor("_Tenkoku_Nightlight", lightObjectNight.color*(lightObjectNight.intensity + nightBrightness)*(1.0f - calcTime)*2f);
        }


        //void FixedUpdate(){
        //TimeUpdate();
        //}


        void TimeUpdate()
        {
            //------------------------------
            //---    CALCULATE TIMER    ----
            //------------------------------


            //TRANSITION TIME
            if (doTransition)
                Tenkoku_TransitionTime();


            //AUTO INCREASE TIME
            if (useAutoTime && !autoTimeSync && Application.isPlaying)
            {
                //calculate time compression curve
                curveVal = timeCurves.Evaluate(dayValue);

                if (useTimeCompression < 3600.0f)
                {
                    setTimeSpan = Time.fixedDeltaTime*useTimeCompression;
                    countSecond += setTimeSpan;
                    countSecondMoon += Mathf.FloorToInt(setTimeSpan*0.92068f);
                    countSecondStar += Mathf.FloorToInt(setTimeSpan*0.9333342f);
                }
                else
                {
                    setTimeSpan = Time.fixedDeltaTime*(useTimeCompression/60.0f);
                    countMinute += setTimeSpan;
                    countMinuteMoon += Mathf.FloorToInt(setTimeSpan*0.92068f);
                    countMinuteStar += Mathf.FloorToInt(setTimeSpan*0.9333342f);
                }
            }


            //RECALCULATE DATE and TIME
            RecalculateTime();


            if (Mathf.Abs(countSecond) >= 1.0f)
            {
                currentSecond += Mathf.FloorToInt(countSecond);
                countSecond = 0.0f;
            }
            if (Mathf.Abs(countMinute) >= 1.0f)
            {
                currentMinute += Mathf.FloorToInt(countMinute);
                countMinute = 0.0f;
            }

            if (Mathf.Abs(countSecondMoon) >= 1.0f)
            {
                moonSecond += Mathf.FloorToInt(countSecondMoon);
                countSecondMoon = 0.0f;
            }
            if (Mathf.Abs(countMinuteMoon) >= 1.0f)
            {
                moonMinute += Mathf.FloorToInt(countMinuteMoon);
                countMinuteMoon = 0.0f;
            }

            if (Mathf.Abs(countSecondStar) >= 1.0f)
            {
                starSecond += Mathf.FloorToInt(countSecondStar);
                countSecondStar = 0.0f;
            }
            if (Mathf.Abs(countMinuteStar) >= 1.0f)
            {
                starMinute += Mathf.FloorToInt(countMinuteStar);
                countMinuteStar = 0.0f;
            }


            //SET DISPLAY TIME
#if UNITY_EDITOR
            displayTime = DisplayTime("[ hh:mm:ss am] [ M/D/Y ad]");
#endif
        }


        public string DisplayTime(string format)
        {
            //format string examples:
            // "M/D/Y H:M:S"
            setString = format;
            eon = "ad";
            useHour = setHour;

            displayHour = setHour;
            if (use24Clock)
            {
                hourMode = "AM";
                if (useHour > 12)
                {
                    displayHour -= 12;
                    hourMode = "PM";
                }
            }
            else
            {
                hourMode = "";
            }

            if (currentYear < 0) eon = "bc";
            setString = setString.Replace("hh", useHour.ToString("00"));
            setString = setString.Replace("mm", currentMinute.ToString("00"));
            setString = setString.Replace("ss", currentSecond.ToString("00"));
            setString = setString.Replace("Y", Mathf.Abs(currentYear).ToString());
            setString = setString.Replace("M", currentMonth.ToString());
            setString = setString.Replace("D", currentDay.ToString());
            setString = setString.Replace("ad", eon);

            if (use24Clock)
                setString = setString.Replace("am", hourMode);
            else
                setString = setString.Replace("am", "");

            return setString;
        }


        public int RecalculateLeapYear(int checkMonth, int checkYear)
        {
            //check for leap Year (by div 4 method)
            leapYear = false;
            if (checkYear/4.0f == Mathf.FloorToInt(checkYear/4.0f)) leapYear = true;

            //double check for leap Year (by div 100 + div 400 method)
            if (checkYear/100.0f == Mathf.FloorToInt(checkYear/100.0f))
                if (checkYear/400.0f != Mathf.FloorToInt(checkYear/400.0f)) leapYear = false;

            //calculate month length
            monthLength = 31;
            testMonth = Mathf.FloorToInt(checkMonth);
            if ((testMonth == 4) || (testMonth == 6) || (testMonth == 9) || (testMonth == 11)) monthLength = 30;
            if ((testMonth == 2) && !leapYear) monthLength = 28;
            if ((testMonth == 2) && leapYear) monthLength = 29;

            return monthLength;
        }


        void RecalculateTime()
        {
            //getLeapYear
            monthFac = RecalculateLeapYear(currentMonth, currentYear);

            //clamp and pass all values
            if ((currentSecond > 59) || (currentSecond < 0)) currentMinute += Mathf.FloorToInt(currentSecond/60.0f);
            if (currentSecond > 59) currentSecond = 0;
            if (currentSecond < 0) currentSecond = 59;
            if ((currentMinute > 59) || (currentMinute < 0.0)) currentHour += Mathf.FloorToInt(currentMinute/60.0f);
            if (currentMinute > 59) currentMinute = 0;
            if (currentMinute < 0) currentMinute = 59;

            if ((currentHour > 23) || (currentHour < 0)) currentDay += Mathf.CeilToInt(currentHour/24.0f);
            if (currentHour > 23) currentHour = 0;
            if (currentHour < 0) currentHour = 23;

            if ((currentDay > monthFac) || (currentDay < 1)) currentMonth += Mathf.CeilToInt(currentDay/(monthFac*1.0f) - 1.0f);
            if (currentDay > monthFac) currentDay = 1;
            if (currentDay < 1) currentDay = RecalculateLeapYear(currentMonth - 1, currentYear);
            if ((currentMonth > 12) || (currentMonth < 1)) currentYear += Mathf.CeilToInt(currentMonth/12.0f - 1f);
            if (currentMonth > 12) currentMonth = 1;
            if (currentMonth < 1) currentMonth = 12;
            if (currentYear == 0) currentYear = 1;

            //clamp and pass all moon values
            if ((moonSecond > 59) || (moonSecond < 0)) moonMinute += Mathf.FloorToInt(moonSecond/60.0f);
            if (moonSecond > 59) moonSecond = 0;
            if (moonSecond < 0) moonSecond = 59;
            if ((moonMinute > 59) || (moonMinute < 0.0)) moonHour += Mathf.FloorToInt(moonMinute/60.0f);
            if (moonMinute > 59) moonMinute = 0;
            if (moonMinute < 0) moonMinute = 59;
            if ((moonHour > 24) || (moonHour < 1)) moonDay += Mathf.CeilToInt(moonHour/24.0f - 1f);
            if (moonHour > 24) moonHour = 1;
            if (moonHour < 1) moonHour = 24;
            if ((moonDay > monthFac) || (moonDay < 1)) moonMonth += Mathf.CeilToInt(moonDay/(monthFac*1.0f) - 1.0f);
            if (moonDay > monthFac) moonDay = 1;
            if (moonDay < 1) moonDay = RecalculateLeapYear(moonMonth - 1, currentYear);
            if ((moonMonth > 12) || (moonMonth < 1)) moonYear += Mathf.CeilToInt(moonMonth/12.0f - 1f);
            if (moonMonth > 12) moonMonth = 1;
            if (moonMonth < 1) moonMonth = 12;

            //clamp and pass all star values
            if ((starSecond > 59) || (starSecond < 0)) starMinute += Mathf.FloorToInt(starSecond/60.0f);
            if (starSecond > 59) starSecond = 0;
            if (starSecond < 0) starSecond = 59;
            if ((starMinute > 59) || (starMinute < 0.0)) starHour += Mathf.FloorToInt(starMinute/60.0f);
            if (starMinute > 59) starMinute = 0;
            if (starMinute < 0) starMinute = 59;
            if ((starHour > 24) || (starHour < 1)) starDay += Mathf.CeilToInt(starHour/24.0f - 1f);
            if (starHour > 24) starHour = 1;
            if (starHour < 1) starHour = 24;
            if ((starDay > monthFac) || (starDay < 1)) starMonth += Mathf.CeilToInt(starDay/(monthFac*1.0f) - 1.0f);
            if (starDay > monthFac) starDay = 1;
            if (starDay < 1) starDay = RecalculateLeapYear(starMonth - 1, currentYear);
            if ((starMonth > 12) || (starMonth < 1)) starYear += Mathf.CeilToInt(starMonth/12.0f - 1f);
            if (starMonth > 12) starMonth = 1;
            if (starMonth < 1) starMonth = 12;


            if (!use24Clock && (setHour > 12))
                setHour = currentHour + 12;
            else
                setHour = currentHour;
            setHour = currentHour;


            //CALCULATE TIMERS
            setDay = (setHour - 1)*3600.0f + currentMinute*60.0f + currentSecond*1.0f;
            setStar = (starHour - 1)*3600.0f + starMinute*60.0f + starSecond*1.0f;
            monthAddition = 0.0f;

            for (aM = 1; aM < currentMonth; aM++)
                monthAddition += RecalculateLeapYear(aM, currentYear)*1.0f;
            setYear = monthAddition + (currentDay - 1f) + (currentSecond + currentMinute*60f + setHour*3600f)/86400.0f;
            setMonth = Mathf.Floor(moonDay - 1)*86400.0f + Mathf.Floor(moonHour - 1)*3600.0f + Mathf.Floor(moonMinute)*60.0f + Mathf.Floor(moonSecond)*1.0f;
            setMoon = Mathf.Floor(moonDay - 1)*86400.0f + Mathf.Floor(moonHour - 1f)*3600.0f + Mathf.Floor(moonMinute)*60.0f + Mathf.Floor(moonSecond)*1.0f;
            setStar = Mathf.Floor(starMonth - 1)*30.41666f + Mathf.Floor(starDay - 1f) + Mathf.Floor(starSecond + Mathf.Floor(starMinute)*60f + Mathf.Floor(starHour - 1)*3600f)/86400.0f;


            //CLAMP VALUES
            yearDiv = 365.0f;
            if (leapYear) yearDiv = 366.0f;
            if (setYear > 86400.0f*yearDiv) setYear = 0.0f;
            if (setYear < 0.0f) setYear = 86400.0f*yearDiv;


            //CALCULATE VALUES
            dayValue = setDay/86400.0f;
            monthValue = setMonth/(86400.0f*29.530589f);
            yearValue = setYear/yearDiv;
            starValue = setDay/86400.0f;
            starValue -= setStar/365.0f;
            moonValue = setDay/86400.0f;
            moonValue -= setMoon/(86400.0f*29.6666f);

            //SEND TIME TO CALCULATIONS COMPONENT
            calcComponent.y = currentYear;
            calcComponent.m = currentMonth;
            calcComponent.D = currentDay;


            calcComponent.UT = currentHour - 1 + currentMinute/60.0f + (currentSecond + cloudStepTime)/60.0f/60.0f;
            lastSecond = currentSecond;

            calcComponent.local_latitude = setLatitude;
            calcComponent.local_longitude = -setLongitude;
            calcComponent.tzOffset = -setTZOffset;
            calcComponent.dstOffset = enableDST ? 1 : 0;
        }


        public float floatRound(float inFloat)
        {
            //var retFloat : float = 0.0f;
            //retFloat = Mathf.Round(inFloat*1000.0f)/1000.0f;
            //return retFloat;
            return inFloat;
        }


        void ClampParticle(string px_system)
        {
            clampRes = 0.0f;
            px = 0;
            usePoint = 0.0f;

            //clamp rain fog particles to ground (raycast)
            if (px_system == "rain fog")
            {
                clampRes = 1.0f;
                setParticles = new ParticleSystem.Particle[particleObjectRainFog.particleCount];
                particleObjectRainFog.GetParticles(setParticles);
                for (px = 0; px < particleObjectRainFog.particleCount; px++)
                    if (setParticles[px].remainingLifetime >= 2.5f)
                    {
                        if (px/clampRes == Mathf.Floor(px/clampRes)*1.0f)
                        {
                            particleRayPosition.x = setParticles[px].position.x;
                            particleRayPosition.y = 5000.0f;
                            particleRayPosition.z = setParticles[px].position.z;
                            if (Physics.Raycast(particleRayPosition, -Vector3.up, out hit, 10000.0f))
                                if (!hit.collider.isTrigger)
                                    usePoint = hit.point.y;
                        }

                        particlePosition.x = setParticles[px].position.x;
                        particlePosition.y = usePoint;
                        particlePosition.z = setParticles[px].position.z;
                        setParticles[px].position = particlePosition;
                    }
                particleObjectRainFog.SetParticles(setParticles, setParticles.Length);
                particleObjectRainFog.Play();
            }


            //clamp rain fog particles to ground (raycast)
            if (px_system == "rain splash")
            {
                clampRes = 1.0f;
                setParticles = new ParticleSystem.Particle[particleObjectRainSplash.particleCount];
                particleObjectRainSplash.GetParticles(setParticles);
                for (px = 0; px < particleObjectRainSplash.particleCount; px++)
                {
                    //#if UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
                    particleCol.r = setParticles[px].startColor.r;
                    particleCol.g = setParticles[px].startColor.g;
                    particleCol.b = setParticles[px].startColor.b;
                    particleCol.a = 0f;
                    setParticles[px].startColor = particleCol;
#else
				particleCol.r = setParticles[px].color.r;
				particleCol.g = setParticles[px].color.g;
				particleCol.b = setParticles[px].color.b;
				particleCol.a = 0f;
				setParticles[px].color = particleCol;
			#endif

                    if (setParticles[px].remainingLifetime >= 0.05f)
                    {
                        if (px/clampRes == Mathf.Floor(px/clampRes)*1.0f)
                        {
                            particleRayPosition.x = setParticles[px].position.x;
                            particleRayPosition.y = 5000.0f;
                            particleRayPosition.z = setParticles[px].position.z;
                            if (Physics.Raycast(particleRayPosition, -Vector3.up, out hit, 10000.0f))
                                if (!hit.collider.isTrigger)
                                    usePoint = hit.point.y;
                        }

                        particlePosition.x = setParticles[px].position.x;
                        particlePosition.y = usePoint;
                        particlePosition.z = setParticles[px].position.z;
                        setParticles[px].position = particlePosition;

                        //#if UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
#if UNITY_5_3_4 || UNITY_5_3_5 || UNITY_5_3_6 || UNITY_5_4_OR_NEWER
                        particleCol.r = setParticles[px].startColor.r;
                        particleCol.g = setParticles[px].startColor.g;
                        particleCol.b = setParticles[px].startColor.b;
                        particleCol.a = TenRandom.Next(25.0f, 150.0f);
                        setParticles[px].startColor = particleCol;
#else
					particleCol.r = setParticles[px].color.r;
					particleCol.g = setParticles[px].color.g;
					particleCol.b = setParticles[px].color.b;
					particleCol.a = TenRandom.Next(25.0f,150.0f);
					setParticles[px].color = particleCol;
				#endif
                    }
                }
                particleObjectRainSplash.SetParticles(setParticles, setParticles.Length);
                particleObjectRainSplash.Play();
            }


            //clamp fog particles to ground (raycast)
            if (px_system == "fog")
            {
                clampRes = 1.0f;
                setParticles = new ParticleSystem.Particle[particleObjectFog.particleCount];
                particleObjectFog.GetParticles(setParticles);
                for (px = 0; px < particleObjectFog.particleCount; px++)
                    if (setParticles[px].remainingLifetime >= 4.8f)
                    {
                        if (px/clampRes == Mathf.Floor(px/clampRes)*1.0f)
                        {
                            particleRayPosition.x = setParticles[px].position.x;
                            particleRayPosition.y = 5000.0f;
                            particleRayPosition.z = setParticles[px].position.z;
                            if (Physics.Raycast(particleRayPosition, -Vector3.up, out hit, 10000.0f))
                                if (!hit.collider.isTrigger)
                                    usePoint = hit.point.y;
                        }
                        if (usePoint > weather_FogHeight) usePoint = weather_FogHeight;

                        particlePosition.x = setParticles[px].position.x;
                        particlePosition.y = usePoint;
                        particlePosition.z = setParticles[px].position.z;
                        setParticles[px].position = particlePosition;
                    }
                particleObjectFog.SetParticles(setParticles, setParticles.Length);
                particleObjectFog.Play();
            }
        }


        public Vector2 TenkokuConvertAngleToVector(float convertAngle)
        {
            dir = Vector3.zero;
            tempAngle = Vector3.zero;
            if (convertAngle <= 180.0f)
            {
                tempAngle = Vector3.Slerp(Vector3.forward, -Vector3.forward, convertAngle/180.0f);
                tempAngleVec2.x = tempAngle.x;
                tempAngleVec2.y = -tempAngle.z;
                dir = tempAngleVec2;
            }
            if (convertAngle > 180.0f)
            {
                tempAngle = Vector3.Slerp(-Vector3.forward, Vector3.forward, (convertAngle - 180.0f)/180.0f);
                tempAngleVec2.x = -tempAngle.x;
                tempAngleVec2.y = -tempAngle.z;
                dir = tempAngleVec2;
            }

            return dir;
        }


        public Vector4 CloudsConvertAngleToVector(float convertAngle)
        {
            var dir = Vector4.zero;
            var tempAngle = Vector3.zero;
            if (convertAngle <= 180.0f)
            {
                tempAngle = Vector3.Slerp(Vector3.forward, -Vector3.forward, convertAngle/180.0f);
                dir.x = tempAngle.x;
                dir.z = -tempAngle.z;
            }
            if (convertAngle > 180.0f)
            {
                tempAngle = Vector3.Slerp(-Vector3.forward, Vector3.forward, (convertAngle - 180.0f)/180.0f);
                dir.x = -tempAngle.x;
                dir.z = -tempAngle.z;
            }
            dir.y = -0.25f;
            dir.w = 0f;

            return dir;
        }


        public void LoadDecodedColors()
        {
            decodeColorSun = DecodeColorKey(0);
            //decodeColorSunray = DecodeColorKey(1);
            decodeColorAmbientcolor = DecodeColorKey(2);
            decodeColorMoon = DecodeColorKey(3);
            decodeColorSkyambient = DecodeColorKey(4);
            decodeColorSkybase = DecodeColorKey(5);
            decodeColorAmbientcloud = DecodeColorKey(6);
            decodeColorColorhorizon = DecodeColorKey(7);
            decodeColorColorcloud = DecodeColorKey(8);
            decodeColorAmbientGI = DecodeColorKey(9);
        }


        public void UpdateColorMap()
        {
            DecodedColors = colorRamp.GetPixels(0);
        }


        public Color DecodeColorKey(int position)
        {
            //positions
            texPos = 0;
            if (position == 0) texPos = 144; //sun
            if (position == 1) texPos = 144; //sunray
            if (position == 2) texPos = 81; //ambientcolor
            if (position == 3) texPos = 59; //moon
            if (position == 4) texPos = 37; //skyambient
            if (position == 5) texPos = 100; //skybase
            if (position == 6) texPos = 186; //ambientcloud
            if (position == 7) texPos = 121; //colorhorizon
            if (position == 8) texPos = 166; //colorcloud
            if (position == 9) texPos = 15; //ambientGI


            //decode texture
            returnColor = Color.black;

            if (colorRamp != null)
            {
                //decode textures
                if (DecodedColors != null)
                    returnColor = Color.Lerp(
                        DecodedColors[stepTime + texPos*colorRamp.width],
                        DecodedColors[stepTime + 1 + texPos*colorRamp.width],
                        timeLerp);

                //moon
                if ((position == 3) && (DecodedColors != null))
                    returnColor = Color.Lerp(
                        DecodedColors[stepTimeM + texPos*colorRamp.width],
                        DecodedColors[stepTimeM + 1 + texPos*colorRamp.width],
                        timeLerpM);

                //sunray
                if (position == 1)
                {
                    returnColor.r = Mathf.Pow(returnColor.r, 3.2f);
                    returnColor.g = Mathf.Pow(returnColor.g, 3.2f);
                    returnColor.b = Mathf.Pow(returnColor.b, 3.2f);
                }


                //linear and gamma conversion
                if (QualitySettings.activeColorSpace != ColorSpace.Linear)
                    if (position == 5)
                    {
                        //skybase
                        returnColor.r *= 0.4646f;
                        returnColor.g *= 0.4646f;
                        returnColor.b *= 0.4646f;
                    }
            }

            return returnColor;
        }


        // ENCODE SETTINGS TO STRING
        // this is useful to quickly encode
        // Tenkoku settings over a server.
        public string Tenkoku_EncodeData()
        {
            //run functions
            dataString = currentYear + ",";
            dataString += currentMonth + ",";
            dataString += currentDay + ",";
            dataString += currentHour + ",";
            dataString += currentMinute + ",";
            dataString += currentSecond + ",";

            dataString += setLatitude + ",";
            dataString += setLongitude + ",";

            dataString += weather_cloudAltoStratusAmt + ",";
            dataString += weather_cloudCirrusAmt + ",";
            dataString += weather_cloudCumulusAmt + ",";
            dataString += weather_OvercastAmt + ",";
            dataString += weather_cloudScale + ",";
            dataString += weather_cloudSpeed + ",";
            dataString += weather_RainAmt + ",";
            dataString += weather_SnowAmt + ",";
            dataString += weather_FogAmt + ",";
            dataString += weather_WindAmt + ",";
            dataString += weather_WindDir + ",";

            dataString += weatherTypeIndex + ",";
            dataString += weather_autoForecastTime + ",";
            dataString += weather_TransitionTime + ",";

            dataUpdate = weather_forceUpdate ? "1" : "0";
            dataString += dataUpdate + ",";

            dataString += weather_temperature + ",";
            dataString += weather_rainbow + ",";
            dataString += weather_lightning + ",";
            dataString += weather_lightningDir + ",";
            dataString += weather_lightningRange + ",";

            //save random marker
            dataString += randSeed + ",";

            //current cloud coordinates
            dataString += currCoords.x + ",";
            dataString += currCoords.y.ToString();


            return dataString;
        }


        // DECODE SETTINGS FROM STRING
        // this is useful to quickly decode
        // Tenkoku settings over a server.
        public void Tenkoku_DecodeData(string dataString)
        {
            data = dataString.Split(","[0]);

            //set functions
            currentYear = int.Parse(data[0]);
            currentMonth = int.Parse(data[1]);
            currentDay = int.Parse(data[2]);
            currentHour = int.Parse(data[3]);
            currentMinute = int.Parse(data[4]);
            currentSecond = int.Parse(data[5]);

            setLatitude = float.Parse(data[6]);
            setLongitude = float.Parse(data[7]);

            weather_cloudAltoStratusAmt = float.Parse(data[8]);
            weather_cloudCirrusAmt = float.Parse(data[9]);
            weather_cloudCumulusAmt = float.Parse(data[10]);
            weather_OvercastAmt = float.Parse(data[11]);
            weather_cloudScale = float.Parse(data[12]);
            weather_cloudSpeed = float.Parse(data[13]);
            weather_RainAmt = float.Parse(data[14]);
            weather_SnowAmt = float.Parse(data[15]);
            weather_FogAmt = float.Parse(data[16]);
            weather_WindAmt = float.Parse(data[17]);
            weather_WindDir = float.Parse(data[18]);

            weatherTypeIndex = int.Parse(data[19]);
            weather_autoForecastTime = float.Parse(data[20]);
            weather_TransitionTime = float.Parse(data[21]);

            setUpdate = data[22];
            if (setUpdate == "1")
                weather_forceUpdate = true;
            else
                weather_forceUpdate = false;

            weather_temperature = float.Parse(data[23]);
            weather_rainbow = float.Parse(data[24]);
            weather_lightning = float.Parse(data[25]);
            weather_lightningDir = float.Parse(data[26]);
            weather_lightningRange = float.Parse(data[27]);

            //decode random marker
            randSeed = int.Parse(data[28]);
            TenRandom = new Random(randSeed);

            //current cloud coordinates
            currCoords.x = float.Parse(data[29]);
            currCoords.y = float.Parse(data[30]);
        }


        // TRANSITION TIME CAPTURE
        public void Tenkoku_SetTransition(string startTime, string targetTime, int duration, float direction)
        {
            transitionStartTime = startTime;
            transitionTargetTime = targetTime;
            transitionDuration = duration;
            transitionDirection = direction;
            doTransition = true;
        }

        public void Tenkoku_SetTransition(string startTime, string targetTime, int duration, float direction, GameObject callbackObject)
        {
            transitionStartTime = startTime;
            transitionTargetTime = targetTime;
            transitionDuration = duration;
            transitionDirection = direction;
            if (callbackObject != null)
            {
                transitionCallbackObject = callbackObject;
                transitionCallback = true;
            }
            doTransition = true;
        }


        // DO TIME TRANSITIONS
        void Tenkoku_TransitionTime()
        {
            //Initialize
            if (transitionTime <= 0.0f)
            {
                //clamp direction
                if (transitionDirection > 0.0f) transitionDirection = 1.0f;
                if (transitionDirection < 0.0f) transitionDirection = -1.0f;

                //calculate ending time
                setTransHour = Mathf.Clamp(int.Parse(transitionTargetTime.Substring(0, 2)), 0, 23);
                setTransMinute = Mathf.Clamp(int.Parse(transitionTargetTime.Substring(3, 2)), 0, 59);
                setTransSecond = Mathf.Clamp(int.Parse(transitionTargetTime.Substring(6, 2)), 0, 59);
                endTime = setTransSecond + setTransMinute*60 + setTransHour*3600;

                //calculate starting time
                if ((transitionStartTime == null) || (transitionStartTime == ""))
                {
                    startHour = currentHour;
                    startMinute = currentMinute;
                    startSecond = currentSecond;
                }
                else
                {
                    startHour = Mathf.Clamp(int.Parse(transitionStartTime.Substring(0, 2)), 0, 23);
                    startMinute = Mathf.Clamp(int.Parse(transitionStartTime.Substring(3, 2)), 0, 59);
                    startSecond = Mathf.Clamp(int.Parse(transitionStartTime.Substring(6, 2)), 0, 59);
                    currentHour = startHour;
                    currentMinute = startMinute;
                    currentSecond = startSecond;
                }
                startTime = startSecond + startMinute*60 + startHour*3600;

                //calculate same day flag
                transSameDay = true;
                if ((transitionDirection == 1.0f) && (endTime < startTime)) transSameDay = false;
                if ((transitionDirection == -1.0f) && (endTime > startTime)) transSameDay = false;

                //set transition target value
                if (transitionDirection == 1.0f)
                {
                    if ((endTime > startTime) && transSameDay) timeVal = endTime - startTime;
                    if ((endTime < startTime) && !transSameDay) timeVal = 86400f - startTime + endTime;
                }
                if (transitionDirection == -1.0f)
                {
                    if ((endTime < startTime) && transSameDay) timeVal = startTime - endTime;
                    if ((endTime > startTime) && !transSameDay) timeVal = 86400f - endTime + startTime;
                }
                setTransVal = timeVal/transitionDuration;
            }

            //track current time
            currTime = currentSecond + currentMinute*60 + currentHour*3600;
            if ((transitionDirection == 1.0f) && (currTime <= endTime)) transSameDay = true;
            if ((transitionDirection == -1.0f) && (currTime >= endTime)) transSameDay = true;

            //check for transition end
            endTransition = false;
            if ((transitionDirection == 1.0f) && (currTime >= endTime) && transSameDay) endTransition = true;
            if ((transitionDirection == -1.0f) && (currTime <= endTime) && transSameDay) endTransition = true;

            if (transitionTime > transitionDuration)
            {
                Debug.Log(transitionTime);
                endTransition = true;
            }

            //END TRANSITION
            if (endTransition)
            {
                useAutoTime = false;
                transitionTime = 0.0f;
                doTransition = false;
                currentHour = setTransHour;
                currentMinute = setTransMinute;
                currentSecond = setTransSecond;

                //Send Callback (optional)
                if (transitionCallback)
                    if (transitionCallbackObject != null)
                        transitionCallbackObject.SendMessage("CaptureTenkokuCallback", SendMessageOptions.DontRequireReceiver);
                transitionCallbackObject = null;
                transitionCallback = false;

                //DO TRANSITION
            }
            else
            {
                useAutoTime = true;
                transitionTime += Time.deltaTime;
                //useTimeCompression = setTransVal*transitionDirection*(Mathf.SmoothStep(0.0f,1.0f,transitionTime/transitionDuration));
                useTimeCompression = setTransVal*transitionDirection;
            }
        }


        //Variables for Unity 5.3+ only
        //#if UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
#if UNITY_5_4_OR_NEWER
        private Vector3 snowPosition = Vector3.zero;

        private ParticleSystem.MinMaxCurve rainCurve;
        private ParticleSystem.MinMaxCurve rainCurveForceX;
        private ParticleSystem.MinMaxCurve rainCurveForceY;
        private ParticleSystem.MinMaxCurve rainCurveFog;
        private ParticleSystem.MinMaxCurve rainCurveFogForceX;
        private ParticleSystem.MinMaxCurve rainCurveFogForceY;
        private ParticleSystem.MinMaxCurve splashCurve;
        private ParticleSystem.MinMaxCurve fogCurve;
        private ParticleSystem.MinMaxCurve fogCurveForceX;
        private ParticleSystem.MinMaxCurve fogCurveForceY;
        private ParticleSystem.MinMaxCurve snowCurve;
        private ParticleSystem.MinMaxCurve snowCurveForceX;
        private ParticleSystem.MinMaxCurve snowCurveForceY;

        private ParticleSystem.EmissionModule rainEmission;
        private ParticleSystem.EmissionModule rainFogEmission;
        private ParticleSystem.EmissionModule splashEmission;
        private ParticleSystem.EmissionModule fogEmission;
        private ParticleSystem.EmissionModule snowEmission;

        private ParticleSystem.ForceOverLifetimeModule rainForces;
        private ParticleSystem.ForceOverLifetimeModule rainFogForces;
        private ParticleSystem.ForceOverLifetimeModule fogForces;
        private ParticleSystem.ForceOverLifetimeModule snowForces;
#endif
    }
}