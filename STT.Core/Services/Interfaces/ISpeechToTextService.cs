using System.Collections.Generic;
using System.Threading.Tasks;

namespace TRM_STT.Core.Services.Interfaces
{
    public interface ISpeechToTextService
    {
        Task<string> ConvertAudioFileToTextAsync(string fileName);
    }
}