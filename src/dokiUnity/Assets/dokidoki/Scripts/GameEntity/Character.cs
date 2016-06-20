using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using dokidoki.dokiScriptSetting;
using Action = dokidoki.dokiScriptSetting.Action;


namespace dokidoki.dokiUnity {
    /// <summary>
    /// Character is a GameObject, represents a character in game, used to take a series actions to tell game story.
    /// Those actions contain: RoleAction, PostureAction, TextAction, VoiceAction, MoveAction.
    /// Character could show appearence, speak voice, show psychological descriptions that are texts without voice, move around.
    /// Character GameObject itseft is a child of World GameObject
    /// Character has childs as Bubble board.
    /// </summary>
    public class Character : MonoBehaviour {
        /// <summary>
        /// CharacterData records status for saving and loading
        /// </summary>
        public CharacterData characterData = new CharacterData();

        //Effect related GameObjects
        /// <summary>
        /// worldControl is a GameObject to control all things in the game like world, characters and UIs. Here it is used to read the worldControl modes.
        /// </summary>
        public GameObject worldControl;
        /// <summary>
        /// dialogContent is a GameObject to show dialog text on dialog window, which is a child of UI Canvas
        /// </summary>
        public GameObject dialogContent;

        private IEnumerator moving = null;
        private System.DateTime movingStartTime;

        /// <summary>
        /// Character takes role action to change character infomation, like this character type, character name
        /// </summary>
        /// <param name="roleAction">Action tagged as weather, which contains the parameters for weather setting</param>
        public void takeRoleAction(Action roleAction) {
            if (roleAction.parameters.TryGetValue(ScriptKeyword.TYPE, out characterData.roleType)) {

            } else {
                characterData.roleType = ScriptKeyword.TYPE_CHARACTER;
            }
            if (roleAction.parameters.TryGetValue(ScriptKeyword.NAME, out characterData.shownName)) {

            } else {
                characterData.shownName = "???";
            }
        }

        /// <summary>
        /// Character takes posture action to change character appearence, like this character cloth, character face expression, gestures.
        /// Anyway, this action is to change the picture this character shows
        /// </summary>
        /// <param name="postureAction">Action tagged as posture, which contains the parameters for posture setting</param>
        public void takePostureAction(Action postureAction) {
			//Check anchor value
			string anchorStringValue = "";
			if (postureAction.parameters.TryGetValue(ScriptKeyword.ANCHOR, out anchorStringValue)) {

			} else {
				anchorStringValue = "(0.5, 0.5)";
			}

			anchorStringValue = anchorStringValue.Replace(ScriptKeyword.PARENTHESE_LEFT, string.Empty);
			anchorStringValue = anchorStringValue.Replace(ScriptKeyword.PARENTHESE_RIGHT, string.Empty);
			anchorStringValue = anchorStringValue.Replace(@"\s+", string.Empty);
			string[] anchorStrings = anchorStringValue.Split(ScriptKeyword.COMMA.ToCharArray());
			this.characterData.anchorX = float.Parse(anchorStrings[0]);
			this.characterData.anchorY = float.Parse(anchorStrings[1]);

			//check zoom value
			string zoomValue = "";
			float zoom = 1f;
			if(postureAction.parameters.TryGetValue(ScriptKeyword.ZOOM, out zoomValue)){
				zoom = float.Parse (zoomValue);
			}
			this.characterData.zoom = zoom;

			string live2dValue = "";
			if (postureAction.parameters.TryGetValue (ScriptKeyword.LIVE2D, out live2dValue)) {
				this.characterData.postrueSrc = null;
				this.characterData.postureLive2D = live2dValue;
				//Use live2d posture
				this.GetComponent<SpriteRenderer>().sprite = null;
				//find all live2d file resources
				Live2DSimpleModel live2DSimpleModel = this.GetComponent<Live2DSimpleModel>();
				Debug.Log ("live2DSimpleModel="+live2DSimpleModel.enabled);
				Object[] live2DFiles = Resources.LoadAll(FolderStructure.CHARACTERS + FolderStructure.POSTURES + live2dValue);
				TextAsset mocFile = null;
				TextAsset physicsFile = null;
				List<Texture2D> textureFiles = new List<Texture2D>();
				foreach (Object live2DFile in live2DFiles) {
					Debug.Log ("live2DFile="+live2DFile.name);
					//scriptNames.Add(Path.GetFileNameWithoutExtension(scriptObject.name));
					if (live2DFile.name.EndsWith (ScriptKeyword.LIVE2D_MOC_EXTENSION)) {
						mocFile = live2DFile as TextAsset;
					} else if(live2DFile.name.EndsWith(ScriptKeyword.LIVE2D_PHYSICS_EXTENSION)) {
						physicsFile = live2DFile as TextAsset;
					}else if( live2DFile.name.Contains(ScriptKeyword.LIVE2D_TEXTURE_EXTENSION)){
						textureFiles.Add (live2DFile as Texture2D);
					}
				}
				Debug.CheckResources (live2dValue, mocFile);
				Debug.CheckResources (live2dValue, physicsFile);
				Debug.CheckResources (live2dValue, textureFiles);

				live2DSimpleModel.mocFile = mocFile;
				live2DSimpleModel.physicsFile = physicsFile;
				live2DSimpleModel.textureFiles = textureFiles.ToArray();
				live2DSimpleModel.zoom = this.characterData.zoom;
				live2DSimpleModel.enabled = true;
			} else {
				//Use normal image posture
				this.GetComponent<Live2DSimpleModel>().enabled = false;
				this.characterData.postrueSrc = postureAction.parameters[ScriptKeyword.SRC];
				this.characterData.postureLive2D = null;
				//read pixelsPerUnit from user setting
                /*
				Sprite postureSpriteOriginal = Resources.Load<Sprite>(FolderStructure.CHARACTERS + FolderStructure.POSTURES + postureAction.parameters[ScriptKeyword.SRC]);
				Debug.CheckResources (postureAction.parameters[ScriptKeyword.SRC], postureSpriteOriginal);
				float pixelsPerUnity = postureSpriteOriginal.pixelsPerUnit;
                */
                float pixelsPerUnity = 100 / characterData.zoom;
				//create the sprite again for setting the pivot from the script
				Texture2D postureTexture2D = Resources.Load<Texture2D>(
					FolderStructure.CHARACTERS + FolderStructure.POSTURES + postureAction.parameters[ScriptKeyword.SRC]);
				Sprite postureSprite = Sprite.Create(postureTexture2D
					, new Rect(0, 0, postureTexture2D.width, postureTexture2D.height)
					, new Vector2(characterData.anchorX, characterData.anchorY)
					, pixelsPerUnity);
				this.GetComponent<SpriteRenderer>().sprite = postureSprite;
			}
        }

        /// <summary>
        /// Character takes text action to show character's psychological descriptions, mainly it is used for first-view character
        /// </summary>
        /// <param name="textAction">Action tagged as text, which contains the parameters for text setting</param>
        /// <returns>Returns end of the time at which this action is supposed over</returns>
        public float takeTextAction(Action textAction) {
            if (dialogContent == null) {
                Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
                Application.Quit();
            }
            //dialogContent.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
            dialogContent.GetComponent<DialogManager>().writeOnDialogBoard(characterData.shownName, textAction.parameters[ScriptKeyword.CONTENT], "");
            float nextAutoClickTime = Time.realtimeSinceStartup;
            nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * (PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR) + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;
            return nextAutoClickTime;
        }

        /// <summary>
        /// Character takes text action to speack something with or without audio, be careful that World GameObject should not speak voice
        /// </summary>
        /// <param name="voiceAction">Action tagged as voice, which contains the parameters for voice setting</param>
        /// <returns>Returns end of the time at which this action is supposed over</returns>
        public float takeVoiceAction(Action voiceAction) {
            string voiceSrc = "";

            //Play the voice audio
            float nextAutoClickTimeVoice = Time.realtimeSinceStartup;
            if (voiceAction.parameters.TryGetValue(ScriptKeyword.SRC, out voiceSrc)) {
                AudioClip voiceAudioClip = Resources.Load(FolderStructure.CHARACTERS + FolderStructure.VOICES + voiceSrc) as AudioClip;
				Debug.CheckResources (voiceSrc, voiceAudioClip);
				this.GetComponent<AudioSource>().clip = voiceAudioClip;
                this.GetComponent<AudioSource>().Play();
                nextAutoClickTimeVoice = nextAutoClickTimeVoice + this.GetComponent<AudioSource>().clip.length + (PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR);
            }

            //Similar to the takeTextAction
            if (dialogContent == null) {
                Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
                Application.Quit();
            }

            //dialogContent.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
            dialogContent.GetComponent<DialogManager>().writeOnDialogBoard(characterData.shownName, voiceAction.parameters[ScriptKeyword.CONTENT], voiceSrc);

            if (this.characterData.roleType == ScriptKeyword.TYPE_CHARACTER && worldControl.GetComponent<WorldControl>().getDialogMode() == GameConstants.BUBBLE) {
                this.GetComponentInChildren<BubbleManager>().writeOnBubbleBoard(characterData.shownName
                                                                                , voiceAction.parameters[ScriptKeyword.CONTENT], voiceSrc
                                                                                , new Vector2(characterData.positionX, characterData.positionY));
            } else {
                this.GetComponentInChildren<BubbleManager>().hide();
            }

            float nextAutoClickTimeText = Time.realtimeSinceStartup;
            nextAutoClickTimeText = nextAutoClickTimeText + voiceAction.parameters[ScriptKeyword.CONTENT].Length * (PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR) + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;

            //Debug.Log("AudioClip length: " + this.GetComponent<AudioSource>().clip.length);
            return Mathf.Max(nextAutoClickTimeVoice, nextAutoClickTimeText);
        }

        /// <summary>
        /// Character takes move action to move arround in the World, exactly arround the background GameObject
        /// </summary>
        /// <param name="moveAction">Action tagged as voice, which contains the parameters for voice setting</param>
        public void takeMoveAction(Action moveAction) {
            string positionValue = moveAction.parameters[ScriptKeyword.POSITION];
            if (positionValue == null || positionValue.Equals("")) {
                return;
            }
            if (positionValue.Equals(ScriptKeyword.POSITION_CENTER)) {
                characterData.positionX = 0.5f;
                characterData.positionY = 0f;
                characterData.positionZ = 0f;
            } else if (positionValue.Equals(ScriptKeyword.POSITION_LEFT)) {
                characterData.positionX = 0.2f;
                characterData.positionY = 0f;
                characterData.positionZ = 0f;
            } else if (positionValue.Equals(ScriptKeyword.POSITION_RIGHT)) {
                characterData.positionX = 0.8f;
                characterData.positionY = 0f;
                characterData.positionZ = 0f;
            } else {
                //the position is written in (x.xxx, x.xxx, x.xxx)
                positionValue = positionValue.Replace(ScriptKeyword.PARENTHESE_LEFT, string.Empty);
                positionValue = positionValue.Replace(ScriptKeyword.PARENTHESE_RIGHT, string.Empty);
                positionValue = positionValue.Replace(@"\s+", string.Empty);
                string[] posString = positionValue.Split(ScriptKeyword.COMMA.ToCharArray());
                characterData.positionX = float.Parse(posString[0]);
                characterData.positionY = float.Parse(posString[1]);
                characterData.positionZ = float.Parse(posString[2]);
            }

			if(this.characterData.postureLive2D != null){
				float width = this.GetComponent<Renderer> ().bounds.size.x;
				float height = this.GetComponent<Renderer> ().bounds.size.y;
				Debug.Log ("width="+width);
				Debug.Log ("height="+height);
			}else if(this.characterData.postrueSrc != null){
				//float backgroundWidth = worldControl.GetComponent<WorldControl>().world.GetComponent<World>().background.GetComponent<Renderer>().bounds.extents.x;
				//float backgroundHeight = worldControl.GetComponent<WorldControl>().world.GetComponent<World>().background.GetComponent<Renderer>().bounds.extents.y;
				//Debug.Log("characterData.posX = " + characterData.positionX + ", characterData.posY = " + characterData.positionY + ", characterData.posZ = " + characterData.positionZ);
				Vector3 characterScreenToWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(characterData.positionX, characterData.positionY
					, Mathf.Abs(Camera.main.transform.position.z)));

                //Here do the trajectory move
                string type;
                if(!moveAction.parameters.TryGetValue(ScriptKeyword.TYPE, out type)){

                }
                if (type != null) {
                    //string durationString;
                    //if (!moveAction.parameters.TryGetValue(ScriptKeyword.TYPE, out durationString)) {

                    //}
                    movingStartTime = System.DateTime.Now;
                    if (moving != null) {
                        StopCoroutine(moving);
                    }
                    //Vector3 direction = characterScreenToWorldPoint - transform.localPosition;
                    moving = Moving(transform.localPosition, characterScreenToWorldPoint, 1f, type);
                    StartCoroutine(moving);
                } else {
                    this.transform.localPosition = characterScreenToWorldPoint;
                }
			}
        }

        IEnumerator Moving(Vector3 start, Vector3 end, float duration, string type) {
            while (true) {
                System.DateTime now = System.DateTime.Now;
                float t = (float)(now - movingStartTime).TotalMilliseconds / 1000f;
                if(t<duration){
                    //this.transform.localPosition = position - direction * (1f - t / duration);
                    transform.localPosition = Trajectory.Sin(start, end, t, duration);
                }
                yield return new WaitForSeconds(0.001f);
            }
        }

        /// <summary>
        /// Character takes other actions you defined
        /// </summary>
        /// <param name="otherAction">Action tagged as other, which contains the parameters you defined</param>
        public void takeOtherAction(Action otherAction) { 
            
        }

        /// <summary>
        /// Character game entity load data from saving data (on the disk)
        /// </summary>
        /// <param name="characterData">characterData is the serialized data on the disk</param>
        public void loadData(CharacterData characterData) {
            this.characterData = characterData;

            Debug.Log("characterData: " + characterData.id + ", " + characterData.postrueSrc + ", " + characterData.roleType + ", " + characterData.shownName);

            Action loadedRoleAction = new Action(ScriptKeyword.ROLE, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE, characterData.roleType},
            {ScriptKeyword.NAME, characterData.shownName}
        });
            this.takeRoleAction(loadedRoleAction);
            if (characterData.postrueSrc != null && !characterData.postrueSrc.Equals("")) {
                Action loadedPostureAction = new Action(ScriptKeyword.POSTURE, new Dictionary<string, string>(){
                {ScriptKeyword.SRC, characterData.postrueSrc}
                });
                this.takePostureAction(loadedPostureAction);
            }
            Action loadedMoveAction = new Action(ScriptKeyword.MOVE, new Dictionary<string, string>(){
            {ScriptKeyword.POSITION, ScriptKeyword.POSITION_CENTER},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        });
            this.takeMoveAction(loadedMoveAction);
        }
    }
}