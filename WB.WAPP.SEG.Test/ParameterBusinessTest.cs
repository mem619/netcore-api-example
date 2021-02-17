using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WB.WAPP.SEG.Business;
using WB.WAPP.SEG.Business.Repositories;
using System.Linq.Expressions;
using WB.WAPP.SEG.Entities;
using WB.WAPP.SEG.VModel;
using System.Linq;

namespace WB.WAPP.SEG.Test
{
  [TestClass]
  public class ParameterBusinessTest
  {

    private Mock<IGenericRepository<Parameter>> _genericParameterRepository;
    private Mock<IMapper> _mapperInstance;


    [TestInitialize]
    public void Initialize()
    {
      _genericParameterRepository = new Mock<IGenericRepository<Parameter>>();
      _mapperInstance = new Mock<IMapper>();

      _genericParameterRepository.Setup(s => s.Save())
        .Returns(_genericParameterRepository.Object);
      _mapperInstance.Setup(s => s.Map<Parameter>(It.IsAny<object>()))
        .Returns(new Parameter { });
      _mapperInstance.Setup(s => s.Map<VParameter>(It.IsAny<object>()))
       .Returns(new VParameter { });
    }

    [TestMethod]
    public void DeleteTest()
    {
      _genericParameterRepository.Setup(s => s.Delete(It.IsAny<int>()))
      .Returns(_genericParameterRepository.Object); ;
      var oParameters = new ParameterBusiness(_genericParameterRepository.Object, _mapperInstance.Object);
      var result =  oParameters.Delete(1);

      Assert.IsTrue(typeof(VParameter) == result.GetType());
    }

    [TestMethod]
    public void InsertTest()
    {
      _genericParameterRepository.Setup(s => s.Insert(It.IsAny<Parameter>()))
      .Returns(_genericParameterRepository.Object); ;

      var oParameters = new ParameterBusiness(_genericParameterRepository.Object, _mapperInstance.Object);
      var result = oParameters.Insert(new VParameter { });

      Assert.IsTrue(typeof(VParameter) == result.GetType());
    }

    [TestMethod]
    public void UpdateTest()
    {
      _genericParameterRepository.Setup(s => s.Update(It.IsAny<Parameter>()))
     .Returns(_genericParameterRepository.Object); ;

      var oParameters = new ParameterBusiness(_genericParameterRepository.Object, _mapperInstance.Object);
      var result = oParameters.Update(new VParameter { });

      Assert.IsTrue(typeof(VParameter) == result.GetType());
    }

    [TestMethod]
    public void GetTest()
    {
      _genericParameterRepository.Setup(s => s.Get(
          It.IsAny<Expression<Func<Parameter, bool>>>(), 
          It.IsAny<Func<IQueryable<Parameter>, 
          IOrderedQueryable<Parameter>>>(), It.IsAny<string>())
      )
     .Returns(new List<Parameter>().AsQueryable()); ;

      var oParameters = new ParameterBusiness(_genericParameterRepository.Object, _mapperInstance.Object);

      oParameters.Get(new VRequestParams { });
    }
  }
}
