using System.Reflection;

namespace CT.Utility.Helpers
{
    public class MimeMappingWrapper
    {
        static readonly MethodInfo GetMimeMappingMethod;

        static MimeMappingWrapper()
        {
            // dirty trick - Assembly.LoadWIthPartialName has been deprecated

            var fullName = typeof (System.Web.HttpContext).Assembly.FullName;
            var ass = Assembly.Load(fullName);
            var t = ass.GetType("System.Web.MimeMapping");

            GetMimeMappingMethod = t.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        }

        /// <summary>
        /// Returns a MIME type depending on the passed files extension
        /// </summary>
        /// <param name="fileName">File to get a MIME type for</param>
        /// <returns>MIME type according to the files extension</returns>
        public static string GetMimeMapping(string fileName)
        {
            return (string)GetMimeMappingMethod.Invoke(null, new[] { fileName });
        }
    }
}
