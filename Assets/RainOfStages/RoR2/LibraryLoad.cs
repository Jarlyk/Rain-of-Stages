#if THUNDERKIT_CONFIGURED
using BepInEx;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace PassivePicasso.RainOfStages.Shared
{
    [BepInPlugin("com.PassivePicasso.RainOfStages.Shared", "RainOfStages.Shared", "2020.1.0")]
    public class LibraryLoad : BaseUnityPlugin
    {
        public Object[] Assets;

        private void Awake()
        {
            LoadAssetBundles();
        }

        private void LoadAssetBundles()
        {
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var workingDirectory = Path.GetDirectoryName(assemblyLocation);
            var file = new FileInfo(Path.Combine(workingDirectory, "rosshared.manifest"));
            var directory = file.DirectoryName;
            var filename = Path.GetFileNameWithoutExtension(file.FullName);
            var abmPath = Path.Combine(directory, filename);
            var namedBundle = AssetBundle.LoadFromFile(abmPath);
            Assets = namedBundle.LoadAllAssets();
        }
    }
}
#endif
