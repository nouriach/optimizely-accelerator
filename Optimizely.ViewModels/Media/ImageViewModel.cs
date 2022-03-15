namespace Optimizely.ViewModels.Media
{
    public class ImageViewModel
    {
        public string AltText { get; set; }
        public ImageDataViewModel Mobile { get; set; }
        public ImageDataViewModel Tablet { get; set; }
        public ImageDataViewModel Desktop { get; set; }
        public ImageDataViewModel LargeDesktop { get; set; }
    }
}
