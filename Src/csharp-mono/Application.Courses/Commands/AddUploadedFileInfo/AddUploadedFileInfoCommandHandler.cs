using System;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Domain.Entities;
using MediatR;

namespace Application.Courses.Commands.AddUploadedFileInfo
{
    public class AddUploadedFileInfoCommandHandler: IRequestHandler<AddUploadedFileInfoCommand, object>
    {

        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public AddUploadedFileInfoCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<object> Handle(AddUploadedFileInfoCommand request, CancellationToken cancellationToken)
        {
            bool success = false;

            try
            {
                DocumentFileDetail docDetails = new DocumentFileDetail
                {
                    ContentType = request.ContentType,
                    CreationTime= DateTime.UtcNow.ToString(),
                    CreatorUserId= _userService.UserId,
                    Description = request.Description,
                    EntityRecordId= request.EntityRecordId,
                    EntityType= request.EntityType,
                    IsDeleted= false,
                    Name= request.Name,
                    RawFileMimeType= request.RawFileMimeType,
                    RawFileSizeBytes= request.RawFileSizeBytes,
                    StorageDirectoryPath= request.StorageDirectoryPath
                };

                await _dbContext.DocumentFileDetail.AddAsync(docDetails);
                await _dbContext.SaveChangesAsync(cancellationToken);
                success = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return success;
        }
    }
}