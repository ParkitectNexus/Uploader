using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using UnityEngine;

namespace NexusUploader
{
    class Uploader : MonoBehaviour
    {
        public delegate void UploadComplete(ContentProviderItem item);

        public UploadComplete OnUploadComplete;

        public static Uploader Instance;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                ContentProviderManager.Instance.registerContentProvider(new NexusContentProvider());
            }
        }

        public void Upload(ContentProviderItem item)
        {
            StartCoroutine(UploadToNexus(item));
        }

        public IEnumerator UploadToNexus(ContentProviderItem item)
        {
            // Create a Web Form
            WWWForm form = new WWWForm();

            form.AddBinaryData("resource", File.ReadAllBytes(item.getLocation()), System.IO.Path.GetFileName(item.getLocation()), "image/png");
            
            WWW w = new WWW("http://parkitectnexus.com/api/assets/manage/upload-asset", form.data, form.headers);

            yield return w;
            if (!string.IsNullOrEmpty(w.error))
            {
                print(w.text);
            }
            
            if (SteamManager.Initialized)
            {
                SteamFriends.ActivateGameOverlayToWebPage(w.text);
            }
            else
            {
                Application.OpenURL(w.text);
            }

            if (OnUploadComplete != null)
            {
                OnUploadComplete(item);
            }
        }
    }
}
