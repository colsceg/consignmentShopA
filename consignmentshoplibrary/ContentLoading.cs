using System.Collections;
using System.IO;
using System.Reflection;


namespace ConsignmentShopLibrary
{
    public static class ContentLoading
    {
        public static ArrayList GetTextContent(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string NAME = $"ConsignmentShopLibrary.Attributes.{filename}";

            using (Stream stream = assembly.GetManifestResourceStream(NAME))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    ArrayList tempArray = new ArrayList();

                    while (reader.Peek() != -1)
                    {
                        tempArray.Add(reader.ReadLine());
                    }
                    return tempArray;
                }
            }
        }
    }
}
