using UnityEditor;
using UnityEngine;

public class DisableTextureCompression
{
    [MenuItem("Assets/Fix Texture Import Settings For XML", false, 1000)]
    public static void FixTextureImportSettings()
    {
        var textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);

        if (textures.Length == 0)
        {
            Debug.LogWarning("⚠️ No Texture2D assets selected.");
            return;
        }

        foreach (var texture in textures)
        {
            var path = AssetDatabase.GetAssetPath(texture);
            var importer = AssetImporter.GetAtPath(path) as TextureImporter;

            if (importer == null)
            {
                Debug.LogWarning($"⚠️ Skipped (not a TextureImporter): {path}");
                continue;
            }

            Debug.Log($"🔧 Processing: {path}");

            // Базовые настройки
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.maxTextureSize = 8192;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.npotScale = TextureImporterNPOTScale.None;
            importer.alphaIsTransparency = true;

#if UNITY_2021_1_OR_NEWER
            // Только если поддерживается
            var type = typeof(TextureImporter);
            var resizeProperty = type.GetProperty("resizeAlgorithm");
            if (resizeProperty != null)
            {
                // Enum значение 0 соответствует TextureResizeAlgorithm.None
                resizeProperty.SetValue(importer, System.Enum.ToObject(resizeProperty.PropertyType, 0), null);
                Debug.Log("🟢 Set resizeAlgorithm = None");
            }
#endif

            // Применение
            importer.SaveAndReimport();

            // Подтверждение
            var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (tex != null)
            {
                Debug.Log($"✅ Done: {path}\n   → Actual Size: {tex.width}x{tex.height}");
            }
            else
            {
                Debug.LogWarning($"❌ Failed to reload texture at: {path}");
            }
        }
    }
}
