using AutoMapper;
using WB.WAPP.SEG.Entities;
using WB.WAPP.SEG.VModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WB.WAPP.SEG.Business.Repositories;

namespace WB.WAPP.SEG.Business
{
    public class ParameterBusiness: IParameterBusiness
    {
        private readonly IGenericRepository<Parameter> parameterRepository;
        private readonly IMapper mapper;

        public ParameterBusiness(
            IGenericRepository<Parameter> parameterRepository , 
            IMapper mapper
        )
        {
            this.parameterRepository = parameterRepository;
            this.mapper = mapper;
        }

        public IEnumerable<VParameter> Get(VRequestParams vRequestParams)
        {
            var query = parameterRepository.Get();
            var count = query.Count();
            

            if(vRequestParams.Page!= null && vRequestParams != null)
            {
                return mapper.Map<IEnumerable<VParameter>>(
                    query.Skip(vRequestParams.Page.Value).Take(vRequestParams.Limit.Value).ToList()
                );
            }

            return mapper.Map<IEnumerable<VParameter>>(query.ToList());
        }

        public VParameter Get(int id)
        {
            return mapper.Map<VParameter>(parameterRepository.GetByID(id));
        }

        public VParameter Insert(VParameter vParameter)
        {
            var parameter = mapper.Map<Parameter>(vParameter);
            parameter.UserCreated = "Test";
            parameter.Id = 0;

            parameterRepository.Insert(parameter).Save();
            
            return mapper.Map<VParameter>(parameter);
        }

        public VParameter Update(VParameter vParameter)
        {
            var parameter = mapper.Map<Parameter>(vParameter);
            parameterRepository.Update(parameter).Save();

            return mapper.Map<VParameter>(parameter);
        }

        public VParameter Delete(int id)
        {
            var parameter = parameterRepository.GetByID(id);

            if( parameter != null )
            {
                parameterRepository.Delete(parameter.Id).Save();
            }

            return mapper.Map<VParameter>(parameter);
        }
    }

    public interface IParameterBusiness
    {
        IEnumerable<VParameter> Get(VRequestParams vRequestParams);
        VParameter Get(int id);
        VParameter Insert(VParameter vParameter);
        VParameter Update(VParameter vParameter);
        VParameter Delete(int id);
    }
}
