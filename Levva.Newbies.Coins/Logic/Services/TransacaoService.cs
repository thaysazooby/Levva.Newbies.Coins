using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Logic.Dtos;
using Levva.Newbies.Coins.Logic.Interfaces;

namespace Levva.Newbies.Coins.Logic.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _repository;
        private readonly IMapper _mapper;
        public TransacaoService(ITransacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(TransacaoDto transacao)
        {
            var _transacao = _mapper.Map<Transacao>(transacao);
            _repository.Create(_transacao);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public TransacaoDto Get(int Id)
        {
            var transacao = _mapper.Map<TransacaoDto>(_repository.Get(Id));
            return transacao;
        }

        public List<TransacaoDto> GetAll()
        {
            var transacoes = _mapper.Map<List<TransacaoDto>>(_repository.GetAll());
            return transacoes;
        }

        public void Update(TransacaoDto transacao)
        {
            var _transacao = _mapper.Map<Transacao>(transacao);
            _repository.Update(_transacao);
        }
    }
}
