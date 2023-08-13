using System.IO;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1;
using Microsoft.Extensions.Hosting;
using TRM_STT.Core.Services.Interfaces;

namespace TRM_STT.Core.Services
{
    public class SpeechToTextService : ISpeechToTextService
    {
        private readonly IHostEnvironment _hostingEnvironment;

        public SpeechToTextService(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> ConvertAudioFileToTextAsync(string fileName)
        {
            var speechClient = await SpeechClient.CreateAsync();
            var recognitionConfig = new RecognitionConfig {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                LanguageCode = LanguageCodes.English.UnitedStates,
            };
            
            var audio = await RecognitionAudio.FromFileAsync(Path.Combine($"{_hostingEnvironment.ContentRootPath}/wwwroot", fileName));
            var response = await speechClient.RecognizeAsync(recognitionConfig, audio);
            
            var resultString = new StringBuilder();
            foreach (var result in response.Results) {
                foreach (var alternative in result.Alternatives)
                {
                    resultString.Append(alternative.Transcript);
                }
            }
            
            return resultString.ToString();
        }
    }
}