namespace Binder.Application.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public PictureType PictureType { get; set; }
    }

    public enum PictureType
    {
        ProfilePhotos,
        Galleries
    }
}