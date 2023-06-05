using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace TranslateBackend
{

    public class Translator
    {
        public class TranslationQuery
        {
            public string fromCode;
            public string toCode;
            public string translateQuery;
        }
        public async Task<string> GetTranslation(TranslationQuery query)
        {
            var client = new HttpClient();
            try
            {
                var result = await client.GetAsync(new Uri("https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + query.fromCode + "&tl=" + query.toCode + "&dt=t&q=" + query.translateQuery));
                string[] json = result.Content.ToString().Split('"');
                
                if (json[1] == "initial-scale=1, minimum-scale=1, width=device-width")
                {
                    throw new Exception("There was something wrong with your request or you've been temporairly banned. Please try again.");
                }
                else
                {
                    return json[1];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
