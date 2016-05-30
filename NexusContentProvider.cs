using UnityEngine;

namespace NexusUploader
{
    class NexusContentProvider : IContentProvider
    {
        public void store(ContentProviderItem contentProviderItem, ContentProviderTransactionFinishedHandler storeFinishedHandler)
        {
            Uploader.Instance.OnUploadComplete += item =>
            {
                storeFinishedHandler(this, item.gameContent, true, "Uploaded");

                Uploader.Instance.OnUploadComplete = null;
            };

            Uploader.Instance.Upload(contentProviderItem);
        }

        public void unsubscribe(AbstractGameContent gameContent, ContentProviderTransactionFinishedHandler unsubscribeFinishedHandler)
        {
            unsubscribeFinishedHandler(this, gameContent, true, "Can't unsubscribe yet from ParkitectNexus.");
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
