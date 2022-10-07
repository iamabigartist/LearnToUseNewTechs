using System;
using GamesTan;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamesTan {
    [System.Serializable]
    public abstract class SFXAsset : BaseConfig {
        public AudioClip clip;
    }
    
    public abstract class AudioManager : MonoBaseManager<AudioManager> {
        //public AudioClip 
        public AudioSource MusicSource;
        public AudioSource AudioSource;

        private float _VolumeMusic {
            get => MusicSource.volume;
            set => MusicSource.volume = value;
        }

        private float _VolumeAudio {
            get => AudioSource.volume;
            set => AudioSource.volume = value;
        }

        private static string _volumeTagMusic = "_volumeTagMusic";
        private static string _volumeTagAudio = "_volumeTagAudio";

        public override void DoStart() {
            base.DoStart();
            SetVolumeMusic(PlayerPrefs.GetFloat(_volumeTagMusic, 1));
            SetVolumeAudio(PlayerPrefs.GetFloat(_volumeTagAudio, 1));
            AudioSource.loop = false;
            MusicSource.loop = true;
        }

        public void SetVolumeMusic(float percent) {
            PlayerPrefs.SetFloat(_volumeTagMusic, percent);
            _VolumeMusic = percent;
        }

        public void SetVolumeAudio(float percent) {
            PlayerPrefs.SetFloat(_volumeTagAudio, percent);
            _VolumeAudio = percent;
        }


        public static void PlayMusic(int assetId) {
            if (assetId == 0) return;
            var asset = ResourceManager.Instance.LoadConfig<SFXAsset>(assetId);
            if (asset != null && asset.clip != null) Instance._PlayMusic(asset.clip);
        }

        public static void PlayAudio(int assetId) {
            if (assetId == 0) return;
            var asset = ResourceManager.Instance.LoadConfig<SFXAsset>(assetId);
            if (asset != null && asset.clip != null) Instance._PlayAudio(asset.clip);
        }
        
      
        void _PlayAudio(AudioClip clip) {
            if (clip != null && AudioSource != null) {
                AudioSource.clip = clip;
                AudioSource.Play();
            }
        }

        void _PlayMusic(AudioClip clip) {
            if (clip != null && MusicSource != null) {
                MusicSource.Stop();
                MusicSource.clip = clip;
                MusicSource.loop = true;
                MusicSource.Play();
            }
        }
    }
}