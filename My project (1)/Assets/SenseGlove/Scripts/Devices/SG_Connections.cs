using System.Collections.Generic;
using SenseGlove.Scripts.Calibration;
using UnityEngine;
using UnityEngine.UI;

namespace SenseGlove.Scripts.Devices
{
	/// <summary> Handles SenseGlove connections with SenseCom and/or Android. </summary>
	public class SgConnections : MonoBehaviour
	{
		//----------------------------------------------------------------------------------------------------
		// Member Variables

		/// <summary> Singleton instance of the SG_Connections </summary>
		private static SgConnections _instance = null;

	//	/// <summary> Putting this variable here for now. Need a way to change that in .ini or Build settings. </summary>
	//	private static bool standaloneMode = false;

		/// <summary> If true, Initialization of communication resources was succesful, so we must dispose of it OnApplicationQuit. </summary>
		private static bool _initialized = false;

		/// <summary> a queue of debug messages from SG_Conections, used to show the last few messages from this back-end. </summary>
		private static List<string> _msgQueue = new List<string>();
		/// <summary> The maximum number of messages in the queue. </summary>
		private static int _maxQueue = 5;
		/// <summary> Optional 3D Text element on which to project the last few messages. </summary>
		private static TextMesh _debugElement = null;
		/// <summary> Optional 2D UI element on which to project the last few messages. </summary>
		private static Text _debugUIElement = null;

		/// <summary> Whether or not to load profiles on focus </summary>
		private static bool _loadProfilesOnFocus = true;

		/// <summary> If set to true, we're also upding ConnectionStates. This is mainly relevant to SenseCom, so it's false by default. </summary>
		public static bool AndrCheckConnectionStates = false;

		// Instance Members

		/// <summary> When added into the scene manually, you can assign a 3D text to host any debug messages. </summary>
		public TextMesh debugText;
		/// <summary> When added into the scene manually, you can assign a 2D UI text to host any debug messages. </summary>
		public Text debugUIText;


#if UNITY_ANDROID && !UNITY_EDITOR

		/// <summary> The time in between hardware updates to check for new devices. Set slightly faster than the Update Rate of the Android Library. </summary>
		private static readonly float hardwareUpdateTime = 0.5f; //check for new devices every x amount of seconds

		/// <summary> Internal timer to keep track of the next HardwareTick. </summary>
		private float hwTime = 0;

		/// <summary> The number of available SGDevices in the last tick. </summary>
		private static int lastDevices = 0;

		/// <summary> If true, we should unlink the class during OnApplicationQuit </summary>
		private static bool classLinked = false;

		/// <summary> If 1, we initialized the library, and should therefore dispose during OnApplicationQuit. </summary>
		private static int libraryInit = -1;


		
		//----------------------------------------------------------------------------------------------------
		// Data Updates

#endif

		/// <summary> If true, an instance of SG_Connections exists within the scene. </summary>
		public static bool ExistsInScene
		{
			get { return _instance != null; }
		}


		//----------------------------------------------------------------------------------------------------
		// Initalization / Disposing of Android Resources.

		/// <summary> Initialized the Android Library is we haven't already </summary>
		/// <remarks> This function could be called every time we switch scenes, and thatshouldn't break things. </remarks>
		private static void Andr_TryInitialize()
		{
#if UNITY_ANDROID && !UNITY_EDITOR
			
#endif
		}

		/// <summary> Disposes of the Android Library if we haven't already. </summary>
		private static void Andr_TryDispose()
		{
#if UNITY_ANDROID && !UNITY_EDITOR

#endif
		}


		/// <summary> Utility method to log to Unity, but also to write the last few messages to a 3D text in the scene. </summary>
		/// <param name="message"></param>
		public static void Log(string message)
        {
			Debug.Log("[SenseGlove] " + message);

			if (_msgQueue.Count + 1 > _maxQueue) { _msgQueue.RemoveAt(0); }
			_msgQueue.Add(message);

			if (_debugElement != null || _debugUIElement != null)
            {
				string msg = "";
				for (int i=0; i<_msgQueue.Count; i++)
                {
					msg += _msgQueue[i];
					if (i < _msgQueue.Count - 1) { msg += "\r\n"; } 
                }
				if (_debugElement != null) { _debugElement.text = msg; }
				if (_debugUIElement != null) { _debugUIElement.text = msg; }
            }
        }



		/// <summary> Create a new instance of SG_Connection in the Scene, if we don't have on e yet. </summary>
		public static void SetupConnections()
        {
			//Log("Ensuring we have some form of connections available to us!");
			if (_instance == null)
            {
				GameObject connectionObj = new GameObject("[SG Connections]");
				//Log("Created a new instance!");
				_instance = connectionObj.AddComponent<SgConnections>();
            }
        }

		/// <summary> Initialize the SenseGlove back-end, be it SenseCom or Android Class wrappers </summary>
		protected static void Initialize()
        {
			if (!_initialized)
			{
				_initialized = true;
				
				if (SGCore.Library.GetBackEndType() == SGCore.Library.BackEndType.AndroidStrings)
                {
					Log("Initalizing AndroidStrings");
					Andr_TryInitialize();
				}
				else
                {
					Log("Initalizing SenseCom");
					if (!SGCore.SenseCom.ScanningActive()) //TODO: Standalone Mode?
                    {
						if (SGCore.SenseCom.StartupSenseCom())
                        {
							Log("Started up SenseCom.");
						}
						else
                        {
							Log("SenseCom is not currently running. You won't be able to communicate with your glove(s) until it is running.");
						}
					}
                }
			}
			else
            {
				//Log("Already initialized a scene before this one.");
            }
        }

		/// <summary> Dispose of any Android resources. </summary>
		protected static void Dispose()
        {
			if (_initialized)
			{
				_initialized = false;
				if (SGCore.Library.GetBackEndType() == SGCore.Library.BackEndType.AndroidStrings)
				{
					Andr_TryDispose();
					Log("Disposed Communications (Standalone modes only)");
				}
			}
			else
            {
				//Log("We never initialized, so we don't have to dispose either");
            }
		}


		//----------------------------------------------------------------------------------------------------
		// Monobehaviour

		void Awake()
		{
			if (_instance == null) //when created and in the scene, be sure to add one of these.
			{
				//Log("Linked SenseGlove Connections to " + this.name);
				_instance = this;
				_debugElement = this.debugText;
				_debugUIElement = this.debugUIText;
				Initialize(); //initialized me!
			}
		}


		void OnDestroy() //called after OnApplicationQuit for some insane reason.
        {
			if (_instance ==  this)
            {
				//Log("Unlinked SenseGlove Connections from " + this.name);
				_debugElement = null;
				_debugUIElement = null;
				_instance = null; //clear my refernce to the instance, so another can take its place.
            }
        }


		void OnApplicationQuit() //is called before OnDestory
        {
			if (_instance == this)
			{
				Dispose();
			}
        }

		//Fires when tabbing in / out of this application
		void OnApplicationFocus(bool hasFocus)
		{
			if (hasFocus && _loadProfilesOnFocus)
            {
				//Debug.Log("Reloaded SenseGlove Profiles from disk...");
				SG_HandProfiles.TryLoadFromDisk(); //reload profiles. Done here because this script is always there when using SenseGlove scripts.
            }
		}

		void Update()
        {
#if UNITY_ANDROID && !UNITY_EDITOR

#endif
		}

	}

}