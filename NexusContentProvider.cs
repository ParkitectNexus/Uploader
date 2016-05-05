using UnityEngine;

namespace NexusUploader
{
    class NexusContentProvider : IContentProvider
    {
        public void store(ContentProviderItem contentProviderItem, ContentProviderTransactionFinishedHandler storeFinishedHandler)
        {
            Uploader.Instance.OnUploadComplete += item =>
            {
                storeFinishedHandler(this, item, true, "Uploaded");

                Uploader.Instance.OnUploadComplete = null;
            };

            Uploader.Instance.Upload(contentProviderItem);
        }

        public void unsubscribe(ContentProviderItem contentProviderItem, ContentProviderTransactionFinishedHandler unsubscribeFinishedHandler)
        {
            unsubscribeFinishedHandler(this, contentProviderItem, true, "Can't unsubscribe yet from ParkitectNexus.");
        }

        public RectTransform getProviderSpecificInfoPanel()
        {
            return new RectTransform();
        }

        public string getProviderName()
        {
            return "ParkitectNexus";
        }

        public Texture2D getProviderIcon()
        {
            return new Texture2D(32, 32);
        }
    }
}
