using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.FileManagment;

public interface IDRRFileService : IService
{
    Task<int> GetFileSizeKb(string base64);
    Task<int> GetFileSizeKb(Int64 bytes);
    Task<string> SaveFile(DRRFile DRRFile, string base64);
    Task<string> SaveFile(DRRFile DRRFile, IFormFile formFile);
    Task<byte[]> ReadDataFromPath(string filePath);
    Task<string> GetMimeTypeForFileExtension(string filePath);

    Task<ImageFileDto> ConvertToImageFileDto(DRRFile DRRFile);
    Task<List<ImageFileDto>> ConvertToImageFileDto(List<DRRFile> DRRFiles);
}