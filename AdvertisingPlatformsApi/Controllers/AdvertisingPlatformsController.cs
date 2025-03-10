using AdvertisingPlatformsApi.Extensions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatformsApi.Controllers;

[Route("api/advertising_platforms")]
public class AdvertisingPlatformsController
    (IAdveristingPlatformsService adveristingPlatformsServiceService, 
        IStorageService memoryStorageService,
        IValidatorService validatorService) : ApiBaseController
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
        var validateResult = validatorService.ValidateUploadFile(lineFile);
        if(!validateResult.IsValidate)
            return BadRequest(validateResult);
        
        try
        {
            memoryStorageService.AddPlatform(lineFile);
        }
        catch (Exception e)
        {
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
        if(!validateResult.IsValidate)
            return BadRequest(validateResult);

        try
        {
            result = await adveristingPlatformsServiceService.GetPlatforms(location);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok(result);
    }
}