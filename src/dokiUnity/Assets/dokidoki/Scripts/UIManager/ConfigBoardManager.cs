using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace dokidoki.dokiUnity {
    /// <summary>
    /// ConfigBoardManager manages the ConfigBoard.
    /// ConfigBoardManager could read player's game settings from PlayerPrefs when game starts up.
    /// </summary>
    public class ConfigBoardManager : MonoBehaviour {

        /// <summary>
        /// Pointer to screenModeDropdown GameObject
        /// </summary>
        public Dropdown screenModeDropdown;
        /// <summary>
        /// Pointer to dialogModeDropdown GameObject
        /// </summary>
        public Dropdown dialogModeDropdown;
        /// <summary>
        /// Pointer to bgmVolumeSlider GameObject
        /// </summary>
        public Slider bgmVolumeSlider;
        /// <summary>
        /// Pointer to seVolumeSlider GameObject
        /// </summary>
        public Slider seVolumeSlider;
        /// <summary>
        /// Pointer to voiceVolumeSlider GameObject
        /// </summary>
        public Slider voiceVolumeSlider;
        /// <summary>
        /// Pointer to textSpeedSlider GameObject
        /// </summary>
        public Slider textSpeedSlider;
        /// <summary>
        /// Pointer to autoSpeedSlider GameObject
        /// </summary>
        public Slider autoSpeedSlider;

        /// <summary>
        /// Loads game settings from PlayerPrefs, when game starts up
        /// </summary>
        void Awake() {
            int screenMode = PlayerPrefs.GetInt(GameConstants.CONFIG_SCREEN_MODE, 0);
            int dialogMode = PlayerPrefs.GetInt(GameConstants.CONFIG_DIALOG_MODE, 0);
            float bgmVolume = PlayerPrefs.GetFloat(GameConstants.CONFIG_BGM_VOLUME, 0.5f);
            float seVolume = PlayerPrefs.GetFloat(GameConstants.CONFIG_SE_VOLUME, 0.5f);
            float voiceVolume = PlayerPrefs.GetFloat(GameConstants.CONFIG_VOICE_VOLUME, 0.5f);
            float textSpeed = PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED, 0.5f);
            float autoSpeed = PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED, 0.5f);

            screenModeDropdown.value = screenMode;
            dialogModeDropdown.value = dialogMode;
            bgmVolumeSlider.value = bgmVolume;
            seVolumeSlider.value = seVolume;
            voiceVolumeSlider.value = voiceVolume;
            textSpeedSlider.value = textSpeed;
            autoSpeedSlider.value = autoSpeed;
        }
    }
}
