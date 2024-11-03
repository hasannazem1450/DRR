using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.FileManagement;
using DRR.Settings;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.Services.FileManagment;

public class DRRFileService : IDRRFileService
{
    private readonly FileSetting _fileSetting;

    public DRRFileService(IOptions<FileSetting> fileOptions)
    {
        _fileSetting = fileOptions.Value;
    }

    public async Task<int> GetFileSizeKb(string base64)
    {
        var result = 0;

        try
        {
            var token = ";base64,";

            var stringLength = base64.Split(token).LastOrDefault().Length;

            var sizeInBytes = 4 * Math.Ceiling((double)(stringLength / 3)) * 0.5624896334383812;
            var sizeInKb = sizeInBytes / 1000;

            result = (int)sizeInKb;
        }
        catch (Exception)
        {
        }

        return result;
    }

    public async Task<int> GetFileSizeKb(long bytes)
    {
        var result = bytes / 1024;

        return (int)result;
    }

    public async Task<string> SaveFile(DRRFile DRRFile, string base64)
    {
        var dirPath = Path.Combine(_fileSetting.RootDirectoryPath, DRRFile.EntityName);

        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);

        var fullPath = Path.Combine(dirPath, $"{DRRFile.Id}.{DRRFile.Extension}");

        var bytes = Convert.FromBase64String(base64.Split(";base64,").LastOrDefault());

        await File.WriteAllBytesAsync(fullPath, bytes);

        return fullPath;
    }

    public async Task<string> SaveFile(DRRFile DRRFile, IFormFile formFile)
    {
        var dirPath = Path.Combine(_fileSetting.RootDirectoryPath, DRRFile.EntityName);

        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);

        var fullPath = Path.Combine(dirPath, $"{DRRFile.Id}.{DRRFile.Extension}");

        using (var stream = File.Create(fullPath))
        {
            await formFile.CopyToAsync(stream);
        }

        return fullPath;
    }

    public async Task<byte[]> ReadDataFromPath(string filePath)
    {
        var bytes = await File.ReadAllBytesAsync(filePath);

        return bytes;
    }

    public async Task<string> GetMimeTypeForFileExtension(string filePath)
    {
        const string DefaultContentType = "application/octet-stream";

        var provider = new FileExtensionContentTypeProvider();

        if (!provider.TryGetContentType(filePath, out var contentType)) contentType = DefaultContentType;

        return contentType;
    }

    public async Task<ImageFileDto> ConvertToImageFileDto(DRRFile DRRFile)
    {
        var result = new ImageFileDto
        {
            Id = DRRFile.Id,
            LastModified = DRRFile.ModifiedAt ?? DRRFile.CreatedAt,
            JalaliLastModified = (DRRFile.ModifiedAt ?? DRRFile.CreatedAt).ToPersianString(),
            OriginalName = DRRFile.OriginalName,
            Extension = DRRFile.Extension,
            MimeType = await GetMimeTypeForFileExtension(DRRFile.FullPath)
        };

        return result;
    }

    public async Task<List<ImageFileDto>> ConvertToImageFileDto(List<DRRFile> DRRFiles)
    {
        var result = DRRFiles.Select(s => ConvertToImageFileDto(s).Result).ToList();

        return result;
    }
}