using AdvertisingPlatformsApi.Extensions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatformsApi.Controllers;

[Route("api/advertising_platforms")]
public class AdvertisingPlatformsController
    (IAdveristingPlatformsService adveristingPlatformsServiceService, 
        IStorageService memoryStorageService,
        IValidatorService validatorService,
        ILogger<AdvertisingPlatformsController> logger) : ApiBaseController
{
    /// <summary>
    /// метод загрузки файла
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UploadPlatforms(IFormFile file)
    {
        var lineFile = file.ReadAllLines();
        var validateResult = validatorService.ValidateLinesUploadFile(lineFile);
        
        if (!validateResult.IsValidate)
            return BadRequest(validateResult);
        
        try
        {
            memoryStorageService.AddPlatform(lineFile);
        }
        catch (Exception e)
        {
            logger.LogError($"[{DateTime.Now}] url: {Url.Action()}, method: UploadPlatforms, file: {file?.FileName}\n" +
                            $" Error: {e.StackTrace}");
            return BadRequest(e.Message);
        }
        
        return Ok();
    }

    /// <summary>
    /// метод получения площадок по введенной локации
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetPlatforms(string location)
    {
        List<string> result = null;
        var validateResult = validatorService.ValidateLocationParameter(location);
        if (!validateResult.IsValidate) 
            return BadRequest(validateResult);
        
        try
        {
            result = await adveristingPlatformsServiceService.GetPlatforms(location);
        }
        catch (Exception e)
        {
            logger.LogError($"[{DateTime.Now}] url: {Url.Action()}, method: UploadPlatforms\n" +
                            $" Error: {e.StackTrace}");
            return BadRequest(e.Message);
        }
        
        return Ok(result);
    }
}