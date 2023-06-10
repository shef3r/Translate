using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace TranslateBackend
{

    public class Translator
    {

        public async Task<string> GetTranslation(TranslationQuery query)
        {
            var client = new HttpClient();
            Uri uri = new Uri("https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + query.fromCode + "&tl=" + query.toCode + "&dt=t&q=" + System.Web.HttpUtility.UrlEncode(query.translateQuery));
            var result = await client.GetAsync(uri);
            System.Diagnostics.Debug.WriteLine(uri.ToString());
            string json = await result.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("Unexpected error.");
            }
            else if (json.StartsWith("<html"))
            {
                throw new Exception("There was something wrong with your request. Request URL:\n" + uri.ToString());
            }
            else
            {
                string fulltrans = null;
                JArray jArray = JArray.Parse(json);
                string generatedTranslation = null;
                foreach (JToken item in jArray.First())
                {
                    if (item.Type == JTokenType.Array && item[0].Type == JTokenType.String)
                    {
                        string translation = item[0].ToString();
                        generatedTranslation += translation + " ";
                    }
                }
                if (generatedTranslation.EndsWith(" "))
                {
                    generatedTranslation = generatedTranslation.Substring(0, generatedTranslation.Length - 1);
                    return generatedTranslation.Replace("  ", " ");
                }
                else
                {
                    return generatedTranslation.Replace("  ", " ");
                }
            }
        }
    }
}
