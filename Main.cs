using Parkitect.UI;
using UnityEngine;

namespace NexusUploader
{
    public class Main : IMod
    {
        public void onEnabled()
        {
            GameObject go = new GameObject("NexusUploader");

            go.AddComponent<Uploader>();
        }

        public void onDisabled()
        {

        }

        public string Name { get { return "ParkitectNexus Uploader"; } }
        public string Description { get { return "Upload blueprints and parks to ParkitectNexus"; } }
        public string Identifier { get { return "ParkitectNexus@Uploader"; } set { } }
    }
}
