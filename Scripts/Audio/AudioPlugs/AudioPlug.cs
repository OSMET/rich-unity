﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    public abstract class AudioPlug : ScriptableObject
    {
        public abstract void Play(AudioSource audioSource);

        protected static void Play(AudioSource audioSource, AudioClip audioClip, float volume, float pitch)
        {
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;

            audioSource.Play();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioPlug), true)]
    public class AudioPlugEditor : Editor
    {
        [SerializeField] 
        private AudioSource previewAudioSource;

        public void OnEnable()
        {
            previewAudioSource = EditorUtility
                .CreateGameObjectWithHideFlags("PreviewAudioSource", HideFlags.HideAndDontSave, typeof(AudioSource))
                .GetComponent<AudioSource>();
        }

        public void OnDisable()
        {
            DestroyImmediate(previewAudioSource.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
            if (GUILayout.Button("Preview"))
            {
                ((AudioPlug) target).Play(previewAudioSource);
            }

            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}