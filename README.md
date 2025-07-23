# Unity3D-TextureAtlasSlicer
  
This project originally isn't mine, but I modified it to solve some problems with unity automatic sprite compression. 
This project refers to https://github.com/toxicFork/Unity3D-TextureAtlasSlicer
  
Simple and fast tool to import XML spritesheets (TextureAtlas) into Unity3D!

![Preview Image](https://i.imgur.com/LhmcMjX.png)

Works very well to import [Kenney's sprite assets](http://opengameart.org/users/kenney)!

## Usage
- Copy this folder to your project's assets directory, or just use the latest .unitypackage file from the [Github project's releases](https://github.com/toxicFork/Unity3D-TextureAtlasSlicer/releases), or the [Unity3D asset store](https://www.assetstore.unity3d.com/en/#!/content/36103)!
- You can now use the Assets/Slice Sprite Using XML button!
- If your sprite is smaller than xml (because of Unity compression system) try use first Assets/Fix Texture Import Settings For XML button.
- After these actions try again slice your sprite sheet. 
- This will open a window.
- Select any sprite asset in your Project window
- If it has a XML file with the same name next to it, that XML file will automatically be selected
- Otherwise, drag-drop the XML file reference onto the XML Source field in the Texture Atlas Slicer window
- Configure the pivot settings and if it necessary (because of Unity automatic sprite compression) configure the padding Parameter (in pixels). 
- Hit Slice!
- Enjoy! :D
