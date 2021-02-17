using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WB.WAPP.SEG.Business;
using WB.WAPP.SEG.VModel;
using WB.WAPP.SEG.Api.Auth;

namespace WB.WAPP.SEG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorization]
    public class ParametersController : ControllerBase
    {
        private readonly IParameterBusiness ParameterBusiness;

        public ParametersController(IParameterBusiness parameterBusiness)
        {
            this.ParameterBusiness = parameterBusiness;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]VRequestParams vRequestParams)
        {

            return Ok(this.ParameterBusiness.Get(vRequestParams));
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok(this.ParameterBusiness.Get(id));
        }

        [HttpPost]
        public ActionResult Post(VParameter vParameter)
        {
            try
            {
                if (ModelState.ErrorCount == 0)
                {
                    return Created(Request.Path.Value, this.ParameterBusiness.Insert(vParameter));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = this.ParameterBusiness.Delete(id);
                
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut]
        public ActionResult Put(VParameter vParameter)
        {
            try
            {
                if (ModelState.ErrorCount == 0)
                {
                    return Ok(this.ParameterBusiness.Update(vParameter));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return Conflict(ex.InnerException);
            }
        }

    }
}