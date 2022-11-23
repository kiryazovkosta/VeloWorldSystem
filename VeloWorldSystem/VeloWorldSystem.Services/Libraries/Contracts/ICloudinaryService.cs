using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.Services.Libraries.Contracts
{
    public interface ICloudinaryService
    {
        bool IsFileValid(IFormFile photoFile);

        Task<string> UploudAsync(IFormFile file);

        Task<string> UploudArrayAsync(byte[] file);
    }
}
