using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using System.Text.Json;

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

                JsonDocument document = JsonDocument.Parse(json);

                // Get the root element
                JsonElement root = document.RootElement;

                // Get the translations array
                JsonElement translations = root[0];

                // Initialize a string to store the combined translations
                string combinedTranslations = "";

                // Iterate over each translation
                foreach (JsonElement translation in translations.EnumerateArray())
                {
                    // Get the translated sentence
                    string sentence = translation[1].GetString();

                    // Concatenate the sentence to the combinedTranslations string
                    combinedTranslations += sentence + " ";
                }

                // Remove the trailing space
                combinedTranslations = combinedTranslations.Trim();
                return combinedTranslations;
            }
        }
    }
}
