using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BSTimestamp
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class BSTimestampController : MonoBehaviour
    {
        public static BSTimestampController Instance { get; private set; }

        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (Instance != null)
            {
                Plugin.Log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            Instance = this;
            Plugin.Log?.Debug($"{name}: Awake()");
        }

        TextMeshPro text;
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
        
            var rect = gameObject.AddComponent<RectTransform>();
            rect.sizeDelta = new Vector2(2000, 500);
            rect.localScale = Vector3.one * 0.1f;
            text = gameObject.AddComponent<TextMeshPro>();
            text.text = "the text has been initialized!";
            text.transform.position = Vector3.forward * 3 + Vector3.up * 0.7f;
            text.alignment = TextAlignmentOptions.Center;

            text.color = Color.red;
            text.autoSizeTextContainer = true;
        }

        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private void Update()
        {

        }

        int last_fps = 0;
        int last_sec = 0;
        int current_fps = 0;
        int total_frame = 0;
        private void OnRenderObject()
        {
            var time = DateTime.Now;
            if(time.Second != last_sec)
            {
                last_sec = time.Second;
                last_fps = current_fps;
                current_fps = 1;
            }
            else
            {
                current_fps++;
            }
            total_frame++;
            var s = time.Second.ToString();
            while (s.Length < 2)
                s = "0" + s;
            var ms = time.Millisecond.ToString();
            while (ms.Length < 3)
                ms = "0" + ms;
            var fpss = last_fps.ToString();
            while(fpss.Length < 3)
                fpss = "0" + fpss;
            text.text = time.Hour + "h " + time.Minute + "m " + s + "s " + ms + "ms \ntext-render-fps:" + fpss + " frame:" + total_frame;
        }

        /// <summary>
        /// Called every frame after every other enabled script's Update().
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// Called when the script becomes enabled and active
        /// </summary>
        private void OnEnable()
        {

        }

        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {

        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            if (Instance == this)
                Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
}
