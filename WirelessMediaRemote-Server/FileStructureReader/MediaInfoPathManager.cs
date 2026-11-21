namespace Logic
{
    /// <summary>
    /// Class for reading and fetching media file information from selected directories.
    /// </summary>
    public class MediaInfoPathManager
    {
        public static readonly string[] DEFAULT_VIDEO_FILE_EXTENSIONS = ["mp4", "m4p", "m4v", "mkv", "webm", "avi"];

        public static readonly string[] DEFAULT_IMAGE_FILE_EXTENSIONS = ["jpg", "jxl", "jpeg", "png", "gif", "webp", "bmp"];

        /// <summary>
        /// List of extensions used to determine if a file is a video file. 
        /// </summary>
        public string[] VideoFileExtensions { get; set; } = DEFAULT_VIDEO_FILE_EXTENSIONS;

        /// <summary>
        /// List of extensions used to determine if a file is an image file. 
        /// </summary>
        public string[] ImageFileExtensions { get; set; } = DEFAULT_IMAGE_FILE_EXTENSIONS;


    }
}
