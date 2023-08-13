using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRM_STT.Core.Data.Contracts;
using TRM_STT.Core.Domain.Models;
using TRM_STT.Core.Services.Interfaces;

namespace TRM_STT.Core.Services
{
    public class GoodService : IGoodService
    {
        private readonly List<string> _wordsToIgnore = new()
        {
            "the", "an", "with", "for", "and", "to", "have", "should", "it"
        };
        
        private readonly IRepository<Good> _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpeechToTextService _speechToTextService;

        public GoodService(IUnitOfWork unitOfWork, ISpeechToTextService speechToTextService)
        {
            _unitOfWork = unitOfWork;
            _speechToTextService = speechToTextService;
            _goodRepository = unitOfWork.GetRepository<Good>();
        }

        public async Task CreateAsync(Good good)
        {
            good.CreatedAt = DateTime.UtcNow;

            _goodRepository.Create(good);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Good>> GetAllAsync()
        {
            var goods = await _goodRepository.GetAllAsync();

            return goods;
        }
        
        public async Task<IEnumerable<Good>> GetAllByAudioAsync(string fileName)
        {
            var text = await _speechToTextService.ConvertAudioFileToTextAsync(fileName);
            var words = GetWordsToSearch(text);

            var goods = await _goodRepository.GetAllAsync();

            var result = GetGoodsByWords(goods, words);

            return result;
        }

        private IEnumerable<string> GetWordsToSearch(string text)
        {
            var result = text
                .Split(' ')
                .Select(word => word.ToLower())
                .Where(word => word.Length > 1 && !_wordsToIgnore.Contains(word))
                .ToList();

            return result;
        }

        private IEnumerable<Good> GetGoodsByWords(IEnumerable<Good> goods, IEnumerable<string> words)
        {
            var result = goods.Select(x => new
            {
                Good = x,
                AlignmentInName = words.Count(word => x.Name.ToLower().Contains(word)),
                AlignmentInDescription = words.Count(word => x.Description.ToLower().Contains(word)),
            })
            .Where(x => x.AlignmentInName > 0 || x.AlignmentInDescription > 0)
            .OrderByDescending(x => x.AlignmentInName)
            .ThenByDescending(x => x.AlignmentInDescription)
            .Select(x => x.Good);

            return result;
        }
    }
}