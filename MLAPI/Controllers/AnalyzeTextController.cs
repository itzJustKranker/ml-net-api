namespace MLAPI.Controllers
{
    using System;
    using System.Diagnostics;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Route("api/analyze-text")]
    public class AnalyzeTextController : ApiControllerBase
    {
        private readonly IMachineLearningService _service;
        
        public AnalyzeTextController(IMachineLearningService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public ActionResult<string> Analyze([FromBody] ModelInput input)
        {
            try
            {
                var result = _service.AnalyzeText(input);
                var response =
                    $"Text: {input.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Toxic" : "Non-toxic")} sentiment";
                return Ok(response);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}