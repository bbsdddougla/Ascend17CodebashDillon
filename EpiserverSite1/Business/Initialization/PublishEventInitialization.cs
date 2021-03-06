﻿using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EpiserverSite1.Business.SearchAnalyzation;
using EpiserverSite1.Models.Media;
using EpiserverSite1.Models.Pages;

namespace EpiserverSite1.Business.Initialization
{

    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class PublishEventInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.PublishingContent += contentEvents_PublishingContent;
        }

        void contentEvents_PublishingContent(object sender, EPiServer.ContentEventArgs e)
        {
            var page = e.Content as StandardPage;

            if (page != null)
            {
                var analyzer = ServiceLocator.Current.GetInstance<ITextServiceAnalyzer>();
                AnalyzeText(analyzer, page);
                return;
            }

            var image = e.Content as ImageFile;

            if (image != null)
            {
                var analyzer = ServiceLocator.Current.GetInstance<IImageAnalyzerService>();
                AnalyzeImage(analyzer, image);
            }
        }

        private void AnalyzeImage(IImageAnalyzerService analyzer, ImageFile image)
        {
            var results = analyzer.AnalyzeImage(image);

            image.MetadataText = results;
        }

        private void AnalyzeText(ITextServiceAnalyzer analyzer, StandardPage page)
        {
            var document = CreateDocument(page);

            var results = analyzer.AnalyzeText(document);

            page.MetadataText = results;
        }

        public ISearchDocument CreateDocument(StandardPage page)
        {
            var document = new SearchDocument();

            document.Id = page.ContentLink.ID;
            document.Language = page.Language.TwoLetterISOLanguageName;
            document.Text = page.MainBody.ToHtmlString();

            return document;
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.PublishingContent -= contentEvents_PublishingContent;
        }
    }
}