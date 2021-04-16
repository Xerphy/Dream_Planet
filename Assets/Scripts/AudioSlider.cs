namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
    using UnityEngine.Audio;
    using GameCreator.Variables;
    using GameCreator.Core.Hooks;
    using UnityEngine.UI;


    
    [AddComponentMenu("")]
    public class AudioSlider : IAction
    {
        [Space]
        [Tooltip("Place your Music Slider Object Here")]
        public Slider Music;
        [Tooltip("Place your FX Slider Object Here")]
        public Slider FX;

        [Space]
        private float musicLvl;
        private float sfxLvl;

        [Space]    
        [Tooltip("Create you Music Number variable by going to : Game Creator - Preferences - Variables")]
        public string MusicVar = "MyVariableA";
        [Tooltip("Create you FX Number variable by going to : Game Creator - Preferences - Variables")]
        public string FXVar = "MyVariableB";
        
        [Space]
        [Tooltip("Place your Mixer Here, Be sure to Select the Master, hover over the word 'volume' and right click to expose parameters. Above Master you will see Parameters Exposed. Change the name from 'MyExposedParam' to match your Variables : MusicVar and FXVar")]
        public AudioMixer MasterMixer;


        public void SetMusicLvl(float musicLvl)
        {
            MasterMixer.SetFloat(MusicVar, musicLvl);
            
            Debug.Log(musicLvl);
            VariablesManager.SetGlobal(MusicVar, musicLvl);
        }

        public void SetSfxLvl(float sfxLvl)
        {
            MasterMixer.SetFloat(FXVar, sfxLvl);
            
            Debug.Log(sfxLvl);
            VariablesManager.SetGlobal(FXVar, sfxLvl);
        }

        
        public void SetSound()
        {
            MasterMixer.GetFloat(MusicVar, out musicLvl);
            Music.value = musicLvl;

            MasterMixer.GetFloat(FXVar, out sfxLvl);
            FX.value = sfxLvl;

            VariablesManager.GetGlobal("musicLvl");
            VariablesManager.GetGlobal("sfxLvl");

            Debug.Log(sfxLvl);
            Debug.Log(musicLvl);
            
        }



          public override bool InstantExecute(GameObject target, IAction[] actions, int index)
          {

            MasterMixer.GetFloat(MusicVar, out musicLvl);
            Music.value = musicLvl;

            MasterMixer.GetFloat(FXVar, out sfxLvl);
            FX.value = sfxLvl;

            //VariablesManager.SetGlobal("musicLvl", 50);
            //Debug.Log(this.example);
            return true;
          }

#if UNITY_EDITOR
        public static new string NAME = "Audio/AudioSlider";
#endif
    }
}



