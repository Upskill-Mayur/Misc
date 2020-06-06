using System;

namespace PracticeDelegates
{
    public class Photo
    {
        public static Photo Load(string photoPath)
        {
            return new Photo();
        }       
    }

    public class PhotoFilter
    {
        public void ApplyContrast(Photo photo)
        {
            System.Console.WriteLine("Contrast applied.");
        }
        public void ApplyBrightness(Photo photo)
        {
            System.Console.WriteLine("Brightness applied.");
        }
        public void ApplySaturation(Photo photo)
        {
            System.Console.WriteLine("Saturation applied.");
        }
    }
    public class PhotoProcessor
    {
        Photo photo = null;
        public delegate void FilterHandler(Photo photo);

        public void DefaultProcess(string path)
        {
            photo = Photo.Load(path);

            PhotoFilter filter = new PhotoFilter();
            PhotoProcessor.FilterHandler filterHandler = filter.ApplyBrightness;
            filterHandler += filter.ApplyContrast;
            filterHandler += filter.ApplySaturation;
            filterHandler(photo);
        }

        public void CustomProcess(FilterHandler customProcessFilterHandler)
        {
            customProcessFilterHandler(photo);
        }

        public void CustomActionProcess(Action<Photo> actionCall)
        {
            actionCall(photo);
        }
    }
}