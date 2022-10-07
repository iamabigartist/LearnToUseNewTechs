﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Doozy.Runtime.Common.Utils;
using UnityEditor;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Doozy.Editor.EditorUI.Utils
{
    public static class TextureUtils
    {
        /// <summary> Get a Texture2D found at the target file path </summary>
        /// <param name="filePath"> Target file path </param>
        public static Texture2D GetTexture2D(string filePath) =>
            AssetDatabase.LoadAssetAtPath<Texture2D>(PathUtils.ToRelativePath(filePath));

        /// <summary> Get a sorted (by filename) list of Texture2D for all the .png files found at the target folderPath </summary>
        /// <param name="folderPath"> Target folder path </param>
        public static List<Texture2D> GetTextures2D(string folderPath)
        {
            string[] paths = Directory.GetFiles(folderPath, "*.png"); //get the paths for all the png files in the target folder
            
            Array.Sort(paths);
            
            for (int i = 0; i < paths.Length; i++)
                paths[i] = PathUtils.ToRelativePath(paths[i]);
            
            return paths.Select(AssetDatabase.LoadAssetAtPath<Texture2D>).ToList();
        }

        /// <summary>
        /// Set the textures at the target paths to have the following settings:
        /// <para/> textureType = TextureImporterType.GUI
        /// <para/> mipmapEnabled = true
        /// <para/> filterMode = FilterMode.Trilinear
        /// <para/> textureCompression = TextureImporterCompression.Uncompressed
        /// </summary>
        /// <param name="filePaths"> Example of file path 'Assets/MyFolderName/MyTextureName.png' </param>
        /// <param name="startStopAssetEditing"></param>
        public static void SetTextureSettingsToGUI(IEnumerable<string> filePaths, bool startStopAssetEditing = true)
        {
            if (filePaths == null) return;
            if (startStopAssetEditing) AssetDatabase.StartAssetEditing();
            foreach (string filePath in filePaths)
            {
                SetTextureSettingsToGUI(filePath);
            }
            if (startStopAssetEditing) AssetDatabase.StopAssetEditing();
        }

        /// <summary>
        /// Set the texture at the target path to have the following settings:
        /// <para/> textureType = TextureImporterType.GUI
        /// <para/> mipmapEnabled = true
        /// <para/> filterMode = FilterMode.Trilinear
        /// <para/> textureCompression = TextureImporterCompression.Uncompressed
        /// </summary>
        /// <param name="filePath"> Texture file path 'Assets/MyFolderName/MyTextureName.png' </param>
        public static void SetTextureSettingsToGUI(string filePath)
        {
            filePath = PathUtils.ToRelativePath(filePath);

            var textureImporter = AssetImporter.GetAtPath(filePath) as TextureImporter;
            if (textureImporter == null) return;
            Debug.Assert(textureImporter != null, nameof(textureImporter) + " != null");
            bool requiresImport = false;
            if (textureImporter.textureType != TextureImporterType.GUI)
            {
                textureImporter.textureType = TextureImporterType.GUI;
                requiresImport = true;
            }

            if (textureImporter.mipmapEnabled != true)
            {
                textureImporter.mipmapEnabled = true;
                requiresImport = true;
            }

            if (textureImporter.filterMode != FilterMode.Trilinear)
            {
                textureImporter.filterMode = FilterMode.Trilinear;
                requiresImport = true;
            }

            if (textureImporter.textureCompression != TextureImporterCompression.Uncompressed)
            {
                textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
                requiresImport = true;
            }

            if (!requiresImport) return;
            UnityEngine.Debug.Log($"Importing: {filePath}");
            AssetDatabase.ImportAsset(filePath, ImportAssetOptions.ForceUpdate);
        }

        /// <summary>
        /// Set the texture at the target path to have the following settings:
        /// <para/> textureType = TextureImporterType.Sprite
        /// <para/> spriteImportMode = SpriteImportMode.Multiple
        /// <para/> isReadable = true (Read/Write Enabled)
        /// <para/> spriteMeshType = SpriteMeshType.FullRect
        /// <para/> spriteExtrude = 0
        /// <para/> spriteGenerateFallbackPhysicsShape = false
        /// </summary>
        /// <param name="filePaths"> Example of file path 'Assets/MyFolderName/MySpriteSheetName.png' </param>
        /// <param name="startStopAssetEditing"></param>
        public static void SetTextureSettingsToSpriteSheet(IEnumerable<string> filePaths, bool startStopAssetEditing = true)
        {
            if (filePaths == null) return;
            if (startStopAssetEditing) AssetDatabase.StartAssetEditing();
            foreach (string filePath in filePaths) SetTextureSettingsToSpriteSheet(filePath);
            if (startStopAssetEditing) AssetDatabase.StopAssetEditing();
        }

        /// <summary>
        /// Set the texture at the target path to have the following settings:
        /// <para/> textureType = TextureImporterType.Sprite
        /// <para/> spriteImportMode = SpriteImportMode.Multiple
        /// <para/> isReadable = true (Read/Write Enabled)
        /// <para/> spriteMeshType = SpriteMeshType.FullRect
        /// <para/> spriteExtrude = 0
        /// <para/> spriteGenerateFallbackPhysicsShape = false
        /// </summary>
        /// <param name="filePath"> SpriteSheet file path 'Assets/MyFolderName/MySpriteSheetName.png' </param>
        public static void SetTextureSettingsToSpriteSheet(string filePath)
        {
            if (filePath.StartsWith(Application.dataPath))
                filePath = "Assets" + filePath.Substring(Application.dataPath.Length);

            var textureImporter = AssetImporter.GetAtPath(filePath) as TextureImporter;
            if (textureImporter == null) throw new NullReferenceException($"Could not load TextureImporter for '{filePath}'");

            bool isDirty = false;

            if (textureImporter.textureType != TextureImporterType.Sprite)
            {
                textureImporter.textureType = TextureImporterType.Sprite;
                isDirty = true;
            }

            if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
            {
                textureImporter.spriteImportMode = SpriteImportMode.Multiple;
                isDirty = true;
            }

            if (textureImporter.isReadable == false)
            {
                textureImporter.isReadable = true;
                isDirty = true;
            }

            var textureSettings = new TextureImporterSettings();
            textureImporter.ReadTextureSettings(textureSettings);

            if (textureSettings.spriteMeshType != SpriteMeshType.FullRect)
            {
                textureSettings.spriteMeshType = SpriteMeshType.FullRect;
                isDirty = true;
            }

            if (textureSettings.spriteExtrude != 0)
            {
                textureSettings.spriteExtrude = 0;
                isDirty = true;
            }

            if (textureSettings.spriteGenerateFallbackPhysicsShape)
            {
                textureSettings.spriteGenerateFallbackPhysicsShape = false;
                isDirty = true;
            }

            textureImporter.SetTextureSettings(textureSettings);

            if (!isDirty) return;
            Texture2D asset = AssetDatabase.LoadAssetAtPath<Texture2D>(filePath);
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssetIfDirty(asset);
            AssetDatabase.ImportAsset(filePath, ImportAssetOptions.ForceUpdate);
        }

       
    }
}
