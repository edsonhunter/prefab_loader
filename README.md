How this work?
- Set your prefabs
- Make sure your script extends BaseObject
- Hit play (the assetBundle will automatically build)
- Check the Spawner object into the scene.
- Drag and drop any prefab into the "GO" field
- If it exists in the AssetBundle, it will load and instantiate.
- Try change it's folder or it's name.
- It will keep showing the prefab, loading if necessary of swapping for one already loaded.
- Whenever you change play state, the assetBundle will be loaded again and save your changes
